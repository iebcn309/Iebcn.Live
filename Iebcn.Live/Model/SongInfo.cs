namespace Iebcn.Live
{
	public class SongInfo
	{
		// 歌曲平台信息
		private string _platform;

		// 歌曲链接
		private string _link;

		// 歌曲ID
		private int _songId;

		// 歌曲标题
		private string _title;

		// 歌曲作者
		private string _author;

		// 歌词文件
		private string _lrc;

		// 歌曲播放链接
		private string _url;

		// 歌曲封面图片链接
		private string _pic;

		// 播放链接（备用）
		private string _playUrlWgscd;

		// 歌曲平台信息的属性
		public string Platform
		{
			get { return _platform; }
			set { _platform = value; }
		}

		// 歌曲链接的属性
		public string Link
		{
			get { return _link; }
			set { _link = value; }
		}

		// 歌曲ID的属性
		public int SongId
		{
			get { return _songId; }
			set { _songId = value; }
		}

		// 歌曲标题的属性
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		// 歌曲作者的属性
		public string Author
		{
			get { return _author; }
			set { _author = value; }
		}

		// 歌词文件的属性
		public string Lrc
		{
			get { return _lrc; }
			set { _lrc = value; }
		}

		// 歌曲播放链接的属性
		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}

		// 歌曲封面图片链接的属性
		public string Pic
		{
			get { return _pic; }
			set { _pic = value; }
		}

		// 播放链接（备用）的属性
		public string PlayUrlWgscd
		{
			get { return _playUrlWgscd; }
			set { _playUrlWgscd = value; }
		}

		// 这里可以添加其他方法或属性，例如数据加载、保存等
	}
}
