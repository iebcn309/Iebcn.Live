namespace Iebcn.Live.ViewModel
{
	public class HitGiftInfo
	{
		// 弹幕类型，例如礼物、聊天、点赞
		private DanmuType _type = DanmuType.Gift;

		// 礼物名称，当类型为礼物时使用
		private string _giftName = "小心心";

		// 礼物是否按数量触发
		private bool _giftExcByCount;

		// 弹幕内容，当类型为聊天时使用
		private string _chatWords = "";

		// 优先级
		private int _priority;

		// 循环次数
		private int _loopCount = 1;

		// 添加时间
		private DateTime _addTime = DateTime.Now;

		// 图片数量
		private int _picCount = 6;

		// 图片文件名
		private string _picFile = "1.png";

		// 音频文件名
		private string _audioFile = "1.mp3";

		// 持续秒数
		private int _lastSeconds = 3;

		// 弹幕类型的属性
		public DanmuType DType
		{
			get { return _type; }
			set { _type = value; }
		}

		// 礼物名称的属性
		public string GiftName
		{
			get { return _giftName; }
			set { _giftName = value; }
		}

		// 礼物是否按数量触发的属性
		public bool GiftExcByCount
		{
			get { return _giftExcByCount; }
			set { _giftExcByCount = value; }
		}

		// 弹幕内容的属性
		public string ChatWords
		{
			get { return _chatWords; }
			set { _chatWords = value; }
		}

		// 优先级的属性
		public int Priority
		{
			get { return _priority; }
			set { _priority = value; }
		}

		// 循环次数的属性
		public int LoopCount
		{
			get { return _loopCount; }
			set { _loopCount = value; }
		}

		// 添加时间的属性
		public DateTime AddTime
		{
			get { return _addTime; }
			set { _addTime = value; }
		}

		// 图片数量的属性
		public int PicCount
		{
			get { return _picCount; }
			set { _picCount = value; }
		}

		// 图片文件名的属性
		public string PicFile
		{
			get { return _picFile; }
			set { _picFile = value; }
		}

		// 音频文件名的属性
		public string AudioFile
		{
			get { return _audioFile; }
			set { _audioFile = value; }
		}

		// 持续秒数的属性
		public int LastSeconds
		{
			get { return _lastSeconds; }
			set { _lastSeconds = value; }
		}

		// 描述信息，根据类型动态生成
		public string Desc
		{
			get
			{
				switch (_type)
				{
					case DanmuType.Gift:
						return $"{_priority}-礼物[{_giftName}]，砸图{_picCount}个，持续{_lastSeconds}秒";
					case DanmuType.Chat:
						return $"{_priority}-弹幕[{_chatWords}]，砸图{_picCount}个，持续{_lastSeconds}秒";
					case DanmuType.Like:
						return $"{_priority}-点赞，砸图{_picCount}个，持续{_lastSeconds}秒";
					default:
						return "未知类型";
				}
			}
		}
	}
}