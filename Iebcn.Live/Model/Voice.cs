namespace Iebcn.Live
{
	public class Voice
	{
		private VoicePlatform _plantform = VoicePlatform.Xunfei;
		private string _speakerName = "一菲";
		private string _speakerValue = "x3_yifei";
		private int _speed = 50;
		private int _pitch = 50;
		private int _volume = 100;

		public VoicePlatform Platform
		{
			get => _plantform;
			set => _plantform = value;
		}

		public string SpeakerName
		{
			get => _speakerName;
			set => _speakerName = value;
		}

		public string SpeakerValue
		{
			get => _speakerValue;
			set => _speakerValue = value;
		}

		public int Speed
		{
			get => _speed;
			set => _speed = value;
		}

		public int Pitch
		{
			get => _pitch;
			set => _pitch = value;
		}

		public int Volume
		{
			get => _volume;
			set => _volume = value;
		}
	}
}