using Iebcn.Live.Controls;

namespace Iebcn.Live.Helper
{
	public class RenqiHelper
	{
		private static List<dynamic> _users; // 存储用户信息的列表

		public static bool StopFlag; // 停止标志

		private static RenqiWindow _renqiWindow; // 人气窗口

		/// <summary>
		/// 显示人气窗口
		/// </summary>
		public static void ShowWindow()
		{
			if (_renqiWindow == null || _renqiWindow.IsClosed)
			{
				_renqiWindow = new RenqiWindow();
			}
			_renqiWindow.Show();
			_renqiWindow.Activate();
		}

		/// <summary>
		/// 根据礼物名称获取礼物图片URL
		/// </summary>
		/// <param name="giftName">礼物名称</param>
		/// <returns>礼物图片URL</returns>
		public static string GetGitUrl(string giftName)
		{
			// 根据礼物名称进行条件判断并返回对应的图片URL
			// 这里使用switch语句可以提高代码的可读性
			switch (giftName.ToLower())
			{
				case "小心心":
					return "https://p6-webcast.douyinpic.com/img/webcast/0ea40b8376ef8157791b928a339ed9c9~tplv-obj.png";
				case "玫瑰":
					return "https://p3-webcast.douyinpic.com/img/webcast/a29d6cdc0abb7286fdd403915196eaa7.png~tplv-obj.png";
				default:
					if (giftName.Contains("入团卡"))
					{
						return "http://p6-webcast.douyinpic.com/img/webcast/698373dfdac86a90b54facdc38698cbc~tplv-obj.png";
					}
					else if (!giftName.Contains("大啤酒") && !giftName.Contains("棒棒糖"))
					{
						return "https://p3-webcast.douyinpic.com/img/webcast/ca0707852589ae08c17b0d28fa250125.png~tplv-obj.png";
					}
					return "https://p6-webcast.douyinpic.com/img/webcast/a24b3cc863742fd4bc3de0f53dac4487.png~tplv-obj.png";
			}
		}

		/// <summary>
		/// 加载用户信息
		/// </summary>
		public static void LoadUsers()
		{
			_users = new List<object>();
			var lines = Resource1.Users.Split('\n')
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.Select(x => x.Split('|'))
				.ToList();
			foreach (var line in lines)
			{
				_users.Add(new
				{
					UserNick = line[0].Trim(),
					UserHeadPic = line[1].Trim()
				});
			}
		}

		/// <summary>
		/// 获取一个随机用户信息
		/// </summary>
		/// <returns>随机用户信息</returns>
		public static dynamic GetOneUser()
		{
			if (_users == null || _users.Count == 0)
			{
				return null;
			}
			return _users[Common.rnd.Next(0, _users.Count)];
		}

		/// <summary>
		/// 格式化用户昵称
		/// </summary>
		/// <param name="nick">用户昵称</param>
		/// <param name="len">最大长度</param>
		/// <returns>格式化后的昵称</returns>
		public static string FormatUserNick(string nick, int len)
		{
			if (nick.Length > len)
			{
				return nick.Substring(0, len);
			}
			return nick;
		}

		/// <summary>
		/// 格式化匿名用户昵称
		/// </summary>
		/// <param name="nick">用户昵称</param>
		/// <returns>匿名昵称</returns>
		public static string FormatUserNickAnonymous(string nick)
		{
			return nick.Substring(0, 1) + "***";
		}

		/// <summary>
		/// 验证设置的有效性
		/// </summary>
		public static void ValidateSettings()
		{
			// 确保设置中的最小值不大于最大值
			SetMaxIfGreaterThanMin(Common.danmuSetting.Renqi.BuyMiniSeconds, Common.danmuSetting.Renqi.BuyMaxSeconds);
			SetMaxIfGreaterThanMin(Common.danmuSetting.Renqi.EnterRoomMiniSeconds, Common.danmuSetting.Renqi.EnterRoomMaxSeconds);
			SetMaxIfGreaterThanMin(Common.danmuSetting.Renqi.GiftMiniSeconds, Common.danmuSetting.Renqi.GiftMaxSeconds);
			SetMaxIfGreaterThanMin(Common.danmuSetting.Renqi.GiftMinCount, Common.danmuSetting.Renqi.GiftMaxCount);
		}
		private static void SetMaxIfGreaterThanMin(int min, int max)
		{
			if (min > max)
			{
				max = min;
			}
		}
	}
}