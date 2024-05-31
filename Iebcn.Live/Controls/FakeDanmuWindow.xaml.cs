using Iebcn.Live.Helper;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// FakeDanmuWindow.xaml 的交互逻辑
	/// </summary>
	public partial class FakeDanmuWindow : Window, IComponentConnector
	{
		public bool IsClosed;

		public FakeDanmuWindow()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.FakeDanmu;
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

		private void TtD(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void ptc(object sender, RoutedEventArgs e)
		{
			Ttk();
		}

		private void Ttk()
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void QtM(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Vti(object sender, RoutedEventArgs e)
		{
		}

	}

}
