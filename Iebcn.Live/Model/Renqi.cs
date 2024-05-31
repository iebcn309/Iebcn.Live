namespace Iebcn.Live
{
	public class Renqi
	{
		// 私有字段，表示礼物功能是否启用
		private bool _isGiftEnabled = true;

		// 私有字段，表示背景透明功能是否启用
		private bool _isBgTransparentEnabled;

		// 私有字段，表示匿名功能是否启用
		private bool _isAnonymousEnabled;

		// 私有字段，表示进入房间功能是否启用
		private bool _isEnterRoomEnabled = true;

		// 私有字段，表示购买功能是否启用
		private bool _isBuyEnabled = true;

		// 礼物功能的最小秒数
		private int _giftMiniSeconds = 6;

		// 礼物功能的最大秒数
		private int _giftMaxSeconds = 6;

		// 礼物功能的最小次数
		private int _giftMinCount = 1;

		// 礼物功能的最大次数
		private int _giftMaxCount = 6;

		// 进入房间功能的最小秒数
		private int _enterRoomMiniSeconds;

		// 进入房间功能的最大秒数
		private int _enterRoomMaxSeconds = 6;

		// 购买功能的最小秒数
		private int _buyMiniSeconds;

		// 购买功能的最大秒数
		private int _buyMaxSeconds = 6;

		/// <summary>
		/// 获取或设置礼物功能是否启用
		/// </summary>
		public bool GiftEnabled
		{
			get { return _isGiftEnabled; }
			set { _isGiftEnabled = value; }
		}

		/// <summary>
		/// 获取或设置背景透明功能是否启用
		/// </summary>
		public bool BgTransparentEnabled
		{
			get { return _isBgTransparentEnabled; }
			set { _isBgTransparentEnabled = value; }
		}

		/// <summary>
		/// 获取或设置匿名功能是否启用
		/// </summary>
		public bool AnonymousEnabled
		{
			get { return _isAnonymousEnabled; }
			set { _isAnonymousEnabled = value; }
		}

		/// <summary>
		/// 获取或设置进入房间功能是否启用
		/// </summary>
		public bool EnterRoomEnabled
		{
			get { return _isEnterRoomEnabled; }
			set { _isEnterRoomEnabled = value; }
		}

		/// <summary>
		/// 获取或设置购买功能是否启用
		/// </summary>
		public bool BuyEnabled
		{
			get { return _isBuyEnabled; }
			set { _isBuyEnabled = value; }
		}

		/// <summary>
		/// 获取或设置礼物功能的最小秒数
		/// </summary>
		public int GiftMiniSeconds
		{
			get { return _giftMiniSeconds; }
			set { _giftMiniSeconds = value; }
		}

		/// <summary>
		/// 获取或设置礼物功能的最大秒数
		/// </summary>
		public int GiftMaxSeconds
		{
			get { return _giftMaxSeconds; }
			set { _giftMaxSeconds = value; }
		}

		/// <summary>
		/// 获取或设置礼物功能的最小次数
		/// </summary>
		public int GiftMinCount
		{
			get { return _giftMinCount; }
			set { _giftMinCount = value; }
		}

		/// <summary>
		/// 获取或设置礼物功能的最大次数
		/// </summary>
		public int GiftMaxCount
		{
			get { return _giftMaxCount; }
			set { _giftMaxCount = value; }
		}

		/// <summary>
		/// 获取或设置进入房间功能的最小秒数
		/// </summary>
		public int EnterRoomMiniSeconds
		{
			get { return _enterRoomMiniSeconds; }
			set { _enterRoomMiniSeconds = value; }
		}

		/// <summary>
		/// 获取或设置进入房间功能的最大秒数
		/// </summary>
		public int EnterRoomMaxSeconds
		{
			get { return _enterRoomMaxSeconds; }
			set { _enterRoomMaxSeconds = value; }
		}

		/// <summary>
		/// 获取或设置购买功能的最小秒数
		/// </summary>
		public int BuyMiniSeconds
		{
			get { return _buyMiniSeconds; }
			set { _buyMiniSeconds = value; }
		}

		/// <summary>
		/// 获取或设置购买功能的最大秒数
		/// </summary>
		public int BuyMaxSeconds
		{
			get { return _buyMaxSeconds; }
			set { _buyMaxSeconds = value; }
		}
	}
}