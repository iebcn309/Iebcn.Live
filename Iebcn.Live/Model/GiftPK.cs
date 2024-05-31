namespace Iebcn.Live.ViewModel
{
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Windows.Media;

	public class GiftPK : INotifyPropertyChanged
	{
		private PropertyChangedEventHandler _propertyChangedHandler;
		private bool _isEnabled;
		private bool _greenBackground;
		private bool _showDesc;
		private bool _showCounterBar;
		private SolidColorBrush _fontColor;
		private ObservableCollection<GiftInfo> _savedList;

		public GiftPK()
		{
			_isEnabled = true;
			_greenBackground = true;
			_showDesc = true;
			_showCounterBar = true;
			_fontColor = new SolidColorBrush(Colors.Yellow);
			_savedList = new ObservableCollection<GiftInfo>();
		}

		public bool IsEnabled
		{
			get => _isEnabled;
			set
			{
				if (Common.VIPLevel < 1 && value)
				{
					value = false;
				}
				_isEnabled = value;
				OnPropertyChanged(nameof(IsEnabled));
			}
		}

		public bool GreenBackground
		{
			get => _greenBackground;
			set
			{
				if (_greenBackground != value)
				{
					_greenBackground = value;
					OnPropertyChanged(nameof(GreenBackground));
				}
			}
		}

		public bool ShowDesc
		{
			get => _showDesc;
			set
			{
				if (_showDesc != value)
				{
					_showDesc = value;
					OnPropertyChanged(nameof(ShowDesc));
				}
			}
		}

		public bool ShowCounterBar
		{
			get => _showCounterBar;
			set
			{
				if (_showCounterBar != value)
				{
					_showCounterBar = value;
					OnPropertyChanged(nameof(ShowCounterBar));
				}
			}
		}

		public SolidColorBrush FontColor
		{
			get => _fontColor;
			set
			{
				if (_fontColor != value)
				{
					_fontColor = value;
					OnPropertyChanged(nameof(FontColor));
				}
			}
		}

		public ObservableCollection<GiftInfo> SavedList
		{
			get => _savedList;
			set
			{
				if (_savedList != value)
				{
					_savedList = value;
					OnPropertyChanged(nameof(SavedList));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add { _propertyChangedHandler += value; }
			remove { _propertyChangedHandler -= value; }
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			_propertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
