using Iebcn.Live.Helper;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// EventDanmuWindow.xaml 的交互逻辑
	/// </summary>
	public partial class EventDanmuWindow : Window, IComponentConnector
	{
		private DoubleAnimation RtP;

		private DoubleAnimation Ltu;

		private DoubleAnimation ltL;

		private DoubleAnimation Vt1;

		private DoubleAnimation Etm;

		private Storyboard sb1;

		private Storyboard sbDisappear;

		private Storyboard sbFadein;

		private DanmuEventData Ctr;

		private string ptA = "";

		private List<DanmuData> ItS = new List<DanmuData>();

		[CompilerGenerated]
		private bool OtZ;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return OtZ;
			}
			[CompilerGenerated]
			private set
			{
				OtZ = value;
			}
		}

		public EventDanmuWindow()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.EventDanmu;
			base.MouseLeftButtonDown += Ntw;
			base.Loaded += wtC;
			sb1 = base.Resources["sb1"] as Storyboard;
			sbDisappear = base.Resources["sbDisappear"] as Storyboard;
			sbFadein = base.Resources["sbFadein"] as Storyboard;
			RtP = (DoubleAnimation)sb1.Children.First((Timeline x) => x.Name == "t1");
			Ltu = (DoubleAnimation)sb1.Children.First((Timeline x) => x.Name == "t2");
			ltL = (DoubleAnimation)sb1.Children.First((Timeline x) => x.Name == "t3");
			Vt1 = (DoubleAnimation)sb1.Children.First((Timeline x) => x.Name == "t4");
			Etm = (DoubleAnimation)sb1.Children.First((Timeline x) => x.Name == "t5");
			Play();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
			try
			{
				Util.SaveDanmuSetting();
			}
			catch
			{
			}
		}

		public async void Play()
		{
			Exception obj6;
			while (true)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (Common.VIPLevel < 1 || IsClosed)
						{
							goto end_IL_0068;
						}
						if (ItS.Count <= 0)
						{
							goto IL_08cb;
						}
						DanmuData yIf = null;
						if (Common.danmuSetting.EventDanmu.DataGift.Enabled)
						{
							yIf = ItS.LastOrDefault((DanmuData x) => x.Type == DanmuType.Gift);
						}
						if (yIf == null)
						{
							yIf = ItS.LastOrDefault();
						}
						if (yIf == null)
						{
							goto IL_08cb;
						}
						ItS.Remove(yIf);
						if (Common.danmuSetting.EventDanmu.OnlyUsers && !Common.danmuSetting.EventDanmu.UserNicks.Split('|').Any((string x) => x.Trim() == yIf.UserNick))
						{
							goto IL_08cb;
						}
						if (yIf.Type == DanmuType.Gift)
						{
							Ctr = Common.danmuSetting.EventDanmu.DataGift;
							if (Ctr.GiftIgnoreList.Trim() != "" && (from x in Ctr.GiftIgnoreList.Split('|').ToList()
																	where x.Trim() != ""
																	select x).Any((string x) => yIf.GiftName.Contains(x.Trim())))
							{
								goto IL_08cb;
							}
							ptA =  EventDanmuManager.l4V();
						}
						else if (yIf.Type != DanmuType.EnterRoom)
						{
							if (yIf.Type != DanmuType.Like)
							{
								if (yIf.Type != DanmuType.Follow)
								{
									goto IL_08cb;
								}
								ptA =  EventDanmuManager.d4I();
								Ctr = Common.danmuSetting.EventDanmu.DataFollow;
							}
							else
							{
								ptA =  EventDanmuManager.z4B();
								Ctr = Common.danmuSetting.EventDanmu.DataLike;
							}
						}
						else
						{
							ptA =  EventDanmuManager.A4j();
							Ctr = Common.danmuSetting.EventDanmu.DataEnterRoom;
						}
						if (!Ctr.Enabled)
						{
							goto IL_08cb;
						}
						role.MaxHeight = Ctr.PicMaxHeight;
						try
						{
							userHeadPic.ImageSource = new BitmapImage(new Uri(yIf.UserHeadPic, UriKind.RelativeOrAbsolute));
						}
						catch
						{
						}
						try
						{
							if (yIf.Type == DanmuType.Gift && yIf.GiftUrl != "")
							{
								imgGift.Source = new BitmapImage(new Uri(yIf.GiftUrl, UriKind.RelativeOrAbsolute));
								imgGift.Visibility = Visibility.Visible;
							}
							else
							{
								imgGift.Visibility = Visibility.Collapsed;
							}
						}
						catch
						{
						}
						lbWords.Content = Ctr.Words;
						if (Ctr.Words.Trim() == "")
						{
							lbWords.Padding = new Thickness(0.0);
						}
						else
						{
							lbWords.Padding = new Thickness(6.0);
						}
						lbNick.Content = yIf.UserNick;
						lbNick.FontSize = Ctr.NickFontSize;
						ShowPic(yIf.Type);
						if (Ctr.AnimationStyle == EventDanmuAnimationStyle.FromUp)
						{
							Vt1.From = 0.0;
							Etm.From = -800.0;
						}
						else if (Ctr.AnimationStyle == EventDanmuAnimationStyle.FromBottom)
						{
							Vt1.From = 0.0;
							Etm.From = 800.0;
						}
						else if (Ctr.AnimationStyle == EventDanmuAnimationStyle.FromLeft)
						{
							Vt1.From = -800.0;
							Etm.From = 0.0;
						}
						else if (Ctr.AnimationStyle == EventDanmuAnimationStyle.FromRight)
						{
							Vt1.From = 800.0;
							Etm.From = 0.0;
						}
						if (Ctr.AnimationStyle == EventDanmuAnimationStyle.Fadein)
						{
							sbFadein.Begin(this);
						}
						else
						{
							sb1.Begin(this);
						}
						await dtF(yIf.Type);
						await Task.Delay(1000 + 1000 * (int)Ctr.StaySeconds);
						sbDisappear.Begin(this);
						await Task.Delay(300);
						await Task.Delay(1000 * (int)Ctr.IntervalSeconds);
						goto end_IL_0044;
					end_IL_0068:;
					}
					catch
					{
						goto end_IL_0044;
					}
					num = 2;
					goto end_IL_0044;
				IL_08cb:
					num = 1;
				end_IL_0044:;
				}
				catch (Exception obj5)
				{
					obj = obj5;
				}
				await Task.Delay(300);
				obj6 = obj;
				if (obj6 != null)
				{
					Exception obj7 = obj6 as Exception;
					if (obj7 == null)
					{
						break;
					}
					ExceptionDispatchInfo.Capture(obj7).Throw();
				}
				int num2 = num;
				if (num2 != 1 && num2 == 2)
				{
					return;
				}
			}
			throw obj6;
		}
		public void AddData(DanmuData data)
		{
			if (Common.VIPLevel < 1)
			{
				return;
			}
			try
			{
				ItS.Add(data);
				if (ItS.Count > Common.danmuSetting.EventDanmu.CacheMax)
				{
					ItS.RemoveAt(0);
				}
			}
			catch
			{
			}
		}

		private async Task dtF(DanmuType danmuType_0)
		{
			if (Ctr.SoundEnabled)
			{
				string soundFileName = Ctr.SoundFileName;
				soundFileName = ((!(soundFileName == "随机")) ?System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EventDanmuManager.GetEventBasePath(danmuType_0,true), soundFileName) : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EventDanmuManager.GetEventBasePath(danmuType_0, true), EventDanmuManager.GetRandomEventGifFile(danmuType_0)));
				try
				{
					await SoundPlayer.Play(soundFileName, muteOtherSound: true);
				}
				catch
				{
				}
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "" 运算符，将以同步方式运行
		private async void ShowPic(DanmuType type)
