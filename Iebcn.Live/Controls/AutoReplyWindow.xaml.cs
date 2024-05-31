using Iebcn.Live.Helper;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// AutoReplyWindow.xaml 的交互逻辑
	/// </summary>
	public partial class AutoReplyWindow : Window, IComponentConnector
	{
		public bool IsClosed;

		public AutoReplyWindow()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.AutoReply;
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

		private void vnO(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void unU(object sender, RoutedEventArgs e)
		{
			AutoReplyHelper.OpenLog();
		}

		private void TnW(object sender, RoutedEventArgs e)
		{
			gridUseText.IsEnabled = false;
		}

		private void Gna(object sender, RoutedEventArgs e)
		{
			gridUseText.IsEnabled = true;
		}

		private void PnN(object sender, RoutedEventArgs e)
		{
			try
			{
				string text = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\自动问答声音");
				Directory.CreateDirectory(text);
				if (Directory.Exists(text))
				{
					Process.Start("explorer.exe", text);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void bnP(object sender, RoutedEventArgs e)
		{
		}

		private void Tnu(object sender, RoutedEventArgs e)
		{
			DanmuData e2 = new DanmuData
			{
				Type = DanmuType.Chat,
				UserNick = "系统测试",
				Msg = "系统测试:" + txtDanmu.Text
			};
			Common.mainWindow?.WebBrowserHelper_DanmuDataChanged(null, e2);
		}

		private void rnL(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void vn1(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void inm(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				Util.PromptPurchase(2);
			}
		}
	}

}
