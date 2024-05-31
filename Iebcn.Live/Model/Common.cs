using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Iebcn.Live
{
	//存储和管理一些公共的数据和配置信息。 
	public partial class Common
	{
		//VIP 等级
		public static int VIPLevel = 2;
		//存储 VIP 等级与对应的等级名称
		private static Dictionary<int, string> UHw;
		//当前环境文件夹
		public static EnvFolder CurrEnvFolder_SendDanmu;
		public static bool IsAgent;
		//启动应用程序的计数
		public static int StartAppCount;

		public static DanmuData latestDanmudata;
		//应用程序退出标志
		public static bool AppExitFlag;

		public const string Str_Random = "Random";

		public const string Str_RndPicPath = "Pack://application:,,,/Assets/rnd.jpg";

		public const string Str_DemoUserHeadPic = "Pack://application:,,,/Assets/sampleHead1.jpg";

		public const string Img_Shopcar = "Pack://application:,,,/Assets/shopcar.png";

		public const string Img_musicCover = "Pack://application:,,,/Assets/musicCover.jpg";
		//上次互动时间
		public static DateTime lastIneractTime;
		//应用程序关闭标志
		public static bool AppClosed;
		//语音列表
		public static List<Voice> VoiceList;
		//禁止的词语
		public static string ForbiddenWords;
		//当前房间 ID
		public static string CurrRoomId
		{
			get
			{
				Match match = null;
				switch (CurrLivePlatform)
				{
					case LivePlatform.Douyin:
                        match = new Regex("live.douyin.com/[a-zA-Z0-9_]{5,20}").Match(Common.CurrLiveUrl);
                        if (match.Success)
                        {
                            _currRoomId = match.Value.Replace("live.douyin.com/", "");
                        }
                        break;
					case LivePlatform.KuaiShou:
                        match = new Regex("https://live.kuaishou.com/u/\\w+").Match(Common.CurrLiveUrl);
                        if (match.Success)
                        {
                            _currRoomId = match.Value.Replace("https://live.kuaishou.com/u/", "");
                        }
						break;
                }
				return _currRoomId;
			}
		}
		//当前直播 URL
		public static string CurrLiveUrl;
        //当前直播 URL
        public static LivePlatform CurrLivePlatform;
        ////主窗口
        public static MainWindow mainWindow;
		////音乐窗口
		public static MusicWindow musicWindow;
		////机器人 Eva
		//public static RobotEva robotEva;
		////投票窗口
		//public static VoteWindow voteWindow;
		//达到每日最大限制时是否继续
		public static bool continueWhenReachDailyMaxLimit;
		//每日最大限制发送计数。 
		public static int dailyMaxLimitSendCount;
		//随机数生成器
		public static Random rnd;
		//是否为 VIP 用户
		public static bool isVIP = true;

		public static DateTime dateTime_0;
		//弹幕设置
		public static DanmuSetting danmuSetting;
		public static RoomData RoomData;

		//关键用户弹幕数据集合
		public static ObservableCollection<DanmuData> KeyUserDanmuData;
		//存档弹幕数据集合
		public static ObservableCollection<DanmuData> ArchiveDanmuData;
		//用户音乐列表
		public static ObservableCollection<UserMusic> UserMusicList;
		//用户音乐列表存档
		public static ObservableCollection<UserMusic> UserMusicListArchive;
		public static List<DanmuData> CacheData;
		//需要 VIP 1 的提示信息
		public static string Msg_NeedVip1;
		//需要 VIP 2 的提示信息
		public static string Msg_NeedVip2;
		private static string _currRoomId;

		public static string VipLevelTitle
		{
			get
			{
				if (!UHw.Keys.Contains(VIPLevel))
				{
					return "未知版";
				}
				return UHw[VIPLevel];
			}
		}
		public static bool Win2DWebHasInitialized { get; set; }
		public static VoteWindow voteWindow { get; set; }

		static Common()
		{

			VIPLevel = 2;
			UHw = new Dictionary<int, string>
			{
				{ 0, "普通版" },
				{ 1, "高级版" },
				{ 2, "互动版" }
			};
			IsAgent = false;
			StartAppCount = 0;
			latestDanmudata = null;
			AppExitFlag = false;
			lastIneractTime = DateTime.Now;
			AppClosed = false;
			VoiceList = new List<Voice>();
			ForbiddenWords = "";
			CurrLiveUrl = "";
			continueWhenReachDailyMaxLimit = false;
			dailyMaxLimitSendCount = 100;
			rnd = new Random();
			isVIP = false;
			dateTime_0 = DateTime.Now;
			danmuSetting = new DanmuSetting();
			RoomData = new RoomData();
			KeyUserDanmuData = new ObservableCollection<DanmuData>();
			ArchiveDanmuData = new ObservableCollection<DanmuData>();
			UserMusicList = new ObservableCollection<UserMusic>();
			UserMusicListArchive = new ObservableCollection<UserMusic>();
			CacheData = new List<DanmuData>();
			Msg_NeedVip1 = "哎呀，您是普通版，【普通版】用户不能使用此功能！请开通高级版后操作！（可去主菜单【续费】按钮升级[高级版]）";
			Msg_NeedVip2 = "哎呀这是【互动版】功能，请开通互动版后操作！（可去主菜单【续费】按钮升级[互动版]）";
		}
	}
}
