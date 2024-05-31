namespace Iebcn.Live
{
	public class TimerSpeak
	{
		private const string DefaultRangeTimeContent = "北京时间{当前时间}，感谢直播间{直播间人数}位家人的支持！十分感谢！感谢直播间{直播间人数}位家人！感谢{榜1昵称}！衷心感谢大家的支持！愿你们身体健康，感谢{榜2昵称}！天天发大财！";
		private const string DefaultHourTimeContent = "现在是北京时间{当前时间}，感谢直播间{直播间人数}位家人的支持！十分感谢！\n北京时间{当前时间}，感谢直播间{直播间人数}位家人朋友！\n北京时间{当前时间}衷心感谢大家的支持！";

		private bool _isRangeTimeEnabled;
		private bool _isHourTimeEnabled;
		private bool _isRangeTimeRandomSpeak;
		private bool _isHourTimeRandomSpeak;
		private string _rangeTimeContent;
		private string _hourTimeContent;
		private int _rangeTimeIntervalMinMinutes;
		private int _rangeTimeIntervalMaxMinutes;

		/// <summary>
		/// 范围时间功能是否启用
		/// </summary>
		public bool IsRangeTimeEnabled
		{
			get => _isRangeTimeEnabled;
			set
			{
				if (Common.VIPLevel <= 0)
				{
					value = false;
				}
				_isRangeTimeEnabled = value;
			}
		}

		/// <summary>
		/// 小时时间功能是否启用
		/// </summary>
		public bool IsHourTimeEnabled
		{
			get => _isHourTimeEnabled;
			set
			{
				if (Common.VIPLevel <= 0)
				{
					value = false;
				}
				_isHourTimeEnabled = value;
			}
		}

		/// <summary>
		/// 范围时间随机发言功能是否启用
		/// </summary>
		public bool IsRangeTimeRandomSpeak
		{
			get => _isRangeTimeRandomSpeak;
			set => _isRangeTimeRandomSpeak = value;
		}

		/// <summary>
		/// 小时时间随机发言功能是否启用
		/// </summary>
		public bool IsHourTimeRandomSpeak
		{
			get => _isHourTimeRandomSpeak;
			set => _isHourTimeRandomSpeak = value;
		}

		/// <summary>
		/// 范围时间的发言内容
		/// </summary>
		public string RangeTimeContent
		{
			get => _rangeTimeContent ?? DefaultRangeTimeContent;
			set => _rangeTimeContent = value;
		}

		/// <summary>
		/// 小时时间的发言内容
		/// </summary>
		public string HourTimeContent
		{
			get => _hourTimeContent ?? DefaultHourTimeContent;
			set => _hourTimeContent = value;
		}

		/// <summary>
		/// 范围时间间隔的最小分钟数
		/// </summary>
		public int RangeTimeIntervalMinMinutes
		{
			get => _rangeTimeIntervalMinMinutes;
			set => _rangeTimeIntervalMinMinutes = value;
		}

		/// <summary>
		/// 范围时间间隔的最大分钟数
		/// </summary>
		public int RangeTimeIntervalMaxMinutes
		{
			get => _rangeTimeIntervalMaxMinutes;
			set => _rangeTimeIntervalMaxMinutes = value;
		}

		// 构造函数
		public TimerSpeak()
		{
			// 初始化默认的发言内容
			_rangeTimeContent = DefaultRangeTimeContent;
			_hourTimeContent = DefaultHourTimeContent;
		}
	}
}