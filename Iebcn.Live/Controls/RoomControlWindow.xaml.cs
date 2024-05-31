using Iebcn.Live.Helper;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// RoomControlWindow.xaml 的交互逻辑
	/// </summary>
	public partial class RoomControlWindow : Window, IComponentConnector
	{
		public bool IsClosed;

		public RoomControlWindow()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting;
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

		private void HYh(object sender, RoutedEventArgs e)
		{
			BYg(1);
		}

		private void BYg(int int_0)
		{
			if (Common.VIPLevel < int_0)
			{
				MessageBox.Show(Common.Msg_NeedVip1);
			}
		}

		private void IY9(object sender, RoutedEventArgs e)
		{
			new KeyUserPlayerWindow().Show();
		}

		private void vY6(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void tY7(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
	}

}
