using Iebcn.Live.Helper;
using Microsoft.Web.WebView2.Core;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// WebEffectsWindow.xaml 的交互逻辑
	/// </summary>
	public partial class WebEffectsWindow : Window, IComponentConnector
	{
		public bool IsClosed;

		private Random i6p = new Random();

		private SolidColorBrush B6b = new SolidColorBrush(System.Windows.Media.Color.FromArgb(1, 0, 0, 0));

		private SolidColorBrush b6J = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));

		private SolidColorBrush Q6R = new SolidColorBrush(System.Windows.Media.Color.FromArgb(200, 0, 0, 0));

		private SolidColorBrush h6Y = new SolidColorBrush(System.Windows.Media.Color.FromArgb(200, 0, 0, byte.MaxValue));

		public WebEffectsWindow()
		{
			InitializeComponent();
			if (Common.danmuSetting.Agent.IsAgent)
			{
				btnSetting.Visibility = Visibility.Collapsed;
			}
			webView.AllowDrop = true;
			base.Loaded += A6S;
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

		private void k6m(object sender, CoreWebView2NewWindowRequestedEventArgs e)
		{
			string uri = e.Uri;
			e.Handled = true;
			try
			{
				webView.Source = new Uri(uri, UriKind.RelativeOrAbsolute);
			}
			catch
			{
			}
		}

		private async Task R6r()
		{
			AppLog.AddLog("InitializeAsync...........");
			try
			{
				CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions();
				CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Path.GetTempPath(), "DouyinEffects_Browser"), options);
				await webView.EnsureCoreWebView2Async(environment);
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.Message);
			}
			webView.CoreWebView2.NewWindowRequested += k6m;
			webView.CoreWebView2.NavigationCompleted += l6A;
			webView.WebMessageReceived += delegate (object sender, CoreWebView2WebMessageReceivedEventArgs e)
			{
				if (e.WebMessageAsJson.Contains("mouseenter"))
				{
					cmdBarPanel.Opacity = 1.0;
				}
				else if (e.WebMessageAsJson.Contains("mouseleave"))
				{
					cmdBarPanel.Opacity = 0.01;
				}
			};
			webView.CoreWebView2.Settings.AreHostObjectsAllowed = true;
			webView.DefaultBackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
			webView.CoreWebView2.SetVirtualHostNameToFolderMapping("web", "Assets/web", CoreWebView2HostResourceAccessKind.Allow);
		}

		private async void l6A(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			try
			{
				string javaScript = "document.body.addEventListener(\"mouseenter\", function(){chrome.webview.postMessage('mouseenter');}, false);document.body.addEventListener(\"mouseleave\", function(){chrome.webview.postMessage('mouseleave');}, false);";
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				webView.CoreWebView2.ExecuteScriptAsync(javaScript);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				javaScript = "document.title;";
				base.Title = "装饰：" + await webView.CoreWebView2.ExecuteScriptAsync(javaScript);
				javaScript = "document.querySelector('.schmenu').style.display='none';";
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				webView.CoreWebView2.ExecuteScriptAsync(javaScript);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			}
			catch (Exception)
			{
			}
		}
		public static List<FilePathModel> GetFiles()
		{
			string[] files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\effects"));
			List<FilePathModel> list = new List<FilePathModel>();
			if (files != null && files.Length != 0)
			{
				string[] array = files;
				foreach (string text in array)
				{
					FilePathModel filePathModel = new FilePathModel();
					filePathModel.Name = Path.GetFileName(text);
					filePathModel.Filepath = text;
					filePathModel.FileTargetPath = text;
					if (text.ToLower().EndsWith(".url"))
					{
						string[] array2 = File.ReadAllLines(text);
						foreach (string text2 in array2)
						{
							if (text2.StartsWith("URL="))
							{
								filePathModel.FileTargetPath = text2.Replace("URL=", "").Trim();
								break;
							}
						}
					}
					list.Add(filePathModel);
				}
			}
			return list;
		}

		private async void A6S(object sender, RoutedEventArgs e)
		{
			await R6r();
			comboxLinks.ItemsSource = GetFiles();
			foreach (FilePathModel item in (IEnumerable)comboxLinks.Items)
			{
				if (item.Name.Contains("-请选择各种装饰和特效-"))
				{
					comboxLinks.SelectedItem = item;
					break;
				}
			}
		}

		private void W6Z(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void W6t(object sender, RoutedEventArgs e)
		{
			try
			{
				webView.Dispose();
			}
			catch
			{
			}
			Close();
		}

		private void l6D(object sender, MouseEventArgs e)
		{
			cmdBarPanel.Opacity = 1.0;
		}

		private void Q6c(object sender, MouseEventArgs e)
		{
			cmdBarPanel.Opacity = 0.01;
		}

		private void Q6k(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems == null)
			{
				return;
			}
			try
			{
				FilePathModel filePathModel = e.AddedItems[0] as FilePathModel;
				webView.Source = new Uri(filePathModel.FileTargetPath, UriKind.RelativeOrAbsolute);
			}
			catch
			{
			}
		}

		private void E6M(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl(Config.HelpUrlEffects);
		}

		private void U6i(object sender, RoutedEventArgs e)
		{
			WebEffectsWindow webEffectsWindow = new WebEffectsWindow();
			webEffectsWindow.Show();
			webEffectsWindow.Activate();
		}

		[CompilerGenerated]
		private void c68(object sender, CoreWebView2WebMessageReceivedEventArgs e)
		{
			if (e.WebMessageAsJson.Contains("mouseenter"))
			{
				cmdBarPanel.Opacity = 1.0;
			}
			else if (e.WebMessageAsJson.Contains("mouseleave"))
			{
				cmdBarPanel.Opacity = 0.01;
			}
		}

	}

}
