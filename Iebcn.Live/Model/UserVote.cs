namespace Iebcn.Live.ViewModel
{
	public class UserVote
	{
		public long UserId { get; set; }
		public string VoteId { get; set; }
		public UserVote(long userId, string voteId)
		{
			UserId = userId;
			VoteId = voteId;
		}
	}

}
