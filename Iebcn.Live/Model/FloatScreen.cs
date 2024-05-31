using System.Windows.Media;

namespace Iebcn.Live.ViewModel
{
	public class FloatScreen
	{
		// 私有字段，用于控制是否显示绿色背景
		private bool _isGreenBackground;

		// 私有字段，用于控制聊天功能是否启用
		private bool _isChatEnabled;

		// 私有字段，用于控制礼物功能是否启用
		private bool _isGiftEnabled;

		// 私有字段，用于控制进入房间提示是否启用
		private bool _isEnterRoomEnabled;

		// 私有字段，用于控制点赞功能是否启用
		private bool _isLikeEnabled;

		// 私有字段，用于控制关注功能是否启用
		private bool _isFollowEnabled = true;

		// 私有字段，用于控制滚动速度
		private int _speed = 5;

		// 私有字段，用于控制字体大小
		private double _fontSize = 25.0;

		// 私有字段，用于控制礼物图片功能是否启用
		private bool _isGiftPicEnabled;

		// 私有字段，用于控制最大运行次数
		private int _maxRunCount = 3;

		// 私有字段，用于控制间隔秒数
		private int _intervalSeconds = 4;

		// 私有字段，用于控制前景颜色
		private SolidColorBrush _foreground = new SolidColorBrush(Colors.White);

		// 私有字段，用于控制钻石数量限制
		private int _limitDiamondCount;

		// 私有字段，用于控制整数0的值（可能用于其他特定功能）
		private int _int32_0;

		// 私有字段，用于控制聊天触发功能是否启用
		private bool _isChatTriggerEnabled;

		// 私有字段，用于控制聊天触发内容
		private string _chatTriggerContent = "666=欢迎{用户}加入蓝队\r\n777=欢迎{用户}加入红队\r\n";

		// 是否显示绿色背景的属性
		public bool GreenBackground
		{
			get { return _isGreenBackground; }
			set { _isGreenBackground = value; }
		}

		// 聊天功能是否启用的属性
		public bool ChatEnabled
		{
			get { return _isChatEnabled; }
			set { _isChatEnabled = value; }
		}

		// 礼物功能是否启用的属性
		public bool GiftEnabled
		{
			get { return _isGiftEnabled; }
			set { _isGiftEnabled = value; }
		}

		// 进入房间提示是否启用的属性
		public bool EnterRoomEnabled
		{
			get { return _isEnterRoomEnabled; }
			set { _isEnterRoomEnabled = value; }
		}

		// 点赞功能是否启用的属性
		public bool LikeEnabled
		{
			get { return _isLikeEnabled; }
			set { _isLikeEnabled = value; }
		}

		// 关注功能是否启用的属性
		public bool FollowEnabled
		{
			get { return _isFollowEnabled; }
			set { _isFollowEnabled = value; }
		}

		// 滚动速度的属性
		public int Speed
		{
			get { return _speed; }
			set { _speed = value; }
		}

		// 字体大小的属性
		public double FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		// 礼物图片功能是否启用的属性
		public bool GifPicEnabled
		{
			get { return _isGiftPicEnabled; }
			set { _isGiftPicEnabled = value; }
		}

		// 最大运行次数的属性
		public int MaxRunCount
		{
			get { return _maxRunCount; }
			set { _maxRunCount = value; }
		}

		// 间隔秒数的属性
		public int IntervalSeconds
		{
			get { return _intervalSeconds; }
			set { _intervalSeconds = value; }
		}

		// 前景颜色的属性
		public SolidColorBrush Foreground
		{
			get { return _foreground; }
			set { _foreground = value; }
		}

		// 钻石数量限制的属性
		public int LimitDiamondCount
		{
			get { return _limitDiamondCount; }
			set { _limitDiamondCount = value; }
		}

		// 整数0的属性（可能用于其他特定功能）
		public int Int32_0
		{
			get { return _int32_0; }
			set { _int32_0 = value; }
		}

		// 聊天触发功能是否启用的属性
		public bool ChatTriggerEnabled
		{
			get { return _isChatTriggerEnabled; }
			set { _isChatTriggerEnabled = value; }
		}

		// 聊天触发内容的属性
		public string ChatTriggerContent
		{
			get { return _chatTriggerContent; }
			set { _chatTriggerContent = value; }
		}
	}
}
