using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using Microsoft.Web.WebView2.Core;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// FakeGiftWindow.xaml 的交互逻辑
	/// </summary>
	public partial class FakeGiftWindow : Window, IComponentConnector
	{
		private FakeGift IDF;

		private List<FakeGiftInfo> uDw;

		public bool IsClosed;

		private bool SDC;

		private bool iD3;

		public FakeGiftWindow()
		{
			InitializeComponent();
			uDw = new List<FakeGiftInfo>();
			SDC = false;
			iD3 = false;
			base.Loaded += cDs;
			base.DataContext = (IDF = Common.danmuSetting.FakeGift);
			Process();
		}

		private async Task Ftz()
		{
			if (SDC)
			{
				return;
			}
			try
			{
				AppLog.AddLog("InitializeAsync...........");
				CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions("--autoplay-policy=no-user-gesture-required");
				CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync(null, System.IO.Path.Combine(System.IO.Path.GetTempPath(), "DouyinDanmuFakeGift_Browser"), options);
				await webView.EnsureCoreWebView2Async(environment);
				webView.CoreWebView2.Settings.AreHostObjectsAllowed = true;
				webView.DefaultBackgroundColor =System.Drawing.Color.FromArgb(0, 0, 0, 0);
				webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
				webView.CoreWebView2.Settings.IsStatusBarEnabled = false;
				webView.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = true;
				webView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
				webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
				webView.CoreWebView2.Settings.IsWebMessageEnabled = true;
				webView.CoreWebView2.NavigationCompleted += oDx;
				webView.ContextMenuOpening += CDd;
				webView.CoreWebView2.SetVirtualHostNameToFolderMapping("web", "Assets/web/FakeGift", CoreWebView2HostResourceAccessKind.Allow);
				SDC = true;
				webView.Source = new Uri("http://web/index.html");
			}
			catch (Exception ex)
			{
				MessageBox.Show("FakeGift init webview err:\r\n" + ex.Message);
				AppLog.AddLog("FakeGift init webview err:" + ex.Message);
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		protected override async void OnClosed(EventArgs e)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			try
			{
				FakeGiftManager.Close();
				base.OnClosed(e);
				IsClosed = true;
			}
			catch (Exception)
			{
			}
		}

		private void cDs(object sender, RoutedEventArgs e)
		{
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			Ftz();
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
		}

		private async void oDx(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			iD3 = true;
			try
			{
				string javaScript = "document.body.addEventListener(\"mouseenter\", function(){chrome.webview.postMessage('mouseenter');}, false);document.body.addEventListener(\"mouseleave\", function(){chrome.webview.postMessage('mouseleave');}, false);";
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				webView.CoreWebView2.ExecuteScriptAsync(javaScript);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.addEventListener('dragover',function(e){e.preventDefault();},false);window.addEventListener('drop',function(e){e.preventDefault();console.log(e.dataTransfer);console.log(e.dataTransfer.files[0])}, false);");
				await webView.CoreWebView2.ExecuteScriptAsync("window.addEventListener('contextmenu', window => {window.preventDefault();});");
			}
			catch
			{
			}
		}

		private void CDd(object sender, ContextMenuEventArgs e)
		{
			e.Handled = true;
		}

		private async void Process()
		{
			if (Common.VIPLevel < 1 || IsClosed)
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
						if (IDF.SavedList.Count <= 0 || uDw.Count <= 0 || !Common.danmuSetting.FakeGift.Enabled || !iD3 || await webView.ExecuteScriptAsync("stoped") != "1")
						{
							goto end_IL_007e;
						}
						FakeGiftInfo fakeGiftInfo = (from x in uDw
													 orderby x.Priority descending
													 orderby x.AddTime descending
													 select x).FirstOrDefault();
						uDw.Remove(fakeGiftInfo);
						Play(fakeGiftInfo);
						FakeGiftManager.LogInfo("触发：" + fakeGiftInfo.Desc);
						goto end_IL_0056;
					end_IL_007e:;
					}
					catch
					{
						goto end_IL_0056;
					}
					num = 1;
				end_IL_0056:;
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
				if (num == 1)
				{
				}
			}
			throw obj4;
		}

		private void Play(FakeGiftInfo fgInfo)
		{
			int num = fgInfo.MediaId;
			if (fgInfo.MediaId <= 0)
			{
				if (FakeGiftManager.GetRandomGiftInfoList() == null)
				{
					return;
				}
				num = FakeGiftManager.GetRandomGiftInfoList().GiftId;
			}
			webView.ExecuteScriptAsync("playVideo(" + num + "," + fgInfo.LoopCount + ")");
		}

		private void ADH(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void VDK(object sender, RoutedEventArgs e)
		{
			FakeGiftManager.ShowFakeGiftSettingWindow();
		}

		private void yDQ(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		internal async Task HandleFakeGiftInfo(FakeGiftInfo fakeGiftInfo_0)
		{
			try
			{
				if (await webView.ExecuteScriptAsync("stoped") != "1")
				{
					msgTipCtl.Show("正在播放礼物特效!稍后再试！");
					return;
				}
				int num = fakeGiftInfo_0.MediaId;
				if (fakeGiftInfo_0.MediaId <= 0)
				{
					if (FakeGiftManager.GetRandomGiftInfoList() == null)
					{
						return;
					}
					num = FakeGiftManager.GetRandomGiftInfoList().GiftId;
				}
				await webView.ExecuteScriptAsync("playVideo(" + num + "," + fakeGiftInfo_0.LoopCount + ")");
			}
			catch
			{
			}
		}

		private void ADq(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		internal void HandleDanmuData(DanmuData danmuData_0)
		{
			if (Common.VIPLevel < 1 || !Common.danmuSetting.FakeGift.Enabled)
			{
				return;
			}
			FakeGiftInfo fakeGiftInfo = null;
			if (danmuData_0.Type == DanmuType.Gift)
			{
				fakeGiftInfo = IDF.SavedList.FirstOrDefault((FakeGiftInfo x) => x.DType == DanmuType.Gift && (x.GiftName == danmuData_0.GiftName || x.GiftName == ""));
				if (fakeGiftInfo != null && fakeGiftInfo.GiftExcByCount)
				{
					fakeGiftInfo.LoopCount = danmuData_0.GiftCount;
				}
			}
			if (danmuData_0.Type == DanmuType.Chat)
			{
				fakeGiftInfo = IDF.SavedList.FirstOrDefault((FakeGiftInfo x) => x.DType == DanmuType.Chat && x.ChatWords == danmuData_0.PureMsg);
			}
			if (danmuData_0.Type == DanmuType.Like)
			{
				fakeGiftInfo = IDF.SavedList.FirstOrDefault((FakeGiftInfo x) => x.DType == DanmuType.Like);
			}
			if (fakeGiftInfo != null)
			{
				fakeGiftInfo.AddTime = DateTime.Now;
				MD4(fakeGiftInfo);
				FakeGiftManager.LogInfo("加入队列：" + fakeGiftInfo.Desc);
			}
		}

		private void MD4(FakeGiftInfo fakeGiftInfo_0)
		{
			uDw.Add(fakeGiftInfo_0);
			if (uDw.Count > IDF.CacheMax)
			{
				uDw.RemoveAt(0);
			}
		}

	}

}
