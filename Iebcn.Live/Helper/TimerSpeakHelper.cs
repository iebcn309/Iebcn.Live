using Iebcn.Live.Controls;

namespace Iebcn.Live.Helper
{
	public sealed class TimerSpeakHelper
	{
		private static int Kmu;

		private static int dmL;

		private static DateTime ym1;

		private static int Amm;

		private static TimerSpeakWind kmr;

		public static void ShowWindow()
		{
			if (kmr == null || kmr.IsClosed)
			{
				kmr = new TimerSpeakWind();
			}
			kmr.Show();
			kmr.Activate();
		}

		private static async Task Pma()
		{
			try
			{
				while (!Common.AppClosed)
				{
					if (!Common.danmuSetting.TimerSpeak.IsRangeTimeEnabled)
					{
						await Task.Delay(300);
						continue;
					}
					if (Common.danmuSetting.TimerSpeak.RangeTimeContent.Trim() == "")
					{
						await Task.Delay(300);
						continue;
					}
					if (Common.danmuSetting.TimerSpeak.RangeTimeIntervalMinMinutes > Common.danmuSetting.TimerSpeak.RangeTimeIntervalMaxMinutes)
					{
						Common.danmuSetting.TimerSpeak.RangeTimeIntervalMinMinutes = Common.danmuSetting.TimerSpeak.RangeTimeIntervalMaxMinutes;
					}
					int num = Common.rnd.Next(Common.danmuSetting.TimerSpeak.RangeTimeIntervalMinMinutes, Common.danmuSetting.TimerSpeak.RangeTimeIntervalMaxMinutes);
					if (ym1.AddMinutes(num) <= DateTime.Now)
					{
						ym1 = DateTime.Now;
						await VoiceHelper.smethod_0(ymP(), stopOther: true);
					}
					await Task.Delay(300);
				}
			}
			catch
			{
			}
		}

		private static async Task amN()
		{
			try
			{
				while (!Common.AppClosed)
				{
					if (Common.danmuSetting.TimerSpeak.IsHourTimeEnabled)
					{
						if (Common.danmuSetting.TimerSpeak.HourTimeContent.Trim() == "")
						{
							await Task.Delay(300);
							continue;
						}
						if (DateTime.Now.Minute == 0 && Amm != DateTime.Now.Hour)
						{
							Amm = DateTime.Now.Hour;
							await VoiceHelper.smethod_0(ymP(bool_0: false), stopOther: true);
						}
						await Task.Delay(300);
					}
					else
					{
						await Task.Delay(300);
					}
				}
			}
			catch
			{
			}
		}

		private static string ymP(bool bool_0 = true)
		{
			List<string> list = null;
			string text = "";
			if (bool_0)
			{
				list = (from x in Common.danmuSetting.TimerSpeak.RangeTimeContent.Trim().Split('\n')
						where x.Trim() != ""
						select x).ToList();
				if (list.Count <= 0)
				{
					return "";
				}
				if (Common.danmuSetting.TimerSpeak.IsRangeTimeRandomSpeak)
				{
					text = list[Common.rnd.Next(0, list.Count)];
				}
				else
				{
					if (Kmu >= list.Count)
					{
						Kmu = 0;
					}
					text = list[Kmu];
					Kmu++;
				}
			}
			else
			{
				list = (from x in Common.danmuSetting.TimerSpeak.HourTimeContent.Trim().Split('\n')
						where x.Trim() != ""
						select x).ToList();
				if (list.Count <= 0)
				{
					return "";
				}
				if (Common.danmuSetting.TimerSpeak.IsHourTimeRandomSpeak)
				{
					text = list[Common.rnd.Next(0, list.Count)];
				}
				else
				{
					if (dmL >= list.Count)
					{
						dmL = 0;
					}
					text = list[dmL];
					dmL++;
				}
			}
			return FormatContent(text);
		}

		public static string FormatContent(string content)
		{
			content = ((DateTime.Now.Minute == 0) ? content.Replace("{当前时间}", DateTime.Now.Hour + "点整") : content.Replace("{当前时间}", DateTime.Now.Hour + "点" + DateTime.Now.Minute + "分"));
			content = content.Replace("{直播间人数}", Common.RoomData.OnlineUser ?? "");
			string text = "榜一大哥";
			string text2 = "榜二大哥";
			string text3 = "榜三大哥";
			int count = RoomRankHelper.OnlineRankList.Count;
			if (count >= 1)
			{
				text = RoomRankHelper.OnlineRankList[0].UserNick;
			}
			if (count >= 2)
			{
				text2 = RoomRankHelper.OnlineRankList[1].UserNick;
			}
			if (count >= 3)
			{
				text3 = RoomRankHelper.OnlineRankList[2].UserNick;
			}
			content = content.Replace("{榜1昵称}", text ?? "");
			content = content.Replace("{榜2昵称}", text2 ?? "");
			content = content.Replace("{榜3昵称}", text3 ?? "");
			return content;
		}
		public static async Task Start()
		{
			if (Common.VIPLevel >= 1)
			{
				await Pma();
				await amN();
			}
		}

		public static async Task TestSpeak(bool isRangeTimer)
		{
			await VoiceHelper.smethod_0(ymP(isRangeTimer), stopOther: true);
		}

		static TimerSpeakHelper()
		{
			Kmu = 0;
			dmL = 0;
			ym1 = DateTime.Now;
			Amm = 0;
			kmr = null;
		}
	}

}
