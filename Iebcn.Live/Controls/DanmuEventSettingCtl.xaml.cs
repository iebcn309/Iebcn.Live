using Iebcn.Live.Helper;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// DanmuEventSettingCtl.xaml 的交互逻辑
	/// </summary>
	public partial class DanmuEventSettingCtl : UserControl, IComponentConnector
	{
		private DanmuEventData l7Y;

		private DanmuType O70 = DanmuType.Gift;

		public DanmuType CType
		{
			get
			{
				return O70;
			}
			set
			{
				O70 = value;
				gridIgnoreGift.Visibility = Visibility.Collapsed;
				if (O70 == DanmuType.Gift)
				{
					gridIgnoreGift.Visibility = Visibility.Visible;
					l7Y = Common.danmuSetting.EventDanmu.DataGift;
					l7Y.FolderName = "礼物";
				}
				else if (O70 == DanmuType.EnterRoom)
				{
					l7Y = Common.danmuSetting.EventDanmu.DataEnterRoom;
					l7Y.FolderName = "进场";
				}
				else if (O70 == DanmuType.Like)
				{
					l7Y = Common.danmuSetting.EventDanmu.DataLike;
					l7Y.FolderName = "点赞";
				}
				else if (O70 == DanmuType.Follow)
				{
					l7Y = Common.danmuSetting.EventDanmu.DataFollow;
					l7Y.FolderName = "关注";
				}
				comboxAniTypes.SelectedItem = l7Y.AnimationStyle;
				base.DataContext = l7Y;
				Y7i();
				List<string> list = EventDanmuManager.GetEventGifFiles(O70);
				comboxSounds.Items.Insert(0, "随机");
				for (int i = 0; i < list.Count; i++)
				{
					comboxSounds.Items.Add(list[i]);
				}
				bool flag = false;
				foreach (string item in list)
				{
					if (item == l7Y.SoundFileName)
					{
						comboxSounds.SelectedItem = item;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					comboxSounds.SelectedIndex = 0;
				}
				U7J();
			}
		}
		public DanmuEventSettingCtl()
		{
			InitializeComponent();
			comboxAniTypes.ItemsSource = new List<EventDanmuAnimationStyle>
			{
				EventDanmuAnimationStyle.Fadein,
				EventDanmuAnimationStyle.FromLeft,
				EventDanmuAnimationStyle.FromRight,
				EventDanmuAnimationStyle.FromUp,
				EventDanmuAnimationStyle.FromBottom
			};
		}

		private void K7c(object sender, RoutedEventArgs e)
		{
			if (CType == DanmuType.Gift && !Common.danmuSetting.EventDanmu.DataGift.Enabled)
			{
				MessageBox.Show("请先勾选【开启】选项");
				return;
			}
			if (CType == DanmuType.EnterRoom && !Common.danmuSetting.EventDanmu.DataEnterRoom.Enabled)
			{
				MessageBox.Show("请先勾选【开启】选项");
				return;
			}
			if (CType == DanmuType.Like && !Common.danmuSetting.EventDanmu.DataLike.Enabled)
			{
				MessageBox.Show("请先勾选【开启】选项");
				return;
			}
			if (CType == DanmuType.Follow && !Common.danmuSetting.EventDanmu.DataFollow.Enabled)
			{
				MessageBox.Show("请先勾选【开启】选项");
				return;
			}
			string userNick = "王老板";
			if (Common.danmuSetting.EventDanmu.OnlyUsers)
			{
				string text = Common.danmuSetting.EventDanmu.UserNicks.Split('|').FirstOrDefault();
				if (!string.IsNullOrEmpty(text))
				{
					userNick = text;
				}
			}
			EventDanmuManager.AddDanmuDataToEventWindow(new DanmuData
			{
				GiftCount = 1,
				GiftName = "嘉年华",
				UserNick = userNick,
				Type = CType,
				UserHeadPic = "Pack://application:,,,/Assets/sampleHead1.jpg"
			});
		}

		private void r7k(object sender, SelectionChangedEventArgs e)
		{
			if (comboxAniTypes.SelectedItem != null)
			{
				l7Y.AnimationStyle = (EventDanmuAnimationStyle)comboxAniTypes.SelectedItem;
			}
		}

		private void D7M(object sender, RoutedEventArgs e)
		{
			SelectEventPicsWindow selectEventPicsWindow = new SelectEventPicsWindow(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件", l7Y.FolderName, "动图"));
			selectEventPicsWindow.PicUrl = l7Y.PicUrl;
			selectEventPicsWindow.Owner = Common.mainWindow;
			selectEventPicsWindow.ShowDialog();
			l7Y.PicUrl = selectEventPicsWindow.PicUrl;
			Y7i();
		}

		private void Y7i()
		{
			try
			{
				string text = l7Y.PicUrl;
				if (text == "Random" || text == "")
				{
					text = "Pack://application:,,,/Assets/rnd.jpg";
				}
				ImageBehavior.SetAnimatedSource(img, new BitmapImage(new Uri(text, UriKind.RelativeOrAbsolute)));
			}
			catch
			{
			}
		}
		private async void p72(object sender, RoutedEventArgs e)
		{
			if (comboxSounds.SelectedItem == null)
			{
				return;
			}
			string text = (string)comboxSounds.SelectedItem;
			text = ((text == "随机") ? System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EventDanmuManager.GetEventBasePath(CType,true), EventDanmuManager.GetRandomEventGifFile(CType)) :System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EventDanmuManager.GetEventBasePath(CType, true), text));
			try
			{
				await SoundPlayer.Play(text, muteOtherSound: true);
			}
			catch
			{
			}
		}

		private void H78(object sender, SelectionChangedEventArgs e)
		{
			if (comboxSounds.SelectedItem != null)
			{
				l7Y.SoundFileName = (string)comboxSounds.SelectedItem;
			}
		}

		private void W7p(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EventDanmuManager.GetEventBasePath(CType, true)));
			}
			catch
			{
			}
		}

		private void i7b(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				MessageBox.Show(Common.Msg_NeedVip1);
			}
			U7J();
		}

		private void U7J()
		{
			if (!l7Y.Enabled)
			{
				rectEnabledBg.Fill = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 245, 212, 163));
			}
			else
			{
				rectEnabledBg.Fill = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 153, byte.MaxValue, 153));
			}
		}

		private void c7R(object sender, MouseButtonEventArgs e)
		{
			D7M(sender, e);
		}

	}

}
