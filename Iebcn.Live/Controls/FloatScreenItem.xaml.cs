using Iebcn.Live.Helper;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// FloatScreenItem.xaml 的交互逻辑
	/// </summary>
	public partial class FloatScreenItem : StackPanel, IComponentConnector
	{
		private DoubleAnimation NZU;

		private Storyboard sb1;

		public FloatScreenItem(DanmuData data, bool isTriggerMsg = false)
		{
			InitializeComponent();
			base.DataContext = data;
			if (isTriggerMsg)
			{
				txtMsg.Text = data.ExtMsg;
			}
			lbNickName.Foreground = Common.danmuSetting.FloatScreen.Foreground;
			if (Common.danmuSetting.FloatScreen.GifPicEnabled)
			{
				try
				{
					string gifRndPic = FloatScreenHelper.GetGifRndPic();
					if (!string.IsNullOrEmpty(gifRndPic))
					{
						data.AnimationPicUrl = gifRndPic;
					}
				}
				catch
				{
				}
			}
			sb1 = base.Resources["sb1"] as Storyboard;
			NZU = sb1.Children[0] as DoubleAnimation;
			NZU.From = SystemParameters.PrimaryScreenWidth;
			NZU.To = 0.0 - base.Width;
			NZU.Duration = TimeSpan.FromSeconds(21 - Common.danmuSetting.FloatScreen.Speed);
			sb1.Begin(this);
		}

		private void TZO(object sender, EventArgs e)
		{
			try
			{
				(base.Parent as Grid).Children.Remove(this);
			}
			catch
			{
			}
		}

	}

}
