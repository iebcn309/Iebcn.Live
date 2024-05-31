namespace Iebcn.Live
{
	using System.Windows.Media; // 假设使用的是WPF的Brush类
	using System.ComponentModel; // 用于INotifyPropertyChanged接口

	public class AppTheme : INotifyPropertyChanged
	{
		// 用于存储背景画刷的私有字段
		private Brush _backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 8, 9, 8));

		/// <summary>
		/// 获取或设置背景画刷。
		/// </summary>
		public Brush BackgroundBrush
		{
			get
			{
				return _backgroundBrush;
			}
			set
			{
				if (_backgroundBrush != value)
				{
					_backgroundBrush = value;
					// 当BackgroundBrush属性值改变时，触发PropertyChanged事件
					OnPropertyChanged(nameof(BackgroundBrush));
				}
			}
		}

		/// <summary>
		/// 属性变更事件。
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// 当属性值改变时调用的方法，用于通知界面属性值已改变。
		/// </summary>
		/// <param name="propertyName">改变的属性名。</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}