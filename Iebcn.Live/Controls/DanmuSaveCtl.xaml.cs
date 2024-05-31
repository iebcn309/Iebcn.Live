using Iebcn.Live.Helper;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// DanmuSaveCtl.xaml 的交互逻辑
	/// </summary>
	public partial class DanmuSaveCtl : Grid, IComponentConnector
	{
		private ArchiveDanmuWindow B7T;

		public DanmuSaveCtl()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.SaveDanmuConfig;
		}

		private void O7g(object sender, RoutedEventArgs e)
		{
			try
			{
				string directoryName = Path.GetDirectoryName(AppLog.GetDanmuLogFilePath("danmu.log"));
				Directory.CreateDirectory(directoryName);
				Process.Start(directoryName);
			}
			catch
			{
			}
		}

		private void F79(object sender, RoutedEventArgs e)
		{
			j76();
		}

		private void j76()
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}
		private void C77(object sender, RoutedEventArgs e)
		{
			if (B7T == null || B7T.IsClosed)
			{
				B7T = new ArchiveDanmuWindow();
			}
			B7T.Show();
			B7T.Activate();
		}

	}

}
