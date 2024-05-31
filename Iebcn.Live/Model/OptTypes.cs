namespace Iebcn.Live
{
	public class OptTypes
	{
		private bool _chatEnabled = true;
		private bool _giftEnabled = true;
		private bool _enterRoomEnabled = true;
		private bool _followEnabled = true;
		private bool _likeEnabled = true;

		public bool ChatEnabled
		{
			get => _chatEnabled;
			set => _chatEnabled = value;
		}

		public bool GiftEnabled
		{
			get => _giftEnabled;
			set => _giftEnabled = value;
		}

		public bool EnterRoomEnabled
		{
			get => _enterRoomEnabled;
			set => _enterRoomEnabled = value;
		}

		public bool FollowEnabled
		{
			get => _followEnabled;
			set => _followEnabled = value;
		}

		public bool LikeEnabled
		{
			get => _likeEnabled;
			set => _likeEnabled = value;
		}
	}
}