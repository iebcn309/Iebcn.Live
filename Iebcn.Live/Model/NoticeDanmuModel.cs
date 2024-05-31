using System.Collections.ObjectModel;

namespace Iebcn.Live.ViewModel
{
	public class NoticeDanmuModel
	{
		public bool Enabled { get; set; }
		public ObservableCollection<NoticeItem> Notices { get; set; } = new ObservableCollection<NoticeItem>();
		public NoticeDanmuUI NoticeDanmuUI { get; set; } = new NoticeDanmuUI();
	}

}