#pragma warning restore CS1998 // 异步方法缺少 "" 运算符，将以同步方式运行
		{
			if (!Ctr.PicEnabled)
			{
				role.Visibility = Visibility.Collapsed;
				return;
			}
			try
			{
				if (!string.IsNullOrEmpty(Ctr.PicUrl) && !(Ctr.PicUrl == "Pack://application:,,,/Assets/rnd.jpg") && !(Ctr.PicUrl == "Random"))
				{
					ImageBehavior.SetAnimatedSource(role, new BitmapImage(new Uri(Ctr.PicUrl, UriKind.RelativeOrAbsolute)));
				}
				else
				{
					ptA = System.IO.Path.Combine(EventDanmuManager.GetEventBasePath(type), ptA);
					if (!string.IsNullOrEmpty(ptA))
					{
						ImageBehavior.SetAnimatedSource(role, new BitmapImage(new Uri(ptA, UriKind.RelativeOrAbsolute)));
					}
				}
				role.Visibility = Visibility.Visible;
			}
			catch
			{
			}
		}

		private void Ntw(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void wtC(object sender, RoutedEventArgs e)
		{
		}

		private void at3(object sender, RoutedEventArgs e)
		{
			try
			{
				base.ShowInTaskbar = true;
				cmdBarPanel.Visibility = Visibility.Collapsed;
				Win32API.SetTranMouseWind(this);
			}
			catch (Exception ex)
			{
				AppLog.AddLog("event wind lock err:" + ex.Message);
			}
		}

		private void MtO(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ttU(object sender, RoutedEventArgs e)
		{
			EventDanmuSettingsWindow eventDanmuSettingsWindow = new EventDanmuSettingsWindow();
			eventDanmuSettingsWindow.Owner = this;
			eventDanmuSettingsWindow.ShowDialog();
		}

		private void ftW(object sender, MouseEventArgs e)
		{
			cmdBarPanel.Opacity = 1.0;
		}

		private void jta(object sender, MouseEventArgs e)
		{
			cmdBarPanel.Opacity = 0.0;
		}
	}

}
