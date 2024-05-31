using Iebcn.Live.Controls;
using System.Diagnostics;
using System.IO;

namespace Iebcn.Live.Helper
{
	public class AutoReplyHelper
	{
		private static string _audioDirectory; // 音频文件目录
		private static string _logFilePath; // 日志文件路径
		private static int _sendInterval; // 自动回复间隔（秒）
		private static AutoReplyWindow _replyWindow; // 自动回复窗口
		private static List<ReplyData> _replyList; // 回复数据列表

		internal static bool _isAutoReplying; // 是否正在自动回复

		/// <summary>
		/// 显示自动回复窗口
		/// </summary>
		public static void ShowWindow()
		{
			if (_replyWindow == null || _replyWindow.IsClosed)
			{
				_replyWindow = new AutoReplyWindow();
			}
			_replyWindow.Show();
			_replyWindow.Activate();
		}

		/// <summary>
		/// 开始自动回复
		/// </summary>
		public static async Task Start()
		{
			if (Common.VIPLevel <= 0)
			{
				return;
			}
			while (true)
			{
				try
				{
					if (!Common.danmuSetting.AutoReply.AudioFileReplyEnabled && !Common.danmuSetting.AutoReply.ContentReplyEnabled || _replyList.Count <= 0)
					{
						break;
					}
					var data = _replyList[0];
					_replyList.RemoveAt(0);
					if (string.IsNullOrWhiteSpace(data.Answer))
					{
						continue;
					}
					bool isAudioFile = data.Answer.ToLower().EndsWith(".mp3") || data.Answer.ToLower().EndsWith(".wav");
					_isAutoReplying = true;
					if (Common.danmuSetting.AutoReply.ReadQuestionEnabled)
					{
						await VoiceHelper.smethod_0($"回复{data.Nick},{data.PureMsg}", true, null, _sendInterval);
					}
					if (isAudioFile)
					{
						await SoundPlayer.Play(Path.Combine(_audioDirectory, data.Answer), muteOtherSound: true, level: _sendInterval);
					}
					else
					{
						await VoiceHelper.smethod_0(data.Answer, true, null, _sendInterval);
					}
					Log($"回复{data.Nick}：{data.PureMsg} -----> {data.Answer}");
					_isAutoReplying = false;
				}
				catch (Exception ex)
				{
					_isAutoReplying = false;
					Log($"自动回复出错：{ex.Message}");
					break;
				}
				await Task.Delay(_sendInterval);
			}
		}

		private static string uGA(DanmuData danmuData_0)
		{
			if (!Common.danmuSetting.AutoReply.ContentReplyEnabled)
			{
				return "";
			}
			string result = "";
			List<string> list = (from x in Common.danmuSetting.AutoReply.ContentReplySetting.Split('\n')
								 where x.Trim() != ""
								 select x).ToList();
			if (list.Count > 0)
			{
				foreach (string item in list)
				{
					if (item.Contains("="))
					{
						string[] array = item.Split('=');
						if (array.Length != 0)
						{
							string text = array[0].Trim();
							string text2 = VGS(array[1].Trim().Split('|'));
							if (!string.IsNullOrEmpty(text2))
							{
								string[] array2 = text.Split('|');
								foreach (string text3 in array2)
								{
									if (!(text3.Trim() == "") && danmuData_0.PureMsg.Contains(text3.Trim()))
									{
										result = text2;
										break;
									}
								}
							}
						}
					}
				}
				return result;
			}
			return result;
		}
		private static string VGS(object object_0)
		{
			if (object_0 != null && ((Array)object_0).Length != 0)
			{
				return ((string)((object[])object_0)[Common.rnd.Next(0, ((Array)object_0).Length)]).Trim();
			}
			return "";
		}
		private static string RGZ(DanmuData danmuData_0)
		{
			if (!Common.danmuSetting.AutoReply.AudioFileReplyEnabled)
			{
				return "";
			}
			string result = "";
			List<string> list = (from x in Common.danmuSetting.AutoReply.AudioFileReplySetting.Split('\n')
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
				string text2 = VGS(array[1].Trim().Split('|'));
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				string[] array2 = text.Split('|');
				foreach (string text3 in array2)
				{
					if (!(text3.Trim() == "") && danmuData_0.PureMsg.Contains(text3.Trim()))
					{
						result = text2;
						break;
					}
				}
			}
			return result;
		}
		public static void OpenLog()
		{
			try
			{
				if (File.Exists(_logFilePath))
				{
					Process.Start(_logFilePath);
				}
				Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
			}
			catch
			{
			}
		}
		public static void Log(string msg)
		{
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
				File.AppendAllText(_logFilePath, "[" + DateTime.Now.ToString() + "] " + msg + "\r\n");
			}
			catch
			{
			}
		}
		internal static void AGt(DanmuData danmuData_0)
		{
			if (Common.VIPLevel <= 0 || (!Common.danmuSetting.AutoReply.AudioFileReplyEnabled && !Common.danmuSetting.AutoReply.ContentReplyEnabled) || danmuData_0.Type != 0)
			{
				return;
			}
			string text = uGA(danmuData_0);
			if (text == "")
			{
				text = RGZ(danmuData_0);
			}
			if (text != "")
			{
				if (_replyList.Count > 10)
				{
					_replyList.RemoveAt(_replyList.Count - 1);
				}
				_replyList.Add(new ReplyData(danmuData_0.UserNick, danmuData_0.PureMsg, text));
			}
		}


		static AutoReplyHelper()
		{
			_audioDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\自动问答声音");
			_logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "弹幕日志", "问答日志.txt");
			_sendInterval = 2; // 默认发送间隔为2秒
			_replyWindow = null;
			_replyList = new List<ReplyData>();
			_isAutoReplying = false;
		}
	}

}