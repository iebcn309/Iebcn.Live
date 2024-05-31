using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using System.Diagnostics;
using System.IO;

namespace Iebcn.Live.Helper
{
	public sealed class FloatScreenHelper
	{
		private static FloatScreenWindow rf9;

		private static List<string> Cf6;

		private static string Lf7;

		private static void Dfh()
		{
			new List<string>();
			Directory.CreateDirectory(Lf7);
			Cf6 = (from x in Directory.GetFiles(Lf7)
				   where Wfg(x)
				   select x).ToList();
		}

		private static bool Wfg(string string_0)
		{
			string[] array = new string[4] { ".jpg", ".png", ".gif", ".bmp" };
			foreach (string value in array)
			{
				if (string_0.ToLower().EndsWith(value))
				{
					return true;
				}
			}
			return false;
		}

		public static string GetGifRndPic()
		{
			if (Cf6.Count <= 0)
			{
				Dfh();
			}
			if (Cf6.Count <= 0)
			{
				return "";
			}
			return Cf6[Common.rnd.Next(0, Cf6.Count)];
		}

		public static void OpenPicFolder()
		{
			try
			{
				Directory.CreateDirectory(Lf7);
				Process.Start(Lf7);
			}
			catch
			{
			}
		}

		public static bool CheckValidType(DanmuData data)
		{
			FloatScreen floatScreen = Common.danmuSetting.FloatScreen;
			if (data.Type == DanmuType.Chat && floatScreen.ChatEnabled)
			{
				return true;
			}
			if (data.Type == DanmuType.Gift && floatScreen.GiftEnabled)
			{
				return true;
			}
			if (data.Type == DanmuType.EnterRoom && floatScreen.EnterRoomEnabled)
			{
				return true;
			}
			if (data.Type == DanmuType.Like && floatScreen.LikeEnabled)
			{
				return true;
			}
			if (data.Type == DanmuType.Follow && floatScreen.FollowEnabled)
			{
				return true;
			}
			return false;
		}

		public static void AddData(DanmuData data)
		{
			if (rf9 != null && !rf9.IsClosed)
			{
				rf9.Play(data);
			}
		}

		public static void ShowWindow()
		{
			if (rf9 == null || rf9.IsClosed)
			{
				rf9 = new FloatScreenWindow();
			}
			rf9.Show();
			rf9.Activate();
		}

		static FloatScreenHelper()
		{
			rf9 = null;
			Cf6 = new List<string>();
			Lf7 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件\\飘屏\\动图");
		}

	}

}
