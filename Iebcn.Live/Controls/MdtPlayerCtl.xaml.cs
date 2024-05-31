using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// MdtPlayerCtl.xaml 的交互逻辑
	/// </summary>
	public partial class MdtPlayerCtl : UserControl, IComponentConnector
	{
		private MediaInfo OTM;

		private string YTi = "";

		private double nT2 = 1.0;

		private int zT8;

		private int TTp = 1;

		public MdtPlayerCtl(MediaInfo mdInfo)
		{
			InitializeComponent();
			OTM = mdInfo;
			Canvas.SetLeft(this, mdInfo.X);
			Canvas.SetTop(this, mdInfo.Y);
			base.Width = mdInfo.WindowWidth;
			base.Height = mdInfo.WindowHeight;
			md.MediaEnded += FTD;
			md.MediaFailed += ITt;
			if (mdInfo.DType == DanmuType.Gift && mdInfo.GiftExcByCount)
			{
				if (mdInfo.LoopCount <= 0)
				{
					mdInfo.LoopCount = 1;
				}
				TTp = mdInfo.LoopCount;
			}
			YTi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, MediaTriggerManager.MediaAssetsPath + "\\" + mdInfo.MediaFile);
			if (MediaTriggerManager.IsValidMediaFileExtension(YTi))
			{
				imgGif.Source = new BitmapImage(new Uri(YTi, UriKind.RelativeOrAbsolute));
				ImageBehavior.SetAnimatedSource(imgGif, imgGif.Source);
				imgGif.Visibility = Visibility.Visible;
				md.Visibility = Visibility.Collapsed;
				_ = wTc(mdInfo.ShowSeconds * TTp);
			}
			else
			{
				nT2 = mdInfo.Volume;
				oTZ();
			}
		}
		private void oTZ()
		{
			md.Source = new Uri(YTi, UriKind.RelativeOrAbsolute);
			md.Volume = nT2;
			imgGif.Visibility = Visibility.Collapsed;
			md.Visibility = Visibility.Visible;
		}
		private void ITt(object sender, ExceptionRoutedEventArgs e)
		{
			zT8++;
			if (zT8 >= TTp)
			{
				qTk();
			}
			else
			{
				oTZ();
			}
		}
		private void FTD(object sender, RoutedEventArgs e)
		{
			zT8++;
			if (zT8 < TTp)
			{
				oTZ();
			}
			else
			{
				qTk();
			}
		}

		private async Task wTc(int int_0)
		{
			await Task.Delay(int_0 * 1000);
			qTk();
		}

		private void qTk()
		{
			(base.Parent as Canvas).Children.Remove(this);
		}

	}

}
