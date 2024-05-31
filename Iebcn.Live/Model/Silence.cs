namespace Iebcn.Live
{
	public class Silence
	{
		private bool _isSilenceEnabled;

		// 私有字段，由编译器生成，表示是否启用文本消息
		private bool _useText;

		// 私有字段，由编译器生成，表示是否启用本地音频播放
		private bool _useLocalSound;

		// 私有字段，由编译器生成，表示检查时间间隔（秒）
		private double _checkInterval = 20.0;

		// 私有字段，由编译器生成，存储默认的文本内容
		private string _defaultMessage = "{当前时间}主播祝愿各位家人们财源广进！\r\n进场的观众老爷们记得加个关注啊！\r\n{当前时间}今天天气真不错！\r\n请还没有购买的朋友抓紧时间下单啊，机不可失失不再来！";

		// 私有字段，由编译器生成，表示随机读取文本
		private bool _rndReadText;

		// 私有字段，由编译器生成，表示随机播放音频
		private bool _rndPlayAudio;

		// 私有字段，由编译器生成，表示文本分组模式是否启用
		private bool _textGroupModeEnabled;

		// 私有字段，由编译器生成，表示音频分组模式是否启用
		private bool _audioGroupModeEnabled;

		// 私有字段，由编译器生成，表示文本分组解决方案
		private string _textGroupSolution = "1-2-3-4";

		// 私有字段，由编译器生成，表示音频分组解决方案
		private string _audioGroupSolution = "1-2-3-4";

		/// <summary>
		/// 获取或设置是否启用沉默功能
		/// </summary>
		public bool Enabled
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_isSilenceEnabled = false;
				}
				return _isSilenceEnabled;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_isSilenceEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置是否使用文本消息
		/// </summary>
		public bool UseText
		{
			get { return _useText; }
			set { _useText = value; }
		}

		/// <summary>
		/// 获取或设置是否使用本地音频播放
		/// </summary>
		public bool UseLocalSound
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_useLocalSound = false;
				}
				return _useLocalSound;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_useLocalSound = value;
			}
		}

		/// <summary>
		/// 获取或设置检查时间间隔（秒）
		/// </summary>
		public double CheckSeconds
		{
			get { return _checkInterval; }
			set { _checkInterval = value; }
		}

		/// <summary>
		/// 获取或设置默认的文本内容
		/// </summary>
		public string Content
		{
			get { return _defaultMessage; }
			set { _defaultMessage = value; }
		}

		/// <summary>
		/// 获取或设置是否随机读取文本
		/// </summary>
		public bool RndReadText
		{
			get { return _rndReadText; }
			set { _rndReadText = value; }
		}

		/// <summary>
		/// 获取或设置是否随机播放音频
		/// </summary>
		public bool RndPlayAudio
		{
			get { return _rndPlayAudio; }
			set { _rndPlayAudio = value; }
		}

		/// <summary>
		/// 获取或设置文本分组模式是否启用
		/// </summary>
		public bool TextGroupModeEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_textGroupModeEnabled = false;
				}
				return _textGroupModeEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_textGroupModeEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置音频分组模式是否启用
		/// </summary>
		public bool AudioGroupModeEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_audioGroupModeEnabled = false;
				}
				return _audioGroupModeEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_audioGroupModeEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置文本分组解决方案
		/// </summary>
		public string TextGroupSolution
		{
			get { return _textGroupSolution; }
			set { _textGroupSolution = value; }
		}

		/// <summary>
		/// 获取或设置音频分组解决方案
		/// </summary>
		public string AudioGroupSolution
		{
			get { return _audioGroupSolution; }
			set { _audioGroupSolution = value; }
		}
	}
}