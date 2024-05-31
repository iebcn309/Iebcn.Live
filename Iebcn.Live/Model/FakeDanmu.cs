using System.Runtime.CompilerServices;

namespace Iebcn.Live.ViewModel
{
	public class FakeDanmu
	{
		// 用户等级，用于判断用户是否享有聊天权限
		private int userLevel = 1;

		// 是否启用聊天功能
		private bool isChatEnabled;

		// 是否启用礼物功能
		private bool isGiftEnabled;

		// 是否启用进入房间功能
		private bool isEnterRoomEnabled;

		// 是否启用点赞功能
		private bool isLikeEnabled;

		// 是否启用关注功能
		private bool isFollowEnabled;

		// 礼物最大数量
		[CompilerGenerated]
		private int giftCountMax = 5;

		// 是否忽略用户昵称的语音功能
		[CompilerGenerated]
		private bool voiceIgnoreUserNick;

		// 聊天最小间隔时间（秒）
		private double minChatIntervalSeconds;

		// 礼物最小间隔时间（秒）
		private double minGiftIntervalSeconds;

		// 进入房间最小间隔时间（秒）
		private double minEnterRoomIntervalSeconds;

		// 点赞最小间隔时间（秒）
		private double minLikeIntervalSeconds;

		// 关注最小间隔时间（秒）
		private double minFollowIntervalSeconds;

		// 聊天最大间隔时间（秒）
		private double maxChatIntervalSeconds;

		// 礼物最大间隔时间（秒）
		private double maxGiftIntervalSeconds;

		// 进入房间最大间隔时间（秒）
		private double maxEnterRoomIntervalSeconds;

		// 点赞最大间隔时间（秒）
		private double maxLikeIntervalSeconds;

		// 关注最大间隔时间（秒）
		private double maxFollowIntervalSeconds;

		// 弹幕内容
		[CompilerGenerated]
		private string content = "这个产品真的好！\r\n用过都说好！\r\n确实棒棒哒，效果杠杠的！\r\n太好用了！666！";

		// 获取或设置是否启用聊天功能，根据用户等级进行判断
		public bool ChatEnabled
		{
			get { return isChatEnabled; }
			set
			{
				if (Common.VIPLevel < userLevel)
				{
					isChatEnabled = false;
				}
				else
				{
					isChatEnabled = value;
				}
			}
		}

		// 获取或设置是否启用礼物功能，根据用户等级进行判断
		public bool GiftEnabled
		{
			get { return isGiftEnabled; }
			set
			{
				if (Common.VIPLevel < userLevel)
				{
					isGiftEnabled = false;
				}
				else
				{
					isGiftEnabled = value;
				}
			}
		}

		// 获取或设置是否启用进入房间功能，根据用户等级进行判断
		public bool EnterRoomEnabled
		{
			get { return isEnterRoomEnabled; }
			set
			{
				if (Common.VIPLevel < userLevel)
				{
					isEnterRoomEnabled = false;
				}
				else
				{
					isEnterRoomEnabled = value;
				}
			}
		}

		// 获取或设置是否启用点赞功能，根据用户等级进行判断
		public bool LikeEnabled
		{
			get { return isLikeEnabled; }
			set
			{
				if (Common.VIPLevel < userLevel)
				{
					isLikeEnabled = false;
				}
				else
				{
					isLikeEnabled = value;
				}
			}
		}

		// 获取或设置是否启用关注功能，根据用户等级进行判断
		public bool FollowEnabled
		{
			get { return isFollowEnabled; }
			set
			{
				if (Common.VIPLevel < userLevel)
				{
					isFollowEnabled = false;
				}
				else
				{
					isFollowEnabled = value;
				}
			}
		}

		// 获取或设置礼物最大数量
		public int GiftCountMax
		{
			[CompilerGenerated]
			get { return giftCountMax; }
			[CompilerGenerated]
			set { giftCountMax = value; }
		}

		// 获取或设置是否忽略用户昵称的语音功能
		public bool VoiceIgnoreUserNickEnabled
		{
			[CompilerGenerated]
			get { return voiceIgnoreUserNick; }
			[CompilerGenerated]
			set { voiceIgnoreUserNick = value; }
		}

		// 获取或设置聊天最小间隔时间（秒）
		public double MinIntrevalSecondsChat
		{
			get { return minChatIntervalSeconds; }
			set
			{
				if (value > MaxIntrevalSecondsChat)
				{
					MaxIntrevalSecondsChat = value;
				}
				minChatIntervalSeconds = value;
			}
		}

