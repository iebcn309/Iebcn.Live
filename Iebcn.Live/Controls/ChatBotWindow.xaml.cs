using Iebcn.Live.Helper;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;


namespace Iebcn.Live.Controls
{
	/// <summary>
	/// ChatBotWindow.xaml 的交互逻辑
	/// </summary>
	public partial class ChatBotWindow : Window, IComponentConnector
	{
		public class SpeakCustTextInfo
		{
			[CompilerGenerated]
			private Stream fBn;

			[CompilerGenerated]
			private Stream LB4;

			[CompilerGenerated]
			private Stream zBf;

			[CompilerGenerated]
			private double yBF;

			[CompilerGenerated]
			private string HBw = "";

			[CompilerGenerated]
			private string RBC = "";

			[CompilerGenerated]
			private string WB3 = "";

			[CompilerGenerated]
			private DanmuType QBO;

			public Stream StreamWelcome
			{
				[CompilerGenerated]
				get
				{
					return fBn;
				}
				[CompilerGenerated]
				set
				{
					fBn = value;
				}
			}

			public Stream StreamReply
			{
				[CompilerGenerated]
				get
				{
					return LB4;
				}
				[CompilerGenerated]
				set
				{
					LB4 = value;
				}
			}

			public Stream StreamCustText
			{
				[CompilerGenerated]
				get
				{
					return zBf;
				}
				[CompilerGenerated]
				set
				{
					zBf = value;
				}
			}

			public double DelaySeonds
			{
				[CompilerGenerated]
				get
				{
					return yBF;
				}
				[CompilerGenerated]
				set
				{
					yBF = value;
				}
			}

			public string WelcomeText
			{
				[CompilerGenerated]
				get
				{
					return HBw;
				}
				[CompilerGenerated]
				set
				{
					HBw = value;
				}
			}

			public string ReplyText
			{
				[CompilerGenerated]
				get
				{
					return RBC;
				}
				[CompilerGenerated]
				set
				{
					RBC = value;
				}
			}

			public string CustText
			{
				[CompilerGenerated]
				get
				{
					return WB3;
				}
				[CompilerGenerated]
				set
				{
					WB3 = value;
				}
			}

			public DanmuType DanmuType
			{
				[CompilerGenerated]
				get
				{
					return QBO;
				}
				[CompilerGenerated]
				set
				{
					QBO = value;
				}
			}

			internal static void Kd0f()
			{
			}

			internal static void Ld0F()
			{
			}
		}

		private ChatBotAnchor xSI=new ChatBotAnchor();

		private List<int> JSE;

		private int fSl;

		private int aSz;

		private int pZs;

		private ChatBot NZx;

		private Voice SZd = new Voice
		{
			Pitch = 30,
			Platform = VoicePlatform.Xunfei,
			SpeakerName = "小忠",
			SpeakerValue = "x3_xiaozhong",
			Speed = 85,
			Volume = 100
		};

		private int RZH = 3;
		private string KZQ = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets","ChatBot");

		private string QZe = "";

		private string sZq = "";

		[CompilerGenerated]
		private EventHandler<SpeakData> zZn;

		private SpeakState GZ4 = SpeakState.Complete;
		private bool JZF;

		private ChatBotSettingWindow LZw;

		public bool IsClosed;

		private List<SpeakCustTextInfo> lZC = new List<SpeakCustTextInfo>();

		public ChatBotWindow()
		{
			InitializeComponent();
			JSE = new List<int>();
			base.DataContext = (NZx = Common.danmuSetting.ChatBot);
			BS3();
			uSU();
			SetRole(NZx.RoleId);
			base.MouseLeftButtonDown += hSO;
			base.Loaded += mSC;
			mdIdle.Opacity = 1.0;
			mdTalk.Opacity = 0.0;
			mdIdle.Volume = 0.0;
			mdTalk.Volume = 0.0;
			MediaElement mediaElement = mdTalk;
			mdTalk.IsMuted = true;
			mediaElement.IsMuted = true;
			mdTalk.MediaEnded += iSY;
			mdIdle.MediaEnded += JS0;
			mdGiftAction.MediaEnded += GSw;
			mdGiftAction.MediaFailed += rSF;
			ISV(NSR);
			ProcessBotReply();
			CSN();
			zSm();
		}

