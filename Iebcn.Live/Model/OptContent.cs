namespace Iebcn.Live
{
	public class OptContent
	{
		// 感谢 {用户} 赠送的 {礼物个数} 的 {礼物名}
		private string giftFormat = "感谢 {用户} 赠送的 {礼物个数} 的 {礼物名}";
		// 感谢 {用户} 点赞了主播
		private string likeFormat = "感谢 {用户} 点赞了主播";
		// 感谢 {用户} 关注了主播
		private string followFormat = "感谢 {用户} 关注了主播";
		// 欢迎 {用户} 进入直播间
		private string enterRoomFormat = "欢迎 {用户} 进入直播间";
		// 大礼感谢语句
		private string giftExt = "，感谢！\r\n，感谢大礼，爱你！";
		// 点赞感谢语句
		private string likeExt = "，爱你一万年！\r\n，感谢支持，爱你！";
		// 关注感谢语句
		private string followExt = "，鞠躬感谢！\r\n，十分感谢，么么哒！";
		// 进入直播间欢迎语句
		private string enterRoomExt = "，热烈欢迎，鼓掌！\r\n，起立欢迎！";
		// 感谢 {用户} 赠送的 {礼物个数} 的 {礼物名}
		public string GiftFormat
		{
			get => giftFormat;
			set => giftFormat = value;
		}
		// 感谢 {用户} 点赞了主播
		public string LikeFormat
		{
			get => likeFormat;
			set => likeFormat = value;
		}
		// 感谢 {用户} 关注了主播
		public string FollowFormat
		{
			get => followFormat;
			set => followFormat = value;
		}
		// 欢迎 {用户} 进入直播间
		public string EnterRoomFormat
		{
			get => enterRoomFormat;
			set => enterRoomFormat = value;
		}
		// 大礼感谢语句
		public string GiftExt
		{
			get => giftExt;
			set => giftExt = value;
		}
		// 点赞感谢语句
		public string LikeExt
		{
			get => likeExt;
			set => likeExt = value;
		}
		// 关注感谢语句
		public string FollowExt
		{
			get => followExt;
			set => followExt = value;
		}
		// 进入直播间欢迎语句
		public string EnterRoomExt
		{
			get => enterRoomExt;
			set => enterRoomExt = value;
		}
	}

}