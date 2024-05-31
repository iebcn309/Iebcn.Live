using Iebcn.Live.Helper;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// PrintAvatarWind.xaml 的交互逻辑
	/// </summary>
	public partial class PrintAvatarWind : Window, IComponentConnector
	{
		private double kRu = 333.0;

		private bool RRL;

		public bool IsClosed;

		public PrintAvatarWind()
		{
			InitializeComponent();
			wR4();
			base.DataContext = Common.danmuSetting?.PrintAvatar;
		}

		private void wR4()
		{
			myStackPanel.Children.Clear();
			UIElementCollection children = myStackPanel.Children;
			AvatarItem avatarItem = new AvatarItem("Pack://application:,,,/Assets/UserHeadPic1.jpg");
			double width = (base.Height = kRu);
			avatarItem.Width = width;
			avatarItem.Height = kRu;
			children.Add(avatarItem);
			UIElementCollection children2 = myStackPanel.Children;
			AvatarItem avatarItem2 = new AvatarItem("Pack://application:,,,/Assets/UserHeadPic2.jpg", "感谢思聪大哥赠送的1个嘉年华");
			width = (base.Height = kRu);
			avatarItem2.Width = width;
			avatarItem2.Height = kRu;
			children2.Add(avatarItem2);
		}

		public async void Print(DanmuData data)
		{
			bool flag = false;
			if (RRL || Common.VIPLevel < 2 || !Common.danmuSetting.PrintAvatar.Enabled || (data.Type != DanmuType.Gift && data.Type != DanmuType.EnterRoom && data.Type != DanmuType.Like && data.Type != DanmuType.Follow) || (!Common.danmuSetting.PrintAvatar.OptTypes.GiftEnabled && !Common.danmuSetting.PrintAvatar.OptTypes.EnterRoomEnabled && !Common.danmuSetting.PrintAvatar.OptTypes.LikeEnabled && !Common.danmuSetting.PrintAvatar.OptTypes.FollowEnabled))
			{
				return;
			}
			if (Common.danmuSetting.PrintAvatar.OptTypes.GiftEnabled && data.Type == DanmuType.Gift)
			{
				flag = true;
			}
			if (Common.danmuSetting.PrintAvatar.OptTypes.EnterRoomEnabled && data.Type == DanmuType.EnterRoom)
			{
				flag = true;
			}
			if (Common.danmuSetting.PrintAvatar.OptTypes.LikeEnabled && data.Type == DanmuType.Like)
			{
				flag = true;
			}
			if (Common.danmuSetting.PrintAvatar.OptTypes.FollowEnabled && data.Type == DanmuType.Follow)
			{
				flag = true;
			}
			if (flag)
			{
				RRL = true;
				if (myStackPanel.Children.Count > 10)
				{
					AvatarItem obj = myStackPanel.Children[0] as AvatarItem;
					myStackPanel.Children.RemoveAt(0);
					obj?.Release();
				}
				AvatarItem control = new AvatarItem(data, await qRf(data.UserHeadPic720))
				{
					Width = kRu,
					Height = 0.0
				};
				myStackPanel.Children.Add(control);
				if (Common.danmuSetting.PrintAvatar.SoundEnabled)
				{
					await SoundPlayer.PlaySteam(new MemoryStream(Resource1.printer1));
				}
				double i = 0.0;
				while (i < kRu)
				{
					i = (control.Height = i + 8.0);
					scrollview.ScrollToEnd();
					await Task.Delay(10);
				}
				control.SetValue(FrameworkElement.HeightProperty, kRu);
				RRL = false;
			}
		}

		private async Task<Stream> qRf(string string_0)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.Timeout = new TimeSpan(0,0,5);
					return new MemoryStream(await client.GetByteArrayAsync(string_0))
					{
						Position = 0L
					};
				}
			}
			catch
			{
			}
			return null;
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

		private async void WRF()
		{
			while (true)
			{
				try
				{
					await Task.Delay(1000);
					scrollview.ScrollToEnd();
				}
				catch
				{
				}
			}
		}

		private void KRw(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void nRC(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Visible;
		}

		private void cR3(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Collapsed;
		}

		private void LRO(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				hRU();
			}
		}

		private void hRU()
		{
			  MessageBox.Show(this, "需要开通【互动版】才能使用！", Common.Msg_NeedVip2 ?? "");
		}

		private void DRW(object sender, RoutedEventArgs e)
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

		private void pRa(object sender, RoutedEventArgs e)
		{
			if (Common.danmuSetting.PrintAvatar.Enabled)
			{
				if (Common.VIPLevel < 2)
				{
					hRU();
					return;
				}
				dynamic oneUser = RenqiHelper.GetOneUser();
				DanmuData danmuData = new DanmuData();
				danmuData.Type = DanmuType.Gift;
				danmuData.UserHeadPic = oneUser.UserHeadPic;
				danmuData.UserNick = oneUser.UserNick;
				danmuData.GiftCount = 5;
				danmuData.GiftName = "小心心";
				danmuData.Msg = oneUser.UserNick;
				Print(danmuData);
			}
			else
			{
				MessageBox.Show("请先【开启】");
			}
		}

		private void qRN(object sender, RoutedEventArgs e)
		{
			Close();
		}

		[CompilerGenerated]
		private void HRP(EventArgs eventArgs_0)
		{
			base.OnClosed(eventArgs_0);
		}

	}

}