		[SpecialName]
		[CompilerGenerated]
		private void ISV(EventHandler<SpeakData> value)
		{
			EventHandler<SpeakData> eventHandler = zZn;
			EventHandler<SpeakData> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<SpeakData> value2 = (EventHandler<SpeakData>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref zZn, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		private void rSF(object sender, ExceptionRoutedEventArgs e)
		{
			JZF = false;
			mdGiftAction.Visibility = Visibility.Collapsed;
			MediaElement mediaElement = mdIdle;
			mdTalk.Visibility = Visibility.Visible;
			mediaElement.Visibility = Visibility.Visible;
		}

		private void GSw(object sender, RoutedEventArgs e)
		{
			JZF = false;
			mdGiftAction.Visibility = Visibility.Collapsed;
			MediaElement mediaElement = mdIdle;
			mdTalk.Visibility = Visibility.Visible;
			mediaElement.Visibility = Visibility.Visible;
		}

		private void mSC(object sender, RoutedEventArgs e)
		{
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				Util.SaveDanmuSetting();
				IsClosed = true;
				ChatBotHelper.ClearAllCache();
				if (xSI != null && !xSI.IsClosed)
				{
					xSI.Close();
				}
			}
			catch (Exception ex)
			{
				AppLog.AddLog(GetType()?.ToString() + ex.Message);
			}
		}

		private void BS3()
		{
			if (NZx.Enabled)
			{
				Common.danmuSetting.VoiceDanmu.Enabled = false;
				AutoReply autoReply = Common.danmuSetting.AutoReply;
				Common.danmuSetting.AutoReply.ContentReplyEnabled = false;
				autoReply.ContentReplyEnabled = false;
				Common.danmuSetting.Silence.Enabled = false;
				Common.danmuSetting.TimerSpeak.IsRangeTimeEnabled = false;
				Common.danmuSetting.TimerSpeak.IsHourTimeEnabled = false;
			}
		}

		public void UpdateWindowSize()
		{
			double num2 = (base.MaxWidth = NZx.WindowWidth);
			double width = (base.MinWidth = num2);
			base.Width = width;
			num2 = (base.MaxHeight = NZx.WindowHeight);
			width = (base.MinHeight = num2);
			base.Height = width;
			UpdateLayout();
			InvalidateVisual();
		}

		private void hSO(object sender, MouseButtonEventArgs e)
		{
			if (e.Source.Equals(chatBotMsgCtl))
			{
				return;
			}
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void uSU()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			for (int i = 1; i <= 100; i++)
			{
				string path = KZQ + "\\Roles\\" + i + "\\cover.png";
				if (File.Exists(KZQ + "\\Roles\\" + i + "\\talk.mp4") && File.Exists(KZQ + "\\Roles\\" + i + "\\idle.mp4") && File.Exists(path))
				{
					JSE.Add(i);
				}
			}
		}

		public void SetRole(int roleId)
		{
			try
			{
				RZH = roleId;
				QZe = KZQ + "\\Roles\\" + roleId + "\\talk.mp4";
				sZq = KZQ + "\\Roles\\" + roleId + "\\idle.mp4";
				mdTalk.Source = new Uri(QZe, UriKind.RelativeOrAbsolute);
				mdTalk.Play();
				mdIdle.Source = new Uri(sZq, UriKind.RelativeOrAbsolute);
				mdIdle.Play();
			}
			catch
			{
			}
		}

		private void ASW()
		{
			fSl++;
			if (fSl >= JSE.Count)
			{
				fSl = 0;
			}
			SetRole(JSE[fSl]);
		}

		public async void ProcessBotReply()
		{
			while (!IsClosed)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (!NZx.Enabled || ChatBotHelper.CacheChatDanmuList.Count <= 0)
						{
							goto end_IL_0074;
						}
						DanmuData data = ChatBotHelper.CacheChatDanmuList.LastOrDefault();
						ChatBotHelper.CacheChatDanmuList.Remove(data);
						if (NZx.KeyWordReplyEnabled && LSc(data.PureMsg) != "")
						{
							goto end_IL_0074;
						}
						if (!NZx.ReplySourceGPT)
						{
							if (NZx.ReplyFromChinaAI)
							{
								//sGa.tGu(data);
							}
							else if (NZx.ReplySourceBot)
							{
								string text = await ChatBotHelper.GetHttpReplyAsync(data.PureMsg);
								if (text != "")
								{
									ChatBotHelper.BotResultList.Add(new BotResult
									{
										DanmuType = DanmuType.Chat,
										IsChat = true,
										Query = data.UserNickCut + ":  " + data.PureMsg,
										Result = text
									});
								}
							}
							else if (NZx.ReplySourceCust)
							{
								string text2 = await ChatBotHelper.GetCustHttpReply(NZx.ReplySourceCustUrl + Uri.EscapeDataString(data.PureMsg));
								if (text2 != "")
								{
									if (text2.Length > 350)
									{
										text2 = text2.Substring(0, 350);
									}
									ChatBotHelper.BotResultList.Add(new BotResult
									{
										DanmuType = DanmuType.Chat,
										IsChat = true,
										Query = data.UserNickCut + ":  " + data.PureMsg,
										Result = text2
									});
								}
							}
						}
						else
						{
							new ChatBotService(data).StateCahanged += tSa;
						}
						goto end_IL_0044;
					end_IL_0074:;
					}
					catch
					{
						goto end_IL_0044;
					}
					num = 1;
				end_IL_0044:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(1000);
				Exception obj4 = obj;
				if (obj4 != null)
				{
					ExceptionDispatchInfo.Capture((obj4 as Exception) ?? throw obj4).Throw();
				}
				if (num == 1)
				{
				}
			}
		}

