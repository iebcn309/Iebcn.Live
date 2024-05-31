namespace Iebcn.Live.ViewModel
{
	using System;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Windows.Media;

	public class Overtime : INotifyPropertyChanged
	{
		private bool _isEnabled;

		private Brush _giftNameForeground = new SolidColorBrush(Colors.White);

		private Brush _giftDescForeground = new SolidColorBrush(Colors.Yellow);

		private Brush _otherForeground = new SolidColorBrush(Colors.WhiteSmoke);

		private double _backOpacity = 0.9;

		private string _titleText = "距离下播时间";

		private string _idleText = "送送小礼物，加班加到吐";

		private long _remainTimeSeconds;

		private bool _isComplete;

		public Overtime()
		{
			// 初始化剩余时间（单位：秒）
			RemainTimeSeconds = 1800;
		}

		public bool IsEnabled
		{
			get => _isEnabled;
			set
			{
				if (Common.VIPLevel < 1)
				{
					_isEnabled = false;
				}
				else
				{
					_isEnabled = value;
				}
				OnPropertyChanged(nameof(IsEnabled));
			}
		}

		public Brush GiftNameForeground
		{
			get => _giftNameForeground;
			set
			{
				if (_giftNameForeground != value)
				{
					_giftNameForeground = value;
					OnPropertyChanged(nameof(GiftNameForeground));
				}
			}
		}

		public Brush GiftDescForeground
		{
			get => _giftDescForeground;
			set
			{
				if (_giftDescForeground != value)
				{
					_giftDescForeground = value;
					OnPropertyChanged(nameof(GiftDescForeground));
				}
			}
		}

		public Brush OtherForeground
		{
			get => _otherForeground;
			set
			{
				if (_otherForeground != value)
				{
					_otherForeground = value;
					OnPropertyChanged(nameof(OtherForeground));
				}
			}
		}

		public double BackOpacity
		{
			get => _backOpacity;
			set
			{
				if (_backOpacity != value)
				{
					_backOpacity = value;
					OnPropertyChanged(nameof(BackOpacity));
				}
			}
		}

		public string TitleText
		{
			get => _titleText;
			set
			{
				if (_titleText != value)
				{
					_titleText = value;
					OnPropertyChanged(nameof(TitleText));
				}
			}
		}

		public string IdleText
		{
			get => _idleText;
			set
			{
				if (_idleText != value)
				{
					_idleText = value;
					OnPropertyChanged(nameof(IdleText));
				}
			}
		}

		public long RemainTimeSeconds
		{
			get => _remainTimeSeconds;
			set
			{
				if (_remainTimeSeconds != value)
				{
					_remainTimeSeconds = value;
					OnPropertyChanged(nameof(RemainTimeSeconds));
					OnPropertyChanged(nameof(TimeString));
				}
			}
		}

		public bool IsComplete
		{
			get => _isComplete;
			set
			{
				if (_isComplete != value)
				{
					_isComplete = value;
					OnPropertyChanged(nameof(IsComplete));
				}
			}
		}

		public string TimeString
		{
			get
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(RemainTimeSeconds);
				return timeSpan.TotalDays > 0
					? timeSpan.ToString("dd' 'hh':'mm':'ss")
					: timeSpan.ToString("hh':'mm':'ss");
			}
		}

		public ObservableCollection<OvertimeGift> ListDataSaved { get; private set; } = new ObservableCollection<OvertimeGift>();

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		// 其他方法（如jPZ, qPt, vPc, jPk）可以根据需要进行重构或移除
	}
}
