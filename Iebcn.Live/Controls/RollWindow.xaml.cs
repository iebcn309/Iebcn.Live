using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// RollWindow.xaml 的交互逻辑
	/// </summary>
	public partial class RollWindow : Window, IComponentConnector
	{
		private ObservableCollection<UserRollInfo> jYb = new ObservableCollection<UserRollInfo>();
		public bool IsClosed;
		public RollWindow()
		{
			InitializeComponent();
			_ = GiftHelper.giftList;
			base.DataContext = Common.danmuSetting.Roll;
			listBox.ItemsSource = jYb;
		}
		public void AddData(DanmuData data)
		{
			if (Common.danmuSetting.Roll.IsEnabled && data.Type == DanmuType.Gift && data.GiftCount > 0 && (!(Common.danmuSetting.Roll.Gifts.Trim() != "") || Common.danmuSetting.Roll.Gifts.Trim().Contains(data.GiftName)))
			{
				jYb.Add(new UserRollInfo
				{
					UserHeadPic = data.UserHeadPic,
					Roll = (Common.rnd.Next(1, 101).ToString() ?? ""),
					UserNick = data.UserNick
				});
				base.Dispatcher.Invoke(delegate
				{
					scrollview.ScrollToEnd();
				});
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				Util.SaveDanmuSetting();
				IsClosed = true;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(GetType()?.ToString() + ex.Message);
			}
		}

		private void oYA(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void OYS(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Visible;
			bgRect.Opacity = 1.0;
		}

		private void EYZ(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Collapsed;
			bgRect.Opacity = 0.0;
		}

		private void JYt(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				aYD();
			}
		}

		private void aYD()
		{
			 MessageBox.Show(this, "需要开通【互动版】才能使用！", Common.Msg_NeedVip2 ?? "");
		}

		private void fYc(object sender, RoutedEventArgs e)
		{
			try
			{
				base.ShowInTaskbar = true;
				gridBar.Visibility = Visibility.Collapsed;
				bgRect.Opacity = 0.0;
				Win32API.SetTranMouseWind(this);
			}
			catch
			{
			}
		}

		private void hYk(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void qYM(object sender, RoutedEventArgs e)
		{
			dynamic oneUser = RenqiHelper.GetOneUser();
			jYb.Add(new UserRollInfo
			{
				UserHeadPic = oneUser.UserHeadPic,
				Roll = (Common.rnd.Next(1, 101).ToString() ?? ""),
				UserNick = oneUser.UserNick
			});
			base.Dispatcher.Invoke(delegate
			{
				scrollview.ScrollToEnd();
			});
		}

		private void jYi(object sender, TextChangedEventArgs e)
		{
			try
			{
				_ = (sender as TextBox).RenderTransform;
				TextBox value = sender as TextBox;
				Storyboard storyboard = new Storyboard();
				DoubleAnimation doubleAnimation = new DoubleAnimation
				{
					From = 2.0,
					To = 1.0,
					Duration = TimeSpan.FromMilliseconds(500.0)
				};
				DoubleAnimation doubleAnimation2 = new DoubleAnimation
				{
					From = 2.0,
					To = 1.0,
					Duration = TimeSpan.FromMilliseconds(500.0)
				};
				Storyboard.SetTarget(doubleAnimation, value);
				Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("RenderTransform.ScaleX"));
				Storyboard.SetTarget(doubleAnimation2, value);
				Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("RenderTransform.ScaleY"));
				storyboard.Children.Add(doubleAnimation);
				storyboard.Children.Add(doubleAnimation2);
				storyboard.Begin();
			}
			catch
			{
			}
		}

		[CompilerGenerated]
		private void iY2()
		{
			scrollview.ScrollToEnd();
		}

		[CompilerGenerated]
		private void gY8(EventArgs eventArgs_0)
		{
			base.OnClosed(eventArgs_0);
		}

		[CompilerGenerated]
		private void XYp()
		{
			scrollview.ScrollToEnd();
		}

	}

}
