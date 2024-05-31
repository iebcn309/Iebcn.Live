using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows;

namespace Iebcn.Live.Controls
{
	public class GClass0 : Window, IComponentConnector, IStyleConnector
	{
		public bool IsClosed;

		internal TextBox txtGiftName;

		internal TextBox txtGiftDesc;

		internal Button btnAdd;

		internal ListBox listBox;

		internal ListBox listBoxUserSend;

		internal Grid gridBar;

		internal Button x;

		private bool IMQ;

		public GClass0()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.GiftPK;
			listBox.ItemsSource = (GiftPKHandler._giftList = Common.danmuSetting.GiftPK.SavedList);
			listBoxUserSend.ItemsSource = GiftPKHandler._userGiftList;
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

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		public async void UpdateUserSendList()
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			try
			{
				if (listBoxUserSend.Items.Count > 1)
				{
					listBoxUserSend.ScrollIntoView(listBoxUserSend.Items[listBoxUserSend.Items.Count - 1]);
				}
			}
			catch
			{
			}
		}

		private void YkB(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void vkI(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void tkE(object sender, RoutedEventArgs e)
		{
			Lkz();
		}

		private void ikl(object sender, RoutedEventArgs e)
		{
			GiftInfo giftInfo_ = (sender as Button).Tag as GiftInfo;
			zMs(giftInfo_);
		}

		private void Lkz()
		{
			try
			{
				string JIl = txtGiftName.Text.Trim();
				GiftInfo YIz = GiftHelper.giftList.FirstOrDefault((GiftInfo x) => x.Name.Contains(JIl));
				if (YIz != null)
				{
					if (GiftPKHandler._giftList.Any((GiftInfo x) => x.Name == YIz.Name))
					{
						MessageBox.Show("已经存在这个礼物PK项目");
						return;
					}
					if (GiftPKHandler._giftList.Count >= 2 && Common.VIPLevel < 2)
					{
						MessageBox.Show("互动版才能添加3个以上礼物PK项目");
						return;
					}
					YIz.Extra = txtGiftDesc.Text.Trim();
					GiftPKHandler._giftList.Add(YIz);
				}
				else
				{
					MessageBox.Show("数据库里没有这个礼物，请检查是否输入正确的礼物名！");
				}
			}
			catch
			{
			}
		}

		private void zMs(GiftInfo giftInfo_0)
		{
			try
			{
				GiftPKHandler._giftList.Remove(giftInfo_0);
			}
			catch
			{
			}
		}

		private void HMx(object sender, RoutedEventArgs e)
		{
			try
			{
				if ((sender as Button).Background is SolidColorBrush fontColor)
				{
					Common.danmuSetting.GiftPK.FontColor = fontColor;
				}
			}
			catch
			{
			}
		}

		private void rMd(object sender, RoutedEventArgs e)
		{
			GiftPKHandler.ResetGiftListCount();
		}

		private void uMH(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				MessageBox.Show("请开通高级版或互动版后操作！");
			}
		}

		[GeneratedCode("PresentationBuildTasks", "8.0.0.0")]
		public void InitializeComponent()
		{
			if (!IMQ)
			{
				IMQ = true;
				Uri resourceLocator = new Uri("/抖灵;component/giftpksettingwindow.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		[GeneratedCode("PresentationBuildTasks", "8.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
				case 1:
					((GClass0)target).MouseLeftButtonDown += YkB;
					break;
				case 2:
					((CheckBox)target).Click += uMH;
					break;
				case 3:
					((Button)target).Click += HMx;
					break;
				case 4:
					((Button)target).Click += HMx;
					break;
				case 5:
					((Button)target).Click += HMx;
					break;
				case 6:
					((Button)target).Click += HMx;
					break;
				case 7:
					((Button)target).Click += HMx;
					break;
				case 8:
					txtGiftName = (TextBox)target;
					break;
				case 9:
					txtGiftDesc = (TextBox)target;
					break;
				case 10:
					btnAdd = (Button)target;
					btnAdd.Click += tkE;
					break;
				case 11:
					((Button)target).Click += rMd;
					break;
				case 12:
					listBox = (ListBox)target;
					break;
				default:
					IMQ = true;
					break;
				case 14:
					listBoxUserSend = (ListBox)target;
					break;
				case 15:
					gridBar = (Grid)target;
					break;
				case 16:
					x = (Button)target;
					x.Click += vkI;
					break;
			}
		}

		[GeneratedCode("PresentationBuildTasks", "8.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 13)
			{
				((Button)target).Click += ikl;
			}
		}

	}

}
