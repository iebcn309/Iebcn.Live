using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using NAudio.Wave;
using System.Collections.ObjectModel;
using System.IO;

namespace Iebcn.Live.Helper
{
	public class SoundAssistantHelper
	{
		public enum SpeakState
		{
			Complete,
			Start
		}

		private static WaveOut _waveOut;
		private static SoundAssistantWindow _soundAssistantWindow;
		private static SpeakState _speakState = SpeakState.Complete;

		/// <summary>
		/// 显示音效助手窗口
		/// </summary>
		public static void ShowWindow()
		{
			if (_soundAssistantWindow == null || _soundAssistantWindow.IsClosed)
			{
				_soundAssistantWindow = new SoundAssistantWindow();
			}
			_soundAssistantWindow.Show();
			_soundAssistantWindow.Activate();
		}

		/// <summary>
		/// 添加弹幕数据并播放相应的音效
		/// </summary>
		/// <param name="data">弹幕数据</param>
		public static void AddData(DanmuData data)
		{
			if (!Common.danmuSetting.SoundAssistant.IsEnabled ||
				Common.danmuSetting.SoundAssistant.ListDataSaved == null ||
				Common.danmuSetting.SoundAssistant.ListDataSaved.Count <= 0)
			{
				return;
			}

			SoundAssItem soundAssItem = GetSoundAssItem(data);
			if (soundAssItem != null && !string.IsNullOrEmpty(soundAssItem.AudioFile))
			{
				StopPlay();
				Play(soundAssItem.AudioFile);
			}
		}

		/// <summary>
		/// 删除音效项
		/// </summary>
		/// <param name="ctl">音效项控制对象</param>
		public static void Delete(SoundAssItemCtl ctl)
		{
			if (_soundAssistantWindow != null)
			{
				_soundAssistantWindow.Delete(ctl);
			}
		}

		/// <summary>
		/// 编辑音效项
		/// </summary>
		/// <param name="ctl">音效项控制对象</param>
		public static void Edit(SoundAssItemCtl ctl)
		{
			if (_soundAssistantWindow != null)
			{
				_soundAssistantWindow.Edit(ctl);
			}
		}

		/// <summary>
		/// 加载默认的音效列表
		/// </summary>
		/// <returns>音效列表</returns>
		public static ObservableCollection<SoundAssItem> LoadDefaultList()
		{
			ObservableCollection<SoundAssItem> observableCollection = new ObservableCollection<SoundAssItem>();
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			foreach (string item in Resource1.SoundAssDefault.Split('\n'))
			{
				if (item.Split('|').Length > 2)
				{
					string[] array = item.Split('|');
					observableCollection.Add(new SoundAssItem
					{
						Title = array[0].Trim(),
						AudioFile = Path.Combine(baseDirectory, array[1].Trim('/')).Trim(),
						PicUrl = array[2].Trim()
					});
				}
			}
			return observableCollection;
		}

		/// <summary>
		/// 检查快捷键并播放音效
		/// </summary>
		/// <param name="hotKeys">快捷键组合</param>
		public static void CheckHotkeyPlayAudio(string hotKeys)
		{
			if (hotKeys == Common.danmuSetting.SoundAssistant.StopSoundAssHotKeys)
			{
				StopPlay();
				return;
			}

			SoundAssItem soundAssItem = GetSoundAssItemByHotKeys(hotKeys);
			if (soundAssItem != null && !string.IsNullOrEmpty(soundAssItem.AudioFile))
			{
				StopPlay();
				Play(soundAssItem.AudioFile);
			}
		}

		/// <summary>
		/// 播放音效文件
		/// </summary>
		/// <param name="file">音效文件路径</param>
		public static void Play(string file)
		{
			try
			{
				using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
				{
					PlaySteam(stream, file.ToLower().EndsWith(".wav"));
				}
			}
			catch (Exception ex)
			{
				AppLog.AddLog(ex.ToString());
			}
		}

		/// <summary>
		/// 使用流播放音效
		/// </summary>
		/// <param name="stream">音效流</param>
		/// <param name="isWav">是否为WAV格式</param>
		public static void PlaySteam(Stream stream, bool isWav = false)
		{
			if (stream == null)
			{
				return;
			}

			try
			{
				_speakState = SpeakState.Start;
				GlobalAudioHelper.SetAudioDucking();
				stream.Position = 0;

				using (_waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
				{
					var playbackBuffer=PrepareWaveStream(stream, isWav);
					_waveOut.Init(playbackBuffer);
					_waveOut.PlaybackStopped += (sender, e) =>
					{
						playbackBuffer.Dispose();
						_waveOut.Dispose();
						_speakState = SpeakState.Complete;
					};
					_waveOut.Volume = (float)Common.danmuSetting.SoundAssistant.Volume;
					_waveOut.Play();

					while (_waveOut.PlaybackState == PlaybackState.Playing)
					{
						Thread.Sleep(100);
					}
				}
			}
			catch (Exception ex)
			{
				AppLog.AddLog($"Error: {ex.ToString()}");
			}
			finally
			{
				GlobalAudioHelper.ResetAudioDucking();
			}
		}

		/// <summary>
		/// 停止播放音效
		/// </summary>
		public static void StopPlay()
		{
			if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
			{
				_waveOut.Stop();
			}
		}

		private static SoundAssItem GetSoundAssItem(DanmuData data)
		{
			// 根据弹幕数据类型查找音效项
			// 这里需要根据实际情况实现查找逻辑
			return null;
		}

		private static SoundAssItem GetSoundAssItemByHotKeys(string hotKeys)
		{
			// 根据快捷键查找音效项
			// 这里需要根据实际情况实现查找逻辑
			return null;
		}

		private static WaveStream PrepareWaveStream(Stream stream, bool isWav)
		{
			WaveStream NVX;
			if (isWav)
			{
				NVX = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(stream)));
			}
			else
			{
				NVX = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(stream)));
			}
			// 根据文件格式准备WaveStream
			// 这里需要根据实际情况实现转换逻辑
			return NVX;
		}

		static SoundAssistantHelper()
		{
			_speakState = SpeakState.Complete;
			_soundAssistantWindow = null;
		}
	}
}
