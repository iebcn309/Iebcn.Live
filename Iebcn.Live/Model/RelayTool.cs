namespace Iebcn.Live.ViewModel
{
	using System.Collections.ObjectModel; // 引入ObservableCollection的命名空间

	public class RelayTool
	{
		// 是否启用中继工具的功能
		private bool _isEnabled;

		// 中继工具的缓存数量
		private int _cacheCount = 5;

		// 中继命令的最大循环次数
		private int _maxLoop = 100;

		// 保存的中继命令列表
		private ObservableCollection<RelayCommand> _relayCmdList = new ObservableCollection<RelayCommand>();

		// 启用状态属性，考虑VIP等级的影响
		public bool Enabled
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

		// 缓存数量属性，初始值为5
		public int CacheCount
		{
			get { return _cacheCount; }
			set { _cacheCount = value; }
		}

		// 命令最大循环次数属性，初始值为100
		public int CmdMaxLoop
		{
			get { return _maxLoop; }
			set { _maxLoop = value; }
		}

		// 保存的中继命令列表属性
		public ObservableCollection<RelayCommand> RelayCmdListSaved
		{
			get { return _relayCmdList; }
			set { _relayCmdList = value; }
		}
	}

	// 假设RelayCommand是一个已经定义好的类，用于表示中继命令
	public class RelayCommand
	{
		// RelayCommand的实现略...
	}
}
