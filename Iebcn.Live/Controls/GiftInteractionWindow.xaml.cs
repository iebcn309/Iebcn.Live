using HandyControl.Data;
using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// GiftInteractionWindow.xaml 的交互逻辑
	/// </summary>
	public partial class GiftInteractionWindow : Window, IComponentConnector, IStyleConnector
	{
		private List<GiftInfo> ccw = new List<GiftInfo>();

		private ObservableCollection<GiftInfo> icC = new ObservableCollection<GiftInfo>();

		private ObservableCollection<GiftInfo> Nc3 = new ObservableCollection<GiftInfo>();

		public bool IsClosed;

		public GiftInteractionWindow()
		{
			InitializeComponent();
			_ = GiftHelper.giftList;
			base.DataContext = Common.danmuSetting?.GiftInteraction;
			listBox.ItemsSource = icC;
			listBox2.ItemsSource = Nc3;
			UDj();
			GDB();
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void UDj()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			if (Common.danmuSetting?.GiftInteraction.SavedGifts == null)
			{
				return;
			}
			DanmuSetting danmuSetting = Common.danmuSetting;
			if (danmuSetting != null && danmuSetting.GiftInteraction.SavedGifts.Count <= 0)
			{
				return;
			}
			foreach (GiftInfo item in Common.danmuSetting?.GiftInteraction.SavedGifts)
			{
				ccw.Add(item);
				if (item.PageId == 2)
				{
					Nc3.Add(item);
				}
				else
				{
					icC.Add(item);
				}
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		public async void AddGiftData(DanmuData data)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			if (Common.danmuSetting.GiftInteraction.IsEnabled && data.Type == DanmuType.Gift && data.GiftCount > 0)
			{
				GiftInfo giftInfo = ccw.FirstOrDefault((GiftInfo x) => x.Name == data.GiftName);
				if (giftInfo != null)
				{
					giftInfo.Count += data.GiftCount;
				}
			}
		}

		private async void GDB()
		{
			try
			{
				while (!IsClosed)
				{
					if (Common.danmuSetting.GiftInteraction.IsPageSwitchEnabled)
					{
						await Task.Delay(Common.danmuSetting.GiftInteraction.SwitchIntervalSeconds * 1000);
						if (!page1.IsSelected)
						{
							page1.IsSelected = true;
						}
						else
						{
							page2.IsSelected = true;
						}
					}
					else
					{
						await Task.Delay(1000);
					}
				}
			}
			catch
			{
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				Common.danmuSetting.GiftInteraction.SavedGifts.Clear();
				foreach (GiftInfo item in ccw)
				{
					Common.danmuSetting.GiftInteraction.SavedGifts.Add(item);
				}
				Util.SaveDanmuSetting();
				IsClosed = true;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(GetType()?.ToString() + ex.Message);
			}
		}

		private void HDI(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void PDE(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Visible;
		}

		private void qDl(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Collapsed;
		}

		private void HDz(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				Vcs();
			}
		}

		private void Vcs()
		{
			  MessageBox.Show(this, "需要开通【互动版】才能使用！", Common.Msg_NeedVip2 ?? "");
		}

		private void fcx(object sender, RoutedEventArgs e)
		{
			try
			{
				base.ShowInTaskbar = true;
				gridBar.Visibility = Visibility.Collapsed;
				Win32API.SetTranMouseWind(this);
			}
			catch
			{
			}
		}

		private void Kcd(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void EcH(object sender, TextChangedEventArgs e)
		{
			string query = (sender as TextBox).Text.Trim();
			listBoxAll.ItemsSource = GiftHelper.Search(query);
		}

		private void qcK(object sender, FunctionEventArgs<double> e)
		{
		}

		private void OcQ(object sender, RoutedEventArgs e)
		{
			GiftInfo gIV = (GiftInfo)(sender as Button).Tag;
			if (!ccw.Any((GiftInfo x) => x.GiftId == gIV.GiftId))
			{
				if (!(sender as Button).Content.ToString().Contains("2"))
				{
					gIV.PageId = 1;
				}
				else
				{
					gIV.PageId = 2;
				}
				ccw.Add(gIV);
				if (gIV.PageId == 2)
				{
					Nc3.Add(gIV);
				}
				else
				{
					icC.Add(gIV);
				}
			}
			else
			{
				MessageBox.Show("已存在！");
			}
		}

		private void Ece(object sender, RoutedEventArgs e)
		{
			GiftInfo giftInfo = (GiftInfo)(sender as Button).Tag;
			ccw.Remove(giftInfo);
			if (giftInfo.PageId == 2)
			{
				Nc3.Remove(giftInfo);
			}
			else
			{
				icC.Remove(giftInfo);
			}
		}

		private void Xcq(object sender, RoutedEventArgs e)
		{
			((GiftInfo)(sender as Button).Tag).Count = 0;
		}

		private void fcn(object sender, RoutedEventArgs e)
		{
			if (gridSetting.Visibility == Visibility.Collapsed)
			{
				gridSetting.Visibility = Visibility.Visible;
			}
			else
			{
				gridSetting.Visibility = Visibility.Collapsed;
			}
		}

		private void rc4(object sender, MouseButtonEventArgs e)
		{
			gridSetting.Visibility = Visibility.Collapsed;
		}

		private void ncf(object sender, TextChangedEventArgs e)
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

	}

}
