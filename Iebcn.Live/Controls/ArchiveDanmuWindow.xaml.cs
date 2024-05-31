using Iebcn.Live.Helper;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// ArchiveDanmuWindow.xaml 的交互逻辑
	/// </summary>
	public partial class ArchiveDanmuWindow : Window, IComponentConnector, IStyleConnector
	{
		private DispatcherTimer Vnw;

		private bool EnC;

		public bool IsClosed;

		public ArchiveDanmuWindow()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.DanmuDetailPage;
			listDanmu.ItemsSource = Common.ArchiveDanmuData;
			Vnw = new DispatcherTimer();
			Vnw.Interval = TimeSpan.FromMilliseconds(500.0);
			Vnw.Tick += PqE;
			Vnw.Start();
			lbTotalCount.Content = "数据量: " + Common.ArchiveDanmuData.Count + "条";
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

		private void PqE(object sender, EventArgs e)
		{
			if (!IsClosed)
			{
				if (Common.ArchiveDanmuData.Count <= 0)
				{
					return;
				}
				lbTotalCount.Content = "数据量: " + Common.ArchiveDanmuData.Count + "条";
				if (!EnC)
				{
					return;
				}
				try
				{
					Task.Run(delegate
					{
						base.Dispatcher.Invoke(delegate
						{
							listDanmu.ScrollIntoView(listDanmu.Items[listDanmu.Items.Count - 1]);
						});
					});
					return;
				}
				catch
				{
					return;
				}
			}
			Vnw.Stop();
			Vnw = null;
		}

		private void Fql(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

		private void Rqz(object sender, RoutedEventArgs e)
		{
			EnC = false;
			Vnw.Stop();
			Vnw = null;
			Util.SaveDanmuSetting();
			Close();
		}

		private void jns(object sender, RoutedEventArgs e)
		{
			base.WindowState = WindowState.Minimized;
		}

		private void vnx(object sender, RoutedEventArgs e)
		{
			if (base.WindowState == WindowState.Maximized)
			{
				base.WindowState = WindowState.Normal;
				btnMaxWindow.Content = "□";
			}
			else
			{
				base.WindowState = WindowState.Maximized;
				btnMaxWindow.Content = "█";
			}
		}

		private void Wnd(object sender, RoutedEventArgs e)
		{
			EnC = true;
		}

		private void WnH(object sender, RoutedEventArgs e)
		{
			EnC = false;
		}

		private void pnK(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel >= 1)
			{
				vnQ();
			}
			else
			{
				Util.PromptPurchase(1);
			}
		}

		private void vnQ()
		{
			try
			{
				if (listDanmu.Items.Count <= 0)
				{
					return;
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "html|*.html";
				if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				{
					return;
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (DanmuData archiveDanmuDatum in Common.ArchiveDanmuData)
				{
					stringBuilder.Append("<tr><td>[" + archiveDanmuDatum.Timestamp.ToString() + "]</td><td>" + archiveDanmuDatum.UserNick + "</td><td>" + archiveDanmuDatum.UserSex + "</td><td>" + archiveDanmuDatum.UserId + "</td><td>" + archiveDanmuDatum.UserDisplayId + "</td><td>" + archiveDanmuDatum.UserV5Level + "</td><td>" + archiveDanmuDatum.UserFans + "</td><td>" + archiveDanmuDatum.UserFollows + "</td><td>" + archiveDanmuDatum.Msg + "</td><td>" + archiveDanmuDatum.GiftCount + "</td><td><a href='https://www.douyin.com/user/" + archiveDanmuDatum.SecUid + "'>查看主页</a></td></tr>\r\n");
				}
				string text = "<html><body><p><a href='http://www.douyin163.top/' target='_blank'>抖灵</a>  -  " + lbTotalCount.Content?.ToString() + "</p><enter><table><tr style='background:#ccc;font-size:20px'><td>时间</td><td>昵称</td><td>性别</td><td>Id</td><td>抖音号</td><td>蓝V等级</td><td>粉丝数</td><td>关注数</td><td>内容</td><td>礼物数量</td><td>操作</td></tr>\r\n";
				stringBuilder.Append("</table></center></body></html>");
				string contents = text + stringBuilder.ToString();
				File.WriteAllText(saveFileDialog.FileName, contents);
			}
			catch
			{
			}
		}

		private void hne(object sender, RoutedEventArgs e)
		{
			try
			{
				object obj;
				if (Common.VIPLevel >= 1)
				{
					object tag = (sender as System.Windows.Controls.Button).Tag;
					if (tag != null)
					{
						obj = tag.ToString();
						if (obj != null)
						{
							goto IL_002a;
						}
					}
					else
					{
						obj = null;
					}
					obj = "";
					goto IL_002a;
				}
				Util.PromptPurchase(1);
				return;
			IL_002a:
				string text = (string)obj;
				if (!string.IsNullOrEmpty(text))
				{
					Util.OpenUrl("https://www.douyin.com/user/" + text);
				}
			}
			catch
			{
			}
		}

		private void knq(object sender, RoutedEventArgs e)
		{
			if (Common.ArchiveDanmuData.Count <= 0)
			{
				return;
			}
			string text = "";
			try
			{
				var source = from a in Common.ArchiveDanmuData
							 group a by new { a.UserNick } into g
							 select new
							 {
								 Nick = g.Key.UserNick,
								 Count = g.Sum((DanmuData x) => x.GiftCount)
							 };
				int num = 1;
				foreach (var item in (from x in source.ToList()
									  orderby x.Count descending
									  select x).Take(10))
				{
					text = text + num + ") " + item.Nick + ":" + item.Count + "\r\n";
					num++;
				}
				System.Windows.MessageBox.Show(text);
			}
			catch
			{
			}
		}

		private void snn(object sender, RoutedEventArgs e)
		{
			RoomRankHelper.ShowRankWindow();
		}


	}

}
