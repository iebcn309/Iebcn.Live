using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace Iebcn.Live.Helper
{
	public class ChatBotService
	{
		private string _pureMsg = "";
		private string userNick = "";
		private ClientWebSocket _webSocket;
		private string _hash = "";
		public event EventHandler<BotResult> StateCahanged;
		
		/// <summary>
		/// 打开链接
		/// </summary>
		public void Open()
		{
			Task.Run(async () =>
			{
				if (_webSocket.State == WebSocketState.Connecting || _webSocket.State == WebSocketState.Open)
					return;
				string netErr = string.Empty;
				try
				{
					_webSocket = new ClientWebSocket();
					var uri = new Uri("wss://modelscope.cn/api/v1/studio/damo/role_play_chat/gradio/queue/join");
					await _webSocket.ConnectAsync(uri, CancellationToken.None);
					//全部消息容器
					List<byte> bs = new List<byte>();
					//缓冲区
					var buffer = new byte[1024 * 4];
					//监听Socket信息
					WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
					//是否关闭
					while (!result.CloseStatus.HasValue)
					{
						//文本消息
						if (result.MessageType == WebSocketMessageType.Text)
						{
							string userMsg = Encoding.UTF8.GetString(buffer.ToArray(), 0, result.Count);
							if (OnMessage != null)
								OnMessage(_webSocket, userMsg);
							//bs.AddRange(buffer.Take(result.Count));

							////消息是否已接收完全
							//if (result.EndOfMessage)
							//{
							//	//发送过来的消息
							//	string userMsg = Encoding.UTF8.GetString(bs.ToArray(), 0, bs.Count);
							//	//清空消息容器
							//	bs = new List<byte>();
							//	if (OnMessage != null)
							//		OnMessage(_webSocket, userMsg);
							//}
						}
						//继续监听Socket信息
						result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
					}
					////关闭WebSocket（服务端发起）
					//await _webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
				}
				catch (Exception ex)
				{
					netErr = " .Net发生错误" + ex.Message;
					if (_webSocket != null && _webSocket.State == WebSocketState.Open)
						//关闭WebSocket（客户端发起）
						await _webSocket.CloseAsync(WebSocketCloseStatus.Empty, ex.Message, CancellationToken.None);
				}
				finally
				{
				}
			});

		}
		public delegate void MessageEventHandler(object sender, string data);
		/// <summary>
		/// 客户端接收服务端数据时触发
		/// </summary>
		public event MessageEventHandler OnMessage;
		public ChatBotService(DanmuData data)
		{
			_hash = ChatBotHelper.Hash;
			_pureMsg = data.PureMsg;
			_pureMsg = _pureMsg.Replace("\r", "").Replace("\n", "");
			userNick = data.UserNickCut;
            _webSocket = new ClientWebSocket();
            OnMessage += ChatBotService_OnMessage;
			Open();
		}

		private async void ChatBotService_OnMessage(object sender, string data)
		{
			var @string = data;
			if (@string.Contains("{\"msg\": \"send_hash\"}"))
			{
				JnE();
			}
			else if (!@string.StartsWith("{\"msg\": \"send_data\"}"))
			{
				if (@string.StartsWith("{\"msg\": \"estimation\""))
				{
					try
					{
						dynamic val = JsonConvert.DeserializeObject<object>(@string);
						if ((int)val.queue_size > 5)
						{
							StateCahanged?.Invoke(null, new BotResult
							{
								OK = true,
								IsChat = true,
								Query = _pureMsg,
								Result = "GPT服务器队列太忙，建议你切换使用普通聊天源或稍后再试！"
							});
							await CloseAsync();
						}
						return;
					}
					catch
					{
						return;
					}
				}
				if (!@string.StartsWith("{\"msg\": \"process_starts\"}"))
				{
					if (!@string.StartsWith("{\"msg\":\"process_completed\""))
					{
						return;
					}
					dynamic val2 = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(@string);
					string text = "";
					try
					{
						dynamic val3 = "" + val2.output.error;
						if (val3 != "")
						{
							_hash = anz();
							ChatBotHelper.Hash = _hash;
							return;
						}
						dynamic val4 = ("" + val2.output.data[0][0][1]).Replace("\\n", "\r\n");
						text = RemoveBadChars(val4);
						if (!text.StartsWith("error:"))
						{
							StateCahanged?.Invoke(null, new BotResult
							{
								OK = true,
								IsChat = true,
								Query = userNick + ":" + _pureMsg,
								Result = text
							});
							DanmuData danmuData = new DanmuData();
							danmuData.UserNick = userNick;
							danmuData.Type = DanmuType.Chat;
							danmuData.Msg = userNick + ":" + _pureMsg + " GPT:" + text;
							//SocketServer.SendMessage(danmuData);
						}
						else
						{
							_hash = anz();
							ChatBotHelper.Hash = _hash;
						}
					}
					catch (Exception)
					{
					}
					await CloseAsync();
				}
				else
				{
				}
			}
			else
			{
				Cnl();
			}
		}

		public async Task CloseAsync()
		{
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                _webSocket = null;
            }
		}
		private async void JnE()
		{
			if (_hash == "")
			{
				_hash = anz();
				ChatBotHelper.Hash = _hash;
			}
			string data = "{\"session_hash\":\"" + anz() + "\",\"fn_index\":2}";
			await SendTextAsync(data);
		}
		private async void Cnl()
		{
			try
			{
				string text1 = Common.danmuSetting.ChatBot.GptReplyRoleSet1.Replace("\r", "").Replace("\n", "").Trim();
                string text2 = Common.danmuSetting.ChatBot.GptReplyRoleSet2.Replace("\r", "").Replace("\n", "").Trim();
				string data = "{\"fn_index\":2,\"data\":[[],null,\"" + _pureMsg + "\",\"" + text1 + "\",\"" + text2 + "\",null],\"dataType\":[\"chatbot\",\"state\",\"textbox\",\"textbox\",\"textbox\",\"state\"],\"session_hash\":\"" + _hash + "\"}";
				await SendTextAsync(data);
			}
			catch (Exception)
			{
                await CloseAsync();
            }
		}
		private string anz()
		{
			Random random = new Random();
			string[] array = (from c in "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray()
							  select c.ToString()).ToArray();
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 11; i++)
			{
				int num = random.Next(array.Length);
				string value = array[num];
				stringBuilder.Append(value);
			}
			stringBuilder.ToString();
			return stringBuilder.ToString();
		}

		private static bool IsTransientWebSocketException(WebSocketException ex)
		{
			// 判断是否为暂时性错误，如网络中断、服务器忙等。可以根据实际情况调整此方法。
			return ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely ||
				   ex.WebSocketErrorCode == WebSocketError.InvalidMessageType ||
				   ex.WebSocketErrorCode == WebSocketError.InvalidState ||
				   ex.WebSocketErrorCode == WebSocketError.NativeError ||
				   ex.WebSocketErrorCode == WebSocketError.NotAWebSocket ||
				   ex.WebSocketErrorCode == WebSocketError.UnsupportedProtocol ||
				   ex.WebSocketErrorCode == WebSocketError.UnsupportedVersion;
		}
		public async Task SendTextAsync(string message)
	    {
			if (_webSocket.State != WebSocketState.Open)
				return ;
			var encodedMessage = Encoding.UTF8.GetBytes(message);
	        try
	        {
	            await _webSocket.SendAsync(new ArraySegment<byte>(encodedMessage), WebSocketMessageType.Text, true, CancellationToken.None);
	        }
	        catch (WebSocketException ex) when(IsTransientWebSocketException(ex))
	        {
				AppLog.AddLog(ex.ToString());
	        }
	        catch (Exception ex)
	        {
	            AppLog.AddLog(ex.ToString());
	        }
	    }
 
		private string RemoveBadChars(string input)
		{
			input = input.Replace("</code>", "");
			input = input.Replace("</pre>", "");
			input = input.Replace("<code>", "");
			input = input.Replace("<pre>", "");
			input = input.Replace("<p>", "").Replace("</p>", "");
			input = input.Replace("&quot;", "\"");
			input = input.Replace("<s>", "").Replace("</s>", "");
			input = input.Replace("<!-- ALREADY CONVERTED BY PARSER. -->", "");
			input = input.Replace("达摩院", "人类科学家").Replace("</s>", "");
			input = input.Replace("<ul>", "").Replace("</ul>", "");
			input = input.Replace("<li>", "").Replace("</li>", "");
			input = input.Replace("<ol>", "").Replace("</ol>", "");
			if (!input.Contains("<"))
			{
				input.Contains(">");
			}
			if (input.Length > Common.danmuSetting.ChatBot.ReplyWordMaxLenth)
			{
				input = input.Substring(0, Common.danmuSetting.ChatBot.ReplyWordMaxLenth) + "...";
			}
			return input.Trim();
		}
	}

}
