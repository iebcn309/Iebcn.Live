namespace Iebcn.Live
{
	public class Lrc
	{
		// LRC歌词的持续时间
		private TimeSpan _time;

		// LRC歌词的内容
		private string _lrcContent;

		// 获取LRC歌词的持续时间
		public TimeSpan Time
		{
			get { return _time; }
			set { _time = value; }
		}

		// 获取或设置LRC歌词的内容
		public string LrcContent
		{
			get { return _lrcContent; }
			set { _lrcContent = value; }
		}


	}
}
