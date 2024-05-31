using System.ComponentModel;

namespace Iebcn.Live
{
	public class UILog : INotifyPropertyChanged
	{
		private string _content = "";
		// 日志内容
		public string Content
		{
			get
			{
				return _content;
			}
			set
			{
				if (_content != value) // 检查值是否已更改，以避免不必要的通知
				{
					_content = value;
					OnPropertyChanged(nameof(Content)); // 通知属性已更改
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		// 用于在属性值更改时通知的辅助方法
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}