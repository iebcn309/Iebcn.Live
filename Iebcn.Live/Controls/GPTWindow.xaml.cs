using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using Microsoft.Win32;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// GPTWindow.xaml 的交互逻辑
	/// </summary>
	public partial class GPTWindow : Window, IComponentConnector
	{
		private GPT YMt;

		public bool isBusy;

		public bool IsClosed;

		public List<DanmuData> CacheDanmuList;

		public GPTWindow()
		{
			InitializeComponent();
			gridSetting.Visibility = Visibility.Collapsed;
			CacheDanmuList = new List<DanmuData>();
			base.DataContext = (YMt = Common.danmuSetting?.GPT);
			base.Loaded += tMO;
			YM3();
			gMw();
			dMC();
		}
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			Util.SaveDanmuSetting();
			IsClosed = true;
		}
		public void AddData(DanmuData data)
		{
			if (CacheDanmuList.Count > YMt.CacheMaxCount)
			{
				CacheDanmuList.RemoveAt(0);
			}
			CacheDanmuList.Add(data);
			if (YMt.ReplyFromChinaAI)
			{
				sGa.tGu(data);
			}
		}

		private async void gMw()
		{
			Exception obj4;
			while (true)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (IsClosed || Common.VIPLevel < 2)
						{
							goto end_IL_0045;
						}
						if (!YMt.Enabled || isBusy || YMt.ReplyFromChinaAI)
						{
							goto IL_00bb;
						}
						DanmuData danmuData = CacheDanmuList.LastOrDefault();
						if (danmuData == null)
						{
							goto IL_00bb;
						}
						CacheDanmuList.Remove(danmuData);
						Process(danmuData);
						goto end_IL_0045_2;
					end_IL_0045:;
					}
					catch
					{
						goto end_IL_0045_2;
					}
					num = 2;
					goto end_IL_0045_2;
				IL_00bb:
					num = 1;
				end_IL_0045_2:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(1000);
				obj4 = obj;
				if (obj4 != null)
				{
					Exception obj5 = obj4 as Exception;
					if (obj5 == null)
					{
						break;
					}
					ExceptionDispatchInfo.Capture(obj5).Throw();
				}
				int num2 = num;
				if (num2 != 1 && num2 == 2)
				{
					return;
				}
			}
			throw obj4;
		}

		private async void dMC()
		{
			Exception obj4;
			while (true)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (IsClosed || Common.VIPLevel < 2)
						{
							goto end_IL_0045;
						}
						if (!YMt.Enabled || isBusy || !YMt.ReplyFromChinaAI)
						{
							goto IL_0150;
						}
						if (myStackPanel.Children.Count > 30)
						{
							myStackPanel.Children.RemoveAt(0);
						}
						BotResult botResult = sGa.bGr.LastOrDefault();
						if (botResult == null)
						{
							goto IL_0150;
						}
						sGa.bGr.Remove(botResult);
						DanmuData data = new DanmuData
						{
							UserNick = "网友",
							Msg = "网友:" + botResult.Query
						};
						myStackPanel.Children.Add(new GPTUserCtl(data));
						myStackPanel.Children.Add(new GPTAnswerCtl(botResult.Result));
						scrollview.ScrollToEnd();
						goto end_IL_0045_2;
					end_IL_0045:;
					}
					catch
					{
						goto end_IL_0045_2;
					}
					num = 2;
					goto end_IL_0045_2;
				IL_0150:
					num = 1;
				end_IL_0045_2:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(1000);
				obj4 = obj;
				if (obj4 != null)
				{
					Exception obj5 = obj4 as Exception;
					if (obj5 == null)
					{
						break;
					}
					ExceptionDispatchInfo.Capture(obj5).Throw();
				}
				int num2 = num;
				if (num2 != 1 && num2 == 2)
				{
					return;
				}
			}
			throw obj4;
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void YM3()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			myStackPanel.Children.Add(new GPTAnswerCtl("您好！我是ChatGPT人工智能AI聊天机器人，您可以问我任何问题，也可以让我写任何文章!"));
		}

		private void tMO(object sender, RoutedEventArgs e)
		{
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void Process(DanmuData data)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			if (myStackPanel.Children.Count > 30)
			{
				myStackPanel.Children.RemoveAt(0);
			}
			myStackPanel.Children.Add(new GPTUserCtl(data));
			myStackPanel.Children.Add(new GPTAnswerCtl(data, this));
			scrollview.ScrollToEnd();
		}

		private void JMW(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void TMa(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() == true)
				{
					bgImage.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));
				}
			}
			catch
			{
			}
		}

		private void TMN(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				MessageBox.Show(Common.Msg_NeedVip2);
			}
		}

		private void lMP(object sender, RoutedEventArgs e)
		{
			try
			{
				base.ShowInTaskbar = true;
				gridBar.Visibility = Visibility.Collapsed;
				gridSetting.Visibility = Visibility.Collapsed;
				Win32API.SetTranMouseWind(this);
			}
			catch
			{
			}
		}

		private void bMu(object sender, RoutedEventArgs e)
		{
			TML();
		}

		private void TML()
		{
			if (YMt.Enabled)
			{
				AddData(new DanmuData
				{
					Type = DanmuType.Chat,
					UserNick = "主播测试",
					Msg = "主播测试:" + txtTest.Text
				});
			}
			else
			{
				MessageBox.Show("请先开启！");
			}
		}

		private void mM1(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void nMm(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				TML();
			}
		}

		private void dMr(object sender, RoutedEventArgs e)
		{
			sGa.tGP();
		}

		private void VMA(object sender, RoutedEventArgs e)
		{
			if (gridSetting.Visibility != 0)
			{
				gridSetting.Visibility = Visibility.Visible;
			}
			else
			{
				gridSetting.Visibility = Visibility.Collapsed;
			}
		}

		private void rMS(object sender, RoutedEventArgs e)
		{
			CacheDanmuList.Clear();
		}

	}
	internal class sGa
	{
		private static AIPlatformsWindow pGm;

		public static List<BotResult> bGr = new List<BotResult>();

		public static void tGP()
		{
			if (pGm == null || pGm.IsClosed)
			{
				pGm = new AIPlatformsWindow();
			}
			pGm.Show();
			pGm.Activate();
			pGm.ShowWind();
		}

		public static void tGu(DanmuData danmuData_0)
		{
			if (pGm != null && !pGm.IsClosed)
			{
				pGm.AddData(danmuData_0);
			}
		}
		public static void hGL(BotResult botResult_0)
		{
			bGr.Add(botResult_0);
			ChatBotHelper.BotResultList.Add(botResult_0);
		}

	}

}
