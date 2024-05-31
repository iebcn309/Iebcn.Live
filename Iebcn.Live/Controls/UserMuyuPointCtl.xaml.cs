using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// UserMuyuPointCtl.xaml 的交互逻辑
	/// </summary>
	public partial class UserMuyuPointCtl : Grid, IComponentConnector
	{
		private Storyboard sb1;

		public UserMuyuPointCtl(string nick, double points)
		{
			InitializeComponent();
			lbPoints.Content = "+" + points;
			lbNick.Content = nick;
			lbDesc.Content = Common.danmuSetting.Muyu.DescText ?? "";
			sb1 = base.Resources["sb1"] as Storyboard;
			sb1.Completed += LG4;
			base.Loaded += VGn;
		}

		private void VGn(object sender, RoutedEventArgs e)
		{
			sb1.Begin(this);
		}

		private void LG4(object sender, EventArgs e)
		{
			try
			{
				(base.Parent as Grid).Children.Remove(this);
			}
			catch
			{
			}
		}
	}
}