		// 获取或设置礼物最小间隔时间（秒）
		public double MinIntrevalSecondsGift
		{
			get { return minGiftIntervalSeconds; }
			set
			{
				if (value > MaxIntrevalSecondsGift)
				{
					MaxIntrevalSecondsGift = value;
				}
				minGiftIntervalSeconds = value;
			}
		}

		// 获取或设置进入房间最小间隔时间（秒）
		public double MinIntrevalSecondsEnterRoom
		{
			get { return minEnterRoomIntervalSeconds; }
			set
			{
				if (value > MaxIntrevalSecondsEnterRoom)
				{
					MaxIntrevalSecondsEnterRoom = value;
				}
				minEnterRoomIntervalSeconds = value;
			}
		}

		// 获取或设置点赞最小间隔时间（秒）
		public double MinIntrevalSecondsLike
		{
			get { return minLikeIntervalSeconds; }
			set
			{
				if (value > MaxIntrevalSecondsLike)
				{
					MaxIntrevalSecondsLike = value;
				}
				minLikeIntervalSeconds = value;
			}
		}

		// 获取或设置关注最小间隔时间（秒）
		public double MinIntrevalSecondsFollow
		{
			get { return minFollowIntervalSeconds; }
			set
			{
				if (value > MaxIntrevalSecondsFollow)
				{
					MaxIntrevalSecondsFollow = value;
				}
				minFollowIntervalSeconds = value;
			}
		}

		// 获取或设置聊天最大间隔时间（秒）
		public double MaxIntrevalSecondsChat
		{
			get
			{
				if (maxChatIntervalSeconds < minChatIntervalSeconds)
				{
					maxChatIntervalSeconds = minChatIntervalSeconds;
				}
				return maxChatIntervalSeconds;
			}
			set
			{
				if (value < minChatIntervalSeconds)
				{
					value = minChatIntervalSeconds;
				}
				maxChatIntervalSeconds = value;
			}
		}

		// 获取或设置礼物最大间隔时间（秒）
		public double MaxIntrevalSecondsGift
		{
			get
			{
				if (maxGiftIntervalSeconds < minGiftIntervalSeconds)
				{
					maxGiftIntervalSeconds = minGiftIntervalSeconds;
				}
				return maxGiftIntervalSeconds;
			}
			set
			{
				if (value < minGiftIntervalSeconds)
				{
					value = minGiftIntervalSeconds;
				}
				maxGiftIntervalSeconds = value;
			}
		}

		// 获取或设置进入房间最大间隔时间（秒）
		public double MaxIntrevalSecondsEnterRoom
		{
			get
			{
				if (maxEnterRoomIntervalSeconds < minEnterRoomIntervalSeconds)
				{
					maxEnterRoomIntervalSeconds = minEnterRoomIntervalSeconds;
				}
				return maxEnterRoomIntervalSeconds;
			}
			set
			{
				if (value < minEnterRoomIntervalSeconds)
				{
					value = minEnterRoomIntervalSeconds;
				}
				maxEnterRoomIntervalSeconds = value;
			}
		}

		// 获取或设置点赞最大间隔时间（秒）
		public double MaxIntrevalSecondsLike
		{
			get
			{
				if (maxLikeIntervalSeconds < minLikeIntervalSeconds)
				{
					maxLikeIntervalSeconds = minLikeIntervalSeconds;
				}
				return maxLikeIntervalSeconds;
			}
			set
			{
				if (value < minLikeIntervalSeconds)
				{
					value = minLikeIntervalSeconds;
				}
				maxLikeIntervalSeconds = value;
			}
		}

		// 获取或设置关注最大间隔时间（秒）
		public double MaxIntrevalSecondsFollow
		{
			get
			{
				if (maxFollowIntervalSeconds < minFollowIntervalSeconds)
				{
					maxFollowIntervalSeconds = minFollowIntervalSeconds;
				}
				return maxFollowIntervalSeconds;
			}
			set
			{
				if (value < minFollowIntervalSeconds)
				{
					value = minFollowIntervalSeconds;
				}
				maxFollowIntervalSeconds = value;
			}
		}

		// 获取或设置弹幕内容
		public string Content
		{
			[CompilerGenerated]
			get { return content; }
			[CompilerGenerated]
			set { content = value; }
		}
	}
}
