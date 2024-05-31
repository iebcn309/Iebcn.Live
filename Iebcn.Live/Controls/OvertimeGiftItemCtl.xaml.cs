using Iebcn.Live.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// OvertimeGiftItemCtl.xaml 的交互逻辑
	/// </summary>
	public partial class OvertimeGiftItemCtl : UserControl, IComponentConnector
	{
		public OvertimeGift gift;

		private OvertimeWindow AT9;

		public OvertimeGiftItemCtl(OvertimeWindow parent, OvertimeGift gift)
		{
			InitializeComponent();
			AT9 = parent;
			this.gift = gift;
			base.DataContext = Common.danmuSetting.Overtime;
			lbGiftDesc.Content = gift.GiftDesc;
			lbGiftName.Content = gift.GiftName;
			try
			{
				img.Source = new BitmapImage(new Uri(gift.Pic, UriKind.RelativeOrAbsolute));
			}
			catch
			{
			}
		}

		private void hT0(object sender, MouseEventArgs e)
		{
			gridDel.Visibility = Visibility.Visible;
		}

		private void VTh(object sender, MouseEventArgs e)
		{
			gridDel.Visibility = Visibility.Collapsed;
		}

		private void eTg(object sender, RoutedEventArgs e)
		{
			AT9.DelItem(this);
		}

	}

}
