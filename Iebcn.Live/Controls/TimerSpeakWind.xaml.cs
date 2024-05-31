using Iebcn.Live.Helper;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// TimerSpeakWind.xaml 的交互逻辑
	/// </summary>
	public partial class TimerSpeakWind : Window, IComponentConnector
	{
		public bool IsClosed;

		public TimerSpeakWind()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.TimerSpeak;
		}

		private void RgG(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void ugo(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			Util.SaveDanmuSetting();
			base.OnClosed(e);
			IsClosed = true;
		}

		private void Fgv(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private async void FgX(object sender, RoutedEventArgs e)
		{
			await TimerSpeakHelper.TestSpeak(isRangeTimer: true);
		}

		private async void Pgy(object sender, RoutedEventArgs e)
		{
			await TimerSpeakHelper.TestSpeak(isRangeTimer: false);
		}
	}

}
