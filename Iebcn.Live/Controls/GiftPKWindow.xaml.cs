using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// GiftPKWindow.xaml 的交互逻辑
	/// </summary>
	public partial class GiftPKWindow : Window, IComponentConnector
	{
		public bool IsClosed;

		public GiftPKWindow()
		{
			InitializeComponent();
			bMe();
			GiftPKHandler.ResetGiftListCount();
			base.DataContext = Common.danmuSetting.GiftPK;
			listView.ItemsSource = (GiftPKHandler._giftList = Common.danmuSetting.GiftPK.SavedList);
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

		private void bMe()
		{
			if (Common.danmuSetting.GiftPK.SavedList.Count <= 0)
			{
				Common.danmuSetting.GiftPK.SavedList.Add(new GiftInfo
				{
					GiftId = 463,
					Count = 0,
					Name = "小心心",
					Image = "https://p3-webcast.douyinpic.com/img/webcast/0ea40b8376ef8157791b928a339ed9c9~tplv-obj.png",
					Extra = "骑马舞"
				});
				Common.danmuSetting.GiftPK.SavedList.Add(new GiftInfo
				{
					GiftId = 2002,
					Count = 0,
					Name = "大啤酒",
					Image = "https://p6-webcast.douyinpic.com/img/webcast/a24b3cc863742fd4bc3de0f53dac4487.png~tplv-obj.png",
					Extra = "嘎嘎叫"
				});
			}
			if (Common.VIPLevel < 2 && Common.danmuSetting.GiftPK.SavedList.Count > 2)
			{
				while (Common.danmuSetting.GiftPK.SavedList.Count > 2)
				{
					Common.danmuSetting.GiftPK.SavedList.RemoveAt(0);
				}
			}
		}

		private void qMq(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void uMn(object sender, RoutedEventArgs e)
		{
			GiftPKHandler.ShowUserSendListWindow();
		}

		private void LM4(object sender, RoutedEventArgs e)
		{
			Close();
		}

	}

}
