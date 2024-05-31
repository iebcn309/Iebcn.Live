using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// MessageTip.xaml 的交互逻辑
	/// </summary>
	public partial class MessageTip : UserControl, IComponentConnector
	{
		private SolidColorBrush ipx;

		private SolidColorBrush Fpd;

		private Storyboard sb1;

		private Storyboard sb2;

		public MessageTip()
		{
			InitializeComponent();
			sb1 = base.Resources["sb1"] as Storyboard;
			sb2 = base.Resources["sb2"] as Storyboard;
			ipx = new SolidColorBrush(Colors.Blue);
			Fpd = new SolidColorBrush(Colors.Red);
		}

		public async Task ShowMessageTip(string msg, bool isWarningOrError = false, int stayMinsec = 1600)
		{
			base.Visibility = Visibility.Visible;
			lb.Content = msg;
			if (isWarningOrError)
			{
				lb.Background = Fpd;
			}
			else
			{
				lb.Background = ipx;
			}
			sb1.Begin(this);
			await Task.Delay(stayMinsec);
			sb2.Begin();
		}
	}

}
