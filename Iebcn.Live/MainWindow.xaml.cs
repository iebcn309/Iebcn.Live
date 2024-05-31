using Iebcn.Live.Controls;
using Iebcn.Live.Helper;
using NAudio.Wave;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Iebcn.Live
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private List<DanmuPlayer> _danmuPlayerList = new List<DanmuPlayer>();
		private LiveWebWindow _liveWebWindow;
		private DanmuPlayer _danmuPlayer;
		private HandyControl.Controls.NotifyIcon _notifyIcon;
		private static MuyuWindow _muyuWindow;
		private static OvertimeWindow _overtimeWindow;
		private static IntercutWindow _intercutWindow;
		private static WebEffectsWindow _webEffectsWindow;
		private static RoomControlWindow m1f;
		private static VoiceSettingsWindow YoE;

		public MainWindow()
		{
			Common.mainWindow = this;
			InitializeComponent();

			Util.LoadConfig();
			WebBrowserHelper.DanmuDataChanged += WebBrowserHelper_DanmuDataChanged;
			base.Loaded += MainWindow_Loaded; ;
			InitNotifyIcon();


			//new ChatBotService(new DanmuData() { Msg = "你是谁？", UserNick ="kwong"}).StateCahanged += tSa;

		}
		private void InitNotifyIcon()
		{
			_notifyIcon = new HandyControl.Controls.NotifyIcon();
			_notifyIcon.Text = "抖灵";
			_notifyIcon.Icon = new BitmapImage(new Uri("pack://application:,,,/Assets/app.ico"));
			MenuItem menuItem = new MenuItem { Header = "打开主界面" };
			menuItem.Click += (sender, e) =>
			{
				base.Visibility = Visibility.Visible;
				base.ShowInTaskbar = true;
				Activate();
			}; 
			MenuItem menuItem2 = new MenuItem { Header = "自动发弹幕" };
			menuItem2.Click += (sender, e) =>
			{
				//SendDanmuWindow.Instance.Show();
				//SendDanmuWindow.Instance.Activate();
			}; 
			MenuItem menuItem3 = new MenuItem { Header = "点歌" };
			menuItem3.Click += (sender, e) =>
			{
				//MusicWindow.Instance.Show();
				//MusicWindow.Instance.Activate();
			};
			MenuItem menuItem4 = new MenuItem{ Header = "帮助" };
			menuItem4.Click += (sender, e) =>
			{
				//MusicWindow.Instance.Show();
				//MusicWindow.Instance.Activate();
			};
			MenuItem menuItem5 = new MenuItem { Header = "添加文本" };
			//menuItem5.Click += t2r;
			MenuItem menuItem6 = new MenuItem { Header = "退出" };
			menuItem6.Click += (sender, e) => {
				Common.AppClosed = true;
				if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1)
				{
					for (int i = 0; i < Common.danmuSetting.AutoSendDanmu.EnvFolders.Length; i++)
					{
						Common.danmuSetting.AutoSendDanmu.EnvFolders[i].InUse = false;
					}
				}
				else if (Common.CurrEnvFolder_SendDanmu != null)
				{
					Common.CurrEnvFolder_SendDanmu.InUse = false;
				}
				Util.SaveDanmuSetting();
				_liveWebWindow?.Close();
				//SocketServer.Close();
				Close();
				Application.Current.Shutdown();
			};
			_notifyIcon.ContextMenu = new ContextMenu();

			_notifyIcon.ContextMenu.Items.Add(menuItem);
			_notifyIcon.ContextMenu.Items.Add(menuItem2);
			_notifyIcon.ContextMenu.Items.Add(menuItem3);
			_notifyIcon.ContextMenu.Items.Add(menuItem4);
			_notifyIcon.ContextMenu.Items.Add(menuItem6);

			_notifyIcon.MouseDoubleClick += delegate (object sender, RoutedEventArgs e)
			{
				//if (e.Button == MouseButtons.Left)
				//{
				//	Y2m(sender, e);
				//}
			};
			this.gridAppNotice.Children.Add(_notifyIcon);

		}
		private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			GlobalAudioHelper.AppMainHandler = Process.GetCurrentProcess().MainWindowHandle;
			//await J2M();
			Common.danmuSetting = Util.LoadDanmuSetting();
			for (int i = 0; i < WaveOut.DeviceCount; i++)
			{
				WaveOutCapabilities capabilities = WaveOut.GetCapabilities(i);
				comboxAudioDevices.Items.Add(capabilities.ProductName);
			}
			if (WaveOut.DeviceCount > Common.danmuSetting.GlobalConfig.AudioDeviceNumber)
			{
				comboxAudioDevices.SelectedIndex = Common.danmuSetting.GlobalConfig.AudioDeviceNumber;
			}
			Common.danmuSetting.Agent.Id = "";
			Common.danmuSetting.Agent.Contact = Config.Contact;
			Common.danmuSetting.Agent.Title = Config.softTitle;
			Common.danmuSetting.Agent.IsAgent = false;
			Common.danmuSetting.Agent.AgentUIVisible = Visibility.Visible;
			txtUrl.Text = Common.danmuSetting.LastLiveUrl;

			if (Common.danmuSetting.Agent.Id.ToLower() == "laoban")
			{
				PluginItemCtlPK2.Visibility = Visibility.Visible;
			}
			else
			{
				PluginItemCtlPK2.Visibility = Visibility.Collapsed;
			}
			AppMenuBackground.DataContext = Common.danmuSetting.AppTheme;
			lbHomeAppTitle.Content = Common.danmuSetting.Agent.Title + " v" + Config.softVersion + " [" + Common.VipLevelTitle + "]";
			if (Common.VIPLevel >= 1)
			{
				FakeDanmuHelper.Start();
				SilenceHelper.Start();
				await TimerSpeakHelper.Start();
				await AutoReplyHelper.Start();
			}
			if (Common.VIPLevel >= 2)
			{
				OBSCommandCenter.Uou();
				//SocketServer.Start();
			}
			base.DataContext = Common.danmuSetting;
			NoticeDanmuStart();
			Win32API.InstallHook();
			gridLoading.Visibility = Visibility.Collapsed;
		}
		public static async void NoticeDanmuStart()
		{
			try
			{
				//if (Common.danmuSetting.NoticeDanmu.Enabled && Common.danmuSetting.NoticeDanmu.Notices.Count > 0)
				//{
				//	foreach (NoticeItem notice in Common.danmuSetting.NoticeDanmu.Notices)
				//	{
				//		if (!OLu.Contains(notice.DateTime))
				//		{
				//			double totalMilliseconds = (DateTime.Now - notice.DateTime).TotalMilliseconds;
				//			if (totalMilliseconds >= 0.0 && totalMilliseconds < 1000.0)
				//			{
				//				OLu.Add(notice.DateTime);
				//				new NoticeDanmuPlayer(notice.Msg ?? "").Show();
				//			}
				//		}
				//	}
				//}
			}
			catch
			{
			}
			if (!Common.AppClosed)
			{
				await Task.Delay(300);
				NoticeDanmuStart();
			}
		}
		private void btnPluginItem_Click(object sender, RoutedEventArgs e)
		{
			PluginItemCtl pluginItem = sender as PluginItemCtl;
			if (pluginItem == null)
			{
				return;
			}

			string pluginName = pluginItem.Tag as string;
			if (string.IsNullOrEmpty(pluginName))
			{
				return;
			}

			switch (pluginName)
			{
				case "Roll":
					RollHelper.ShowWindow();
					break;
				case "Muyu":
					if (_muyuWindow == null || _muyuWindow.IsClosed)
					{
						_muyuWindow = new MuyuWindow();
					}
					_muyuWindow.Show();
					_muyuWindow.Activate();
					break;
				case "Timer":
					//YoX.To5();
					break;
				case "OBSCmd":
					OBSCommandCenter.ShowOBSCmdWindow();
					break;
				case "GiftPK":
					GiftPKHandler.ShowGiftPKWindow();
					break;
				case "HitGift":
					HitGiftManager.ShowHitGiftWindow();
					break;
				case "ChatGPT":
					GPTHelper.ShowWindow();
					break;
				case "ChatBot":
					ChatBotHelper.ShowWindow();
					break;
				case "FakeGift":
					FakeGiftManager.ShowFakeGiftWindow();
					break;
				case "DanmuApi":
					//WGJ.QGY();
					break;
				case "RoomRank":
					RoomRankHelper.ShowRankWindow();
					break;
				case "Overtime":
					if (_overtimeWindow == null || _overtimeWindow.IsClosed)
					{
						_overtimeWindow = new OvertimeWindow();
					}
					_overtimeWindow.Show();
					_overtimeWindow.Activate();
					break;
				case "RobotEva":
					//GfV.cfB();
					break;
				case "TextList":
					//zoT.Noo();
					break;
				case "Intercut":
					if (_intercutWindow == null || _intercutWindow.IsClosed)
					{
						_intercutWindow = new IntercutWindow();
					}
					_intercutWindow.Show();
					_intercutWindow.Activate();
					break;
				case "MusicBox":
					MusicHelper.ShowWindow();
					break;
				case "RelayTool":
					//NLV.BLB();
					break;
				case "DanmuPage":
					AddPlayer("正在等待弹幕数据。。。");
					break;
				case "GiftPK2.0":
					break;
				case "FakeRenqi":
					RenqiHelper.ShowWindow();
					break;
				case "SendDanmu":
					DanmuSender.ShowSendDanmuWindow();
					break;
				case "Validator":
					System.Windows.MessageBox.Show("开发中...敬请期待！");
					break;
				case "FakeDanmu":
					FakeDanmuHelper.ShowWindow();
					break;
				case "DanmuVote":
					VoteHelper.ShowWindow();
					break;
				case "ScreenText":
					//NLV.BLB();
					break;
				case "TimerSpeak":
					TimerSpeakHelper.ShowWindow();
					break;
				case "WebEffects":
					if (_webEffectsWindow == null || _webEffectsWindow.IsClosed)
					{
						_webEffectsWindow = new WebEffectsWindow();
					}
					_webEffectsWindow.Show();
					_webEffectsWindow.Activate();
					break;
				case "ActiveCode":
					//NLV.BLB();
					break;
				case "Live2DRoles":
					//NLV.BLB();
					break;
				case "PrintAvatar":
					PrintAvatarHelper.ShowWindow();
					break;
				case "TimerNotice":
					//NLV.BLB();
					break;
				case "DanmuTriger":
					EventDanmuManager.ShowEventDanmuWindow();
					break;
				case "RoomControl":
					if (m1f == null || m1f.IsClosed)
					{
						m1f = new RoomControlWindow();
					}
					m1f.Show();
					m1f.Activate();
					break;
				case "MediaTriger":
					MediaTriggerManager.ShowMediaTriggerWindow();
					break;
				case "PicResource":
					//NLV.BLB();
					break;
				case "VoiceSetting":
					if (YoE == null || YoE.IsClosed)
					{
						YoE = new VoiceSettingsWindow();
					}
					YoE.Show();
					YoE.Activate(); break;
				case "SilenceSpeak":
					SilenceHelper.ShowWindow();
					break;
				case "FlyDanmuPage":
					FloatScreenHelper.ShowWindow();
					break;
				case "FullDanmuPage":
					//NLV.BLB();
					break;
				case "SoundAssistant":
					SoundAssistantHelper.ShowWindow();
					break;
				case "DanmuAutoReply":
					AutoReplyHelper.ShowWindow();
					break;

				case "GiftInteraction":
					GiftInteractionHelper.ShowWindow();
					break;
				case "MouseKeyboardTool":
					break;
				default:
					// 可以添加默认逻辑或者记录未知插件的日志
					break;
			}
		}
		private void tSa(object object_0, BotResult botResult_0)
		{
			if (botResult_0.OK)
			{
				ChatBotHelper.BotResultList.Add(botResult_0);
			}
		}
		private bool IsInBlackList(string input)
		{
			// 如果黑名单为空或不存在，则直接返回false
			if (string.IsNullOrEmpty(Common.danmuSetting.BlackList))
			{
				return false;
			}

			// 将黑名单字符串按换行符分割成数组
			string[] blacklistItems = Common.danmuSetting.BlackList.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

			// 遍历数组，检查是否有任何黑名单项与输入字符串匹配
			foreach (var item in blacklistItems)
			{
				// 去除黑名单项和输入字符串的前后空白字符，并比较它们是否相等
				if (!string.IsNullOrWhiteSpace(item) && item.Trim().Equals(input.Trim()))
				{
					return true; // 找到匹配的黑名单项，返回true
				}
			}

			// 没有找到匹配的黑名单项，返回false
			return false;
		}
		public async void WebBrowserHelper_DanmuDataChanged(object sender, DanmuData e)
		{
			if (e.Type == DanmuType.Chat || e.Type == DanmuType.Like || e.Type == DanmuType.Follow || e.Type == DanmuType.Gift)
			{
				Common.lastIneractTime = DateTime.Now;
			}
			if (!IsInBlackList(e.UserNick))
			{
				await PushDanmuData(e);
				Common.CacheData.Add(e);
				if (Common.CacheData.Count > 30)
				{
					Common.CacheData.RemoveAt(0);
				}
				if (Common.CacheData.Take(30).Count((DanmuData x) => x.Type == DanmuType.Like && x.UserNick == e.UserNick) <= 1)
				{
					Common.latestDanmudata = e;
					await ProcessVoiceDanmuAsync(e);
				}
			}
		}
		public async Task PushDanmuData(DanmuData data)
		{
			foreach (DanmuPlayer item in _danmuPlayerList)
			{
				item.AddDanmuDataMessage(data);
			}
			ChatBotHelper.AddData(data);
			AutoReplyHelper.AGt(data);
			Util.AddKeyUserDanmuData(data);
			await ProcessDanmuAsync(data);
			//SocketServer.SendMessage(data);
			//APIHelper.PostUrl(data);
			MusicHelper.AddUserMusic(data);
			//WebPlayerHelper.OnDanmuArrived(data);
			EventDanmuManager.HandleConditionalDanmuEvent(data);
			//GfV.VfI(data);
			GPTHelper.AddData(data);
			VoteHelper.AddData(data);
			PrintAvatarHelper.AddData(data);
			GiftInteractionHelper.AddData(data);
			RollHelper.AddData(data);
			FloatScreenHelper.AddData(data);
			//NLV.bLI(data);
			//duZ.yuR(data);
			_muyuWindow?.AddData(data);
			AppLog.SaveDanmu(data);
			_overtimeWindow?.AddData(data);
			SoundAssistantHelper.AddData(data);
			FakeGiftManager.HandleDanmuData(data);
			DanmuSender.ProcessDanmuData(data);
			GiftPKHandler.ProcessDanmuData(data);
			//pwQ.Rwn(data);
			OBSCommandCenter.EoL(data);
			MediaTriggerManager.HandleDanmuData(data);
			HitGiftManager.ProcessDanmuData(data);
		}
		private async Task ProcessDanmuAsync(DanmuData danmuData)
		{
			// 定义一个变量来标记是否应该处理弹幕数据
			bool shouldProcess = false;

			// 根据弹幕类型和设置决定是否处理弹幕
			if (danmuData.Type == DanmuType.Chat && Common.danmuSetting.DanmuDetailPage.OptTypes.ChatEnabled)
			{
				shouldProcess = true;
			}
			else if (danmuData.Type == DanmuType.Follow && Common.danmuSetting.DanmuDetailPage.OptTypes.FollowEnabled)
			{
				shouldProcess = true;
			}
			else if (danmuData.Type == DanmuType.Like && Common.danmuSetting.DanmuDetailPage.OptTypes.LikeEnabled)
			{
				shouldProcess = true;
			}
			else if (danmuData.Type == DanmuType.EnterRoom && Common.danmuSetting.DanmuDetailPage.OptTypes.EnterRoomEnabled)
			{
				shouldProcess = true;
			}
			else if (danmuData.Type == DanmuType.Gift && Common.danmuSetting.DanmuDetailPage.OptTypes.GiftEnabled)
			{
				shouldProcess = true;
			}

			// 如果弹幕数据应该被处理，并且满足特定条件（例如用户等级），则将其添加到存档
			if (shouldProcess && danmuData.UserV5Level >= Common.danmuSetting.DanmuDetailPage.Int32_0)
			{
				Common.ArchiveDanmuData.Add(danmuData);
			}

			// 由于方法现在返回 Task，我们可以使用 await 关键字等待其完成
			await Task.CompletedTask;
		}
		private async Task ProcessVoiceDanmuAsync(DanmuData danmuData)
		{
			// 如果弹幕数据指示静音，则直接返回
			if (danmuData.Mute)
			{
				return;
			}

			// 获取语音弹幕设置
			var voiceDanmuSettings = Common.danmuSetting.VoiceDanmu;
			if (voiceDanmuSettings?.Enabled ?? false)
			{
				// 根据弹幕类型和设置决定是否播放语音
				bool shouldPlayVoice = false;
				switch (danmuData.Type)
				{
					case DanmuType.Chat:
						shouldPlayVoice = voiceDanmuSettings.OptTypes.ChatEnabled;
						break;
					case DanmuType.Follow:
						shouldPlayVoice = voiceDanmuSettings.OptTypes.FollowEnabled;
						break;
					case DanmuType.Like:
						shouldPlayVoice = voiceDanmuSettings.OptTypes.LikeEnabled;
						break;
					case DanmuType.EnterRoom:
						shouldPlayVoice = voiceDanmuSettings.OptTypes.EnterRoomEnabled;
						break;
					case DanmuType.Gift:
						shouldPlayVoice = voiceDanmuSettings.OptTypes.GiftEnabled;
						break;
					case DanmuType.App:
						// 特殊情况处理，例如设置粉丝等级
						danmuData.FansClubLevel = 60;
						shouldPlayVoice = true;
						break;
				}

				// 如果弹幕类型不满足播放条件或者粉丝等级低于最小值，则不播放语音
				if (shouldPlayVoice && danmuData.FansClubLevel < voiceDanmuSettings.FansClubLevelMini)
				{
					shouldPlayVoice = false;
				}

				// 如果决定播放语音，则执行语音弹幕播放操作
				if (shouldPlayVoice)
				{
					await VoiceHelper.VoiceDanmu(danmuData);
					// 如果存在最新的弹幕数据且当前处理的不是最新的，则递归调用此方法处理最新弹幕
					if (Common.latestDanmudata != null && !ReferenceEquals(danmuData, Common.latestDanmudata))
					{
						await ProcessVoiceDanmuAsync(Common.latestDanmudata);
					}
				}
			}
		}
		public void AddInstanceNormalPlayer(DanmuPlayer danmuPlayer)
		{
			try
			{
				int num = _danmuPlayerList.Count + 1;
				_danmuPlayerList.Add(danmuPlayer);
				danmuPlayer.SetTitle("弹幕页" + num);
				danmuPlayer.Show();
				danmuPlayer.AddSysDanmuData("正在等待数据...");
			}
			catch
			{
			}
		}
		private void M8n(object sender, RoutedEventArgs e)
		{
			ShowLiveWindow();
		}
		public async void ShowLiveWindow()
		{
			if (_liveWebWindow == null)
			{
				await messageTip.ShowMessageTip("当前没有连接任何直播间！", isWarningOrError: true, 2222);
				return;
			}
			_liveWebWindow.ShowWind();
			_liveWebWindow.WindowState = WindowState.Normal;
			_liveWebWindow.Activate();
		}

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
		private void tabctl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems == null || e.AddedItems.Count <= 0 || !(e.AddedItems[0] is TabItem tabItem))
			{
				return;
			}
			if (tabItem.Name == "tabItemDanmuDetail" && gridDanmuDetail.Children.Count <= 0)
			{
				gridDanmuDetail.Children.Add(new DanmuSaveCtl());
			}
			if (tabItem.Header != null)
			{
				((tabItem.Header as Grid).Children[0] as TextBlock).Foreground = new SolidColorBrush(Colors.White);
				tabItem.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(20, 47, 65));
			}
			foreach (TabItem item in tabctl.Items)
			{
				if (!item.Equals(tabItem))
				{
					item.Background = new SolidColorBrush(Colors.Transparent);
					if (item.Header != null)
					{
						((item.Header as Grid).Children[0] as TextBlock).Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(214, 214, 214));
					}
				}
			}
		}
		private async void btnGo_Click(object sender, RoutedEventArgs e)
		{
			//if (!Common.isVIP)
			//{
			//	BuyVipWindow buyVipWindow = new BuyVipWindow();
			//	buyVipWindow.Owner = this;
			//	buyVipWindow.ShowDialog();
			//	return;
			//}
			Process[] processesByName = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
			if (processesByName.Length > 1)
			{
				if (Common.VIPLevel < 1)
				{
					await messageTip.ShowMessageTip("不支持多开！【高级版】才支持多开。如果没有多开却提示，请检查任务栏小图标看是否已经启动有一个弹幕助手，如没有，请在【任务管理器】里结束【抖灵】再启动软件");
					System.Windows.Application.Current.Shutdown();
					return;
				}
				if (Common.VIPLevel < 2 && processesByName.Length > 3)
				{
					await messageTip.ShowMessageTip("高级版多开已达上限，请开通【互动版】无限多开！");
					System.Windows.Application.Current.Shutdown();
					return;
				}
			}
            Common.StartAppCount = processesByName.Length;

            if (txtUrl.Text.Trim().StartsWith("https://live.kuaishou.com/u/") || txtUrl.Text.StartsWith("https://livev.m.chenzhongtech.com/fw/live"))
            {
                Common.CurrLiveUrl = txtUrl.Text.Trim();
                Common.CurrLivePlatform= LivePlatform.KuaiShou;
                //messageTip.ShowMessageTip("输入的直播地址不正确", isWarningOrError: true, 3222);
                //return;
            }
            else if (new Regex("^[a-zA-Z0-9_]{5,20}$").Match(txtUrl.Text.Trim()).Success)
            {
                Common.CurrLiveUrl = "https://live.douyin.com/" + txtUrl.Text.Trim();
                Common.CurrLivePlatform = LivePlatform.Douyin;

            }
            else
            {
                if (!txtUrl.Text.Trim().StartsWith("https://live.douyin.com/"))
                {
                    await messageTip.ShowMessageTip("输入的直播地址或者抖音号、直播间房间号不正确", isWarningOrError: true, 3222);
                    return;
                }
                Common.CurrLivePlatform = LivePlatform.Douyin;
                Common.CurrLiveUrl = txtUrl.Text.Trim();
            }

            Common.danmuSetting.LastLiveUrl = Common.CurrLiveUrl;

			Util.SaveDanmuSetting();
			if (_liveWebWindow == null)
			{
				_liveWebWindow = new LiveWebWindow();
			}
			_liveWebWindow.Show();

			await _liveWebWindow.OpenPage(Common.CurrLiveUrl + "?t=" + DateTime.Now.ToFileTime() + "&" + E2b());
			if (_danmuPlayer == null || _danmuPlayer.IsClosed)
			{
				AddPlayer("开始连接...");
			}
			Common.latestDanmudata = new DanmuData
			{
				Type = DanmuType.App,
				UserNick = "",
				Msg = "系统：开始连接...",
				Mute = true
			};
			ChatBotHelper.ClearAllCache();
		}
		private string E2b()
		{
			string text = DateTime.Now.ToString("yyyyMMddhhmmss");
			return "cover_type=0&enter_from_merge=web_live&enter_method=web_card&game_name=&is_recommend=1&live_type=game&more_detail=&request_id=" + text + "5D79BD5AFB9D743B91" + Common.rnd.Next(11, 99);
		}
		public void AddPlayer(string msg, bool isTypeWaterFall = false)
		{
			int num = _danmuPlayerList.Count + 1;
			if (_danmuPlayer == null || _danmuPlayer.IsClosed)
			{
				_danmuPlayer = new DanmuPlayer();
				_danmuPlayerList.Add(_danmuPlayer);
			}
			_danmuPlayer.SetTitle("弹幕页" + num);
			_danmuPlayer.Show();
			_danmuPlayer.AddSysDanmuData(msg);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Common.danmuSetting.AppTheme.BackgroundBrush = (sender as System.Windows.Controls.Button).Background;
		}
		private SolidColorBrush o8w()
		{
			System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
			colorDialog.AllowFullOpen = true;
			if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				return new SolidColorBrush
				{
					Color = new System.Windows.Media.Color
					{
						A = colorDialog.Color.A,
						B = colorDialog.Color.B,
						G = colorDialog.Color.G,
						R = colorDialog.Color.R
					}
				};
			}
			return null;
		}
		private void btnCustThemaColor_Click(object sender, RoutedEventArgs e)
		{
			SolidColorBrush solidColorBrush = o8w();
			if (solidColorBrush != null)
			{
				Common.danmuSetting.AppTheme.BackgroundBrush = solidColorBrush;
			}
		}

		private void comboxAudioDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (comboxAudioDevices.SelectedItem != null)
			{
				Common.danmuSetting.GlobalConfig.AudioDeviceNumber = comboxAudioDevices.SelectedIndex;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			tabctl.SelectedItem = tabItemSetting;
		}

		private void btnMinWindow_Click(object sender, RoutedEventArgs e)
		{
			base.ShowInTaskbar = true;
			base.Visibility = Visibility.Visible;
			base.WindowState = WindowState.Minimized;
		}

		private void x_Click(object sender, RoutedEventArgs e)
		{
			base.ShowInTaskbar = false;
			base.Visibility = Visibility.Hidden;
			_notifyIcon.Text = "抖灵 已最小化到系统托盘！";
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			txtAppNotice.Text = Common.danmuSetting.AppNotice.Msg;
			gridAppNotice.Visibility = Visibility.Visible;
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			ShowLiveWindow();
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			gridAppNotice.Visibility = Visibility.Collapsed;
		}
	}
}