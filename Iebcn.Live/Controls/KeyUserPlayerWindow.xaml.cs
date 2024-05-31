using Iebcn.Live.Helper;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// KeyUserPlayerWindow.xaml 的交互逻辑
	/// </summary>
	public partial class KeyUserPlayerWindow : Window, IComponentConnector
	{
		[CompilerGenerated]
		private bool Jim;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return Jim;
			}
			[CompilerGenerated]
			private set
			{
				Jim = value;
			}
		}

		public KeyUserPlayerWindow()
		{
			InitializeComponent();
			listDanmu.ItemsSource = Common.KeyUserDanmuData;
			base.Loaded += aiU;
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
		}

		private void aiU(object sender, RoutedEventArgs e)
		{
			Activate();
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			Cia();
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
		}

		private void WiW(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

		private async Task Cia()
		{
			try
			{
				if (IsClosed)
				{
					return;
				}
				base.Dispatcher.Invoke(delegate
				{
					listDanmu.ScrollIntoView(Common.KeyUserDanmuData.LastOrDefault());
				});
			}
			catch
			{
			}
			await Task.Delay(1000);
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			Cia();
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
		}

		private void NiN(object sender, SelectionChangedEventArgs e)
		{
			if (Common.VIPLevel >= 1 && listDanmu.SelectedItem != null)
			{
				try
				{
					System.Windows.Forms.Clipboard.SetText((listDanmu.SelectedItem as DanmuData).Msg, System.Windows.Forms.TextDataFormat.Text);
				}
				catch
				{
				}
			}
		}

		private void TiP(object sender, RoutedEventArgs e)
		{
			if (Common.KeyUserDanmuData == null || Common.KeyUserDanmuData.Count <= 0)
			{
				return;
			}
			string text = "";
			try
			{
				foreach (DanmuData keyUserDanmuDatum in Common.KeyUserDanmuData)
				{
					text = text + keyUserDanmuDatum.Msg + "\r\n";
				}
				string text2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "重点关注用户_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
				File.WriteAllText(text2, text);
				Process.Start(text2);
			}
			catch (Exception ex)
			{
				AppLog.AddLog("export key user err" + ex.Message);
			}
		}

		private void viu(object sender, RoutedEventArgs e)
		{
			Common.KeyUserDanmuData.Clear();
		}

	}

}
