using Iebcn.Live.Controls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Iebcn.Live.Helper
{
	public sealed class ChatBotHelper
    {
        public static string Hash;
		public static ChatBotWindow window;

		public static ObservableCollection<DanmuData> Users;

        public static bool IsBusy;

        public static List<BotResult> BotResultList;

        public static List<DanmuData> CacheChatDanmuList;

        public static List<string> AnchorSpeakList;

        public static List<DanmuData> AllChatDanmuList;
		public static List<DanmuData> KeyReplyChatDanmuList;
		public static List<DanmuData> CacheTksList;

        public event EventHandler<SpeakState> SpeakStateChange;
        // 添加数据
        public static void AddData(DanmuData data)
        {
            try
            {
				OnV(4, data);

				Users.Add(data);
                if (Users.Count > 3)
                {
                    Users.RemoveAt(0);
                }
                if (data.Type != 0)
                {
                    //if (data.Type == DanmuType.Gift || data.Type == DanmuType.EnterRoom || data.Type == DanmuType.Like || data.Type == DanmuType.Follow)
                    //{
                    //    CacheTksList.Add(data);
                    //    if (CacheTksList.Count > 50)
                    //    {
                    //        CacheTksList.RemoveAt(0);
                    //    }
                    //}
					if (data.Type == DanmuType.Like && Common.danmuSetting.ChatBot.OptTypes.LikeEnabled)
					{
						if (CacheTksList.Take(50).Count((DanmuData x) => x.UserNick == data.UserNick) > 1)
						{
							return;
						}
						CacheTksList.Add(data);
					}
					else if (data.Type == DanmuType.EnterRoom && Common.danmuSetting.ChatBot.OptTypes.EnterRoomEnabled)
					{
						CacheTksList.Add(data);
					}
					else if (data.Type == DanmuType.Follow && Common.danmuSetting.ChatBot.OptTypes.FollowEnabled)
					{
						CacheTksList.Add(data);
					}
					else if (data.Type == DanmuType.Gift && Common.danmuSetting.ChatBot.OptTypes.GiftEnabled)
					{
						CacheTksList.Add(data);
					}
					if (CacheTksList.Count > Common.danmuSetting.ChatBot.DanmuCacheMax)
					{
						CacheTksList.RemoveAt(0);
					}
				}
				else if (!Common.danmuSetting.ChatBot.ForbiddenWordsCheckEnabled || !Util.CheckIsForbiddenWords(data.PureMsg))
				{
                    CacheChatDanmuList.Add(data);
                    if (CacheChatDanmuList.Count > 5)
                    {
                        CacheChatDanmuList.RemoveAt(0);
                    }
					KeyReplyChatDanmuList.Add(data);
					if (KeyReplyChatDanmuList.Count > 50)
					{
						KeyReplyChatDanmuList.RemoveAt(0);
					}
                }
            }
            catch
            {
            }
        }
		private static void OnV(int int_0, DanmuData danmuData_0)
		{
			try
			{
				foreach (Match item in new Regex("\\d{" + int_0 + ",20}").Matches(danmuData_0.UserNick))
				{
					danmuData_0.UserNick = danmuData_0.UserNick.Replace(item.Value, "");
				}
			}
			catch
			{
			}
		}
		public static void ClearAllCache()
		{
			CacheChatDanmuList.Clear();
			CacheTksList.Clear();
			BotResultList.Clear();
			KeyReplyChatDanmuList.Clear();
		}
		// 添加主播发言
		public static void AddAnchorSpeak(string words)
        {
            AnchorSpeakList.Add(words);
        }
        // 测试播放礼物视频
        public static void TestPlayGiftVideo()
        {
			window?.TestPlayGiftVideo();

		}
		public static void ShowWindow()
		{
			if (window == null || window.IsClosed)
			{
				window = new ChatBotWindow();
			}
			window.Show();
			window.Activate();
		}
		public static async Task<string> GetHttpReplyAsync(string input)
		{
			// 构建请求地址
			string requestUrl = $"https://api.ownthink.com/bot?spoken={Uri.EscapeDataString(input)}";

			// 创建HttpClient实例
			using (HttpClient client = new HttpClient())
			{
				// 设置请求头信息
				client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
				client.DefaultRequestHeaders.Referrer = new Uri("https://www.ownthink.com/");

				// 发送GET请求
				try
				{
					// 获取响应内容字符串
					string responseContent = await client.GetStringAsync(requestUrl);

					// 反序列化响应数据
					dynamic jsonData = JsonConvert.DeserializeObject<object>(responseContent);

					// 返回数据文本
					if (jsonData != null && jsonData.Data != null && jsonData.Data.Info != null)
					{
						return jsonData.data.info.text;
					}
				}
				catch (Exception ex)
				{
					// 处理可能发生的异常
					Console.WriteLine($"请求API时发生错误：{ex.Message}");
				}
			}

			// 如果没有获取到有效的响应文本，则返回空字符串
			return string.Empty;
		}
        // 获取自定义HTTP回复
        public static async Task<string> GetCustHttpReply(string requestUrl)
        {
			using (HttpClient client = new HttpClient())
			{
				// 设置请求头信息
				client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
				client.DefaultRequestHeaders.Referrer = new Uri("https://www.iebcn.com/");

				// 发送GET请求
				try
				{
					// 获取响应内容字符串
					string responseContent = await client.GetStringAsync(requestUrl);

					// 反序列化响应数据
					dynamic jsonData = JsonConvert.DeserializeObject<object>(responseContent);

					// 返回数据文本
					if (jsonData != null && jsonData.Data != null && jsonData.Data.Info != null)
					{
						return jsonData.data.info.text;
					}
				}
				catch (Exception ex)
				{
					// 处理可能发生的异常
					Console.WriteLine($"请求API时发生错误：{ex.Message}");
				}
			}
            return "";
        }
        // 获取Tks格式化内容
        public static string GetTksFormtContent(DanmuData data)
        {
            if (data.Type != DanmuType.Gift && data.Type != DanmuType.EnterRoom && data.Type != DanmuType.Like && data.Type != DanmuType.Follow)
            {
                return data.ThksMsg;
            }
            ChatBot chatBot = Common.danmuSetting.ChatBot;
            _ = chatBot.TksConFormatGift;
            List<string> list = new List<string>();
            switch (data.Type)
            {
                case DanmuType.Gift:
                    list = (from x in chatBot.TksConFormatGift.Split('\n')
                            where x.Trim() != ""
                            select x).ToList();
                    break;
                case DanmuType.Like:
                    list = (from x in chatBot.TksConFormatLike.Split('\n')
                            where x.Trim() != ""
                            select x).ToList();
                    break;
                case DanmuType.EnterRoom:
                    list = (from x in chatBot.TksConFormatEnterRoom.Split('\n')
                            where x.Trim() != ""
                            select x).ToList();
                    break;
                case DanmuType.Follow:
                    list = (from x in chatBot.TksConFormatFollow.Split('\n')
                            where x.Trim() != ""
                            select x).ToList();
                    break;
            }
            if (list.Count <= 0)
            {
                return data.ThksMsg;
            }
            return list[Common.rnd.Next(0, list.Count)].Replace("{用户}", data.UserNick).Replace("{xxx}", data.UserNick).Replace("{礼物数量}", data.GiftCount.ToString() ?? "")
                .Replace("{礼物个数}", data.GiftCount.ToString() ?? "")
                .Replace("{礼物数}", data.GiftCount.ToString() ?? "")
                .Replace("{礼物名称}", data.GiftName)
                .Replace("{礼物名}", data.GiftName)
                .Replace("{当前时间}", DateTime.Now.ToString() ?? "")
                .Replace("{北京时间}", DateTime.Now.ToString() ?? "")
                .Replace("{时间}", DateTime.Now.ToString() ?? "");
        }

		static ChatBotHelper()
        {
            Hash = "";
            Users = new ObservableCollection<DanmuData>();
            IsBusy = false;
            BotResultList = new List<BotResult>();
            CacheChatDanmuList = new List<DanmuData>();
            AnchorSpeakList = new List<string>();
			KeyReplyChatDanmuList = new List<DanmuData>();
			AllChatDanmuList = new List<DanmuData>();
            CacheTksList = new List<DanmuData>();
        }
    }

}