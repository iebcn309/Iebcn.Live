namespace Iebcn.Live.Helper
{
	public class Emoji
	{
		// 私有字段，用于存储表情符号的显示名称
		private string _displayName;

		// 私有字段，用于存储表情符号的图片URL
		private string _picUrl;

		/// <summary>
		/// 表情符号的显示名称
		/// </summary>
		public string DisplayName
		{
			get { return _displayName; }
			set { _displayName = value; }
		}

		/// <summary>
		/// 表情符号的图片URL
		/// </summary>
		public string PicUrl
		{
			get { return _picUrl; }
			set { _picUrl = value; }
		}

		/// <summary>
		/// 构造函数，初始化一个新的Emoji对象
		/// </summary>
		public Emoji()
		{
			// 默认构造函数，可以留空
		}

		/// <summary>
		/// 构造函数，通过显示名称和图片URL初始化一个新的Emoji对象
		/// </summary>
		/// <param name="displayName">表情符号的显示名称</param>
		/// <param name="picUrl">表情符号的图片URL</param>
		public Emoji(string displayName, string picUrl)
		{
			DisplayName = displayName;
			PicUrl = picUrl;
		}
	}
}