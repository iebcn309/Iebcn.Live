using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// ChatbotRoleCoverCtl.xaml 的交互逻辑
	/// </summary>
	public partial class ChatbotRoleCoverCtl : UserControl, IComponentConnector
	{
		private ChatBotSettingWindow a71;

		public int RoleId = 1;

		public ChatbotRoleCoverCtl(ChatBotSettingWindow parent, int roleId)
		{
			InitializeComponent();
			RoleId = roleId;
			a71 = parent;
			string uriString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\ChatBot\\Roles\\" + roleId + "\\cover.png");
			try
			{
				img.Source = new BitmapImage(new Uri(uriString, UriKind.RelativeOrAbsolute));
			}
			catch
			{
			}
		}

		private void R7u(object sender, RoutedEventArgs e)
		{
		}

		private void e7L(object sender, MouseButtonEventArgs e)
		{
			a71.SetRole(RoleId);
		}

	}
}
