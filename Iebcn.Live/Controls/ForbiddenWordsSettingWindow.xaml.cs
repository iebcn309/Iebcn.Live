using Iebcn.Live.Helper;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// ForbiddenWordsSettingWindow.xaml 的交互逻辑
	/// </summary>
	public partial class ForbiddenWordsSettingWindow : Window, IComponentConnector
	{
		public ForbiddenWordsSettingWindow()
		{
			InitializeComponent();
			txt.Text = Common.ForbiddenWords;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			vD2();
			base.OnClosing(e);
		}

		private void SDi(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void vD2()
		{
			Common.ForbiddenWords = txt.Text;
			Util.SaveForbiddenWords();
		}

	}

}
