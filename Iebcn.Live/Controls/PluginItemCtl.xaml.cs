using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// PluginItemCtl.xaml 的交互逻辑
	/// </summary>
	public partial class PluginItemCtl : Button, IComponentConnector
	{
		public ImageSource Icon
		{
			set
			{
				iconImg.Source = value;
			}
		}

		public string Title
		{
			set
			{
				txtTitle.Text = value;
			}
		}

		public string Flag
		{
			set
			{
				txtFlag.Content = value;
			}
		}

		public string Desc
		{
			set
			{
				txtDesc.Text = value;
			}
		}

		public PluginItemCtl()
		{
			InitializeComponent();
		}
	}

}
