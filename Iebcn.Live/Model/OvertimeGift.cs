namespace Iebcn.Live.ViewModel
{
	using System;
	using System.ComponentModel;

	public class OvertimeGift : INotifyPropertyChanged
	{
		private int _id;
		private string _giftName;
		private string _picUrl;
		private bool _isAdd;
		private double _seconds;

		public int Id
		{
			get => _id;
			set
			{
				_id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		public string GiftName
		{
			get => _giftName;
			set
			{
				_giftName = value;
				OnPropertyChanged(nameof(GiftName));
			}
		}

		public string Pic
		{
			get => _picUrl;
			set
			{
				_picUrl = value;
				OnPropertyChanged(nameof(Pic));
			}
		}

		public string GiftDesc
		{
			get
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(_seconds);
				string format = _isAdd ? "+" : "-";
				string text = timeSpan.Hours > 0
					? $"{format}{timeSpan.Hours}小时{timeSpan.Minutes}分{timeSpan.Seconds}秒"
					: timeSpan.Minutes > 0
						? $"{format}{timeSpan.Minutes}分{timeSpan.Seconds}秒"
						: $"{format}{timeSpan.Seconds}秒";
				return text;
			}
		}

		public bool IsAdd
		{
			get => _isAdd;
			set
			{
				_isAdd = value;
				OnPropertyChanged(nameof(IsAdd));
			}
		}

		public double Seconds
		{
			get => _seconds;
			set
			{
				_seconds = value;
				OnPropertyChanged(nameof(Seconds));
				// 更新GiftDesc属性，因为它依赖于Seconds的值
				OnPropertyChanged(nameof(GiftDesc));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
