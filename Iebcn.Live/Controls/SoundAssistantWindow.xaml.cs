using Iebcn.Live.Helper;
using Iebcn.Live.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	/// <summary>
	/// SoundAssistantWindow.xaml 的交互逻辑
	/// </summary>
	public partial class SoundAssistantWindow : Window, IComponentConnector
	{
		private SoundAssistant PhG;

		public bool IsClosed;

		public SoundAssistantWindow()
		{
			InitializeComponent();
			Grid grid = gridEdit;
			gridSetting.Visibility = Visibility.Collapsed;
			grid.Visibility = Visibility.Collapsed;
			PhG = Common.danmuSetting.SoundAssistant;
			if (PhG.ListDataSaved == null || PhG.ListDataSaved.Count <= 0)
			{
				PhG.ListDataSaved = SoundAssistantHelper.LoadDefaultList();
			}
			base.DataContext = PhG;
			Khk();
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

		private void dhc(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Khk()
		{
			wrapPanel.Children.Clear();
			foreach (SoundAssItem item in PhG.ListDataSaved)
			{
				wrapPanel.Children.Add(new SoundAssItemCtl(item));
			}
		}

		private void YhM(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.Copy;
		}

		private void Mhi(object sender, DragEventArgs e)
		{
			foreach (string item in (e.Data.GetData(DataFormats.FileDrop, autoConvert: true) as string[]).Where((string x) => x.ToLower().EndsWith(".mp3") || x.ToLower().EndsWith(".wav")).ToList())
			{
				SoundAssItem soundAssItem = new SoundAssItem
				{
					AudioFile = item,
					Title = "自定义.."
				};
				PhG.ListDataSaved.Add(soundAssItem);
				wrapPanel.Children.Add(new SoundAssItemCtl(soundAssItem));
			}
		}

		private void jh2(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void dh8(object sender, KeyEventArgs e)
		{
			if (PhG.ListDataSaved.Any((SoundAssItem x) => x.HotKeys == Win32API.HotkeyCombination))
			{
				(sender as TextBox).Text = "";
				MessageBox.Show("快捷键已经被占用！请换其他！");
			}
			else
			{
				(sender as TextBox).Text = Win32API.HotkeyCombination;
			}
		}

		private void khp(object sender, RoutedEventArgs e)
		{
			gridEdit.Visibility = Visibility.Visible;
			gridEdit.DataContext = new SoundAssItem();
			lbEditType.Content = "添加";
		}

		public void Edit(SoundAssItemCtl ctl)
		{
			gridEdit.Visibility = Visibility.Visible;
			gridEdit.DataContext = ctl.data;
			lbEditType.Content = "编辑";
		}

		public void Delete(SoundAssItemCtl ctl)
		{
			try
			{
				PhG.ListDataSaved.Remove(ctl.data);
				wrapPanel.Children.Remove(ctl);
			}
			catch
			{
			}
		}

		private void Vhb(object sender, RoutedEventArgs e)
		{
			object content = lbEditType.Content;
			object obj;
			if (content == null)
			{
				obj = null;
			}
			else
			{
				obj = content.ToString();
				if (obj != null)
				{
					goto IL_0020;
				}
			}
			obj = "";
			goto IL_0020;
		IL_0020:
			if ((string)obj == "添加")
			{
				SoundAssItem soundAssItem = gridEdit.DataContext as SoundAssItem;
				if (soundAssItem.AudioFile == "")
				{
					MessageBox.Show("请选择音频文件");
					return;
				}
				PhG.ListDataSaved.Add(soundAssItem);
				wrapPanel.Children.Add(new SoundAssItemCtl(soundAssItem));
			}
			gridEdit.Visibility = Visibility.Collapsed;
		}

		private void IhJ(object sender, RoutedEventArgs e)
		{
			gridEdit.Visibility = Visibility.Collapsed;
		}

		private void PhR(object sender, RoutedEventArgs e)
		{
			SoundAssItem soundAssItem = gridEdit.DataContext as SoundAssItem;
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.Filter = "图片文件|*.jpg;*.png;*.gif";
			if (openFileDialog.ShowDialog(this) == true)
			{
				soundAssItem.PicUrl = openFileDialog.FileName;
			}
		}

		private void lhY(object sender, RoutedEventArgs e)
		{
			SoundAssItem soundAssItem = gridEdit.DataContext as SoundAssItem;
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.Filter = "声音文件(*.wav,*.mp3)|*.wav;*.mp3";
			if (openFileDialog.ShowDialog(this) == true)
			{
				soundAssItem.AudioFile = openFileDialog.FileName;
			}
		}

		private void ah0(object sender, RoutedEventArgs e)
		{
			SoundAssItem soundAssItem = gridEdit.DataContext as SoundAssItem;
			if (!string.IsNullOrEmpty(soundAssItem.AudioFile))
			{
				SoundAssistantHelper.StopPlay();
				SoundAssistantHelper.Play(soundAssItem.AudioFile);
			}
		}

		private void Whh(object sender, RoutedEventArgs e)
		{
			gridSetting.Visibility = Visibility.Visible;
		}

		private void shg(object sender, KeyEventArgs e)
		{
			if (PhG.ListDataSaved.Any((SoundAssItem x) => x.HotKeys == Win32API.HotkeyCombination))
			{
				(sender as TextBox).Text = "";
				MessageBox.Show("快捷键已经被占用！请换其他！");
			}
			else
			{
				(sender as TextBox).Text = Win32API.HotkeyCombination;
			}
		}

		private void xh9(object sender, RoutedEventArgs e)
		{
			gridSetting.Visibility = Visibility.Collapsed;
		}

		private void Nh6(object sender, RoutedEventArgs e)
		{
			if (Common.VIPLevel < 1)
			{
				Util.PromptPurchase(1);
			}
		}

		private void Rh7(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("重置所有音效,将删除所有自定义音效数据，确定重置?", "警告", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
			{
				return;
			}
			wrapPanel.Children.Clear();
			PhG.ListDataSaved = SoundAssistantHelper.LoadDefaultList();
			foreach (SoundAssItem item in PhG.ListDataSaved)
			{
				wrapPanel.Children.Add(new SoundAssItemCtl(item));
			}
			MessageBox.Show("重置所有音效完成！");
		}

	}

}
