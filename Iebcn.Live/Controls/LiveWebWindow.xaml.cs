using Iebcn.Live.Helper;
using Microsoft.Web.WebView2.Core;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;


namespace Iebcn.Live.Controls
{
	/// <summary>
	/// LiveWebWindow.xaml 的交互逻辑
	/// </summary>
	public partial class LiveWebWindow : Window, IComponentConnector
	{
		private LivePage _livePage;
		private DateTime _lastUpdateTime = DateTime.Now;
		//_isInit
		private bool _isInit;
		//_script 
		private string _script = "setInterval(function(){ \r\n//mouse over\r\n  var event = document.createEvent(\"MouseEvents\");\r\n      event.initEvent('mouseover', true, false);\r\n     document.body.dispatchEvent(event);\r\n\t console.log('createEvent');\r\n //click  \r\nconst event2 = document.createEvent('Events');\r\nevent2.initEvent( 'click', true, false );\r\ndocument.body.dispatchEvent(event2);\r\n\r\nvar event3 = document.createEvent(\"UIEvents\");\r\nevent3.initUIEvent(\"keypress\", true, true, window, 1);\r\nevent3.keyCode = 38;//up\r\ndocument.body.dispatchEvent(event3);\r\n\r\n}, 60000);\r\n";
		//_userAgent 
		private string _userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";

		public LiveWebWindow()
		{
			InitializeComponent();
			_livePage = Common.danmuSetting.LivePage;
			if (_livePage.ReloadMinutes < 1)
			{
				_livePage.ReloadMinutes = 5;
			}
			base.DataContext = _livePage;
			Initialize();
			CheckLogin();
			Reload();
			_lastUpdateTime = DateTime.Now;
		}

		private async void Reload()
		{
			while (true)
			{
				try
				{
					if (!Common.AppClosed)
					{
						if (_lastUpdateTime.AddMinutes(_livePage.ReloadMinutes) <= DateTime.Now)
						{
							_lastUpdateTime = DateTime.Now;
							webView.Reload();
						}
					}

				}
				catch
				{
				}
				await Task.Delay(1000);
			}
		}

