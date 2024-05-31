using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// MediaTrigerWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MediaTrigerWindow : Window, IComponentConnector
	{
		private MediaTriger N8V;

		private List<MediaInfo> K8j = new List<MediaInfo>();

		public bool IsClosed;

		public MediaTrigerWindow()
		{
			InitializeComponent();
			base.DataContext = (N8V = Common.danmuSetting.MediaTriger);
			Process();
		}

		private async void Process()
		{
			if (Common.VIPLevel < 1 || IsClosed)
			{
				return;
			}
			Exception obj4;
			while (true)
			{
				Exception obj = null;
				int num = 0;
				try
				{
					try
					{
						if (N8V.SavedList.Count <= 0 || K8j.Count <= 0 || !Common.danmuSetting.MediaTriger.Enabled || canvas.Children.Count > 0)
						{
							goto end_IL_005c;
						}
						MediaInfo mediaInfo = (from x in K8j
											   orderby x.Priority descending
											   orderby x.AddTime descending
											   select x).FirstOrDefault();
						K8j.Remove(mediaInfo);
						canvas.Children.Add(new MdtPlayerCtl(mediaInfo));
						MediaTriggerManager.LogInfo("触发：" + mediaInfo.Desc);
						goto end_IL_005c_2;
					end_IL_005c:;
					}
					catch
					{
						goto end_IL_005c_2;
					}
					num = 1;
				end_IL_005c_2:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(300);
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
				if (num == 1)
				{
				}
			}
			throw obj4;
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		protected override async void OnClosed(EventArgs e)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			try
			{
				MediaTriggerManager.Close();
				base.OnClosed(e);
				IsClosed = true;
			}
			catch (Exception)
			{
			}
		}

		private void s87(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void L8T(object sender, RoutedEventArgs e)
		{
			MediaTriggerManager.ShowMediaTriggerSettingWindow();
		}

		private void b8G(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		internal void HandleMediaInfo(MediaInfo mediaInfo_0)
		{
			canvas.Children.Add(new MdtPlayerCtl(mediaInfo_0));
		}

		private void f8v(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		internal void HandleDanmuData(DanmuData danmuData_0)
		{
			if (Common.VIPLevel < 1 || !Common.danmuSetting.MediaTriger.Enabled)
			{
				return;
			}
			MediaInfo mediaInfo = null;
			if (danmuData_0.Type == DanmuType.Gift)
			{
				mediaInfo = N8V.SavedList.FirstOrDefault((MediaInfo x) => x.DType == DanmuType.Gift && (x.GiftName == danmuData_0.GiftName || x.GiftName == ""));
				if (mediaInfo != null && mediaInfo.GiftExcByCount)
				{
					mediaInfo.LoopCount = danmuData_0.GiftCount;
				}
			}
			if (danmuData_0.Type == DanmuType.Chat)
			{
				mediaInfo = N8V.SavedList.FirstOrDefault((MediaInfo x) => x.DType == DanmuType.Chat && x.ChatWords == danmuData_0.PureMsg);
			}
			if (danmuData_0.Type == DanmuType.Like)
			{
				mediaInfo = N8V.SavedList.FirstOrDefault((MediaInfo x) => x.DType == DanmuType.Like);
			}
			if (mediaInfo != null)
			{
				mediaInfo.AddTime = DateTime.Now;
				c8y(mediaInfo);
				MediaTriggerManager.LogInfo("加入队列：" + mediaInfo.Desc);
			}
		}

		private void c8y(MediaInfo mediaInfo_0)
		{
			K8j.Add(mediaInfo_0);
			if (K8j.Count > N8V.CacheMax)
			{
				K8j.RemoveAt(0);
			}
		}
	}

}
