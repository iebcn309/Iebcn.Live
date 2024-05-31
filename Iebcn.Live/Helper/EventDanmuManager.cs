using Iebcn.Live.Controls;
using System.IO;

namespace Iebcn.Live.Helper
{
	// 内部类L49，用于处理与弹幕事件相关的数据和逻辑
	public class EventDanmuManager
	{
		// 弹幕事件数据对象
		private static DanmuEventData mfs;

		// 礼物声音文件列表
		private static List<string> Xfx;
		// 进场声音文件列表
		private static List<string> Afd;
		// 点赞声音文件列表
		private static List<string> EfH;
		// 关注声音文件列表
		private static List<string> lfK;

		// 礼物动图文件列表
		private static List<string> KfQ;
		// 进场动图文件列表
		private static List<string> mfe;
		// 点赞动图文件列表
		private static List<string> Sfq;
		// 关注动图文件列表
		private static List<string> rfn;

		// 弹幕事件窗口对象
		private static EventDanmuWindow Xf4;

		// 显示弹幕事件窗口
		public static void ShowEventDanmuWindow()
		{
			if (Xf4 == null || Xf4.IsClosed)
			{
				Xf4 = new EventDanmuWindow();
			}
			Xf4.Show();
			Xf4.Activate();
		}

		// 初始化弹幕事件相关文件列表
		public static void InitializeEventFiles()
		{
			try
			{
				// 获取各类弹幕事件的声音和动图文件路径
				Xfx = GetEventFilePaths(DanmuType.Gift, isSound: true);
				Afd = GetEventFilePaths(DanmuType.EnterRoom, isSound: true);
				EfH = GetEventFilePaths(DanmuType.Like, isSound: true);
				lfK = GetEventFilePaths(DanmuType.Follow, isSound: true);
				KfQ = GetEventFilePaths(DanmuType.Gift);
				mfe = GetEventFilePaths(DanmuType.EnterRoom);
				Sfq = GetEventFilePaths(DanmuType.Like);
				rfn = GetEventFilePaths(DanmuType.Follow);
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.Message);
			}
		}

		// 获取指定类型弹幕事件的文件路径列表（声音或动图）
		private static List<string> GetEventFilePaths(DanmuType danmuType, bool isSound = false)
		{
			List<string> filePaths = new List<string>();

			string basePath = GetEventBasePath(danmuType, isSound);
			Directory.CreateDirectory(basePath);

			IEnumerable<string> fileEntries = isSound ?
				Directory.GetFiles(basePath).Where(JudgeValidSoundFile) :
				Directory.GetFiles(basePath).Where(JudgeValidImageFile);

			foreach (string filePath in fileEntries.ToList())
			{
				filePaths.Add(Path.GetFileName(filePath));
			}

			return filePaths;
		}

