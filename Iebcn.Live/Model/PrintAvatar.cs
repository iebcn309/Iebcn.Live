namespace Iebcn.Live.ViewModel
{
	public class PrintAvatar
	{
		// 头像显示功能启用状态
		private bool _isAvatarEnabled;

		// 背景颜色为绿色
		private bool _isGreenBackground;

		// 头像边框显示状态
		private bool _hasBorder;

		// 声音提示功能启用状态
		private bool _isSoundEnabled;

		// 文字提示功能启用状态
		private bool _isTextShowEnabled;

		// 选项类型
		private OptTypes _optType;

		// 读取答案功能启用状态
		private bool _isReadAnswerEnabled;

		// 窗口高度
		private double _windowHeight;

		// 背景透明度
		private double _backgroundOpacity;

		// 字体大小
		private double _fontSize;

		// 命令字符串
		private string _command;

		// 构造函数
		public PrintAvatar()
		{
			// 初始化属性值
			_isAvatarEnabled = true;
			_isGreenBackground = true;
			_hasBorder = true;
			_isSoundEnabled = true;
			_isTextShowEnabled = true;
			_optType = new OptTypes();
			_isReadAnswerEnabled = false;
			_windowHeight = 850.0;
			_backgroundOpacity = 1.0;
			_fontSize = 14.0;
			_command = "GPT:";
		}

		// 头像显示功能启用状态
		public bool Enabled
		{
			get => _isAvatarEnabled;
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_isAvatarEnabled = value;
			}
		}

		// 背景颜色为绿色
		public bool IsGreenBackground
		{
			get => _isGreenBackground;
			set => _isGreenBackground = value;
		}

		// 头像边框显示状态
		public bool HasBorder
		{
			get => _hasBorder;
			set => _hasBorder = value;
		}

		// 声音提示功能启用状态
		public bool SoundEnabled
		{
			get => _isSoundEnabled;
			set => _isSoundEnabled = value;
		}

		// 文字提示功能启用状态
		public bool IsTextShowEnabled
		{
			get => _isTextShowEnabled;
			set => _isTextShowEnabled = value;
		}

		// 选项类型
		public OptTypes OptTypes
		{
			get => _optType;
			set => _optType = value;
		}

		// 读取答案功能启用状态
		public bool IsReadAnswerEnabled
		{
			get => _isReadAnswerEnabled;
			set => _isReadAnswerEnabled = value;
		}

		// 窗口高度
		public double WindowHeight
		{
			get => _windowHeight;
			set => _windowHeight = value;
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

		// 命令字符串
		public string Command
		{
			get => _command;
			set => _command = value;
		}
	}
}
