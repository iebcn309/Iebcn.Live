using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Iebcn.Live
{
	public class DanmuSetting : INotifyPropertyChanged
	{
		// 上次直播 URL
		public string LastLiveUrl { get; set; }
		public UIConfig RoomRankUIConfig { get; set; } = new UIConfig();
		public UIConfig UIConfig0 { get; set; } = new UIConfig();
		public UIConfig NormalUIConfig { get; set; } = new UIConfig();
		private SaveDanmuConfig _saveDanmuConfig = new SaveDanmuConfig();
		private bool _saveDanmuUseRoomIdEnabled = true;
		private ChatBot _chatBot = new ChatBot();
		private VoiceDanmu _voiceDanmu = new VoiceDanmu();
		private MusicBox _musicBox = new MusicBox();
		private string _msg = "";
		private bool _animationEnabled;
		private string _animationPicUrl = "Assets/ThanksGifs/p7.gif";
		private int _animationIntervalSeconds = 3;
		private int _animationAliveSeconds = 3;
		private string _blackList = "";
		private KeyUser _keyUser = new KeyUser();
		private AppNotice _appNotice=new AppNotice();
		private AppTheme _appTheme = new AppTheme();
		private GlobalConfig _globalConfig = new GlobalConfig();
		private Silence _silence = new Silence();
		private AutoReply _autoReply=new AutoReply();
		private Renqi _renqi = new Renqi();
		private EventDanmu _eventDanmu=new EventDanmu();
		private LivePage _livePage= new LivePage();	
		private AgentData _agent=new AgentData();
		private TimerSpeak _timerSpeak = new TimerSpeak();
		private DanmuDetailPage _danmuDetailPage = new DanmuDetailPage();
		private AutoSendDanmu _autoSendDanmu= new AutoSendDanmu();
		private FakeDanmu _fakeDanmu=new FakeDanmu();
		private OBSCmd _OBSCmd=new OBSCmd();
		private SoundAssistant _soundAssistant=new SoundAssistant();
		private Live2DRole _live2DRole=new Live2DRole();
		private Vote _vote=new Vote();
		private RelayTool _relayTool=new RelayTool();
		private Overtime _overtime=	new Overtime();
		private GPT _GPT=new GPT();
		private PrintAvatar _printAvatar=new PrintAvatar();
		private GiftInteraction _giftInteraction=	new GiftInteraction();
		private FloatScreen _floatScreen=new FloatScreen();
		private MouseKeyboardTool _mouseKeyboardTool=new MouseKeyboardTool();
		private Muyu _muyu=new Muyu();
		private TextList _textList=new TextList();
		private FakeGift _fakeGift=new FakeGift();
		private ScreenText _screenText=new ScreenText();
		private GiftPK _giftPK=	new GiftPK();
		private GiftPK2 _giftPK2=	new GiftPK2();
		private Roll _roll=	new Roll();
		private Intercut _intercut=new Intercut();
		private NoticeDanmuModel _noticeDanmuModel=new NoticeDanmuModel();
		private Api _api=new Api();
		private FunnyRobot _funnyRobot=new FunnyRobot();
		private MediaTriger _mediaTriger=new MediaTriger();
		private HitGift _hitGift=new HitGift();

		public string LastSetText { get; set; } = "欢迎加关注：抖音弹幕助手！";
		public AppTheme AppTheme
		{
			get => _appTheme;
			set
			{
				SetProperty(ref _appTheme, value);
			}
		}
		public GlobalConfig GlobalConfig
		{
			get => _globalConfig;
			set
			{
				SetProperty(ref _globalConfig, value);
			}
		}
		public LivePage LivePage
		{
			get => _livePage;
			set
			{
				SetProperty(ref _livePage, value);
			}
		}
		public AgentData Agent
		{
			get => _agent;
			set
			{
				SetProperty(ref _agent, value);
			}
		}
		public SaveDanmuConfig SaveDanmuConfig
		{
			get => _saveDanmuConfig;
			set
			{
				SetProperty(ref _saveDanmuConfig, value);
			}
		}
		public bool SaveDanmuUseRoomIdEnabled
		{
			get => _saveDanmuUseRoomIdEnabled;
			set
			{
				SetProperty(ref _saveDanmuUseRoomIdEnabled, value);
			}
		}
		public AutoSendDanmu AutoSendDanmu
		{
			get => _autoSendDanmu;
			set
			{
				SetProperty(ref _autoSendDanmu, value);
			}
		}
		public Live2DRole Live2DRole_0
		{
			get => _live2DRole;
			set
			{
				SetProperty(ref _live2DRole, value);
			}
		}
		public Vote Vote
		{
			get => _vote;
			set
			{
				SetProperty(ref _vote, value);
			}
		}
		public RelayTool RelayTool
		{
			get => _relayTool;
			set
			{
				SetProperty(ref _relayTool, value);
			}
		}
		public Overtime Overtime
		{
			get => _overtime;
			set
			{
				SetProperty(ref _overtime, value);
			}
		}
		public SoundAssistant SoundAssistant
		{
			get => _soundAssistant;
			set
			{
				SetProperty(ref _soundAssistant, value);
			}
		}
		public AppNotice AppNotice
		{
			get => _appNotice;
			set
			{
				SetProperty(ref _appNotice, value);
			}
		}
		public GPT GPT
		{
			get => _GPT;
			set
			{
				SetProperty(ref _GPT, value);
			}
		}
		public PrintAvatar PrintAvatar
		{
			get => _printAvatar;
			set
			{
				SetProperty(ref _printAvatar, value);
			}
		}
		public GiftInteraction GiftInteraction
		{
			get => _giftInteraction;
			set
			{
				SetProperty(ref _giftInteraction, value);
			}
		}
		public GiftPK GiftPK
		{
			get => _giftPK;
			set
			{
				SetProperty(ref _giftPK, value);
			}
		}

		public GiftPK2 GiftPK2
		{
			get => _giftPK2;
			set
			{
				SetProperty(ref _giftPK2, value);
			}
		}

		public Roll Roll
		{
			get => _roll;
			set
			{
				SetProperty(ref _roll, value);
			}
		}
		public FloatScreen FloatScreen
		{
			get => _floatScreen;
			set
			{
				SetProperty(ref _floatScreen, value);
			}
		}
		public Silence Silence
		{
			get => _silence;
			set
			{
				SetProperty(ref _silence, value);
			}
		}
		public Renqi Renqi
		{
			get => _renqi;
			set
			{
				SetProperty(ref _renqi, value);
			}
		}
		public FakeDanmu FakeDanmu
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_fakeDanmu.ChatEnabled = false;
					_fakeDanmu.GiftEnabled = false;
					_fakeDanmu.EnterRoomEnabled = false;
					_fakeDanmu.LikeEnabled = false;
					_fakeDanmu.FollowEnabled = false;
				}
				return _fakeDanmu;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value.ChatEnabled = false;
					value.GiftEnabled = false;
					value.EnterRoomEnabled = false;
					value.LikeEnabled = false;
					value.FollowEnabled = false;
				}
				SetProperty(ref _fakeDanmu, value);
			}
		}
		public EventDanmu EventDanmu
		{
			get => _eventDanmu;
			set
			{
				SetProperty(ref _eventDanmu, value);
			}
		}
		public TimerSpeak TimerSpeak
		{
			get => _timerSpeak;
			set
			{
				SetProperty(ref _timerSpeak, value);
			}
		}
		public Intercut Intercut
		{
			get => _intercut;
			set
			{
				SetProperty(ref _intercut, value);
			}
		}

		public ChatBot ChatBot
		{
			get => _chatBot;
			set
			{
				SetProperty(ref _chatBot, value);
			}
		}
		public MouseKeyboardTool MouseKeyboardTool
		{
			get => _mouseKeyboardTool;
			set
			{
				SetProperty(ref _mouseKeyboardTool, value);
			}
		}
		public Muyu Muyu
		{
			get => _muyu;
			set
			{
				SetProperty(ref _muyu, value);
			}
		}

		public TextList TextList
		{
			get => _textList;
			set
			{
				SetProperty(ref _textList, value);
			}
		}

		public FakeGift FakeGift
		{
			get => _fakeGift;
			set
			{
				SetProperty(ref _fakeGift, value);
			}
		}

		public ScreenText ScreenText
		{
			get => _screenText;
			set
			{
				SetProperty(ref _screenText, value);
			}
		}
		public AutoReply AutoReply
		{
			get => _autoReply;
			set
			{
				SetProperty(ref _autoReply, value);
			}
		}
		public VoiceDanmu VoiceDanmu
		{
			get => _voiceDanmu;
			set
			{
				SetProperty(ref _voiceDanmu, value);
			}
		}
		public Api Api
		{
			get => _api;
			set
			{
				SetProperty(ref _api, value);
			}
		}
		public NoticeDanmuModel NoticeDanmu
		{
			get => _noticeDanmuModel;
			set
			{
				SetProperty(ref _noticeDanmuModel, value);
			}
		}
		public FunnyRobot FunnyRobot
		{
			get => _funnyRobot;
			set
			{
				SetProperty(ref _funnyRobot, value);
			}
		}
		public OBSCmd OBSCmd
		{
			get => _OBSCmd;
			set
			{
				SetProperty(ref _OBSCmd, value);
			}
		}
		public MediaTriger MediaTriger
		{
			get => _mediaTriger;
			set
			{
				SetProperty(ref _mediaTriger, value);
			}
		}

		public HitGift HitGift
		{
			get => _hitGift;
			set
			{
				SetProperty(ref _hitGift, value);
			}
		}
		public DanmuDetailPage DanmuDetailPage
		{
			get => _danmuDetailPage;
			set
			{
				SetProperty(ref _danmuDetailPage, value);
			}
		}

		public MusicBox MusicBox
		{
			get => _musicBox;
			set
			{
				SetProperty(ref _musicBox, value);
			}
		}

		public string Msg
		{
			get => _msg;
			set
			{
				SetProperty(ref _msg, value);
			}
		}

		public bool AnimationEnabled
		{
			get => _animationEnabled;
			set
			{
				SetProperty(ref _animationEnabled, value);
			}
		}

		public string AnimationPicUrl
		{
			get => _animationPicUrl;
			set
			{
				SetProperty(ref _animationPicUrl, value);
			}
		}

		public int AnimationIntervalSeconds
		{
			get => _animationIntervalSeconds;
			set
			{
				SetProperty(ref _animationIntervalSeconds, value);
			}
		}

		public int AnimationAliveSeconds
		{
			get => _animationAliveSeconds;
			set
			{
				SetProperty(ref _animationAliveSeconds, value);
			}
		}

		public string BlackList
		{
			get => _blackList;
			set
			{
				SetProperty(ref _blackList, value);
			}
		}

		public KeyUser KeyUser
		{
			get => _keyUser;
			set
			{
				SetProperty(ref _keyUser, value);
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(field, value))
			{
				field = value;
				OnPropertyChanged(propertyName);
			}
		}
	}
}