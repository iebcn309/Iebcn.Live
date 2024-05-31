using HandyControl.Data;
using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// OvertimeWindow.xaml 的交互逻辑
	/// </summary>
	public partial class OvertimeWindow : Window, IComponentConnector, IStyleConnector
	{
		private Storyboard sb1;

		private DispatcherTimer HJ0;

		private Overtime dJh;

		public bool IsClosed;

		private ObservableCollection<DanmuData> dJg;
		private static List<OvertimeGift> PLR;

		public OvertimeWindow()
		{
			InitializeComponent();
			base.DataContext = (dJh = Common.danmuSetting.Overtime);
			listBoxAll.ItemsSource = bLp();
			dJg = new ObservableCollection<DanmuData>();
			listLog.ItemsSource = dJg;
			HJ1();
			sb1 = base.Resources["sb1"] as Storyboard;
			HJ0 = new DispatcherTimer();
			HJ0.Interval = TimeSpan.FromSeconds(1.0);
			HJ0.Tick += UJu;
			HJ0.Start();
		}
		public static List<OvertimeGift> bLp()
		{
			if (PLR == null)
			{
				PLR = new List<OvertimeGift>();
				foreach (GiftInfo gift in GiftHelper.giftList)
				{
					PLR.Add(new OvertimeGift
					{
						Pic = gift.Image,
						GiftName = gift.Name,
						Id = gift.GiftId,
						IsAdd = true,
						Seconds = 1.0
					});
				}
			}
			return PLR;
		}

		public static List<OvertimeGift> FL8(string string_0)
		{
			return (from x in bLp()
					where x.GiftName.Contains(string_0)
					select x).ToList();
		}
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			Util.SaveDanmuSetting();
			IsClosed = true;
		}
		public void AddData(DanmuData data)
		{
			if (data.Type != DanmuType.Gift || !dJh.IsEnabled)
			{
				return;
			}
			OvertimeGift overtimeGift = dJh.ListDataSaved.FirstOrDefault((OvertimeGift x) => x.GiftName == data.GiftName);
			if (overtimeGift != null)
			{
				string text = "+";
				if (overtimeGift.IsAdd)
				{
					dJh.RemainTimeSeconds += (long)overtimeGift.Seconds;
				}
				else
				{
					text = "-";
					dJh.RemainTimeSeconds -= (long)overtimeGift.Seconds;
				}
				TimeSpan timeSpan = TimeSpan.FromSeconds(overtimeGift.Seconds);
				nJL(data.UserNickCut + text + Math.Round(timeSpan.TotalMinutes, 2) + "分钟");
				data.ExtMsg = text + Math.Round(timeSpan.TotalMinutes, 2) + "分钟";
				dJg.Add(data);
			}
		}

		private void UJu(object sender, EventArgs e)
		{
			if (!IsClosed)
			{
				dJh.IsComplete = dJh.RemainTimeSeconds <= 0L;
				if (!dJh.IsComplete)
				{
					dJh.RemainTimeSeconds--;
				}
			}
			else
			{
				HJ0.Stop();
				HJ0 = null;
			}
		}

		private void nJL(string string_0)
		{
			lbUserAddTime.Content = string_0;
			sb1.Begin(this);
		}

		public void DelItem(OvertimeGiftItemCtl item)
		{
			wrapPanel.Children.Remove(item);
			Common.danmuSetting.Overtime.ListDataSaved.Remove(item.gift);
		}

		private void HJ1()
		{
			if (dJh.ListDataSaved == null || dJh.ListDataSaved.Count <= 0)
			{
				return;
			}
			foreach (OvertimeGift item in dJh.ListDataSaved)
			{
				wrapPanel.Children.Add(new OvertimeGiftItemCtl(this, item));
			}
		}

		private void vJm(object sender, RoutedEventArgs e)
		{
			OvertimeGift hlw = (OvertimeGift)(sender as System.Windows.Controls.Button).Tag;
			if (!dJh.ListDataSaved.Any((OvertimeGift x) => x.Id == hlw.Id))
			{
				if (dJh.ListDataSaved.Count < 6)
				{
					List<System.Windows.Controls.ComboBox> list = FindVisualChildren<System.Windows.Controls.ComboBox>((sender as System.Windows.Controls.Button).Parent);
					if (list != null)
					{
						hlw.IsAdd = list[0].SelectedIndex == 0;
					}
					dJh.ListDataSaved.Add(hlw);
					wrapPanel.Children.Add(new OvertimeGiftItemCtl(this, hlw));
				}
				else
				{
					System.Windows.MessageBox.Show("已添加有6项了！");
				}
			}
			else
			{
				System.Windows.MessageBox.Show("已存在！");
			}
		}

		private void WJr(object sender, TextChangedEventArgs e)
		{
			string string_ = (sender as System.Windows.Controls.TextBox).Text.Trim();
			listBoxAll.ItemsSource = FL8(string_);
		}

		private void tJA(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Collapsed;
			if (base.Width < 980.0)
			{
				base.Width = 980.0;
			}
			else
			{
				base.Width = 500.0;
			}
		}

		private void qJS(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void TJZ(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void IJt(object sender, System.Windows.Input.MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Visible;
		}

		private void mJD(object sender, System.Windows.Input.MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Collapsed;
		}

		private void nJc(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = lJi();
			if (solidColorBrush != null)
			{
				System.Windows.Controls.Button obj = sender as System.Windows.Controls.Button;
				Brush background = (dJh.GiftNameForeground = solidColorBrush);
				obj.Background = background;
			}
		}

		private void AJk(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = lJi();
			if (solidColorBrush != null)
			{
				System.Windows.Controls.Button obj = sender as System.Windows.Controls.Button;
				Brush background = (dJh.GiftDescForeground = solidColorBrush);
				obj.Background = background;
			}
		}

		private void LJM(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = lJi();
			if (solidColorBrush != null)
			{
				System.Windows.Controls.Button obj = sender as System.Windows.Controls.Button;
				Brush background = (dJh.OtherForeground = solidColorBrush);
				obj.Background = background;
			}
		}

		private SolidColorBrush lJi()
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.AllowFullOpen = true;
			if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				return new SolidColorBrush
				{
					Color = new Color
					{
						A = colorDialog.Color.A,
						B = colorDialog.Color.B,
						G = colorDialog.Color.G,
						R = colorDialog.Color.R
					}
				};
			}
			return null;
		}

		public static List<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
		{
			List<T> list = new List<T>();
			if (depObj != null)
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T)
					{
						list.Add((T)child);
					}
					List<T> list2 = FindVisualChildren<T>(child);
					if (list2 == null || list2.Count() <= 0)
					{
						continue;
					}
					foreach (T item in list2)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		private void pJ2(object sender, RoutedEventArgs e)
		{
			bg.Fill = (sender as System.Windows.Controls.Button).Background;
		}

		private void vJ8(object sender, FunctionEventArgs<double> e)
		{
			if (dJh != null)
			{
				dJh.RemainTimeSeconds = (long)numInitSeconds.Value * 60L;
			}
		}

		private void PJp(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Visible;
			if (base.Width < 980.0)
			{
				base.Width = 980.0;
			}
		}

		private void tJb(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Collapsed;
		}

		private void JJJ(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Visible;
		}

		private void rJR(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

	}

}
