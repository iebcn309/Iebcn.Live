using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// AvatarItem.xaml 的交互逻辑
	/// </summary>
	public partial class AvatarItem : UserControl, IComponentConnector
	{
		private Stream n74;

		public AvatarItem(DanmuData data, Stream picStream)
		{
			InitializeComponent();
			n74 = picStream;
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.StreamSource = picStream;
			bitmapImage.DecodePixelWidth = 333;
			bitmapImage.EndInit();
			bitmapImage.Freeze();
			img.Source = bitmapImage;
			txt.Text = data.FormatMsg;
		}
		public AvatarItem(string headPic, string strText = "感谢么么哒赠送的2个小心心")
		{
			InitializeComponent();
			img.Source = new BitmapImage(new Uri(headPic, UriKind.RelativeOrAbsolute));
			txt.Text = strText;
		}
		public void Release()
		{
			try
			{
				img.Source = null;
				if (n74 != null)
				{
					n74.Dispose();
					n74 = null;
				}
			}
			catch
			{
			}
		}

	}

}
