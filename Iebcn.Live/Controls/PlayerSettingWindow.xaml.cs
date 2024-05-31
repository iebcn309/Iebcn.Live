using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// PlayerSettingWindow.xaml 的交互逻辑
	/// </summary>
	public partial class PlayerSettingWindow : Window, IComponentConnector
	{
		private UIConfig h2n;

		private DanmuPlayer U2G;
		public PlayerSettingWindow()
		{
			InitializeComponent();
			base.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			base.Topmost = true;
		}

		public PlayerSettingWindow(UIConfig uiConfig, DanmuPlayer danmuPlayer)
		{
			h2n = uiConfig;
			U2G = danmuPlayer;
			InitializeComponent();
			base.DataContext = uiConfig;
			base.Loaded += h2J;
		}

		private void h2J(object sender, RoutedEventArgs e)
		{
			base.Topmost = false;
			base.Topmost = true;
			Activate();
		}

		private void y2R(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void V2L(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = i2Z();
			if (solidColorBrush != null)
			{
				h2n.DanmuForeground = solidColorBrush;
			}
		}

		private void m2o(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = i2Z();
			if (solidColorBrush != null)
			{
				h2n.PageBackground = solidColorBrush;
			}
		}

		private SolidColorBrush i2Z()
		{
			//ColorDialog colorDialog = new ColorDialog();
			//colorDialog.AllowFullOpen = true;
			//if (colorDialog.ShowDialog() == DialogResult.OK)
			//{
			//	return new SolidColorBrush
			//	{
			//		Color = new Color
			//		{
			//			A = colorDialog.Color.A,
			//			B = colorDialog.Color.B,
			//			G = colorDialog.Color.G,
			//			R = colorDialog.Color.R
			//		}
			//	};
			//}
			return null;
		}

		private void z25(object sender, MouseButtonEventArgs e)
		{
			try
			{
				base.Topmost = false;
				base.Topmost = true;
				DragMove();
			}
			catch
			{
			}
		}

		private void G2j(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void R2X(object sender, RoutedEventArgs e)
		{
			base.Topmost = false;
			base.Topmost = true;
		}

		private void g2F(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				System.Windows.MessageBox.Show(Common.Msg_NeedVip2);
			}
		}

		private void B2l(object sender, MouseButtonEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				System.Windows.MessageBox.Show(Common.Msg_NeedVip2);
			}
		}

		private void q27(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = i2Z();
			if (solidColorBrush != null)
			{
				h2n.NickForeground = solidColorBrush;
			}
		}
	}

}
