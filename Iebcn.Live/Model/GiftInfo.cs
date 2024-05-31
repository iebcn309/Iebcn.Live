namespace Iebcn.Live.ViewModel
{
	using System.ComponentModel;
	using System.Collections.Generic;

	public class GiftInfo : INotifyPropertyChanged
	{
		private int _giftId;
		private string _giftName;
		private string _giftImage;
		private string _giftExtra;
		private int _giftCount;
		private int _pageId;

		public GiftInfo()
		{
			_giftId = 0;
			_giftName = string.Empty;
			_giftImage = string.Empty;
			_giftExtra = string.Empty;
			_giftCount = 0;
			_pageId = 1;
		}

		public int GiftId
		{
			get => _giftId;
			set => Set(ref _giftId, value, "GiftId");
		}

		public string Name
		{
			get => _giftName;
			set => Set(ref _giftName, value, "GiftName");
		}

		public string Image
		{
			get => _giftImage;
			set => Set(ref _giftImage, value, "GiftImage");
		}

		public string Extra
		{
			get => _giftExtra;
			set => Set(ref _giftExtra, value, "GiftExtra");
		}

		public int Count
		{
			get => _giftCount;
			set => Set(ref _giftCount, value, "GiftCount");
		}

		public int PageId
		{
			get => _pageId;
			set => Set(ref _pageId, value, "PageId");
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private bool Set<T>(ref T backingStore, T value, string propertyName)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}