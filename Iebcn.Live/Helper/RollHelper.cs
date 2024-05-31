using Iebcn.Live.Controls;

namespace Iebcn.Live.Helper
{
	public sealed class RollHelper
	{
		private static RollWindow Q1e;
		public static void AddData(DanmuData data)
		{
			if (Q1e != null && !Q1e.IsClosed)
			{
				Q1e.AddData(data);
			}
		}

		public static void ShowWindow()
		{
			if (Q1e == null || Q1e.IsClosed)
			{
				Q1e = new RollWindow();
			}
			Q1e.Show();
			Q1e.Activate();
		}
	}
}
