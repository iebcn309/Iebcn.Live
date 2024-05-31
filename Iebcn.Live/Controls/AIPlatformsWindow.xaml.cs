using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// AIPlatformsWindow.xaml 的交互逻辑
	/// </summary>
	public partial class AIPlatformsWindow : Window, IComponentConnector
	{
		private static int eq8;

		private string Lqp = "";

		public bool IsClosed;

		private static List<DanmuData> wqb;
		private Random CqR = new Random();

		private bool vqY;
		private string Mqh = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";

		public AIPlatformsWindow()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.ChatBot;
			base.Closed += qqK;
			tqQ();
			Vqf();
			NqF();
		}

		protected override  void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (MessageBox.Show("退出还是最小化？Yes=退出，No=最小化！退出后将关闭大模型交互！", "退出还是最小化？", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				wqb.Clear();
				base.OnClosing(e);
				IsClosed = true;
			}
			else
			{
				e.Cancel = true;
				base.WindowState = WindowState.Minimized;
			}
		}

		private void qqK(object sender, EventArgs e)
		{
		}

		private async Task tqQ()
		{
			AppLog.AddLog("InitializeAsync Iebcn.Live.ControlsAIPlatforms_Browser...........");
			try
			{
				CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions
				{
					AdditionalBrowserArguments = "--autoplay-policy=user-gesture-required"
				};
				CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Path.GetTempPath(), "Iebcn.Live.ControlsAIPlatforms_Browser"), options);
				await webView.EnsureCoreWebView2Async(environment);
				webView.CoreWebView2.NavigationCompleted += jq1;
				webView.CoreWebView2.NewWindowRequested += Oqq;
				webView.CoreWebView2.NavigationStarting += Uqe;
				webView.CoreWebView2.Settings.AreHostObjectsAllowed = true;
				webView.CoreWebView2.Settings.UserAgent = Mqh;
				webView.CoreWebView2.WebResourceResponseReceived += Hq4;
				vqY = true;
				AppLog.AddLog("InitializeAsync...compete.");
			}
			catch (Exception ex)
			{
				AppLog.AddLog("Live window init webview err:" + ex.Message);
				MessageBox.Show("Live window init webview err:\r\n" + ex.Message);
			}
		}

		private void Uqe(object sender, CoreWebView2NavigationStartingEventArgs e)
		{
			if (!e.IsUserInitiated)
			{
				e.Cancel = true;
				webView.Source = new Uri("https://xinghuo.xfyun.cn/desk");
			}
		}

		private void Oqq(object sender, CoreWebView2NewWindowRequestedEventArgs e)
		{
			e.Handled = true;
		}

		private void Dqn(object sender, CoreWebView2InitializationCompletedEventArgs e)
		{
			try
			{
				CoreWebView2Cookie cookie = webView.CoreWebView2.CookieManager.CreateCookie("LOGIN_STATUS", "1", ".douyin.com", "/");
				webView.CoreWebView2.CookieManager.AddOrUpdateCookie(cookie);
			}
			catch (Exception)
			{
			}
		}

		private async void Hq4(object sender, CoreWebView2WebResourceResponseReceivedEventArgs e)
		{
			int num = 0;
			if ((uint)num > 1u)
			{
				return;
			}
			try
			{
				if (e.Request.Uri.StartsWith("https://qianwen.aliyun.com/conversation") && e.Response != null && e.Response.StatusCode == 200)
				{
					await new StreamReader(await e.Response.GetContentAsync()).ReadToEndAsync();
				}
			}
			catch (Exception)
			{
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		public async void AddData(DanmuData data)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			wqb.Add(data);
			if (wqb.Count > eq8)
			{
				wqb.RemoveAt(0);
			}
		}

		private async void Vqf()
		{
			Exception obj4;
			while (true)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (IsClosed)
						{
							goto end_IL_0060;
						}
						if (webView.CoreWebView2 == null || !Common.danmuSetting.ChatBot.ReplyFromChinaAI)
						{
							goto IL_033a;
						}
						if (!webView.CoreWebView2.Source.StartsWith("https://tongyi.aliyun.com/qianwen"))
						{
							if (webView.CoreWebView2.Source.StartsWith("https://www.doubao.com/chat"))
							{
								await zq3();
							}
							else if (webView.CoreWebView2.Source.StartsWith("https://yiyan.baidu.com"))
							{
								await Yqw();
							}
							else if (!webView.CoreWebView2.Source.StartsWith("https://www.chatglm.cn/main/detail"))
							{
								if (webView.CoreWebView2.Source.StartsWith("https://xinghuo.xfyun.cn/desk"))
								{
									await nqU();
								}
							}
							else
							{
								await DqO();
							}
						}
						else
						{
							await PqC();
						}
						goto end_IL_0044;
					end_IL_0060:;
					}
					catch
					{
						goto end_IL_0044;
					}
					num = 2;
					goto end_IL_0044;
				IL_033a:
					num = 1;
				end_IL_0044:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(300);
				obj4 = obj;
				if (obj4 != null)
				{
					Exception obj5 = obj4 as Exception;
					if (obj5 == null)
					{
						break;
					}
					ExceptionDispatchInfo.Capture(obj5).Throw();
				}
				int num2 = num;
				if (num2 != 1 && num2 == 2)
				{
					return;
				}
			}
			throw obj4;
		}

		private async void NqF()
		{
			Exception obj4;
			while (true)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (IsClosed)
						{
							goto end_IL_0045;
						}
						if (webView.CoreWebView2 == null)
						{
							goto IL_0135;
						}
						if (webView.CoreWebView2.Source.StartsWith("https://tongyi.aliyun.com/qianwen"))
						{
							cqW();
						}
						else if (!webView.CoreWebView2.Source.StartsWith("https://www.doubao.com/chat"))
						{
							if (webView.CoreWebView2.Source.StartsWith("https://yiyan.baidu.com"))
							{
								AqN();
							}
							else if (webView.CoreWebView2.Source.StartsWith("https://xinghuo.xfyun.cn/desk"))
							{
								tqu();
							}
							else if (webView.CoreWebView2.Source.StartsWith("https://www.chatglm.cn/main/detail"))
							{
								JqP();
							}
						}
						else
						{
							vqa();
						}
						goto end_IL_0045_2;
					end_IL_0045:;
					}
					catch
					{
						goto end_IL_0045_2;
					}
					num = 2;
					goto end_IL_0045_2;
				IL_0135:
					num = 1;
				end_IL_0045_2:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(300);
				obj4 = obj;
				if (obj4 != null)
				{
					Exception obj5 = obj4 as Exception;
					if (obj5 == null)
					{
						break;
					}
					ExceptionDispatchInfo.Capture(obj5).Throw();
				}
				int num2 = num;
				if (num2 != 1 && num2 == 2)
				{
					return;
				}
			}
			throw obj4;
		}

		private async Task Yqw()
		{
			try
			{
				DanmuData data = wqb.LastOrDefault();
				if (data != null)
				{
					string yiyanPost = W4L.G4r().YiyanPost;
					string msg = data.PureMsg;
					yiyanPost = yiyanPost.Replace("{msg}", msg.Replace("'", "'"));
					if (await webView.ExecuteScriptAsync(yiyanPost) == "1")
					{
						wqb.Remove(data);
						Eqt("发送成功:" + msg);
						await wqL();
						await Task.Delay(1000);
					}
				}
			}
			catch
			{
			}
		}

		private async Task PqC()
		{
			try
			{
				DanmuData data = wqb.LastOrDefault();
				if (data != null)
				{
					string tongyiPost = W4L.G4r().TongyiPost;
					string msg = data.PureMsg ?? "";
					tongyiPost = tongyiPost.Replace("{msg}", msg.Replace("'", "'"));
					if (await webView.ExecuteScriptAsync(tongyiPost) == "1")
					{
						wqb.Remove(data);
						Eqt("发送成功:" + msg);
						await wqL();
						await Task.Delay(1000);
					}
				}
			}
			catch
			{
			}
		}

		private async Task zq3()
		{
			try
			{
				DanmuData data = wqb.LastOrDefault();
				if (data != null)
				{
					string doubaoPost = W4L.G4r().DoubaoPost;
					string msg = data.PureMsg;
					doubaoPost = doubaoPost.Replace("{msg}", msg.Replace("'", "'"));
					if (await webView.ExecuteScriptAsync(doubaoPost) == "1")
					{
						wqb.Remove(data);
						Eqt("发送成功:" + msg);
						await wqL();
						await Task.Delay(1000);
					}
				}
			}
			catch
			{
			}
		}

		private async Task DqO()
		{
			try
			{
				DanmuData data = wqb.LastOrDefault();
				if (data != null)
				{
					string qingyanPost = W4L.G4r().QingyanPost;
					string msg = data.PureMsg;
					qingyanPost = qingyanPost.Replace("{msg}", msg.Replace("'", "'"));
					if (await webView.ExecuteScriptAsync(qingyanPost) == "1")
					{
						wqb.Remove(data);
						Eqt("发送成功:" + msg);
						await wqL();
						await Task.Delay(1000);
					}
				}
			}
			catch
			{
			}
		}

		private async Task nqU()
		{
			try
			{
				DanmuData data = wqb.LastOrDefault();
				if (data != null)
				{
					string xinghuoPost = W4L.G4r().XinghuoPost;
					string msg = data.PureMsg;
					xinghuoPost = xinghuoPost.Replace("{msg}", msg.Replace("'", "'"));
					if (await webView.ExecuteScriptAsync(xinghuoPost) == "1")
					{
						wqb.Remove(data);
						Eqt("发送成功:" + msg);
						await wqL();
						await Task.Delay(1000);
					}
				}
			}
			catch
			{
			}
		}

		private async void cqW()
		{
			try
			{
				string tongyiReply = W4L.G4r().TongyiReply;
				string text = await webView.CoreWebView2.ExecuteScriptAsync(tongyiReply);
				if (text == "null")
				{
					return;
				}
				text = text.Trim('"');
				if (!(text == ""))
				{
					string text2 = text.Substring(0, text.IndexOf("--==--"));
					string text3 = text.Substring(text2.Length, text.Length - text2.Length).Replace("--==--", "").Replace("\\n", "\n")
						.Replace("\\r", "\r");
					text3 = text3.Replace("\\\"", "\"");
					if (!(text3 == Lqp) && !(text3 == "") && !(text2 == ""))
					{
						Lqp = text3;
						sGa.hGL(new BotResult
						{
							IsChat = true,
							OK = true,
							Result = text3,
							Query = text2
						});
					}
				}
			}
			catch
			{
			}
		}

		private async void vqa()
		{
			try
			{
				string doubaoReply = W4L.G4r().DoubaoReply;
				string text = await webView.CoreWebView2.ExecuteScriptAsync(doubaoReply);
				if (text == "null" || text == "\"\"")
				{
					return;
				}
				text = text.Trim('"');
				if (!(text == ""))
				{
					string text2 = text.Substring(0, text.IndexOf("--==--"));
					string text3 = text.Substring(text2.Length, text.Length - text2.Length).Replace("--==--", "").Replace("\\n", "\n")
						.Replace("\\r", "\r");
					text3 = text3.Replace("\\\"", "\"");
					if (!(text3 == Lqp))
					{
						Lqp = text3;
						sGa.hGL(new BotResult
						{
							IsChat = true,
							OK = true,
							Result = text3,
							Query = text2
						});
					}
				}
			}
			catch
			{
			}
		}

		private async void AqN()
		{
			try
			{
				string yiyanReply = W4L.G4r().YiyanReply;
				string text = await webView.CoreWebView2.ExecuteScriptAsync(yiyanReply);
				if (text == "null" || text == "\"\"")
				{
					return;
				}
				text = text.Trim('"');
				if (!(text == ""))
				{
					string text2 = text.Substring(0, text.IndexOf("--==--"));
					string text3 = text.Substring(text2.Length, text.Length - text2.Length).Replace("--==--", "").Replace("\\n", "\n")
						.Replace("\\r", "\r");
					text3 = text3.Replace("\\\"", "\"");
					if (!(text2 == Lqp))
					{
						Lqp = text2;
						sGa.hGL(new BotResult
						{
							IsChat = true,
							OK = true,
							Result = text3,
							Query = text2
						});
					}
				}
			}
			catch
			{
			}
		}

		private async void JqP()
		{
			try
			{
				string qingyanReply = W4L.G4r().QingyanReply;
				string text = await webView.CoreWebView2.ExecuteScriptAsync(qingyanReply);
				if (text == "null" || text == "\"\"")
				{
					return;
				}
				text = text.Trim('"');
				if (!(text == ""))
				{
					string text2 = text.Substring(0, text.IndexOf("--==--"));
					string text3 = text.Substring(text2.Length, text.Length - text2.Length).Replace("--==--", "").Replace("\\n", "\n")
						.Replace("\\r", "\r");
					text3 = text3.Replace("\\\"", "\"");
					if (!(text3 == Lqp))
					{
						Lqp = text3;
						sGa.hGL(new BotResult
						{
							IsChat = true,
							OK = true,
							Result = text3,
							Query = text2
						});
					}
				}
			}
			catch
			{
			}
		}

		private async void tqu()
		{
			try
			{
				string xinghuoReply = W4L.G4r().XinghuoReply;
				string text = await webView.CoreWebView2.ExecuteScriptAsync(xinghuoReply);
				if (text == "null" || text == "\"\"")
				{
					return;
				}
				text = text.Trim('"');
				if (!(text == ""))
				{
					string text2 = text.Substring(0, text.IndexOf("--==--"));
					string text3 = text.Substring(text2.Length, text.Length - text2.Length).Replace("--==--", "").Replace("\\n", "\n")
						.Replace("\\r", "\r");
					text3 = text3.Replace("\\\"", "\"");
					if (!(text3 == Lqp))
					{
						Lqp = text3;
						sGa.hGL(new BotResult
						{
							IsChat = true,
							OK = true,
							Result = text3,
							Query = text2
						});
					}
				}
			}
			catch
			{
			}
		}

		private async Task wqL()
		{
			await Task.Delay(1000 * Common.danmuSetting.ChatBot.AIPlatformRequestIntervalSeconds);
		}

		private async void jq1(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			try
			{
				await webView.CoreWebView2.ExecuteScriptAsync("function ondevtoolopen(){};function DV(){};function MV(){};");
				await webView.CoreWebView2.ExecuteScriptAsync("document.body.innerHTML");
			}
			catch
			{
			}
		}

		private void jqA(object sender, ContextMenuEventArgs e)
		{
			e.Handled = true;
		}

		private void sqS(object sender, CoreWebView2WebMessageReceivedEventArgs e)
		{
			string webMessageAsString = e.TryGetWebMessageAsString();
			webView.CoreWebView2.PostWebMessageAsString(webMessageAsString);
		}

		public async Task OpenPage(string url)
		{
			if (!vqY)
			{
				await tqQ();
			}
			try
			{
				webView.CoreWebView2.Settings.UserAgent = Mqh;
			}
			catch
			{
			}
			webView.Source = new Uri(url);
		}

		public void DisposeWebview()
		{
			try
			{
				webView.Dispose();
			}
			catch
			{
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void Eqt(string string_0)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
		}

		private void SqD(object sender, CancelEventArgs e)
		{
			DisposeWebview();
		}

		public void ShowWind()
		{
			if (base.RenderSize.Width <= 160.0)
			{
				if (SystemParameters.PrimaryScreenWidth > 1440.0 && SystemParameters.PrimaryScreenHeight > 800.0)
				{
					base.Width = 1440.0;
					base.Height = 800.0;
				}
				else
				{
					base.Width = SystemParameters.PrimaryScreenWidth * 0.9;
					base.Height = SystemParameters.PrimaryScreenHeight * 0.9;
				}
				base.Left = (SystemParameters.PrimaryScreenWidth - base.Width) / 2.0;
				base.Top = (SystemParameters.PrimaryScreenHeight - base.Height) / 2.0;
				Activate();
			}
		}

		private void rqk(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void vqM(object sender, RoutedEventArgs e)
		{
			object tag = (sender as Button).Tag;
			object obj;
			if (tag == null)
			{
				obj = null;
			}
			else
			{
				obj = tag.ToString();
				if (obj != null)
				{
					goto IL_0020;
				}
			}
			obj = "";
			goto IL_0020;
		IL_0020:
			string uriString = (string)obj;
			webView.Source = new Uri(uriString);
		}

		private async void Tqi(object sender, RoutedEventArgs e)
		{
			try
			{
				string text = await webView.CoreWebView2.ExecuteScriptAsync(txt.Text);
				base.Title = text ?? "";
				File.WriteAllText("D:\\xunfei.html", text);
			}
			catch
			{
			}
		}

		static AIPlatformsWindow()
		{
			eq8 = 3;
			wqb = new List<DanmuData>();
		}

	}
	internal static class W4L
	{
		[CompilerGenerated]
		private static AIPlateformConfig v4Z;

		public static string y4t;

		[SpecialName]
		[CompilerGenerated]
		public static AIPlateformConfig G4r()
		{
			return v4Z;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void X4A(AIPlateformConfig aiplateformConfig_0)
		{
			v4Z = aiplateformConfig_0;
		}

		public static void A4m(string string_0)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(string_0);
				string string_ = xmlDocument.SelectSingleNode("app/aicfg").InnerText.Trim();
				AIPlateformConfig aIPlateformConfig = JsonConvert.DeserializeObject<AIPlateformConfig>(G4r().Decode(string_));
				if (aIPlateformConfig != null)
				{
					X4A(aIPlateformConfig);
				}
				XmlNode xmlNode = xmlDocument.SelectSingleNode("app/urlcfg/FakeGiftZipUrl");
				if (xmlNode != null)
				{
					y4t = xmlNode.InnerText.Trim();
				}
			}
			catch (Exception ex)
			{
				AppLog.AddLog("ParseRemoteConfig err" + ex.Message);
			}
		}

		static W4L()
		{
			v4Z = new AIPlateformConfig();
			y4t = "";
		}


	}
}
