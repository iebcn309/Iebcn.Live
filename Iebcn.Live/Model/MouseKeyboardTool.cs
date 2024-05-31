namespace Iebcn.Live.ViewModel
{
	using System.Collections.ObjectModel;
	using System.ComponentModel;

	public class MouseKeyboardTool
	{
		// 私有字段，用于控制工具是否启用
		private bool _isEnabled;

		// 私有字段，用于控制缓存数量
		private int _cacheCount = 50;

		// 私有字段，用于控制礼物是否多次运行
		private bool _giftRunMultiTime;

		// 私有字段，用于控制礼物最大循环次数
		private int _giftMaxLoop = 10;

		// 私有字段，用于存储命令列表
		private ObservableCollection<MKTriggerCommand> _cmdListSaved = new ObservableCollection<MKTriggerCommand>();

		// 工具是否启用的属性
		public bool Enabled
		{
			get
			{
				// 如果VIP等级小于1，则禁用工具
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

		// 缓存数量的属性
		public int CacheCount
		{
			get { return _cacheCount; }
			set { _cacheCount = value; OnPropertyChanged(nameof(CacheCount)); }
		}

		// 礼物是否多次运行的属性
		public bool GiftRunMultiTime
		{
			get { return _giftRunMultiTime; }
			set { _giftRunMultiTime = value; OnPropertyChanged(nameof(GiftRunMultiTime)); }
		}

		// 礼物最大循环次数的属性
		public int GiftMaxLoop
		{
			get { return _giftMaxLoop; }
			set { _giftMaxLoop = value; OnPropertyChanged(nameof(GiftMaxLoop)); }
		}

		// 命令列表的属性
		public ObservableCollection<MKTriggerCommand> CmdListSaved
		{
			get { return _cmdListSaved; }
			set { _cmdListSaved = value; OnPropertyChanged(nameof(CmdListSaved)); }
		}

		// 属性更改通知
		public event PropertyChangedEventHandler PropertyChanged;

		// 触发属性更改事件的方法
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
