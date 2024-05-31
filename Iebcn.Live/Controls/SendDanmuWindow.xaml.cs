using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// SendDanmuWindow.xaml 的交互逻辑
	/// </summary>
	public partial class SendDanmuWindow : Window, IComponentConnector
	{
		private DateTime a0E = DateTime.Now.AddMinutes(-5.0);

		private DateTime M0l = DateTime.Now.AddMinutes(-5.0);

		private DateTime c0z = DateTime.Now.AddMinutes(-5.0);

		private AutoSendDanmu Whs;

		private bool Yhx;

		private Random ohd = new Random();

		private bool whH;

		private StringBuilder sb = new StringBuilder();

		private int QhK;
		private string ihe = "setInterval(function(){ \r\n//mouse over\r\n  var event = document.createEvent(\"MouseEvents\");\r\n      event.initEvent('mouseover', true, false);\r\n     document.body.dispatchEvent(event);\r\n\t console.log('createEvent');\r\n //click  \r\nconst event2 = document.createEvent('Events');\r\nevent2.initEvent( 'click', true, false );\r\ndocument.body.dispatchEvent(event2);\r\n\r\nvar event3 = document.createEvent(\"UIEvents\");\r\nevent3.initUIEvent(\"keypress\", true, true, window, 1);\r\nevent3.keyCode = 38;//up\r\ndocument.body.dispatchEvent(event3);\r\n\r\n}, 60000);\r\n";

		public bool IsClosed;

		public SendDanmuWindow()
		{
			InitializeComponent();
			DanmuSender._welcomeMessages.Clear();
			gridSetting.Visibility = Visibility.Collapsed;
			gridLog.Visibility = Visibility.Collapsed;
			base.DataContext = (Whs = Common.danmuSetting.AutoSendDanmu);
			h0r();
			u0S();
			C0A();
			q0c();
		}

		private async Task y0m()
		{
			AppLog.AddLog("Web InitializeAsync  DouyinDanmuSendDanmu_Browser... ");
			string envFolderName = "DouyinDanmuSendDanmu_Browser";
			try
			{
				CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions
				{
					AdditionalBrowserArguments = "--autoplay-policy=user-gesture-required"
				};
				CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Path.GetTempPath(), envFolderName), options);
				await webView.EnsureCoreWebView2Async(environment);
				webView.CoreWebView2.NavigationCompleted += E08;
				webView.ContextMenuOpening += s0b;
				webView.CoreWebView2.Settings.AreHostObjectsAllowed = true;
				Yhx = true;
				p0Y("Initialize complete: " + envFolderName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("senddanmu init webview err:\r\n" + ex.Message);
				AppLog.AddLog(ex.Message);
				p0Y(ex.Message ?? "");
			}
		}

		private async void h0r()
		{
			if (Common.VIPLevel < 1)
			{
				return;
			}
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
							goto end_IL_0072;
						}
						if (webView == null || !Whs.WelcomeEnabled)
						{
							goto IL_00e7;
						}
						await U0Z();
						goto end_IL_004d;
					end_IL_0072:;
					}
					catch
					{
						goto end_IL_004d;
					}
					num = 2;
					goto end_IL_004d;
				IL_00e7:
					num = 1;
				end_IL_004d:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(500);
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

		private async void C0A()
		{
			if (Common.VIPLevel < 1)
			{
				return;
			}
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
							goto end_IL_0052;
						}
						if (webView == null || !Whs.CustEnabled)
						{
							goto IL_00e1;
						}
						await n0t();
						goto end_IL_004d;
					end_IL_0052:;
					}
					catch
					{
						goto end_IL_004d;
					}
					num = 2;
					goto end_IL_004d;
				IL_00e1:
					num = 1;
				end_IL_004d:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(2000);
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

		private async void u0S()
		{
			if (Common.VIPLevel < 2)
			{
				return;
			}
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
							goto end_IL_0072;
						}
						if (webView == null || !Whs.Boolean_0)
						{
							goto IL_00e7;
						}
						await R0D();
						goto end_IL_004d;
					end_IL_0072:;
					}
					catch
					{
						goto end_IL_004d;
					}
					num = 2;
					goto end_IL_004d;
				IL_00e7:
					num = 1;
				end_IL_004d:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(500);
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

		private async Task U0Z()
		{
			if (IsClosed || !Whs.WelcomeEnabled || a0E.AddSeconds(1.0) > DateTime.Now || c0z.AddSeconds(2.0) > DateTime.Now)
			{
				return;
			}
			try
			{
				string msg2 = "";
				bool flag = false;
				DanmuData data = DanmuSender._processedMessages.FirstOrDefault((DanmuData x) => x.Type == DanmuType.Gift || x.Type == DanmuType.EnterRoom || x.Type == DanmuType.Like || x.Type == DanmuType.Follow);
				bool isKeyUser = data != null;
				if (!isKeyUser)
				{
					if (Whs.OptTypes.GiftEnabled)
					{
						data = DanmuSender._welcomeMessages.LastOrDefault((DanmuData x) => x.Type == DanmuType.Gift);
					}
					if (data == null)
					{
						data = DanmuSender._welcomeMessages.LastOrDefault((DanmuData x) => x.Type == DanmuType.EnterRoom || x.Type == DanmuType.Like || x.Type == DanmuType.Follow);
					}
				}
				if (data == null)
				{
					return;
				}
				if (data.Type == DanmuType.Gift && Whs.OptTypes.GiftEnabled)
				{
					flag = true;
					msg2 = Whs.OptContent.GiftFormat;
				}
				else if (data.Type == DanmuType.Follow && Whs.OptTypes.FollowEnabled)
				{
					flag = true;
					msg2 = Whs.OptContent.FollowFormat;
				}
				else if (data.Type == DanmuType.Like && Whs.OptTypes.LikeEnabled)
				{
					flag = true;
					msg2 = Whs.OptContent.LikeFormat;
				}
				else if (data.Type == DanmuType.EnterRoom && Whs.OptTypes.EnterRoomEnabled)
				{
					flag = true;
					msg2 = Whs.OptContent.EnterRoomFormat;
				}
				if (!flag)
				{
					return;
				}
				msg2 = r0R(msg2, data);
				string javaScript = T0k(msg2);
				if (await webView.ExecuteScriptAsync(javaScript) == "1")
				{
					if (isKeyUser)
					{
						p0Y("******欢迎感谢关键用户:[" + data.UserNick + "] 发送成功:" + msg2);
						DanmuSender._processedMessages.Remove(data);
					}
					else
					{
						DanmuSender._welcomeMessages.Remove(data);
						p0Y("发送成功:" + msg2);
					}
					await p0M();
				}
			}
			catch
			{
			}
		}

		private async Task n0t()
		{
			if (IsClosed || !Whs.CustEnabled)
			{
				return;
			}
			try
			{
				if (a0E.AddSeconds(1.0) > DateTime.Now || M0l.AddSeconds(2.0) > DateTime.Now)
				{
					return;
				}
				List<string> list = (from x in Common.danmuSetting.AutoSendDanmu.CustContent.Split('\n')
									 where x.Trim() != ""
									 select x).ToList();
				if (list.Count <= 0)
				{
					return;
				}
				string msg;
				if (!Whs.CustRndSend)
				{
					if (QhK >= list.Count)
					{
						QhK = 0;
					}
					msg = list[QhK].Trim();
					QhK++;
				}
				else
				{
					msg = list[Common.rnd.Next(0, list.Count)].Trim();
				}
				string javaScript = T0k(msg);
				if (await webView.ExecuteScriptAsync(javaScript) == "1")
				{
					p0Y("发送成功:" + msg);
					await n0i();
				}
			}
			catch
			{
			}
		}

		private async Task R0D()
		{
			if (IsClosed || !Whs.Boolean_0)
			{
				return;
			}
			try
			{
				DanmuData data = DanmuSender._welcomeMessages.LastOrDefault((DanmuData x) => x.Type == DanmuType.Chat);
				if (data == null)
				{
					return;
				}
				if (F02(data.UserNick))
				{
					DanmuSender._welcomeMessages.Remove(data);
					return;
				}
				string msg = DanmuSender.xob(data);
				if (msg == "")
				{
					DanmuSender._welcomeMessages.Remove(data);
					return;
				}
				string javaScript = T0k(msg);
				if (await webView.ExecuteScriptAsync(javaScript) == "1")
				{
					DanmuSender._welcomeMessages.Remove(data);
					p0Y("自动问答回复成功:" + msg);
					try
					{
						p0Y("程序自动等待:1秒...");
						a0E = DateTime.Now;
						await Task.Delay(1000);
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}

		private async void q0c()
		{
			Exception obj = null;
			int num = 0;
			try
			{
				try
				{
					while (!IsClosed)
					{
						await Task.Delay(60000 * Whs.RefreshPageMinutes);
						webView.CoreWebView2.Reload();
					}
				}
				catch
				{
					goto end_IL_004d;
				}
				num = 1;
			end_IL_004d:;
			}
			catch (Exception obj3)
			{
				obj = obj3;
			}
			await Task.Delay(1000);
			Exception obj4 = obj;
			if (obj4 != null)
			{
				ExceptionDispatchInfo.Capture((obj4 as Exception) ?? throw obj4).Throw();
			}
			if (num != 1)
			{
			}
		}

		private string T0k(string string_0)
		{
			string text = "function setInput(selector, text) {\r\n                                            document.querySelector(selector).focus();        \r\n                                            document.execCommand('selectAll', false, null);\r\n                                            document.execCommand('insertText', false, text);\r\n                                          }\r\n                                         setInput('.webcast-chatroom___textarea', '{msg}');\r\n\r\n                                        // 模拟回车\r\n                                        var txtCtl=document.querySelector('.webcast-chatroom___textarea');\r\n                                        var event = document.createEvent('Event');\r\n                                        event.initEvent('keydown', true, false);\r\n                                        event = Object.assign(event, {\r\n                                          ctrlKey: false,\r\n                                          metaKey: false,\r\n                                          altKey: false,\r\n                                          which: 13,\r\n                                          keyCode: 13,\r\n                                          key: 'Enter',\r\n                                          code: 'Enter'\r\n                                        })\r\n                                        txtCtl.focus();\r\n                                        txtCtl.dispatchEvent(event);1;";
			if (whH)
			{
				text = "function setInput(selector, text) {\r\n                                            document.querySelector(selector).focus();        \r\n                                            document.execCommand('selectAll', false, null);\r\n                                            document.execCommand('insertText', false, text);\r\n                                            document.querySelector('.sendBtn--pSNlG').click();   \r\n                                          }\r\n                                         setInput('.sendInput--6Xm90', '{msg}');1";
			}
			string_0 = TimerSpeakHelper.FormatContent(string_0);
			return text.Replace("{msg}", string_0.Replace("'", "'"));
		}

		private async Task p0M()
		{
			try
			{
				if (Whs.InterValSecondsMin > Whs.InterValSecondsMax)
				{
					Whs.InterValSecondsMax = Whs.InterValSecondsMin;
				}
				int num = Common.rnd.Next(Whs.InterValSecondsMin, Whs.InterValSecondsMax + 1);
				p0Y("程序自动等待:" + num + "秒...");
				M0l = DateTime.Now;
				await Task.Delay(1000 * num);
			}
			catch
			{
			}
		}

		private async Task n0i()
		{
			try
			{
				if (Whs.CustInterValSecondsMin > Whs.CustInterValSecondsMax)
				{
					Whs.CustInterValSecondsMax = Whs.CustInterValSecondsMin;
				}
				int num = Common.rnd.Next(Whs.CustInterValSecondsMin, Whs.CustInterValSecondsMax + 1);
				p0Y("程序自动等待:" + num + "秒...");
				c0z = DateTime.Now;
				await Task.Delay(1000 * num);
			}
			catch
			{
			}
		}

		private bool F02(string string_0)
		{
			if (Whs.BlockNicks.Trim() == "")
			{
				return false;
			}
			return (from x in Whs.BlockNicks.Split('|')
					where x.Trim() != ""
					select x).Any((string x) => x.Trim() == string_0);
		}

		private async void E08(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			try
			{
				await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.addEventListener('dragover',function(e){e.preventDefault();},false);window.addEventListener('drop',function(e){e.preventDefault();console.log(e.dataTransfer);console.log(e.dataTransfer.files[0])}, false);");
				await webView.CoreWebView2.ExecuteScriptAsync("window.addEventListener('contextmenu', window => {window.preventDefault();});");
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				j0p(ihe);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			}
			catch
			{
			}
		}

		private async Task j0p(string string_0)
		{
			try
			{
				await webView.CoreWebView2.ExecuteScriptAsync(string_0);
			}
			catch
			{
			}
		}

		private void s0b(object sender, ContextMenuEventArgs e)
		{
			e.Handled = true;
		}

		private void t0J(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				Util.SaveDanmuSetting();
				IsClosed = true;
				webView.Dispose();
			}
			catch
			{
			}
		}

		private string r0R(string string_0, DanmuData danmuData_0)
		{
			return (VoiceHelper.FormatOptContent(string_0, danmuData_0.UserNickCut, danmuData_0.GiftName, danmuData_0.GiftCount) + "".PadLeft(50)).Substring(0, 50).Trim();
		}

		private void p0Y(string string_0)
		{
			try
			{
				base.Dispatcher.Invoke(delegate
				{
					lbState.Content = string_0;
				});
				sb.Append("[" + DateTime.Now.ToString() + "]: " + string_0 + "\r\n");
			}
			catch
			{
			}
		}

		private async void R00(string string_0)
		{
			if (!Yhx)
			{
				await y0m();
			}
			whH = string_0.StartsWith("https://anchor.douyin.com/anchor/dashboard");
			p0Y("转到直播间:" + string_0);
			webView.Source = new Uri(string_0);
		}

		private void j0h()
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void p0g()
		{
			if (Common.VIPLevel < 2)
			{
				Util.PromptPurchase(2);
			}
		}

		private void l09(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel >= 1)
			{
				R00(Common.danmuSetting.LastLiveUrl);
			}
			else
			{
				j0h();
			}
		}

		private void j06(object sender, RoutedEventArgs e)
		{
			gridSetting.Visibility = Visibility.Visible;
			webView.Visibility = Visibility.Collapsed;
		}

		private void h07(object sender, RoutedEventArgs e)
		{
			txtLog.Text = sb.ToString();
			txtLog.ScrollToEnd();
			gridLog.Visibility = Visibility.Visible;
			Grid grid = gridSetting;
			webView.Visibility = Visibility.Collapsed;
			grid.Visibility = Visibility.Collapsed;
		}

		private void e0T(object sender, RoutedEventArgs e)
		{
			gridSetting.Visibility = Visibility.Collapsed;
			webView.Visibility = Visibility.Visible;
		}

		private void H0G(object sender, RoutedEventArgs e)
		{
			gridSetting.Visibility = Visibility.Collapsed;
			gridLog.Visibility = Visibility.Collapsed;
			webView.Visibility = Visibility.Visible;
		}

		private void A0o(object sender, RoutedEventArgs e)
		{
			if (!Yhx)
			{
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				messageTip.ShowMessageTip("输入的直播地址不正确", isWarningOrError: true, 3222);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			}
			else if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void J0v(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("注：支持多个关键词匹配多个随机回复，多个关键词或多个回复内容中间用|隔开\r\n怎么购买|下单|哪里下单=下发小黄车2号链接下单|点小黄车\r\n发货地|哪里发货=发货地是北京哈|我们是北京发货\r\n主播666|666=感谢支持|感谢！祝你开心！");
		}

		private void J0X(object sender, RoutedEventArgs e)
		{
			j0h();
		}

		private void Q0y(object sender, RoutedEventArgs e)
		{
			p0g();
		}

		private void o05(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				j0h();
			}
			else if (!Common.danmuSetting.LastLiveUrl.Trim().StartsWith("https://live.douyin.com/"))
			{
				MessageBox.Show("请先到程序主界面连接到你需要的直播间，且确保已成功经获取到弹幕信息");
			}
			else
			{
				R00("https://anchor.douyin.com/anchor/dashboard");
			}
		}

		private void J0V(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("作用是关键用户会被重点照顾，程序不会遗漏他们的欢迎感谢回复！");
		}
	}

}
