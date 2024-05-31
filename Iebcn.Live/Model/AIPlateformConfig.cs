using System.Runtime.CompilerServices;
using System.Text;

namespace Iebcn.Live.ViewModel
{
	public class AIPlateformConfig
	{
		[CompilerGenerated]
		private string L4D = "\r\nif(ck1())\r\n{\r\n sendMsg();\r\n}\r\nelse{\r\n'0'\r\n}\r\n\r\nfunction ck1(){ \r\n\treturn document.querySelector('.container-bd3362')!=null && document.querySelector(\"textarea\")!=null;\r\n}\r\n\r\n\r\nfunction sendMsg(){\r\n\tvar txtCtl=document.querySelector('textarea');\r\n    txtCtl.focus();        \r\n    document.execCommand('selectAll', false, null);\r\n    document.execCommand('insertText', false, '{msg}');\r\n   // 模拟回车\r\n   var event = document.createEvent('Event');\r\n   event.initEvent('keydown', true, false);\r\n   event = Object.assign(event, {\r\n   ctrlKey: false,\r\n   metaKey: false,\r\n   altKey: false,\r\n   which: 13,\r\n   keyCode: 13,\r\n   key: 'Enter',\r\n   code: 'Enter'\r\n   });\r\n   txtCtl.focus();\r\n   txtCtl.dispatchEvent(event);return 1;\r\n}\r\n\r\n";

		[CompilerGenerated]
		private string F4c = "\r\nfunction getRepay(){\r\n\tif(document.querySelector('.container-bd3362')==null || document.querySelector('.self-content-pre-ca33f6')==null ){\r\n\t   return '';\r\n\t}\r\n\tvar querys=document.querySelectorAll('.self-content-pre-ca33f6');\r\n\tvar query_count=querys.length;\r\n\tvar answers=document.querySelectorAll('.flow-markdown-body');\r\n\tvar answer_count=answers.length;\r\n\treturn '' + querys[query_count-1].innerText + '--==--' + answers[answer_count-1].innerText;\r\n\t\t\t\r\n}\r\ngetRepay();\r\n";

		[CompilerGenerated]
		private string H4k = "\r\n\r\nif(ck())\r\n{\r\n sendMsg();\r\n}\r\nelse{\r\n '0'\r\n}\r\n\r\nfunction ck(){ \r\n\r\n\tvar queryCount=document.querySelectorAll('.H7oUCk_o').length > 0;\r\n\tvar reGenCount=document.querySelectorAll('.yyjIo3Fm').length > 0;\r\n\treturn queryCount && reGenCount;\r\n\t\r\n}\r\n\r\nvar int_yiyan;\r\nfunction sendMsg(){  \r\n    var txtCtl=document.querySelector('.yc-editor');\r\n\ttxtCtl.focus();  \r\n\tdocument.execCommand('selectAll', false, null);\r\n\tdocument.execCommand('insertText', false, '{msg}');\r\n    int_yiyan=setInterval('yiyan_clock()',1000);\r\n    return 1;\r\n}\r\n\r\nfunction yiyan_clock()\r\n{\r\n     document.querySelector('.VAtmtpqL').click();\r\n     int_yiyan=window.clearInterval(int_yiyan);\r\n}\r\n";

		[CompilerGenerated]
		private string s4M = "\r\nfunction getRepay(){\r\n\tif(document.querySelector('.yyjIo3Fm').innerText!='重新生成'){\r\n\t   return '';\r\n\t}\r\n\tvar querys=document.querySelectorAll('.RpZCRbZe');\r\n\tvar query_count=querys.length;\r\n\tvar answers=document.querySelectorAll('.q4y8uP0A');\r\n\tvar answer_count=answers.length;\r\n\treturn  querys[0].innerText + '--==--' + answers[0].innerText;\r\n\t\t\t\r\n}\r\ngetRepay();\r\n";

