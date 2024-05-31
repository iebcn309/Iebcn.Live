namespace Iebcn.Live.ViewModel
{
	// 定义一个名为"Muyu"的类，用于封装与平台互动相关的设置和数据
	public class Muyu
	{

		private bool _greenBackground = true; // 是否启用绿色背景

		private bool _soundEnabled = true; // 是否启用声音

		private bool _enterRoomEnabled; // 是否允许进入房间

		private bool _likeEnabled; // 是否允许点赞

		private bool _followEnabled; // 是否允许关注

		private bool _giftEnabled; // 是否允许赠送礼物

		private bool _chatEnabled; // 是否允许聊天

		private double _enterRoomPoint = 1.0; // 进入房间所获积分

		private double _likePoint = 1.0; // 点赞所获积分

		private double _followPoint = 1.0; // 关注所获积分

		private string _giftContent = "小心心=1\r\n玫瑰花=2\r\n飞机=10\r\n嘉年华=5000\r\n其他=1"; // 礼物内容及对应积分

		private string _chatContent = "666=1\r\n加油=2\r\n777=3\r\n其他=1"; // 聊天内容及对应积分

		private string _descText = "功德"; // 描述文本

		// 公开属性：GreenBackground
		public bool GreenBackground
		{
			get => _greenBackground;
			set => _greenBackground = value;
		}

		// 公开属性：SoundEnabled
		public bool SoundEnabled
		{
			get => _soundEnabled;
			set => _soundEnabled = value;
		}

		// 公开属性：EnterRoomEnabled，根据VIP等级限制是否允许进入房间
		public bool EnterRoomEnabled
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_enterRoomEnabled = false;
				}
				return _enterRoomEnabled;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_enterRoomEnabled = value;
			}
		}

		// 公开属性：LikeEnabled，根据VIP等级限制是否允许点赞
		public bool LikeEnabled
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_likeEnabled = false;
				}
				return _likeEnabled;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_likeEnabled = value;
			}
		}

		// 公开属性：FollowEnabled，根据VIP等级限制是否允许关注
		public bool FollowEnabled
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_followEnabled = false;
				}
				return _followEnabled;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_followEnabled = value;
			}
		}

		// 公开属性：GiftEnabled，根据VIP等级限制是否允许赠送礼物
		public bool GiftEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_giftEnabled = false;
				}
				return _giftEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_giftEnabled = value;
			}
		}

		// 公开属性：ChatEnabled，根据VIP等级限制是否允许聊天
		public bool ChatEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_chatEnabled = false;
				}
				return _chatEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_chatEnabled = value;
			}
		}

		// 公开属性：EnterRoomPoint
		public double EnterRoomPoint
		{
			get => _enterRoomPoint;
			set => _enterRoomPoint = value;
		}

		// 公开属性：LikePoint
		public double LikePoint
		{
			get => _likePoint;
			set => _likePoint = value;
		}

		// 公开属性：FollowPoint
		public double FollowPoint
		{
			get => _followPoint;
			set => _followPoint = value;
		}

		// 公开属性：GiftContent
		public string GiftContent
		{
			get => _giftContent;
			set => _giftContent = value;
		}

		// 公开属性：ChatContent
		public string ChatContent
		{
			get => _chatContent;
			set => _chatContent = value;
		}

		// 公开属性：DescText
		public string DescText
		{
			get => _descText;
			set => _descText = value;
		}
	}
}
