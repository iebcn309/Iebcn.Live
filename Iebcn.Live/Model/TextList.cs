using System.Collections.ObjectModel;
using System.Windows.Media;


namespace Iebcn.Live.ViewModel
{

	public class TextList
	{
		// 背景颜色
		private SolidColorBrush _backBrush = new SolidColorBrush(Color.FromRgb(14, 96, 124));

		// 边框颜色
		private SolidColorBrush _borderBrush = new SolidColorBrush(Color.FromRgb(54, 166, 203));

		// 字体颜色
		private SolidColorBrush _fontBrush = new SolidColorBrush(Colors.White);

		// 是否显示页面背景
		private bool _showPageBack = true;

		// 边框大小
		private double _borderSize = 1.0;

		// 边框圆角大小
		private double _borderRadius = 10.0;

		// 页面背景透明度
		private double _backOpacity = 0.4;

		// 字体大小
		private double _fontSize = 16.0;

		// 是否显示图片
		private bool _showPic = true;

		// 垂直滚动速度
		private double _verticalScrollSpeed = 9.0;

		// 列表项宽度
		private double _itemWidth = 300.0;

		// 列表项高度
		private double _itemHeight = 50.0;

		// 文本信息列表
		private ObservableCollection<TextInfo> _textList = new ObservableCollection<TextInfo>
	{
		new TextInfo(),
		new TextInfo(),
		new TextInfo()
	};

		// 背景颜色的属性
		public SolidColorBrush BackBrush
		{
			get { return _backBrush; }
			set { _backBrush = value; }
		}

		// 边框颜色的属性
		public SolidColorBrush BorderBrush
		{
			get { return _borderBrush; }
			set { _borderBrush = value; }
		}

		// 字体颜色的属性
		public SolidColorBrush FontBrush
		{
			get { return _fontBrush; }
			set { _fontBrush = value; }
		}

		// 是否显示页面背景的属性
		public bool ShowPageBack
		{
			get { return _showPageBack; }
			set { _showPageBack = value; }
		}

		// 边框大小的属性
		public double BorderSize
		{
			get { return _borderSize; }
			set { _borderSize = value; }
		}

		// 边框圆角大小的属性
		public double BorderRadius
		{
			get { return _borderRadius; }
			set { _borderRadius = value; }
		}

		// 页面背景透明度的属性
		public double BackOpacity
		{
			get { return _backOpacity; }
			set { _backOpacity = value; }
		}

		// 字体大小的属性
		public double FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		// 是否显示图片的属性
		public bool ShowPic
		{
			get { return _showPic; }
			set { _showPic = value; }
		}

		// 垂直滚动速度的属性
		public double VerticalScrollSpeed
		{
			get { return _verticalScrollSpeed; }
			set { _verticalScrollSpeed = value; }
		}

		// 列表项宽度的属性
		public double ItemWidth
		{
			get { return _itemWidth; }
			set { _itemWidth = value; }
		}

		// 列表项高度的属性
		public double ItemHeight
		{
			get { return _itemHeight; }
			set { _itemHeight = value; }
		}

		// 文本信息列表的属性
		public ObservableCollection<TextInfo> List
		{
			get { return _textList; }
			set { _textList = value; }
		}
	}
}