		// 获取指定类型弹幕事件的文件基础路径（声音或动图）
		public static string GetEventBasePath(DanmuType danmuType, bool isSound = false)
		{
			string basePath = string.Empty;

			switch (danmuType)
			{
				case DanmuType.Gift:
					basePath = isSound ? "Assets\\事件\\礼物\\声音" : "Assets\\事件\\礼物\\动图";
					break;
				case DanmuType.EnterRoom:
					basePath = isSound ? "Assets\\事件\\进场\\声音" : "Assets\\事件\\进场\\动图";
					break;
				case DanmuType.Like:
					basePath = isSound ? "Assets\\事件\\点赞\\声音" : "Assets\\事件\\点赞\\动图";
					break;
				case DanmuType.Follow:
					basePath = isSound ? "Assets\\事件\\关注\\声音" : "Assets\\事件\\关注\\动图";
					break;
			}

			return isSound ? basePath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, basePath);
		}

		// 添加弹幕数据到弹幕事件窗口
		public static void AddDanmuDataToEventWindow(DanmuData danmuData)
		{
			if (Xf4 == null || Xf4.IsClosed)
			{
				Xf4 = new EventDanmuWindow();
			}
			Xf4.Show();
			Xf4.Activate();
			Xf4.AddData(danmuData);
		}

		// 处理特定条件下的弹幕事件
		public static void HandleConditionalDanmuEvent(DanmuData danmuData)
		{
			if (Common.VIPLevel < 1 ||
				Xf4 == null || Xf4.IsClosed ||
				(Common.danmuSetting.EventDanmu.OnlyUsers &&
				 !Common.danmuSetting.EventDanmu.UserNicks.Split('|')
					 .Any(x => x.Trim() == danmuData.UserNick)))
			{
				return;
			}

			switch (danmuData.Type)
			{
				case DanmuType.Gift:
					mfs = Common.danmuSetting.EventDanmu.DataGift;
					break;
				case DanmuType.EnterRoom:
					mfs = Common.danmuSetting.EventDanmu.DataEnterRoom;
					break;
				case DanmuType.Like:
					mfs = Common.danmuSetting.EventDanmu.DataLike;
					break;
				case DanmuType.Follow:
					mfs = Common.danmuSetting.EventDanmu.DataFollow;
					break;
			}

			if (mfs != null && mfs.Enabled)
			{
				Xf4.AddData(danmuData);
			}
		}

		// 根据弹幕类型获取对应的动图文件列表
		public static List<string> GetEventGifFiles(DanmuType danmuType)
		{
			List<string> gifFiles = new List<string>();

			switch (danmuType)
			{
				case DanmuType.Gift:
					gifFiles = KfQ;
					break;
				case DanmuType.EnterRoom:
					gifFiles = mfe;
					break;
				case DanmuType.Like:
					gifFiles = Sfq;
					break;
				case DanmuType.Follow:
					gifFiles = rfn;
					break;
			}

			return gifFiles;
		}

		// 随机获取指定类型弹幕事件的声音文件
		public static string GetRandomEventSoundFile(DanmuType danmuType)
		{
			if (danmuType == DanmuType.Gift)
			{
				return GetRandomEventSoundFile(Xfx);
			}
			else if (danmuType == DanmuType.EnterRoom)
			{
				return GetRandomEventSoundFile(Afd);
			}
			else if (danmuType == DanmuType.Like)
			{
				return GetRandomEventSoundFile(EfH);
			}
			else if (danmuType == DanmuType.Follow)
			{
				return GetRandomEventSoundFile(lfK);
			}
			return "";
		}
		public static string GetRandomEventSoundFile(List<string> list)
		{
			if (list == null || list.Count <= 0)
			{
				return "";
			}
			return list[Common.rnd.Next(0, Afd.Count)];
		}
		public static string l4V()
		{
			if (Xfx.Count <= 0)
			{
				return "";
			}
			return Xfx[Common.rnd.Next(0, Xfx.Count)];
		}

		public static string A4j()
		{
			if (Afd.Count <= 0)
			{
				return "";
			}
			return Afd[Common.rnd.Next(0, Afd.Count)];
		}

		public static string z4B()
		{
			if (EfH.Count <= 0)
			{
				return "";
			}
			return EfH[Common.rnd.Next(0, EfH.Count)];
		}

		public static string d4I()
		{
			if (lfK.Count > 0)
			{
				return lfK[Common.rnd.Next(0, lfK.Count)];
			}
			return "";
		}
		// 随机获取指定类型弹幕事件的动图文件
		public static string GetRandomEventGifFile(DanmuType danmuType)
		{
			List<string> gifFiles = GetEventGifFiles(danmuType);
			if (gifFiles.Count > 0)
			{
				return gifFiles[Common.rnd.Next(0, gifFiles.Count)];
			}
			return "";
		}

		// 判断文件是否为有效声音文件
		private static bool JudgeValidSoundFile(string filePath)
		{
			string[] soundExtensions = { ".wav", ".mp3" };
			return soundExtensions.Any(ext => filePath.ToLower().EndsWith(ext));
		}

		// 判断文件是否为有效图像文件
		private static bool JudgeValidImageFile(string filePath)
		{
			string[] imageExtensions = { ".jpg", ".png", ".gif", ".bmp" };
			return imageExtensions.Any(ext => filePath.ToLower().EndsWith(ext));
		}
	}
}
