using Iebcn.Live.Helper;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// GiftCtl.xaml 的交互逻辑
	/// </summary>
	public partial class GiftCtl : UserControl, IComponentConnector
	{
		public int intervalSeconds = 3;

		private Storyboard sb1;

		private string[] eTx = new string[6] { "小心心", "玫瑰", "大啤酒", "入团卡", "棒棒糖", "嘉年花" };

		public GiftCtl()
		{
			InitializeComponent();
			sb1 = base.Resources["sb1"] as Storyboard;
		}

		public async void Play()
		{
			while (true)
			{
				try
				{
					if (!RenqiHelper.StopFlag)
					{
						if (!Common.danmuSetting.Renqi.GiftEnabled)
						{
							await Task.Delay(300);
							continue;
						}
						dynamic oneUser = RenqiHelper.GetOneUser();
						string text = eTx[Common.rnd.Next(0, 4)];
						string userNick = (Common.danmuSetting.Renqi.AnonymousEnabled ? ((string)RenqiHelper.FormatUserNickAnonymous(oneUser.UserNick)) : ((string)RenqiHelper.FormatUserNick(oneUser.UserNick, 6)));
						RenqiHelper.ValidateSettings();
						base.DataContext = new
						{
							UserHeadPic = (object)oneUser.UserHeadPic,
							UserNick = userNick,
							GiftName = "送" + text,
							GiftCount = "x" + Common.rnd.Next(Common.danmuSetting.Renqi.GiftMinCount, Common.danmuSetting.Renqi.GiftMaxCount + 1),
							GiftUrl = RenqiHelper.GetGitUrl(text)
						};
						int num = Common.rnd.Next(Common.danmuSetting.Renqi.GiftMiniSeconds, Common.danmuSetting.Renqi.GiftMaxSeconds);
						sb1.Begin();
						await Task.Delay(3000 + 1000 * num + 200 * Common.rnd.Next(1, 20));
						continue;
					}
					break;
				}
				catch
				{
				}
			}
		}
	}
}
