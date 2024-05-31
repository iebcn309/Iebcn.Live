using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class CSWebHeartbeat : IMessage<CSWebHeartbeat>, IMessage, IEquatable<CSWebHeartbeat>, IDeepCloneable<CSWebHeartbeat>, IBufferMessage
	{
		private static readonly MessageParser<CSWebHeartbeat> y9O;

		private UnknownFieldSet X9l;

		private int x9k;

		public const int TimestampFieldNumber = 1;

		private static readonly ulong c90;

		private ulong E9Y;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<CSWebHeartbeat> Parser => y9O;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[0];

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong Timestamp
		{
			get
			{
				if (((uint)x9k & (true ? 1u : 0u)) != 0)
				{
					return E9Y;
				}
				return c90;
			}
			set
			{
				x9k |= 1;
				E9Y = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasTimestamp => (x9k & 1) != 0;

		[GeneratedCode("protoc", null)]
		public CSWebHeartbeat()
		{
		}

		[GeneratedCode("protoc", null)]
		public CSWebHeartbeat(CSWebHeartbeat other)
			: this()
		{
			x9k = other.x9k;
			E9Y = other.E9Y;
			X9l = UnknownFieldSet.Clone(other.X9l);
		}

		[GeneratedCode("protoc", null)]
		public CSWebHeartbeat Clone()
		{
			return new CSWebHeartbeat(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearTimestamp()
		{
			x9k &= -2;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as CSWebHeartbeat);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(CSWebHeartbeat other)
		{
			if (other == null)
			{
				return false;
			}
			if (other == this)
			{
				return true;
			}
			if (Timestamp != other.Timestamp)
			{
				return false;
			}
			return object.Equals(X9l, other.X9l);
		}

		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			int num = 1;
			if (HasTimestamp)
			{
				num ^= Timestamp.GetHashCode();
			}
			if (X9l != null)
			{
				num ^= X9l.GetHashCode();
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
			if (HasTimestamp)
			{
				output.WriteRawTag(8);
				output.WriteUInt64(Timestamp);
			}
			if (X9l != null)
			{
				X9l.WriteTo(ref output);
			}
		}

		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			int num = 0;
			if (HasTimestamp)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(Timestamp);
			}
			if (X9l != null)
			{
				num += X9l.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(CSWebHeartbeat other)
		{
			if (other != null)
			{
				if (other.HasTimestamp)
				{
					Timestamp = other.Timestamp;
				}
				X9l = UnknownFieldSet.MergeFrom(X9l, other.X9l);
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
				if (num != 8)
				{
					X9l = UnknownFieldSet.MergeFieldFrom(X9l, ref input);
				}
				else
				{
					Timestamp = input.ReadUInt64();
				}
			}
		}

		static CSWebHeartbeat()
		{
			y9O = new MessageParser<CSWebHeartbeat>(() => new CSWebHeartbeat());
			c90 = 0uL;
		}
	}
}
