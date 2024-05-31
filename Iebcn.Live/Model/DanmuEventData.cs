namespace Iebcn.Live.Helper
{
	public class DanmuEventData
	{
		private bool _isEnabled; // 表示弹幕事件是否启用

		private double _nickFontSize = 16.0; // 弹幕昵称的字体大小

		private bool _isPicEnabled; // 表示是否显示图片

		private bool _isSoundEnabled; // 表示是否播放声音

		private EventDanmuAnimationStyle _animationStyle = EventDanmuAnimationStyle.FromUp; // 弹幕动画样式

		private string _words; // 弹幕文本内容

		private string _picUrl; // 弹幕图片的URL

		private string _soundFileName; // 弹幕声音文件的名称

		private double _staySeconds = 2.0; // 弹幕显示的持续时间（秒）

		private double _intervalSeconds; // 弹幕之间的时间间隔（秒）

		private string _folderName; // 弹幕图片所在的文件夹名称

		private double _picMaxHeight = 200.0; // 弹幕图片的最大高度

		private string _giftIgnoreList = "小心心|啤酒"; // 忽略的礼物列表，使用竖线分隔

		/// <summary>
		/// 获取或设置弹幕事件是否启用
		/// </summary>
		public bool Enabled
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_isEnabled = false;
				}
				return _isEnabled;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_isEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置弹幕昵称的字体大小
		/// </summary>
		public double NickFontSize
		{
			get { return _nickFontSize; }
			set { _nickFontSize = value; }
		}

		/// <summary>
		/// 获取或设置是否显示图片
		/// </summary>
		public bool PicEnabled
		{
			get { return _isPicEnabled; }
			set { _isPicEnabled = value; }
		}

		/// <summary>
		/// 获取或设置是否播放声音
		/// </summary>
		public bool SoundEnabled
		{
			get { return _isSoundEnabled; }
			set { _isSoundEnabled = value; }
		}

		/// <summary>
		/// 获取或设置弹幕动画样式
		/// </summary>
		public EventDanmuAnimationStyle AnimationStyle
		{
			get { return _animationStyle; }
			set { _animationStyle = value; }
		}

		/// <summary>
		/// 获取或设置弹幕文本内容
		/// </summary>
		public string Words
		{
			get { return _words; }
			set { _words = value; }
		}

		/// <summary>
		/// 获取或设置弹幕图片的URL
		/// </summary>
		public string PicUrl
		{
			get { return _picUrl; }
			set { _picUrl = value; }
		}

		/// <summary>
		/// 获取或设置弹幕声音文件的名称
		/// </summary>
		public string SoundFileName
		{
			get { return _soundFileName; }
			set { _soundFileName = value; }
		}

		/// <summary>
		/// 获取或设置弹幕显示的持续时间（秒）
		/// </summary>
		public double StaySeconds
		{
			get { return _staySeconds; }
			set { _staySeconds = value; }
		}

		/// <summary>
		/// 获取或设置弹幕之间的时间间隔（秒）
		/// </summary>
		public double IntervalSeconds
		{
			get { return _intervalSeconds; }
			set { _intervalSeconds = value; }
		}

		/// <summary>
		/// 获取或设置弹幕图片所在的文件夹名称
		/// </summary>
		public string FolderName
		{
			get { return _folderName; }
			set { _folderName = value; }
		}

		/// <summary>
		/// 获取或设置弹幕图片的最大高度
		/// </summary>
		public double PicMaxHeight
		{
			get { return _picMaxHeight; }
			set { _picMaxHeight = value; }
		}

		/// <summary>
		/// 获取或设置忽略的礼物列表，使用竖线分隔
		/// </summary>
		public string GiftIgnoreList
		{
			get { return _giftIgnoreList; }
			set { _giftIgnoreList = value; }
		}
	}
}