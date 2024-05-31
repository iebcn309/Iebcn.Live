using Iebcn.Live.Helper;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Iebcn.Live.Controls
{
	public class Win32API
	{
		[DllImport("user32")]
		private static extern uint SetWindowLong(IntPtr intptr_0, int int_0, uint uint_0);

		[DllImport("user32")]
		private static extern uint GetWindowLong(IntPtr intptr_0, int int_0);
		public static void SetTranMouseWind(Window window)
		{
			try
			{
				IntPtr handle = new WindowInteropHelper(window).Handle;
				uint windowLong = GetWindowLong(handle, -20);
				SetWindowLong(handle, -20, windowLong | 0x20u);
			}
			catch
			{
			}
		}
		// 定义键盘钩子委托
		private delegate IntPtr KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam);

		// 键盘钩子过程
		private static KeyboardHookProc hookProc;

		// 存储挂钩的句柄
		private static IntPtr hookHandle;

		// 存储按键组合的字符串
		public static string HotkeyCombination;

		// 导入SetWindowsHookEx函数
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc lpfn, IntPtr hMod, uint dwThreadId);

		// 导入UnhookWindowsHookEx函数
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		// 导入CallNextHookEx函数
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// 安装键盘钩子
		/// </summary>
		public static void InstallHook()
		{
			using (Process process = Process.GetCurrentProcess())
			{
				using (ProcessModule processModule = process.MainModule)
				{
					hookHandle = SetWindowsHookEx(13, hookProc, processModule.BaseAddress, 0u);
				}
			}
		}

		/// <summary>
		/// 键盘钩子回调函数
		/// </summary>
		/// <param name="nCode">钩子代码</param>
		/// <param name="wParam">消息参数</param>
		/// <param name="lParam">消息参数</param>
		/// <returns>调用下一个钩子的返回值</returns>
		private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0 && wParam == (IntPtr)256)
			{
				int vkCode = Marshal.ReadInt32(lParam);
				string modifierKeys = Control.ModifierKeys.ToString();
				if (modifierKeys != "None")
				{
					string modifiedModifierKeys = modifierKeys.Replace(",", "+");
					Keys keys = (Keys)vkCode;
					HotkeyCombination = modifiedModifierKeys + "+" + keys;
				}
				else
				{
					Keys keys = (Keys)vkCode;
					HotkeyCombination = keys.ToString() ?? "";
				}
				// 检查是否需要播放音效
				if (Common.danmuSetting.SoundAssistant.IsEnabled)
				{
					SoundAssistantHelper.CheckHotkeyPlayAudio(HotkeyCombination);
				}
				// 处理音乐相关操作
				MusicHelper.rLx(HotkeyCombination);
			}
			return CallNextHookEx(hookHandle, nCode, wParam, lParam);
		}

		/// <summary>
		/// 卸载键盘钩子
		/// </summary>
		public static void UninstallHook()
		{
			UnhookWindowsHookEx(hookHandle);
		}

		// 类构造函数，初始化钩子委托和句柄
		static Win32API()
		{
			hookProc = KeyboardHookCallback;
			hookHandle = IntPtr.Zero;
			HotkeyCombination = "";
		}
	}
}