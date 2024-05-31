using System.Windows.Controls;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// GifButton.xaml 的交互逻辑
	/// </summary>
	public partial class GifButton : UserControl, IComponentConnector
	{
		public GifButton()
		{
			InitializeComponent();
		}

		public GifButton(dynamic obj)
		{
			InitializeComponent();
			base.DataContext = (object)obj;
		}
	}
}
