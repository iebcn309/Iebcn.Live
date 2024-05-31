using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// MsgTipCtl.xaml 的交互逻辑
	/// </summary>
	public partial class MsgTipCtl : UserControl, IComponentConnector
	{
		private Storyboard sb1;

		public MsgTipCtl()
		{
			InitializeComponent();
			base.Visibility = Visibility.Collapsed;
			sb1 = base.Resources["sb1"] as Storyboard;
		}

		public async void Show(string msg, double lastSeconds = 3.0)
		{
			InitializeComponent();
			txtMsg.Text = msg;
			base.Visibility = Visibility.Visible;
			sb1.Begin(this);
			await Task.Delay((int)(1000.0 * lastSeconds + 1.0));
			base.Visibility = Visibility.Collapsed;
		}
	}
}
