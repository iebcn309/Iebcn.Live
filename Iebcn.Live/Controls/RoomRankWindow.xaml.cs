using Iebcn.Live.Helper;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// RoomRankWindow.xaml 的交互逻辑
	/// </summary>
	public partial class RoomRankWindow : Window, IComponentConnector
	{
		private static RoomRankWindow instance = null;
		private static object obj = new object();

		[CompilerGenerated]
		private bool dYB;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return dYB;
			}
			[CompilerGenerated]
			private set
			{
				dYB = value;
			}
		}

		public static RoomRankWindow Instance
		{
			get
			{
				if (instance == null || instance.IsClosed)
				{
					lock (obj)
					{
						if (instance == null || instance.IsClosed)
						{
							instance = new RoomRankWindow();
						}
					}
				}
				return instance;
			}
		}
		public RoomRankWindow()
		{
			InitializeComponent();
			listOnlineRank.ItemsSource = RoomRankHelper.OnlineRankList;
			if (RoomRankHelper.OnlineRankList.Count > 0)
			{
				lbWaitTip.Visibility = Visibility.Collapsed;
			}
			else
			{
				lbWaitTip.Visibility = Visibility.Visible;
			}
		}

		private void pYo(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

		private void MYv(object sender, RoutedEventArgs e)
		{
			Close();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
		}

		private void SYX(object sender, RoutedEventArgs e)
		{
			if (listOnlineRank.Items.Count > 0)
			{
				if (Common.VIPLevel < 2)
				{
					Util.PromptPurchase(2);
				}
				else
				{
					BYy();
				}
			}
		}

		private void BYy()
		{
			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "html|*.html";
				int num = 0;
				if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				{
					return;
				}
				StringBuilder stringBuilder = new StringBuilder();
				string text = "<html><body><p><a href='http://www.douyin163.top/' target='_blank'>抖灵</a>  - 在线榜单: " + listOnlineRank.Items.Count + "</p><enter><table><tr style='background:#ccc;font-size:20px'><td>昵称</td><td>抖音号</td><td>Id</td><td>操作</td></tr>\r\n";
				foreach (DanmuData onlineRank in RoomRankHelper.OnlineRankList)
				{
					num++;
					if (Common.VIPLevel >= 2 || num <= 10)
					{
						stringBuilder.Append("<tr><td>" + onlineRank.UserNick + "</td><td>" + onlineRank.UserDisplayId + "</td><td>" + onlineRank.UserId + "</td><td><a href='https://www.douyin.com/user/" + onlineRank.SecUid + "'>查看主页</a></td></tr>\r\n");
						continue;
					}
					break;
				}
				stringBuilder.Append("</table></center></body></html>");
				string contents = text + stringBuilder.ToString();
				File.WriteAllText(saveFileDialog.FileName, contents);
			}
			catch
			{
			}
		}
	}

}
