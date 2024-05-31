namespace Iebcn.Live.ViewModel
{
	using System.ComponentModel; // 引入INotifyPropertyChanged所在的命名空间
	using System.Windows;

	public class VoteData : INotifyPropertyChanged
	{
		// 选项的标题
		private string _title = "选项标题";

		// 投票的提示信息
		private string _commandTip = "投票发:";

		// 弹幕命令的字符串表示
		private string _danmuCommand = "1";

		// 投票的数量
		private int _count;

		// 头像图片的路径
		private string _headPicPath = "Pack://application:,,,/Assets/sampleHead1.jpg";

		// 删除按钮的可见性
		private Visibility _btnDeleteVisibility = Visibility.Collapsed;

		// 唯一标识符
		private string _id = Guid.NewGuid().ToString();

		// 选项标题属性
		public string Title
		{
			get { return _title; }
			set
			{
				if (_title != value)
				{
					_title = value;
					OnPropertyChanged(nameof(Title));
				}
			}
		}

		// 投票提示信息属性
		public string CmdTip
		{
			get { return _commandTip; }
			set
			{
				if (_commandTip != value)
				{
					_commandTip = value;
					OnPropertyChanged(nameof(CmdTip));
				}
			}
		}

		// 弹幕命令属性
		public string DanmuCmd
		{
			get { return _danmuCommand; }
			set
			{
				_danmuCommand = value;
				OnPropertyChanged(nameof(DanmuCmd));
			}
		}

		// 投票数量属性
		public int Count
		{
			get { return _count; }
			set
			{
				_count = value;
				OnPropertyChanged(nameof(Count));
				OnPropertyChanged(nameof(CountCN)); // 当投票数量改变时，计数的中文表示也需要更新
			}
		}

		// 投票数量的中文表示
		public string CountCN
		{
			get { return _count + "票"; }
		}

		// 头像图片路径属性
		public string HeadPic
		{
			get { return _headPicPath; }
			set
			{
				_headPicPath = value;
				OnPropertyChanged(nameof(HeadPic));
			}
		}

		// 删除按钮可见性属性
		public Visibility BtnDelVisibility
		{
			get { return _btnDeleteVisibility; }
			set
			{
				_btnDeleteVisibility = value;
				OnPropertyChanged(nameof(BtnDelVisibility));
			}
		}

		// 唯一标识符属性
		public string Id
		{
			get { return _id; }
			private set
			{
				// 唯一标识符在对象创建时生成，之后不再改变
				if (_id != value)
				{
					_id = value;
					OnPropertyChanged(nameof(Id));
				}
			}
		}

		// 实现INotifyPropertyChanged接口的PropertyChanged事件
		public event PropertyChangedEventHandler PropertyChanged;

		// 当属性值发生变化时调用的方法
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}