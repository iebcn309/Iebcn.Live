namespace Iebcn.Live
{
	using System.Runtime.CompilerServices;

	public class AutoReply
	{
		// 私有字段，表示是否启用内容回复
		private bool _isContentReplyEnabled;

		// 私有字段，表示是否启用音频文件回复
		private bool _isAudioFileReplyEnabled;

		// 私有字段，表示是否启用问题阅读功能
		private bool _isReadQuestionEnabled;

		// 默认为 true，表示默认启用问题阅读功能
		private const bool DefaultReadQuestionEnabled = true;

		// 内容回复设置，包含多个回复规则，格式为：触发词|回复内容|=回复音频文件
		[CompilerGenerated]
		private string _contentReplySetting = "发货地|哪里发货|=我们的发货地是北京\r\n什么时候开播|每天开播时间=直播每天下午5点开播，记得加关注哦！";

		// 音频文件回复设置，包含多个回复规则，格式与内容回复设置相同
		[CompilerGenerated]
		private string _audioFileReplySetting = "发货地|哪里发货|=发货地回答声音文件.mp3\r\n什么时候开播|每天开播时间=开播问题回答声音文件.mp3";

		/// <summary>
		/// 获取或设置是否启用内容回复功能
		/// </summary>
		public bool ContentReplyEnabled
		{
			get
			{
				if (Common.VIPLevel < 1)
				{
					_isContentReplyEnabled = false;
				}
				return _isContentReplyEnabled;
			}
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				_isContentReplyEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置是否启用音频文件回复功能
		/// </summary>
		public bool AudioFileReplyEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_isAudioFileReplyEnabled = false;
				}
				return _isAudioFileReplyEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_isAudioFileReplyEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置是否启用问题阅读功能
		/// </summary>
		public bool ReadQuestionEnabled
		{
			get { return DefaultReadQuestionEnabled; }
			set { _isReadQuestionEnabled = value; }
		}

		/// <summary>
		/// 获取内容回复设置
		/// </summary>
		public string ContentReplySetting
		{
			get { return _contentReplySetting; }
			set { _contentReplySetting = value; }
		}

		/// <summary>
		/// 获取音频文件回复设置
		/// </summary>
		public string AudioFileReplySetting
		{
			get { return _audioFileReplySetting; }
			set { _audioFileReplySetting = value; }
		}
	}
}