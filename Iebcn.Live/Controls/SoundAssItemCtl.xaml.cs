using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// SoundAssItemCtl.xaml 的交互逻辑
	/// </summary>
	public partial class SoundAssItemCtl : UserControl, IComponentConnector
	{
		public SoundAssItem data;

		public SoundAssItemCtl(SoundAssItem data)
		{
			InitializeComponent();
			base.DataContext = (this.data = data);
		}

		private void pTl(object sender, MouseEventArgs e)
		{
			Button button = btnPlay;
			gridBar.Visibility = Visibility.Visible;
			button.Visibility = Visibility.Visible;
		}

		private void KTz(object sender, MouseEventArgs e)
		{
			Button button = btnPlay;
			gridBar.Visibility = Visibility.Collapsed;
			button.Visibility = Visibility.Collapsed;
		}

		private void aGs(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(data.AudioFile))
				{
					SoundAssistantHelper.StopPlay();
					SoundAssistantHelper.Play(data.AudioFile);
				}
			}
			catch
			{
			}
		}

		private void UGx(object sender, RoutedEventArgs e)
		{
			SoundAssistantHelper.Edit(this);
		}

		private void mGd(object sender, RoutedEventArgs e)
		{
			SoundAssistantHelper.Delete(this);
		}
	}

}
