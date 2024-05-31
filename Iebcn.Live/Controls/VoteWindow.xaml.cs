using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// VoteWindow.xaml 的交互逻辑
	/// </summary>
	public partial class VoteWindow : Window, IComponentConnector, IStyleConnector
	{
		private int t97 = 10;

		private DispatcherTimer w9T = new DispatcherTimer();

		public bool IsClosed;

		public VoteWindow()
		{
			Common.voteWindow = this;
			InitializeComponent();
			if (Common.danmuSetting.Vote.VoteDataList.Count <= 0)
			{
				K9b(3);
			}
			base.DataContext = Common.danmuSetting.Vote;
			voteListView.DataContext = (voteListView.ItemsSource = Common.danmuSetting.Vote.VoteDataList);
			w9T.Interval = TimeSpan.FromSeconds(1.0);
			w9T.Tick += H9c;
		}

		private void o9D(object sender, RoutedEventArgs e)
		{
			t97 = Common.danmuSetting.Vote.CountDownSeconds;
			stackPanelCountDown.Visibility = Visibility.Visible;
			countdown.Text = t97.ToString();
			w9T.Start();
		}

		private void H9c(object sender, EventArgs e)
		{
			if (t97 < 0)
			{
				w9T.Stop();
				return;
			}
			t97--;
			if (t97 == 0)
			{
				w9T.Stop();
				countdown.Text = "Time's Up!";
				stackPanelCountDown.Visibility = Visibility.Collapsed;
			}
			else
			{
				countdown.Text = t97.ToString();
				Y9k();
			}
		}

		private void Y9k()
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation(1.0, 0.0, TimeSpan.FromSeconds(0.9));
			doubleAnimation.AutoReverse = true;
			doubleAnimation.AccelerationRatio = 0.2;
			doubleAnimation.DecelerationRatio = 0.8;
			countdown.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			Util.SaveDanmuSetting();
			IsClosed = true;
		}

		private void J9M(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DragMove();
			}
			catch
			{
			}
		}

		private void B9i(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void q92(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Visible;
		}

		private void h98(object sender, MouseEventArgs e)
		{
			gridBar.Visibility = Visibility.Collapsed;
		}

		private void h9p(object sender, RoutedEventArgs e)
		{
			K9b(1);
		}

		private void K9b(int int_0)
		{
			for (int i = 0; i < int_0; i++)
			{
				Common.danmuSetting.Vote.VoteDataList.Add(new VoteData());
			}
		}

		private void N9J(object sender, MouseButtonEventArgs e)
		{
			try
			{
				System.Windows.Controls.Image image = e.Source as System.Windows.Controls.Image;
				if ((e.Source as System.Windows.Controls.Image).Tag is VoteData voteData)
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Filter = "图片|*.jpg;*.png;*.bmp";
					if (openFileDialog.ShowDialog(this) == true)
					{
						voteData.HeadPic = openFileDialog.FileName;
						image.Source = new BitmapImage(new Uri(voteData.HeadPic, UriKind.RelativeOrAbsolute));
					}
				}
			}
			catch
			{
			}
		}

		private void o9R(object sender, RoutedEventArgs e)
		{
			try
			{
				if ((e.Source as Button).Tag is VoteData item)
				{
					Common.danmuSetting.Vote.VoteDataList.Remove(item);
				}
			}
			catch
			{
			}
		}

		private void L9Y(object sender, MouseEventArgs e)
		{
			try
			{
				if ((e.Source as Border).Tag is VoteData voteData)
				{
					voteData.BtnDelVisibility = Visibility.Visible;
				}
			}
			catch
			{
			}
		}

		private void p90(object sender, MouseEventArgs e)
		{
			try
			{
				if ((e.Source as Border).Tag is VoteData voteData)
				{
					voteData.BtnDelVisibility = Visibility.Collapsed;
				}
			}
			catch
			{
			}
		}

		private void S9h(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void G9g(object sender, RoutedEventArgs e)
		{
			if (base.WindowState != WindowState.Maximized)
			{
				base.WindowState = WindowState.Maximized;
			}
			else
			{
				base.WindowState = WindowState.Normal;
			}
		}

		private void a99(object sender, RoutedEventArgs e)
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
					goto IL_0020;
				}
			}
			obj = "";
			goto IL_0020;
		IL_0020:
			string key = (string)obj;
			voteListView.ItemTemplate = base.Resources[key] as DataTemplate;
		}

	}

}
