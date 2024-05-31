namespace Iebcn.Live.ViewModel
{
	public class GPT
	{
		private bool _isEnabled;

		// 属性名使用更具描述性的英文命名，以提高代码的可读性。
		private bool _readAnswerEnabled;
		private bool _replyFromChinaAI;
		private double _windWidth;
		private double _windHeight;
		private double _backgroundOpacity;
		private double _fontSize;
		private int _cacheMaxCount;
		private string _command;
		private string _commandTip;
		private bool _cmdTipEnabled;
		private bool _showBusyEnabled;
		private int _minFansClubLevel;
		private int _speakMaxCount;

		// 构造函数
		public GPT()
		{
			// 初始化属性值
			_isEnabled = true;
			_readAnswerEnabled = true;
			_replyFromChinaAI = false;
			_windWidth = 890.0;
			_windHeight = 850.0;
			_backgroundOpacity = 1.0;
			_fontSize = 14.0;
			_cacheMaxCount = 5;
			_command = "gpt";
			_commandTip = "弹幕发送命令> gpt+问题,例如: gpt帮我写一封情书。";
			_cmdTipEnabled = true;
			_showBusyEnabled = false;
			_minFansClubLevel = 250;
			_speakMaxCount = 5;
		}

		// 启用状态
		public bool Enabled
		{
			get => _isEnabled;
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_isEnabled = value;
			}
		}

		// 读取答案功能启用状态
		public bool ReadAnswerEnabled
		{
			get => _readAnswerEnabled;
			set => _readAnswerEnabled = value;
		}

		// 是否从中国AI回复
		public bool ReplyFromChinaAI
		{
			get => _replyFromChinaAI;
			set => _replyFromChinaAI = value;
		}

		// 窗口宽度
		public double WindowWidth
		{
			get => _windWidth;
			set => _windWidth = value;
		}

		// 窗口高度
		public double WindowHeight
		{
			get => _windHeight;
			set => _windHeight = value;
		}

		// 背景透明度
		public double BgOpacity
		{
			get => _backgroundOpacity;
			set => _backgroundOpacity = value;
		}

		// 字体大小
		public double FontSize
		{
			get => _fontSize;
			set => _fontSize = value;
		}

		// 缓存最大数量
		public int CacheMaxCount
		{
			get => _cacheMaxCount;
			set => _cacheMaxCount = value;
		}

		// 命令字符串
		public string Cmd
		{
			get => _command;
			set => _command = value;
		}

		// 命令提示
		public string CmdTip
		{
			get => _commandTip;
			set => _commandTip = value;
		}

		// 命令提示启用状态
		public bool CmdTipEnabled
		{
			get => _cmdTipEnabled;
			set => _cmdTipEnabled = value;
		}

		// 显示忙碌状态功能启用状态
		public bool ShowBusyEnabled
		{
			get => _showBusyEnabled;
			set => _showBusyEnabled = value;
		}

		// 粉丝俱乐部最小等级
		public int MiniFansClubLevel
		{
			get => _minFansClubLevel;
			set => _minFansClubLevel = value;
		}

		// 最大发言次数
		public int SpeakMaxCount
		{
			get => _speakMaxCount;
			set => _speakMaxCount = value;
		}
	}
}
