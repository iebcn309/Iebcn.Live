using Iebcn.Live.Controls;
using System.Windows.Threading;

namespace Iebcn.Live.Helper
{
	public class PrintAvatarHelper
	{
		private static PrintAvatarWind YLX;

		public static void ShowWindow()
		{
			if (YLX == null || YLX.IsClosed)
			{
				YLX = new PrintAvatarWind();
			}
			YLX.Show();
			YLX.Activate();
		}

		public static void AddData(DanmuData data)
		{
			if (!Common.danmuSetting.PrintAvatar.Enabled)
			{
				return;
			}
			try
			{
				Dispatcher.CurrentDispatcher.InvokeAsync(delegate
				{
					if (YLX != null && !YLX.IsClosed)
					{
						YLX.Print(data);
					}
				});
			}
			catch
			{
			}
		}
	}

}
