using HandyControl.Data;
using Iebcn.Live.Helper;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// RenqiWindow.xaml 的交互逻辑
	/// </summary>
	public partial class RenqiWindow : Window, IComponentConnector
	{
		private SolidColorBrush nYN = new SolidColorBrush(Color.FromArgb(184, 100, 124, 224));

		private SolidColorBrush lYP = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 0, 177, 64));

		private SolidColorBrush xYu = new SolidColorBrush(Colors.Transparent);

		private Storyboard sb1;

		[CompilerGenerated]
		private bool qYL;


		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return qYL;
			}
			[CompilerGenerated]
			private set
			{
				qYL = value;
			}
		}

		public RenqiWindow()
		{
			InitializeComponent();
			sb1 = base.Resources["sb1"] as Storyboard;
			base.DataContext = Common.danmuSetting.Renqi;
			RenqiHelper.StopFlag = false;
			base.Loaded += TYH;
		}

		private void TYH(object sender, RoutedEventArgs e)
		{
			aYU();
			Play();
			giftCtl1.Play();
			giftCtl2.Play();
			aYQ();
		}

		public async void Play()
		{
			while (!RenqiHelper.StopFlag)
			{
				if (!Common.danmuSetting.Renqi.EnterRoomEnabled && !Common.danmuSetting.Renqi.BuyEnabled)
				{
					await Task.Delay(300);
					continue;
				}
				RenqiHelper.ValidateSettings();
				if (Common.danmuSetting.Renqi.EnterRoomEnabled && Common.danmuSetting.Renqi.BuyEnabled)
				{
					if (Common.rnd.Next(1, 11) < 5)
					{
						renqiBuyctl.Visibility = Visibility.Collapsed;
						border.Visibility = Visibility.Visible;
						await SYK();
					}
					else
					{
						renqiBuyctl.Visibility = Visibility.Visible;
						border.Visibility = Visibility.Collapsed;
						await renqiBuyctl.Play();
					}
				}
				else if (Common.danmuSetting.Renqi.BuyEnabled)
				{
					renqiBuyctl.Visibility = Visibility.Visible;
					border.Visibility = Visibility.Collapsed;
					await renqiBuyctl.Play();
				}
				else
				{
					renqiBuyctl.Visibility = Visibility.Collapsed;
					border.Visibility = Visibility.Visible;
					await SYK();
				}
			}
		}

		private async Task SYK()
		{
			try
			{
				DanmuData danmuData = new DanmuData();
				int num = Common.rnd.Next(1, 40);
				dynamic oneUser = RenqiHelper.GetOneUser();
				danmuData.NewImIconWithLevel = "https://p6-webcast.douyinpic.com/img/webcast/user_grade_level_v5_" + num + ".png~tplv-obj.image";
				danmuData.UserNick = oneUser.UserNick;
				if (Common.danmuSetting.Renqi.AnonymousEnabled)
				{
					danmuData.UserNick = RenqiHelper.FormatUserNickAnonymous(oneUser.UserNick);
				}
				else
				{
					danmuData.UserNick = RenqiHelper.FormatUserNick(oneUser.UserNick, 4);
				}
				danmuData.Msg = danmuData.UserNick + ": 加入了直播间";
				border.DataContext = danmuData;
			}
			catch
			{
			}
			sb1.Begin();
			int num2 = Common.rnd.Next(Common.danmuSetting.Renqi.EnterRoomMiniSeconds, Common.danmuSetting.Renqi.EnterRoomMaxSeconds);
			await Task.Delay(3000 + num2 * 1000);
		}

		private async void aYQ()
		{
			if (Common.VIPLevel >= 1)
			{
				gridBuy.Visibility = Visibility.Collapsed;
			}
			else if (!RenqiHelper.StopFlag)
			{
				await Task.Delay(60000);
				gridBuy.Visibility = Visibility.Visible;
				aYQ();
			}
		}

		private void DYe(object sender, RoutedEventArgs e)
		{
			if (gridSetting.Visibility == Visibility.Visible)
			{
				gridSetting.Visibility = Visibility.Collapsed;
			}
			else
			{
				gridSetting.Visibility = Visibility.Visible;
			}
		}

		private void dYq(object sender, RoutedEventArgs e)
		{
			Close();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
			RenqiHelper.StopFlag = true;
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			Util.SaveDanmuSetting();
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
		}

		private void fYn(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void cY4(object sender, FunctionEventArgs<double> e)
		{
		}

		private void IYf(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl(Config.HelpUrlRenqi);
		}

		private void RYF(object sender, RoutedEventArgs e)
		{
			gridBuy.Visibility = Visibility.Collapsed;
		}

		private void mYw(object sender, MouseEventArgs e)
		{
			gridSetting.Visibility = Visibility.Visible;
			cmdBarPanel.Visibility = Visibility.Visible;
		}

		private void PYC(object sender, MouseEventArgs e)
		{
			gridSetting.Visibility = Visibility.Collapsed;
			cmdBarPanel.Visibility = Visibility.Collapsed;
		}

		private void sY3(object sender, FunctionEventArgs<double> e)
		{
		}

		private void oYO(object sender, RoutedEventArgs e)
		{
			aYU();
		}

		private void aYU()
		{
			if (Common.danmuSetting.Renqi.BgTransparentEnabled)
			{
				gridMain.Background = xYu;
			}
			else
			{
				gridMain.Background = lYP;
			}
		}

		private void AYW(object sender, RoutedEventArgs e)
		{
			base.ShowInTaskbar = true;
			gridSetting.Visibility = Visibility.Collapsed;
			cmdBarPanel.Visibility = Visibility.Collapsed;
			Win32API.SetTranMouseWind(this);
		}


	}

}
