using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Iebcn.Live
{
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	public class Resource1
	{
		private static ResourceManager rYm;

		private static CultureInfo tYr;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (rYm == null)
				{
					rYm = new ResourceManager("Iebcn.Live.Resource1", typeof(Resource1).Assembly);
				}
				return rYm;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return tYr;
			}
			set
			{
				tYr = value;
			}
		}

		public static string emoji_list => ResourceManager.GetString("emoji_list", tYr);

		public static string encGifts => ResourceManager.GetString("encGifts", tYr);

		public static string fake_gift => ResourceManager.GetString("fake_gift", tYr);

		public static string forbiddenWords => ResourceManager.GetString("forbiddenWords", tYr);

		public static string GameSeeLetterWords => ResourceManager.GetString("GameSeeLetterWords", tYr);

		public static string humor => ResourceManager.GetString("humor", tYr);

		public static string keyboard_code => ResourceManager.GetString("keyboard_code", tYr);

		public static string live2D => ResourceManager.GetString("live2D", tYr);

		public static object muyu => ResourceManager.GetStream("muyu", tYr);
		public static byte[] printer1 => (byte[])ResourceManager.GetObject("printer1", tYr);

		public static string SoundAssDefault => ResourceManager.GetString("SoundAssDefault", tYr);

		public static string style1 => ResourceManager.GetString("style1", tYr);

		public static string thks_gift => ResourceManager.GetString("thks_gift", tYr);

		public static string txt1 => ResourceManager.GetString("txt1", tYr);

		public static string txt2 => ResourceManager.GetString("txt2", tYr);

		public static string txtVoice => ResourceManager.GetString("txtVoice", tYr);

		public static string UserNicks => ResourceManager.GetString("UserNicks", tYr);

		public static string Users => ResourceManager.GetString("Users", tYr);

		public static string VerLog => ResourceManager.GetString("VerLog", tYr);

		internal Resource1()
		{
		}
	}
}
