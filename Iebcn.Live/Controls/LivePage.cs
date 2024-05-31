namespace Iebcn.Live.Controls
{
	public class LivePage
	{
		// 直播页面刷新时间（分钟）
		// 这个值表示直播页面在多少分钟后自动刷新
		private int _refreshIntervalInMinutes = 600;

		// 获取或设置直播页面的刷新时间（分钟）
		// 默认值为600分钟，即10小时
		public int ReloadMinutes
		{
			get
			{
				return _refreshIntervalInMinutes;
			}
			set
			{
				_refreshIntervalInMinutes = value;
			}
		}
	}
}