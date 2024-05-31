using Iebcn.Live.Helper;
using System.Windows;
using System.Windows.Threading;

namespace Iebcn.Live
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
		}
		protected override void OnStartup(StartupEventArgs e)
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			System.Windows.Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
			TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
			base.OnStartup(e);
		}

		private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			AppLog.AddLog($"TaskScheduler_UnobservedTaskException: {e.Exception}");
			e.SetObserved();
		}

		private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			AppLog.AddLog($"Current_DispatcherUnhandledException:{e.Exception}");
			e.Handled = true;
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			AppLog.AddLog($"CurrentDomain_UnhandledException: {e.ExceptionObject}");
		}
	}

}
