using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// MusicWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MusicWindow : Window, IComponentConnector
	{
		private bool _isUsingNetwork = true;
		private string _localMusicList  = "";
        // 音乐列表和歌词列表
        private List<SongInfo> _localSongs  = new List<SongInfo>();
        private List<Lrc> _lyricList = new List<Lrc>();
        private int _freeSongIndex;
		private CollectionViewSource _musicViewSource;
		private bool _isDraggingWindow;
        Point _pressedPosition;
        bool _isDragMoved = false;
        public bool IsClosed { get; set; }

		public MusicWindow()
		{
			InitializeComponent();
            SetInitialSettings();
            base.MouseLeftButtonDown += MusicWindow_MouseLeftButtonDown; ;
			md.MediaOpened += OnMediaOpened;
			md.MediaEnded += OnMediaEnded;
			md.MediaFailed += OnMediaFailed;
			base.Closing += OnClosing;
            StartUpdatingMediaTime();
			UpdateLyricsControl();
		}

        private void MusicWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sliderVolume.Visibility != Visibility.Collapsed)
            {
                sliderVolume.Visibility = Visibility.Collapsed;
            }
        }

        // 初始化设置
        private void SetInitialSettings()
        {
            // 隐藏设置面板
            settingGrid.Visibility = Visibility.Collapsed;
            if (Common.UserMusicList.Count <= 0)
            {
                Common.UserMusicList.Add(new UserMusic
                {
                    ByUser = "wgscd",
                    Title = "天意",
                    AddTime = DateTime.Now
                });
                Common.UserMusicList.Add(new UserMusic
                {
                    ByUser = "wgscd",
                    Title = "赤伶",
                    AddTime = DateTime.Now
                });
                Common.UserMusicList.Add(new UserMusic
                {
                    ByUser = "wgscd",
                    Title = "后来",
                    AddTime = DateTime.Now
                });
                Common.UserMusicList.Add(new UserMusic
                {
                    ByUser = "wgscd",
                    Title = "刘德华 爱你一万年",
                    AddTime = DateTime.Now
                });
            }

            LoadLocalMusicList();
            _musicViewSource = base.Resources["MusicResource"] as CollectionViewSource;
            _musicViewSource.Source = Common.UserMusicList;
            base.DataContext = Common.danmuSetting.MusicBox;
            listSong.SelectedItem = null;
        }
        void Window_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _pressedPosition = e.GetPosition(this);
        }
        void Window_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed && _pressedPosition != e.GetPosition(this))
            {
                _isDragMoved = true;
                DragMove();
            }
        }
        void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragMoved)
            {
                _isDragMoved = false;
                e.Handled = true;
            }
        }
        protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
		}

		private void OnMediaOpened(object sender, RoutedEventArgs e)
		{
			slider.Maximum = md.NaturalDuration.TimeSpan.TotalMilliseconds;
		}

		private void OnMediaEnded(object sender, RoutedEventArgs e)
		{
			musicCover.StopCircleAnimation();
			PlayMusic();
		}

		private async void OnMediaFailed(object sender, ExceptionRoutedEventArgs e)
		{
            await messageTip.ShowMessageTip("抱歉当前歌曲无法播放，自动播放下一首", isWarningOrError: true, 3000);
            PlayMusic();
        }

		private void LoadLocalMusicList()
		{
			_localMusicList  = "";
			_localSongs  = MusicHelper.LoadLoclMusic();
			foreach (SongInfo song in _localSongs )
			{
                _localMusicList  += Path.GetFileNameWithoutExtension(song.Url) + "\r\n";
            }
			if (_localSongs .Count <= 0)
			{
				_localMusicList  = "程序目录'Music'里没有mp3文件";
			}
			txtLocalMusic.Text = _localMusicList ;
            _isUsingNetwork = rdFreeUseNetwork.IsChecked.Value;
        }
		// 播放指定歌曲
		private async void Play(string musicTitle, string requestedBy = "")
		{
			bool hasError = false;
			loadingCircle.Visibility = Visibility.Visible;
			try
			{
				Song song = await MusicHelper.Search(musicTitle);
				if (song != null)
				{
					SongInfo[] data = song.data;
					if (data != null && data.Length > 0)
					{
						SongInfo selectedSong = await GetPlayableSong(data);
						if (selectedSong != null)
						{
							string introduction = $"正在为您播放{selectedSong.Author}的《{selectedSong.Title}》";
							if (!string.IsNullOrEmpty(requestedBy))
							{
								introduction = $"由[{requestedBy}]点播的{selectedSong.Author}的《{selectedSong.Title}》";
							}
							if (Common.danmuSetting.MusicBox.SpeakUserPickSong)
							{
								await VoiceHelper.smethod_0(introduction, stopOther: true);
							}
                            _lyricList.Clear();
							musicCover.SetCover(selectedSong.Pic);
							lbMusicTitle.Content = $"{selectedSong.Author}:{selectedSong.Title}";
                            _lyricList = MusicHelper.ParseLrc(selectedSong.Lrc);
							md.Source = new Uri(selectedSong.PlayUrlWgscd, UriKind.RelativeOrAbsolute);
							md.Play();
						}
						else
						{
							await messageTip.ShowMessageTip("抱歉，未找到可用歌曲，将自动播放下一首", isWarningOrError: true, 3000);
							hasError = true;
						}
					}
					else
					{
						hasError = true;
					}
				}
				else
				{
					hasError = true;
				}
			}
			catch
			{
				hasError = true;
			}
			finally
			{
				loadingCircle.Visibility = Visibility.Collapsed;
				if (hasError)
				{
                    OnMediaEnded(null, null);
				}
			}
		}
		private async Task<SongInfo> GetPlayableSong(SongInfo[] songs)
		{
			for (int i = 0; i < songs.Length; i++)
			{
				SongInfo song = songs[i];
				if (song.Platform == "netease")
				{
					if (await CheckSongAvailability(song))
					{
						return song;
					}
				}
			}
			return null;
		}

		private async Task<bool> CheckSongAvailability(SongInfo songInfo_0)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(songInfo_0.Url);
				if (response.IsSuccessStatusCode)
				{
					string text = response.RequestMessage.RequestUri.ToString();
					if (text.EndsWith("music.163.com/404"))
					{
						return false;
					}
					songInfo_0.PlayUrlWgscd = text;
				}
			}

			//HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(songInfo_0.Url);
			//obj.Method = "GET";
			//obj.AllowAutoRedirect = true;
			//HttpWebResponse obj2 = (HttpWebResponse)(await obj.GetResponseAsync());
			//string text = obj2.ResponseUri?.ToString();
			//obj2.Close();
			//if (text.EndsWith("music.163.com/404"))
			//{
			//	return false;
			//}
			//songInfo_0.PlayUrlWgscd = text;
			return true;
		}

 
		private async void PlayNextLocalSong()
		{
			bool flag = false;
			try
			{
				if (_localSongs .Count <= 0)
				{
					return;
				}
				loadingCircle.Visibility = Visibility.Visible;
				if (_freeSongIndex >= _localSongs .Count)
				{
					_freeSongIndex = 0;
				}
				SongInfo songInfo = _localSongs [_freeSongIndex];
				_lyricList.Clear();
				musicCover.SetCover("");
				lbMusicTitle.Content = songInfo.Author + ":" + songInfo.Title;
				await VoiceHelper.smethod_0("请欣赏歌曲：" + lbMusicTitle.Content, stopOther: true);
				md.Source = new Uri(songInfo.Url, UriKind.RelativeOrAbsolute);
				MusicHelper.IsPlayingFreeList = true;
				_freeSongIndex++;
				md.Play();
			}
			catch
			{
				flag = true;
			}
			loadingCircle.Visibility = Visibility.Collapsed;
			if (flag)
			{
				OnMediaEnded(null, null);
			}
		}
        // 切换播放模式
        private void TogglePlayMode()
		{
			_isUsingNetwork = rdFreeUseNetwork.IsChecked == true;
			if (!_isUsingNetwork)
			{
				PlayNextLocalSong();
				return;
			}
			List<string> source = Common.danmuSetting.MusicBox.FreeSongList.Trim().Split('\n').ToList();
			source = source.Where((string x) => x.Trim() != "").ToList();
			if (_freeSongIndex >= source.Count)
			{
				_freeSongIndex = 0;
			}
			if (source.Count > 0)
			{
				string musicTitle = source[_freeSongIndex].Trim();
				MusicHelper.IsPlayingFreeList = true;
				_freeSongIndex++;
				Play(musicTitle);
			}
		}

		private void PromptVIPPurchase()
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
        }
		// 开始更新媒体时间
     private async void StartUpdatingMediaTime()
     {
         lbMediaTime.Content = md.Position.ToString("hh\\:mm\\:s");
         if (!_isDraggingWindow)
         {
             slider.Value = md.Position.TotalMilliseconds;
         }
         await Task.Delay(100);
         StartUpdatingMediaTime();
     }

		// 更新歌词控件
		private async void UpdateLyricsControl()
		{
			Lrc currentLrc = _lyricList.FirstOrDefault(l => l.Time > md.Position.Add(TimeSpan.FromMilliseconds(-300.0)) && l.Time < md.Position.Add(TimeSpan.FromMilliseconds(300.0)));
			object previousTag = lrcControl.Tag;
			if (currentLrc != null)
			{
				string currentTag = currentLrc.Time.ToString() + ":" + currentLrc.LrcContent;
				if (previousTag != null && previousTag.ToString() != currentTag)
				{
					lrcControl.Tag = currentTag;
					lrcControl.SetLrc(currentLrc.LrcContent);
				}
			}
			await Task.Delay(100);
			UpdateLyricsControl();
		}
		public void RefreshView()
		{
			_musicViewSource.View.Refresh();
		}
		public void PlayMusic()
		{
            base.Dispatcher.Invoke(delegate
            {
                if (!md.NaturalDuration.HasTimeSpan || !(md.Position.TotalMilliseconds > 0.0) || !(md.Position.TotalMilliseconds < md.NaturalDuration.TimeSpan.TotalMilliseconds))
                {
                    if (listSong.Items.Count > 0)
                    {
                        UserMusic userMusic = listSong.Items[0] as UserMusic;
                        string Title = userMusic.Title;
                        Common.UserMusicList.Remove(userMusic);
                        MusicHelper.IsPlayingFreeList = false;
                        Play(Title, userMusic.ByUser);
                    }
                    else
                    {
                        TogglePlayMode();
                    }
                }
            });
        }
		public void PlayNextMusic()
		{
            base.Dispatcher.Invoke(delegate
            {
                if (listSong.Items.Count > 0)
                {
                    UserMusic userMusic = listSong.Items[0] as UserMusic;
                    Common.UserMusicList.Remove(userMusic);
                    MusicHelper.IsPlayingFreeList = false;
                    Play(userMusic.Title, userMusic.ByUser);
                }
                else
                {
                    TogglePlayMode();
                }
            });
        }
 
		private void OnClosing(object sender, CancelEventArgs e)
		{
			Util.SaveDanmuSetting();
		}

		private void tbd(object sender, RoutedEventArgs e)
		{
			Close();
		}
		private void TbK(object sender, MouseEventArgs e)
		{
			cmdBarPanel.Opacity = 1.0;
		}

		private void kbQ(object sender, MouseEventArgs e)
		{
			cmdBarPanel.Opacity = 0.0;
		}

 
		private void ubf(object sender, RoutedEventArgs e)
		{
			PromptVIPPurchase();
		}
 
		private void lbC(object sender, RoutedEventArgs e)
		{
			LoadLocalMusicList();
		}

		private void Ib3(object sender, RoutedEventArgs e)
		{
			MusicHelper.OpenLocalMusicFolder();
		}

 
		public void Play()
		{
            base.Dispatcher.Invoke(delegate
            {
                if (!(md.Source == null))
                {
                    md.Play();
                }
                else
                {
                    PlayNextMusic();
                }
            });
        }

		public void Stop()
		{
            base.Dispatcher.Invoke(delegate
            {
                if (md.Source != null)
                {
                    md.Stop();
                }
            });
        }

        private void slider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDraggingWindow = true;
        }

        private void slider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            md.Position = TimeSpan.FromMilliseconds(slider.Value);
            md.Play();
            _isDraggingWindow = false;
        }

        private void ClearMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Common.UserMusicList.Clear();
        }

        private void PlayNextMusicMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PlayNextMusic();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void btnPlayNext_Click(object sender, RoutedEventArgs e)
        {
            PlayNextMusic();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Play();
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            base.ShowInTaskbar = true;
            cmdBarPanel.Opacity = 0.0;
            Slider obj = sliderVolume;
            Grid grid = settingGrid;
            btnMinbox.Visibility = Visibility.Collapsed;
            grid.Visibility = Visibility.Collapsed;
            obj.Visibility = Visibility.Collapsed;
            Win32API.SetTranMouseWind(this);
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            if (!(txt.Text.Trim() == ""))
            {
                Play(txt.Text.Trim());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            settingGrid.Visibility = Visibility.Collapsed;
        }

        private void btnVolume_Click(object sender, RoutedEventArgs e)
        {
            if (sliderVolume.Visibility == Visibility.Collapsed)
            {
                sliderVolume.Visibility = Visibility.Visible;
            }
            else
            {
                sliderVolume.Visibility = Visibility.Collapsed;
            }
        }

        private void btnMinbox_Click(object sender, RoutedEventArgs e)
        {
            if (base.Height > 204.0)
            {
                base.Height = 204.0;
            }
            else
            {
                base.Height = 450.0;
            }
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            if (settingGrid.Visibility == Visibility.Collapsed)
            {
                settingGrid.Visibility = Visibility.Visible;
                base.Height = 450.0;
            }
            else
            {
                settingGrid.Visibility = Visibility.Collapsed;
            }
        }
    }

}
