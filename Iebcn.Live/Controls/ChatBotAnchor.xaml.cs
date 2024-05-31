using System.Net.Http.Headers;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using NAudio.Wave;
using System.IO;
using System.Text.Json;
using Iebcn.Live.Helper;
using Newtonsoft.Json;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// ChatBotAnchor.xaml 的交互逻辑
	/// </summary>
	public partial class ChatBotAnchor : Window
	{
		public bool IsClosed;
		private bool _isRecording;
		public WaveIn WaveIn { get; set; }
		public WaveFileWriter WaveWriter { get; set; }
		private string _recordFileName = "rec.wav";
        Point _pressedPosition;
        bool _isDragMoved = false;
        public ChatBotAnchor()
		{
			InitializeComponent();
			Loaded += OnLoaded;
			MouseLeftButtonDown += OnMouseLeftButtonDown;
		}
        void Window_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _pressedPosition = e.GetPosition(this);
        }
        void Window_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed && _pressedPosition != e.GetPosition(this))
            {
                _isDragMoved = true;
                DragMove();
            }
        }
        void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragMoved)
            {
                _isDragMoved = false;
                e.Handled = true;
            }
        }
        /// <summary>
        /// 开始录音
        /// </summary>
        /// <param name="filePath">录音文件路径</param>
        public void StartRecord(string filePath)
		{
			try
			{
				WaveIn = new WaveIn();
				WaveIn.DataAvailable += OnDataAvailable;
				WaveWriter = new WaveFileWriter(filePath, WaveIn.WaveFormat);
				WaveIn.StartRecording();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"StartRecord error: {ex.Message}");
			}
		}
		/// <summary>
		/// 停止录音
		/// </summary>
		public void StopRecord()
		{
			try
			{
				WaveIn?.StopRecording();
				WaveIn?.Dispose();
				WaveIn = null;
				WaveWriter?.Close();
				WaveWriter?.Dispose();
				WaveWriter = null;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"StopRecord error: {ex.Message}");
			}
		}
		private void OnDataAvailable(object sender, WaveInEventArgs e)
		{
			try
			{
				if (WaveWriter != null)
				{
					WaveWriter.Write(e.Buffer, 0, e.BytesRecorded);
					var length = (int)WaveWriter.Length / WaveWriter.WaveFormat.AverageBytesPerSecond;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"OnDataAvailable error: {ex.Message}");
			}
		}
		// 窗口关闭事件
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
		}
		// 关闭按钮点击事件
		private void x_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
		// 窗口加载事件
		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			loading.Visibility = Visibility.Collapsed;
		}
		// 上传音频文件并获取识别结果
		private async void Test(string file = "")
		{
			string uploadUri = "https://aidemo.youdao.com/asr?lang=zh-CHS&mutiSentences=false";
			byte[] fullFile = File.ReadAllBytes(file);
			string text = await UploadAudioFile(uploadUri, fullFile);
			txt.Text = text;
			if (!string.IsNullOrEmpty(text))
			{
				DanmuData item = new DanmuData
				{
					Type = DanmuType.Chat,
					UserNick = "主播",
					Msg = ":" + text
				};
				ChatBotHelper.KeyReplyChatDanmuList.Add(item);
				ChatBotHelper.CacheChatDanmuList.Add(item);
			}
		}
		// 上传音频文件
		private async Task<string> UploadAudioFile(string uploadUri, byte[] audioFile)
		{
			Uri uri = new Uri(uploadUri);
			HttpClient client = new HttpClient();
			client.Timeout = TimeSpan.FromSeconds(8);
			MultipartFormDataContent content = new MultipartFormDataContent();
			ByteArrayContent audioContent = new ByteArrayContent(audioFile);
			audioContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");
			audioContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
			{
				Name = "audioData",
				FileName = "blob"
			};
			content.Add(audioContent);
			try
			{
				string responseJson = await client.PostAsync(uri, content).Result.Content.ReadAsStringAsync();
				dynamic response =JsonConvert.DeserializeObject<object>(responseJson);
				return response.result[0].ToString();
			}
			catch
			{
				return "";
			}
			finally
			{
				content.Dispose();
				client.Dispose();
			}
		}
		// 鼠标左键按下事件
		private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.Source.Equals(btnRecord))
			{
				return;
			}
		}
		// 开始录音按钮点击事件
		private void OnStartRecording(object sender, MouseButtonEventArgs e)
		{
			gifRecording.Visibility = Visibility.Visible;
			_isRecording = true;
			StartRecord(_recordFileName);
		}
		// 停止录音按钮点击事件
		private void OnStopRecording(object sender, MouseButtonEventArgs e)
		{
			gifRecording.Visibility = Visibility.Collapsed;
			UpdateLayout();
			_isRecording = false;
			StopRecord();
			Test(_recordFileName);
		}
		// 清空缓存按钮点击事件
		private void OnClearCache(object sender, RoutedEventArgs e)
		{
			try
			{
				ChatBotHelper.CacheChatDanmuList.Clear();
				ChatBotHelper.CacheTksList.Clear();
				ChatBotHelper.BotResultList.Clear();
			}
			catch
			{
			}
		}
		// 发送聊天弹幕按钮点击事件
		private void OnSendChatDanmu(object sender, RoutedEventArgs e)
		{
			if (Common.danmuSetting.ChatBot.Enabled)
			{
				if (!string.IsNullOrWhiteSpace(txtInput.Text))
				{
					ChatBotHelper.CacheChatDanmuList.Add(new DanmuData
					{
						Type = DanmuType.Chat,
						UserNick = "主播",
						Msg = txtInput.Text
					});
				}
			}
			else
			{
				MessageBox.Show("请先开启数字人");
			}
		}
		// 添加主播发言按钮点击事件
		private void OnAddAnchorSpeak(object sender, RoutedEventArgs e)
		{
			if (Common.danmuSetting.ChatBot.Enabled)
			{
				if (!string.IsNullOrWhiteSpace(txtInput.Text))
				{
					ChatBotHelper.AddAnchorSpeak(txtInput.Text.Trim());
				}
			}
			else
			{
				MessageBox.Show("请先开启数字人");
			}
		}
		private void OnTestPlayGiftVideo(object sender, RoutedEventArgs e)
		{
			if (Common.danmuSetting.ChatBot.Enabled)
			{
				ChatBotHelper.TestPlayGiftVideo();
			}
			else
			{
				MessageBox.Show("请先开启数字人");
			}
		}
	}
}
