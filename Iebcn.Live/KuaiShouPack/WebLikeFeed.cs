using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class WebLikeFeed : IMessage<WebLikeFeed>, IMessage, IEquatable<WebLikeFeed>, IDeepCloneable<WebLikeFeed>, IBufferMessage
	{
		private static readonly MessageParser<WebLikeFeed> hAP;

		private UnknownFieldSet vA6;

		private int AA8;

		public const int IdFieldNumber = 1;

		private static readonly string TAJ;

		private string vAD;

		public const int UserFieldNumber = 2;

		private SimpleUserInfo MAE;

		public const int SortRankFieldNumber = 3;

		private static readonly ulong GAI;

		private ulong NAf;

		public const int DeviceHashFieldNumber = 4;

		private static readonly string nAH;

		private string nAN;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<WebLikeFeed> Parser => hAP;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[7];

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string Id
		{
			get
			{
				return vAD ?? TAJ;
			}
			set
			{
				vAD = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasId => vAD != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public SimpleUserInfo User
		{
			get
			{
				return MAE;
			}
			set
			{
				MAE = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong SortRank
		{
			get
			{
				if ((AA8 & 1) == 0)
				{
					return GAI;
				}
				return NAf;
			}
			set
			{
				AA8 |= 1;
				NAf = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasSortRank => (AA8 & 1) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string DeviceHash
		{
			get
			{
				return nAN ?? nAH;
			}
			set
			{
				nAN = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasDeviceHash => nAN != null;

		[GeneratedCode("protoc", null)]
		public WebLikeFeed()
		{
		}

		[GeneratedCode("protoc", null)]
		public WebLikeFeed(WebLikeFeed other)
			: this()
		{
			AA8 = other.AA8;
			vAD = other.vAD;
			MAE = ((other.MAE == null) ? null : other.MAE.Clone());
			NAf = other.NAf;
			nAN = other.nAN;
			vA6 = UnknownFieldSet.Clone(other.vA6);
		}

		[GeneratedCode("protoc", null)]
		public WebLikeFeed Clone()
		{
			return new WebLikeFeed(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearId()
		{
			vAD = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearSortRank()
		{
			AA8 &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDeviceHash()
		{
			nAN = null;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as WebLikeFeed);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(WebLikeFeed other)
		{
			if (other != null)
			{
				if (other == this)
				{
					return true;
				}
				if (!(Id != other.Id))
				{
					if (object.Equals(User, other.User))
					{
						if (SortRank != other.SortRank)
						{
							return false;
						}
						if (DeviceHash != other.DeviceHash)
						{
							return false;
						}
						return object.Equals(vA6, other.vA6);
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
			if (HasId)
			{
				num ^= Id.GetHashCode();
			}
			if (MAE != null)
			{
				num ^= User.GetHashCode();
			}
			if (HasSortRank)
			{
				num ^= SortRank.GetHashCode();
			}
			if (HasDeviceHash)
			{
				num ^= DeviceHash.GetHashCode();
			}
			if (vA6 != null)
			{
				num ^= vA6.GetHashCode();
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
			if (MAE != null)
			{
				output.WriteRawTag(18);
				output.WriteMessage(User);
			}
			if (HasSortRank)
			{
				output.WriteRawTag(24);
				output.WriteUInt64(SortRank);
			}
			if (HasDeviceHash)
			{
				output.WriteRawTag(34);
				output.WriteString(DeviceHash);
			}
			if (vA6 != null)
			{
				vA6.WriteTo(ref output);
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
			if (MAE != null)
			{
				num += 1 + CodedOutputStream.ComputeMessageSize(User);
			}
			if (HasSortRank)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(SortRank);
			}
			if (HasDeviceHash)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(DeviceHash);
			}
			if (vA6 != null)
			{
				num += vA6.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(WebLikeFeed other)
		{
			if (other == null)
			{
				return;
			}
			if (other.HasId)
			{
				Id = other.Id;
			}
			if (other.MAE != null)
			{
				if (MAE == null)
				{
					User = new SimpleUserInfo();
				}
				User.MergeFrom(other.User);
			}
			if (other.HasSortRank)
			{
				SortRank = other.SortRank;
			}
			if (other.HasDeviceHash)
			{
				DeviceHash = other.DeviceHash;
			}
			vA6 = UnknownFieldSet.MergeFrom(vA6, other.vA6);
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
				case 18u:
					if (MAE == null)
					{
						User = new SimpleUserInfo();
					}
					input.ReadMessage(User);
					break;
				case 10u:
					Id = input.ReadString();
					break;
				default:
					vA6 = UnknownFieldSet.MergeFieldFrom(vA6, ref input);
					break;
				case 34u:
					DeviceHash = input.ReadString();
					break;
				case 24u:
					SortRank = input.ReadUInt64();
					break;
				}
			}
		}

		static WebLikeFeed()
		{
			hAP = new MessageParser<WebLikeFeed>(() => new WebLikeFeed());
			TAJ = "";
			GAI = 0uL;
			nAH = "";
		}
	}
}
