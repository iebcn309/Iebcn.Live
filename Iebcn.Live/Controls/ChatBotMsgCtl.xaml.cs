using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Iebcn.Live.Controls
{
	public partial class ChatBotMsgCtl : UserControl, IComponentConnector
	{
		// 控件是否可以被移动
		private bool canMove;
		// 鼠标按下时的位置
		private Point mouseDownPosition;

		public ChatBotMsgCtl()
		{
			InitializeComponent();
			txtQuery.Text = "";
		}
		public void SetQueryText(string txt)
		{
			txtQuery.Text = txt;
		}
		// 添加数据
		public void AddData(BotResult botResult)
		{
			txtQuery.Text = botResult.Query;
			printMessageCtl.Print(TimeSpan.FromSeconds(1.0), " ");
			printMessageCtl.txt1.Text = "";
		}
		// 打印机器人的回复
		public void PrintBotReply(string msg)
		{
			printMessageCtl.Print(new TimeSpan(0), msg);
		}
		// 打印机器人的回复
		public void PrintBotReply(TimeSpan duration, string msg)
		{
			printMessageCtl.Print(duration, msg);
		}
		// 鼠标按下时设置 canMove 为 true，并记录鼠标位置
		private void MouseDownHandler(object sender, MouseButtonEventArgs e)
		{
			canMove = true;
			mouseDownPosition = e.GetPosition(gridRoot);
		}
		// 鼠标移动时，如果可以移动并且鼠标左键被按下，则移动控件
		private void MouseMoveHandler(object sender, MouseEventArgs e)
		{
			Point currentPosition = e.GetPosition(gridRoot);
			if (e.Source.GetType().Equals(typeof(StackPanel)) && canMove && e.LeftButton == MouseButtonState.Pressed)
			{
				MoveControl(currentPosition);
			}
		}
		// 移动控件
		private void MoveControl(Point currentPosition)
		{
			Point previousPosition = gridRoot.TranslatePoint(mouseDownPosition, myStackPanel);
			Point newPosition = gridRoot.TranslatePoint(currentPosition, myStackPanel);
			//gridRoot.X += newPosition.X - previousPosition.X;
			//gridRoot.Y += newPosition.Y - previousPosition.Y;
			mouseDownPosition = currentPosition;
		}
		// 鼠标松开时设置 canMove 为 false
		private void MouseUpHandler(object sender, MouseButtonEventArgs e)
		{
			canMove = false;
		}
		// 鼠标单击事件，不需要处理
		private void MouseClickHandler(object sender, MouseButtonEventArgs e)
		{
			// 空方法，不需要处理
		}
	}

}
