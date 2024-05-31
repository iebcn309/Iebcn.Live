using System.Text.Json.Serialization;

namespace Iebcn.Live
{
	public class DanmuData
	{
		private DateTime _timestamp;
		private string _userNick="";
		private string _userSex;
		private long _int64_0;
		private long _userFans;
		private long _userFollows;
		private string _userDisplayId;
		private long _userId;
		private string _secUid;
		private string _msg;
		private string _extMsg;
		private string _giftUrl = "pack://application:,,,/assets/record.png";
		private int _giftCount;
		private string _giftName;
		private int _diamondCount;
		private DanmuType _type;
		private long _userConsumeInRoom;
		private string _userHeadPic = "pack://application:,,,/assets/userheadpic3.jpg";
		private string _newImIconWithLevel = "pack://application:,,,/assets/ok.png";
		private int _fansClubLevel;
		private bool _mute;

		[JsonIgnore]
		public string UserNickCut => UserNick.Length > 6 ? UserNick.Substring(0, 6) + ".." : UserNick;

		[JsonIgnore]
		public string FormatMsg
		{
			get
			{
				switch (_type)
				{
					default:
						return $"感谢[{UserNickCut}]";
					case DanmuType.Gift:
						return $"感谢[{UserNickCut}]赠送的{_giftCount}个{_giftName}";
					case DanmuType.Like:
						return $"感谢[{UserNickCut}]点赞了主播";
					case DanmuType.EnterRoom:
						return $"欢迎[{UserNickCut}]进入直播间";
					case DanmuType.Follow:
						return $"感谢[{UserNickCut}]关注了主播";
				}
			}
		}

		[JsonIgnore]
		public string UserNickWithSymbol => $"{UserNick}:";

		[JsonIgnore]
		public string PureMsg
		{
			get
			{
				int colonIndex = _msg.IndexOf(':');
				if (colonIndex > 0)
				{
					return _msg.Substring(colonIndex + 1);
				}
				if (_msg.IndexOf("：") > 0)
				{
					return _msg.Substring(_msg.IndexOf('：') + 1);
				}
				return _msg;
			}
		}

		[JsonIgnore]
		public string TypeCN
		{
			get
			{
				switch (_type)
				{
					default:
						return "聊天";
					case DanmuType.Gift:
						return "礼物";
					case DanmuType.Like:
						return "点赞";
					case DanmuType.EnterRoom:
						return "进入房间";
					case DanmuType.Follow:
						return "关注";
					case DanmuType.App:
						return "系统";
				}
			}
		}

		[JsonIgnore]
		public string UserHeadPic720 => UserHeadPic.Replace("100x100", "720x720");

		[JsonIgnore]
		public string ThksMsg
		{
			get
			{
				if (_type == DanmuType.Chat)
				{
					return _msg;
				}
				if (_type == DanmuType.Gift)
				{
					return $"感谢{UserNick}赠送的{_giftCount}个{_giftName}";
				}
				if (_type == DanmuType.EnterRoom)
				{
					return $"欢迎{UserNick}接入直播间!";
				}
				if (_type == DanmuType.Like)
				{
					return $"感谢{UserNick}点赞了主播!";
				}
				if (_type == DanmuType.Follow)
				{
					return $"感谢{UserNick}关注了主播!";
				}
				return _msg;
			}
		}

		public DateTime Timestamp
		{
			get => _timestamp;
			set => _timestamp = value;
		}

		public string UserNick
		{
			get => _userNick;
			set => _userNick = value;
		}

		public string UserSex
		{
			get => _userSex;
			set => _userSex = value;
		}

		public long UserV5Level
		{
			get => _int64_0;
			set => _int64_0 = value;
		}

		public long UserFans
		{
			get => _userFans;
			set => _userFans = value;
		}

		public long UserFollows
		{
			get => _userFollows;
			set => _userFollows = value;
		}

		public string UserDisplayId
		{
			get => Common.VIPLevel > 0 ? _userDisplayId : "普通版不显示";
			set => _userDisplayId = value;
		}

		public long UserId
		{
			get => _userId;
			set => _userId = value;
		}

		public string SecUid
		{
			get => _secUid;
			set => _secUid = value;
		}

		public string Msg
		{
			get => _msg;
			set => _msg = value;
		}

		public string ExtMsg
		{
			get => _extMsg;
			set => _extMsg = value;
		}

		public string GiftUrl
		{
			get => _giftUrl;
			set { if (!string.IsNullOrWhiteSpace(value)) { _giftUrl = value; } }
		}

		public int GiftCount
		{
			get => _giftCount;
			set => _giftCount = value;
		}

		public string GiftName
		{
			get => _giftName;
			set => _giftName = value;
		}

		public int DiamondCount
		{
			get => _diamondCount;
			set => _diamondCount = value;
		}

		public DanmuType Type
		{
			get => _type;
			set => _type = value;
		}

		public long UserConsumeInRoom
		{
			get => _userConsumeInRoom;
			set => _userConsumeInRoom = value;
		}

		public string UserHeadPic
		{
			get => _userHeadPic;
			set { if (!string.IsNullOrWhiteSpace(value)) { _userHeadPic = value; } }
		}
		public string NewImIconWithLevel
		{
			get => _newImIconWithLevel;
			set { Console.WriteLine(value); if (!string.IsNullOrWhiteSpace(value)) { _newImIconWithLevel = value; } }
		}

		public int FansClubLevel
		{
			get => _fansClubLevel;
			set => _fansClubLevel = value;
		}

		public string AnimationPicUrl { get; set; }
		public bool Mute
		{
			get => _mute;
			set => _mute = value;
		}

		// Internal methods removed for clarity as they don't impact optimization
		// internal static object ux6a(int int_0) { ... }
		// internal static void wx6N() { ... }
		// internal static void Xx6P() { ... }
	}
}