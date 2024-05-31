using Iebcn.Live.Controls;
using System.IO;

namespace Iebcn.Live.Helper
{
	public class SilenceHelper
	{
		// 私有变量：文本回复索引
		private static int _textIndex;

		// 私有变量：音频回复索引
		private static int _audioIndex;

		// 公共属性：本地音效文件列表
		public static List<string> LocalSoundFiles { get; private set; }

		// 私有变量：冷场窗口实例
		private static SilenceWind _silenceWindow;

		// 私有变量：文本话术组路径
		private static string _textGroupPath;

		// 私有变量：音频话术组路径
		private static string _audioGroupPath;

		// 私有变量：播放优先级标志
		private static int _playbackPriority;

		// 公共属性：是否正在处理请求的标志
		public static bool IsBusy { get; private set; }

		/// <summary>
		/// 显示冷场窗口，如需创建则创建新实例。
		/// </summary>
		public static void ShowWindow()
		{
			if (_silenceWindow == null || _silenceWindow.IsClosed)
			{
				_silenceWindow = new SilenceWind();
			}
			_silenceWindow.Show();
			_silenceWindow.Activate();
		}

		/// <summary>
		/// 加载指定目录下的本地音效文件，根据文件扩展名过滤。
		/// </summary>
		public static void LoadLocalSoundFiles()
		{
			try
			{
				string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件\\冷场\\声音");
				Directory.CreateDirectory(path);
				LocalSoundFiles = Directory.GetFiles(path)
					.Where(x => x.ToLower().EndsWith(".mp3") || x.ToLower().EndsWith(".wav"))
					.ToList();
			}
			catch
			{
			}
		}

		/// <summary>
		/// 启动冷场检测与响应循环，检查VIP等级要求。
		/// </summary>
		public static async void Start()
		{
			if (Common.VIPLevel < 1)
			{
				return;
			}

			while (!Common.AppClosed)
			{
				await Task.Delay(1000);
				if (Common.danmuSetting.Silence.Enabled)
				{
					await CheckSilenceAndRespond();
				}
			}
		}

		/// <summary>
		/// 检查冷场并根据需要触发相应响应。
		/// </summary>
		private static async Task CheckSilenceAndRespond()
		{
			if (Common.lastIneractTime.AddSeconds(Common.danmuSetting.Silence.CheckSeconds) > DateTime.Now)
			{
				return;
			}
			if (SoundPlayer.SpeakState != SpeakState.Complete ||
				AutoReplyHelper._isAutoReplying ||
				SoundPlayer.Isbusy ||
				VoiceHelper.Isbusy)
			{
				await Task.Delay(1000);
				return;
			}

			IsBusy = true;
			Common.lastIneractTime = DateTime.Now;

			if (Common.danmuSetting.Silence.UseText)
			{
				await RespondWithText();
			}
			else
			{
				await RespondWithAudio();
			}

			Common.lastIneractTime = DateTime.Now;
			IsBusy = false;
		}

		/// <summary>
		/// 使用随机选择的文本消息作为冷场响应。
		/// </summary>
		private static async Task RespondWithText()
		{
			List<string> textMessages = Common.danmuSetting.Silence.Content.Split('\n')
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.ToList();

			if (textMessages.Count > 0)
			{
				if (_textIndex >= textMessages.Count)
				{
					_textIndex = 0;
				}

				string text = textMessages[_textIndex].Trim();
				if (Common.danmuSetting.Silence.RndReadText)
				{
					text = textMessages[Common.rnd.Next(0, textMessages.Count)].Trim();
				}

				if (!string.IsNullOrEmpty(text))
				{
					text = text.Replace("{当前时间}", DateTime.Now.ToString("hh:mm") ?? "");
					await VoiceHelper.smethod_0(text, stopOther: true, null, _playbackPriority);
					_textIndex++;
				}
			}
		}

		/// <summary>
		/// 使用随机选择的音频文件作为冷场响应。
		/// </summary>
		private static async Task RespondWithAudio()
		{
			if (!Common.danmuSetting.Silence.AudioGroupModeEnabled)
			{
				if (LocalSoundFiles.Count > 0)
				{
					if (_audioIndex >= LocalSoundFiles.Count)
					{
						_audioIndex = 0;
					}

					string audioFilePath = LocalSoundFiles[_audioIndex].Trim();
					if (Common.danmuSetting.Silence.RndPlayAudio)
					{
						audioFilePath = LocalSoundFiles[Common.rnd.Next(0, LocalSoundFiles.Count)].Trim();
					}

					if (!string.IsNullOrEmpty(audioFilePath))
					{
						await SoundPlayer.Play(audioFilePath, muteOtherSound: true, _playbackPriority);
						_audioIndex++;
					}
				}
			}
			else
			{
				await RespondWithAudioGroup();
			}
		}

		/// <summary>
		/// 使用音频话术组中随机选择的音频文件作为冷场响应。
		/// </summary>
		private static async Task RespondWithAudioGroup()
		{
			List<int> audioGroupNumbers = new List<int>();

			try
			{
				audioGroupNumbers = Common.danmuSetting.Silence.AudioGroupSolution.Split('-')
					.Select(int.Parse)
					.ToList();

				if (audioGroupNumbers.Count > 0)
				{
					Directory.CreateDirectory(_audioGroupPath);

					foreach (int groupNumber in audioGroupNumbers)
					{
						string groupFolderPath = Path.Combine(_audioGroupPath, groupNumber.ToString());
						Directory.CreateDirectory(groupFolderPath);

						List<string> audioFiles = Directory.GetFiles(groupFolderPath)
							.Where(x => x.ToLower().EndsWith(".mp3") || x.ToLower().EndsWith(".wav"))
							.ToList();

						if (audioFiles.Count > 0)
						{
							await SoundPlayer.Play(audioFiles[Common.rnd.Next(audioFiles.Count)], muteOtherSound: true, _playbackPriority);
						}
					}
				}
			}
			catch
			{
			}
		}

		// 静态构造函数，初始化字段和属性
		static SilenceHelper()
		{
			_textIndex = 0;
			_audioIndex = 0;
			LocalSoundFiles = new List<string>();
			_silenceWindow = null;
			_textGroupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件\\冷场\\话术组");
			_audioGroupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件\\冷场\\音频组");
			_playbackPriority = 1;
			IsBusy = false;
		}
	}
}