using Iebcn.Live.Helper;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// RenqiBuyCtl.xaml 的交互逻辑
	/// </summary>
	public partial class RenqiBuyCtl : UserControl, IComponentConnector
	{
		private Storyboard sb;

		public RenqiBuyCtl()
		{
			InitializeComponent();
			sb = base.Resources["sb"] as Storyboard;
		}

		public async Task Play()
		{
			if (!RenqiHelper.StopFlag)
			{
				dynamic oneUser = RenqiHelper.GetOneUser();
				DanmuData danmuData = new DanmuData();
				Common.rnd.Next(1, 40);
				danmuData.UserHeadPic = oneUser.UserHeadPic;
				danmuData.UserNick = oneUser.UserNick;
				if (Common.danmuSetting.Renqi.AnonymousEnabled)
				{
					danmuData.UserNick = RenqiHelper.FormatUserNickAnonymous(oneUser.UserNick);
				}
				if (Common.danmuSetting.Renqi.AnonymousEnabled)
				{
					danmuData.UserNick = RenqiHelper.FormatUserNickAnonymous(oneUser.UserNick);
				}
				else
				{
					danmuData.UserNick = RenqiHelper.FormatUserNick(oneUser.UserNick, 4);
				}
				danmuData.Msg = danmuData.UserNick + ":...正在去购买";
				base.DataContext = danmuData;
				sb.Begin();
				int num = Common.rnd.Next(Common.danmuSetting.Renqi.BuyMiniSeconds, Common.danmuSetting.Renqi.BuyMaxSeconds);
				await Task.Delay(2800 + 1000 * num);
			}
		}
	}
}
