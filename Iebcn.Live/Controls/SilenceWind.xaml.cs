using Iebcn.Live.Helper;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	public partial class SilenceWind : Window, IComponentConnector
	{
		private string AhZ = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件\\冷场\\话术组");

		private string lht = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件\\冷场\\音频组");

		public bool IsClosed;

		public SilenceWind()
		{
			InitializeComponent();
			Eh3();
			base.DataContext = Common.danmuSetting.Silence;
			base.Loaded += Shn;
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				Util.SaveDanmuSetting();
				IsClosed = true;
			}
			catch (Exception ex)
			{
				AppLog.AddLog(GetType()?.ToString() + ex.Message);
			}
		}

		private void Shn(object sender, RoutedEventArgs e)
		{
			Eh3();
		}

		private void lh4(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void Thf(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				MessageBox.Show(Common.Msg_NeedVip1);
			}
		}

		private void RhF(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Ahw(object sender, RoutedEventArgs e)
		{
			try
			{
				string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\事件\\冷场\\声音");
				Directory.CreateDirectory(text);
				Process.Start(text);
			}
			catch
			{
			}
		}

		private void ohC(object sender, RoutedEventArgs e)
		{
			Eh3();
		}

		private void Eh3()
		{
			try
			{
				SilenceHelper.LoadLocalSoundFiles();
				lbSoundCound.Content = "(当前" + SilenceHelper.LocalSoundFiles.Count + "个)";
			}
			catch
			{
			}
		}

		private void DhO(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 2)
			{
				MessageBox.Show(Common.Msg_NeedVip2);
			}
		}

		private void dhU(object sender, RoutedEventArgs e)
		{
			string text = "";
			string text2 = "【话术组播报方案】设置不正确！\r\n参考正确例子：1-2-3-4";
			List<int> list = new List<int>();
			try
			{
				List<string> list2 = txtTextGroupSolution.Text.Split('-').ToList();
				if (list2.Count > 0)
				{
					foreach (string item in list2)
					{
						list.Add(int.Parse(item));
					}
					if (list.Count <= 0)
					{
						MessageBox.Show(text2);
						return;
					}
					Directory.CreateDirectory(AhZ);
					foreach (int item2 in list)
					{
						string text3 = Path.Combine(AhZ, item2 + ".txt");
						if (!File.Exists(text3))
						{
							File.WriteAllText(text3, item2 + "话术组测试话术111\r\n" + item2 + "话术组测试话术222\r\n" + item2 + "话术组测试话术333");
						}
						text = text + XhW(text3) + "\r\n";
					}
					MessageBox.Show(text);
				}
				else
				{
					MessageBox.Show(text2);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(text2 + "\r\n" + ex.Message);
			}
		}

		private string XhW(string string_0)
		{
			try
			{
				List<string> list = (from x in File.ReadAllLines(string_0)
									 where x.Trim() != ""
									 select x).ToList();
				if (list.Count > 0)
				{
					return list[Common.rnd.Next(0, list.Count)];
				}
				return "";
			}
			catch
			{
				return "";
			}
		}

		private void Rha(object sender, RoutedEventArgs e)
		{
			string text = "";
			string text2 = "【音频组播报方案】设置不正确！\r\n参考正确例子：1-2-3-4";
			List<int> list = new List<int>();
			try
			{
				List<string> list2 = txtAudioGroupSolution.Text.Split('-').ToList();
				if (list2.Count <= 0)
				{
					MessageBox.Show(text2);
					return;
				}
				foreach (string item in list2)
				{
					list.Add(int.Parse(item));
				}
				if (list.Count > 0)
				{
					Directory.CreateDirectory(lht);
					foreach (int item2 in list)
					{
						string path = Path.Combine(lht, item2.ToString());
						Directory.CreateDirectory(path);
						string[] files = Directory.GetFiles(path);
						foreach (string text3 in files)
						{
							if (text3.ToLower().EndsWith(".mp3") || text3.ToLower().EndsWith(".wav"))
							{
								text = text + item2 + "音频组：" + Path.GetFileName(text3) + "\r\n";
								break;
							}
						}
					}
					if (!(text.Trim() == ""))
					{
						MessageBox.Show(text);
					}
					else
					{
						MessageBox.Show("还没有音频文件！，你可以将音频文件放到【音频组】文件夹下各个分组文件夹里");
					}
				}
				else
				{
					MessageBox.Show(text2);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(text2 + "\r\n" + ex.Message);
			}
		}

		private void RhN(object sender, RoutedEventArgs e)
		{
			gridTextGroupSetting.Visibility = Visibility.Collapsed;
		}

		private void ThP(object sender, RoutedEventArgs e)
		{
			txtSilenceContent.IsEnabled = false;
		}

		private void Xhu(object sender, RoutedEventArgs e)
		{
			txtSilenceContent.IsEnabled = true;
		}

		private void JhL(object sender, RoutedEventArgs e)
		{
			gridTextGroupSetting.Visibility = Visibility.Visible;
		}

		private void Jh1(object sender, RoutedEventArgs e)
		{
			try
			{
				Directory.CreateDirectory(AhZ);
				Process.Start(AhZ);
			}
			catch
			{
			}
		}

		private void Khm(object sender, RoutedEventArgs e)
		{
			try
			{
				Directory.CreateDirectory(lht);
				Process.Start(lht);
			}
			catch
			{
			}
		}

		private void Rhr(object sender, RoutedEventArgs e)
		{
			gridAudioGroupSetting.Visibility = Visibility.Visible;
		}

		private void JhA(object sender, RoutedEventArgs e)
		{
			gridAudioGroupSetting.Visibility = Visibility.Collapsed;
		}
	}

}
