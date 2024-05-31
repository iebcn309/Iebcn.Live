using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ICSharpCode.SharpZipLib.Zip;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// FileDownLoaderCtl.xaml 的交互逻辑
	/// </summary>
	public partial class FileDownLoaderCtl : UserControl, IComponentConnector
	{
		public FileDownLoaderCtl()
		{
			InitializeComponent();
		}

		public async Task<bool> DownloadFilesAsync(string url, string downloadPath, string fileName)
		{
			Application.Current.Dispatcher.Invoke(delegate
			{
				lbTip.Visibility = Visibility.Visible;
			});
			string file = Path.Combine(downloadPath, fileName);
			if (File.Exists(file))
			{
				try
				{
					File.Delete(file);
				}
				catch (Exception ex)
				{
					MessageBox.Show("无法下载文件:" + ex.Message);
					return false;
				}
			}
			HttpClient client = new HttpClient();
			try
			{
				HttpResponseMessage response = await client.GetAsync(url, (HttpCompletionOption)1);
				try
				{
					using (Stream stream = await response.Content.ReadAsStreamAsync())
					{
						using (FileStream fileStream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true))
						{
							byte[] buffer = new byte[8192];
							long totalBytesRead = 0L;
							long totalBytes = response.Content.Headers.ContentLength ?? (-1L);
							while (true)
							{
								int num;
								int bytesRead = (num = await stream.ReadAsync(buffer, 0, buffer.Length));
								if (num <= 0)
								{
									break;
								}
								await fileStream.WriteAsync(buffer, 0, bytesRead);
								totalBytesRead += bytesRead;
								double double_ = (double)totalBytesRead / (double)totalBytes * 100.0;
								o7v(double_);
								k7X((double)(totalBytesRead / 1024L) + "/" + totalBytes * 100L / 1024L + "kb");
							}
						}
					}
				}
				finally
				{
					((IDisposable)response)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
			return F7y(file, downloadPath);
		}

		private void o7v(double double_0)
		{
			Application.Current.Dispatcher.Invoke(delegate
			{
				progressBar.Value = double_0;
			});
		}

		private void k7X(string string_0)
		{
			Application.Current.Dispatcher.Invoke(delegate
			{
				progressText.Text = string_0;
			});
		}
		private bool F7y(string string_0, string string_1)
		{
			try
			{
				new FastZip().ExtractZip(string_0, string_1, "");
				MessageBox.Show("下载完毕！");
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return false;
		}

	}

}
