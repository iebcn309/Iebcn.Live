namespace Iebcn.Live.ViewModel
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Windows;
	using System.Windows.Media;

	public class GiftPK2 : INotifyPropertyChanged
	{
		// 定义事件
		public event PropertyChangedEventHandler PropertyChanged;

		// 私有字段，用于存储属性值
		private string _giftNameA;
		private string _giftNameB;
		private string _giftPicA;
		private string _giftPicB;
		private string _giftDescA;
		private string _giftDescB;
		private double _giftPointA;
		private double _giftPointB;
		private GridLength _giftWidthA;
		private GridLength _giftWidthB;
		private bool _showCounterBar;
		private SolidColorBrush _fontColor;
		private SolidColorBrush _progressBgColorA;
		private SolidColorBrush _progressBgColorB;
		private bool _relayEnabledA;
		private bool _relayEnabledB;
		private string _relayCommandA;
		private string _relayCommandB;

		// 构造函数
		public GiftPK2()
		{
			// 初始化属性值
			_giftNameA = "小心心";
			_giftNameB = "大啤酒";
			_giftPicA = "https://p3-webcast.douyinpic.com/img/webcast/0ea40b8376ef8157791b928a339ed9c9~tplv-obj.png";
			_giftPicB = "https://p6-webcast.douyinpic.com/img/webcast/a24b3cc863742fd4bc3de0f53dac4487.png~tplv-obj.png";
			_giftDescA = "A测试描述...";
			_giftDescB = "B测试描述...";
			_giftPointA = 1.0;
			_giftPointB = 1.0;
			_giftWidthA = new GridLength(5.0, GridUnitType.Star);
			_giftWidthB = new GridLength(5.0, GridUnitType.Star);
			_showCounterBar = true;
			_fontColor = new SolidColorBrush(Colors.Yellow);
			_progressBgColorA = new SolidColorBrush(Colors.Red);
			_progressBgColorB = new SolidColorBrush(Colors.Blue);
			_relayEnabledA = true;
			_relayEnabledB = true;
			_relayCommandA = "L1-K0.5-G5";
			_relayCommandB = "L2-K0.5-G5";
		}

		// 礼物A名称属性
		public string GiftNameA
		{
			get { return _giftNameA; }
			set { SetProperty(ref _giftNameA, value); }
		}

		// 礼物B名称属性
		public string GiftNameB
		{
			get { return _giftNameB; }
			set { SetProperty(ref _giftNameB, value); }
		}

		// 礼物A图片属性
		public string GiftPicA
		{
			get { return _giftPicA; }
			set { SetProperty(ref _giftPicA, value); }
		}

		// 礼物B图片属性
		public string GiftPicB
		{
			get { return _giftPicB; }
			set { SetProperty(ref _giftPicB, value); }
		}

		// 礼物A描述属性
		public string GiftDescA
		{
			get { return _giftDescA; }
			set { SetProperty(ref _giftDescA, value); }
		}

		// 礼物B描述属性
		public string GiftDescB
		{
			get { return _giftDescB; }
			set { SetProperty(ref _giftDescB, value); }
		}

		// 礼物A点数属性
		public double GiftPointA
		{
			get { return _giftPointA; }
			set { SetProperty(ref _giftPointA, value); }
		}

		// 礼物B点数属性
		public double GiftPointB
		{
			get { return _giftPointB; }
			set { SetProperty(ref _giftPointB, value); }
		}

		// 礼物A宽度属性
		public GridLength GiftWidthA
		{
			get { return _giftWidthA; }
			set { SetProperty(ref _giftWidthA, value); }
		}

		// 礼物B宽度属性
		public GridLength GiftWidthB
		{
			get { return _giftWidthB; }
			set { SetProperty(ref _giftWidthB, value); }
		}

		// 显示计数条属性
		public bool ShowCounterBar
		{
			get { return _showCounterBar; }
			set { SetProperty(ref _showCounterBar, value); }
		}

		// 字体颜色属性
		public SolidColorBrush FontColor
		{
			get { return _fontColor; }
			set { SetProperty(ref _fontColor, value); }
		}

		// 礼物A进度背景颜色属性
		public SolidColorBrush ProgressBgColorA
		{
			get { return _progressBgColorA; }
			set { SetProperty(ref _progressBgColorA, value); }
		}

		// 礼物B进度背景颜色属性
		public SolidColorBrush ProgressBgColorB
		{
			get { return _progressBgColorB; }
			set { SetProperty(ref _progressBgColorB, value); }
		}

		// 礼物A继电器启用属性
		public bool RelayEnabledA
		{
			get { return _relayEnabledA; }
			set { SetProperty(ref _relayEnabledA, value); }
		}

		// 礼物B继电器启用属性
		public bool RelayEnabledB
		{
			get { return _relayEnabledB; }
			set { SetProperty(ref _relayEnabledB, value); }
		}

		// 礼物A继电器命令属性
		public string RelayCommandA
		{
			get { return _relayCommandA; }
			set { SetProperty(ref _relayCommandA, value); }
		}

		// 礼物B继电器命令属性
		public string RelayCommandB
		{
			get { return _relayCommandB; }
			set { SetProperty(ref _relayCommandB, value); }
		}

		// 属性更改通知
		protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value)) return;
			backingStore = value;
			OnPropertyChanged(propertyName);
		}

		// 触发属性更改事件
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
