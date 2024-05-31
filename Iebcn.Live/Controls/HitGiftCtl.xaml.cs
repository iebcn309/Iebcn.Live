using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// HitGiftCtl.xaml 的交互逻辑
	/// </summary>
	public partial class HitGiftCtl : UserControl, IComponentConnector
	{
		private double sTO;

		private double h;

		private Size PTU = new Size(100.0, 100.0);

		private int pTW;

		private string yTa = "";

		private string vTN = "";

		private HitGiftInfo kTP;

		private Random NTu = new Random();

		public HitGiftCtl()
		{
			InitializeComponent();
			base.Loaded += uT4;
		}

		public HitGiftCtl(HitGiftInfo hitGiftInfo)
		{
			kTP = hitGiftInfo;
			pTW = hitGiftInfo.LastSeconds;
			vTN = yTf(hitGiftInfo.PicFile);
			yTa = VTF(hitGiftInfo.AudioFile);
			InitializeComponent();
			base.Loaded += uT4;
		}

		private async void uT4(object sender, RoutedEventArgs e)
		{
			sTO = base.RenderSize.Width;
			h = base.RenderSize.Height;
			Start();
			if (yTa != "")
			{
				HitGiftManager.GetRandomAudio();
				await SoundPlayer.PlayFree(yTa, pTW);
			}
		}

		private async void Start()
		{
			for (int i = 0; i < kTP.PicCount; i++)
			{
				System.Windows.Controls.Image image = new System.Windows.Controls.Image
				{
					RenderTransformOrigin = new Point(0.5, 0.5),
					Width = PTU.Width,
					Height = PTU.Height
				};
				TranslateTransform value = new TranslateTransform
				{
					X = Common.rnd.Next(-((int)sTO / 2), (int)sTO / 2),
					Y = Common.rnd.Next(-((int)h / 2), (int)h / 2)
				};
				TransformGroup transformGroup = new TransformGroup();
				transformGroup.Children.Add(value);
				image.RenderTransform = transformGroup;
				try
				{
					image.Source = new BitmapImage(new Uri(vTN, UriKind.RelativeOrAbsolute));
				}
				catch
				{
				}
				rootGrid.Children.Add(image);
				qTw(image);
			}
			if (pTW > 0)
			{
				await Task.Delay(500);
				Start();
			}
			pTW--;
		}

		private string yTf(string string_0)
		{
			if (string_0.Trim() == "")
			{
				return "";
			}
			try
			{
				if (!(string_0 == "-随机-"))
				{
					return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HitGiftManager.PicturesFolderPath, string_0);
				}
				return HitGiftManager.GetRandomPicture();
			}
			catch
			{
				return "";
			}
		}

		private string VTF(string string_0)
		{
			if (!(string_0.Trim() == "") && !(string_0.Trim() == "-无声-"))
			{
				try
				{
					return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HitGiftManager.AudiosFolderPath, string_0);
				}
				catch
				{
					return "";
				}
			}
			return "";
		}

		private async void qTw(FrameworkElement frameworkElement_0)
		{
			int num = Common.rnd.Next(0, 300);
			DoubleAnimation doubleAnimation = new DoubleAnimation();
			doubleAnimation.To = 0.0;
			doubleAnimation.Duration = TimeSpan.FromSeconds(1.0);
			doubleAnimation.BeginTime = TimeSpan.FromMilliseconds(num);
			DoubleAnimation doubleAnimation2 = new DoubleAnimation();
			doubleAnimation2.To = 0.0;
			doubleAnimation2.Duration = TimeSpan.FromSeconds(1.0);
			doubleAnimation2.BeginTime = TimeSpan.FromMilliseconds(Common.rnd.Next(0, 300));
			new DoubleAnimation
			{
				To = Common.rnd.Next(90, 720),
				Duration = TimeSpan.FromSeconds(1.0),
				BeginTime = TimeSpan.FromMilliseconds(num)
			};
			Storyboard.SetTarget(doubleAnimation, frameworkElement_0);
			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));
			Storyboard.SetTarget(doubleAnimation2, frameworkElement_0);
			Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.Y)"));
			Storyboard storyboard = new Storyboard();
			storyboard.Children.Add(doubleAnimation);
			storyboard.Children.Add(doubleAnimation2);
			storyboard.Begin(this);
			await Task.Delay(num);
			await Task.Delay(1000);
			rootGrid.Children.Remove(frameworkElement_0);
		}

	}

}
