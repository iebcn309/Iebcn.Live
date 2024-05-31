namespace Iebcn.Live.ViewModel
{
	public class FakeGiftInfo
	{
		// 媒体ID，用于标识不同的礼物或弹幕
		private int _mediaId;

		// 弹幕类型，用于区分是礼物、弹幕还是点赞
		private DanmuType _type = DanmuType.Gift;

		// 礼物名称，当类型为礼物时使用
		private string _giftName = "小心心";

		// 礼物是否按数量触发，用于控制重复发送相同礼物的逻辑
		private bool _giftExcByCount;

		// 弹幕内容，当类型为弹幕时使用
		private string _chatWords;

		// 媒体名称，用于显示的名称
		private string _mediaName;

		// 优先级，用于控制显示顺序
		private int _priority;

		// 循环次数，用于控制重复显示的次数
		private int _loopCount = 1;

		// 添加时间，用于记录创建时间
		private DateTime _addTime = DateTime.Now;

		// 媒体ID的属性
		public int MediaId
		{
			get { return _mediaId; }
			set { _mediaId = value; }
		}

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

		// 媒体名称的属性
		public string MediaName
		{
			get { return _mediaName; }
			set { _mediaName = value; }
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

		// 描述信息，根据类型动态生成
		public string Desc
		{
			get
			{
				switch (DType)
				{
					case DanmuType.Gift:
						return $"{Priority}-礼物[{GiftName}]=媒体名称";
					case DanmuType.Chat:
						return $"{Priority}-弹幕[{ChatWords}]=媒体名称";
					case DanmuType.Like:
						return $"{Priority}-点赞=媒体名称";
					default:
						return string.Empty;
				}
			}
		}
	}
}