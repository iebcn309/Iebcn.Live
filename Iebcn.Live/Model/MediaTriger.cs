using System.Collections.ObjectModel;

namespace Iebcn.Live.ViewModel
{
	public class MediaTriger
	{
		public bool Enabled { get; set; }
		public int CacheMax { get; set; } = 10;
		public int Width { get; set; } = 560;
		public int Height { get; set; } = 800;
		public bool GreenBackground { get; set; } = true;
		public ObservableCollection<MediaInfo> SavedList { get; set; } = new ObservableCollection<MediaInfo>();
	}

}
