namespace Iebcn.Live
{
	public class MusicBox
	{
		private double _scale = 1.0;
		private bool _isEnabled;
		private bool _isRankConsumeEnabled = true;
		private double _bgOpacity = 0.7;
		private int _musicMaxCount = 8;
		private double _volume = 1.0;
		private string _freeSongList = "黑夜\r\n我爱你中国";
		private int _fansMiniLevel;
		private bool _isOnlyConsumerCanSetTopmostEnabled;
		/// <summary>
		/// 缩放比例
		/// </summary>
		public double Scale
		{
			get => _scale;
			set => _scale = value;
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				_isEnabled = value;
			}
		}
		public bool SpeakUserPickSong{ get; set; }
		/// <summary>
		/// 是否启用排行榜
		/// </summary>
		public bool IsRankConsumeEnabled
		{
			get => _isRankConsumeEnabled;
			set => _isRankConsumeEnabled = value;
		}
		/// <summary>
		/// 背景透明度
		/// </summary>
		public double BgOpacity
		{
			get => _bgOpacity;
			set => _bgOpacity = value;
		}
		/// <summary>
		/// 音乐最大数
		/// </summary>
		public int MusicMaxCount
		{
			get => _musicMaxCount;
			set => _musicMaxCount = value;
		}
		/// <summary>
		/// 音量
		/// </summary>
		public double Volume
		{
			get => _volume;
			set => _volume = value;
		}
		/// <summary>
		/// 空闲时播放歌曲列表
		/// </summary>
		public string FreeSongList
		{
			get => _freeSongList;
			set => _freeSongList = value;
		}
		/// <summary>
		/// 粉丝最低等级
		/// </summary>
		public int FansMiniLevel
		{
			get => _fansMiniLevel;
			set => _fansMiniLevel = value;
		}
		/// <summary>
		/// 是否只有消费者才能置顶
		/// </summary>
		public bool IsOnlyConsumerCanSetTopmostEnabled
		{
			get => _isOnlyConsumerCanSetTopmostEnabled;
			set => _isOnlyConsumerCanSetTopmostEnabled = value;
		}
	}

}