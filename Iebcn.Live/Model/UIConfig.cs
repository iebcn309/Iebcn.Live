using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Text.Json.Serialization;

namespace Iebcn.Live
{
	public class UIConfig : INotifyPropertyChanged
	{
		private DanmuPlayerConfig _config = new DanmuPlayerConfig();
		private SolidColorBrush _pageBackground = new SolidColorBrush(Colors.Black);
		private SolidColorBrush _nickForeground = new SolidColorBrush(Colors.LightBlue);
		private SolidColorBrush _danmuForeground = new SolidColorBrush(Colors.White);
		private DropShadowEffect _shadowEffect = new DropShadowEffect();
		private int _limitDiamondCount;
		private bool _giftPriceLimitEnabled;
		private bool _fullScrVertModeAnimPicEnabled = true;
		private bool _fullScrVertMode;
		private bool _greenBackground = true;
		private bool _fullScrShowText = true;

		public DanmuPlayerConfig Config
		{
			get => _config;
			set
			{
				_config = value;
				OnPropertyChanged(nameof(Config));
			}
		}
		[JsonIgnore]
		public SolidColorBrush PageBackground
		{
			get => _pageBackground;
			set
			{
				_pageBackground = value;
				OnPropertyChanged(nameof(PageBackground));
			}
		}
		[JsonIgnore]

		public SolidColorBrush NickForeground
		{
			get => _nickForeground;
			set
			{
				_nickForeground = value;
				OnPropertyChanged(nameof(NickForeground));
			}
		}
		[JsonIgnore]

		public SolidColorBrush DanmuForeground
		{
			get => _danmuForeground;
			set
			{
				_danmuForeground = value;
				OnPropertyChanged(nameof(DanmuForeground));
			}
		}
		[JsonIgnore]
		public DropShadowEffect ShadowEffect
		{
			get => _shadowEffect;
			set
			{
				_shadowEffect = value;
				OnPropertyChanged(nameof(ShadowEffect));
			}
		}

		public int LimitDiamondCount
		{
			get => _limitDiamondCount;
			set
			{
				_limitDiamondCount = value;
				OnPropertyChanged(nameof(LimitDiamondCount));
			}
		}

		public bool GiftPriceLimitEnabled
		{
			get => Common.VIPLevel >= 2 && _giftPriceLimitEnabled;
			set
			{
				if (Common.VIPLevel >= 2)
				{
					_giftPriceLimitEnabled = value;
					OnPropertyChanged(nameof(GiftPriceLimitEnabled));
				}
			}
		}

		public bool FullScrVertModeAnimPicEnabled
		{
			get => _fullScrVertModeAnimPicEnabled;
			set
			{
				_fullScrVertModeAnimPicEnabled = value;
				OnPropertyChanged(nameof(FullScrVertModeAnimPicEnabled));
			}
		}

		public bool FullScrVertMode
		{
			get => Common.VIPLevel >= 1 && _fullScrVertMode;
			set
			{
				if (Common.VIPLevel >= 1)
				{
					_fullScrVertMode = value;
					OnPropertyChanged(nameof(FullScrVertMode));
				}
			}
		}

		public bool GreenBackground
		{
			get => _greenBackground;
			set
			{
				_greenBackground = value;
				OnPropertyChanged(nameof(GreenBackground));
			}
		}

		public bool FullScrShowText
		{
			get => _fullScrShowText;
			set
			{
				_fullScrShowText = value;
				OnPropertyChanged(nameof(FullScrShowText));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
