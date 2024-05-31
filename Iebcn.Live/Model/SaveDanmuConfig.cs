namespace Iebcn.Live
{
	/// <summary>
	/// 保存弹幕配置
	/// </summary>
	public class SaveDanmuConfig
	{
		private bool _autoSaveDanmuEnabled;
		private bool _folderUseRoomIdEnabled;
		private OptTypes optTypes = new OptTypes();
		/// <summary>
		/// 是否启用自动保存弹幕
		/// </summary>
		public bool AutoSaveDanmuEnabled
		{
			get
			{
				if (Common.VIPLevel <= 0)
				{
					_autoSaveDanmuEnabled = false;
				}
				return _autoSaveDanmuEnabled;
			}
			set
			{
				if (Common.VIPLevel <= 0)
				{
					value = false;
				}
				_autoSaveDanmuEnabled = value;
			}
		}
		/// <summary>
		/// 是否使用房间号作为文件夹名
		/// </summary>
		public bool FolderUseRoomIdEnabled
		{
			get { return _folderUseRoomIdEnabled; }
			set { _folderUseRoomIdEnabled = value; }
		}
		/// <summary>
		/// 操作类型
		/// </summary>
		public OptTypes OptTypes
		{
			get { return optTypes; }
			set { optTypes = value; }
		}
	}
}