		[CompilerGenerated]
		private string z4i = "\r\nif(ck1())\r\n{\r\n sendMsg();\r\n}\r\nelse{\r\n  if(ck2())\r\n\t{\r\n\t sendMsg();\r\n\t}\r\n\telse{\r\n\t  '0'\r\n\t}\r\n}\r\n\r\nfunction ck1(){ \r\n\tvar input=document.querySelector('.input-box-inner')!=null;\r\n\tvar initpage=document.querySelector('.init-page')!=null;\r\n\treturn initpage && input;\r\n}\r\n\r\nfunction ck2(){ \r\n    var input=document.querySelector('.input-box-inner')!=null;\r\n\tvar query=document.querySelector('.markdown-body')!=null;\r\n\tvar stop=document.querySelector('.stop')==null ||document.querySelector('.stop').innerText.trim()=='重新生成';\r\n\treturn input && query && stop;\r\n\t\r\n}\r\n\r\nfunction sendMsg(){  \r\n    var txtCtl=document.querySelector('textarea');\r\n\ttxtCtl.focus();  \r\n\tdocument.execCommand('selectAll', false, null);\r\n\tdocument.execCommand('insertText', false, '{msg}');\r\n    // 模拟回车\r\n     document.querySelector('.enter_icon').click();\r\n\t return 1;\r\n}\r\n";

		[CompilerGenerated]
		private string L42 = "\r\nfunction getRepay(){\r\n\t//是否有'停止'按钮\r\n\tif(document.querySelector('.stop')!=null){\r\n\t   return '';\r\n\t}\r\n\tif(document.querySelectorAll('.question-txt').length<=0){\r\n\t return '';\r\n\t}\r\n\tvar querys=document.querySelectorAll('.question-txt');\r\n\tvar query_count=querys.length;\r\n\tvar answers=document.querySelectorAll('.answer-content-wrap');\r\n\tvar answer_count=answers.length;\r\n\treturn '' + querys[query_count-1].innerText + '--==--' + answers[answer_count-1].innerText;\r\n\t\t\t\r\n}\r\ngetRepay();\r\n";

		[CompilerGenerated]
		private string H48 = "\r\nif(ck1())\r\n{\r\n sendMsg();\r\n}\r\nelse{\r\n  if(ck2())\r\n\t{\r\n\t sendMsg();\r\n\t}\r\n\telse{\r\n\t  '0'\r\n\t}\r\n}\r\n\r\nfunction ck1(){ \r\n\tvar input=document.querySelector('#primary-text-textarea')!=null;\r\n\tvar query=document.querySelector('.chat-window_content_user__cgo3u')==null;\r\n\treturn query && input;\r\n}\r\nfunction ck2(){ \r\n\r\n    var input=document.querySelector('textarea')!=null;\r\n\tvar query=document.querySelector('.chat-window_content_user__cgo3u')!=null;\r\n\tvar newChat=document.querySelector('.ask-window_quit_botmode__IBy2e')!=null;//全新对话\r\n\treturn input && query && newChat;\r\n}\r\n\r\n\r\nfunction sendMsg(){\r\n   \tvar txtCtl=document.querySelector('#primary-text-textarea');\r\n\tif(txtCtl==null){\r\n\t   return 0;\r\n\t}\r\n\ttxtCtl.focus();  \r\n\tdocument.execCommand('selectAll', false, null);\r\n\tdocument.execCommand('insertText', false, '{msg}');\r\n               document.querySelector('.chatBtn--RFpkrgo_').click();\r\n              return 1;\r\n}\r\n\r\n";

		[CompilerGenerated]
		private string C4p = "\r\nfunction getRepay(){\r\nvar q='';\r\nvar a='';\r\nvar qs=document.querySelectorAll('.questionItem--dS3Alcnv');\r\nvar as=document.querySelectorAll('.answerItem--U4_Uv3iw');\r\nif(document.querySelector('.reloadBtn--n5VdexgH')!=null){\r\n   q=qs[qs.length-1].innerText;\r\n   a=as[as.length-1].innerText;\r\n   return q + '--==--' + a.replace('\\n\\n重新生成','')\r\n  }\r\nelse{\r\n   return '';\r\n  }\r\n\t\t\r\n}\r\ngetRepay();\r\n";

