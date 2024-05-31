using Iebcn.Live.Helper;

namespace Iebcn.Live
{
	public class EventDanmu
	{
		private bool _greenBackground = true; // 是否启用绿色背景
		private int _cacheMax = 10; // 缓存的最大数量
		private bool _onlyUsers; // 是否只针对特定用户
		private string _userNicks = "大哥aaa|牛叉用户bbb|土豪cc"; // 特定用户的昵称列表，用竖线分隔
		private DanmuEventData _dataGift = new DanmuEventData(); // 礼物事件的弹幕数据
		private DanmuEventData _dataEnterRoom = new DanmuEventData(); // 进场事件的弹幕数据
		private DanmuEventData _dataLike = new DanmuEventData(); // 点赞事件的弹幕数据
		private DanmuEventData _dataFollow = new DanmuEventData(); // 关注事件的弹幕数据

		/// <summary>
		/// 获取或设置是否启用绿色背景
		/// </summary>
		public bool GreenBackground
		{
			get { return _greenBackground; }
			set { _greenBackground = value; }
		}

		/// <summary>
		/// 获取或设置缓存的最大数量
		/// </summary>
		public int CacheMax
		{
			get { return _cacheMax; }
			set { _cacheMax = value; }
		}

		/// <summary>
		/// 获取或设置是否只针对特定用户
		/// </summary>
		public bool OnlyUsers
		{
			get { return _onlyUsers; }
			set { _onlyUsers = value; }
		}

		/// <summary>
		/// 获取或设置特定用户的昵称列表，用竖线分隔
		/// </summary>
		public string UserNicks
		{
			get { return _userNicks; }
			set { _userNicks = value; }
		}

		/// <summary>
		/// 获取或设置礼物事件的弹幕数据
		/// </summary>
		public DanmuEventData DataGift
		{
			get { return _dataGift; }
			set { _dataGift = value; }
		}

		/// <summary>
		/// 获取或设置进场事件的弹幕数据
		/// </summary>
		public DanmuEventData DataEnterRoom
		{
			get { return _dataEnterRoom; }
			set { _dataEnterRoom = value; }
		}

		/// <summary>
		/// 获取或设置点赞事件的弹幕数据
		/// </summary>
		public DanmuEventData DataLike
		{
			get { return _dataLike; }
			set { _dataLike = value; }
		}

		/// <summary>
		/// 获取或设置关注事件的弹幕数据
		/// </summary>
		public DanmuEventData DataFollow
		{
			get { return _dataFollow; }
			set { _dataFollow = value; }
		}
	}
}