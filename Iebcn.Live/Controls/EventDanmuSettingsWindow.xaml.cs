using Iebcn.Live.Helper;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// EventDanmuSettingsWindow.xaml 的交互逻辑
	/// </summary>
	public partial class EventDanmuSettingsWindow : Window, IComponentConnector
	{
		[CompilerGenerated]
		private bool jt4;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return jt4;
			}
			[CompilerGenerated]
			private set
			{
				jt4 = value;
			}
		}

		public EventDanmuSettingsWindow()
		{
			InitializeComponent();
			base.DataContext = Common.danmuSetting.EventDanmu;
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

		private void hte(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

		private void Atq(object sender, RoutedEventArgs e)
		{
			Close();
		}


	}

}
