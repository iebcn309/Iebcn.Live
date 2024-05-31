using System.Windows.Controls;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// GPTUserCtl.xaml 的交互逻辑
	/// </summary>
	public partial class GPTUserCtl : UserControl, IComponentConnector
	{
		public GPTUserCtl(DanmuData data)
		{
			InitializeComponent();
			base.DataContext = data;
		}
	}
}
