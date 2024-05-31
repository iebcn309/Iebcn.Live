namespace Iebcn.Live.ViewModel
{
	// 自动发送弹幕类
	public class AutoSendDanmu
	{
		// 是否启用自动发送弹幕
		public bool Enabled { get; set; } = true;
		// 自动发送弹幕的间隔时间（秒）
		public double IntrevalSeconds { get; set; } = 6.0;
		// 弹幕操作类型
		public OptTypes OptTypes { get; set; } = new OptTypes();
		// 弹幕内容
		public OptContent OptContent { get; set; } = new OptContent();
		// 是否启用自定义弹幕
		public bool CustEnabled { get; set; }
		// 自定义弹幕的间隔时间（秒）
		public double IntrevalSecondsCust { get; set; } = 8.0;
		// 自定义弹幕内容
		public string CustContent { get; set; } = "这个成品真的好！\r\n用过都说好！\r\n确实棒棒哒，效果杠杠的！\r\n这个太棒了！";
		// 环境文件夹
		public EnvFolder[] EnvFolders { get; set; } = new EnvFolder[15]
		{
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser1", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser2", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser3", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser4", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser5", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser6", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser7", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser8", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser9", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser10", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser11", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser12", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser13", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser14", inUse: false),
			new EnvFolder("Iebcn.Live.ControlsSendDanmu_Browser15", inUse: false)
		};
		public int FansClubLevelMin { get; set; }
		public int Int32_0 { get; set; }
		public double LimitDiamondCount { get; set; }
		public string KeyUserList { get; set; } = "";

		public bool WelcomeEnabled { get; set; }
		public bool Boolean_0 { get; set; }
		public int MaxCacheCount { get; set; }
		public bool CustRndSend { get; set; } = true;
		public bool QAAtUser { get; set; } = true;
		public int InterValSecondsMin { get; set; } = 10;

		public int InterValSecondsMax { get; set; } = 20;
		public int RefreshPageMinutes { get; set; } = 10;
		public int CustInterValSecondsMin { get; set; } = 10;
		public int CustInterValSecondsMax { get; set; } = 10;
		public string BlockNicks { get; set; } = "测试用户123|昵称abs123|GG12abc";
		public string String_0 { get; set; } = "怎么购买|下单|哪里下单=下发小黄车2号链接下单\r\n发货地|哪里发货=我们的发货地是北京哈\r\n主播666|666=感谢支持！祝你开心！";

	}
}
