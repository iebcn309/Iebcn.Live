using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class SimpleUserInfo : IMessage<SimpleUserInfo>, IMessage, IEquatable<SimpleUserInfo>, IDeepCloneable<SimpleUserInfo>, IBufferMessage
	{
		private static readonly MessageParser<SimpleUserInfo> i2c;

		private UnknownFieldSet f2b;

		public const int PrincipalIdFieldNumber = 1;

		private static readonly string G2a;

		private string K2o;

		public const int UserNameFieldNumber = 2;

		private static readonly string D2V;

		private string J2Z;

		public const int HeadUrlFieldNumber = 3;

		private static readonly string c2h;

		private string l2z;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageParser<SimpleUserInfo> Parser => i2c;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[5];

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string PrincipalId
		{
			get
			{
				return K2o ?? G2a;
			}
			set
			{
				K2o = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPrincipalId => K2o != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string UserName
		{
			get
			{
				return J2Z ?? D2V;
			}
			set
			{
				J2Z = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasUserName => J2Z != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string HeadUrl
		{
			get
			{
				return l2z ?? c2h;
			}
			set
			{
				l2z = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasHeadUrl => l2z != null;

		[GeneratedCode("protoc", null)]
		public SimpleUserInfo()
		{
		}

		[GeneratedCode("protoc", null)]
		public SimpleUserInfo(SimpleUserInfo other)
			: this()
		{
			K2o = other.K2o;
			J2Z = other.J2Z;
			l2z = other.l2z;
			f2b = UnknownFieldSet.Clone(other.f2b);
		}

		[GeneratedCode("protoc", null)]
		public SimpleUserInfo Clone()
		{
			return new SimpleUserInfo(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearPrincipalId()
		{
			K2o = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearUserName()
		{
			J2Z = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearHeadUrl()
		{
			l2z = null;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as SimpleUserInfo);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(SimpleUserInfo other)
		{
			if (other == null)
			{
				return false;
			}
			if (other == this)
			{
				return true;
			}
			if (!(PrincipalId != other.PrincipalId))
			{
				if (UserName != other.UserName)
				{
					return false;
				}
				if (!(HeadUrl != other.HeadUrl))
				{
					return object.Equals(f2b, other.f2b);
				}
				return false;
			}
			return false;
		}

		[GeneratedCode("protoc", null)]
		public override int GetHashCode()
		{
			int num = 1;
			if (HasPrincipalId)
			{
				num ^= PrincipalId.GetHashCode();
			}
			if (HasUserName)
			{
				num ^= UserName.GetHashCode();
			}
			if (HasHeadUrl)
			{
				num ^= HeadUrl.GetHashCode();
			}
			if (f2b != null)
			{
				num ^= f2b.GetHashCode();
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
			if (HasPrincipalId)
			{
				output.WriteRawTag(10);
				output.WriteString(PrincipalId);
			}
			if (HasUserName)
			{
				output.WriteRawTag(18);
				output.WriteString(UserName);
			}
			if (HasHeadUrl)
			{
				output.WriteRawTag(26);
				output.WriteString(HeadUrl);
			}
			if (f2b != null)
			{
				f2b.WriteTo(ref output);
			}
		}

		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			int num = 0;
			if (HasPrincipalId)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(PrincipalId);
			}
			if (HasUserName)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(UserName);
			}
			if (HasHeadUrl)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(HeadUrl);
			}
			if (f2b != null)
			{
				num += f2b.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(SimpleUserInfo other)
		{
			if (other != null)
			{
				if (other.HasPrincipalId)
				{
					PrincipalId = other.PrincipalId;
				}
				if (other.HasUserName)
				{
					UserName = other.UserName;
				}
				if (other.HasHeadUrl)
				{
					HeadUrl = other.HeadUrl;
				}
				f2b = UnknownFieldSet.MergeFrom(f2b, other.f2b);
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
					f2b = UnknownFieldSet.MergeFieldFrom(f2b, ref input);
					break;
				case 26u:
					HeadUrl = input.ReadString();
					break;
				case 18u:
					UserName = input.ReadString();
					break;
				case 10u:
					PrincipalId = input.ReadString();
					break;
				}
			}
		}

		static SimpleUserInfo()
		{
			i2c = new MessageParser<SimpleUserInfo>(() => new SimpleUserInfo());
			G2a = "";
			D2V = "";
			c2h = "";
		}
	}
}
