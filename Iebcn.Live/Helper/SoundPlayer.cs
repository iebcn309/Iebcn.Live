using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace Iebcn.Live.Helper
{
	public class SoundPlayer
	{
		private static bool _isMaster;
		private static Voice _voice;

		public static bool Isbusy;
		public static SpeakState SpeakState;
		public static List<int> LevelList;

		public static int GetAudioFileBitRate(string filePath)
		{
			int result = 0;
			if (!filePath.ToLower().EndsWith(".mp3"))
			{
				using (WaveFileReader waveFileReader = new WaveFileReader(filePath))
				{
					result = waveFileReader.WaveFormat.BitsPerSample;
					waveFileReader.Close();
				}
			}
			else
			{
				using (Mp3FileReader mp3FileReader = new Mp3FileReader(filePath))
				{
					result = mp3FileReader.WaveFormat.BitsPerSample;
					mp3FileReader.Close();
				}
			}
			return result;
		}

		public static async Task Play(string file, bool muteOtherSound = false, int level = 0)
		{
			Isbusy = true;
			using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(file)))
			{
				memoryStream.Position = 0L;
				bool isWav = file.ToLower().EndsWith(".wav");
				if (!muteOtherSound)
				{
					await PlaySteam(memoryStream, isWav, level);
				}
				else
				{
					await PlaySteamMaster(memoryStream, isWav, level);
				}
				Isbusy = false;
			}
		}

		public static async Task PlayFree(string file, int lastSeconds)
		{
			using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(file))
			{
				Position = 0L
			})
			{
				bool isWav = file.ToLower().EndsWith(".wav");
				await PlaySteamFree(ms, lastSeconds, isWav);
			}
		}
		public static async Task<Stream> Text2Voice_Xunfei(string sText, Voice v = null)
		{
			_voice = Common.danmuSetting.VoiceDanmu.Voice;
			sText = Uri.EscapeDataString(sText);
			string post = "text=" + sText + "&addressor=" + Common.danmuSetting.VoiceDanmu.Voice.SpeakerValue + "&volume=" + _voice.ConvertVolume() + "&speed=" + (int)_voice.ConvertSpeed() + "&pitch=" + _voice.ConvertPitch();
			if (v != null)
			{
				post = "text=" + sText + "&addressor=" + v.SpeakerValue + "&volume=" + v.ConvertVolume() + "&speed=" + (int)v.ConvertSpeed() + "&pitch=" + v.ConvertPitch();
			}
			using (HttpClient httpClient = new HttpClient())
			{
				byte[] data = Encoding.ASCII.GetBytes(post);
				using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://aidev.xfyun.cn/xcx/aistack/speech/ttsws"))
				{
					httpRequestMessage.Content = new ByteArrayContent(data);
					httpRequestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
					httpRequestMessage.Headers.Add("Cookie", "BAIDUID=CA97D41AACE2AD8A2750225E9F53C9BA:FG=1; BIDUPSID=CA97D41AACE2AD8A2750225E9F53C9BA; PSTM=1562830960; BDUSS=1Vib0ZXRjlqYnBmNG1SaW4wZjJ0SE0wRW40MXhJdE1JT01RQmk5QmtoMzB2VmRkSVFBQUFBJCQAAAAAAAAAAAEAAADSJwUAd2dzY2QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPQwMF30MDBdN; H_WISE_SIDS=126894_127760_132206_132550_133721_120202_133016_132911_133041_131246_132439_130762_132378_131518_118889_118863_118845_118826_118787_107320_133159_132780_134393_133352_129647_134434_124636_128968_132540_133837_133473_131906_133838_133847_132552_134460_133424_134319_134214_129645_131423_134345_133587_110085_134152_127969_131299_127318_127417_134150_133668_134352; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; delPer=0; H_PS_PSSID=29716_1446_21115_29523_29520_29721_29568_29220; PSINO=6; Hm_lvt_8b973192450250dd85b9011320b455ba=1567135060; Hm_lpvt_8b973192450250dd85b9011320b455ba=1567135060");
					httpRequestMessage.Headers.Add("openId", "otGjq0BqLnx7QmgIoRQzWsHw9maE");
					httpRequestMessage.Headers.Add("Host", "aidev.xfyun.cn");
					httpRequestMessage.Headers.Add("Referer", "https://servicewechat.com/wxa7f07807b0f7f668/29/page-frame.html");
					httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36");
					var response = await httpClient.SendAsync(httpRequestMessage);
					if (response.IsSuccessStatusCode == true)
					{
						var result = await response.Content.ReadFromJsonAsync<JsonObject>();
						if (result["code"].GetValue<int>() == 0)
						{
							var url = result["audioPath"].ToString();
							if (!string.IsNullOrEmpty(url))
							{
								var stream = await httpClient.GetByteArrayAsync(url);
								if (stream != null)
								{
									return new MemoryStream(stream);
								}
							}
						}
					}
				}
			}
			return null;
		}
 
		public static async Task<Stream> Text2Voice_Baidu(string sText)
		{
			_voice = Common.danmuSetting.VoiceDanmu.Voice;
			try
			{
				sText = Uri.EscapeDataString(sText);
				string post = "type=tns&spd=" + (int)_voice.ConvertSpeed() + "&pit=" + _voice.ConvertPitch() + "&vol=" + _voice.ConvertVolume() + "&per=" + _voice.SpeakerValue + "&aue=3&tex=" + sText;
				string result = "";
				string url = "http://ai.baidu.com/aidemo";
				string referer = "http://cloud.baidu.com/";
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36");
					if (!string.IsNullOrEmpty(referer))
					{
						client.DefaultRequestHeaders.Referrer = new Uri(referer);
					}

					HttpContent content = new StringContent(post, Encoding.ASCII, "application/x-www-form-urlencoded");
					HttpResponseMessage response = await client.PostAsync(url, content);

					if (response.IsSuccessStatusCode)
					{
						result = await response.Content.ReadAsStringAsync();
					}
					else
					{
						result = $"HTTP error {response.StatusCode}: {response.ReasonPhrase}";
					}
				}
				if (result.Contains("data:audio\\/x-mpeg;base64"))
				{
					result = Regex.Unescape(result);
					return new MemoryStream(Convert.FromBase64String(result.Replace("{\"errno\":0,\"msg\":\"success\",\"data\":\"data:audio/x-mpeg;base64,", "").Replace("\"}", "")));
				}
			}
			catch(Exception ex)
			{
				AppLog.AddLog(ex.ToString());
			}
			return null;
		}
		public static async Task<Stream> Text2Voice_Dui(string sText)
		{
			_voice = Common.danmuSetting.VoiceDanmu.Voice;
			try
			{
				sText = Uri.EscapeDataString(sText);
				string url = "https://dds.dui.ai/runtime/v1/synthesize?voiceId=" + _voice.SpeakerValue + "&speed=" + _voice.ConvertSpeed().ToString("f1") + "&volume=" + _voice.ConvertVolume() + "&audioType=mp3&mp3Quality=high&text=" + sText;
				MemoryStream ms = null;
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36");
					HttpResponseMessage response = await client.GetAsync(url);

					if (response.IsSuccessStatusCode)
					{
						ms = new MemoryStream(await response.Content.ReadAsByteArrayAsync());
					}
				}
				return ms;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.ToString());
			}
			return null;
		}
		public static async Task<byte[]> HttpGetData(string url, string referer = "")
		{
			byte[] data = null;
			using (HttpClient client = new HttpClient())
			{
				// 添加请求头部信息
				client.DefaultRequestHeaders.Add("Cookie", "BAIDUID=CA97D41AACE2AD8A2750225E9F53C9BA:FG=1; BIDUPSID=CA97D41AACE2AD8A2750225E9F53C9BA; PSTM=1562830960; BDUSS=1Vib0ZXRjlqYnBmNG1SaW4wZjJ0SE0wRW40MXhJdE1JT01RQmk5QmtoMzB2VmRkSVFBQUFBJCQAAAAAAAAAAAEAAADSJwUAd2dzY2QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPQwMF30MDBdN; H_WISE_SIDS=126894_127760_132206_132550_133721_120202_133016_132911_133041_131246_132439_130762_132378_131518_118889_118863_118845_118826_118787_107320_133159_132780_134393_133352_129647_134434_124636_128968_132540_133837_133473_131906_133838_133847_132552_134460_133424_134319_134214_129645_131423_134345_133587_110085_134152_127969_131299_127318_127417_134150_133668_134352; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; delPer=0; H_PS_PSSID=29716_1446_21115_29523_29520_29721_29568_29220; PSINO=6; Hm_lvt_8b973192450250dd85b9011320b455ba=1567135060; Hm_lpvt_8b973192450250dd85b9011320b455ba=1567135060");
				client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36");

				if (!string.IsNullOrEmpty(referer))
				{
					client.DefaultRequestHeaders.Referrer = new Uri(referer);
				}

				HttpResponseMessage response = await client.GetAsync(url); // 发送GET请求
				if (response.IsSuccessStatusCode)
				{
					data = await response.Content.ReadAsByteArrayAsync(); // 读取响应内容为字节数组
				}
			}
			return data;
		}
		public static async Task<Stream> Text2Voice_Ali(string sText, Voice v = null)
		{
			_voice = Common.danmuSetting.VoiceDanmu.Voice;
			try
			{
				sText = Uri.EscapeDataString(sText);
				string text = "text=" + sText + "&format=mp3&voice=" + Common.danmuSetting.VoiceDanmu.Voice.SpeakerValue + "&volume=" + _voice.ConvertVolume() + "&speech_rate=" + (int)_voice.ConvertSpeed() + "&pitch_rate=" + _voice.ConvertPitch();
				if (v != null)
				{
					text = "text=" + sText + "&format=mp3&voice=" + v.SpeakerValue + "&volume=" + v.ConvertVolume() + "&speech_rate=" + (int)v.ConvertSpeed() + "&pitch_rate=" + v.ConvertPitch();
				}
				byte[] array = await HttpGetData("https://nls-gateway-inner.aliyuncs.com/stream/v1/tts?appkey=AMS01xcocDkOJIH9&token=1c988cca36e847029b205a00b91db6b9&" + text);
				if (array != null)
				{
					return new MemoryStream(array);
				}
				return null;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.ToString());
			}
			return null;
		}
		public static async Task<Stream> Text2Voice_Microsoft(string sText)
		{
			_voice = Common.danmuSetting.VoiceDanmu.Voice;
			try
			{
				string s = "language=%E4%B8%AD%E6%96%87%EF%BC%88%E6%99%AE%E9%80%9A%E8%AF%9D%EF%BC%8C%E7%AE%80%E4%BD%93%EF%BC%89&voice=" + Common.danmuSetting.VoiceDanmu.Voice.SpeakerValue + "&text=" + Uri.EscapeDataString(sText) + "&role=0&style=0&styledegree=1&volume=" + _voice.ConvertVolume() + "&predict=1&rate=" + (int)_voice.ConvertSpeed() + "&pitch=" + _voice.ConvertPitch() + "&kbitrate=audio-16khz-32kbitrate-mono-mp3&silence=&user_id=9c8197c173de00a3&yzm=&replice=1";
				string result = "";
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36");
					client.DefaultRequestHeaders.Add("Referer", "http://www.ttsonline.cn/?user_id=9c8197c173de00a3");
					client.DefaultRequestHeaders.Add("Origin", "http://www.ttsonline.cn");
					client.DefaultRequestHeaders.Add("Cookie", "t-lang=cn; Hm_lvt_7e1d4492d033e9df3cf687ed3ff39925=" + Util.DataTimeToTimestamp(DateTime.Now) + "; checkuser=" + DateTime.Now.ToString("yyyy-MM-dd"));
					HttpContent content = new StringContent(s, Encoding.ASCII, "application/x-www-form-urlencoded");
					HttpResponseMessage response = await client.PostAsync("http://www.ttsonline.cn/getSpeek.php", content);
					if (response.IsSuccessStatusCode)
					{
						result = await response.Content.ReadAsStringAsync();
					}
					else
					{
						result = $"HTTP error {response.StatusCode}: {response.ReasonPhrase}";
					}
				}
				if (result == "")
				{
					return null;
				}
				dynamic val = JsonConvert.DeserializeObject<object>(result);
				dynamic data = await HttpGetData("" + val.download);
				if (data == null)
				{
					return null;
				}
				return new MemoryStream(data);
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.ToString());
			}
			return null;
		}

		public static async Task<Stream> Text2Voice_Cust(string sText, string custUrl = "")
		{
			if (custUrl == "")
			{
				_voice = Common.danmuSetting.VoiceDanmu.Voice;
				switch (_voice.SpeakerValue.Trim())
				{
					case "cust3":
						custUrl = Common.danmuSetting.VoiceDanmu.CustomVoiceUrl3;
						break;
					case "cust4":
						custUrl = Common.danmuSetting.VoiceDanmu.CustomVoiceUrl4;
						break;
					case "cust5":
						custUrl = Common.danmuSetting.VoiceDanmu.CustomVoiceUrl5;
						break;
					case "cust2":
						custUrl = Common.danmuSetting.VoiceDanmu.CustomVoiceUrl2;
						break;
					case "cust1":
						custUrl = Common.danmuSetting.VoiceDanmu.CustomVoiceUrl1;
						break;
				}
			}
			try
			{
				sText = Uri.EscapeDataString(sText);
				custUrl = custUrl.Replace("{text}", sText);
				byte[] array = await HttpGetData(custUrl);
				if (array == null)
				{
					return null;
				}
				return new MemoryStream(array);
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.ToString());
			}
			return null;
		}
		private static bool imH(int int_0)
		{
			return LevelList.Any((int p) => p > int_0);
		}

		public static async Task PlaySteamFree(Stream ms, int lastSeconds, bool isWav = false)
		{
			if (ms == null)
			{
				return;
			}
			double count = lastSeconds;
			try
			{
				SpeakState = SpeakState.Start;
				GlobalAudioHelper.SetAudioDucking();
				ms.Position = 0L;
				WaveStream Pjd;
				if (isWav)
				{
					Pjd = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(ms)));
				}
				else
				{
					Pjd = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms)));
				}
				WaveOut ojH = new WaveOut(WaveCallbackInfo.FunctionCallback());
				try
				{
					ojH.DeviceNumber = Common.danmuSetting.GlobalConfig.AudioDeviceNumber;
					ojH.Init(Pjd);
					ojH.PlaybackStopped += delegate
					{
						ojH.Stop();
						Pjd.Dispose();
						Pjd = null;
					};
					ojH.Volume = 1f;
					ojH.Play();
					while (ojH.PlaybackState == PlaybackState.Playing)
					{
						if (!(count > 0.0))
						{
							ojH.Stop();
							return;
						}
						await Task.Delay(300);
						count -= 0.15;
					}
				}
				finally
				{
					if (ojH != null)
					{
						((IDisposable)ojH).Dispose();
					}
				}
				ms.Dispose();
				ms = null;
			}
			catch (Exception)
			{
			}
			GlobalAudioHelper.ResetAudioDucking();
			SpeakState = SpeakState.Complete;
		}
		public static async Task PlaySteam(Stream ms, bool isWav = false, int level = 0)
		{
			if (!(Common.danmuSetting?.GlobalConfig.AudioRndModeEnabled ?? false))
			{
				if (_isMaster || ms == null)
				{
					return;
				}
				Isbusy = true;
				LevelList.Add(level);
				SpeakState = SpeakState.Start;
				GlobalAudioHelper.SetAudioDucking();
				ms.Position = 0L;
				WaveStream waveStream;
				if (!isWav)
				{
					waveStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms)));
				}
				else
				{
					waveStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(ms)));
				}
				WaveOut outputDevice = new WaveOut(WaveCallbackInfo.FunctionCallback());
				outputDevice.DeviceNumber = Common.danmuSetting.GlobalConfig.AudioDeviceNumber;
				outputDevice.Init(waveStream);
				outputDevice.PlaybackStopped += delegate
				{
					outputDevice.Stop();
					waveStream.Dispose();
					waveStream = null;
				};
				outputDevice.Volume = 1f;
				outputDevice.Play();
				while (outputDevice.PlaybackState == PlaybackState.Playing)
				{
					if (_isMaster || imH(level))
					{
						outputDevice.Stop();
						break;
					}
					await Task.Delay(300);
				}
				if (outputDevice != null)
				{
					((IDisposable)outputDevice).Dispose();
				}
				ms.Dispose();
				ms = null;
				LevelList.Remove(level);
				GlobalAudioHelper.ResetAudioDucking();
				SpeakState = SpeakState.Complete;
				Isbusy = false;
			}
			else
			{
				await PlaySteamRandMode(ms, isWav);
			}
		}
		public static async Task PlaySteamRandMode(Stream ms, bool isWav = false, int level = 0)
		{
			if (_isMaster || ms == null)
			{
				return;
			}
			Isbusy = true;
			try
			{
				LevelList.Add(level);
				SpeakState = SpeakState.Start;
				GlobalAudioHelper.SetAudioDucking();
				ms.Position = 0L;
				WaveStream njn;
				if (isWav)
				{
					njn = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(ms)));
				}
				else
				{
					njn = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms)));
				}
				SmbPitchShiftingSampleProvider smbPitchShiftingSampleProvider = new SmbPitchShiftingSampleProvider(njn.ToSampleProvider());
				smbPitchShiftingSampleProvider.PitchFactor = CmQ();
				WaveOut Uj4 = new WaveOut();
				try
				{
					Uj4.DeviceNumber = Common.danmuSetting.GlobalConfig.AudioDeviceNumber;
					Uj4.Init(smbPitchShiftingSampleProvider.Take(TimeSpan.FromSeconds(600.0)));
					Uj4.PlaybackStopped += delegate
					{
						Uj4.Stop();
						njn.Dispose();
						njn = null;
					};
					Uj4.Volume = rmK();
					Uj4.Play();
					while (Uj4.PlaybackState == PlaybackState.Playing)
					{
						if (_isMaster || imH(level))
						{
							Uj4.Stop();
							break;
						}
						await Task.Delay(300);
					}
				}
				finally
				{
					if (Uj4 != null)
					{
						((IDisposable)Uj4).Dispose();
					}
				}
				ms.Dispose();
				ms = null;
			}
			catch (Exception)
			{
			}
			LevelList.Remove(level);
			GlobalAudioHelper.ResetAudioDucking();
			SpeakState = SpeakState.Complete;
			Isbusy = false;
		}
		public static async Task PlaySteamMaster(Stream ms, bool isWav = false, int level = 0)
		{
			if (ms != null)
			{
				if (Common.danmuSetting.GlobalConfig.AudioRndModeEnabled)
				{
					await PlaySteamMasterRandMode(ms, isWav);
					return;
				}
				_isMaster = true;
				Isbusy = true;
				try
				{
					LevelList.Add(level);
					SpeakState = SpeakState.Start;
					GlobalAudioHelper.SetAudioDucking();
					ms.Position = 0L;
					WaveStream YjF;
					if (!isWav)
					{
						YjF = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms)));
					}
					else
					{
						YjF = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(ms)));
					}
					WaveOut Gjw = new WaveOut(WaveCallbackInfo.FunctionCallback());
					try
					{
						Gjw.DeviceNumber = Common.danmuSetting.GlobalConfig.AudioDeviceNumber;
						Gjw.Init(YjF);
						Gjw.PlaybackStopped += delegate
						{
							Gjw.Stop();
							YjF.Dispose();
							YjF = null;
						};
						Gjw.Volume = 1f;
						Gjw.Play();
						while (Gjw.PlaybackState == PlaybackState.Playing)
						{
							if (imH(level))
							{
								Gjw.Stop();
								break;
							}
							await Task.Delay(300);
						}
					}
					finally
					{
						if (Gjw != null)
						{
							((IDisposable)Gjw).Dispose();
						}
					}
					ms.Dispose();
					ms = null;
				}
				catch (Exception)
				{
				}
				LevelList.Remove(level);
				GlobalAudioHelper.ResetAudioDucking();
				_isMaster = false;
				Isbusy = false;
				SpeakState = SpeakState.Complete;
			}
			else
			{
				_isMaster = false;
			}
		}
		public static async Task PlaySteamMasterRandMode(Stream ms, bool isWav = false, int level = 0)
		{
			if (ms == null)
			{
				_isMaster = false;
				return;
			}
			_isMaster = true;
			Isbusy = true;
			try
			{
				LevelList.Add(level);
				SpeakState = SpeakState.Start;
				GlobalAudioHelper.SetAudioDucking();
				ms.Position = 0L;
				WaveStream Dj3;
				if (!isWav)
				{
					Dj3 = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms)));
				}
				else
				{
					Dj3 = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(ms)));
				}
				SmbPitchShiftingSampleProvider smbPitchShiftingSampleProvider = new SmbPitchShiftingSampleProvider(Dj3.ToSampleProvider());
				smbPitchShiftingSampleProvider.PitchFactor = CmQ();
				WaveOut ojO = new WaveOut();
				try
				{
					ojO.DeviceNumber = Common.danmuSetting.GlobalConfig.AudioDeviceNumber;
					ojO.Init(smbPitchShiftingSampleProvider.Take(TimeSpan.FromSeconds(600.0)));
					ojO.PlaybackStopped += delegate
					{
						ojO.Stop();
						Dj3.Dispose();
						Dj3 = null;
					};
					ojO.Volume = rmK();
					ojO.Play();
					while (ojO.PlaybackState == PlaybackState.Playing)
					{
						if (imH(level))
						{
							ojO.Stop();
							break;
						}
						await Task.Delay(300);
					}
				}
				finally
				{
					if (ojO != null)
					{
						((IDisposable)ojO).Dispose();
					}
				}
				ms.Dispose();
				ms = null;
			}
			catch
			{
			}
			LevelList.Remove(level);
			GlobalAudioHelper.ResetAudioDucking();
			_isMaster = false;
			Isbusy = false;
			SpeakState = SpeakState.Complete;
		}
		private static float rmK()
		{
			return (float)((double)(float)Common.rnd.Next(8, 11) * 0.1);
		}
		private static float CmQ()
		{
			return (float)((double)(float)Common.rnd.Next(980, 1002) * 0.001);
		}
		static SoundPlayer()
		{
			_isMaster = false;
			Isbusy = false;
			SpeakState = SpeakState.Complete;
			_voice = Common.danmuSetting?.VoiceDanmu.Voice;
			LevelList = new List<int>();
		}
	}

}
