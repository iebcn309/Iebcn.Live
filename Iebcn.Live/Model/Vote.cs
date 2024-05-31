namespace Iebcn.Live.ViewModel
{
	using System.Collections.ObjectModel; // 引入ObservableCollection的命名空间

	public class Vote
	{
		// 控件是否启用的属性，受VIP等级影响
		private bool _isEnabled;

		// 字体大小
		private double _fontSize = 14.0;

		// 背景透明度
		private double _bgOpacity = 0.5;

		// 项目宽度
		private double _itemWidth = 222.0;

		// 项目高度
		private double _itemHeight = 311.0;

		// 是否显示项目头像
		private bool _showItemHeadPic = true;

		// 是否显示命令提示
		private bool _showCmdTip = true;

		// 允许投票更多项目
		private bool _allowVoteMoreItems = true;

		// 允许重复投票项目
		private bool _allowVoteItemRepeat = true;

		// 单个用户最大投票限制
		private int _singleUserMaxVoteLimit = 10000;

		// 倒计时秒数
		private int _countDownSeconds = 10;

		// 投票数据列表
		private ObservableCollection<VoteData> _voteDataList = new ObservableCollection<VoteData>();

		// 控件启用状态的属性
		public bool IsEnabled
		{
			get
			{
				// 如果VIP等级小于等于0，则控件不可用
				if (Common.VIPLevel <= 0)
				{
					_isEnabled = false;
				}
				return _isEnabled;
			}
			set
			{
				// 设置启用状态，并考虑VIP等级的影响
				if (Common.VIPLevel <= 0)
				{
					value = false;
				}
				_isEnabled = value;
			}
		}

		// 字体大小属性
		public double FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		// 背景透明度属性
		public double BgOpacity
		{
			get { return _bgOpacity; }
			set { _bgOpacity = value; }
		}

		// 项目宽度属性
		public double ItemWidth
		{
			get { return _itemWidth; }
			set { _itemWidth = value; }
		}

		// 项目高度属性
		public double ItemHeight
		{
			get { return _itemHeight; }
			set { _itemHeight = value; }
		}

		// 是否显示项目头像属性
		public bool ShowItemHeadPic
		{
			get { return _showItemHeadPic; }
			set { _showItemHeadPic = value; }
		}

		// 是否显示命令提示属性
		public bool ShowCmdTip
		{
			get { return _showCmdTip; }
			set { _showCmdTip = value; }
		}

		// 允许投票更多项目属性
		public bool AllowVoteMoreItems
		{
			get { return _allowVoteMoreItems; }
			set { _allowVoteMoreItems = value; }
		}

		// 允许重复投票项目属性
		public bool AllowVoteItemRepeat
		{
			get { return _allowVoteItemRepeat; }
			set { _allowVoteItemRepeat = value; }
		}

		// 单个用户最大投票限制属性
		public int SingleUserMaxVoteLimit
		{
			get { return _singleUserMaxVoteLimit; }
			set { _singleUserMaxVoteLimit = value; }
		}

		// 倒计时秒数属性
		public int CountDownSeconds
		{
			get { return _countDownSeconds; }
			set { _countDownSeconds = value; }
		}

		// 投票数据列表属性
		public ObservableCollection<VoteData> VoteDataList
		{
			get { return _voteDataList; }
			set { _voteDataList = value; }
		}
	}
}
