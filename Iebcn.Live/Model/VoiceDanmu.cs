namespace Iebcn.Live
{
	public class VoiceDanmu
	{
		// 是否启用
		public bool Enabled { get; set; } = true;
		// 是否启用截断
		public bool CutEnabled { get; set; }
		// 截断计数
		public int CutCount { get; set; } = 50;
		// 是否启用礼物优先
		public bool GiftFirstEnabled { get; set; }
		// 粉丝俱乐部等级最低限制
		public int FansClubLevelMini { get; set; }
		// 语音设置
		public Voice Voice { get; set; } = new Voice();
		// 间隔秒数
		public int IntervalSeconds { get; set; }
		// 选项类型
		public OptTypes OptTypes { get; set; } = new OptTypes { GiftEnabled = true, ChatEnabled = true };
		// 选项内容
		public OptContent OptContent { get; set; } = new OptContent();
		// 是否启用禁用词
		public bool ForbiddenWordsEnabled { get; set; }
		public string CustomVoiceUrl1 { get; set; } = "https://";
		public string CustomVoiceUrl2 { get; set; } = "https://";
		public string CustomVoiceUrl3 { get; set; } = "https://";
		public string CustomVoiceUrl4 { get; set; } = "https://";
		public string CustomVoiceUrl5 { get; set; } = "https://";

		public VoiceDanmu()
		{
			InitializeBasedOnVIPLevel();
		}
		private void InitializeBasedOnVIPLevel()
		{
			if (Common.VIPLevel < 1)
			{
				CutEnabled = false;
				GiftFirstEnabled = false;
				FansClubLevelMini = 0;
				ForbiddenWordsEnabled = false;
			}
		}
	}
}