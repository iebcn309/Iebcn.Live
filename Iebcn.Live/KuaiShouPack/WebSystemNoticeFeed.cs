using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class WebSystemNoticeFeed : IMessage<WebSystemNoticeFeed>, IMessage, IEquatable<WebSystemNoticeFeed>, IDeepCloneable<WebSystemNoticeFeed>, IBufferMessage
	{
		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static class Types
		{
			public enum DisplayType
			{
				[OriginalName("UNKNOWN_DISPLAY_TYPE")]
				UnknownDisplayType,
				[OriginalName("COMMENT")]
				Comment,
				[OriginalName("ALERT")]
				Alert,
				[OriginalName("TOAST")]
				Toast
			}
		}

		private static readonly MessageParser<WebSystemNoticeFeed> GAb;

		private UnknownFieldSet XAa;

		private int RAo;

		public const int IdFieldNumber = 1;

		private static readonly string QAV;

		private string qAZ;

		public const int UserFieldNumber = 2;

		private SimpleUserInfo LAh;

		public const int TimeFieldNumber = 3;

		private static readonly ulong FAz;

		private ulong lP3;

		public const int ContentFieldNumber = 4;

		private static readonly string uPW;

		private string gPL;

		public const int DisplayDurationFieldNumber = 5;

		private static readonly ulong qPj;

		private ulong EPF;

		public const int SortRankFieldNumber = 6;

		private static readonly ulong lPq;

		private ulong LP9;

		public const int DisplayTypeFieldNumber = 7;

		private static readonly Types.DisplayType DP2;

		private Types.DisplayType EPA;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageParser<WebSystemNoticeFeed> Parser => GAb;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[9];

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Id
		{
			get
			{
				return qAZ ?? QAV;
			}
			set
			{
				qAZ = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasId => qAZ != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public SimpleUserInfo User
		{
			get
			{
				return LAh;
			}
			set
			{
				LAh = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ulong Time
		{
			get
			{
				if ((RAo & 1) == 0)
				{
					return FAz;
				}
				return lP3;
			}
			set
			{
				RAo |= 1;
				lP3 = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasTime => (RAo & 1) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Content
		{
			get
			{
				return gPL ?? uPW;
			}
			set
			{
				gPL = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasContent => gPL != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong DisplayDuration
		{
			get
			{
				if (((uint)RAo & 2u) != 0)
				{
					return EPF;
				}
				return qPj;
			}
			set
			{
				RAo |= 2;
				EPF = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDisplayDuration => (RAo & 2) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong SortRank
		{
			get
			{
				if ((RAo & 4) == 0)
				{
					return lPq;
				}
				return LP9;
			}
			set
			{
				RAo |= 4;
				LP9 = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasSortRank => (RAo & 4) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public Types.DisplayType DisplayType
		{
			get
			{
				if (((uint)RAo & 8u) != 0)
				{
					return EPA;
				}
				return DP2;
			}
			set
			{
				RAo |= 8;
				EPA = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasDisplayType => (RAo & 8) != 0;

		[GeneratedCode("protoc", null)]
		public WebSystemNoticeFeed()
		{
		}

		[GeneratedCode("protoc", null)]
		public WebSystemNoticeFeed(WebSystemNoticeFeed other)
			: this()
		{
			RAo = other.RAo;
			qAZ = other.qAZ;
			LAh = ((other.LAh != null) ? other.LAh.Clone() : null);
			lP3 = other.lP3;
			gPL = other.gPL;
			EPF = other.EPF;
			LP9 = other.LP9;
			EPA = other.EPA;
			XAa = UnknownFieldSet.Clone(other.XAa);
		}

		[GeneratedCode("protoc", null)]
		public WebSystemNoticeFeed Clone()
		{
			return new WebSystemNoticeFeed(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearId()
		{
			qAZ = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearTime()
		{
			RAo &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearContent()
		{
			gPL = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDisplayDuration()
		{
			RAo &= -3;
		}

		[GeneratedCode("protoc", null)]
		public void ClearSortRank()
		{
			RAo &= -5;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDisplayType()
		{
			RAo &= -9;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as WebSystemNoticeFeed);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(WebSystemNoticeFeed other)
		{
			if (other == null)
			{
				return false;
			}
			if (other == this)
			{
				return true;
			}
			if (Id != other.Id)
			{
				return false;
			}
			if (object.Equals(User, other.User))
			{
				if (Time != other.Time)
				{
					return false;
				}
				if (!(Content != other.Content))
				{
					if (DisplayDuration != other.DisplayDuration)
					{
						return false;
					}
					if (SortRank != other.SortRank)
					{
						return false;
					}
					if (DisplayType != other.DisplayType)
					{
						return false;
					}
					return object.Equals(XAa, other.XAa);
				}
				return false;
			}
			return false;
		}

		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			int num = 1;
			if (HasId)
			{
				num ^= Id.GetHashCode();
			}
			if (LAh != null)
			{
				num ^= User.GetHashCode();
			}
			if (HasTime)
			{
				num ^= Time.GetHashCode();
			}
			if (HasContent)
			{
				num ^= Content.GetHashCode();
			}
			if (HasDisplayDuration)
			{
				num ^= DisplayDuration.GetHashCode();
			}
			if (HasSortRank)
			{
				num ^= SortRank.GetHashCode();
			}
			if (HasDisplayType)
			{
				num ^= DisplayType.GetHashCode();
			}
			if (XAa != null)
			{
				num ^= XAa.GetHashCode();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public override string ToString()
		{
			return JsonFormatter.ToDiagnosticString(this);
		}

		[GeneratedCode("protoc", null)]
		public void WriteTo(CodedOutputStream output)
		{
			output.WriteRawMessage(this);
		}

		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalWriteTo(ref WriteContext output)
		{
			if (HasId)
			{
				output.WriteRawTag(10);
				output.WriteString(Id);
			}
			if (LAh != null)
			{
				output.WriteRawTag(18);
				output.WriteMessage(User);
			}
			if (HasTime)
			{
				output.WriteRawTag(24);
				output.WriteUInt64(Time);
			}
			if (HasContent)
			{
				output.WriteRawTag(34);
				output.WriteString(Content);
			}
			if (HasDisplayDuration)
			{
				output.WriteRawTag(40);
				output.WriteUInt64(DisplayDuration);
			}
			if (HasSortRank)
			{
				output.WriteRawTag(48);
				output.WriteUInt64(SortRank);
			}
			if (HasDisplayType)
			{
				output.WriteRawTag(56);
				output.WriteEnum((int)DisplayType);
			}
			if (XAa != null)
			{
				XAa.WriteTo(ref output);
			}
		}

		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			int num = 0;
			if (HasId)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(Id);
			}
			if (LAh != null)
			{
				num += 1 + CodedOutputStream.ComputeMessageSize(User);
			}
			if (HasTime)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(Time);
			}
			if (HasContent)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(Content);
			}
			if (HasDisplayDuration)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(DisplayDuration);
			}
			if (HasSortRank)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(SortRank);
			}
			if (HasDisplayType)
			{
				num += 1 + CodedOutputStream.ComputeEnumSize((int)DisplayType);
			}
			if (XAa != null)
			{
				num += XAa.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(WebSystemNoticeFeed other)
		{
			if (other == null)
			{
				return;
			}
			if (other.HasId)
			{
				Id = other.Id;
			}
			if (other.LAh != null)
			{
				if (LAh == null)
				{
					User = new SimpleUserInfo();
				}
				User.MergeFrom(other.User);
			}
			if (other.HasTime)
			{
				Time = other.Time;
			}
			if (other.HasContent)
			{
				Content = other.Content;
			}
			if (other.HasDisplayDuration)
			{
				DisplayDuration = other.DisplayDuration;
			}
			if (other.HasSortRank)
			{
				SortRank = other.SortRank;
			}
			if (other.HasDisplayType)
			{
				DisplayType = other.DisplayType;
			}
			XAa = UnknownFieldSet.MergeFrom(XAa, other.XAa);
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(CodedInputStream input)
		{
			input.ReadRawMessage(this);
		}

		[GeneratedCode("protoc", null)]
		void IBufferMessage.InternalMergeFrom(ref ParseContext input)
		{
			uint num;
			while ((num = input.ReadTag()) != 0)
			{
				switch (num)
				{
				case 24u:
					Time = input.ReadUInt64();
					break;
				case 18u:
					if (LAh == null)
					{
						User = new SimpleUserInfo();
					}
					input.ReadMessage(User);
					break;
				case 10u:
					Id = input.ReadString();
					break;
				case 40u:
					DisplayDuration = input.ReadUInt64();
					break;
				case 34u:
					Content = input.ReadString();
					break;
				default:
					XAa = UnknownFieldSet.MergeFieldFrom(XAa, ref input);
					break;
				case 56u:
					DisplayType = (Types.DisplayType)input.ReadEnum();
					break;
				case 48u:
					SortRank = input.ReadUInt64();
					break;
				}
			}
		}

		static WebSystemNoticeFeed()
		{
			GAb = new MessageParser<WebSystemNoticeFeed>(() => new WebSystemNoticeFeed());
			QAV = "";
			FAz = 0uL;
			uPW = "";
			qPj = 0uL;
			lPq = 0uL;
			DP2 = Types.DisplayType.UnknownDisplayType;
		}
	}
}
