using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using System.IO;

namespace Iebcn.Live.Helper
{
	internal class HitGiftManager
	{
		private static HitGiftSettingWindow _hitGiftSettingWindow;

		private static HitGiftWindow _hitGiftWindow;

		public static UILog Log;

		private static object _hitGiftSetting;

		public static string PicturesFolderPath;

		public static string AudiosFolderPath;

		public static void ShowHitGiftWindow()
		{
			if (_hitGiftWindow == null || _hitGiftWindow.IsClosed)
			{
				_hitGiftWindow = new HitGiftWindow();
			}
			_hitGiftWindow.Show();
			_hitGiftWindow.Activate();
		}

		public static void ShowHitGiftSettingWindow()
		{
			if (_hitGiftSettingWindow == null || _hitGiftSettingWindow.IsClosed)
			{
				_hitGiftSettingWindow = new HitGiftSettingWindow();
			}
			_hitGiftSettingWindow.Show();
			_hitGiftSettingWindow.Activate();
		}
		public static void ProcessDanmuData(DanmuData danmuData_0)
		{
			if (Common.VIPLevel >= 1 && Common.danmuSetting.HitGift.Enabled && _hitGiftWindow != null && !_hitGiftWindow.IsClosed)
			{
				_hitGiftWindow.MiH(danmuData_0);
			}
		}

		public static string GetRandomPicture()
		{
			Directory.CreateDirectory(PicturesFolderPath);
			List<string> list = (from x in Directory.GetFiles(PicturesFolderPath)
								 where x.ToLower().EndsWith(".png") || x.ToLower().EndsWith(".jpg") || x.ToLower().EndsWith(".gif") || x.ToLower().EndsWith(".bmp")
								 select x).ToList();
			if (list.Count > 0)
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, list[Common.rnd.Next(list.Count)]);
			}
			return "";
		}
		public static string GetRandomAudio()
		{
			Directory.CreateDirectory(AudiosFolderPath);
			List<string> list = (from x in Directory.GetFiles(AudiosFolderPath)
								 where x.ToLower().EndsWith(".mp3") || x.ToLower().EndsWith(".wav")
								 select x).ToList();
			if (list.Count > 0)
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, list[Common.rnd.Next(list.Count)]);
			}
			return "";
		}
		public static void LogMessage(string string_0)
		{
			UILog rFh = Log;
			rFh.Content = rFh.Content + DateTime.Now.ToString("hh:mm:ss") + "：" + string_0 + "\r\n";
		}
		public static bool IsValidPictureExtension(string string_0)
		{
			string extension = Path.GetExtension(string_0);
			if (".jpg|.png|.bmp|.gif".Contains(extension.ToLower()))
			{
				return true;
			}
			return false;
		}

		public static void HandleHitGift(HitGiftInfo hitGiftInfo_0)
		{
			_hitGiftWindow?.HandleHitGift(hitGiftInfo_0);
		}

		public static void Close()
		{
			try
			{
				if (_hitGiftSettingWindow != null && !_hitGiftSettingWindow.IsClosed)
				{
					_hitGiftSettingWindow.Close();
				}
			}
			catch
			{
			}
		}
		static HitGiftManager()
		{
			_hitGiftSettingWindow = null;
			_hitGiftWindow = null;
			Log = new UILog();
			_hitGiftSetting = Common.danmuSetting.HitGift;
			PicturesFolderPath = "Assets\\HitGift\\Pic";
			AudiosFolderPath = "Assets\\HitGift\\Audio";
		}
	}

}
