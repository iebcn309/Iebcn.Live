using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class WebComboCommentFeed : IMessage<WebComboCommentFeed>, IMessage, IEquatable<WebComboCommentFeed>, IDeepCloneable<WebComboCommentFeed>, IBufferMessage
	{
		private static readonly MessageParser<WebComboCommentFeed> NA3;

		private UnknownFieldSet kAW;

		private int DAL;

		public const int IdFieldNumber = 1;

		private static readonly string iAj;

		private string IAF;

		public const int ContentFieldNumber = 2;

		private static readonly string oAq;

		private string PA9;

		public const int ComboCountFieldNumber = 3;

		private static readonly uint sA2;

		private uint YAA;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<WebComboCommentFeed> Parser => NA3;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[6];

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Id
		{
			get
			{
				return IAF ?? iAj;
			}
			set
			{
				IAF = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasId => IAF != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string Content
		{
			get
			{
				return PA9 ?? oAq;
			}
			set
			{
				PA9 = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasContent => PA9 != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public uint ComboCount
		{
			get
			{
				if (((uint)DAL & (true ? 1u : 0u)) != 0)
				{
					return YAA;
				}
				return sA2;
			}
			set
			{
				DAL |= 1;
				YAA = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasComboCount => (DAL & 1) != 0;

		[GeneratedCode("protoc", null)]
		public WebComboCommentFeed()
		{
		}

		[GeneratedCode("protoc", null)]
		public WebComboCommentFeed(WebComboCommentFeed other)
			: this()
		{
			DAL = other.DAL;
			IAF = other.IAF;
			PA9 = other.PA9;
			YAA = other.YAA;
			kAW = UnknownFieldSet.Clone(other.kAW);
		}

		[GeneratedCode("protoc", null)]
		public WebComboCommentFeed Clone()
		{
			return new WebComboCommentFeed(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearId()
		{
			IAF = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearContent()
		{
			PA9 = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearComboCount()
		{
			DAL &= -2;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as WebComboCommentFeed);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(WebComboCommentFeed other)
		{
			if (other == null)
			{
				return false;
			}
			if (other == this)
			{
				return true;
			}
			if (!(Id != other.Id))
			{
				if (!(Content != other.Content))
				{
					if (ComboCount != other.ComboCount)
					{
						return false;
					}
					return object.Equals(kAW, other.kAW);
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
			if (HasContent)
			{
				num ^= Content.GetHashCode();
			}
			if (HasComboCount)
			{
				num ^= ComboCount.GetHashCode();
			}
			if (kAW != null)
			{
				num ^= kAW.GetHashCode();
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
			if (HasContent)
			{
				output.WriteRawTag(18);
				output.WriteString(Content);
			}
			if (HasComboCount)
			{
				output.WriteRawTag(24);
				output.WriteUInt32(ComboCount);
			}
			if (kAW != null)
			{
				kAW.WriteTo(ref output);
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
			if (HasContent)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(Content);
			}
			if (HasComboCount)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(ComboCount);
			}
			if (kAW != null)
			{
				num += kAW.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(WebComboCommentFeed other)
		{
			if (other != null)
			{
				if (other.HasId)
				{
					Id = other.Id;
				}
				if (other.HasContent)
				{
					Content = other.Content;
				}
				if (other.HasComboCount)
				{
					ComboCount = other.ComboCount;
				}
				kAW = UnknownFieldSet.MergeFrom(kAW, other.kAW);
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
				default:
					kAW = UnknownFieldSet.MergeFieldFrom(kAW, ref input);
					break;
				case 24u:
					ComboCount = input.ReadUInt32();
					break;
				case 18u:
					Content = input.ReadString();
					break;
				case 10u:
					Id = input.ReadString();
					break;
				}
			}
		}

		static WebComboCommentFeed()
		{
			NA3 = new MessageParser<WebComboCommentFeed>(() => new WebComboCommentFeed());
			iAj = "";
			oAq = "";
			sA2 = 0u;
		}
	}
}
