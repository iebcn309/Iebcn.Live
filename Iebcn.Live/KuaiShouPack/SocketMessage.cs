using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class SocketMessage : IMessage<SocketMessage>, IMessage, IEquatable<SocketMessage>, IDeepCloneable<SocketMessage>, IBufferMessage
	{
		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static class Types
		{
			public enum CompressionType
			{
				[OriginalName("UNKNOWN")]
				Unknown,
				[OriginalName("NONE")]
				None,
				[OriginalName("GZIP")]
				Gzip,
				[OriginalName("AES")]
				Aes
			}
		}

		private static readonly MessageParser<SocketMessage> h95;

		private UnknownFieldSet o94;

		private int Y9Q;

		public const int PayloadTypeFieldNumber = 1;

		private static readonly PayloadType x9X;

		private PayloadType o9w;

		public const int CompressionTypeFieldNumber = 2;

		private static readonly Types.CompressionType O9g;

		private Types.CompressionType s9u;

		public const int PayloadFieldNumber = 3;

		private static readonly ByteString S9c;

		private ByteString Y9b;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<SocketMessage> Parser => h95;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[1];

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public PayloadType PayloadType
		{
			get
			{
				if (((uint)Y9Q & (true ? 1u : 0u)) != 0)
				{
					return o9w;
				}
				return x9X;
			}
			set
			{
				Y9Q |= 1;
				o9w = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasPayloadType => (Y9Q & 1) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public Types.CompressionType CompressionType
		{
			get
			{
				if (((uint)Y9Q & 2u) != 0)
				{
					return s9u;
				}
				return O9g;
			}
			set
			{
				Y9Q |= 2;
				s9u = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasCompressionType => (Y9Q & 2) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ByteString Payload
		{
			get
			{
				return Y9b ?? S9c;
			}
			set
			{
				Y9b = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasPayload => Y9b != null;

		[GeneratedCode("protoc", null)]
		public SocketMessage()
		{
		}

		[GeneratedCode("protoc", null)]
		public SocketMessage(SocketMessage other)
			: this()
		{
			Y9Q = other.Y9Q;
			o9w = other.o9w;
			s9u = other.s9u;
			Y9b = other.Y9b;
			o94 = UnknownFieldSet.Clone(other.o94);
		}

		[GeneratedCode("protoc", null)]
		public SocketMessage Clone()
		{
			return new SocketMessage(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearPayloadType()
		{
			Y9Q &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearCompressionType()
		{
			Y9Q &= -3;
		}

		[GeneratedCode("protoc", null)]
		public void ClearPayload()
		{
			Y9b = null;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as SocketMessage);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(SocketMessage other)
		{
			if (other != null)
			{
				if (other == this)
				{
					return true;
				}
				if (PayloadType != other.PayloadType)
				{
					return false;
				}
				if (CompressionType != other.CompressionType)
				{
					return false;
				}
				if (!(Payload != other.Payload))
				{
					return object.Equals(o94, other.o94);
				}
				return false;
			}
			return false;
		}

		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			int num = 1;
			if (HasPayloadType)
			{
				num ^= PayloadType.GetHashCode();
			}
			if (HasCompressionType)
			{
				num ^= CompressionType.GetHashCode();
			}
			if (HasPayload)
			{
				num ^= Payload.GetHashCode();
			}
			if (o94 != null)
			{
				num ^= o94.GetHashCode();
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
			if (HasPayloadType)
			{
				output.WriteRawTag(8);
				output.WriteEnum((int)PayloadType);
			}
			if (HasCompressionType)
			{
				output.WriteRawTag(16);
				output.WriteEnum((int)CompressionType);
			}
			if (HasPayload)
			{
				output.WriteRawTag(26);
				output.WriteBytes(Payload);
			}
			if (o94 != null)
			{
				o94.WriteTo(ref output);
			}
		}

		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			int num = 0;
			if (HasPayloadType)
			{
				num += 1 + CodedOutputStream.ComputeEnumSize((int)PayloadType);
			}
			if (HasCompressionType)
			{
				num += 1 + CodedOutputStream.ComputeEnumSize((int)CompressionType);
			}
			if (HasPayload)
			{
				num += 1 + CodedOutputStream.ComputeBytesSize(Payload);
			}
			if (o94 != null)
			{
				num += o94.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(SocketMessage other)
		{
			if (other != null)
			{
				if (other.HasPayloadType)
				{
					PayloadType = other.PayloadType;
				}
				if (other.HasCompressionType)
				{
					CompressionType = other.CompressionType;
				}
				if (other.HasPayload)
				{
					Payload = other.Payload;
				}
				o94 = UnknownFieldSet.MergeFrom(o94, other.o94);
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
					o94 = UnknownFieldSet.MergeFieldFrom(o94, ref input);
					break;
				case 26u:
					Payload = input.ReadBytes();
					break;
				case 16u:
					CompressionType = (Types.CompressionType)input.ReadEnum();
					break;
				case 8u:
					PayloadType = (PayloadType)input.ReadEnum();
					break;
				}
			}
		}

		static SocketMessage()
		{
			h95 = new MessageParser<SocketMessage>(() => new SocketMessage());
			x9X = PayloadType.Unknown;
			O9g = Types.CompressionType.Unknown;
			S9c = ByteString.Empty;
		}
	}
}
