using Iebcn.Live.Controls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Iebcn.Live.Helper
{
	public sealed class RoomRankHelper
	{
		// 定义在线排行榜数据的可观察集合
		public static ObservableCollection<DanmuData> OnlineRankList;

		// 定义房间排名窗口的静态引用
		private static RoomRankWindow _rankWindow;

		// 显示排名窗口的方法
		public static void ShowRankWindow()
		{
			// 检查排名窗口是否已关闭，如果是，则创建新窗口
			if (_rankWindow == null || _rankWindow.IsClosed)
			{
				_rankWindow = new RoomRankWindow();
			}

			// 显示并激活窗口
			_rankWindow.Show();
			_rankWindow.Activate();
		}

		// 解析在线排名数据的方法
		public static async Task ParseOnlineRankDataAsync(Stream stream)
		{
			// 清空现有的排名数据
			OnlineRankList.Clear();
			string dataString = "";
			// 使用StreamReader读取流数据
			using (StreamReader streamReader = new StreamReader(stream))
			{
				dataString = await streamReader.ReadToEndAsync();
			}               // 反序列化JSON数据
			dynamic parsedData = JsonConvert.DeserializeObject<dynamic>(dataString);

			// 遍历排名数据并添加到集合中
			foreach (var item in parsedData.data.ranks)
			{
				OnlineRankList.Add(new DanmuData
				{
					UserId = item.user.id,
					UserNick = item.user.nickname,
					UserHeadPic = item.user.avatar_thumb.url_list[0],
					UserDisplayId = item.user.display_id,
					SecUid = item.user.sec_uid
				});
			}
		}

		// 静态构造函数，初始化静态成员
		static RoomRankHelper()
		{
			OnlineRankList = new ObservableCollection<DanmuData>();
			_rankWindow = null;
		}
	}
}
