using Iebcn.Live.Helper;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Iebcn.Live.Controls
{
	public partial class DanmuPlayer : Window
	{
		private bool RIR;
		private UIConfig _UIConfig;
		private ObservableCollection<DanmuData> danmuDataCollection = new ObservableCollection<DanmuData>();
		public bool IsClosed;
		Point _pressedPosition;
		bool _isDragMoved = false;

		public DanmuPlayer(bool isNewInstance = false)
		{
			InitializeComponent();
			if (!isNewInstance)
			{
				_UIConfig = Common.danmuSetting.NormalUIConfig;
			}
			else
			{
				_UIConfig = new UIConfig();
			}
			base.DataContext = _UIConfig;
			listDanmu.ItemsSource = danmuDataCollection;
			roomInfoPanel.DataContext = Common.RoomData;
		}

		public void AddSysDanmuData(string msg = "")
		{
			AddDanmuDataMessage(new DanmuData
			{
				UserNick = "系统",
				Msg = msg,
				Type = DanmuType.Chat
			});
		}

		public void AddDanmuDataMessage(DanmuData data)
		{
			try
			{
				if (!Util.HasOptTypes(_UIConfig.Config.OptTypes, data.Type))
				{
					return;
				}
				if (_UIConfig.GiftPriceLimitEnabled && data.DiamondCount < _UIConfig.LimitDiamondCount)
				{
					RIR = false;
					return;
				}
				RIR = true;
				if (data.UserV5Level < _UIConfig.Config.MiniV5Level && (!_UIConfig.GiftPriceLimitEnabled || !RIR))
				{
					return;
				}
				base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate
				{
					if (danmuDataCollection.Count >= 200)
					{
						for (int i = 0; i < 100; i++)
						{
							danmuDataCollection.RemoveAt(0);
						}
					}
					danmuDataCollection.Add(data);
					listDanmu.ScrollIntoView(data);
				});
			}
			catch (Exception)
			{
			}
		}

		void Window_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			_pressedPosition = e.GetPosition(this);
		}
		void Window_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed && _pressedPosition != e.GetPosition(this))
			{
				_isDragMoved = true;
				DragMove();
			}
		}
		void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (_isDragMoved)
			{
				_isDragMoved = false;
				e.Handled = true;
			}
		}

		private void AIa(object sender, System.Windows.Input.MouseEventArgs e)
		{
			bgGrid.Background = new SolidColorBrush(Color.FromArgb(111, 0, 0, 0));
			cmdBarPanel.Visibility = Visibility.Visible;
			roomInfoPanel.Visibility = Visibility.Collapsed;
		}

		private void NIE(object sender, System.Windows.Input.MouseEventArgs e)
		{
			bgGrid.Background = new SolidColorBrush(Color.FromArgb(11, 0, 0, 0));
			cmdBarPanel.Visibility = Visibility.Collapsed;
			if (_UIConfig.Config.RoomInfoEnabled)
			{
				roomInfoPanel.Visibility = Visibility.Visible;
			}
			else
			{
				roomInfoPanel.Visibility = Visibility.Collapsed;
			}
		}

		private void GIW(object sender, RoutedEventArgs e)
		{
			Close();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
		}

		private void IIS(object sender, RoutedEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
		}

		public void SetTitle(string sTitle)
		{
			base.Title = sTitle;
		}

		private void LID(object sender, RoutedEventArgs e)
		{
			object tag = (sender as System.Windows.Controls.Button).Tag;
			string key = tag?.ToString();
			if (!string.IsNullOrEmpty(key))
			{
				listDanmu.ItemTemplate = Resources[key] as DataTemplate;
			}
		}

		private void bgGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			ShowPlayerSettingWindow();
		}

		private void btnFix_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				base.ShowInTaskbar = true;
				cmdBarPanel.Opacity = 0.0;
				Win32API.SetTranMouseWind(this);
			}
			catch (Exception ex)
			{
				AppLog.AddLog("btnFix_Click:" + ex.Message);
			}
		}

		private void btnSetting_Click(object sender, RoutedEventArgs e)
		{
			ShowPlayerSettingWindow();
		}
		private void ShowPlayerSettingWindow()
		{
			PlayerSettingWindow playerSettingWindow = new PlayerSettingWindow(_UIConfig, this);
			playerSettingWindow.Owner = this;
			playerSettingWindow.ShowDialog();
			base.Topmost = _UIConfig.Config.Topmost;
		}

		private void xZT(object sender, RoutedEventArgs e)
		{
			DanmuPlayer danmuPlayer = new DanmuPlayer(isNewInstance: true);
			Common.mainWindow.AddInstanceNormalPlayer(danmuPlayer);
		}

		private void bZo(object sender, RoutedEventArgs e)
		{
			Common.mainWindow?.ShowLiveWindow();
		}

	}

}
