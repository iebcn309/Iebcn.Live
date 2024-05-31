using Iebcn.Live.Helper;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// IntercutWindow.xaml 的交互逻辑
	/// </summary>
	public partial class IntercutWindow : Window, IComponentConnector
	{
		public static bool Isbusy;

		private List<string> siC;

		[CompilerGenerated]
		private bool bi3;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return bi3;
			}
			[CompilerGenerated]
			private set
			{
				bi3 = value;
			}
		}

		public IntercutWindow()
		{
			InitializeComponent();
			siC = new List<string>();
			base.DataContext = Common.danmuSetting.Intercut;
			Start();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			try
			{
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				Util.SaveDanmuSetting();
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
				IsClosed = true;
			}
			catch
			{
			}
		}

		private void ji4(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		public async void Start()
		{
			if (Common.VIPLevel < 2)
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
						if (IsClosed)
						{
							goto end_IL_0075;
						}
						if (siC.Count <= 0)
						{
							goto IL_0179;
						}
						string msg = siC[0];
						siC.RemoveAt(0);
						if (msg.Trim() == "")
						{
							goto IL_0179;
						}
						Isbusy = true;
						await VoiceHelper.smethod_0(msg, stopOther: true, null, 3);
						txtHistory.AppendText(DateTime.Now.ToString("hh:mm:ss") + ": " + msg + "\r\n");
						Isbusy = siC.Count > 0;
						goto end_IL_004d;
					end_IL_0075:;
					}
					catch
					{
						goto end_IL_004d;
					}
					num = 2;
					goto end_IL_004d;
				IL_0179:
					num = 1;
				end_IL_004d:;
				}
				catch (Exception obj3)
				{
					obj = obj3;
				}
				await Task.Delay(400);
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

		private void vif(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel >= 2)
			{
				if (!(txtMsg.Text.Trim() == ""))
				{
					siC.Add(txtMsg.Text.Trim());
				}
			}
			else
			{
				Util.PromptPurchase(2);
			}
		}

		private void eiF(object sender, RoutedEventArgs e)
		{
			Close();
		}

	}

}
