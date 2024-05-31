using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// MusicCover.xaml 的交互逻辑
	/// </summary>
	public partial class MusicCover : UserControl, IComponentConnector
	{
		private Storyboard sb;

		public MusicCover()
		{
			InitializeComponent();
			try
			{
				sb = base.Resources["sb"] as Storyboard;
			}
			catch
			{
			}
		}

		public void SetCover(string picUrl)
		{
			try
			{
				if (string.IsNullOrEmpty(picUrl))
				{
					picUrl = "Pack://application:,,,/Assets/musicCover.jpg";
				}
				imgCover.Fill = new ImageBrush(new BitmapImage(new Uri(picUrl, UriKind.RelativeOrAbsolute)));
				SartCircleAnimation();
			}
			catch
			{
			}
		}

		public void SartCircleAnimation()
		{
			try
			{
				sb.Begin();
			}
			catch
			{
			}
		}

		public void StopCircleAnimation()
		{
			try
			{
				sb.Stop();
			}
			catch
			{
			}
		}
	}
}
