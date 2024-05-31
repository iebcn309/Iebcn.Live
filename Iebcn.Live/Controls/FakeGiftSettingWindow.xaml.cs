using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// FakeGiftSettingWindow.xaml 的交互逻辑
	/// </summary>
	public partial class FakeGiftSettingWindow : Window, IComponentConnector, IStyleConnector
	{
		private FakeGift YtI;

		[CompilerGenerated]
		private bool AtE;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return AtE;
			}
			[CompilerGenerated]
			private set
			{
				AtE = value;
			}
		}

		public FakeGiftSettingWindow()
		{
			InitializeComponent();
			gridLog.Visibility = Visibility.Collapsed;
			base.DataContext = (YtI = Common.danmuSetting.FakeGift);
			listBox.ItemsSource = YtI.SavedList;
			txtLog.DataContext = FakeGiftManager.Log;
			base.Loaded += BtJ;
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
			try
			{
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				Util.SaveDanmuSetting();
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			}
			catch
			{
			}
		}

		private void Wtp(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void htb(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void BtJ(object sender, RoutedEventArgs e)
		{
			ReLoadFakeGifts();
			PtY();
			XtR();
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void XtR()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			try
			{
				List<GiftInfo> list = FakeGiftManager.GiftInfoList();
				FakeGiftInfo[] array = YtI.SavedList.ToArray();
				foreach (FakeGiftInfo HIO in array)
				{
					if (!list.Exists((GiftInfo x) => x.GiftId == HIO.MediaId))
					{
						YtI.SavedList.Remove(HIO);
					}
				}
			}
			catch
			{
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void PtY()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			try
			{
				if (FakeGiftManager.GiftInfoList().Count > 6)
				{
					btnDownloadMore.Visibility = Visibility.Collapsed;
				}
			}
			catch
			{
			}
		}

		public void ReLoadFakeGifts()
		{
			try
			{
				comboxFakeGift.ItemsSource = null;
				comboxFakeGift.ItemsSource = FakeGiftManager.GiftInfoList();
				PtY();
			}
			catch
			{
			}
		}

		private void zt0(object sender, RoutedEventArgs e)
		{
			try
			{
				if (stackeTypeGift != null && stackeTypeChat != null)
				{
					stackeTypeGift.Visibility = Visibility.Visible;
					stackeTypeChat.Visibility = Visibility.Collapsed;
				}
			}
			catch
			{
			}
		}

		private void rth(object sender, RoutedEventArgs e)
		{
			try
			{
				stackeTypeChat.Visibility = Visibility.Visible;
				stackeTypeGift.Visibility = Visibility.Collapsed;
			}
			catch
			{
			}
		}

		private void Gtg(object sender, RoutedEventArgs e)
		{
			try
			{
				StackPanel stackPanel = stackeTypeChat;
				stackeTypeGift.Visibility = Visibility.Collapsed;
				stackPanel.Visibility = Visibility.Collapsed;
			}
			catch
			{
			}
		}

		private void Jt9(object sender, RoutedEventArgs e)
		{
		}

		private void qt6(object sender, RoutedEventArgs e)
		{
			FakeGiftInfo item = (sender as Button).Tag as FakeGiftInfo;
			YtI.SavedList.Remove(item);
		}

		private async void ot7(object sender, RoutedEventArgs e)
		{
			try
			{
				if (comboxFakeGift.SelectedItem != null)
				{
					DanmuType dType = DanmuType.Like;
					if (rdTypeGift.IsChecked == true)
					{
						dType = DanmuType.Gift;
					}
					else if (rdTypeChat.IsChecked == true)
					{
						dType = DanmuType.Chat;
					}
					await FakeGiftManager.HandleFakeGiftInfo(new FakeGiftInfo
					{
						DType = dType,
						GiftName = txtGiftName.Text.Trim(),
						GiftExcByCount = ckGiftExcByCount.IsChecked.Value,
						ChatWords = txtChatWords.Text.Trim(),
						MediaId = (comboxFakeGift.SelectedItem as GiftInfo).GiftId,
						MediaName = (comboxFakeGift.SelectedItem as GiftInfo).Name,
						Priority = (int)numPriority.Value
					});
				}
				else
				{
					MessageBox.Show("没有选择媒体文件");
					comboxFakeGift.Focus();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void rtT(object sender, RoutedEventArgs e)
		{
			try
			{
				if (rdTypeGift.IsChecked == true && YtI.SavedList.Any((FakeGiftInfo fakeGiftInfo_0) => fakeGiftInfo_0.DType == DanmuType.Gift && fakeGiftInfo_0.GiftName == txtGiftName.Text.Trim()))
				{
					MessageBox.Show("这个礼物名称已经存在列表里了");
					txtGiftName.Focus();
					return;
				}
				if (rdTypeChat.IsChecked == true)
				{
					if (txtChatWords.Text.Trim() == "")
					{
						MessageBox.Show("弹幕文字不能为空！");
						txtChatWords.Focus();
						return;
					}
					if (YtI.SavedList.Any((FakeGiftInfo fakeGiftInfo_0) => fakeGiftInfo_0.DType == DanmuType.Chat && fakeGiftInfo_0.ChatWords == txtChatWords.Text.Trim()))
					{
						MessageBox.Show("这个弹幕文字已经存在列表里了");
						txtChatWords.Focus();
						return;
					}
				}
				if (rdTypeLike.IsChecked == true && YtI.SavedList.Any((FakeGiftInfo x) => x.DType == DanmuType.Like))
				{
					MessageBox.Show("这个点赞已经存在列表里了");
				}
				else if (comboxFakeGift.SelectedItem != null)
				{
					DanmuType dType = DanmuType.Like;
					if (rdTypeGift.IsChecked != true)
					{
						if (rdTypeChat.IsChecked == true)
						{
							dType = DanmuType.Chat;
						}
					}
					else
					{
						dType = DanmuType.Gift;
					}
					YtI.SavedList.Add(new FakeGiftInfo
					{
						DType = dType,
						GiftName = txtGiftName.Text.Trim(),
						GiftExcByCount = ckGiftExcByCount.IsChecked.Value,
						ChatWords = txtChatWords.Text.Trim(),
						MediaId = (comboxFakeGift.SelectedItem as GiftInfo).GiftId,
						MediaName = (comboxFakeGift.SelectedItem as GiftInfo).Name,
						Priority = (int)numPriority.Value
					});
				}
				else
				{
					MessageBox.Show("没有选择媒体文件");
					comboxFakeGift.Focus();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void WtG(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Collapsed;
		}

		private void Nto(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Visible;
		}

		private void Qtv(object sender, RoutedEventArgs e)
		{
			FakeGiftManager.ShowDownloadMoreFakeGiftWindow();
		}

		private async void htX(object sender, RoutedEventArgs e)
		{
			await FakeGiftManager.HandleFakeGiftInfo((sender as Button).Tag as FakeGiftInfo);
		}

		private void nty(object sender, SelectionChangedEventArgs e)
		{
		}

		private void Vt5(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl("http://www.douyin163.top/apps/fakegifts/");
		}

	}

}
