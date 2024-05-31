using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class CSWebEnterRoom : IMessage<CSWebEnterRoom>, IMessage, IEquatable<CSWebEnterRoom>, IDeepCloneable<CSWebEnterRoom>, IBufferMessage
	{
		private static readonly MessageParser<CSWebEnterRoom> R9a;

		private UnknownFieldSet c9o;

		private int j9V;

		public const int TokenFieldNumber = 1;

		private static readonly string v9Z;

		private string H9h;

		public const int LiveStreamIdFieldNumber = 2;

		private static readonly string m9z;

		private string V23;

		public const int ReconnectCountFieldNumber = 3;

		private static readonly uint z2W;

		private uint i2L;

		public const int LastErrorCodeFieldNumber = 4;

		private static readonly uint C2j;

		private uint Y2F;

		public const int ExpTagFieldNumber = 5;

		private static readonly string e2q;

		private string R29;

		public const int AttachFieldNumber = 6;

		private static readonly string r22;

		private string a2A;

		public const int PageIdFieldNumber = 7;

		private static readonly string J2P;

		private string J26;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<CSWebEnterRoom> Parser => R9a;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[2];

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string Token
		{
			get
			{
				return H9h ?? v9Z;
			}
			set
			{
				H9h = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasToken => H9h != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string LiveStreamId
		{
			get
			{
				return V23 ?? m9z;
			}
			set
			{
				V23 = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasLiveStreamId => V23 != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public uint ReconnectCount
		{
			get
			{
				if ((j9V & 1) == 0)
				{
					return z2W;
				}
				return i2L;
			}
			set
			{
				j9V |= 1;
				i2L = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasReconnectCount => (j9V & 1) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public uint LastErrorCode
		{
			get
			{
				if ((j9V & 2) == 0)
				{
					return C2j;
				}
				return Y2F;
			}
			set
			{
				j9V |= 2;
				Y2F = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasLastErrorCode => (j9V & 2) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string ExpTag
		{
			get
			{
				return R29 ?? e2q;
			}
			set
			{
				R29 = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasExpTag => R29 != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string Attach
		{
			get
			{
				return a2A ?? r22;
			}
			set
			{
				a2A = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasAttach => a2A != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string PageId
		{
			get
			{
				return J26 ?? J2P;
			}
			set
			{
				J26 = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasPageId => J26 != null;

		[GeneratedCode("protoc", null)]
		public CSWebEnterRoom()
		{
		}

		[GeneratedCode("protoc", null)]
		public CSWebEnterRoom(CSWebEnterRoom other)
			: this()
		{
			j9V = other.j9V;
			H9h = other.H9h;
			V23 = other.V23;
			i2L = other.i2L;
			Y2F = other.Y2F;
			R29 = other.R29;
			a2A = other.a2A;
			J26 = other.J26;
			c9o = UnknownFieldSet.Clone(other.c9o);
		}

		[GeneratedCode("protoc", null)]
		public CSWebEnterRoom Clone()
		{
			return new CSWebEnterRoom(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearToken()
		{
			H9h = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearLiveStreamId()
		{
			V23 = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearReconnectCount()
		{
			j9V &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearLastErrorCode()
		{
			j9V &= -3;
		}

		[GeneratedCode("protoc", null)]
		public void ClearExpTag()
		{
			R29 = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearAttach()
		{
			a2A = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearPageId()
		{
			J26 = null;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as CSWebEnterRoom);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(CSWebEnterRoom other)
		{
			if (other == null)
			{
				return false;
			}
			if (other == this)
			{
				return true;
			}
			if (!(Token != other.Token))
			{
				if (LiveStreamId != other.LiveStreamId)
				{
					return false;
				}
				if (ReconnectCount != other.ReconnectCount)
				{
					return false;
				}
				if (LastErrorCode != other.LastErrorCode)
				{
					return false;
				}
				if (!(ExpTag != other.ExpTag))
				{
					if (!(Attach != other.Attach))
					{
						if (PageId != other.PageId)
						{
							return false;
						}
						return object.Equals(c9o, other.c9o);
					}
					return false;
				}
				return false;
			}
			return false;
		}

		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			int num = 1;
			if (HasToken)
			{
				num ^= Token.GetHashCode();
			}
			if (HasLiveStreamId)
			{
				num ^= LiveStreamId.GetHashCode();
			}
			if (HasReconnectCount)
			{
				num ^= ReconnectCount.GetHashCode();
			}
			if (HasLastErrorCode)
			{
				num ^= LastErrorCode.GetHashCode();
			}
			if (HasExpTag)
			{
				num ^= ExpTag.GetHashCode();
			}
			if (HasAttach)
			{
				num ^= Attach.GetHashCode();
			}
			if (HasPageId)
			{
				num ^= PageId.GetHashCode();
			}
			if (c9o != null)
			{
				num ^= c9o.GetHashCode();
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
			if (HasToken)
			{
				output.WriteRawTag(10);
				output.WriteString(Token);
			}
			if (HasLiveStreamId)
			{
				output.WriteRawTag(18);
				output.WriteString(LiveStreamId);
			}
			if (HasReconnectCount)
			{
				output.WriteRawTag(24);
				output.WriteUInt32(ReconnectCount);
			}
			if (HasLastErrorCode)
			{
				output.WriteRawTag(32);
				output.WriteUInt32(LastErrorCode);
			}
			if (HasExpTag)
			{
				output.WriteRawTag(42);
				output.WriteString(ExpTag);
			}
			if (HasAttach)
			{
				output.WriteRawTag(50);
				output.WriteString(Attach);
			}
			if (HasPageId)
			{
				output.WriteRawTag(58);
				output.WriteString(PageId);
			}
			if (c9o != null)
			{
				c9o.WriteTo(ref output);
			}
		}

		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			int num = 0;
			if (HasToken)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(Token);
			}
			if (HasLiveStreamId)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(LiveStreamId);
			}
			if (HasReconnectCount)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(ReconnectCount);
			}
			if (HasLastErrorCode)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(LastErrorCode);
			}
			if (HasExpTag)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(ExpTag);
			}
			if (HasAttach)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(Attach);
			}
			if (HasPageId)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(PageId);
			}
			if (c9o != null)
			{
				num += c9o.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(CSWebEnterRoom other)
		{
			if (other != null)
			{
				if (other.HasToken)
				{
					Token = other.Token;
				}
				if (other.HasLiveStreamId)
				{
					LiveStreamId = other.LiveStreamId;
				}
				if (other.HasReconnectCount)
				{
					ReconnectCount = other.ReconnectCount;
				}
				if (other.HasLastErrorCode)
				{
					LastErrorCode = other.LastErrorCode;
				}
				if (other.HasExpTag)
				{
					ExpTag = other.ExpTag;
				}
				if (other.HasAttach)
				{
					Attach = other.Attach;
				}
				if (other.HasPageId)
				{
					PageId = other.PageId;
				}
				c9o = UnknownFieldSet.MergeFrom(c9o, other.c9o);
			}
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
				case 58u:
					PageId = input.ReadString();
					break;
				case 50u:
					Attach = input.ReadString();
					break;
				case 42u:
					ExpTag = input.ReadString();
					break;
				case 32u:
					LastErrorCode = input.ReadUInt32();
					break;
				default:
					c9o = UnknownFieldSet.MergeFieldFrom(c9o, ref input);
					break;
				case 24u:
					ReconnectCount = input.ReadUInt32();
					break;
				case 18u:
					LiveStreamId = input.ReadString();
					break;
				case 10u:
					Token = input.ReadString();
					break;
				}
			}
		}

		static CSWebEnterRoom()
		{
			R9a = new MessageParser<CSWebEnterRoom>(() => new CSWebEnterRoom());
			v9Z = "";
			m9z = "";
			z2W = 0u;
			C2j = 0u;
			e2q = "";
			r22 = "";
			J2P = "";
		}
	}
}
