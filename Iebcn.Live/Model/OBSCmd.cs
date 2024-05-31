using System.Collections.ObjectModel;

namespace Iebcn.Live.ViewModel
{
	public class OBSCmd
	{
		// 命令是否启用的内部标志
		private bool isEnabled;

		// OBS服务器的IP地址
		private string obsHost = "127.0.0.1";

		// OBS服务器的端口号
		private int obsPort = 4455;

		// OBS服务器的密码
		private string obsPass = "";

		// 礼物执行的缓存最大数量
		private int cacheMax = 10;

		// 礼物是否按数量执行的标志
		private bool giftExecuteByCount = true;

		// 保存的命令列表
		private ObservableCollection<OBSCmdItem> savedCmdList = new ObservableCollection<OBSCmdItem>();

		/// <summary>
		/// 获取或设置命令是否启用。如果VIP等级小于2，则不允许修改。
		/// </summary>
		public bool Enabled
		{
			get
			{
				// 如果VIP等级小于2，则返回false并设置Enabled为false
				if (Common.VIPLevel < 2)
				{
					isEnabled = false;
				}
				// 返回当前的Enabled状态
				return isEnabled;
			}
			set
			{
				// 如果VIP等级小于2，则不允许修改
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				// 设置Enabled状态
				isEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置OBS服务器的IP地址。
		/// </summary>
		public string Host
		{
			get { return obsHost; }
			set { obsHost = value; }
		}

		/// <summary>
		/// 获取或设置OBS服务器的端口号。
		/// </summary>
		public int Port
		{
			get { return obsPort; }
			set { obsPort = value; }
		}

		/// <summary>
		/// 获取或设置OBS服务器的密码。
		/// </summary>
		public string Pass
		{
			get { return obsPass; }
			set { obsPass = value; }
		}

		/// <summary>
		/// 获取或设置礼物执行的缓存最大数量。
		/// </summary>
		public int CacheMax
		{
			get { return cacheMax; }
			set { cacheMax = value; }
		}

		/// <summary>
		/// 获取或设置礼物是否按数量执行的标志。
		/// </summary>
		public bool GiftExcuteByCount
		{
			get { return giftExecuteByCount; }
			set { giftExecuteByCount = value; }
		}

		/// <summary>
		/// 获取保存的命令列表。
		/// </summary>
		public ObservableCollection<OBSCmdItem> SavedCmdList
		{
			get { return savedCmdList; }
			set { savedCmdList = value; }
		}

	}
}
