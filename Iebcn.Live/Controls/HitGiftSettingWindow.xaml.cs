using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// HitGiftSettingWindow.xaml 的交互逻辑
	/// </summary>
	public partial class HitGiftSettingWindow : Window, IComponentConnector, IStyleConnector
	{
		private HitGift vMB;

		[CompilerGenerated]
		private bool bMI;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return bMI;
			}
			[CompilerGenerated]
			private set
			{
				bMI = value;
			}
		}

		public HitGiftSettingWindow()
		{
			InitializeComponent();
			gridLog.Visibility = Visibility.Collapsed;
			base.DataContext = (vMB = Common.danmuSetting.HitGift);
			listBox.ItemsSource = vMB.SavedList;
			txtLog.DataContext = HitGiftManager.Log;
			base.Loaded += mM8;
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

		private void cMi(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void DM2(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void mM8(object sender, RoutedEventArgs e)
		{
			iMp();
			oMb();
		}

		private void iMp()
		{
			try
			{
				Directory.CreateDirectory(HitGiftManager.PicturesFolderPath);
				IEnumerable<string> enumerable = from x in Directory.GetFiles(HitGiftManager.PicturesFolderPath)
												 where x.ToLower().EndsWith(".png") || x.ToLower().EndsWith(".jpg") || x.ToLower().EndsWith(".gif") || x.ToLower().EndsWith(".bmp")
												 select x;
				List<string> list = new List<string>();
				foreach (string item in enumerable)
				{
					list.Add(Path.GetFileName(item));
				}
				list.Insert(0, "-随机-");
				comboxPic.ItemsSource = list;
				comboxPic.SelectedIndex = 0;
			}
			catch
			{
			}
		}

		private void oMb()
		{
			try
			{
				Directory.CreateDirectory(HitGiftManager.AudiosFolderPath);
				IEnumerable<string> enumerable = from x in Directory.GetFiles(HitGiftManager.AudiosFolderPath)
												 where x.ToLower().EndsWith(".mp3") || x.ToLower().EndsWith(".wav")
												 select x;
				List<string> list = new List<string>();
				foreach (string item in enumerable)
				{
					list.Add(Path.GetFileName(item));
				}
				list.Insert(0, "-无声-");
				comboxAudio.ItemsSource = list;
				comboxAudio.SelectedIndex = 0;
			}
			catch
			{
			}
		}

		private void OMJ(object sender, RoutedEventArgs e)
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

		private void TMR(object sender, RoutedEventArgs e)
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

		private void FMY(object sender, RoutedEventArgs e)
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

		private void sM0(object sender, RoutedEventArgs e)
		{
		}

		private void eMh(object sender, RoutedEventArgs e)
		{
			try
			{
				Directory.CreateDirectory(MediaTriggerManager.MediaAssetsPath);
				Process.Start(MediaTriggerManager.MediaAssetsPath);
			}
			catch
			{
			}
		}

		private void SMg(object sender, RoutedEventArgs e)
		{
			try
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
				HitGiftManager.HandleHitGift(new HitGiftInfo
				{
					DType = dType,
					GiftName = txtGiftName.Text.Trim(),
					GiftExcByCount = ckGiftExcByCount.IsChecked.Value,
					ChatWords = txtChatWords.Text.Trim(),
					PicFile = comboxPic.SelectedItem.ToString(),
					AudioFile = comboxAudio.SelectedItem.ToString(),
					PicCount = (int)numCount.Value,
					LastSeconds = (int)numShowSeconds.Value,
					Priority = (int)numPriority.Value
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void AM9(object sender, RoutedEventArgs e)
		{
			try
			{
				if (rdTypeGift.IsChecked == true && vMB.SavedList.Any((HitGiftInfo hitGiftInfo_0) => hitGiftInfo_0.DType == DanmuType.Gift && hitGiftInfo_0.GiftName == txtGiftName.Text.Trim()))
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
					if (vMB.SavedList.Any((HitGiftInfo hitGiftInfo_0) => hitGiftInfo_0.DType == DanmuType.Chat && hitGiftInfo_0.ChatWords == txtChatWords.Text.Trim()))
					{
						MessageBox.Show("这个弹幕文字已经存在列表里了");
						txtChatWords.Focus();
						return;
					}
				}
				if (rdTypeLike.IsChecked == true && vMB.SavedList.Any((HitGiftInfo x) => x.DType == DanmuType.Like))
				{
					MessageBox.Show("这个点赞已经存在列表里了");
					return;
				}
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
				vMB.SavedList.Add(new HitGiftInfo
				{
					DType = dType,
					GiftName = txtGiftName.Text.Trim(),
					GiftExcByCount = ckGiftExcByCount.IsChecked.Value,
					ChatWords = txtChatWords.Text.Trim(),
					PicFile = comboxPic.SelectedItem.ToString(),
					AudioFile = comboxAudio.SelectedItem.ToString(),
					PicCount = (int)numCount.Value,
					LastSeconds = (int)numShowSeconds.Value,
					Priority = (int)numPriority.Value
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void OM6(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Collapsed;
		}

		private void nM7(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Visible;
		}

		private void mMT(object sender, RoutedEventArgs e)
		{
			iMp();
		}

		private void AMG(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HitGiftManager.PicturesFolderPath));
			}
			catch
			{
			}
		}

		private void FMo(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HitGiftManager.AudiosFolderPath));
			}
			catch
			{
			}
		}

		private void MMv(object sender, RoutedEventArgs e)
		{
			oMb();
		}

		private void DMX(object sender, RoutedEventArgs e)
		{
			HitGiftManager.HandleHitGift((sender as Button).Tag as HitGiftInfo);
		}

		private void tMy(object sender, RoutedEventArgs e)
		{
			HitGiftInfo item = (sender as Button).Tag as HitGiftInfo;
			vMB.SavedList.Remove(item);
		}

	}

}
