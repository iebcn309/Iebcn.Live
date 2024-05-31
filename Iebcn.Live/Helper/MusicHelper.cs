using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using Newtonsoft.Json;
using OBSWebsocketDotNet.Types;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Threading;

namespace Iebcn.Live.Helper
{
	public class MusicHelper
	{
		public static bool IsPlayingFreeList;

		private static string[] _cmd1;

		private static string[] _topSongsKeywords;

		private static string _localMusicPath;

		private static MusicWindow _musicWindowInstance;
		public static void ShowWindow()
		{
			if (_musicWindowInstance == null || _musicWindowInstance.IsClosed)
			{
				_musicWindowInstance = new MusicWindow();
			}
			_musicWindowInstance.Show();
			_musicWindowInstance.Activate();
		}
		public static List<SongInfo> LoadLoclMusic()

		{
			List<SongInfo> list = new List<SongInfo>();
            _localMusicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Music");
            Directory.CreateDirectory(_localMusicPath);
            string[] files = Directory.GetFiles(_localMusicPath);
            foreach (string text in files)
            {
                if (text.ToLower().EndsWith(".mp3"))
                {
                    SongInfo songInfo = new SongInfo
                    {
                        Url = text
                    };
                    list.Add(songInfo);
                    string[] array = Path.GetFileName(text).Replace(".mp3", "").Replace(".MP3", "")
                        .Split('-');
                    songInfo.Title = array[0].Trim();
                    if (array.Length >= 1)
                    {
                        songInfo.Title = array[0].Trim();
                    }
                    if (array.Length >= 2)
                    {
                        songInfo.Author = array[1].Trim();
                    }
                }
            }
            return list;
		}

		public static async Task<Song> Search(string input)
		{
			Song song = await SearchOnPlatformAsync(input, "netease");
			if (song.code == 404)
			{
				song = await SearchOnPlatformAsync(input, "qq");
			}
			if (song.code == 404)
			{
				song = await SearchOnPlatformAsync(input, "1ting");
			}
			return song;
		}
		private static string GenerateMid()
		{
			Random random = new Random();
			string text = "abcdefghijklmnopqrstuvwxyz";
			string text2 = "0123456789";
			string text3 = "";
			for (int i = 0; i < 4; i++)
			{
				text3 = ((random.Next(11) < 5) ? (text3 + text2[random.Next(0, text2.Length)]) : (text3 + text[random.Next(0, text.Length)]));
			}
			return Util.GenerateSignature(text3);
		}
		private static async Task<Song> GetSongFromKugou(string string_0, string string_1, long long_0)
		{
			string address = "https://wwwapi.kugou.com/yy/index.php?r=play%2Fgetdata&hash=" + string_0 + "&mid=" + string_1 + "&album_audio_id=" + long_0 + "&_=" + Util.DataTimeToTimestamp(DateTime.Now);
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Cookie", "kg_mid=" + string_1 + "; kg_dfid=2C7DvI4DrSHC20YhXz4bs3Hr; Hm_lvt_aedee6983d4cfc62f509129360d6bb3d=1687310625");
				HttpResponseMessage response = await client.GetAsync(address);
				if (response.IsSuccessStatusCode)
				{
					string jsonResult = await response.Content.ReadAsStringAsync();
					JsonNode jObject = JsonConvert.DeserializeObject<JsonNode>(jsonResult);
					Song song = new Song();
					song.code = 0;
					song.error = "";
					song.data = new SongInfo[1]
					{
						new SongInfo
						{
							Platform = "kugou",
							Author = jObject["data"]["author_name"].GetValue<string>(),
							Lrc = jObject["data"]["lyrics"].GetValue<string>(),
							Pic = jObject["data"]["img"].GetValue<string>(),
							PlayUrlWgscd = jObject["data"]["play_url"].GetValue<string>(),
							Url = jObject["data"]["play_url"].GetValue<string>(),
							Title = jObject["data"]["song_name"].GetValue<string>()
						}
					};
					return song;
				}
			}
			return null;
		}

