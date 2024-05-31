using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;

namespace Iebcn.Live.Helper
{
	public sealed class DanmuSender
	{
		private static bool _isProcessing;
		private static SendDanmuWindow _sendDanmuWindow;
		public static List<DanmuData> _welcomeMessages;
		public static List<DanmuData> _processedMessages;
		public static void ShowSendDanmuWindow()
		{
			if (_sendDanmuWindow == null || _sendDanmuWindow.IsClosed)
			{
				_sendDanmuWindow = new SendDanmuWindow();
			}
			_sendDanmuWindow.Show();
			_sendDanmuWindow.Activate();
		}
		public static void ProcessDanmuData(DanmuData danmuData_0)
		{
			if (_sendDanmuWindow == null || _sendDanmuWindow.IsClosed || Common.VIPLevel < 1 || (!Common.danmuSetting.AutoSendDanmu.WelcomeEnabled && !Common.danmuSetting.AutoSendDanmu.Boolean_0))
			{
				return;
			}
			_isProcessing = false;
			bool flag = danmuData_0.Type != DanmuType.Chat;
			if (Common.danmuSetting.AutoSendDanmu.WelcomeEnabled)
			{
				if (flag && (danmuData_0.FansClubLevel < Common.danmuSetting.AutoSendDanmu.FansClubLevelMin || danmuData_0.UserV5Level < Common.danmuSetting.AutoSendDanmu.Int32_0 || (danmuData_0.Type == DanmuType.Gift && (double)danmuData_0.DiamondCount < Common.danmuSetting.AutoSendDanmu.LimitDiamondCount)))
				{
					return;
				}
				if (Common.danmuSetting.AutoSendDanmu.OptTypes.FollowEnabled && danmuData_0.Type == DanmuType.Follow)
				{
					_isProcessing = true;
				}
				else if (Common.danmuSetting.AutoSendDanmu.OptTypes.LikeEnabled && danmuData_0.Type == DanmuType.Like)
				{
					_isProcessing = true;
				}
				else if (Common.danmuSetting.AutoSendDanmu.OptTypes.EnterRoomEnabled && danmuData_0.Type == DanmuType.EnterRoom)
				{
					_isProcessing = true;
				}
				else if (Common.danmuSetting.AutoSendDanmu.OptTypes.GiftEnabled && danmuData_0.Type == DanmuType.Gift)
				{
					_isProcessing = true;
				}
			}
			if (Common.danmuSetting.AutoSendDanmu.Boolean_0 && danmuData_0.Type == DanmuType.Chat && xob(danmuData_0) != "")
			{
				_isProcessing = true;
			}
			if (!_isProcessing || Common.CacheData.Take(60).Count((DanmuData x) => x.Type == DanmuType.Like && x.UserNick == danmuData_0.UserNick) > 1)
			{
				return;
			}
			if (AoR(danmuData_0.UserNick))
			{
				if (_processedMessages.Count > 100)
				{
					_processedMessages.RemoveAt(0);
				}
				_processedMessages.Add(danmuData_0);
				return;
			}
			_welcomeMessages.Add(danmuData_0);
			if (_welcomeMessages.Count > Common.danmuSetting.AutoSendDanmu.MaxCacheCount)
			{
				DanmuData danmuData = _welcomeMessages.FirstOrDefault((DanmuData x) => x.Type != DanmuType.Gift);
				if (danmuData != null)
				{
					_welcomeMessages.Remove(danmuData);
				}
				else
				{
					_welcomeMessages.RemoveAt(0);
				}
			}
		}
		public static string xob(DanmuData danmuData_0)
		{
			AutoSendDanmu autoSendDanmu = Common.danmuSetting.AutoSendDanmu;
			if (!(autoSendDanmu.String_0.Trim() == ""))
			{
				string result = "";
				try
				{
					List<string> list = (from x in autoSendDanmu.String_0.Split('\n')
										 where x.Trim() != ""
										 select x).ToList();
					if (list.Count <= 0)
					{
						return result;
					}
					foreach (string item in list)
					{
						if (!item.Contains("="))
						{
							continue;
						}
						string[] array = item.Split('=');
						if (array.Length == 0)
						{
							continue;
						}
						string text = array[0].Trim();
						string text2 = NoJ(array[1].Trim().Split('|'));
						if (string.IsNullOrEmpty(text2))
						{
							continue;
						}
						string[] array2 = text.Split('|');
						foreach (string text3 in array2)
						{
							if (!(text3.Trim() == "") && danmuData_0.PureMsg.Contains(text3.Trim()))
							{
								result = (autoSendDanmu.QAAtUser ? ("@" + danmuData_0.UserNick + " " + text2) : ("回复" + danmuData_0.UserNick + "：" + text2));
								break;
							}
						}
					}
				}
				catch
				{
				}
				return result;
			}
			return "";
		}
		private static string NoJ(object object_0)
		{
			if (object_0 != null && ((Array)object_0).Length != 0)
			{
				return (string)((object[])object_0)[Common.rnd.Next(0, ((Array)object_0).Length)];
			}
			return "";
		}
		private static bool AoR(string string_0)
		{
			try
			{
				List<string> list = (from x in Common.danmuSetting.AutoSendDanmu.KeyUserList.Split('\n')
									 where x.Trim() != ""
									 select x).ToList();
				if (list.Count < 0)
				{
					return false;
				}
				foreach (string item in list)
				{
					if (item.Trim() == string_0)
					{
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}
		static DanmuSender()
		{
			_isProcessing = false;
			_sendDanmuWindow = null;
			_welcomeMessages = new List<DanmuData>();
			_processedMessages = new List<DanmuData>();
		}
	}
}
