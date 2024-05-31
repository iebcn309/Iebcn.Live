using Iebcn.Live.Controls;
using System.Windows.Threading;

namespace Iebcn.Live.Helper
{
	public class GPTHelper
	{
		private static GPTWindow TFZ;

		private static string FFt;

		public static string GPT_USER_ID
		{
			get
			{
				if (FFt == "")
				{
					FFt = "#/chat/" + Util.DataTimeToTimestamp(DateTime.Now.AddMinutes(-5.0)) + Common.rnd.Next(111, 999);
				}
				return FFt;
			}
		}

		public static void ShowWindow()
		{
			if (TFZ == null || TFZ.IsClosed)
			{
				TFZ = new GPTWindow();
			}
			TFZ.Show();
			TFZ.Activate();
		}
		public static void AddData(DanmuData data)
		{
			if (TFZ != null && !TFZ.IsClosed && Common.danmuSetting.GPT.Enabled && data.Type == DanmuType.Chat && data.FansClubLevel >= Common.danmuSetting.GPT.MiniFansClubLevel && (!(Common.danmuSetting.GPT.Cmd.Trim() != "") || data.PureMsg.Trim().ToLower().StartsWith(Common.danmuSetting.GPT.Cmd.Trim().ToLower())))
			{
				Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate
				{
					TFZ.AddData(data);
				});
			}
		}

		static GPTHelper()
		{
			TFZ = null;
			FFt = "";
		}
	}

}
