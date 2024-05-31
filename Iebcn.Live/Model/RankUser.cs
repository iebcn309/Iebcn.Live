using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Iebcn.Live
{
	/// <summary>
	/// 排名用户类
	/// </summary>
	public class RankUser : INotifyPropertyChanged
	{
		private long rank;
		private string nickName = "";
		private string headPic = "";
		/// <summary>
		/// 排名
		/// </summary>
		public long Rank
		{
			get
			{
				return rank;
			}
			set
			{
				rank = value;
				OnPropertyChanged();
			}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName
		{
			get
			{
				return nickName;
			}
			set
			{
				nickName = value;
				OnPropertyChanged();
			}
		}
		/// <summary>
		/// 头像
		/// </summary>
		public string HeadPic
		{
			get
			{
				return headPic;
			}
			set
			{
				headPic = value;
				OnPropertyChanged();
			}
		}
		/// <summary>
		/// 属性变化事件
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// 触发属性变化事件
		/// </summary>
		/// <param name="propertyName">属性名</param>
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
