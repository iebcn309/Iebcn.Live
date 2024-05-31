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
	/// MediaTrigerSettingWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MediaTrigerSettingWindow : Window, IComponentConnector, IStyleConnector
	{
		private MediaTriger N8g;

		[CompilerGenerated]
		private bool g89;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return g89;
			}
			[CompilerGenerated]
			private set
			{
				g89 = value;
			}
		}

		public MediaTrigerSettingWindow()
		{
			InitializeComponent();
			gridLog.Visibility = Visibility.Collapsed;
			base.DataContext = (N8g = Common.danmuSetting.MediaTriger);
			listBox.ItemsSource = N8g.SavedList;
			txtLog.DataContext = MediaTriggerManager.Log;
			base.Loaded += g8S;
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

		private void N8r(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void J8A(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void g8S(object sender, RoutedEventArgs e)
		{
			V8Z();
		}

		private void V8Z()
		{
			try
			{
				Directory.CreateDirectory(MediaTriggerManager.MediaAssetsPath);
				IEnumerable<string> enumerable = from x in Directory.GetFiles(MediaTriggerManager.MediaAssetsPath)
												 where x.ToLower().EndsWith(".mp4") || x.ToLower().EndsWith(".avi") || x.ToLower().EndsWith(".mpeg") || x.ToLower().EndsWith(".png") || x.ToLower().EndsWith(".jpg") || x.ToLower().EndsWith(".gif") || x.ToLower().EndsWith(".bmp")
												 select x;
				List<string> list = new List<string>();
				foreach (string item in enumerable)
				{
					list.Add(System.IO.Path.GetFileName(item));
				}
				comboxMedia.ItemsSource = list;
			}
			catch
			{
			}
		}

		private void f8t(object sender, RoutedEventArgs e)
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

		private void z8D(object sender, RoutedEventArgs e)
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

		private void m8c(object sender, RoutedEventArgs e)
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

		private void N8k(object sender, RoutedEventArgs e)
		{
		}

		private void j8M(object sender, RoutedEventArgs e)
		{
			MediaInfo item = (sender as Button).Tag as MediaInfo;
			N8g.SavedList.Remove(item);
		}

		private void L8i(object sender, RoutedEventArgs e)
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

		private void D82(object sender, RoutedEventArgs e)
		{
			V8Z();
		}

		private void j88(object sender, SelectionChangedEventArgs e)
		{
			if (comboxMedia.SelectedItem == null)
			{
				return;
			}
			try
			{
				if (!MediaTriggerManager.IsValidMediaFileExtension(comboxMedia.SelectedItem.ToString()))
				{
					stkMdVolume.Visibility = Visibility.Visible;
					stkMdImg.Visibility = Visibility.Collapsed;
				}
				else
				{
					stkMdVolume.Visibility = Visibility.Collapsed;
					stkMdImg.Visibility = Visibility.Visible;
				}
			}
			catch
			{
			}
		}

		private void x8p(object sender, RoutedEventArgs e)
		{
			try
			{
				if (comboxMedia.SelectedItem == null)
				{
					MessageBox.Show("没有选择媒体文件");
					comboxMedia.Focus();
					return;
				}
				DanmuType dType = DanmuType.Like;
				if (rdTypeGift.IsChecked == true)
				{
					dType = DanmuType.Gift;
				}
				else if (rdTypeChat.IsChecked == true)
				{
					dType = DanmuType.Chat;
				}
				MediaTriggerManager.HandleMediaInfo(new MediaInfo
				{
					Name = txtName.Text.Trim(),
					DType = dType,
					GiftName = txtGiftName.Text.Trim(),
					GiftExcByCount = ckGiftExcByCount.IsChecked.Value,
					ChatWords = txtChatWords.Text.Trim(),
					MediaFile = comboxMedia.SelectedItem.ToString(),
					Volume = sldVolume.Value / 100.0,
					ShowSeconds = (int)numImgShowSeconds.Value,
					WindowWidth = numMdWidth.Value,
					WindowHeight = numMdHeight.Value,
					X = numMdX.Value,
					Y = numMdY.Value,
					Priority = (int)numPriority.Value
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void C8b(object sender, RoutedEventArgs e)
		{
			try
			{
				if (txtName.Text.Trim() == "")
				{
					txtName.Focus();
					MessageBox.Show("名称不能为空");
					return;
				}
				if (rdTypeGift.IsChecked == true && N8g.SavedList.Any((MediaInfo mediaInfo_0) => mediaInfo_0.DType == DanmuType.Gift && mediaInfo_0.GiftName == txtGiftName.Text.Trim()))
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
					if (N8g.SavedList.Any((MediaInfo mediaInfo_0) => mediaInfo_0.DType == DanmuType.Chat && mediaInfo_0.ChatWords == txtChatWords.Text.Trim()))
					{
						MessageBox.Show("这个弹幕文字已经存在列表里了");
						txtChatWords.Focus();
						return;
					}
				}
				if (rdTypeLike.IsChecked == true && N8g.SavedList.Any((MediaInfo x) => x.DType == DanmuType.Like))
				{
					MessageBox.Show("这个点赞已经存在列表里了");
				}
				else if (comboxMedia.SelectedItem != null)
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
					N8g.SavedList.Add(new MediaInfo
					{
						Name = txtName.Text.Trim(),
						DType = dType,
						GiftName = txtGiftName.Text.Trim(),
						GiftExcByCount = ckGiftExcByCount.IsChecked.Value,
						ChatWords = txtChatWords.Text.Trim(),
						MediaFile = comboxMedia.SelectedItem.ToString(),
						Volume = sldVolume.Value / 100.0,
						ShowSeconds = (int)numImgShowSeconds.Value,
						WindowWidth = numMdWidth.Value,
						WindowHeight = numMdHeight.Value,
						X = numMdX.Value,
						Y = numMdY.Value,
						Priority = (int)numPriority.Value
					});
				}
				else
				{
					MessageBox.Show("没有选择媒体文件");
					comboxMedia.Focus();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void H8J(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Collapsed;
		}

		private void q8R(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Visible;
		}

	}

}
