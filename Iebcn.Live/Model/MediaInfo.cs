namespace Iebcn.Live.ViewModel
{
	using System;

	public class MediaInfo
	{
		// 媒体名称
		private string _name = "";

		// 弹幕类型
		private DanmuType _type = DanmuType.Gift;

		// 礼物名称
		private string _giftName = "小心心";

		// 礼物是否按数量触发
		private bool _giftExcByCount;

		// 弹幕内容
		private string _chatWords = "";

		// 媒体文件路径
		private string _mediaFile = "";

		// 显示秒数
		private int _showSeconds = 3;

		// 音量大小
		private double _volume = 1.0;

		// 窗口宽度
		private double _windowWidth = 500.0;

		// 窗口高度
		private double _windowHeight = 800.0;

		// 窗口在屏幕上的位置X坐标
		private double _xPos;

		// 窗口在屏幕上的位置Y坐标
		private double _yPos;

		// 优先级
		private int _priority;

		// 循环次数
		private int _loopCount = 1;

		// 添加时间
		private DateTime _addTime = DateTime.Now;

		// 媒体名称的属性
		public string Name
		{
			get { return _name; }
			set { _name = value; }
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

		// 媒体文件路径的属性
		public string MediaFile
		{
			get { return _mediaFile; }
			set { _mediaFile = value; }
		}

		// 显示秒数的属性
		public int ShowSeconds
		{
			get { return _showSeconds; }
			set { _showSeconds = value; }
		}

		// 音量大小的属性
		public double Volume
		{
			get { return _volume; }
			set { _volume = value; }
		}

		// 窗口宽度的属性
		public double WindowWidth
		{
			get { return _windowWidth; }
			set { _windowWidth = value; }
		}

		// 窗口高度的属性
		public double WindowHeight
		{
			get { return _windowHeight; }
			set { _windowHeight = value; }
		}

		// 窗口在屏幕上的位置X坐标的属性
		public double X
		{
			get { return _xPos; }
			set { _xPos = value; }
		}

		// 窗口在屏幕上的位置Y坐标的属性
		public double Y
		{
			get { return _yPos; }
			set { _yPos = value; }
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

		// 媒体信息的描述
		public string Desc
		{
			get
			{
				switch (DType)
				{
					case DanmuType.Gift:
						return $"礼物[{GiftName}]=媒体文件";
					case DanmuType.Chat:
						return $"弹幕[{ChatWords}]=媒体文件";
					case DanmuType.Like:
						return $"点赞=媒体文件";
					default:
						return "未知类型";
				}
			}
		}

		// 标题属性，由优先级和名称组成
		public string Title => $"{Priority}-{Name}";

	}
}
