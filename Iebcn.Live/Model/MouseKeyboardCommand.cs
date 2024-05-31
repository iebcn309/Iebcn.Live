namespace Iebcn.Live.ViewModel
{
	public class MouseKeyboardCommand
	{
		// 命令类型，1-鼠标操作，2-键盘操作，3-延时，4-发送文本
		private int _commandType = 1;

		// 鼠标点击类型，例如左键点击、右键点击等
		private MouseClickType _clickType;

		// 鼠标点击位置的X坐标
		private int _clickX = 50;

		// 鼠标点击位置的Y坐标
		private int _clickY = 50;

		// 按下的键盘按键，以逗号分隔
		private string[] _pressedKeys = new string[1] { "a" };

		// 延时的秒数
		private double _delaySeconds = 1.0;

		// 发送的文本内容
		private string _sendText = "hello";

		// 命令类型的属性
		public int CMDType
		{
			get { return _commandType; }
			set { _commandType = value; }
		}
		public string String_0 => CmdDescription;

		// 鼠标点击类型的属性
		public MouseClickType ClickType
		{
			get { return _clickType; }
			set { _clickType = value; }
		}

		// 鼠标点击位置的X坐标属性
		public int ClickX
		{
			get { return _clickX; }
			set { _clickX = value; }
		}

		// 鼠标点击位置的Y坐标属性
		public int ClickY
		{
			get { return _clickY; }
			set { _clickY = value; }
		}

		// 按下的键盘按键属性
		public string[] PressKeys
		{
			get { return _pressedKeys; }
			set { _pressedKeys = value; }
		}

		// 延时的秒数属性
		public double DelaySeconds
		{
			get { return _delaySeconds; }
			set { _delaySeconds = value; }
		}

		// 发送的文本内容属性
		public string SendText
		{
			get { return _sendText; }
			set { _sendText = value; }
		}

		// 命令描述，根据命令类型动态生成
		public string CmdDescription
		{
			get
			{
				switch (CMDType)
				{
					case 1:
						return $"鼠标:{ClickType}(X:{ClickX}, Y:{ClickY})";
					case 2:
						return $"键盘:{string.Join(" + ", PressKeys)}";
					case 3:
						return $"延时:{DelaySeconds}秒";
					case 4:
						return $"发文字:{SendText}";
					default:
						return "";
				}
			}
		}
	}
}
