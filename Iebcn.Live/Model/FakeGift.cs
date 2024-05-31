using System.Collections.ObjectModel;

namespace Iebcn.Live.ViewModel
{
	// 定义一个名为"FakeGift"的类，用于管理模拟礼物相关设置和数据
	public class FakeGift
	{
		private bool _enabled; // 是否启用模拟礼物功能

		private int _cacheMax = 10; // 模拟礼物缓存的最大数量

		private bool _greenBackground = true; // 是否使用绿色背景显示模拟礼物

		private ObservableCollection<FakeGiftInfo> _savedList = new ObservableCollection<FakeGiftInfo>(); // 已保存的模拟礼物列表

		// 公开属性：Enabled，根据VIP等级限制是否启用模拟礼物功能
		public bool Enabled
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_enabled = false;
				}
				return _enabled;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_enabled = value;
			}
		}

		// 公开属性：CacheMax
		public int CacheMax
		{
			get => _cacheMax;
			set => _cacheMax = value;
		}

		// 公开属性：GreenBackground
		public bool GreenBackground
		{
			get => _greenBackground;
			set => _greenBackground = value;
		}

		// 公开属性：SavedList
		public ObservableCollection<FakeGiftInfo> SavedList
		{
			get => _savedList;
			set => _savedList = value;
		}
	}
}
