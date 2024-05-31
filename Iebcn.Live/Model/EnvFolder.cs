namespace Iebcn.Live.ViewModel
{
	// 环境文件夹类
	public class EnvFolder
	{
		// 文件夹名，默认为"Iebcn.Live.ControlsSendDanmu_Browser"
		public string FolderName { get; set; } = "Iebcn.Live.ControlsSendDanmu_Browser";
		// 是否正在使用
		public bool InUse { get; set; }
		// 构造函数
		public EnvFolder(string folderName, bool inUse)
		{
			// 初始化文件夹名和是否正在使用
			FolderName = folderName;
			InUse = inUse;
		}
	}
}
