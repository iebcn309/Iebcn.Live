using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class WebShareFeed : IMessage<WebShareFeed>, IMessage, IEquatable<WebShareFeed>, IDeepCloneable<WebShareFeed>, IBufferMessage
	{
		private static readonly MessageParser<WebShareFeed> VPP;

		private UnknownFieldSet TP6;

		private int mP8;

		public const int IdFieldNumber = 1;

		private static readonly string RPJ;

		private string dPD;

		public const int UserFieldNumber = 2;

		private SimpleUserInfo RPE;

		public const int TimeFieldNumber = 3;

		private static readonly ulong WPI;

		private ulong YPf;

		public const int ThirdPartyPlatformFieldNumber = 4;

		private static readonly uint jPH;

		private uint HPN;

		public const int SortRankFieldNumber = 5;

		private static readonly ulong QP7;

		private ulong FPt;

		public const int LiveAssistantTypeFieldNumber = 6;

		private static readonly WebLiveAssistantType SPr;

		private WebLiveAssistantType OPU;

		public const int DeviceHashFieldNumber = 7;

		private static readonly string GP1;

		private string cPi;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageParser<WebShareFeed> Parser => VPP;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[10];

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string Id
		{
			get
			{
				return dPD ?? RPJ;
			}
			set
			{
				dPD = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasId => dPD != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public SimpleUserInfo User
		{
			get
			{
				return RPE;
			}
			set
			{
				RPE = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong Time
		{
			get
			{
				if (((uint)mP8 & (true ? 1u : 0u)) != 0)
				{
					return YPf;
				}
				return WPI;
			}
			set
			{
				mP8 |= 1;
				YPf = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasTime => (mP8 & 1) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public uint ThirdPartyPlatform
		{
			get
			{
				if ((mP8 & 2) == 0)
				{
					return jPH;
				}
				return HPN;
			}
			set
			{
				mP8 |= 2;
				HPN = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasThirdPartyPlatform => (mP8 & 2) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong SortRank
		{
			get
			{
				if (((uint)mP8 & 4u) != 0)
				{
					return FPt;
				}
				return QP7;
			}
			set
			{
				mP8 |= 4;
				FPt = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasSortRank => (mP8 & 4) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public WebLiveAssistantType LiveAssistantType
		{
			get
			{
				if (((uint)mP8 & 8u) != 0)
				{
					return OPU;
				}
				return SPr;
			}
			set
			{
				mP8 |= 8;
				OPU = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasLiveAssistantType => (mP8 & 8) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string DeviceHash
		{
			get
			{
				return cPi ?? GP1;
			}
			set
			{
				cPi = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDeviceHash => cPi != null;

		[GeneratedCode("protoc", null)]
		public WebShareFeed()
		{
		}

		[GeneratedCode("protoc", null)]
		public WebShareFeed(WebShareFeed other)
			: this()
		{
			mP8 = other.mP8;
			dPD = other.dPD;
			RPE = ((other.RPE == null) ? null : other.RPE.Clone());
			YPf = other.YPf;
			HPN = other.HPN;
			FPt = other.FPt;
			OPU = other.OPU;
			cPi = other.cPi;
			TP6 = UnknownFieldSet.Clone(other.TP6);
		}

		[GeneratedCode("protoc", null)]
		public WebShareFeed Clone()
		{
			return new WebShareFeed(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearId()
		{
			dPD = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearTime()
		{
			mP8 &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearThirdPartyPlatform()
		{
			mP8 &= -3;
		}

		[GeneratedCode("protoc", null)]
		public void ClearSortRank()
		{
			mP8 &= -5;
		}

		[GeneratedCode("protoc", null)]
		public void ClearLiveAssistantType()
		{
			mP8 &= -9;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDeviceHash()
		{
			cPi = null;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as WebShareFeed);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(WebShareFeed other)
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
				if (!object.Equals(User, other.User))
				{
					return false;
				}
				if (Time != other.Time)
				{
					return false;
				}
				if (ThirdPartyPlatform != other.ThirdPartyPlatform)
				{
					return false;
				}
				if (SortRank != other.SortRank)
				{
					return false;
				}
				if (LiveAssistantType != other.LiveAssistantType)
				{
					return false;
				}
				if (DeviceHash != other.DeviceHash)
				{
					return false;
				}
				return object.Equals(TP6, other.TP6);
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
			if (RPE != null)
			{
				num ^= User.GetHashCode();
			}
			if (HasTime)
			{
				num ^= Time.GetHashCode();
			}
			if (HasThirdPartyPlatform)
			{
				num ^= ThirdPartyPlatform.GetHashCode();
			}
			if (HasSortRank)
			{
				num ^= SortRank.GetHashCode();
			}
			if (HasLiveAssistantType)
			{
				num ^= LiveAssistantType.GetHashCode();
			}
			if (HasDeviceHash)
			{
				num ^= DeviceHash.GetHashCode();
			}
			if (TP6 != null)
			{
				num ^= TP6.GetHashCode();
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
			if (RPE != null)
			{
				output.WriteRawTag(18);
				output.WriteMessage(User);
			}
			if (HasTime)
			{
				output.WriteRawTag(24);
				output.WriteUInt64(Time);
			}
			if (HasThirdPartyPlatform)
			{
				output.WriteRawTag(32);
				output.WriteUInt32(ThirdPartyPlatform);
			}
			if (HasSortRank)
			{
				output.WriteRawTag(40);
				output.WriteUInt64(SortRank);
			}
			if (HasLiveAssistantType)
			{
				output.WriteRawTag(48);
				output.WriteEnum((int)LiveAssistantType);
			}
			if (HasDeviceHash)
			{
				output.WriteRawTag(58);
				output.WriteString(DeviceHash);
			}
			if (TP6 != null)
			{
				TP6.WriteTo(ref output);
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
			if (RPE != null)
			{
				num += 1 + CodedOutputStream.ComputeMessageSize(User);
			}
			if (HasTime)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(Time);
			}
			if (HasThirdPartyPlatform)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(ThirdPartyPlatform);
			}
			if (HasSortRank)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(SortRank);
			}
			if (HasLiveAssistantType)
			{
				num += 1 + CodedOutputStream.ComputeEnumSize((int)LiveAssistantType);
			}
			if (HasDeviceHash)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(DeviceHash);
			}
			if (TP6 != null)
			{
				num += TP6.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(WebShareFeed other)
		{
			if (other == null)
			{
				return;
			}
			if (other.HasId)
			{
				Id = other.Id;
			}
			if (other.RPE != null)
			{
				if (RPE == null)
				{
					User = new SimpleUserInfo();
				}
				User.MergeFrom(other.User);
			}
			if (other.HasTime)
			{
				Time = other.Time;
			}
			if (other.HasThirdPartyPlatform)
			{
				ThirdPartyPlatform = other.ThirdPartyPlatform;
			}
			if (other.HasSortRank)
			{
				SortRank = other.SortRank;
			}
			if (other.HasLiveAssistantType)
			{
				LiveAssistantType = other.LiveAssistantType;
			}
			if (other.HasDeviceHash)
			{
				DeviceHash = other.DeviceHash;
			}
			TP6 = UnknownFieldSet.MergeFrom(TP6, other.TP6);
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
					if (RPE == null)
					{
						User = new SimpleUserInfo();
					}
					input.ReadMessage(User);
					break;
				case 10u:
					Id = input.ReadString();
					break;
				case 40u:
					SortRank = input.ReadUInt64();
					break;
				case 32u:
					ThirdPartyPlatform = input.ReadUInt32();
					break;
				default:
					TP6 = UnknownFieldSet.MergeFieldFrom(TP6, ref input);
					break;
				case 58u:
					DeviceHash = input.ReadString();
					break;
				case 48u:
					LiveAssistantType = (WebLiveAssistantType)input.ReadEnum();
					break;
				}
			}
		}

		static WebShareFeed()
		{
			VPP = new MessageParser<WebShareFeed>(() => new WebShareFeed());
			RPJ = "";
			WPI = 0uL;
			jPH = 0u;
			QP7 = 0uL;
			SPr = WebLiveAssistantType.UnknownAssistantType;
			GP1 = "";
		}
	}
}
