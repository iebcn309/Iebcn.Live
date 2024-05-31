using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;

namespace Iebcn.Live.Helper
{
	public class VoteHelper
	{
		private static VoteWindow dr4;

		public static List<UserVote> userVoteHistory;

		public static void ShowWindow()
		{
			if (dr4 == null || dr4.IsClosed)
			{
				dr4 = new VoteWindow();
			}
			dr4.Show();
			dr4.Activate();
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		public static async void AddData(DanmuData data)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			if (!Common.danmuSetting.Vote.IsEnabled || data.Type != 0)
			{
				return;
			}
			VoteData PBx = Common.danmuSetting.Vote.VoteDataList.FirstOrDefault((VoteData x) => x.DanmuCmd == data.PureMsg.Trim());
			if (PBx == null)
			{
				return;
			}
			if (!userVoteHistory.Any((UserVote x) => x.UserId == data.UserId))
			{
				userVoteHistory.Add(new UserVote(data.UserId, PBx.Id));
				PBx.Count++;
			}
			else if (userVoteHistory.Count((UserVote x) => x.UserId == data.UserId) < Common.danmuSetting.Vote.SingleUserMaxVoteLimit)
			{
				if (userVoteHistory.Any((UserVote x) => x.UserId == data.UserId && x.VoteId == PBx.Id) && Common.danmuSetting.Vote.AllowVoteItemRepeat)
				{
					userVoteHistory.Add(new UserVote(data.UserId, PBx.Id));
					PBx.Count++;
				}
				else if (userVoteHistory.Any((UserVote x) => x.UserId == data.UserId && x.VoteId != PBx.Id) && Common.danmuSetting.Vote.AllowVoteMoreItems)
				{
					userVoteHistory.Add(new UserVote(data.UserId, PBx.Id));
					PBx.Count++;
				}
			}
		}

		static VoteHelper()
		{
			dr4 = null;
			userVoteHistory = new List<UserVote>();
		}
	}

}
