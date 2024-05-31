namespace Iebcn.Live.ViewModel
{
	using System.Collections.Generic;

	public class GiftInteraction
	{
		// 礼物互动功能启用状态
		private bool _isEnabled;

		// 切换页面功能启用状态
		private bool _isPageSwitchEnabled;

		// 切换页面间隔秒数
		private int _switchIntervalSeconds;

		// 字体大小
		private double _fontSize;

		// 图片大小
		private double _picSize;

		// 窗口高度
		private double _windowHeight;

		// 已送出礼物列表
		private List<GiftInfo> _savedGifts;

		// 构造函数
		public GiftInteraction()
		{
			// 初始化属性值
			_isEnabled = true;
			_isPageSwitchEnabled = true;
			_switchIntervalSeconds = 8;
			_fontSize = 18.0;
			_picSize = 50.0;
			_windowHeight = 850.0;
			_savedGifts = new List<GiftInfo>();
		}

		// 礼物互动功能启用状态
		public bool IsEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_isEnabled = false;
				}
				return _isEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_isEnabled = value;
			}
		}

		// 切换页面功能启用状态
		public bool IsPageSwitchEnabled
		{
			get => _isPageSwitchEnabled;
			set => _isPageSwitchEnabled = value;
		}

		// 切换页面间隔秒数
		public int SwitchIntervalSeconds
		{
			get => _switchIntervalSeconds;
			set => _switchIntervalSeconds = value;
		}

		// 字体大小
		public double FontSize
		{
			get => _fontSize;
			set => _fontSize = value;
		}

		// 图片大小
		public double PicSize
		{
			get => _picSize;
			set => _picSize = value;
		}

		// 窗口高度
		public double WindowHeight
		{
			get => _windowHeight;
			set => _windowHeight = value;
		}

		// 已送出礼物列表
		public List<GiftInfo> SavedGifts
		{
			get => _savedGifts;
			set => _savedGifts = value;
		}
	}
}
