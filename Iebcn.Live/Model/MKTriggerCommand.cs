namespace Iebcn.Live.ViewModel
{
	using System.Collections.Generic;

	public class MKTriggerCommand
	{
		// 弹幕类型，用于区分是礼物还是普通弹幕
		private DanmuType _danmuType = DanmuType.Gift;

		// 弹幕内容，例如礼物名称
		private string _danmuContent = "小心心";

		// 礼物数量
		private int _giftCount;

		// 鼠标键盘命令列表
		private List<MouseKeyboardCommand> _commandList = new List<MouseKeyboardCommand>();

		// 弹幕类型的属性
		public DanmuType DanmuType
		{
			get { return _danmuType; }
			set { _danmuType = value; }
		}

		// 弹幕内容的属性
		public string DanmuContent
		{
			get { return _danmuContent; }
			set { _danmuContent = value; }
		}

		// 礼物数量的属性
		public int GiftCount
		{
			get { return _giftCount; }
			set { _giftCount = value; }
		}

		// 鼠标键盘命令列表的属性
		public List<MouseKeyboardCommand> CommandList
		{
			get { return _commandList; }
			set { _commandList = value; }
		}

		// 弹幕描述，用于生成描述信息
		public string DMDescription
		{
			get
			{
				string description = $"{DanmuType} {DanmuContent}=";
				foreach (var command in CommandList)
				{
					description += command.ToString();
				}
				return description;
			}
		}
	}
}
