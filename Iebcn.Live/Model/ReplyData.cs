namespace Iebcn.Live.Helper
{
	public class ReplyData
	{
		// 私有字段，用于存储发送者的昵称
		private string _nick;

		// 私有字段，用于存储纯净的消息内容（不包含发送者或其他上下文信息）
		private string _pureMsg;

		// 私有字段，用于存储回复的内容
		private string _answer;

		/// <summary>
		/// 发送者的昵称
		/// </summary>
		public string Nick
		{
			get { return _nick; }
			set { _nick = value; }
		}

		/// <summary>
		/// 纯净的消息内容（不包含发送者或其他上下文信息）
		/// </summary>
		public string PureMsg
		{
			get { return _pureMsg; }
			set { _pureMsg = value; }
		}

		/// <summary>
		/// 回复的内容
		/// </summary>
		public string Answer
		{
			get { return _answer; }
			set { _answer = value; }
		}

		/// <summary>
		/// 创建一个新的回复数据实例
		/// </summary>
		/// <param name="nick">发送者的昵称</param>
		/// <param name="chat">纯净的消息内容</param>
		/// <param name="answer">回复的内容</param>
		public ReplyData(string nick, string chat, string answer)
		{
			Nick = nick;
			PureMsg = chat;
			Answer = answer;
		}
	}
}