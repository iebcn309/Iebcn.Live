using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// OBSCmdWindow.xaml 的交互逻辑
	/// </summary>
	public partial class OBSCmdWindow : Window, IComponentConnector, IStyleConnector
	{
		public SolidColorBrush connOKForeground;

		public SolidColorBrush connFailedForeground;

		private OBSCmd DJa;

		[CompilerGenerated]
		private bool MJN;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return MJN;
			}
			[CompilerGenerated]
			private set
			{
				MJN = value;
			}
		}

		public OBSCmdWindow()
		{
			InitializeComponent();
			gridLog.Visibility = Visibility.Collapsed;
			connOKForeground = new SolidColorBrush(Colors.Green);
			connFailedForeground = new SolidColorBrush(Colors.Red);
			base.DataContext = (DJa = Common.danmuSetting.OBSCmd);
			listBoxObsCmd.ItemsSource = DJa.SavedCmdList;
			txtLog.DataContext = OBSCommandCenter.Log;
			base.Loaded += ObB;
			bbI();
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

		private void ObB(object sender, RoutedEventArgs e)
		{
		}

		private async void bbI()
		{
			while (!IsClosed)
			{
				if (OBSCommandCenter.DanmuDataCache == null)
				{
					lbCacheCount.Content = 0;
				}
				else
				{
					lbCacheCount.Content = OBSCommandCenter.DanmuDataCache.Count;
				}
				await Task.Delay(1000);
			}
		}

		public void UpdateConnState(bool success)
		{
			if (!success)
			{
				base.Dispatcher.Invoke(delegate
				{
					lbConnState.Foreground = connFailedForeground;
					lbConnState.Content = "已断开连接";
				});
				return;
			}
			base.Dispatcher.Invoke(delegate
			{
				lbConnState.Foreground = connOKForeground;
				lbConnState.Content = "连接成功";
				comboxGiftObsSences.ItemsSource = null;
				comboxChatObsSences.ItemsSource = null;
				comboxLikeObsSences.ItemsSource = null;
				comboxGiftObsSences.ItemsSource = OBSCommandCenter.SceneNames;
				comboxChatObsSences.ItemsSource = OBSCommandCenter.SceneNames;
				comboxLikeObsSences.ItemsSource = OBSCommandCenter.SceneNames;
				if (OBSCommandCenter.SceneNames.Count > 0)
				{
					comboxGiftObsSences.SelectedIndex = 0;
					comboxChatObsSences.SelectedIndex = 0;
					comboxLikeObsSences.SelectedIndex = 0;
				}
			});
		}

		private void ubE(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

		private void sbl(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Ybz(object sender, RoutedEventArgs e)
		{
			OBSCmdItem item = (sender as Button).Tag as OBSCmdItem;
			DJa.SavedCmdList.Remove(item);
		}

		private async void PJs(object sender, RoutedEventArgs e)
		{
			if ((sender as Button).Tag is OBSCmdItem obscmdItem_)
			{
				await OBSCommandCenter.To1(obscmdItem_);
			}
		}

		private void AJx(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				Util.PromptPurchase(2);
			}
		}

		private void MJd(object sender, RoutedEventArgs e)
		{
			OBSCommandCenter.ConnectOBSWebSocket();
		}

		private void pJH(object sender, RoutedEventArgs e)
		{
			if (comboxGiftObsSences.SelectedItem == null)
			{
				MessageBox.Show("没有选择OBS【场景】，请连接到 OBS websocket服务器");
			}
			else if (comboxGiftObsAssets.SelectedItem == null)
			{
				MessageBox.Show("没有OBS场景【素材】，请连接到 OBS websocket服务器，且确保OBS场景里添加有素材");
			}
			else if (!DJa.SavedCmdList.Any((OBSCmdItem obscmdItem_0) => obscmdItem_0.DType == DanmuType.Gift && obscmdItem_0.GiftName == txtGiftName.Text.Trim()))
			{
				DJa.SavedCmdList.Add(new OBSCmdItem
				{
					DType = DanmuType.Gift,
					GiftName = txtGiftName.Text.Trim(),
					Cmd1Open = (comboxGiftObsCmdType.SelectedIndex == 0),
					Cmd2Open = (comboxGiftObsCmdType2.SelectedIndex == 0),
					CmdLastSeconds = numGiftObsCmdLastSeconds.Value,
					Sence = comboxGiftObsSences.SelectedItem.ToString(),
					SenceItem = comboxGiftObsAssets.SelectedItem.ToString()
				});
			}
			else
			{
				MessageBox.Show("礼物名已经存在指令列表里！");
			}
		}

		private void OJK(object sender, RoutedEventArgs e)
		{
			if (comboxChatObsSences.SelectedItem != null)
			{
				if (comboxChatObsAssets.SelectedItem != null)
				{
					if (txtChatWord.Text.Trim() == "")
					{
						MessageBox.Show("弹幕文字不能为空！");
						return;
					}
					if (DJa.SavedCmdList.Any((OBSCmdItem obscmdItem_0) => obscmdItem_0.DType == DanmuType.Chat && obscmdItem_0.ChatWord == txtChatWord.Text.Trim()))
					{
						MessageBox.Show("弹幕词语已经存在指令列表里！");
						return;
					}
					DJa.SavedCmdList.Add(new OBSCmdItem
					{
						DType = DanmuType.Chat,
						ChatWord = txtChatWord.Text.Trim(),
						Cmd1Open = (comboxChatObsCmdType.SelectedIndex == 0),
						Cmd2Open = (comboxChatObsCmdType2.SelectedIndex == 0),
						CmdLastSeconds = numChatObsCmdLastSeconds.Value,
						Sence = comboxChatObsSences.SelectedItem.ToString(),
						SenceItem = comboxChatObsAssets.SelectedItem.ToString()
					});
				}
				else
				{
					MessageBox.Show("没有OBS场景【素材】，请连接到 OBS websocket服务器，且确保OBS场景里添加有素材");
				}
			}
			else
			{
				MessageBox.Show("没有选择OBS【场景】，请连接到 OBS websocket服务器");
			}
		}

		private void HJQ(object sender, RoutedEventArgs e)
		{
			if (comboxLikeObsSences.SelectedItem == null)
			{
				MessageBox.Show("没有选择OBS【场景】，请连接到 OBS websocket服务器");
			}
			else if (comboxLikeObsAssets.SelectedItem == null)
			{
				MessageBox.Show("没有OBS场景【素材】，请连接到 OBS websocket服务器，且确保OBS场景里添加有素材");
			}
			else if (!DJa.SavedCmdList.Any((OBSCmdItem x) => x.DType == DanmuType.Like))
			{
				DJa.SavedCmdList.Add(new OBSCmdItem
				{
					DType = DanmuType.Like,
					Cmd1Open = (comboxLikeObsCmdType.SelectedIndex == 0),
					Cmd2Open = (comboxLikeObsCmdType2.SelectedIndex == 0),
					CmdLastSeconds = numLikeObsCmdLastSeconds.Value,
					Sence = comboxLikeObsSences.SelectedItem.ToString(),
					SenceItem = comboxLikeObsAssets.SelectedItem.ToString()
				});
			}
			else
			{
				MessageBox.Show("点赞已经存在指令列表里！");
			}
		}

		private void nJe(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Visible;
		}

		private void dJq(object sender, RoutedEventArgs e)
		{
			gridLog.Visibility = Visibility.Collapsed;
		}

		private void bJn(object sender, RoutedEventArgs e)
		{
			Util.OpenUrl(Config.HelpUrlObsCtrl);
		}

		private void JJ4(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (comboxGiftObsSences.SelectedItem == null)
				{
					return;
				}
				string text = comboxGiftObsSences.SelectedItem.ToString();
				if (OBSCommandCenter.SceneItems.Keys.Contains(text))
				{
					comboxGiftObsAssets.ItemsSource = OBSCommandCenter.SceneItems[text];
					if (OBSCommandCenter.SceneItems[text].Count > 0)
					{
						comboxGiftObsAssets.SelectedIndex = 0;
					}
				}
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.Message ?? "");
			}
		}

		private void UJf(object sender, SelectionChangedEventArgs e)
		{
			if (comboxChatObsSences.SelectedItem == null)
			{
				return;
			}
			string text = comboxChatObsSences.SelectedItem.ToString();
			if (OBSCommandCenter.SceneItems.Keys.Contains(text))
			{
				comboxChatObsAssets.ItemsSource = OBSCommandCenter.SceneItems[text];
				if (OBSCommandCenter.SceneItems[text].Count > 0)
				{
					comboxChatObsAssets.SelectedIndex = 0;
				}
			}
		}

		private void NJF(object sender, SelectionChangedEventArgs e)
		{
			if (comboxLikeObsSences.SelectedItem == null)
			{
				return;
			}
			string text = comboxLikeObsSences.SelectedItem.ToString();
			if (OBSCommandCenter.SceneItems.Keys.Contains(text))
			{
				comboxLikeObsAssets.ItemsSource = OBSCommandCenter.SceneItems[text];
				if (OBSCommandCenter.SceneItems[text].Count > 0)
				{
					comboxLikeObsAssets.SelectedIndex = 0;
				}
			}
		}

		private void VJw(object sender, RoutedEventArgs e)
		{
			OBSCommandCenter.ClearDanmuCache();
		}
	}

}
