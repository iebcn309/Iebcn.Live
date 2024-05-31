namespace Iebcn.Live.ViewModel
{
	public class Live2DRole
	{
		// 是否启用自定义弹幕词
		private bool enableCustomWords;

		// 角色的选项类型
		private OptTypes optType;

		// 角色的ID
		private int roleId;

		// 角色图片的URL地址
		private string rolePicUrl;

		// 弹幕显示间隔（秒）
		private int displayInterval;

		// 自定义弹幕词
		private string customWords;

		/// <summary>
		/// 获取或设置是否启用自定义弹幕词，根据VIP等级进行判断
		/// </summary>
		public bool CustWordsEnabled
		{
			get { return enableCustomWords; }
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				enableCustomWords = value;
			}
		}

		/// <summary>
		/// 获取或设置角色的选项类型
		/// </summary>
		public OptTypes OptType
		{
			get { return optType; }
			set { optType = value; }
		}

		/// <summary>
		/// 获取或设置角色的ID
		/// </summary>
		public int RoleId
		{
			get { return roleId; }
			set { roleId = value; }
		}

		/// <summary>
		/// 获取或设置角色图片的URL地址
		/// </summary>
		public string RolePicUrl
		{
			get { return rolePicUrl; }
			set { rolePicUrl = value; }
		}

		/// <summary>
		/// 获取或设置弹幕显示间隔（秒）
		/// </summary>
		public int IntervalSeconds
		{
			get { return displayInterval; }
			set { displayInterval = value; }
		}

		/// <summary>
		/// 获取或设置自定义弹幕词
		/// </summary>
		public string Words
		{
			get { return customWords; }
			set { customWords = value; }
		}
	}
}
