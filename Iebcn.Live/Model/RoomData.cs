using System.ComponentModel;

namespace Iebcn.Live
{
	public class RoomData : INotifyPropertyChanged
	{
		private PropertyChangedEventHandler _propertyChanged;
		private string _totalLike = "2234";
		private string _onlineUser = "1234";
		private List<RankUser> _rankUsers = new List<RankUser>();
		public string TotalLike
		{
			get => _totalLike;
			set
			{
				_totalLike = value;
				OnPropertyChanged(nameof(TotalLike));
			}
		}
		public string OnlineUser
		{
			get => _onlineUser;
			set
			{
				_onlineUser = value;
				OnPropertyChanged(nameof(OnlineUser));
			}
		}
		public List<RankUser> RankUsers
		{
			get => _rankUsers;
			set
			{
				_rankUsers = value;
				OnPropertyChanged(nameof(RankUsers));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged
		{
			add => _propertyChanged += value;
			remove => _propertyChanged -= value;
		}
		private void OnPropertyChanged(string propertyName)
		{
			_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}