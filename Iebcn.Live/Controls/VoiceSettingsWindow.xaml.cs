using Iebcn.Live.Helper;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// VoiceSettingsWindow.xaml 的交互逻辑
	/// </summary>
	public partial class VoiceSettingsWindow : Window, IComponentConnector
	{
		private DanmuSetting V9Z;

		public bool IsClosed;

		public VoiceSettingsWindow()
		{
			InitializeComponent();
			gridCust.Visibility = Visibility.Collapsed;
			if (Common.danmuSetting.Agent.IsAgent)
			{
				linkHelp.Visibility = Visibility.Collapsed;
			}
			base.Loaded += g9n;
			base.DataContext = (V9Z = Common.danmuSetting);
			combSpeakers.ItemsSource = Common.VoiceList;
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				Util.SaveDanmuSetting();
				IsClosed = true;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(GetType()?.ToString() + ex.Message);
			}
		}

		private void g9n(object sender, RoutedEventArgs e)
		{
			foreach (Voice item in combSpeakers.Items)
			{
				if (item.SpeakerValue == V9Z.VoiceDanmu.Voice.SpeakerValue)
				{
					combSpeakers.SelectedItem = item;
					break;
				}
			}
		}

		private void U94(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void z9f(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void M9F(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (sender != null && combSpeakers.SelectedItem != null && combSpeakers.SelectedItem is Voice voice)
				{
					V9Z.VoiceDanmu.Voice.SpeakerValue = voice.SpeakerValue;
					V9Z.VoiceDanmu.Voice.SpeakerName = voice.SpeakerName;
					V9Z.VoiceDanmu.Voice.Platform = voice.Platform;
					_ = voice.Platform;
				}
			}
			catch
			{
			}
		}

		private void O9w(object sender, RoutedEventArgs e)
		{
			J9C();
		}

		private async void J9C()
		{
			await VoiceHelper.VoiceDanmu(new DanmuData
			{
				GiftCount = 8,
				GiftName = "火箭",
				UserNick = "思聪老板",
				Type = DanmuType.Gift,
				UserHeadPic = "Pack://application:,,,/Assets/sampleHead1.jpg"
			});
		}

		private void r93(object sender, RoutedEventArgs e)
		{
			try
			{
				ForbiddenWordsSettingWindow forbiddenWordsSettingWindow = new ForbiddenWordsSettingWindow();
				forbiddenWordsSettingWindow.Owner = Common.mainWindow;
				forbiddenWordsSettingWindow.ShowDialog();
			}
			catch
			{
			}
		}

		private void R9O(object sender, RoutedEventArgs e)
		{
			SilenceHelper.ShowWindow();
		}

		private void I9U(object sender, RoutedEventArgs e)
		{
			S9W();
		}

		private void S9W()
		{
			if (Common.VIPLevel < 1)
			{
				MessageBox.Show(Common.Msg_NeedVip1);
			}
		}

		private void N9a()
		{
			if (Common.VIPLevel < 2)
			{
				MessageBox.Show(Common.Msg_NeedVip2);
			}
		}

		private void D9N(object sender, MouseButtonEventArgs e)
		{
			S9W();
		}

		private void r9P(object sender, RoutedEventArgs e)
		{
		}

		private void X9u(object sender, RoutedEventArgs e)
		{
			try
			{
				if (ChatBotHelper.window != null && !ChatBotHelper.window.IsClosed && Common.danmuSetting.ChatBot.Enabled)
				{
					MessageBox.Show("警告：你开启了数字人（数字人是独立的），这里再开启语音播报会导致与数字人声音重叠！");
				}
			}
			catch
			{
			}
		}

		private void Q9L(object sender, RoutedEventArgs e)
		{
			N9a();
		}

		private void r91(object sender, RoutedEventArgs e)
		{
			gridCust.Visibility = Visibility.Visible;
		}

		private void G9m(object sender, RoutedEventArgs e)
		{
			gridCust.Visibility = Visibility.Collapsed;
		}

		private void R9r(object sender, RoutedEventArgs e)
		{
			object tag = (sender as Button).Tag;
			object obj;
			if (tag != null)
			{
				obj = tag.ToString();
				if (obj != null)
				{
					goto IL_0021;
				}
			}
			else
			{
				obj = null;
			}
			obj = "";
			goto IL_0021;
		IL_0021:
			string text = (string)obj;
			string text2 = "";
			if (!(text.Trim() == "1"))
			{
				if (!(text.Trim() == "2"))
				{
					if (!(text.Trim() == "3"))
					{
						if (text.Trim() == "4")
						{
							text2 = V9Z.VoiceDanmu.CustomVoiceUrl4;
						}
						else if (text.Trim() == "5")
						{
							text2 = V9Z.VoiceDanmu.CustomVoiceUrl5;
						}
					}
					else
					{
						text2 = V9Z.VoiceDanmu.CustomVoiceUrl3;
					}
				}
				else
				{
					text2 = V9Z.VoiceDanmu.CustomVoiceUrl2;
				}
			}
			else
			{
				text2 = V9Z.VoiceDanmu.CustomVoiceUrl1;
			}
			if (text2.Trim().Length > 12)
			{
				if (!text2.Trim().ToLower().StartsWith("http://") && !text2.Trim().ToLower().StartsWith("https://"))
				{
					MessageBox.Show("不是有效的地址！");
				}
				else
				{
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
					VoiceHelper.TestCustVoice(text2.Trim(), "欢迎使用自定义音色");
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				}
			}
		}

		private void D9A(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl(Config.HelpUrlCustVoice);
		}

	}

}
