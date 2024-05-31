using Iebcn.Live.Helper;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// ChatBotSettingWindow.xaml 的交互逻辑
	/// </summary>
	public partial class ChatBotSettingWindow : Window, IComponentConnector
	{
		private ChatBotWindow gAj;

		private ChatBotAnchor MAB;

		private List<int> CAI;
		private ChatBot TSs;
		private string zSH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\ChatBot");
		public bool IsClosed;

		public ChatBotSettingWindow(ChatBotWindow chatBotWindow)
		{
			InitializeComponent();
			gAj = chatBotWindow;
			CAI = new List<int>();
			base.DataContext = (TSs = Common.danmuSetting.ChatBot);
			if (Common.danmuSetting.Agent.IsAgent)
			{
				btnHelp.Visibility = Visibility.Collapsed;
			}
			combSpeakers.ItemsSource = Common.VoiceList;
			myScrollViewer.MaxHeight = SystemParameters.PrimaryScreenHeight - 60.0;
			XA3();
			wAU();
			base.Loaded += PAC;
		}

		private void PAC(object sender, RoutedEventArgs e)
		{
			foreach (Voice item in combSpeakers.Items)
			{
				if (item.SpeakerValue == TSs.Voice.SpeakerValue)
				{
					combSpeakers.SelectedItem = item;
					break;
				}
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				Util.SaveDanmuSetting();
				IsClosed = true;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(GetType()?.ToString() + ex.Message);
			}
		}

		private void XA3()
		{
			if (TSs.Enabled)
			{
				Common.danmuSetting.VoiceDanmu.Enabled = false;
				AutoReply autoReply = Common.danmuSetting.AutoReply;
				Common.danmuSetting.AutoReply.ContentReplyEnabled = false;
				autoReply.ContentReplyEnabled = false;
				Common.danmuSetting.Silence.Enabled = false;
				Common.danmuSetting.TimerSpeak.IsRangeTimeEnabled = false;
				Common.danmuSetting.TimerSpeak.IsHourTimeEnabled = false;
			}
		}

		private void iAO(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}
		private void wAU()
		{
			for (int i = 1; i <= 100; i++)
			{
				string path = zSH + "\\Roles\\" + i + "\\cover.png";
				if (File.Exists(zSH + "\\Roles\\" + i + "\\talk.mp4") && File.Exists(zSH + "\\Roles\\" + i + "\\idle.mp4") && File.Exists(path))
				{
					try
					{
						ChatbotRoleCoverCtl element = new ChatbotRoleCoverCtl(this, i)
						{
							Width = 96.0,
							Height = 122.0
						};
						rolesPanel.Children.Insert(0, element);
						CAI.Add(i);
					}
					catch
					{
					}
				}
			}
		}
		public void SetRole(int roleId)
		{
			gAj.SetRole(roleId);
		}

		public void RemoveRole(ChatbotRoleCoverCtl roleCoverCtl)
		{
		}

		private void NAW(object sender, RoutedEventArgs e)
		{
		}

		private void jAa(object sender, RoutedEventArgs e)
		{
			gridCustText.Visibility = Visibility.Collapsed;
		}

		private void GAN(object sender, RoutedEventArgs e)
		{
			gridCustText.Visibility = Visibility.Visible;
		}

		private void gAP(object sender, RoutedEventArgs e)
		{
			Common.danmuSetting.VoiceDanmu.Voice.Platform = VoicePlatform.Ali;
			Common.danmuSetting.VoiceDanmu.Voice.SpeakerName = "阿里:活力女声-猫小美";
			Common.danmuSetting.VoiceDanmu.Voice.SpeakerValue = "maoxiaomei";
			Common.danmuSetting.VoiceDanmu.Voice.Volume = 100;
			Common.danmuSetting.VoiceDanmu.Voice.Speed = 50;
			Common.danmuSetting.VoiceDanmu.Voice.Pitch = 78;
			Common.danmuSetting.ChatBot.Voice = Common.danmuSetting.VoiceDanmu.Voice;
			combSpeakers.Text = Common.danmuSetting.VoiceDanmu.Voice.SpeakerName;
			sldVolume.Value = Common.danmuSetting.VoiceDanmu.Voice.Volume;
			sldSpeed.Value = Common.danmuSetting.VoiceDanmu.Voice.Speed;
			sldPitch.Value = Common.danmuSetting.VoiceDanmu.Voice.Pitch;
		}

		private void CAu(object sender, RoutedEventArgs e)
		{
			Common.danmuSetting.VoiceDanmu.Voice.Platform = VoicePlatform.Dui;
			Common.danmuSetting.VoiceDanmu.Voice.SpeakerName = "精品甜美女声小咪";
			Common.danmuSetting.VoiceDanmu.Voice.SpeakerValue = "xmamif";
			Common.danmuSetting.VoiceDanmu.Voice.Volume = 100;
			Common.danmuSetting.VoiceDanmu.Voice.Speed = 71;
			Common.danmuSetting.VoiceDanmu.Voice.Pitch = 48;
			Common.danmuSetting.ChatBot.Voice = Common.danmuSetting.VoiceDanmu.Voice;
			combSpeakers.Text = Common.danmuSetting.VoiceDanmu.Voice.SpeakerName;
			sldVolume.Value = Common.danmuSetting.VoiceDanmu.Voice.Volume;
			sldSpeed.Value = Common.danmuSetting.VoiceDanmu.Voice.Speed;
			sldPitch.Value = Common.danmuSetting.VoiceDanmu.Voice.Pitch;
		}

		private void BAL(object sender, RoutedEventArgs e)
		{
			Common.danmuSetting.VoiceDanmu.Voice.Platform = VoicePlatform.Dui;
			Common.danmuSetting.VoiceDanmu.Voice.SpeakerName = "精品温柔女声小兰";
			Common.danmuSetting.VoiceDanmu.Voice.SpeakerValue = "gqlanfp";
			Common.danmuSetting.VoiceDanmu.Voice.Volume = 100;
			Common.danmuSetting.VoiceDanmu.Voice.Speed = 95;
			Common.danmuSetting.VoiceDanmu.Voice.Pitch = 53;
			Common.danmuSetting.ChatBot.Voice = Common.danmuSetting.VoiceDanmu.Voice;
			combSpeakers.Text = Common.danmuSetting.VoiceDanmu.Voice.SpeakerName;
			sldVolume.Value = Common.danmuSetting.VoiceDanmu.Voice.Volume;
			sldSpeed.Value = Common.danmuSetting.VoiceDanmu.Voice.Speed;
			sldPitch.Value = Common.danmuSetting.VoiceDanmu.Voice.Pitch;
		}

		private void IA1(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("可在软件主界面菜单的[设置]->语音播报;选择发言人，和调节语速，音调哦");
		}

		private void oAm(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void wAr(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void nAA(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				Util.PromptPurchase(2);
			}
		}

		private void iAS(object sender, RoutedEventArgs e)
		{
			gridThanksFormat.Visibility = Visibility.Visible;
		}

		private void XAZ(object sender, RoutedEventArgs e)
		{
			gridThanksFormat.Visibility = Visibility.Collapsed;
		}

		private void hAt(object sender, RoutedEventArgs e)
		{
			gridSettingGptReplyRole.Visibility = Visibility.Visible;
		}

		private void fAD(object sender, RoutedEventArgs e)
		{
			gridSettingGptReplyRole.Visibility = Visibility.Collapsed;
		}

		private void dAc(object sender, RoutedEventArgs e)
		{
			XA3();
		}

		private void wAk(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("请联系客服定制,你可提供一张至少分辨率1024x1820有正面像的图片定制!");
		}

		private void hAM(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (sender != null && combSpeakers.SelectedItem != null && combSpeakers.SelectedItem is Voice voice)
				{
					TSs.Voice.SpeakerValue = voice.SpeakerValue;
					TSs.Voice.SpeakerName = voice.SpeakerName;
					TSs.Voice.Platform = voice.Platform;
					Common.danmuSetting.VoiceDanmu.Voice = TSs.Voice;
					_ = voice.Platform;
				}
			}
			catch
			{
			}
		}

		private void xAi(object sender, RoutedEventArgs e)
		{
			gridGiftAction.Visibility = Visibility.Visible;
		}

		private void eA2(object sender, RoutedEventArgs e)
		{
			gridGiftAction.Visibility = Visibility.Collapsed;
		}

		private void FA8(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl(Config.HelpUrlChatBot);
		}

		private void TAp(object sender, RoutedEventArgs e)
		{
			gridSettingSilence.Visibility = Visibility.Visible;
		}

		private void MAb(object sender, RoutedEventArgs e)
		{
			gridSettingSilence.Visibility = Visibility.Collapsed;
		}


		private void iAJ(object sender, RoutedEventArgs e)
		{
			gridSettingKeyWordReply.Visibility = Visibility.Collapsed;
		}

		private void EAR(object sender, RoutedEventArgs e)
		{
			gridSettingKeyWordReply.Visibility = Visibility.Visible;
		}

		private void XAY(object sender, RoutedEventArgs e)
		{
			gridSettingBotReplyCust.Visibility = Visibility.Visible;
		}

		private void AA0(object sender, RoutedEventArgs e)
		{
			gridSettingBotReplyCust.Visibility = Visibility.Collapsed;
		}

		private void MAh(object sender, RoutedEventArgs e)
		{
			gridCustText.Visibility = Visibility.Collapsed;
		}

		private void kAg(object sender, RoutedEventArgs e)
		{
			if (MAB == null || MAB.IsClosed)
			{
				MAB = new ChatBotAnchor();
			}
			MAB.Show();
			MAB.Activate();
		}

		private void sA9(object sender, RoutedEventArgs e)
		{
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			zA6();
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async Task zA6()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
			VoiceHelper.smethod_0("欢迎使用数字人！我为竭尽全力为你服务哦！", stopOther: true);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
		}

		private void UA7(object sender, RoutedEventArgs e)
		{
			try
			{
				ChatBotHelper.CacheChatDanmuList.Clear();
				ChatBotHelper.CacheTksList.Clear();
				ChatBotHelper.BotResultList.Clear();
			}
			catch
			{
			}
		}

		private void aAT(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl("https://zhuanlan.zhihu.com/p/622791225");
		}

		private void FAG(object sender, RoutedEventArgs e)
		{
			object tag = (sender as Button).Tag;
			object obj;
			if (tag != null)
			{
				obj = tag.ToString();
				if (obj != null)
				{
					goto IL_0021;
				}
			}
			else
			{
				obj = null;
			}
			obj = "";
			goto IL_0021;
		IL_0021:
			int num = int.Parse((string)obj);
			switch (num)
			{
				case 1080:
					TSs.WindowWidth = 1080;
					TSs.WindowHeight = 1920;
					break;
				case 720:
					TSs.WindowWidth = 720;
					TSs.WindowHeight = 1280;
					break;
			}
			if (num == 480)
			{
				TSs.WindowWidth = 480;
				TSs.WindowHeight = 853;
			}
			gAj.UpdateWindowSize();
		}

		private void RAo(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl(Config.WebPage_DownloadRoles);
		}

		private void hAv(object sender, RoutedEventArgs e)
		{
			//sGa.tGP();
		}

	}

}