		private async Task CheckConnection()
		{
			await Task.Delay(12000);
			DanmuData latestDanmudata = Common.latestDanmudata;
			object obj = latestDanmudata?.PureMsg ?? "";
			if ((string)obj != "开始连接")
			{
				latestDanmudata = Common.latestDanmudata;
				obj = latestDanmudata?.PureMsg ?? "";
			}
			if ((string)obj == "连接成功")
			{
				ShowWind();
			}
		}
		private async void CheckLogin()
		{
			while (true)
			{
				try
				{
					if (webView.Source != null || webView.Source?.AbsoluteUri != "about:blank")
					{
						if (await webView.ExecuteScriptAsync("document.getElementById('web-login-container')!=null;") == "true")
						{
							ShowWind();
						}
					}
				}
				catch
				{
				}
				await Task.Delay(1000);
			}
		}
		private async Task InitializeAsync()
		{
			AppLog.AddLog("InitializeAsync...........");
			try
			{
				CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions
				{
					AdditionalBrowserArguments = "--autoplay-policy=user-gesture-required"
				};
				CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Path.GetTempPath(), "Iebcn.Live.ControlsLive_Browser"), options);
				await webView.EnsureCoreWebView2Async(environment);
				webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
				webView.ContextMenuOpening += WebView_ContextMenuOpening;
				webView.CoreWebView2.Settings.AreHostObjectsAllowed = true;
				webView.CoreWebView2.Settings.UserAgent = _userAgent;
				webView.CoreWebView2.AddWebResourceRequestedFilter("*.flv*", CoreWebView2WebResourceContext.All);
				webView.CoreWebView2.WebResourceResponseReceived += CoreWebView2_WebResourceResponseReceived;
				webView.CoreWebView2.WebResourceRequested += delegate (object sender, CoreWebView2WebResourceRequestedEventArgs e)
				{
					switch (Common.CurrLivePlatform)
					{
						case LivePlatform.Douyin:
                            if (e.Request.Uri.ToString().Contains(".flv"))
                            {
                                FileStream content = null;
                                CoreWebView2WebResourceResponse response = webView.CoreWebView2.Environment.CreateWebResourceResponse(content, 200, "OK", "Content-Type: image/jpeg");
                                e.Response = response;
                            }
                            e.Request.Uri.ToString().Contains("https://live.douyin.com/");
                            break;
						case LivePlatform.KuaiShou:
                            if (e.Request.Uri.ToString().Contains(".flv65"))
                            {
                                FileStream content = null;
                                CoreWebView2WebResourceResponse response = webView.CoreWebView2.Environment.CreateWebResourceResponse(content, 200, "OK", "Content-Type: image/jpeg");
                                e.Response = response;
                            }
                            if (e.Request.Uri.ToString().StartsWith("https://sentry.kuaishou.com/api/2221/envelope/?sentry_key="))
                            {
                                string text = "";
                                using (StreamReader streamReader = new StreamReader(e.Request.Content))
                                {
                                    text = streamReader.ReadToEnd();
                                }
                                text = text.Replace("\"init\":false", "\"init\":true");
                                text = text.Replace("\"status\":\"exited\"", "\"status\":\"ok\"");
                                text = text.Replace("errors\":1", "errors\":0");
                                e.Request.Content = new MemoryStream(Encoding.UTF8.GetBytes(text));
                            }
                            break;
					}
				
				};
				await webView.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.enable", "{}");
				CoreWebView2DevToolsProtocolEventReceiver devToolsProtocolEventReceiver = webView.CoreWebView2.GetDevToolsProtocolEventReceiver("Network.webSocketFrameReceived");
				CoreWebView2DevToolsProtocolEventReceiver devToolsProtocolEventReceiver2 = webView.CoreWebView2.GetDevToolsProtocolEventReceiver("Network.webSocketCreated");
				CoreWebView2DevToolsProtocolEventReceiver devToolsProtocolEventReceiver3 = webView.CoreWebView2.GetDevToolsProtocolEventReceiver("Network.webSocketClosed");
				devToolsProtocolEventReceiver2.DevToolsProtocolEventReceived += async delegate
				{
                    switch (Common.CurrLivePlatform)
                    {
                        case LivePlatform.Douyin:
                        case LivePlatform.KuaiShou:
                            if (!Common.CacheData.Take(10).Any((DanmuData x) => x.PureMsg.StartsWith("连接成功!如果长时间未获取到弹幕")))
                            {
                                OnDanmuDataChanged("连接成功!如果长时间未获取到弹幕，请点软件标题栏【直播间】按钮进去检查下！");
                                await ExecuteScriptAsync("document.getElementsByClassName('basicPlayer ')[0].remove();");
                            }
                            break;
                    }
              
				};
				devToolsProtocolEventReceiver3.DevToolsProtocolEventReceived += DevToolsProtocolEventReceiver3_DevToolsProtocolEventReceived;
				devToolsProtocolEventReceiver.DevToolsProtocolEventReceived += delegate (object sender, CoreWebView2DevToolsProtocolEventReceivedEventArgs e)
				{
					WebBrowserHelper.ParseDanmuData(e.ParameterObjectAsJson);
				};
				_isInit = true;
				AppLog.AddLog("InitializeAsync...compete.");
			}
			catch (Exception ex)
			{
				AppLog.AddLog("Live window init webview err:" + ex.Message);
				MessageBox.Show("Live window init webview err:\r\n" + ex.Message);
			}
		}

		private async void DevToolsProtocolEventReceiver3_DevToolsProtocolEventReceived(object sender, CoreWebView2DevToolsProtocolEventReceivedEventArgs e)
		{
			try
			{
				if ((await webView.CoreWebView2.ExecuteScriptAsync("document.body.innerText")).Contains("账号已在其他地方进入直播间"))
				{
					OnDanmuDataChanged("-----账号已在其他地方进入直播间!---------请重新连接------");
				}
			}
			catch
			{
			}
		}

		private async void CoreWebView2_WebResourceResponseReceived(object sender, CoreWebView2WebResourceResponseReceivedEventArgs e)
		{
			try
			{
				if (e.Request.Uri.StartsWith("https://live.douyin.com/webcast/ranklist/audience/") && e.Response != null && e.Response.StatusCode == 200)
				{
					await RoomRankHelper.ParseOnlineRankDataAsync(await e.Response.GetContentAsync());
				}
			}
			catch (Exception)
			{
			}
		}

		private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			try
			{
				await webView.CoreWebView2.ExecuteScriptAsync("document.querySelector('.basicPlayer').innerText=\"\";");

				await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.addEventListener('dragover',function(e){e.preventDefault();},false);window.addEventListener('drop',function(e){e.preventDefault();console.log(e.dataTransfer);console.log(e.dataTransfer.files[0])}, false);");
				await webView.CoreWebView2.ExecuteScriptAsync("window.addEventListener('contextmenu', window => {window.preventDefault();});");
				string text = await webView.CoreWebView2.ExecuteScriptAsync("document.body.innerText");
				if (!text.Contains("该内容暂时无法查看"))
				{
					text.Contains("聊天功能不可用");
					if (!(await webView.CoreWebView2.ExecuteScriptAsync("document.body.innerText")).Contains("直播已结束"))
					{
						await ExecuteScriptAsync("document.getElementsByClassName('basicPlayer ')[0].remove();");
						await ExecuteScriptAsync(_script);
					}
					else
					{
						OnDanmuDataChanged("直播已结束！");
						await Common.mainWindow.messageTip.ShowMessageTip("该房间直播已结束,去其它直播房间看看吧老哥！", isWarningOrError: true, 2000);
					}
				}
				else
				{
					OnDanmuDataChanged("该内容暂时无法查看！");
					await Common.mainWindow.messageTip.ShowMessageTip("该房间没有直播内容,去其它直播房间看看吧老哥！", isWarningOrError: true, 2000);
				}
			}
			catch
			{
			}
		}

		private async Task ExecuteScriptAsync(string string_0)
		{
			try
			{
				await webView.CoreWebView2.ExecuteScriptAsync(string_0);
			}
			catch
			{
			}
		}

		private void WebView_ContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			e.Handled = true;
		}


		public async Task OpenPage(string liveUrl = "https://live.douyin.com/544523711592")
		{
			if (!_isInit)
			{
				await InitializeAsync();
			}
			try
			{
				OnDanmuDataChanged("开始连接...");
				webView.CoreWebView2.Settings.UserAgent = _userAgent;

			}
			catch
			{
			}
			webView.Source = new Uri(liveUrl);
			await CheckConnection();
			_lastUpdateTime = DateTime.Now;
		}

		private void OnDanmuDataChanged(string string_0)
		{
			Common.mainWindow?.WebBrowserHelper_DanmuDataChanged(this, new DanmuData
			{
				Type = DanmuType.App,
				UserNick = "系统",
				Msg = string_0,
				Mute = true
			});
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			webView.Dispose();
		}

		private void Initialize()
		{
			base.Width = 1.0;
			base.Height = 1.0;
			double left = -55.0;
			base.Top = -55.0;
			base.Left = left;
			base.ShowInTaskbar = false;
		}

		public void ShowWind()
		{
			if (!(base.RenderSize.Width > 160.0))
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

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void btnMinWindow_Click(object sender, RoutedEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
			base.ShowInTaskbar = false;
		}

		private void x_Click(object sender, RoutedEventArgs e)
		{
			Initialize();
		}
	}

}
