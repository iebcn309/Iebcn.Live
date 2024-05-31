namespace Iebcn.Live
{
	using System.Text.Json.Serialization;
	using System.Windows.Media;

	public class DanmuPlayerConfig
	{
		private OptTypes _optTypes = new OptTypes();
		private double _pageBackgroundOpacity = 0.5;
		private double _pageWidth = 500.0;
		private double _pageHeight = 680.0;
		private double _danmuFontSize = 16.0;
		private bool _topmost = true;
		private bool _gameTopmost;
		private int _speed = 10000;
		private int _intervalSeconds;
		private bool _roomInfoEnabled = true;
		private bool _verticalEnabled;
		private bool _transparentBgEnabled;
		private FontFamily _fontFamily = new FontFamily("Microsoft YaHei");
		private int _showCount = 1;
		private int _int32_0;

		public OptTypes OptTypes
		{
			get => _optTypes;
			set => _optTypes = value;
		}

		public double PageBackgroundOpacity
		{
			get => _pageBackgroundOpacity;
			set => _pageBackgroundOpacity = value;
		}

		public double PageWidth
		{
			get => _pageWidth;
			set => _pageWidth = value;
		}

		public double PageHeight
		{
			get => _pageHeight;
			set => _pageHeight = value;
		}

		public double TextBlockWidth => PageWidth - 12.0;

		public double DanmuFontSize
		{
			get => _danmuFontSize;
			set => _danmuFontSize = value;
		}

		public bool Topmost
		{
			get => _topmost;
			set => _topmost = value;
		}

		public bool GameTopmost
		{
			get => _gameTopmost;
			set => _gameTopmost = value;
		}

		public int Speed
		{
			get => _speed;
			set => _speed = value;
		}

		public int IntervalSeconds
		{
			get => _intervalSeconds;
			set => _intervalSeconds = value;
		}

		public bool RoomInfoEnabled
		{
			get => _roomInfoEnabled;
			set => _roomInfoEnabled = value;
		}

		public bool VerticalEnabled
		{
			get => _verticalEnabled;
			set => _verticalEnabled = value;
		}

		public bool TransparentBgEnabled
		{
			get => _transparentBgEnabled;
			set => _transparentBgEnabled = value;
		}
		[JsonIgnore]
		public FontFamily FontFamily
		{
			get => _fontFamily;
			set => _fontFamily = value;
		}

		public int ShowCount
		{
			get => _showCount;
			set => _showCount = value;
		}

		public int MiniV5Level
		{
			get => Common.VIPLevel < 2 ? 0 : _int32_0;
			set => _int32_0 = Common.VIPLevel < 2 ? 0 : value;
		}

		//public int MiniFansClubLevel
		//{
		//	get => Common.VIPLevel < 2 ? 0 : _miniFansClubLevel;
		//	set => _miniFansClubLevel = Common.VIPLevel < 2 ? 0 : value;
		//}
	}
}
