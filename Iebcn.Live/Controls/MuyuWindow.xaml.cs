using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// MuyuWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MuyuWindow : Window, IComponentConnector
	{
		private double _totalPoints;
		MemoryStream muyuWav = new MemoryStream();
		private int _animationCounter = 1;

		private Storyboard _animation;

		private Muyu _settings;

		private List<DanmuData> _danmuDataList = new List<DanmuData>();
		public bool IsClosed { get; set; }
		public MuyuWindow()
		{
			InitializeComponent();
			var fs= File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "assets", "Mdt", "muyu.mp3"));
			fs.CopyTo(muyuWav);
			base.DataContext = _settings = Common.danmuSetting.Muyu;
			_animation = base.Resources["sb1"] as Storyboard;
			InitializeDanmuDataList();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
			Util.SaveDanmuSetting();
		}
		public void AddData(DanmuData data)
		{
			if (!IsClosed && Common.VIPLevel >= 1 && (_settings.EnterRoomEnabled || _settings.LikeEnabled || _settings.FollowEnabled || _settings.GiftEnabled || _settings.ChatEnabled))
			{
				if (_danmuDataList.Count > 100)
				{
					_danmuDataList.RemoveAt(0);
				}
				_danmuDataList.Add(data);
			}
		}
		private async void InitializeDanmuDataList()
		{
			// 循环处理弹幕数据列表
			while (true)
			{
				// 用于存储可能捕获的异常
				Exception capturedException = null;

				try
				{
					// 检查退出条件
					if (IsClosed || Common.VIPLevel < 1)
					{
						// 符合退出条件，结束循环
						break;
					}

					// 判断是否需要继续处理弹幕数据
					if (_danmuDataList.Count > 0 &&
						(_settings.EnterRoomEnabled ||
						 _settings.LikeEnabled ||
						 _settings.FollowEnabled ||
						 _settings.GiftEnabled ||
						 _settings.ChatEnabled))
					{
						// 获取并移除列表中最后一个弹幕数据对象
						DanmuData danmuData = _danmuDataList.LastOrDefault();
						_danmuDataList.Remove(danmuData);

						// 处理弹幕数据
						ProcessDanmuData(danmuData);
					}
					else
					{
						// 当前无弹幕数据需要处理或所有功能均未启用，延迟后继续下一轮检查
						await Task.Delay(500);
						continue;
					}
				}
				catch (Exception ex)
				{
					// 捕获并记录异常
					capturedException = ex;
				}

				// 如果捕获到异常，重新抛出并终止循环
				if (capturedException != null)
				{
					ExceptionDispatchInfo.Capture(capturedException).Throw();
				}
			}
		}
		private async void ProcessDanmuData(DanmuData danmuData)
		{
			double pointValue = 0.0;

			try
			{
				switch (danmuData.Type)
				{
					case DanmuType.EnterRoom when _settings.EnterRoomEnabled:
						pointValue = _settings.EnterRoomPoint;
						break;
					case DanmuType.Like when _settings.LikeEnabled:
						pointValue = _settings.LikePoint;
						break;
					case DanmuType.Follow when _settings.FollowEnabled:
						pointValue = _settings.FollowPoint;
						break;
					case DanmuType.Gift when _settings.GiftEnabled:
						pointValue = ParseGiftPoint(danmuData.GiftName);
						break;
					case DanmuType.Chat when _settings.ChatEnabled:
						pointValue = ParseGiftPoint(danmuData.PureMsg);
						break;
				}

				if (pointValue > 0.0)
				{
					if (_settings.SoundEnabled)
					{
						MemoryStream ms= new MemoryStream();
						muyuWav.WriteTo(ms);
						await SoundPlayer.PlaySteam(ms);
					}

					_totalPoints += pointValue;
					lbTotalPoints.Content = ":" + _totalPoints;
					gridFlyUserPoints.Children.Add(new UserMuyuPointCtl(danmuData.UserNickCut, pointValue));
					_animation.Begin(this);
				}
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.ToString());
			}
		}
		private void BST(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Collapsed;
		}
		// 新增方法，用于解析礼物对应的积分值
		private double ParseGiftPoint(string giftOrMessage)
		{
			List<string> lines = _settings.GiftContent.Split('\n').Where(x => x.Trim().Contains("=")).ToList();

			string matchedLine = lines.FirstOrDefault(line =>
			{
				string[] parts = line.Trim().Split('=');
				return parts.Length == 2 && parts[0].Trim() == giftOrMessage;
			});

			if (matchedLine == null)
			{
				matchedLine = lines.FirstOrDefault(line =>
				{
					string[] parts = line.Trim().Split('=');
					return parts.Length == 2 && parts[0].Trim() == "其他";
				});

				if (matchedLine != null)
				{
					return double.Parse(matchedLine.Trim().Split('=')[1].Trim());
				}
			}
			else
			{
				return double.Parse(matchedLine.Trim().Split('=')[1].Trim());
			}

			return 0.0; // 若没有匹配项，返回默认值0.0
		}
		private void Abi(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Gb2(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void Db8(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void cbp(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				Util.PromptPurchase(2);
			}
		}

		private void Sbb(object sender, RoutedEventArgs e)
		{
			if (base.Width < 800.0)
			{
				base.Width = 822.0;
			}
			else
			{
				base.Width = 390;
			}
		}

		private void gbJ(object sender, RoutedEventArgs e)
		{
			base.Width = 390;
		}

		private void PbR(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("例子:\r\n小心心=1\r\n玫瑰花=2\r\n飞机=10\r\n嘉年华=5000\r\n其他=1\r\n（注：‘其他’很特殊，可匹配任何其他礼物）");
		}

		private void JbY(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("例子:\r\n666=1\r\n加油=2\r\n777=3\r\n其他=1\r\n（注：‘其他’很特殊，可匹配任何其他弹幕）");
		}

		private void bb0(object sender, MouseButtonEventArgs e)
		{
			_animationCounter++;
			if (_animationCounter > 3)
			{
				_animationCounter = 1;
			}
			imgMuyu.Source = new BitmapImage(new Uri("/Assets/muyu" + _animationCounter + ".png", UriKind.RelativeOrAbsolute));
		}

		private void mS7(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Visible;
		}
	}

}
