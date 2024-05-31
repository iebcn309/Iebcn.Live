using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace Iebcn.Live.Helper
{
	public class FakeGiftManager
	{
		private static FakeGiftWindow _fakeGiftWindow;

		private static FakeGiftSettingWindow _fakeGiftSettingWindow;

		private static DownloadMoreFakeGiftWindow _downloadMoreFakeGiftWindow;

		public static string MediaFolderPath;

		public static UILog Log;

		private static FakeGift _fakeGift;

		public static List<DanmuData> DanmuDataList;

		[SpecialName]
		public static List<GiftInfo> GiftInfoList()
		{
			return DeserializeGiftInfoList();
		}

		public static void ShowFakeGiftWindow()
		{
			if (_fakeGiftWindow == null || _fakeGiftWindow.IsClosed)
			{
				_fakeGiftWindow = new FakeGiftWindow();
			}
			_fakeGiftWindow.Show();
			_fakeGiftWindow.Activate();
		}

		public static void ShowFakeGiftSettingWindow()
		{
			if (_fakeGiftSettingWindow == null || _fakeGiftSettingWindow.IsClosed)
			{
				_fakeGiftSettingWindow = new FakeGiftSettingWindow();
			}
			_fakeGiftSettingWindow.Show();
			_fakeGiftSettingWindow.Activate();
		}

		public static void ShowDownloadMoreFakeGiftWindow()
		{
			if (_downloadMoreFakeGiftWindow == null || _downloadMoreFakeGiftWindow.IsClosed)
			{
				_downloadMoreFakeGiftWindow = new DownloadMoreFakeGiftWindow();
			}
			_downloadMoreFakeGiftWindow.Show();
			_downloadMoreFakeGiftWindow.Activate();
		}

		public static void HandleDanmuData(DanmuData danmuData_0)
		{
			if (Common.VIPLevel >= 1 && Common.danmuSetting.FakeGift.Enabled && _fakeGiftWindow != null && !_fakeGiftWindow.IsClosed)
			{
				_fakeGiftWindow.HandleDanmuData(danmuData_0);
			}
		}

		public static void LogInfo(string string_0)
		{
			Log.Content += DateTime.Now.ToString("hh:mm:ss") + "：" + string_0 + "\r\n";
		}

		public static bool IsValidMediaFileExtension(string string_0)
		{
			string extension = Path.GetExtension(string_0);
			if (".jpg|.png|.bmp|.gif".Contains(extension.ToLower()))
			{
				return true;
			}
			return false;
		}

		public static void ReloadFakeGifts()
		{
			if (_fakeGiftSettingWindow != null && !_fakeGiftSettingWindow.IsClosed)
			{
				_fakeGiftSettingWindow.ReLoadFakeGifts();
				_fakeGiftSettingWindow.Activate();
			}
		}

		public static async Task HandleFakeGiftInfo(FakeGiftInfo fakeGiftInfo_0)
		{
			await _fakeGiftWindow?.HandleFakeGiftInfo(fakeGiftInfo_0);
		}

		internal static void Close()
		{
			if (_fakeGiftSettingWindow != null && !_fakeGiftSettingWindow.IsClosed)
			{
				_fakeGiftSettingWindow.Close();
			}
		}

		internal static GiftInfo GetRandomGiftInfoList()
		{
			if (DeserializeGiftInfoList() == null)
			{
				return null;
			}
			if (DeserializeGiftInfoList().Count > 1)
			{
				List<GiftInfo> list = (from x in DeserializeGiftInfoList()
									   where x.GiftId > 0
									   select x).ToList();
				return list[Common.rnd.Next(list.Count)];
			}
			return null;
		}

		private static List<GiftInfo> DeserializeGiftInfoList()
		{
			List<GiftInfo> source = JsonConvert.DeserializeObject<List<GiftInfo>>(Resource1.fake_gift);
			string[] files = Directory.GetFiles(MediaFolderPath, "*.dll");
			List<int> Hya = new List<int>();
			string[] array = files;
			foreach (string path in array)
			{
				try
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
					Hya.Add(int.Parse(fileNameWithoutExtension));
				}
				catch
				{
				}
			}
			source = source.Where((GiftInfo x) => Hya.Contains(x.GiftId)).ToList();
			source.Insert(0, new GiftInfo
			{
				GiftId = 0,
				Name = "随机"
			});
			return source;
		}

		static FakeGiftManager()
		{
			_fakeGiftWindow = null;
			_fakeGiftSettingWindow = null;
			_downloadMoreFakeGiftWindow = null;
			MediaFolderPath = "Assets\\web\\FakeGift\\media";
			Log = new UILog();
			_fakeGift = Common.danmuSetting.FakeGift;
			DanmuDataList = null;
		}

	}

}
