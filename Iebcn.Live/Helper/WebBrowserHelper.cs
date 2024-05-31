using Google.Protobuf.Collections;
using Iebcn.Live.ViewModel;
using KuaiShouPack;
using Newtonsoft.Json;
using ProtoBuf;
using System.IO;
using System.Text.Json.Nodes;
using static Iebcn.Live.RoomUserSeqMessage;

namespace Iebcn.Live.Helper
{
	public class WebBrowserHelper
	{
		static Dictionary<string, Tuple<int, DateTime>> giftCountCache = new Dictionary<string, Tuple<int, DateTime>>();
		public static event EventHandler<DanmuData> DanmuDataChanged;
        private static List<DanmuData> Ky0 = new List<DanmuData>();

        public static void ParseDanmuData(string json)
        {
            JsonNode jToken = JsonNode.Parse(json)["response"]["payloadData"];
            object obj = jToken != null ? jToken.ToString() : "";
            byte[] data = Convert.FromBase64String((string)obj);
            switch (Common.CurrLivePlatform)
			{
				case LivePlatform.Douyin:
                    WssResponse wssResponse = Serializer.Deserialize<WssResponse>(new ReadOnlyMemory<byte>(data));
                    if (wssResponse == null) return;
                    var response = Serializer.Deserialize<Response>(new ReadOnlyMemory<byte>(Util.gzipDecompress(wssResponse.Payload)));
                    response.Messages.ForEach(f => ParseMessage(f));
                    break;
                case LivePlatform.KuaiShou:
                    Ky0.Clear();
                    SocketMessage socketMessage = SocketMessage.Parser.ParseFrom(data);
                    if (socketMessage.PayloadType == PayloadType.CsEnterRoom || socketMessage.PayloadType == PayloadType.ScEnterRoomAck)
                    {
                        return;
                    }
                    if (socketMessage.PayloadType != PayloadType.ScFeedPush)
                    {
                        _ = socketMessage.PayloadType.ToString() != "GZIP";
                        return;
                    }
                    SCWebFeedPush sCWebFeedPush = SCWebFeedPush.Parser.ParseFrom(socketMessage.Payload.ToArray());
					AppLog.AddLog(JsonConvert.SerializeObject(sCWebFeedPush));
                    Common.RoomData.OnlineUser = sCWebFeedPush.DisplayWatchingCount ?? "";
                    Common.RoomData.TotalLike = sCWebFeedPush.DisplayLikeCount ?? "";
                    _ = sCWebFeedPush.SystemNoticeFeeds.Count;
                    if (sCWebFeedPush.CommentFeeds.Count <= 0)
                    {
                        if (sCWebFeedPush.GiftFeeds.Count > 0)
                        {
                            DyB(sCWebFeedPush.GiftFeeds);
                        }
                        else if (sCWebFeedPush.LikeFeeds.Count > 0)
                        {
                            YyT(sCWebFeedPush.LikeFeeds);
                        }
                        else if (sCWebFeedPush.ShareFeeds.Count > 0)
                        {
                            jyK(sCWebFeedPush.ShareFeeds);
                        }
                    }
                    else
                    {
                        fym(sCWebFeedPush.CommentFeeds);
                    }
                    if (Ky0.Count <= 0)
                    {
                        return;
                    }
                    foreach (DanmuData item in Ky0)
                    {
                        item.Timestamp = DateTime.Now;
                        DanmuDataChanged?.Invoke(null, item);
                    }
                    break;
            }

		}
        private static void fym(RepeatedField<WebCommentFeed> repeatedField_0)
        {
            foreach (WebCommentFeed item in repeatedField_0)
            {
                DanmuData danmuData = new DanmuData();
                danmuData.Type = DanmuType.Chat;
                danmuData.UserDisplayId = item.User.PrincipalId ?? "";
                danmuData.UserNick = item.User?.UserName;
                _ = item.User?.HeadUrl;
                danmuData.Msg = item.User?.UserName + ":" + item.Content;
                Ky0.Add(danmuData);
            }
        }
        private static void DyB(RepeatedField<WebGiftFeed> repeatedField_0)
        {
            foreach (WebGiftFeed item in repeatedField_0)
            {
                GiftInfo giftById = GiftHelper.GetGiftById((int)item.GiftId);
                if (giftById != null)
                {
                    DanmuData danmuData = new DanmuData();
                    danmuData.Type = DanmuType.Gift;
                    danmuData.UserDisplayId = item.User.PrincipalId ?? "";
                    danmuData.UserNick = item.User?.UserName;
                    danmuData.Msg = item.User?.UserName + ":送出" + item.ComboCount + "个" + giftById.Name;
                    danmuData.GiftName = giftById.Name;
                    danmuData.GiftUrl = giftById.Image;
                    _ = item.User?.HeadUrl;
                    danmuData.GiftCount = (int)item.ComboCount;
                    Ky0.Add(danmuData);
                }
            }
        }