		public static async Task<Song> GetSongFromKugou(string string_0)
		{
			string text = Uri.EscapeDataString(string_0);
			string _mid = GenerateMid().ToLower();
			string address = "https://mobilecdn.kugou.com/api/v3/search/song?keyword=" + text + "&api_ver=1&area_code=1&correct=1&pagesize=30&plat=2&tag=1&sver=5&showtype=10&page=1&version=8990";
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Cookie", "kg_mid=" + _mid + "; kg_dfid=2C7DvI4DrSHC20YhXz4bs3Hr; Hm_lvt_aedee6983d4cfc62f509129360d6bb3d=1687310625");
				HttpResponseMessage response = await client.GetAsync(address);
				if (response.IsSuccessStatusCode)
				{
					string jsonResult = await response.Content.ReadAsStringAsync();
					JsonNode jObject = JsonConvert.DeserializeObject<JsonNode>(jsonResult);
					string string_ = jObject["data"]["info"][0]["hash"].GetValue<string>();
					long long_ = jObject["data"]["info"][0]["album_audio_id"].GetValue<long>();
					return await GetSongFromKugou(string_, _mid, long_);
				}
			}
			return null;
		}
		private static async Task<Song> SearchOnPlatformAsync(string input, string platform)
		{
			if (platform == "kugou")
			{
				return await GetSongFromKugou(input);
			}
			Song song = null;
			string url = "https://music.liuzhijin.cn/";
			input = Uri.EscapeDataString(input);
			string text = "input=" + input + "&filter=name&type=" + platform + "&page=1";
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("referer", "https://music.liuzhijin.cn/?name=hello&type=netease");
				client.DefaultRequestHeaders.Add("accept", "application/json, text/javascript, */*; q=0.01");
				client.DefaultRequestHeaders.Add("authority", "music.liuzhijin.cn");
				client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.198 Safari/537.36");
				client.DefaultRequestHeaders.Add("x-requested-with", "XMLHttpRequest");
				using (HttpContent content = new StringContent(text, Encoding.UTF8, "application/x-www-form-urlencoded"))
				{
					using (HttpResponseMessage response = await client.PostAsync(url, content))
					{
						if (response.IsSuccessStatusCode)
						{
							string jsonResult = await response.Content.ReadAsStringAsync();
							if (jsonResult != "")
							{
								song = JsonConvert.DeserializeObject<Song>(jsonResult);
								SongInfo[] data = song.data;
								for (int i = 0; i < data.Length; i++)
								{
									data[i].Platform = platform;
								}
							}
							return song;
						}
					}
				}
			}
			return null;
		}
		public static List<Lrc> ParseLrc(string input)
		{
			List<Lrc> list = new List<Lrc>();
			foreach (string item in (from x in input.Split("\n".ToCharArray())
									 where x.Contains("]") && Puj(x.Trim())
									 select x).ToList())
			{
				string text = item.Split(']')[0].Replace("[", "").Trim();
				if (text.Contains("."))
				{
					text = text.Replace(".", ":");
				}
				TimeSpan time = new TimeSpan(0, 0, int.Parse(text.Split(':')[0]), int.Parse(text.Split(':')[1]), int.Parse(text.Split(':')[2]));
				string lrcStr = item.Split(']')[1].Trim();
				list.Add(new Lrc
				{
					Time = time,
					LrcContent = lrcStr
				});
			}
			return list;
		}
		private static bool Puj(string string_0)
		{
			try
			{
				return new Regex("\\[[\\d+]").Match(string_0).Success;
			}
			catch
			{
				return false;
			}
		}
		public static void AddUserMusic(DanmuData data)
		{
			if (!Common.danmuSetting.MusicBox.IsEnabled || data.Type != 0)
			{
				return;
			}
			if (_cmd1.Contains(data.PureMsg.Trim()))
			{
				PlayNextMusic();
			}
			else if (_topSongsKeywords.Contains(data.PureMsg.Trim()))
			{
				xuB(data);
			}
			else
			{
				if (!data.PureMsg.StartsWith("点歌") || Common.UserMusicList.Count >= Common.danmuSetting.MusicBox.MusicMaxCount || data.FansClubLevel < Common.danmuSetting.MusicBox.FansMiniLevel)
				{
					return;
				}
				string text = data.Msg.PadRight(250).Substring(2, 20).Trim();
				if (!(text == ""))
				{
					UserMusic P5E = new UserMusic
					{
						Title = text,
						Vote = 0,
						ByUser = data.UserNick,
						AddTime = DateTime.Now
					};
					if (Common.danmuSetting.MusicBox.IsRankConsumeEnabled)
					{
						P5E.Vote = (int)data.UserConsumeInRoom;
					}
					Application.Current.Dispatcher.Invoke(delegate
					{
						Common.UserMusicList.Add(P5E);
						Common.UserMusicListArchive.Add(P5E);
					});
					if (!IsPlayingFreeList)
					{
						Log(P5E);
						PlayMusic();
					}
					else
					{
						PlayNextMusic();
					}
				}
			}
		}
		private static void xuB(DanmuData danmuData_0)
		{
			if ((Common.danmuSetting.MusicBox.IsOnlyConsumerCanSetTopmostEnabled && danmuData_0.UserConsumeInRoom <= 0L) || Common.UserMusicList.Count <= 1)
			{
				return;
			}
			UserMusic userMusic = (from c in Common.UserMusicList
								   where c.ByUser == danmuData_0.UserNick
								   orderby c.Vote descending, c.AddTime
								   select c).LastOrDefault();
			if (userMusic != null)
			{
				int num = Common.UserMusicList.Max((UserMusic x) => x.Vote);
				userMusic.Vote = num + 1;
				Dispatcher.CurrentDispatcher.Invoke(delegate
				{
					_musicWindowInstance.RefreshView();
				});
			}
		}
		private static async void PlayMusic()

		{
			if (_musicWindowInstance != null && !_musicWindowInstance.IsClosed)
			{

				await Task.Run(delegate
				{
					_musicWindowInstance.PlayMusic();
				});

			}
		}
		private static async void PlayNextMusic()

		{
			if (_musicWindowInstance != null && !_musicWindowInstance.IsClosed)
			{

				await Task.Run(delegate
				{
					_musicWindowInstance.PlayNextMusic();
				});

			}
		}
		private static async void Play()
		{
			if (_musicWindowInstance != null && !_musicWindowInstance.IsClosed)
			{
				await Task.Run(delegate
				{
					_musicWindowInstance.Play();
				});

			}
		}
		private static async void Stop()
		{
			if (_musicWindowInstance != null && !_musicWindowInstance.IsClosed)
			{
				await Task.Run(delegate
				{
					_musicWindowInstance.Stop();
				});
			}
		}


		private static void Log(UserMusic userMusic_0)
		{
            string text = userMusic_0.AddTime.ToString() + ":  " + lLs(userMusic_0.ByUser.PadRight(22).Substring(0, 20).Trim()) + "[消费权重 " + lLs(userMusic_0.Vote.ToString()) + "]: " + lLs(userMusic_0.Title.PadRight(22).Substring(0, 20).Trim()) + "\r\n";
            File.AppendAllText("点歌记录.txt", text ?? "");
        }
		private static string lLs(string string_0)
		{
            string_0 = string_0 + new string(' ', 40 - Encoding.GetEncoding("gb2312").GetBytes(string_0).Length) + 88;

            return string_0;
		}
		public static void OpenLocalMusicFolder()
		{
            string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Music");
            Directory.CreateDirectory(text);
            Process.Start("Explorer.exe", text);
        }
		internal static void rLx(string string_0)
		{
            if (string_0.ToLower() == "control+s")
            {
                Stop();
            }
            else if (string_0.ToLower() == "control+p")
            {
                Play();
            }
            else if (string_0.ToLower() == "control+n")
            {
                PlayNextMusic();
            }
        }
		static MusicHelper()
		{
			IsPlayingFreeList = false;
			_cmd1 = new string[8] { "切歌", "切歌", "下一首", "下首", "下首歌", "下一曲", "下一首歌", "下首歌曲" };
			_topSongsKeywords = new string[6] { "置顶", "‘置顶’", "歌曲置顶", "置顶歌曲", "歌曲提前", "提前" };
			_localMusicPath = "";
			_musicWindowInstance = null;
		}
	}

}