		private void tSa(object object_0, BotResult botResult_0)
		{
			if (botResult_0.OK)
			{
				ChatBotHelper.BotResultList.Add(botResult_0);
			}
		}

		private async void CSN()
		{
			bool flag = false;
			while (!IsClosed)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (!flag && NZx.Enabled)
						{
							Common.danmuSetting.VoiceDanmu.Voice = Common.danmuSetting.ChatBot.Voice;
							if (!JZF && GZ4 == SpeakState.Complete)
							{
								await uSP();
								await qSt();
								await xSL();
								if (NZx.ChatModeEnabled)
								{
									int i = 0;
									while (true)
									{
										if (i < Common.rnd.Next(1, 4))
										{
											if (IsClosed)
											{
												break;
											}
											await qSt();
											await uSP();
											await xSL();
											await lSZ();
											i++;
											continue;
										}
										await FSS();
										goto IL_0518;
									}
									goto IL_0529;
								}
								NZx.CustTextModeEnabled = true;
								await RSA();
								goto IL_0518;
							}
						}
						goto end_IL_0078;
					IL_0518:
						await tSu();
						goto end_IL_0048;
					end_IL_0078:;
					}
					catch
					{
						goto end_IL_0048;
					}
					num = 1;
					goto end_IL_0048;
				IL_0529:
					num = 2;
				end_IL_0048:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(300);
				flag = false;
				Exception obj4 = obj;
				if (obj4 != null)
				{
					ExceptionDispatchInfo.Capture((obj4 as Exception) ?? throw obj4).Throw();
				}
				int num2 = num;
				if (num2 != 1 && num2 == 2)
				{
					break;
				}
			}
		}

		private async Task uSP()
		{
			if (ChatBotHelper.AnchorSpeakList.Count > 0)
			{
				string text = ChatBotHelper.AnchorSpeakList[0];
				ChatBotHelper.AnchorSpeakList.RemoveAt(0);
				BotResult botResult = new BotResult
				{
					IsChat = false,
					Query = "",
					Result = text
				};
				chatBotMsgCtl.AddData(botResult);
				await VoiceHelper.smethod_0(text, stopOther: true, zZn);
			}
		}

		private async Task tSu()
		{
			if (IsClosed || !NZx.Enabled || !NZx.SilenceTalkEnabled || GZ4 != SpeakState.Complete || Common.lastIneractTime.AddSeconds(NZx.SilenceSeconds) > DateTime.Now)
			{
				return;
			}
			List<string> list = (from x in NZx.SilenceTalkContent.Split('\n')
								 where x.Trim() != ""
								 select x).ToList();
			if (list.Count <= 0)
			{
				return;
			}
			string text;
			if (!NZx.RndReadSilenceText)
			{
				if (pZs >= list.Count)
				{
					pZs = 0;
				}
				text = list[pZs];
				pZs++;
			}
			else
			{
				text = list[Common.rnd.Next(0, list.Count)];
			}
			text = text.Replace("{当前时间}", DateTime.Now.ToString("h点m分s秒") ?? "");
			double delaySeconds = 0.0;
			try
			{
				Match match = new Regex("{延时(?<n>\\d+\\.*\\d*)秒}").Match(text);
				if (match.Success)
				{
					delaySeconds = double.Parse(match.Groups["n"].Value ?? "");
					text = text.Replace(match.Value, "");
				}
			}
			catch
			{
			}
			chatBotMsgCtl.AddData(new BotResult
			{
				DanmuType = DanmuType.Chat,
				IsChat = false,
				Query = "",
				Result = text
			});
			await VoiceHelper.smethod_0(text, stopOther: true, zZn);
			await Task.Delay((int)(delaySeconds * 1000.0));
			Common.lastIneractTime = DateTime.Now;
		}

		private async Task xSL()
		{
			if (GZ4 == SpeakState.Complete)
			{
				BotResult botResult = lS2();
				if (botResult != null)
				{
					Common.danmuSetting.VoiceDanmu.Voice = Common.danmuSetting.ChatBot.Voice;
					chatBotMsgCtl.AddData(botResult);
					await VoiceHelper.smethod_0(botResult.Result, stopOther: true, zZn);
				}
			}
		}

		private async void zSm()
		{
			Exception obj5;
			while (true)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (lZC.Count >= 2)
						{
							goto end_IL_005c;
						}
						BotResult botResult = HSb();
						if (botResult == null)
						{
							goto IL_0428;
						}
						SpeakCustTextInfo sCustTextInfo = new SpeakCustTextInfo();
						SpeakCustTextInfo speakCustTextInfo;
						if (botResult.Result.Contains("{欢迎感谢}"))
						{
							botResult.Result = botResult.Result.Replace("{欢迎感谢}", "");
							BotResult botResult2 = mS8();
							if (botResult2 != null)
							{
								sCustTextInfo.DanmuType = botResult2.DanmuType;
								sCustTextInfo.WelcomeText = botResult2.Result;
								speakCustTextInfo = sCustTextInfo;
								speakCustTextInfo.StreamWelcome = await VoiceHelper.GetVoiceStream(botResult2.Result);
							}
						}
						if (botResult.Result.Contains("{弹幕回复}"))
						{
							botResult.Result = botResult.Result.Replace("{弹幕回复}", "");
							BotResult botResult3 = nSi();
							if (botResult3 != null)
							{
								sCustTextInfo.ReplyText = botResult3.Result;
								speakCustTextInfo = sCustTextInfo;
								speakCustTextInfo.StreamReply = await VoiceHelper.GetVoiceStream(botResult3.Result);
							}
						}
						try
						{
							Match match = new Regex("{延时(?<n>\\d+\\.*\\d*)秒}").Match(botResult.Result);
							if (match.Success)
							{
								botResult.Result = botResult.Result.Replace(match.Value, "");
								double delaySeonds = double.Parse(match.Groups["n"].Value ?? "");
								sCustTextInfo.DelaySeonds = delaySeonds;
							}
						}
						catch
						{
						}
						sCustTextInfo.CustText = botResult.Result;
						speakCustTextInfo = sCustTextInfo;
						speakCustTextInfo.StreamCustText = await VoiceHelper.GetVoiceStream(botResult.Result);
						lZC.Add(sCustTextInfo);
						goto end_IL_0044;
					end_IL_005c:;
					}
					catch
					{
						goto end_IL_0044;
					}
					num = 1;
					goto end_IL_0044;
				IL_0428:
					num = 2;
				end_IL_0044:;
				}
				catch (Exception obj4)
				{
					obj = obj4;
				}
				await Task.Delay(300);
				obj5 = obj;
				if (obj5 != null)
				{
					Exception obj6 = obj5 as Exception;
					if (obj6 == null)
					{
						break;
					}
					ExceptionDispatchInfo.Capture(obj6).Throw();
				}
				int num2 = num;
				if (num2 != 1 && num2 == 2)
				{
					return;
				}
			}
			throw obj5;
		}

		private async Task RSA()
		{
			if (GZ4 == SpeakState.Complete && lZC.Count > 0)
			{
				SpeakCustTextInfo spInfo = lZC.First();
				lZC.Remove(spInfo);
				SpeakData spData = default(SpeakData);
				chatBotMsgCtl.SetQueryText("");
				GZ4 = SpeakState.Start;
				spData.SpeakText = spInfo.CustText;
				spData.SpeakState = SpeakState.Start;
				zZn?.Invoke(null, spData);
				await SoundPlayer.PlaySteamMaster(spInfo.StreamCustText);
				GZ4 = SpeakState.Complete;
				spData.SpeakState = SpeakState.Complete;
				zZn?.Invoke(null, spData);
				if (VSM(spInfo.DanmuType) && spInfo.StreamWelcome != null)
				{
					GZ4 = SpeakState.Start;
					spData.SpeakText = spInfo.WelcomeText;
					spData.SpeakState = SpeakState.Start;
					zZn?.Invoke(null, spData);
					await SoundPlayer.PlaySteamMaster(spInfo.StreamWelcome);
					GZ4 = SpeakState.Complete;
					spData.SpeakState = SpeakState.Complete;
					zZn?.Invoke(null, spData);
				}
				if (spInfo.StreamReply != null)
				{
					spData.SpeakText = spInfo.ReplyText;
					spData.SpeakState = SpeakState.Start;
					zZn?.Invoke(null, spData);
					GZ4 = SpeakState.Start;
					await SoundPlayer.PlaySteamMaster(spInfo.StreamReply);
					GZ4 = SpeakState.Complete;
					spData.SpeakState = SpeakState.Complete;
					zZn?.Invoke(null, spData);
				}
				await Task.Delay((int)(spInfo.DelaySeonds * 1000.0));
			}
		}

		private async Task FSS()
		{
			if (GZ4 == SpeakState.Complete && (NZx.OptTypes.GiftEnabled || NZx.OptTypes.EnterRoomEnabled || NZx.OptTypes.LikeEnabled || NZx.OptTypes.FollowEnabled))
			{
				BotResult botResult = mS8();
				if (botResult != null)
				{
					chatBotMsgCtl.AddData(botResult);
					await VoiceHelper.smethod_0(botResult.Result, stopOther: true, zZn);
				}
			}
		}

		private async Task lSZ()
		{
			if (GZ4 != SpeakState.Complete)
			{
				return;
			}
			BotResult botResult = nSi();
			if (botResult != null)
			{
				Task<Stream> task1 = null;
				if (NZx.ReadDanmuEnabled)
				{
					task1 = ((!NZx.ReadDanmuUseMan) ? VoiceHelper.GetVoiceStream(VoiceHelper.iG6(botResult.Query)) : SoundPlayer.Text2Voice_Xunfei(VoiceHelper.iG6(botResult.Query), SZd));
				}
				Task<Stream> task2 = VoiceHelper.GetVoiceStream(botResult.Result);
				if (task1 == null)
				{
					await Task.WhenAll<Stream>(task2);
				}
				else
				{
					await Task.WhenAll<Stream>(task1, task2);
				}
				chatBotMsgCtl.AddData(botResult);
				if (task1 != null)
				{
					GZ4 = SpeakState.Start;
					await SoundPlayer.PlaySteamMaster(task1.Result);
					GZ4 = SpeakState.Complete;
				}
				await VoiceHelper.PlayStreamVoice(task2.Result, botResult.Result, stopOther: true, zZn);
			}
		}

		private async Task qSt()
		{
			if (GZ4 != SpeakState.Complete || JZF)
			{
				return;
			}
			BotResult botResult = FSp();
			if (botResult == null)
			{
				return;
			}
			Common.danmuSetting.VoiceDanmu.Voice = Common.danmuSetting.ChatBot.Voice;
			chatBotMsgCtl.AddData(botResult);
			await VoiceHelper.smethod_0(botResult.Result, stopOther: true, zZn);
			if (!botResult.IsGift)
			{
				return;
			}
			string text = SSJ(botResult.GiftName);
			if (!(text != ""))
			{
				return;
			}
			if (!"换装,换人，换主播".Contains(text.Trim()))
			{
				if (text.Trim().ToLower().EndsWith(".mp4"))
				{
					text = sSD(text);
					await OSk(text);
				}
			}
			else
			{
				ASW();
				await VoiceHelper.smethod_0("换人了哦！", stopOther: true, zZn);
			}
		}

		private string sSD(string string_0)
		{
			List<string> list = (from x in string_0.Split('|')
								 where x.Trim().EndsWith(".mp4")
								 select x).ToList();
			if (list.Count <= 0)
			{
				return "";
			}
			return list[Common.rnd.Next(0, list.Count)];
		}

		private string LSc(string string_0)
		{
			string result = "";
			List<string> list = (from x in NZx.KeyWordReplyContent.Split('\n')
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
							string text2 = array[1].Trim();
							if (!string.IsNullOrEmpty(text2))
							{
								string[] array2 = text.Split('|');
								foreach (string text3 in array2)
								{
									if (!(text3.Trim() == "") && string_0.Contains(text3.Trim()))
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

		private async Task OSk(string string_0)
		{
			JZF = true;
			try
			{
				MediaElement mediaElement = mdIdle;
				mdTalk.Visibility = Visibility.Collapsed;
				mediaElement.Visibility = Visibility.Collapsed;
				mdGiftAction.Source = null;
				mdGiftAction.Source = new Uri(string_0.Trim(), UriKind.RelativeOrAbsolute);
				mdGiftAction.Play();
				mdGiftAction.Opacity = 1.0;
				mdGiftAction.Visibility = Visibility.Visible;
				mdGiftAction.UpdateLayout();
			}
			catch
			{
				mdGiftAction.Visibility = Visibility.Collapsed;
				JZF = false;
				return;
			}
			while (JZF)
			{
				await Task.Delay(1000);
			}
			base.Dispatcher.Invoke(delegate
			{
				mdGiftAction.Visibility = Visibility.Collapsed;
				MediaElement mediaElement2 = mdIdle;
				mdTalk.Visibility = Visibility.Visible;
				mediaElement2.Visibility = Visibility.Visible;
			});
		}

		public async void TestPlayGiftVideo()
		{
			if (JZF)
			{
				return;
			}
			List<string> list = (from x in NZx.GiftActionContent.Split('\n')
								 where x.ToLower().Trim().EndsWith(".mp4")
								 select x).ToList();
			if (list.Count <= 0)
			{
				return;
			}
			List<string> list2 = new List<string>();
			foreach (string item in list)
			{
				List<string> collection = (from x in item.Split('=')
										   where x.Trim().EndsWith(".mp4")
										   select x).ToList();
				list2.AddRange(collection);
			}
			if (list2.Count <= 0)
			{
				return;
			}
			List<string> list3 = new List<string>();
			foreach (string item2 in list2)
			{
				List<string> collection2 = (from x in item2.Split('|')
											where x.Trim().EndsWith(".mp4")
											select x).ToList();
				list3.AddRange(collection2);
			}
			string string_ = list3[Common.rnd.Next(0, list2.Count)].Trim();
			await OSk(string_);
		}

		private bool VSM(DanmuType danmuType_0)
		{
			bool result = false;
			if (NZx.OptTypes.GiftEnabled && danmuType_0 == DanmuType.Gift)
			{
				result = true;
			}
			if (NZx.OptTypes.EnterRoomEnabled && danmuType_0 == DanmuType.EnterRoom)
			{
				result = true;
			}
			if (NZx.OptTypes.LikeEnabled && danmuType_0 == DanmuType.Like)
			{
				result = true;
			}
			if (NZx.OptTypes.FollowEnabled && danmuType_0 == DanmuType.Follow)
			{
				result = true;
			}
			return result;
		}

		private BotResult nSi()
		{
			if (ChatBotHelper.BotResultList.Count > 0)
			{
				BotResult botResult = ChatBotHelper.BotResultList.LastOrDefault();
				if (botResult != null)
				{
					botResult.IsChat = true;
					ChatBotHelper.BotResultList.Remove(botResult);
					return botResult;
				}
				return null;
			}
			return null;
		}

		private BotResult lS2()
		{
			if (NZx.KeyWordReplyEnabled && ChatBotHelper.KeyReplyChatDanmuList.Count > 0)
			{
				string text = "";
				string query = "";
				DanmuData bBo = null;
				try
				{
					for (int i = 0; i < ChatBotHelper.KeyReplyChatDanmuList.Count; i++)
					{
						bBo = ChatBotHelper.KeyReplyChatDanmuList[i];
						text = LSc(bBo.PureMsg);
						if (text != "")
						{
							query = bBo.UserNickCut + ":" + bBo.PureMsg;
							break;
						}
					}
					if (!(text == ""))
					{
						ChatBotHelper.KeyReplyChatDanmuList.Remove(bBo);
						ChatBotHelper.CacheChatDanmuList.Remove(bBo);
						BotResult botResult = ChatBotHelper.BotResultList.FirstOrDefault((BotResult x) => x.Query == bBo.PureMsg);
						if (botResult != null)
						{
							ChatBotHelper.BotResultList.Remove(botResult);
						}
						return new BotResult
						{
							DanmuType = DanmuType.Chat,
							IsChat = false,
							Query = query,
							Result = text
						};
					}
					return null;
				}
				catch
				{
					return null;
				}
			}
			return null;
		}

		private BotResult mS8()
		{
			if (ChatBotHelper.CacheTksList.Count <= 0)
			{
				return null;
			}
			if (!NZx.OptTypes.GiftEnabled && !NZx.OptTypes.EnterRoomEnabled && !NZx.OptTypes.LikeEnabled && !NZx.OptTypes.FollowEnabled)
			{
				return null;
			}
			if (!NZx.OptTypes.EnterRoomEnabled)
			{
				ChatBotHelper.CacheTksList.Remove(ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.EnterRoom));
			}
			if (!NZx.OptTypes.GiftEnabled)
			{
				ChatBotHelper.CacheTksList.Remove(ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.Gift));
			}
			if (!NZx.OptTypes.LikeEnabled)
			{
				ChatBotHelper.CacheTksList.Remove(ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.Like));
			}
			if (!NZx.OptTypes.FollowEnabled)
			{
				ChatBotHelper.CacheTksList.Remove(ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.Follow));
			}
			BotResult botResult = null;
			try
			{
				if (NZx.OptTypes.GiftEnabled)
				{
					botResult = FSp();
				}
				if (botResult != null)
				{
					return botResult;
				}
				DanmuData danmuData = null;
				if (NZx.OptTypes.EnterRoomEnabled)
				{
					danmuData = ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.EnterRoom);
				}
				if (danmuData == null && NZx.OptTypes.LikeEnabled)
				{
					danmuData = ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.Like);
				}
				if (danmuData == null && NZx.OptTypes.FollowEnabled)
				{
					danmuData = ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.Follow);
				}
				if (danmuData != null)
				{
					ChatBotHelper.CacheTksList.Remove(danmuData);
					string tksFormtContent = ChatBotHelper.GetTksFormtContent(danmuData);
					if (tksFormtContent != "")
					{
						botResult = new BotResult
						{
							DanmuType = danmuData.Type,
							IsChat = false,
							IsGift = (danmuData.Type == DanmuType.Gift),
							GiftName = danmuData.GiftName,
							Query = "",
							Result = tksFormtContent
						};
					}
				}
			}
			catch
			{
				return null;
			}
			return botResult;
		}

		private BotResult FSp()
		{
			if (ChatBotHelper.CacheTksList.Count > 0)
			{
				try
				{
					DanmuData danmuData = ChatBotHelper.CacheTksList.LastOrDefault((DanmuData x) => x.Type == DanmuType.Gift);
					if (danmuData != null)
					{
						ChatBotHelper.CacheTksList.Remove(danmuData);
					}
					if (!NZx.OptTypes.GiftEnabled)
					{
						danmuData = null;
					}
					if (danmuData != null)
					{
						string tksFormtContent = ChatBotHelper.GetTksFormtContent(danmuData);
						if (!(tksFormtContent == ""))
						{
							return new BotResult
							{
								DanmuType = danmuData.Type,
								IsChat = false,
								IsGift = true,
								GiftName = danmuData.GiftName,
								Query = "",
								Result = tksFormtContent
							};
						}
						return null;
					}
					return null;
				}
				catch
				{
					return null;
				}
			}
			return null;
		}
		private BotResult HSb()
		{
			List<string> list = (from x in NZx.CustText.Split('\n')
								 where x.Trim() != ""
								 select x).ToList();
			if (list.Count > 0)
			{
				string text;
				if (NZx.RndReadCustText)
				{
					text = list[Common.rnd.Next(0, list.Count)];
				}
				else
				{
					if (aSz >= list.Count)
					{
						aSz = 0;
					}
					text = list[aSz];
					aSz++;
				}
				text = text.Replace("{当前时间}", DateTime.Now.ToString("h点m分s秒") ?? "");
				return new BotResult
				{
					DanmuType = DanmuType.Chat,
					IsChat = false,
					Query = "",
					Result = text
				};
			}
			return null;
		}

		private string SSJ(string string_0)
		{
			try
			{
				string text = (from x in NZx.GiftActionContent.Split('\n')
							   where x.Trim().Contains("=")
							   select x).ToList().FirstOrDefault((string x) => x.Trim().Split('=')[0].Trim() == string_0);
				if (text == null)
				{
					return "";
				}
				return text.Trim().Split('=')[1].Trim();
			}
			catch
			{
				return "";
			}
		}

		private void NSR(object object_0, SpeakData speakData_0)
		{
			GZ4 = speakData_0.SpeakState;
			if (GZ4 == SpeakState.Start)
			{
				chatBotMsgCtl.PrintBotReply(speakData_0.SpeakText);
				qSh();
			}
			if (GZ4 == SpeakState.Complete)
			{
				FSg();
			}
		}

		private void iSY(object sender, RoutedEventArgs e)
		{
			try
			{
				int num = Common.rnd.Next(1, (int)mdTalk.NaturalDuration.TimeSpan.TotalSeconds / 5);
				mdTalk.Position = TimeSpan.FromSeconds(num);
				mdTalk.Play();
			}
			catch
			{
			}
		}

		private void JS0(object sender, RoutedEventArgs e)
		{
			try
			{
				int num = Common.rnd.Next(1, (int)mdIdle.NaturalDuration.TimeSpan.TotalSeconds / 5);
				mdIdle.Position = TimeSpan.FromSeconds(num);
				mdIdle.Play();
			}
			catch
			{
			}
		}

		private void qSh()
		{
			mdIdle.Opacity = 0.0;
			mdTalk.Opacity = 1.0;
		}

		private void FSg()
		{
			mdIdle.Opacity = 1.0;
			mdTalk.Opacity = 0.0;
		}

		private void PS9(object sender, RoutedEventArgs e)
		{
			Close();
		}
 
 

		private void bSG(object sender, RoutedEventArgs e)
		{
			nSX();
		}

		private void ISo(object sender, RoutedEventArgs e)
		{
			nSX();
		}

		private void xSv(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void nSX()
		{
			if (LZw == null || LZw.IsClosed)
			{
				LZw = new ChatBotSettingWindow(this);
			}
			LZw.Show();
			LZw.Activate();
		}

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            gridBar.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            gridBar.Visibility = Visibility.Collapsed;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!e.Source.GetType().Equals(typeof(ChatBotMsgCtl)))
            {
                DragMove();
            }
        }
    }

}
