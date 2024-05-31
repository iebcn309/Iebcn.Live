using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Iebcn.Live.Controls
{
	public partial class PrintMessageCtl : UserControl, IComponentConnector
	{
		// Storyboard 对象
		private Storyboard _storyboard;
		// 是否允许打印
		private bool _isPrintingAllowed = true;

		// 构造函数
		public PrintMessageCtl()
		{
			InitializeComponent();
		}
		// 打印消息方法，默认欢迎使用抖音弹幕助手
		public void Print(TimeSpan duration, string msg = "欢迎使用抖音弹幕助手")
		{
			// 如果允许打印
			if (_isPrintingAllowed)
			{
				// 清空文本框
				txt1.Text = "";
				// 更新布局
				txt1.UpdateLayout();
				// 执行打印动画
				PrintAnimation(duration, msg, txt1);
			}
		}
		// 执行打印动画方法
		private void PrintAnimation(TimeSpan duration, string text, TextBlock textBlock)
		{
			try
			{
				// 计算动画时长
				if (duration.TotalSeconds <= 0.0)
				{
					duration = TimeSpan.FromSeconds((double)text.Length * 0.1);
					if (duration.TotalSeconds < 1.0)
						duration = TimeSpan.FromSeconds(1.0);
				}
				// 创建 Storyboard 对象
				_storyboard = new Storyboard();
				// 注册动画完成事件
				_storyboard.Completed += AnimationCompleted;
				// 动画填充方式
				_storyboard.FillBehavior = FillBehavior.HoldEnd;
				// 创建 StringAnimationUsingKeyFrames 对象
				StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
				// 设置动画时长
				stringAnimationUsingKeyFrames.Duration = new Duration(duration);
				// 创建文本字符串
				string currentText = string.Empty;
				// 遍历字符串中的每个字符
				foreach (char c in text)
				{
					// 创建 DiscreteStringKeyFrame 对象
					DiscreteStringKeyFrame discreteStringKeyFrame = new DiscreteStringKeyFrame();
					// 设置关键帧时间
					discreteStringKeyFrame.KeyTime = KeyTime.Paced;
					// 拼接文本字符串
					currentText = (discreteStringKeyFrame.Value = currentText + c);
					// 添加关键帧
					stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
				}
				// 设置动画目标
				Storyboard.SetTargetName(stringAnimationUsingKeyFrames, textBlock.Name);
				Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
				// 添加动画
				_storyboard.Children.Add(stringAnimationUsingKeyFrames);
				// 开始动画
				_storyboard.Begin(textBlock);
			}
			catch
			{
			}
		}
		// 动画完成事件处理方法
		private void AnimationCompleted(object sender, EventArgs e)
		{
			// 允许打印
			_isPrintingAllowed = true;
		}
	}

}
