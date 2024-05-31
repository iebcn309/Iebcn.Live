namespace Iebcn.Live.ViewModel
{
	public class NoticeItem
	{
		public string Msg { get; set; } = "";
		public DateTime DateTime { get; set; } = DateTime.Now.AddMinutes(10.0);
	}
}
