using Iebcn.Live.Controls;

namespace Iebcn.Live.Helper
{
	public class FakeDanmuHelper
	{
		private static string[] iGB;

		private static int jGI;

		private static Random eGE;

		private static FakeDanmuWindow XGl;

		private static string lGz;

		private static string ros;

		public static void ShowWindow()
		{
			if (XGl == null || XGl.IsClosed)
			{
				XGl = new FakeDanmuWindow();
			}
			XGl.Show();
			XGl.Activate();
		}

		public static void Start()
		{
			StartChat();
			zGo();
			zGv();
			TGX();
			jGy();
		}
		public static async void StartChat()
		{
			while (true)
			{
				try
				{
					if (Common.AppClosed)
					{
						break;
					}
					await Task.Delay(300);
					if (!Common.danmuSetting.FakeDanmu.ChatEnabled)
					{
						await Task.Delay(300);
						continue;
					}
					List<string> list = (from x in Common.danmuSetting.FakeDanmu.Content.Split('\n')
										 where x.Trim() != ""
										 select x).ToList();
					if (list.Count > 0)
					{
						if (jGI >= list.Count)
						{
							jGI = 0;
						}
						string text = list[jGI].Trim();
						if (!(text == ""))
						{
							string text2 = PG5();
							Common.mainWindow.WebBrowserHelper_DanmuDataChanged(null, new DanmuData
							{
								Type = DanmuType.Chat,
								UserNick = text2,
								Msg = text2 + "：" + text,
								Timestamp = DateTime.Now,
								NewImIconWithLevel = CGj(),
								UserHeadPic = gGV()
							});
							jGI++;
							int num = eGE.Next((int)Common.danmuSetting.FakeDanmu.MinIntrevalSecondsChat, (int)Common.danmuSetting.FakeDanmu.MaxIntrevalSecondsChat);
							await Task.Delay(1000 * num);
						}
					}
				}
				catch
				{
					break;
				}
			}
		}
		private static async void zGo()
		{
			while (true)
			{
				try
				{
					if (Common.AppClosed)
					{
						break;
					}
					await Task.Delay(300);
					if (!Common.danmuSetting.FakeDanmu.GiftEnabled)
					{
						await Task.Delay(300);
						continue;
					}
					string text = PG5();
					string text2 = iGB[Common.rnd.Next(0, 4)];
					int giftCount = Common.rnd.Next(1, Common.danmuSetting.FakeDanmu.GiftCountMax + 1);
					string gitUrl = RenqiHelper.GetGitUrl(text2);
					Common.mainWindow.WebBrowserHelper_DanmuDataChanged(null, new DanmuData
					{
						Type = DanmuType.Gift,
						UserNick = text,
						GiftCount = giftCount,
						GiftName = text2,
						GiftUrl = gitUrl,
						Msg = text + "：送" + giftCount + "个" + text2,
						Timestamp = DateTime.Now,
						NewImIconWithLevel = CGj(),
						UserHeadPic = gGV()
					});
					int num = eGE.Next((int)Common.danmuSetting.FakeDanmu.MinIntrevalSecondsGift, (int)Common.danmuSetting.FakeDanmu.MaxIntrevalSecondsGift);
					await Task.Delay(1000 * num);
				}
				catch
				{
					break;
				}
			}
		}

		private static async void zGv()
		{
			while (true)
			{
				try
				{
					if (Common.AppClosed)
					{
						break;
					}
					await Task.Delay(300);
					if (!Common.danmuSetting.FakeDanmu.EnterRoomEnabled)
					{
						await Task.Delay(300);
						continue;
					}
					string text = PG5();
					Common.mainWindow.WebBrowserHelper_DanmuDataChanged(null, new DanmuData
					{
						Type = DanmuType.EnterRoom,
						UserNick = text,
						Msg = text + "：来了",
						Timestamp = DateTime.Now,
						NewImIconWithLevel = CGj(),
						UserHeadPic = gGV()
					});
					int num = eGE.Next((int)Common.danmuSetting.FakeDanmu.MinIntrevalSecondsEnterRoom, (int)Common.danmuSetting.FakeDanmu.MaxIntrevalSecondsEnterRoom);
					await Task.Delay(1000 * num);
				}
				catch
				{
					break;
				}
			}
		}

		private static async void TGX()
		{
			while (true)
			{
				try
				{
					if (Common.AppClosed)
					{
						break;
					}
					await Task.Delay(300);
					if (Common.danmuSetting.FakeDanmu.LikeEnabled)
					{
						string text = PG5();
						Common.mainWindow.WebBrowserHelper_DanmuDataChanged(null, new DanmuData
						{
							Type = DanmuType.Like,
							UserNick = text,
							Msg = text + "：点赞",
							Timestamp = DateTime.Now,
							NewImIconWithLevel = CGj(),
							UserHeadPic = gGV()
						});
						int num = eGE.Next((int)Common.danmuSetting.FakeDanmu.MinIntrevalSecondsLike, (int)Common.danmuSetting.FakeDanmu.MaxIntrevalSecondsLike);
						await Task.Delay(1000 * num);
					}
					else
					{
						await Task.Delay(300);
					}
				}
				catch
				{
					break;
				}
			}
		}

		private static async void jGy()
		{
			while (true)
			{
				try
				{
					if (Common.AppClosed)
					{
						break;
					}
					await Task.Delay(300);
					if (!Common.danmuSetting.FakeDanmu.FollowEnabled)
					{
						await Task.Delay(300);
						continue;
					}
					string text = PG5();
					Common.mainWindow.WebBrowserHelper_DanmuDataChanged(null, new DanmuData
					{
						Type = DanmuType.Follow,
						UserNick = text,
						Msg = text + "：关注了主播",
						Timestamp = DateTime.Now,
						NewImIconWithLevel = CGj(),
						UserHeadPic = gGV()
					});
					int num = eGE.Next((int)Common.danmuSetting.FakeDanmu.MinIntrevalSecondsFollow, (int)Common.danmuSetting.FakeDanmu.MaxIntrevalSecondsFollow);
					await Task.Delay(1000 * num);
				}
				catch
				{
					break;
				}
			}
		}

		private static string PG5()
		{
			string[] array = lGz.Split("|".ToCharArray());
			return array[eGE.Next(0, array.Length)].Trim();
		}

		private static string gGV()
		{
			try
			{
				List<string> list = (from x in ros.Split("\n".ToCharArray()).ToList()
									 where x.Trim().Contains("|")
									 select x).ToList();
				return list[eGE.Next(0, list.Count)].Split('|')[1].Trim();
			}
			catch
			{
				return "";
			}
		}

		private static string CGj()
		{
			return "https://p3-webcast.douyinpic.com/img/webcast/user_grade_level_v5_" + Common.rnd.Next(1, 61) + ".png~tplv-obj.image";
		}

		static FakeDanmuHelper()
		{
			iGB = new string[6] { "小心心", "玫瑰", "大啤酒", "入团卡", "棒棒糖", "嘉年花" };
			jGI = 0;
			eGE = new Random();
			XGl = null;
			lGz = Resource1.UserNicks;
			ros = Resource1.Users;
		}
	}
}
