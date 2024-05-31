using Iebcn.Live.Controls;

namespace Iebcn.Live.Helper
{
	public sealed class GiftInteractionHelper
	{
		private static GiftInteractionWindow vFu;
		public static void AddData(DanmuData data)
		{
			if (vFu != null && !vFu.IsClosed)
			{
				vFu.AddGiftData(data);
			}
		}

		public static void ShowWindow()
		{
			if (vFu == null || vFu.IsClosed)
			{
				vFu = new GiftInteractionWindow();
			}
			vFu.Show();
			vFu.Activate();
		}
	}
}
