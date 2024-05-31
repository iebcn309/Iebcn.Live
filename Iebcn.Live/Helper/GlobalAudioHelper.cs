using System.Runtime.InteropServices;

namespace Iebcn.Live.Helper
{
	public class GlobalAudioHelper
	{
		public static IntPtr AppMainHandler;

		[DllImport("oleacc.dll", SetLastError = true)]
		private static extern int AccSetRunningUtilityState(IntPtr intptr_0, uint uint_0, uint uint_1);

		public static bool SetAudioDucking()
		{
			if (Common.danmuSetting.GlobalConfig.FadeExternalSoundEnabled)
			{
				return AccSetRunningUtilityState(AppMainHandler, 12u, 12u) == 0;
			}
			return false;
		}

		public static bool ResetAudioDucking()
		{
			if (Common.danmuSetting.GlobalConfig.FadeExternalSoundEnabled)
			{
				return AccSetRunningUtilityState(AppMainHandler, 12u, 8u) == 0;
			}
			return false;
		}

		static GlobalAudioHelper()
		{
			AppMainHandler = IntPtr.Zero;
		}
	}

}