using System.ComponentModel;

namespace Iebcn.Live
{
	public class UserMusic : INotifyPropertyChanged
	{
		private DateTime _addTime;
		private int _vote;
		private int _order;
		private string _title;
		private string _byUser;
		private bool _isFreeList;

		public event PropertyChangedEventHandler PropertyChanged;

		// 添加时间，用于记录歌曲被添加的时间
		public DateTime AddTime
		{
			get => _addTime;
			set
			{
				if (_addTime != value)
				{
					_addTime = value;
					OnPropertyChanged(nameof(AddTime));
				}
			}
		}

		// 投票数，用于记录歌曲的投票数量
		public int Vote
		{
			get => _vote;
			set
			{
				if (_vote != value)
				{
					_vote = value;
					OnPropertyChanged(nameof(Vote));
				}
			}
		}

		// 排序位置，用于记录歌曲在列表中的排序位置
		public int Order
		{
			get => _order;
			set
			{
				if (_order != value)
				{
					_order = value;
					OnPropertyChanged(nameof(Order));
				}
			}
		}

		// 歌曲标题，用于存储歌曲的名称
		public string Title
		{
			get => _title;
			set
			{
				if (_title != value)
				{
					_title = value;
					OnPropertyChanged(nameof(Title));
				}
			}
		}

		// 点歌用户，用于记录点歌用户的昵称
		public string ByUser
		{
			get => _byUser;
			set
			{
				if (_byUser != value)
				{
					_byUser = value;
					OnPropertyChanged(nameof(ByUser));
				}
			}
		}

		// 是否为免费歌曲列表，用于标记歌曲是否属于免费点歌列表
		public bool IsFreeList
		{
			get => _isFreeList;
			set
			{
				if (_isFreeList != value)
				{
					_isFreeList = value;
					OnPropertyChanged(nameof(IsFreeList));
				}
			}
		}

		// 实现INotifyPropertyChanged接口的OnPropertyChanged方法，用于在属性值改变时通知监听器
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}