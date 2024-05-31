using System.ComponentModel;
using System.Windows;

namespace Iebcn.Live
{
	public class AgentData : INotifyPropertyChanged
	{
		private string _id;
		private string _contact;
		private string _title;
		private bool _isAgent;
		private Visibility _agentUIVisible;

		public event PropertyChangedEventHandler PropertyChanged;

		// 代理的唯一标识符
		public string Id
		{
			get => _id;
			set
			{
				if (_id != value)
				{
					_id = value;
					OnPropertyChanged(nameof(Id));
				}
			}
		}

		// 联系人信息
		public string Contact
		{
			get => _contact;
			set
			{
				if (_contact != value)
				{
					_contact = value;
					OnPropertyChanged(nameof(Contact));
				}
			}
		}

		// 软件标题
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

		// 是否为代理
		public bool IsAgent
		{
			get => _isAgent;
			set
			{
				if (_isAgent != value)
				{
					_isAgent = value;
					OnPropertyChanged(nameof(IsAgent));
				}
			}
		}

		// 代理用户界面的可见性
		public Visibility AgentUIVisible
		{
			get => _agentUIVisible;
			set
			{
				if (_agentUIVisible != value)
				{
					_agentUIVisible = value;
					OnPropertyChanged(nameof(AgentUIVisible));
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
