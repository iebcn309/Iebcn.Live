using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// LrcControl.xaml 的交互逻辑
	/// </summary>
	public partial class LrcControl : UserControl, IComponentConnector
	{
		private Storyboard sb;
		public LrcControl()
		{
			InitializeComponent();
			try
			{
				sb = base.Resources["sb"] as Storyboard;
			}
			catch
			{
			}
		}
		public void SetLrc(string input)
		{
			try
			{
				lbLrc.Text = input;
				sb.Begin();
			}
			catch
			{
			}
		}
	}

}
