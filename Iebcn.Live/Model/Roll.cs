namespace Iebcn.Live.ViewModel
{
	public class Roll
	{
		// 私有字段，表示是否启用滚动效果
		private bool _isEnabled;

		// 私有字段，表示字体大小
		private double _fontSize = 18.0;

		// 私有字段，表示图片大小
		private double _picSize = 50.0;

		// 私有字段，表示滚动条的高度
		private double _windHeight = 850.0;

		// 私有字段，表示礼物名称，用竖线分隔
		private string _giftNames = "小心心|大啤酒";

		// 是否启用滚动效果的属性
		public bool IsEnabled
		{
			get
			{
				// 如果VIP等级小于2，则禁用滚动效果
				if (Common.VIPLevel < 2)
				{
					_isEnabled = false;
				}
				return _isEnabled;
			}
			set
			{
				// 如果VIP等级小于2，则不允许修改启用状态
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_isEnabled = value;
			}
		}

		// 字体大小的属性
		public double FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		// 图片大小的属性
		public double PicSize
		{
			get { return _picSize; }
			set { _picSize = value; }
		}

		// 滚动条高度的属性
		public double WindowHeight
		{
			get { return _windHeight; }
			set { _windHeight = value; }
		}

		// 礼物名称的属性
		public string Gifts
		{
			get { return _giftNames; }
			set { _giftNames = value; }
		}
	}
}
