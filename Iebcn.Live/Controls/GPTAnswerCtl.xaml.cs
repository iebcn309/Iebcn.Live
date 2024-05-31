using Iebcn.Live.Helper;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Iebcn.Live.ViewModel;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// GPTAnswerCtl.xaml 的交互逻辑
	/// </summary>
	public partial class GPTAnswerCtl : System.Windows.Controls.UserControl, IComponentConnector
	{
		private GPTModel SZS = new GPTModel();

		private GPTWindow jZZ;

		public GPTAnswerCtl(DanmuData data, GPTWindow parent)
		{
			InitializeComponent();
			base.DataContext = SZS;
			jZZ = parent;
			tZa(data);
		}

		public GPTAnswerCtl(string initText)
		{
			InitializeComponent();
			txt1.Text = initText;
			loading.Visibility = Visibility.Collapsed;
		}

		private async void tZa(DanmuData danmuData_0)
		{
			jZZ.isBusy = true;
			loading.Visibility = Visibility.Visible;
			txt1.UpdateLayout();
			_ = DateTime.Now;
			string answer = "";
			try
			{
				HttpClient httpClient = new HttpClient();
				try
				{
					((HttpHeaders)httpClient.DefaultRequestHeaders).Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
					((HttpHeaders)httpClient.DefaultRequestHeaders).Add("Origin", "https://chat18.aichatos.xyz");
					((HttpHeaders)httpClient.DefaultRequestHeaders).Add("Referer", "https://chat18.aichatos.xyz/");
					((HttpHeaders)httpClient.DefaultRequestHeaders).Add("Sec-Ch-Ua", "'Not.A/Brand';v='8', 'Chromium';v='114', 'Google Chrome';v='114'");
					((HttpHeaders)httpClient.DefaultRequestHeaders).Add("Sec-Ch-Ua-Platform", "Windows");
					StringContent content = new StringContent(JsonConvert.SerializeObject(new
					{
						prompt = danmuData_0.PureMsg,
						userId = GPTHelper.GPT_USER_ID,
						network = true,
						system = "",
						withoutContext = false,
						stream = false
					}), Encoding.UTF8, "application/json");
					HttpRequestMessage val = new HttpRequestMessage(HttpMethod.Post, "https://api.binjie.fun/api/generateStream")
					{
						Content = (HttpContent)(object)content
					};
					using (Stream responseStream = await (await httpClient.SendAsync(val, (HttpCompletionOption)1)).Content.ReadAsStreamAsync())
					{
						loading.Visibility = Visibility.Collapsed;
						byte[] buffer = new byte[1024];
						int count;
						while ((count = await responseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
						{
							string @string = Encoding.UTF8.GetString(buffer, 0, count);
							answer += @string;
							SZS.txt = answer;
						}
					}
				}
				finally
				{
					((IDisposable)httpClient)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				loading.Visibility = Visibility.Collapsed;
				SZS.txt = ex.Message;
			}
			jZZ.isBusy = false;
			//SocketServer.SendMessage(new DanmuData
			//{
			//	Type = DanmuType.App,
			//	UserNick = "ChatGPT",
			//	Msg = danmuData_0.Msg + "->ChatGPT:" + answer
			//});
		}

		private void PZ1(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.Clipboard.SetText(txt1.Text, System.Windows.Forms.TextDataFormat.Text);
		}

		private void sZm(object sender, System.Windows.Input.MouseEventArgs e)
		{
			btnCopy.Visibility = Visibility.Visible;
		}

		private void JZr(object sender, System.Windows.Input.MouseEventArgs e)
		{
			btnCopy.Visibility = Visibility.Collapsed;
		}

		private void hZA(object sender, MouseButtonEventArgs e)
		{
			System.Windows.Forms.Clipboard.SetText(txt1.Text, System.Windows.Forms.TextDataFormat.Text);
		}
	}

}
