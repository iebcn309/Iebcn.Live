namespace Iebcn.Live.ViewModel
{
	public class Song
	{
		// 歌曲信息数组，用于存储多首歌曲的详细信息
		public SongInfo[] data { get; set; }

		// 状态码，用于表示请求的状态，例如200表示成功
		public int code { get; set; }

		// 错误信息，用于存储请求失败时的详细信息
		public string error { get; set; }

	}
}
