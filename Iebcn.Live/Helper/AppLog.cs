using System.IO;

namespace Iebcn.Live.Helper
{
	/// <summary>
	/// 应用程序日志类
	/// </summary>
	public static class AppLog
	{
		private static string _currentDate;
		private static string _logFolder;
		private static string _giftLogFileName = "Gift_log_";
		private static string _danmuLogFileName = "Danmu_log_";
		private static string _userLogFileName = "User_log.txt";
		static AppLog()
		{
			_currentDate = DateTime.Now.ToString("yyMMdd");
			_logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "弹幕日志");
		}
		/// <summary>
		/// 获取弹幕日志文件路径
		/// </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>弹幕日志文件路径</returns>
		public static string GetDanmuLogFilePath(string fileName)
		{
			string filePath = Path.Combine(_logFolder, fileName);
			try
			{
				if (Common.danmuSetting.SaveDanmuConfig.FolderUseRoomIdEnabled)
				{
					filePath = Path.Combine(_logFolder, Common.CurrRoomId.ToString() ?? "", fileName);
				}
				Directory.CreateDirectory(Path.GetDirectoryName(filePath));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return filePath;
		}
		/// <summary>
		/// 保存礼物弹幕日志
		/// </summary>
		/// <param name="danmuData">弹幕数据</param>
		private static void SaveGiftDanmuLog(DanmuData danmuData)
		{
			try
			{
				if (Common.danmuSetting.SaveDanmuConfig.AutoSaveDanmuEnabled && Util.HasOptTypes(Common.danmuSetting.SaveDanmuConfig.OptTypes, danmuData.Type))
				{
					string filePath = GetDanmuLogFilePath(_giftLogFileName + _currentDate + ".txt");
					string contents = $"[{danmuData.Timestamp}] {danmuData.UserNick}: 送出 {danmuData.GiftCount} 个 {danmuData.GiftName}\r\n";
					File.AppendAllText(filePath, contents);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		/// <summary>
		/// 保存普通弹幕日志
		/// </summary>
		/// <param name="danmuData">弹幕数据</param>
		private static void SaveDanmuLog(DanmuData danmuData)
		{
			try
			{
				if (Common.danmuSetting.SaveDanmuConfig.AutoSaveDanmuEnabled && Util.HasOptTypes(Common.danmuSetting.SaveDanmuConfig.OptTypes, danmuData.Type))
				{
					bool isPureMsgEmpty = danmuData.PureMsg.Trim() == "";
					string filePath = GetDanmuLogFilePath(_danmuLogFileName + _currentDate + ".txt");
					string contents = $"[{danmuData.Timestamp}] {danmuData.Msg}\r\n";
					File.AppendAllText(filePath, contents);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		/// <summary>
		/// 保存用户信息日志
		/// </summary>
		/// <param name="danmuData">弹幕数据</param>
		private static void SaveUserLog(DanmuData danmuData)
		{
			try
			{
				string filePath = GetDanmuLogFilePath(_userLogFileName);
				string contents = $"{danmuData.UserNick}|{danmuData.UserHeadPic}\r\n";
				File.AppendAllText(filePath, contents);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		/// <summary>
		/// 添加应用程序日志
		/// </summary>
		/// <param name="msg">日志信息</param>
		public static void AddLog(string msg)
		{
			try
			{
				File.AppendAllText("Applog.txt", $"[{DateTime.Now}] {msg}\r\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		/// <summary>
		/// 保存弹幕日志
		/// </summary>
		/// <param name="data">弹幕数据</param>
		public static void SaveDanmu(DanmuData data)
		{
			if (data.Type == DanmuType.Gift)
			{
				SaveGiftDanmuLog(data);
			}
			else
			{
				SaveDanmuLog(data);
			}
		}
	}
}