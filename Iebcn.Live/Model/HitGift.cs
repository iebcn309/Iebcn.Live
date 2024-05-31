namespace Iebcn.Live.ViewModel
{
	using System.Collections.ObjectModel;
	using System.ComponentModel;

	public class HitGift
	{
		// 是否启用礼物击中效果
		private bool _isEnabled;

		// 缓存最大数量
		private int _cacheMax = 10;

		// 是否使用绿色背景
		private bool _greenBackground = true;

		// 窗口宽度
		private double _windowWidth = 560.0;

		// 窗口高度
		private double _windowHeight = 800.0;

		// 保存的礼物击中信息列表
		private ObservableCollection<HitGiftInfo> _savedList = new ObservableCollection<HitGiftInfo>();

		// 是否启用礼物击中效果的属性
		public bool Enabled
		{
			get
			{
				// 如果VIP等级小于1，则禁用击中效果
				if (Common.VIPLevel < 1)
				{
					_isEnabled = false;
				}
				return _isEnabled;
			}
			set
			{
				// 如果VIP等级小于1，则不允许修改启用状态
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_isEnabled = value;
				OnPropertyChanged(nameof(Enabled));
			}
		}

		// 缓存最大数量的属性
		public int CacheMax
		{
			get { return _cacheMax; }
			set { _cacheMax = value; OnPropertyChanged(nameof(CacheMax)); }
		}

		// 是否使用绿色背景的属性
		public bool GreenBackground
		{
			get { return _greenBackground; }
			set { _greenBackground = value; OnPropertyChanged(nameof(GreenBackground)); }
		}

		// 窗口宽度的属性
		public double WindowWidth
		{
			get { return _windowWidth; }
			set { _windowWidth = value; OnPropertyChanged(nameof(WindowWidth)); }
		}

		// 窗口高度的属性
		public double WindowHeight
		{
			get { return _windowHeight; }
			set { _windowHeight = value; OnPropertyChanged(nameof(WindowHeight)); }
		}

		// 保存的礼物击中信息列表的属性
		public ObservableCollection<HitGiftInfo> SavedList
		{
			get { return _savedList; }
			set { _savedList = value; OnPropertyChanged(nameof(SavedList)); }
		}

		// 属性更改通知事件
		public event PropertyChangedEventHandler PropertyChanged;

		// 触发属性更改事件的方法
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
