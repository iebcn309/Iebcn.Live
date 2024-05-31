using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// HitGiftWindow.xaml 的交互逻辑
	/// </summary>
	public partial class HitGiftWindow : Window, IComponentConnector
	{
		private HitGift Lie;

		private List<HitGiftInfo> Iiq = new List<HitGiftInfo>();

		public bool IsClosed;

		public HitGiftWindow()
		{
			InitializeComponent();
			base.DataContext = (Lie = Common.danmuSetting.HitGift);
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
						if (!Lie.Enabled || Iiq.Count <= 0)
						{
							goto end_IL_007e;
						}
						HitGiftInfo hitGiftInfo = (from x in Iiq
												   orderby x.Priority descending
												   orderby x.AddTime descending
												   select x).FirstOrDefault();
						Iiq.Remove(hitGiftInfo);
						gridContainer.Children.Add(new HitGiftCtl(hitGiftInfo));
						await Task.Delay(hitGiftInfo.LastSeconds);
						goto end_IL_0056;
					end_IL_007e:;
					}
					catch
					{
						goto end_IL_0056;
					}
					num = 1;
				end_IL_0056:;
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
				HitGiftManager.Close();
				base.OnClosed(e);
				IsClosed = true;
			}
			catch (Exception)
			{
			}
		}

		private void aMl(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void VMz(object sender, RoutedEventArgs e)
		{
			HitGiftManager.ShowHitGiftSettingWindow();
		}

		private void dis(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		internal void HandleHitGift(HitGiftInfo hitGiftInfo_0)
		{
			gridContainer.Children.Add(new HitGiftCtl(hitGiftInfo_0));
		}

		private void Did(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		internal void MiH(DanmuData danmuData_0)
		{
			if (Common.VIPLevel < 1 || !Common.danmuSetting.HitGift.Enabled)
			{
				return;
			}
			HitGiftInfo hitGiftInfo = null;
			if (danmuData_0.Type == DanmuType.Gift)
			{
				hitGiftInfo = Lie.SavedList.FirstOrDefault((HitGiftInfo x) => x.DType == DanmuType.Gift && (x.GiftName == danmuData_0.GiftName || x.GiftName == ""));
				if (hitGiftInfo != null && hitGiftInfo.GiftExcByCount)
				{
					hitGiftInfo.LoopCount = danmuData_0.GiftCount;
				}
			}
			if (danmuData_0.Type == DanmuType.Chat)
			{
				hitGiftInfo = Lie.SavedList.FirstOrDefault((HitGiftInfo x) => x.DType == DanmuType.Chat && x.ChatWords == danmuData_0.PureMsg);
			}
			if (danmuData_0.Type == DanmuType.Like)
			{
				hitGiftInfo = Lie.SavedList.FirstOrDefault((HitGiftInfo x) => x.DType == DanmuType.Like);
			}
			if (hitGiftInfo != null)
			{
				hitGiftInfo.AddTime = DateTime.Now;
				iiK(hitGiftInfo);
				HitGiftManager.LogMessage("加入队列：" + hitGiftInfo.Desc);
			}
		}

		private void iiK(HitGiftInfo hitGiftInfo_0)
		{
			Iiq.Add(hitGiftInfo_0);
			if (Iiq.Count > Lie.CacheMax)
			{
				Iiq.RemoveAt(0);
			}
		}

	}

}
