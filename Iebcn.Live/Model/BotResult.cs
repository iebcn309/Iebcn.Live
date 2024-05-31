namespace Iebcn.Live
{
	// 机器人结果类
	public class BotResult
	{
		// 是否成功
		public bool OK { get; set; }
		// 是否为聊天消息
		public bool IsChat { get; set; }
		// 是否为礼物消息
		public bool IsGift { get; set; }
		// 查询内容
		public string Query { get; set; } = "";
		// 结果内容
		public string Result { get; set; } = "";
		// 礼物名称
		public string GiftName { get; set; } = "";
		public DanmuType DanmuType { get; set; }
	}
}
