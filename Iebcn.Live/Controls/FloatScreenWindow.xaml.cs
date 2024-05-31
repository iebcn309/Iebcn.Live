using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// FloatScreenWindow.xaml 的交互逻辑
	/// </summary>
	public partial class FloatScreenWindow : Window, IComponentConnector
	{
		private FloatScreen SDD;

		private DateTime MDc = DateTime.Now;

		private List<DanmuData> GDk = new List<DanmuData>();

		public bool IsClosed;

		public FloatScreenWindow()
		{
			InitializeComponent();
			base.DataContext = (SDD = Common.danmuSetting.FloatScreen);
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

		private void gDU(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void TDW(object sender, RoutedEventArgs e)
		{
			cmdBarPanel.Visibility = Visibility.Collapsed;
			Win32API.SetTranMouseWind(this);
		}

		private void jDa(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = PDN();
			if (solidColorBrush != null)
			{
				Common.danmuSetting.FloatScreen.Foreground = solidColorBrush;
			}
		}

		private SolidColorBrush PDN()
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

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		public async void Play(DanmuData data)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			bool isTriggerMsg = false;
			try
			{
				if (!FloatScreenHelper.CheckValidType(data) || data.UserV5Level < SDD.Int32_0 || (data.Type == DanmuType.Gift && SDD.GiftEnabled && data.DiamondCount < SDD.LimitDiamondCount))
				{
					return;
				}
				GDk.Add(data);
				if (GDk.Count > 10)
				{
					GDk.RemoveAt(0);
				}
				if (gridItems.Children.Count > Common.danmuSetting.FloatScreen.MaxRunCount || MDc.AddMilliseconds(1000 * Common.danmuSetting.FloatScreen.IntervalSeconds) > DateTime.Now)
				{
					return;
				}
				DanmuData danmuData = GDk.Last();
				if (SDD.GiftEnabled)
				{
					DanmuData danmuData2 = GDk.FirstOrDefault((DanmuData x) => x.Type == DanmuType.Gift);
					if (danmuData2 != null)
					{
						danmuData = danmuData2;
						GDk.Remove(danmuData2);
					}
				}
				if (danmuData.Type == DanmuType.Chat && SDD.ChatTriggerEnabled)
				{
					string text = (from x in SDD.ChatTriggerContent.Split('\n')
								   where x.Trim().Contains("=")
								   select x).ToList().FirstOrDefault((string x) => x.Substring(0, x.IndexOf('=')) == data.PureMsg);
					if (text != null)
					{
						int num = text.IndexOf("=") + 1;
						string text2 = text.Substring(num, text.Length - num).Trim();
						text2 = text2.Replace("{用户}", data.UserNickCut);
						danmuData.ExtMsg = text2;
						isTriggerMsg = true;
					}
				}
				gridItems.Children.Add(new FloatScreenItem(danmuData, isTriggerMsg));
				MDc = DateTime.Now;
			}
			catch
			{
			}
		}

		private void PDP(object sender, RoutedEventArgs e)
		{
			try
			{
				dynamic oneUsers = RenqiHelper.GetOneUser();
				DanmuData danmuData = new DanmuData();
				danmuData.Type = DanmuType.Gift;
				danmuData.UserNick = "" + oneUsers.UserNick;
				danmuData.Msg = "" + oneUsers.UserNick + ":赠送3个棒棒糖";
				danmuData.UserHeadPic = oneUsers.UserHeadPic;
				danmuData.GiftCount = 3;
				danmuData.GiftName = "棒棒糖";
				danmuData.GiftUrl = "https://p6-webcast.douyinpic.com/img/webcast/cadd229a47b7fad58ba021c7d4638516~tplv-obj.png";
				DanmuData data = danmuData;
				gridItems.Children.Add(new FloatScreenItem(data));
			}
			catch
			{
			}
		}

		private void nDu(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void tDL(object sender, RoutedEventArgs e)
		{
			FloatScreenHelper.OpenPicFolder();
		}

		private void RD1(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void tDm(object sender, RoutedEventArgs e)
		{
			WDA();
		}

		private void TDr(object sender, MouseButtonEventArgs e)
		{
			WDA();
		}

		private void WDA()
		{
			if (Common.VIPLevel < 2)
			{
				Util.PromptPurchase(2);
			}
		}

		private void cDS(object sender, RoutedEventArgs e)
		{
			System.Windows.Controls.CheckBox checkBox = ckChat;
			SDD.ChatEnabled = true;
			checkBox.IsChecked = true;
		}

		private void JDZ(object sender, RoutedEventArgs e)
		{
			try
			{
				dynamic oneUsers = RenqiHelper.GetOneUser();
				DanmuData danmuData = new DanmuData();
				danmuData.Type = DanmuType.Chat;
				danmuData.UserNick = "" + oneUsers.UserNick;
				danmuData.Msg = "" + oneUsers.UserNick + ":666";
				danmuData.UserHeadPic = oneUsers.UserHeadPic;
				DanmuData data = danmuData;
				Play(data);
			}
			catch
			{
			}
		}

	}

}