        private static void YyT(RepeatedField<WebLikeFeed> repeatedField_0)
        {
            foreach (WebLikeFeed item in repeatedField_0)
            {
                DanmuData danmuData = new DanmuData();
                danmuData.Type = DanmuType.Like;
                danmuData.UserDisplayId = item.User.PrincipalId ?? "";
                danmuData.UserNick = item.User?.UserName;
                danmuData.Msg = item.User?.UserName + ":点赞了主播";
                Ky0.Add(danmuData);
            }
        }

        private static void jyK(RepeatedField<WebShareFeed> repeatedField_0)
        {
            foreach (WebShareFeed item in repeatedField_0)
            {
                DanmuData danmuData = new DanmuData();
                danmuData.Type = DanmuType.Like;
                danmuData.UserDisplayId = item.User.PrincipalId ?? "";
                danmuData.UserNick = item.User?.UserName;
                danmuData.Msg = item.User?.UserName + ":分享了";
                Ky0.Add(danmuData);
            }
        }

        private static void ParseMessage(Message message)
		{
			DanmuData danmuData = new DanmuData
			{
				Type = DanmuType.Chat
			};
			User user = new User();
			switch (message.Method)
			{
				case "WebcastChatMessage":
					ParseChatMessage(message, ref danmuData, ref user);
					break;
				case "WebcastLikeMessage":
					ParseLikeMessage(message, ref danmuData, ref user);
					break;
				case "WebcastGiftMessage":
					ParseGiftMessage(message, ref danmuData, ref user);
					break;
				case "WebcastRoomUserSeqMessage":
					ParseRoomUserSeqMessage(message);
					break;
				case "WebcastSocialMessage":
					ParseSocialMessage(message, ref danmuData, ref user);
					break;
				case "WebcastMemberMessage":
					ParseMemberMessage(message, ref danmuData, ref user);
					break;
				//ֱ无无״̬无�
				//case "WebcastControlMessage":
				//    {
				//        var arg = Serializer.Deserialize<ControlMessage>(new ReadOnlyMemory<byte>(msg.Payload));
				//        this.OnControlMessage?.Invoke(this, arg);
				//        File.AppendAllText("danmu.txt", $"[{DateTime.Now}] {msg.Method} {arg}\r\n");

				//        break;
				//    }
				////粉丝团消息
				//case "WebcastFansclubMessage":
				//    {
				//        var arg = Serializer.Deserialize<FansclubMessage>(new ReadOnlyMemory<byte>(msg.Payload));
				//        this.OnFansclubMessage?.Invoke(this, arg);
				//        File.AppendAllText("danmu.txt", $"[{DateTime.Now}] {msg.Method} {arg}\r\n");

				//        break;
				//    }
				case "WebcastFansclubMessage":
				case "RoomRankMessage":
					break;
				default:
					return;
			}
			if (!string.IsNullOrEmpty(danmuData.Msg))
			{
				PopulateUser(user, ref danmuData);
				DanmuDataChanged?.Invoke(null, danmuData);
			}

		}
		private static void ParseChatMessage(Message message, ref DanmuData danmuData_, ref User user_)
		{
			danmuData_.Type = DanmuType.Chat;
			var chatMessage = Serializer.Deserialize<ChatMessage>(new ReadOnlyMemory<byte>(message.Payload));
			user_ = chatMessage.User;
			_ = chatMessage.publicAreaCommon.userConsumeInRoom;
			danmuData_.Msg = chatMessage.User.Nickname + ":" + chatMessage.Content;
			danmuData_.UserConsumeInRoom = ((chatMessage.publicAreaCommon != null) ? chatMessage.publicAreaCommon.userConsumeInRoom : 0L);
			Print($"{(chatMessage.User.Gender == 1 ? "无" : chatMessage.User.Gender == 2 ? "Ů" : "无")}  {chatMessage.User.Nickname}: {chatMessage.Content}", ConsoleColor.White, BarrageMsgType.弹幕消息);
		}
		private static void ParseLikeMessage(Message message, ref DanmuData danmuData_, ref User user_)
		{
			danmuData_.Type = DanmuType.Like;
			var likeMessage = Serializer.Deserialize<LikeMessage>(new ReadOnlyMemory<byte>(message.Payload));
			user_ = likeMessage.User;
			danmuData_.Msg = likeMessage.User.Nickname + ":点赞";
			danmuData_.UserConsumeInRoom = 0L;
			var Content = $"{likeMessage.User.Nickname} Ϊ无无无无{likeMessage.Count}无�ޣ无ܵ无�{likeMessage.Total}";
			Print($"{(likeMessage.User.Gender == 1 ? "无" : likeMessage.User.Gender == 2 ? "Ů" : "无")}  {Content}", ConsoleColor.Cyan, BarrageMsgType.礼物消息);

		}
		private static void ParseGiftMessage(Message message, ref DanmuData danmuData_, ref User user_)
		{
			danmuData_.Type = DanmuType.Gift;
			var giftMessage = Serializer.Deserialize<GiftMessage>(new ReadOnlyMemory<byte>(message.Payload));
			_ = giftMessage.sendType;
			user_ = giftMessage.User;
			danmuData_.GiftCount = (int)giftMessage.repeatCount;
			danmuData_.GiftName = giftMessage.Gift?.Name;
			danmuData_.GiftUrl = giftMessage.Gift?.Image?.urlLists[0];
			danmuData_.Msg = giftMessage.User.Nickname + ":" + giftMessage.Gift?.Describe + " X" + giftMessage.repeatCount;
			if (giftMessage.Gift != null)
			{
				danmuData_.DiamondCount = giftMessage.Gift.diamondCount;
			}
			if (string.IsNullOrEmpty(danmuData_.GiftName))
			{
				int num = giftMessage.Common.Describe.LastIndexOf("个") + 1;
				danmuData_.GiftName = giftMessage.Common.Describe.Substring(num, giftMessage.Common.Describe.Length - num);
				danmuData_.Msg = giftMessage.Common.Describe;
			}
			if (giftMessage.Common.Describe.LastIndexOf("个") <= 0)
			{
				danmuData_.Msg = giftMessage.Common.Describe;
			}
			danmuData_.UserConsumeInRoom = ((giftMessage.publicAreaCommon == null) ? 0L : giftMessage.publicAreaCommon.userConsumeInRoom);

			var key = giftMessage.giftId + "-" + giftMessage.groupId.ToString();
			if (giftMessage.repeatEnd == 0)
			{

			}
			if (giftMessage.repeatEnd == 1)
			{
				if (giftMessage.groupId > 0 && giftCountCache.ContainsKey(key))
				{
					lock (giftCountCache)
					{
						giftCountCache.Remove(key);
					}
				}
				return;
			}
			int lastCount = 0;
			int currCount = (int)giftMessage.repeatCount;
			var backward = currCount <= lastCount;
			if (currCount <= 0) currCount = 1;

			if (giftCountCache.ContainsKey(key))
			{
				lastCount = giftCountCache[key].Item1;
				backward = currCount <= lastCount;
				if (!backward)
				{
					lock (giftCountCache)
					{
						giftCountCache[key] = Tuple.Create(currCount, DateTime.Now);
					}
				}
			}
			else
			{
				if (giftMessage.groupId > 0 && !backward)
				{
					lock (giftCountCache)
					{
						giftCountCache.Add(key, Tuple.Create(currCount, DateTime.Now));
					}
				}
			}
			if (backward) return;


			var count = currCount - lastCount;
			var Content = $"{giftMessage.User.Nickname} �ͳ� {giftMessage.Gift.Name} x {currCount} 无无无无{count}无";

			Print($"{(giftMessage.User.Gender == 1 ? "无" : giftMessage.User.Gender == 2 ? "Ů" : "无")}  {Content}", ConsoleColor.Red, BarrageMsgType.礼物消息);

		}
		private static void ParseRoomUserSeqMessage(Message message)
		{
			var roomUserSeqMessage = Serializer.Deserialize<RoomUserSeqMessage>(new ReadOnlyMemory<byte>(message.Payload));
			Common.RoomData.TotalLike = roomUserSeqMessage.totalPvForAnchor;
			Common.RoomData.OnlineUser = roomUserSeqMessage.onlineUserForAnchor ?? "";
			var ranks = roomUserSeqMessage.Ranks;
			Common.RoomData.RankUsers.Clear();
			foreach (Contributor item in ranks)
			{
				Common.RoomData.RankUsers.Add(new RankUser
				{
					Rank = item.Rank,
					NickName = item.User.Nickname,
					HeadPic = item.User?.avatarThumb?.urlLists[0]
				});
			}
			//RoomRankWindow.Instance.UpdateRank(Common.RoomData.RankUsers);
			Print($"当前直播间人数 {roomUserSeqMessage.onlineUserForAnchor}累计直播间人数 {roomUserSeqMessage.totalPvForAnchor}", ConsoleColor.Magenta, BarrageMsgType.直播间统计);

		}
		private static void ParseSocialMessage(Message message, ref DanmuData danmuData_, ref User user_)
		{
			danmuData_.Type = DanmuType.Follow;
			var socialMessage = Serializer.Deserialize<SocialMessage>(new ReadOnlyMemory<byte>(message.Payload));
			user_ = socialMessage.User;
			danmuData_.Msg = $"{socialMessage.User.Nickname}: 关注了主播";
			danmuData_.UserConsumeInRoom = ((socialMessage.publicAreaCommon != null) ? socialMessage.publicAreaCommon.userConsumeInRoom : 0L);
			Print($"{(socialMessage.User.Gender == 1 ? "无" : socialMessage.User.Gender == 2 ? "Ů" : "无")}  {danmuData_.Msg}", ConsoleColor.Yellow, BarrageMsgType.关注消息);
		}
		private static void ParseMemberMessage(Message message, ref DanmuData danmuData_, ref User user_)
		{
			danmuData_.Type = DanmuType.EnterRoom;
			var memberMessage = Serializer.Deserialize<MemberMessage>(new ReadOnlyMemory<byte>(message.Payload));
			user_ = memberMessage.User;
			danmuData_.Msg = memberMessage.User.Nickname + ": 来了";
			danmuData_.UserConsumeInRoom = 0L;
			var content = $"{memberMessage.User.Nickname} 无无 ֱ无无无无:{memberMessage.memberCount}";
			Print($"{(memberMessage.User.Gender == 1 ? "无" : memberMessage.User.Gender == 2 ? "Ů" : "无")}  {content}", ConsoleColor.Green, BarrageMsgType.进直播间);
		}
		private static void PopulateUser(User user, ref DanmuData danmuData)
		{
			danmuData.Timestamp = DateTime.Now;
			danmuData.UserNick = user.Nickname;
			danmuData.UserId = user.Id;
			danmuData.UserDisplayId = user.displayId;
			danmuData.UserV5Level = long.Parse("0" + user?.payGrade?.Level);
			danmuData.UserFans = long.Parse("0" + user.followInfo?.followerCount);
			danmuData.UserFollows = long.Parse("0" + user.followInfo?.followingCount);
			danmuData.UserSex = ((user.Gender == 1) ? "男" : "女");
			danmuData.SecUid = user.sec_uid;
			danmuData.UserHeadPic = user.avatarThumb?.urlLists?.FirstOrDefault();
			danmuData.FansClubLevel = int.Parse("0" + user.fansClub?.Data?.Level);
			danmuData.NewImIconWithLevel = user.payGrade?.newImIconWithLevel?.urlLists?.FirstOrDefault() ?? "";
		}
		private static void Print(string msg, ConsoleColor color, BarrageMsgType bartype)
		{
			string info = $"{DateTime.Now.ToString("HH:mm:ss.fff")} [{bartype.ToString()}] " + msg + "\n";
			Console.WriteLine(info);
			File.AppendAllText("danmu.txt", info);
		}
	}
	/// <summary>
	/// 弹幕消息无无
	/// </summary>
	public enum BarrageMsgType
	{
		无 = 0,
		弹幕消息 = 1,
		点赞消息 = 2,
		进直播间 = 3,
		关注消息 = 4,
		礼物消息 = 5,
		直播间统计 = 6,
		粉丝团消息 = 7,
		直播间分享 = 8,
		下播 = 9
	}
}
