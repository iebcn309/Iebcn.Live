using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// SelectEventPicsWindow.xaml 的交互逻辑
	/// </summary>
	public partial class SelectEventPicsWindow : Window, IComponentConnector
	{
		private string i0u = "";

		public string PicUrl = "Random";

		[CompilerGenerated]
		private bool n0L;

		public bool IsClosed
		{
			[CompilerGenerated]
			get
			{
				return n0L;
			}
			[CompilerGenerated]
			private set
			{
				n0L = value;
			}
		}

		public SelectEventPicsWindow()
		{
			InitializeComponent();
		}

		public SelectEventPicsWindow(string folderPath)
		{
			i0u = folderPath;
			InitializeComponent();
			base.Topmost = true;
			base.MouseLeftButtonDown += y03;
			N0O(folderPath);
		}

		private void y03(object sender, MouseButtonEventArgs e)
		{
			try
			{
				base.Topmost = false;
				base.Topmost = true;
				DragMove();
			}
			catch
			{
			}
		}

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		private async void N0O(string string_1)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
		{
			foreach (string item in (from string_0 in Directory.GetFiles(string_1)
									 where I0U(string_0)
									 select string_0).ToList())
			{
				GifButton gifButton = new GifButton(new
				{
					PicUrl = item
				})
				{
					Height = 224.0
				};
				gifButton.Tag = item;
				gifButton.btn.Click += e0W;
				wrapPanel.Children.Add(gifButton);
			}
			GifButton gifButton2 = new GifButton(new
			{
				PicUrl = "Pack://application:,,,/Assets/rnd.jpg"
			})
			{
				Height = 224.0
			};
			gifButton2.Tag = "Random";
			gifButton2.btn.Click += e0W;
			wrapPanel.Children.Insert(0, gifButton2);
		}

		private bool I0U(string string_0)
		{
			string[] array = new string[4] { ".jpg", ".png", ".gif", ".bmp" };
			foreach (string value in array)
			{
				if (string_0.EndsWith(value))
				{
					return true;
				}
			}
			return false;
		}

		private void e0W(object sender, RoutedEventArgs e)
		{
			object tag = (sender as Button).Tag;
			object obj;
			if (tag == null)
			{
				obj = null;
			}
			else
			{
				obj = tag.ToString();
				if (obj != null)
				{
					goto IL_0021;
				}
			}
			obj = "";
			goto IL_0021;
		IL_0021:
			PicUrl = (string)obj;
			base.MouseLeftButtonDown -= y03;
			Close();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			IsClosed = true;
		}

		private void m0a(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start(i0u);
			}
			catch
			{
			}
		}
	}

}
