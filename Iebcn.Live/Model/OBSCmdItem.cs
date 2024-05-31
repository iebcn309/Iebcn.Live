
namespace Iebcn.Live.ViewModel
{
	public class OBSCmdItem
	{
		// 弹幕或礼物的类型
		private DanmuType type;

		// 礼物的名称
		private string giftName;

		// 弹幕的内容
		private string chatMessage;

		// 场景的名称
		private string sceneName;

		// 场景素材的名称
		private string sceneItemName;

		// 指令1是否开启
		private bool cmd1Enabled;

		// 指令2是否开启
		private bool cmd2Enabled;

		// 指令之间的最小等待时间（秒）
		private double minWaitSeconds;

		/// <summary>
		/// 获取或设置弹幕或礼物的类型。
		/// </summary>
		public DanmuType DType
		{
			get { return type; }
			set { type = value; }
		}

		/// <summary>
		/// 获取或设置礼物的名称。
		/// </summary>
		public string GiftName
		{
			get { return giftName; }
			set { giftName = value; }
		}

		/// <summary>
		/// 获取或设置弹幕的内容。
		/// </summary>
		public string ChatWord
		{
			get { return chatMessage; }
			set { chatMessage = value; }
		}

		/// <summary>
		/// 获取或设置场景的名称。
		/// </summary>
		public string Sence
		{
			get { return sceneName; }
			set { sceneName = value; }
		}

		/// <summary>
		/// 获取或设置场景素材的名称。
		/// </summary>
		public string SenceItem
		{
			get { return sceneItemName; }
			set { sceneItemName = value; }
		}

		/// <summary>
		/// 获取或设置指令1是否开启。
		/// </summary>
		public bool Cmd1Open
		{
			get { return cmd1Enabled; }
			set { cmd1Enabled = value; }
		}

		/// <summary>
		/// 获取或设置指令2是否开启。
		/// </summary>
		public bool Cmd2Open
		{
			get { return cmd2Enabled; }
			set { cmd2Enabled = value; }
		}

		/// <summary>
		/// 获取或设置指令之间的最小等待时间（秒）。
		/// </summary>
		public double CmdLastSeconds
		{
			get { return minWaitSeconds; }
			set { minWaitSeconds = value; }
		}

		/// <summary>
		/// 获取命令描述信息。
		/// </summary>
		/// <returns>返回格式化的命令描述字符串。</returns>
		public string CmdDesc
		{
			get
			{
				string visibility1 = cmd1Enabled ? "显示" : "隐藏";
				string visibility2 = cmd2Enabled ? "显示" : "隐藏";
				string itemType = DType switch
				{
					DanmuType.Chat => "弹幕",
					DanmuType.Gift => "礼物",
					DanmuType.Like => "点赞",
					_ => "未知类型"
				};

				return $"{itemType}: {GiftName} {ChatWord} -> 场景[{Sence}]素材[{SenceItem}] {visibility1} 等待{CmdLastSeconds}秒后 {visibility2}";
			}
		}
	}
}
