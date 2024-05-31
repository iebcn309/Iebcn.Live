using System.Windows.Media;

namespace Iebcn.Live.ViewModel
{
	public class NoticeDanmuUI
	{
		public double DurationSeconds { get; set; } = 10.0;
		public double RepeatCount { get; set; } = 1.0;
		public double FontSize { get; set; } = 16.0;

		public SolidColorBrush FontColor { get; set; } = new SolidColorBrush(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));

		public SolidColorBrush BackColor { get; set; } = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 30, 100, 100));
	}
}