using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using System.IO;

namespace Iebcn.Live.Helper
{
	internal class MediaTriggerManager
	{
		private static MediaTrigerSettingWindow _mediaTriggerSettingWindow;

		private static MediaTrigerWindow _mediaTriggerWindow;

		public static string MediaAssetsPath;

		public static UILog Log;

		private static MediaTriger _mediaTrigger;

		public static List<DanmuData> DanmuDataList;

		public static void ShowMediaTriggerWindow()
		{
			if (_mediaTriggerWindow == null || _mediaTriggerWindow.IsClosed)
			{
				_mediaTriggerWindow = new MediaTrigerWindow();
			}
			_mediaTriggerWindow.Show();
			_mediaTriggerWindow.Activate();
		}

		public static void ShowMediaTriggerSettingWindow()
		{
			if (_mediaTriggerSettingWindow == null || _mediaTriggerSettingWindow.IsClosed)
			{
				_mediaTriggerSettingWindow = new MediaTrigerSettingWindow();
			}
			_mediaTriggerSettingWindow.Show();
			_mediaTriggerSettingWindow.Activate();
		}

		public static void HandleDanmuData(DanmuData danmuData_0)
		{
			if (Common.VIPLevel >= 1 && Common.danmuSetting.MediaTriger.Enabled && _mediaTriggerWindow != null && !_mediaTriggerWindow.IsClosed)
			{
				_mediaTriggerWindow.HandleDanmuData(danmuData_0);
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

		public static void HandleMediaInfo(MediaInfo mediaInfo_0)
		{
			_mediaTriggerWindow?.HandleMediaInfo(mediaInfo_0);
		}

		internal static void Close()
		{
			try
			{
				if (_mediaTriggerSettingWindow != null && !_mediaTriggerSettingWindow.IsClosed)
				{
					_mediaTriggerSettingWindow.Close();
				}
			}
			catch
			{
			}
		}

		static MediaTriggerManager()
		{
			_mediaTriggerSettingWindow = null;
			_mediaTriggerWindow = null;
			MediaAssetsPath = "Assets\\Mdt";
			Log = new UILog();
			_mediaTrigger = Common.danmuSetting.MediaTriger;
			DanmuDataList = null;
		}
	}

}
