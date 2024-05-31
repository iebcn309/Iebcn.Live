using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using System.Collections.ObjectModel;

namespace Iebcn.Live.Helper
{
	internal class GiftPKHandler
	{
		public static string ConfigurationOption;

		private static GiftPKWindow giftPKWindow;

		private static GClass0 userSendListWindow;

		public static ObservableCollection<GiftInfo> _giftList;

		public static ObservableCollection<GiftInfo> _userGiftList;

		public static void ProcessDanmuData(DanmuData danmuData)
		{
			if (giftPKWindow == null || giftPKWindow.IsClosed || !Common.danmuSetting.GiftPK.IsEnabled)
			{
				return;
			}
			if (danmuData.Type == DanmuType.Gift && _giftList.Any((GiftInfo x) => x.Name == danmuData.GiftName))
			{
				GiftInfo giftInfo = _giftList.First((GiftInfo x) => x.Name == danmuData.GiftName);
				_userGiftList.Add(new GiftInfo
				{
					Name = danmuData.GiftName,
					Extra = danmuData.UserNickCut + " 送出",
					Count = danmuData.GiftCount,
					Image = danmuData.GiftUrl
				});
				giftInfo.Count += danmuData.GiftCount;
				userSendListWindow?.UpdateUserSendList();
			}
		}

		public static void ShowGiftPKWindow()
		{
			if (giftPKWindow == null || giftPKWindow.IsClosed)
			{
				giftPKWindow = new GiftPKWindow();
			}
			giftPKWindow.Show();
			giftPKWindow.Activate();
		}

		public static void ShowUserSendListWindow()
		{
			if (userSendListWindow == null || userSendListWindow.IsClosed)
			{
				userSendListWindow = new GClass0();
			}
			userSendListWindow.Show();
			userSendListWindow.Activate();
		}

		public static void ResetGiftListCount()
		{
			foreach (GiftInfo item in _giftList)
			{
				item.Count = 0;
			}
		}

		static GiftPKHandler()
		{
			ConfigurationOption = "";
			giftPKWindow = null;
			userSendListWindow = null;
			_giftList = new ObservableCollection<GiftInfo>();
			_userGiftList = new ObservableCollection<GiftInfo>();
		}

	}

}
