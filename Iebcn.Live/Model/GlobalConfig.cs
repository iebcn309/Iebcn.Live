namespace Iebcn.Live
{
	public class GlobalConfig
	{
		// 用于存储FadeExternalSoundEnabled的私有字段，受VIPLevel限制
		private bool _fadeExternalSoundEnabled;

		// 用于存储AudioRndModeEnabled的私有字段，受VIPLevel限制
		private bool _audioRndModeEnabled;

		// 用于存储AudioDeviceNumber的私有字段
		private int _audioDeviceNumber;

		/// <summary>
		/// 获取或设置是否启用外部声音淡入功能。若当前用户VIP等级低于2，则始终返回false且无法设置为true。
		/// </summary>
		public bool FadeExternalSoundEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_fadeExternalSoundEnabled = false;
				}
				return _fadeExternalSoundEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_fadeExternalSoundEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置是否启用音频随机模式。若当前用户VIP等级低于2，则始终返回false且无法设置为true。
		/// </summary>
		public bool AudioRndModeEnabled
		{
			get
			{
				if (Common.VIPLevel < 2)
				{
					_audioRndModeEnabled = false;
				}
				return _audioRndModeEnabled;
			}
			set
			{
				if (Common.VIPLevel < 2)
				{
					value = false;
				}
				_audioRndModeEnabled = value;
			}
		}

		/// <summary>
		/// 获取或设置音频设备编号。
		/// </summary>
		public int AudioDeviceNumber
		{
			get => _audioDeviceNumber;
			set => _audioDeviceNumber = value;
		}
	}
}