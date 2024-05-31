using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Iebcn.Live.ViewModel
{
	public class SoundAssistant : INotifyPropertyChanged
	{
		// 用于通知属性更改的事件处理器
		private PropertyChangedEventHandler propertyChangedHandler;

		// 音效助手是否启用
		public bool IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				if (Common.VIPLevel < 1)
				{
					value = false;
				}
				if (_isEnabled != value)
				{
					_isEnabled = value;
					OnPropertyChanged(nameof(IsEnabled));
				}
			}
		}
		private bool _isEnabled;

		// 保存的音效项列表
		public ObservableCollection<SoundAssItem> ListDataSaved
		{
			get { return _soundAssItems; }
			set
			{
				if (_soundAssItems != value)
				{
					_soundAssItems = value;
					OnPropertyChanged(nameof(ListDataSaved));
				}
			}
		}
		private ObservableCollection<SoundAssItem> _soundAssItems;

		// 停止音效助手的快捷键组合
		public string StopSoundAssHotKeys
		{
			get { return _stopSoundAssHotKeys; }
			set
			{
				if (_stopSoundAssHotKeys != value)
				{
					_stopSoundAssHotKeys = value;
					OnPropertyChanged(nameof(StopSoundAssHotKeys));
				}
			}
		}
		private string _stopSoundAssHotKeys;

		// 音效音量
		public double Volume
		{
			get { return _volume; }
			set
			{
				if (_volume != value)
				{
					_volume = value;
					OnPropertyChanged(nameof(Volume));
				}
			}
		}
		private double _volume;

		// 实现INotifyPropertyChanged接口的PropertyChanged事件
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { propertyChangedHandler += value; }
			remove { propertyChangedHandler -= value; }
		}

		// 属性更改时的通知方法
		protected virtual void OnPropertyChanged(string propertyName)
		{
			propertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class SoundAssItem : INotifyPropertyChanged
	{
		// 用于通知属性更改的事件处理器
		private PropertyChangedEventHandler propertyChangedHandler;

		// 音效项的标题
		private string title;

		// 音效项的图片链接
		private string pictureUrl;

		// 音效文件的路径
		private string audioFile;

		// 快捷键组合
		private string hotKeys;

		// 是否对应礼物类型的弹幕
		private bool isGiftType;

		// 是否对应聊天类型的弹幕
		private bool isChatType;

		// 是否对应点赞类型的弹幕
		private bool isLikeType;

		// 礼物的内容描述
		private string giftContent;

		// 聊天的内容描述
		private string chatContent;

		// 行为信息，用于显示具体的音效触发条件
		private string actInfo;

		// 获取或设置音效项的标题
		public string Title
		{
			get { return title; }
			set
			{
				if (title != value)
				{
					title = value;
					OnPropertyChanged(nameof(Title));
				}
			}
		}

		// 获取或设置音效项的图片链接
		public string PicUrl
		{
			get { return pictureUrl; }
			set
			{
				if (pictureUrl != value)
				{
					pictureUrl = value;
					OnPropertyChanged(nameof(PicUrl));
				}
			}
		}

		// 获取或设置音效文件的路径
		public string AudioFile
		{
			get { return audioFile; }
			set
			{
				if (audioFile != value)
				{
					audioFile = value;
					OnPropertyChanged(nameof(AudioFile));
				}
			}
		}

		// 获取或设置快捷键组合
		public string HotKeys
		{
			get { return hotKeys; }
			set
			{
				if (hotKeys != value)
				{
					hotKeys = value;
					OnPropertyChanged(nameof(HotKeys));
				}
			}
		}

		// 获取或设置是否对应礼物类型的弹幕
		public bool DanmuTypeGift
		{
			get { return isGiftType; }
			set
			{
				if (isGiftType != value)
				{
					isGiftType = value;
					OnPropertyChanged(nameof(DanmuTypeGift));
				}
			}
		}

		// 获取或设置是否对应聊天类型的弹幕
		public bool DanmuTypeChat
		{
			get { return isChatType; }
			set
			{
				if (isChatType != value)
				{
					isChatType = value;
					OnPropertyChanged(nameof(DanmuTypeChat));
				}
			}
		}

		// 获取或设置是否对应点赞类型的弹幕
		public bool DanmuTypeLike
		{
			get { return isLikeType; }
			set
			{
				if (isLikeType != value)
				{
					isLikeType = value;
					OnPropertyChanged(nameof(DanmuTypeLike));
				}
			}
		}

		// 获取或设置礼物的内容描述
		public string GiftContent
		{
			get { return giftContent; }
			set
			{
				if (giftContent != value)
				{
					giftContent = value;
					OnPropertyChanged(nameof(GiftContent));
				}
			}
		}

		// 获取或设置聊天的内容描述
		public string ChatContent
		{
			get { return chatContent; }
			set
			{
				if (chatContent != value)
				{
					chatContent = value;
					OnPropertyChanged(nameof(ChatContent));
				}
			}
		}

		// 获取或设置行为信息，用于显示具体的音效触发条件
		public string ActInfo
		{
			get
			{
				if (isGiftType)
				{
					actInfo = "礼物:" + giftContent;
				}
				else if (isChatType)
				{
					actInfo = "弹幕:" + chatContent;
				}
				else if (isLikeType)
				{
					actInfo = "点赞";
				}
				return actInfo;
			}
			set
			{
				if (actInfo != value)
				{
					actInfo = value;
					OnPropertyChanged(nameof(ActInfo));
				}
			}
		}

		// 实现INotifyPropertyChanged接口的PropertyChanged事件
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { propertyChangedHandler += value; }
			remove { propertyChangedHandler -= value; }
		}

		// 属性更改时的通知方法
		protected virtual void OnPropertyChanged(string propertyName)
		{
			propertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
