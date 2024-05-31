using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Iebcn.Live.ViewModel
{
	public class GPTModel : INotifyPropertyChanged
	{
		[CompilerGenerated]
		private PropertyChangedEventHandler MuO;

		private string SuU = "思考中...";

		public string txt
		{
			get
			{
				return SuU;
			}
			set
			{
				SuU = value;
				eu3("txt");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = MuO;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref MuO, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = MuO;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref MuO, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		private void eu3(string string_0)
		{
			MuO?.Invoke(this, new PropertyChangedEventArgs(string_0));
		}

	}

}