		[CompilerGenerated]
		private string m4b = "\r\nif(ck1())\r\n{\r\n sendMsg();\r\n}\r\nelse{\r\n  if(ck2())\r\n\t{\r\n\t sendMsg();\r\n\t}\r\n\telse{\r\n\t  '0'\r\n\t}\r\n}\r\n\r\n\r\nfunction ck1(){ \r\n\tvar input=document.querySelector('textarea')!=null;\r\n\tvar query=document.querySelector('.chat-window_content_user__cgo3u')==null;\r\n\treturn query && input;\r\n}\r\nfunction ck2(){ \r\n\r\n    var input=document.querySelector('textarea')!=null;\r\n\tvar query=document.querySelector('.chat-window_content_user__cgo3u')!=null;\r\n\tvar newChat=document.querySelector('.ask-window_quit_botmode__IBy2e')!=null;//全新对话\r\n\treturn input && query && newChat;\r\n}\r\n\r\n\r\nfunction sendMsg(){\r\n   \tvar txtCtl;\r\n    var txtCtls=document.querySelectorAll('textarea');\r\n\tif(txtCtls.length<=0){\r\n\t\treturn 0;\r\n\t}\r\n\tfor(i=0;i<txtCtls.length;i++){\r\n\t\tif(txtCtls[i].maxLength>=7000){\r\n\t\t\ttxtCtl=txtCtls[i];\r\n\t\t\tbreak;\r\n\t\t}\r\n\t}\r\n\tif(txtCtl==null){\r\n\t\treturn 0;\r\n\t}\r\n\ttxtCtl.focus();  \r\n\tdocument.execCommand('selectAll', false, null);\r\n\tdocument.execCommand('insertText', false, '{msg}');\r\n    // 模拟回车\r\n    document.querySelector('.ask-window_send__xTavC').click();\r\n\treturn 1;\r\n}\r\n";

		[CompilerGenerated]
		private string v4J = "\r\nfunction getRepay(){\r\n\t\r\n\tif(document.querySelector('.chat-window_content_user__cgo3u')==null)\r\n\t{\r\n\t   return '';\r\n\t}\r\n\tif(document.querySelector('.ask-window_quit_botmode__IBy2e')==null)\r\n\t{\r\n\t   return '';\r\n\t}\r\n   if(document.querySelector('.chat-window_re_answer__JEyKu')==null)\r\n\t{\r\n\t   return '';\r\n\t}\r\nvar querys=document.querySelectorAll('.chat-window_content_user__cgo3u');\r\n\tvar query_count=querys.length;\r\n\tvar answers=document.querySelectorAll('.markdown-body');\r\n\tvar answer_count=answers.length;\r\n\treturn '' + querys[0].innerText + '--==--' + answers[0].innerText;\r\n}\r\ngetRepay();\r\n";

		public string DoubaoPost
		{
			[CompilerGenerated]
			get
			{
				return L4D;
			}
			[CompilerGenerated]
			set
			{
				L4D = value;
			}
		}

		public string DoubaoReply
		{
			[CompilerGenerated]
			get
			{
				return F4c;
			}
			[CompilerGenerated]
			set
			{
				F4c = value;
			}
		}

		public string YiyanPost
		{
			[CompilerGenerated]
			get
			{
				return H4k;
			}
			[CompilerGenerated]
			set
			{
				H4k = value;
			}
		}

		public string YiyanReply
		{
			[CompilerGenerated]
			get
			{
				return s4M;
			}
			[CompilerGenerated]
			set
			{
				s4M = value;
			}
		}

		public string QingyanPost
		{
			[CompilerGenerated]
			get
			{
				return z4i;
			}
			[CompilerGenerated]
			set
			{
				z4i = value;
			}
		}

		public string QingyanReply
		{
			[CompilerGenerated]
			get
			{
				return L42;
			}
			[CompilerGenerated]
			set
			{
				L42 = value;
			}
		}

		public string TongyiPost
		{
			[CompilerGenerated]
			get
			{
				return H48;
			}
			[CompilerGenerated]
			set
			{
				H48 = value;
			}
		}

		public string TongyiReply
		{
			[CompilerGenerated]
			get
			{
				return C4p;
			}
			[CompilerGenerated]
			set
			{
				C4p = value;
			}
		}

		public string XinghuoPost
		{
			[CompilerGenerated]
			get
			{
				return m4b;
			}
			[CompilerGenerated]
			set
			{
				m4b = value;
			}
		}

		public string XinghuoReply
		{
			[CompilerGenerated]
			get
			{
				return v4J;
			}
			[CompilerGenerated]
			set
			{
				v4J = value;
			}
		}

		public string Decode(string string_0)
		{
			try
			{
				byte[] bytes = Convert.FromBase64String(string_0);
				return Encoding.UTF8.GetString(bytes);
			}
			catch
			{
			}
			return "";
		}
	}

}
