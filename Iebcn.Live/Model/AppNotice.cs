namespace Iebcn.Live
{
	using System;

	public class AppNotice
	{
		/// <summary>
		/// 表示通知的截止日期，初始化为当前日期的30天前。
		/// </summary>
		private DateTime _noticeDeadline = DateTime.Now.AddDays(-30);

		/// <summary>
		/// 获取或设置通知的截止日期。
		/// </summary>
		public DateTime ToDate
		{
			get { return _noticeDeadline; }
			set
			{
				if (value != _noticeDeadline)
				{
					_noticeDeadline = value;
					OnPropertyChanged(nameof(ToDate));
				}
			}
		}

		/// <summary>
		/// 表示通知消息的内容，默认为"暂无通知!"。
		/// </summary>
		private string _messageContent = "暂无通知!";

		/// <summary>
		/// 获取或设置通知消息的内容。
		/// </summary>
		public string Msg
		{
			get { return _messageContent; }
			set
			{
				if (value != _messageContent)
				{
					_messageContent = value;
					OnPropertyChanged(nameof(Msg));
				}
			}
		}

		/// <summary>
		/// 当属性值改变时调用的方法，用于通知界面属性值已改变。
		/// </summary>
		/// <param name="propertyName">改变的属性名。</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			// 这里可以触发INotifyPropertyChanged接口的PropertyChanged事件
			// 但由于这个类没有实现INotifyPropertyChanged接口，所以这部分代码是示意性的
			// 如果类需要实现INotifyPropertyChanged接口，需要添加相应的事件定义和触发逻辑
		}
	}
}