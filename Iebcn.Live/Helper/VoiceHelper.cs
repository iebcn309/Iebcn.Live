using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace Iebcn.Live.Helper
{
	public static class VoiceHelper
	{
		public static bool Isbusy;
		public static bool CanSpeak = true;
		private static bool _isForbiddenWords;
		private static bool _isFakeDanmu;
		private static List<DanmuData> _danmuList = new List<DanmuData>();
		private static Random _random = new Random();
		public static List<Emoji> EmojiList;

		public static void LoadVoiceList()
		{
			//    SoundPlayer.Speek("哼，你这个笨蛋学长居然还要我再说一遍！我就是桃花元子啊！难道你真的脑袋有问题吗？问这种问题干嘛，真是浪费我宝贵的时间！哼哼，笨蛋学长，记住了吧！桃花元子就是我，傲娇学妹的代表！");
			foreach (string item in (from x in Resource1.txtVoice.Split("\n".ToCharArray()).ToList()
									 where x.Trim() != ""
									 select x).ToList())
			{
				string[] array = item.Split('|');
				if (array.Length == 3)
				{
					Common.VoiceList.Add(new Voice
					{
						Platform = (VoicePlatform)Enum.Parse(typeof(VoicePlatform), array[0].Trim()),
						SpeakerName = array[1].Trim(),
						SpeakerValue = array[2].Trim()
					});
				}
			}
			if (EmojiList == null)
			{
				EmojiList = new List<Emoji>();
			}
			try
			{
				dynamic val = JsonConvert.DeserializeObject<object>(Resource1.emoji_list);
				if (val == null)
				{
					return;
				}
				foreach (dynamic item in val.emoji_list)
				{
					EmojiList.Add(new Emoji("" + item.display_name, "" + item.emoji_url?.url_list[0]));
				}
			}
			catch (Exception ex)
			{
				AppLog.AddLog("load emoji err:" + ex.Message);
			}
		}

		public static double ConvertSpeed(this Voice voice)
		{
			switch (voice.Platform)
			{
				case VoicePlatform.Xunfei:
					return voice.Speed;
				case VoicePlatform.Baidu:
					return voice.Speed / 100.0 * 15.0;
				case VoicePlatform.Dui:
					return 1.0 - voice.Speed / 200.0;
				case VoicePlatform.Ali:
					return voice.Speed - 50.0;
				case VoicePlatform.Azure:
					if (voice.Speed >= 50)
					{
						return (double)(voice.Speed - 50) / 50.0 * 200.0;
					}
					return (double)voice.Speed - 50.0;
				default:
					return 50.0;
			}
		}

		public static int ConvertVolume(this Voice voice)
		{
			switch (voice.Platform)
			{
				case VoicePlatform.Xunfei:
				case VoicePlatform.Ali:
					return voice.Volume;
				case VoicePlatform.Baidu:
					return (int)(voice.Volume * 0.15);
				case VoicePlatform.Dui:
				case VoicePlatform.Azure:
					return (int)(voice.Volume * 2.0);
				default:
					return voice.Volume;
			}
		}

		public static int ConvertPitch(this Voice voice)
		{
			switch (voice.Platform)
			{
				case VoicePlatform.Xunfei:
					return voice.Pitch;
				case VoicePlatform.Baidu:
					return (int)(voice.Pitch * 0.15);
				case VoicePlatform.Dui:
					return voice.Pitch / 100;
				case VoicePlatform.Ali:
				case VoicePlatform.Azure:
					return voice.Volume - 50;
				default:
					return 50;
			}
		}
		public static async Task VoiceDanmu(DanmuData data)
		{
			_isFakeDanmu = false;
			if (data == null || SilenceHelper.IsBusy)
			{
				return;
			}
			if (data.Type == DanmuType.Gift)
			{
				if (!_danmuList.Contains(data))
				{
					_danmuList.Add(data);
				}
				if (_danmuList.Count > 8)
				{
					_danmuList.RemoveAt(0);
				}
			}
			if (Common.danmuSetting.VoiceDanmu.GiftFirstEnabled && _danmuList.Count > 0)
			{
				data = _danmuList.Last();
			}
			if (!CanSpeak)
			{
				return;
			}
			string text = FormatNumbers(data.UserNickCut);
			int giftCount = data.GiftCount;
			string giftName = data.GiftName;
			string TjV = text + ":" + data.Msg;
			CanSpeak = false;
			try
			{
				if (text.Length > 10)
				{
					text = text.Substring(0, 9) + "...";
				}
				text = NumbersToCN(text);
				if (data.Type == DanmuType.EnterRoom)
				{
					string fromUser = text;
					TjV = FormatOptContent(Common.danmuSetting.VoiceDanmu.OptContent.EnterRoomFormat, fromUser, giftName, giftCount);
				}
				else if (data.Type == DanmuType.Gift)
				{
					string fromUser = text;
					TjV = FormatOptContent(Common.danmuSetting.VoiceDanmu.OptContent.GiftFormat, fromUser, giftName, giftCount);
				}
				else if (data.Type == DanmuType.Follow)
				{
					string fromUser = text;
					TjV = FormatOptContent(Common.danmuSetting.VoiceDanmu.OptContent.FollowFormat, fromUser, giftName, giftCount);
				}
				else if (data.Type == DanmuType.Like)
				{
					string fromUser = text;
					TjV = FormatOptContent(Common.danmuSetting.VoiceDanmu.OptContent.LikeFormat, fromUser, giftName, giftCount);
				}
				else if (data.Type != 0)
				{
					if (data.Type == DanmuType.App)
					{
						TjV = data.Msg;
					}
				}
				else
				{
					TjV = data.Msg;
					int num = TjV.IndexOf("：");
					if (num <= 0)
					{
						num = TjV.IndexOf(":");
					}
					if (num >= 0)
					{
						if (Common.danmuSetting.VoiceDanmu.CutEnabled && TjV.Length - num > Common.danmuSetting.VoiceDanmu.CutCount)
						{
							TjV = TjV.Substring(0, Common.danmuSetting.VoiceDanmu.CutCount + num);
						}
						TjV = TjV.Insert(num, "说");
					}
				}
				_isForbiddenWords = false;
				if (Common.danmuSetting.VoiceDanmu.ForbiddenWordsEnabled && data.Type == DanmuType.Chat)
				{
					_isForbiddenWords = Util.CheckIsForbiddenWords(TjV);
				}
				if (!_isForbiddenWords)
				{
					TjV = iG6(TjV);
					await Task.Run(() => smethod_0(TjV + "。" + jfE(data.Type)));
					if (data.Type == DanmuType.Gift)
					{
						_danmuList.Remove(data);
					}
					if (Common.danmuSetting.VoiceDanmu.IntervalSeconds > 0)
					{
						await Task.Delay(1000 * Common.danmuSetting.VoiceDanmu.IntervalSeconds);
					}
				}
				CanSpeak = true;
			}
			catch (Exception)
			{
			}
			CanSpeak = true;
		}

		public static string iG6(string string_0)
		{
			try
			{
				MatchCollection matchCollection = null;
				string text = string_0;
				foreach (Emoji item in EmojiList)
				{
					matchCollection = new Regex("(\\" + item.DisplayName.TrimEnd(']') + "\\]){4,100}").Matches(string_0);
					if (matchCollection.Count <= 0)
					{
						continue;
					}
					foreach (Match item2 in matchCollection)
					{
						text = text.Replace(item2.Value, item.DisplayName);
					}
				}
				return text;
			}
			catch
			{
				return string_0;
			}
		}
		//private static FunnyRobotWindow ffl;

		public static string jfE(DanmuType danmuType_0)
		{
			//	if (ffl != null && !ffl.IsClosed && Common.danmuSetting.FunnyRobot.Enabled)
			//	{
			//		string text = Resource1.humor;
			//		if (danmuType_0 == DanmuType.Gift)
			//		{
			//			text = Resource1.thks_gift;
			//		}
			//		List<string> list = (from x in text.Split('\n')
			//							 where x.Trim() != ""
			//							 select x).ToList();
			//		if (list.Count > 0)
			//		{
			//			return list[Common.rnd.Next(0, list.Count)];
			//		}
			//		return "";
			//	}
			return "";
		}
	public static string FormatNumbers(string input)
		{
			_ = new string[10] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
			for (int i = 0; i < 10; i++)
			{
				input = input.Replace(i.ToString(), ".");
			}
			return input;
		}

		public static string NumbersToCN(string input)
		{
			string[] array = new string[10] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
			for (int i = 0; i < 10; i++)
			{
				input = input.Replace(i.ToString(), array[i]);
			}
			return input;
		}
		public static async Task smethod_0(string s, bool stopOther = false, EventHandler<SpeakData> speakStateHandler = null, int level = 0)
		{
			SpeakData spData = new SpeakData
			{
				SpeakText = s,
				SpeakState = SpeakState.None
			};
			Stream stream = await GetVoiceStream(s);
			spData.SpeakState = SpeakState.Start;
			speakStateHandler?.Invoke(null, spData);
			if (stream != null)
			{
				Isbusy = true;
				if (!stopOther)
				{
					await SoundPlayer.PlaySteam(stream, isWav: false, level);
				}
				else
				{
					await SoundPlayer.PlaySteamMaster(stream, isWav: false, level);
				}
				spData.SpeakState = SpeakState.Complete;
				speakStateHandler?.Invoke(null, spData);
				Isbusy = false;
			}
			else
			{
				spData.SpeakState = SpeakState.Complete;
				speakStateHandler?.Invoke(null, spData);
			}
		}
		public static async Task TestCustVoice(string custUrl, string s, bool stopOther = false)
		{
			Stream stream = await SoundPlayer.Text2Voice_Cust(s, custUrl);
			if (stream != null)
			{
				if (stopOther)
				{
					await SoundPlayer.PlaySteamMaster(stream);
				}
				else
				{
					await SoundPlayer.PlaySteam(stream);
				}
			}
		}
		public static async Task PlayStreamVoice(Stream stream, string txt, bool stopOther = false, EventHandler<SpeakData> speakStateHandler = null)
		{
			SpeakData spData = new SpeakData
			{
				SpeakText = txt,
				SpeakState = SpeakState.None
			};
			if (stream == null)
			{
				spData.SpeakState = SpeakState.Complete;
				speakStateHandler?.Invoke(null, spData);
				return;
			}
			Isbusy = true;
			spData.SpeakState = SpeakState.Start;
			speakStateHandler?.Invoke(null, spData);
			if (stopOther)
			{
				await SoundPlayer.PlaySteamMaster(stream);
			}
			else
			{
				await SoundPlayer.PlaySteam(stream);
			}
			spData.SpeakState = SpeakState.Complete;
			speakStateHandler?.Invoke(null, spData);
			Isbusy = false;
		}
		public static async Task<Stream> GetVoiceStream(string s)
		{
			Stream stream = null;
			try
			{
				if (Common.danmuSetting.VoiceDanmu.Voice.Platform != VoicePlatform.Xunfei)
				{
					if (Common.danmuSetting.VoiceDanmu.Voice.Platform != VoicePlatform.Baidu)
					{
						if (Common.danmuSetting.VoiceDanmu.Voice.Platform != VoicePlatform.Dui)
						{
							if (Common.danmuSetting.VoiceDanmu.Voice.Platform != 0)
							{
								if (Common.danmuSetting.VoiceDanmu.Voice.Platform != VoicePlatform.MS)
								{
									if (Common.danmuSetting.VoiceDanmu.Voice.Platform == VoicePlatform.Cust)
									{
										stream = await SoundPlayer.Text2Voice_Cust(s);
									}
								}
								else
								{
									stream = await SoundPlayer.Text2Voice_Microsoft(s);
								}
							}
							else
							{
								stream = await SoundPlayer.Text2Voice_Ali(s);
							}
						}
						else
						{
							stream = await SoundPlayer.Text2Voice_Dui(s);
						}
					}
					else
					{
						stream = await SoundPlayer.Text2Voice_Baidu(s);
					}
				}
				else
				{
					stream = await SoundPlayer.Text2Voice_Xunfei(s);
				}
			}
			catch
			{
			}
			return stream;
		}
		public static string FormatOptContent(string input, string fromUser, string giftName, int giftCount, bool enabledFunRobot = false)
		{
			input = input.Replace("{用户}", fromUser ?? "");
			input = input.Replace("{用户名}", fromUser ?? "");
			input = input.Replace("{昵称}", fromUser ?? "");
			input = input.Replace("{个}", giftCount.ToString() ?? "");
			input = input.Replace("{数量}", giftCount.ToString() ?? "");
			input = input.Replace("{礼物个数}", giftCount.ToString() ?? "");
			input = input.Replace("{礼物数}", giftCount.ToString() ?? "");
			input = input.Replace("{礼物数量}", giftCount.ToString() ?? "");
			input = input.Replace("{礼物}", giftName ?? "");
			input = input.Replace("{礼物名称}", giftName ?? "");
			input = input.Replace("{礼物名}", giftName);
			input = input.Replace("{当前时间}", DateTime.Now.Hour + "点" + DateTime.Now.Minute + "分");
			input = input.Replace("{直播间人数}", Common.RoomData.OnlineUser);
			List<string> list = (from x in input.Split('\n')
								 where x.Trim() != ""
								 select x).ToList();
			if (list.Count > 0)
			{
				return list[Common.rnd.Next(0, list.Count)];
			}
			return "";
		}
		static VoiceHelper()
		{
			Isbusy = false;
			CanSpeak = true;
			_isForbiddenWords = false;
			_isFakeDanmu = false;
			_danmuList = new List<DanmuData>();
		}
	}

}
