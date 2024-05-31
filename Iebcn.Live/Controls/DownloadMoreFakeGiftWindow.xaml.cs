using Iebcn.Live.Helper;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// DownloadMoreFakeGiftWindow.xaml 的交互逻辑
	/// </summary>
	public partial class DownloadMoreFakeGiftWindow : Window, IComponentConnector
	{
		public bool IsClosed;

		public DownloadMoreFakeGiftWindow()
		{
			InitializeComponent();
		}
		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				IsClosed = true;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(GetType()?.ToString() + ex.Message);
			}
		}

		private void Qtx(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void htd(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private async void ktH(object sender, RoutedEventArgs e)
		{
			try
			{
				string downloadPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FakeGiftManager.MediaFolderPath);
				if (await fileDownLoaderCtl.DownloadFilesAsync(W4L.y4t, downloadPath, "FakeGifts.zip"))
				{
					FakeGiftManager.ReloadFakeGifts();
					Close();
				}
			}
			catch
			{
			}
		}


	}

}
