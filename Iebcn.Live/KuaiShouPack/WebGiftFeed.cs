using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class WebGiftFeed : IMessage<WebGiftFeed>, IMessage, IEquatable<WebGiftFeed>, IDeepCloneable<WebGiftFeed>, IBufferMessage
	{
		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static class Types
		{
			public enum StyleType
			{
				[OriginalName("UNKNOWN_STYLE")]
				UnknownStyle,
				[OriginalName("BATCH_STAR_0")]
				BatchStar0,
				[OriginalName("BATCH_STAR_1")]
				BatchStar1,
				[OriginalName("BATCH_STAR_2")]
				BatchStar2,
				[OriginalName("BATCH_STAR_3")]
				BatchStar3,
				[OriginalName("BATCH_STAR_4")]
				BatchStar4,
				[OriginalName("BATCH_STAR_5")]
				BatchStar5,
				[OriginalName("BATCH_STAR_6")]
				BatchStar6
			}
		}

		private static readonly MessageParser<WebGiftFeed> yA7;

		private UnknownFieldSet qAt;

		private int kAr;

		public const int IdFieldNumber = 1;

		private static readonly string TAU;

		private string oA1;

		public const int UserFieldNumber = 2;

		private SimpleUserInfo WAi;

		public const int TimeFieldNumber = 3;

		private static readonly ulong lAn;

		private ulong uAM;

		public const int GiftIdFieldNumber = 4;

		private static readonly uint JAy;

		private uint nAG;

		public const int SortRankFieldNumber = 5;

		private static readonly ulong tAv;

		private ulong WAe;

		public const int MergeKeyFieldNumber = 6;

		private static readonly string HAs;

		private string EAC;

		public const int BatchSizeFieldNumber = 7;

		private static readonly uint qAm;

		private uint tAB;

		public const int ComboCountFieldNumber = 8;

		private static readonly uint XAT;

		private uint oAK;

		public const int RankFieldNumber = 9;

		private static readonly uint nAd;

		private uint xAS;

		public const int ExpireDurationFieldNumber = 10;

		private static readonly ulong uAx;

		private ulong dAp;

		public const int ClientTimestampFieldNumber = 11;

		private static readonly ulong aAR;

		private ulong WAO;

		public const int SlotDisplayDurationFieldNumber = 12;

		private static readonly ulong QAl;

		private ulong VAk;

		public const int StarLevelFieldNumber = 13;

		private static readonly uint KA0;

		private uint IAY;

		public const int StyleTypeFieldNumber = 14;

		private static readonly Types.StyleType oA5;

		private Types.StyleType VA4;

		public const int LiveAssistantTypeFieldNumber = 15;

		private static readonly WebLiveAssistantType tAQ;

		private WebLiveAssistantType AAX;

		public const int DeviceHashFieldNumber = 16;

		private static readonly string KAw;

		private string eAg;

		public const int DanmakuDisplayFieldNumber = 17;

		private static readonly bool IAu;

		private bool cAc;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<WebGiftFeed> Parser => yA7;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[8];

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string Id
		{
			get
			{
				return oA1 ?? TAU;
			}
			set
			{
				oA1 = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasId => oA1 != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public SimpleUserInfo User
		{
			get
			{
				return WAi;
			}
			set
			{
				WAi = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong Time
		{
			get
			{
				if ((kAr & 1) == 0)
				{
					return lAn;
				}
				return uAM;
			}
			set
			{
				kAr |= 1;
				uAM = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasTime => (kAr & 1) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public uint GiftId
		{
			get
			{
				if ((kAr & 2) == 0)
				{
					return JAy;
				}
				return nAG;
			}
			set
			{
				kAr |= 2;
				nAG = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasGiftId => (kAr & 2) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong SortRank
		{
			get
			{
				if (((uint)kAr & 4u) != 0)
				{
					return WAe;
				}
				return tAv;
			}
			set
			{
				kAr |= 4;
				WAe = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasSortRank => (kAr & 4) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string MergeKey
		{
			get
			{
				return EAC ?? HAs;
			}
			set
			{
				EAC = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasMergeKey => EAC != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public uint BatchSize
		{
			get
			{
				if (((uint)kAr & 8u) != 0)
				{
					return tAB;
				}
				return qAm;
			}
			set
			{
				kAr |= 8;
				tAB = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasBatchSize => (kAr & 8) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public uint ComboCount
		{
			get
			{
				if ((kAr & 0x10) == 0)
				{
					return XAT;
				}
				return oAK;
			}
			set
			{
				kAr |= 16;
				oAK = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasComboCount => (kAr & 0x10) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public uint Rank
		{
			get
			{
				if ((kAr & 0x20) == 0)
				{
					return nAd;
				}
				return xAS;
			}
			set
			{
				kAr |= 32;
				xAS = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasRank => (kAr & 0x20) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ulong ExpireDuration
		{
			get
			{
				if (((uint)kAr & 0x40u) != 0)
				{
					return dAp;
				}
				return uAx;
			}
			set
			{
				kAr |= 64;
				dAp = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasExpireDuration => (kAr & 0x40) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong ClientTimestamp
		{
			get
			{
				if (((uint)kAr & 0x80u) != 0)
				{
					return WAO;
				}
				return aAR;
			}
			set
			{
				kAr |= 128;
				WAO = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasClientTimestamp => (kAr & 0x80) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ulong SlotDisplayDuration
		{
			get
			{
				if ((kAr & 0x100) == 0)
				{
					return QAl;
				}
				return VAk;
			}
			set
			{
				kAr |= 256;
				VAk = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasSlotDisplayDuration => (kAr & 0x100) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public uint StarLevel
		{
			get
			{
				if (((uint)kAr & 0x200u) != 0)
				{
					return IAY;
				}
				return KA0;
			}
			set
			{
				kAr |= 512;
				IAY = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasStarLevel => (kAr & 0x200) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public Types.StyleType StyleType
		{
			get
			{
				if (((uint)kAr & 0x400u) != 0)
				{
					return VA4;
				}
				return oA5;
			}
			set
			{
				kAr |= 1024;
				VA4 = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasStyleType => (kAr & 0x400) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public WebLiveAssistantType LiveAssistantType
		{
			get
			{
				if ((kAr & 0x800) == 0)
				{
					return tAQ;
				}
				return AAX;
			}
			set
			{
				kAr |= 2048;
				AAX = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasLiveAssistantType => (kAr & 0x800) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string DeviceHash
		{
			get
			{
				return eAg ?? KAw;
			}
			set
			{
				eAg = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasDeviceHash => eAg != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool DanmakuDisplay
		{
			get
			{
				if ((kAr & 0x1000) == 0)
				{
					return IAu;
				}
				return cAc;
			}
			set
			{
				kAr |= 4096;
				cAc = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasDanmakuDisplay => (kAr & 0x1000) != 0;

		[GeneratedCode("protoc", null)]
		public WebGiftFeed()
		{
		}

		[GeneratedCode("protoc", null)]
		public WebGiftFeed(WebGiftFeed other)
			: this()
		{
			kAr = other.kAr;
			oA1 = other.oA1;
			WAi = ((other.WAi == null) ? null : other.WAi.Clone());
			uAM = other.uAM;
			nAG = other.nAG;
			WAe = other.WAe;
			EAC = other.EAC;
			tAB = other.tAB;
			oAK = other.oAK;
			xAS = other.xAS;
			dAp = other.dAp;
			WAO = other.WAO;
			VAk = other.VAk;
			IAY = other.IAY;
			VA4 = other.VA4;
			AAX = other.AAX;
			eAg = other.eAg;
			cAc = other.cAc;
			qAt = UnknownFieldSet.Clone(other.qAt);
		}

		[GeneratedCode("protoc", null)]
		public WebGiftFeed Clone()
		{
			return new WebGiftFeed(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearId()
		{
			oA1 = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearTime()
		{
			kAr &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearGiftId()
		{
			kAr &= -3;
		}

		[GeneratedCode("protoc", null)]
		public void ClearSortRank()
		{
			kAr &= -5;
		}

		[GeneratedCode("protoc", null)]
		public void ClearMergeKey()
		{
			EAC = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearBatchSize()
		{
			kAr &= -9;
		}

		[GeneratedCode("protoc", null)]
		public void ClearComboCount()
		{
			kAr &= -17;
		}

		[GeneratedCode("protoc", null)]
		public void ClearRank()
		{
			kAr &= -33;
		}

		[GeneratedCode("protoc", null)]
		public void ClearExpireDuration()
		{
			kAr &= -65;
		}

		[GeneratedCode("protoc", null)]
		public void ClearClientTimestamp()
		{
			kAr &= -129;
		}

		[GeneratedCode("protoc", null)]
		public void ClearSlotDisplayDuration()
		{
			kAr &= -257;
		}

		[GeneratedCode("protoc", null)]
		public void ClearStarLevel()
		{
			kAr &= -513;
		}

		[GeneratedCode("protoc", null)]
		public void ClearStyleType()
		{
			kAr &= -1025;
		}

		[GeneratedCode("protoc", null)]
		public void ClearLiveAssistantType()
		{
			kAr &= -2049;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDeviceHash()
		{
			eAg = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDanmakuDisplay()
		{
			kAr &= -4097;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as WebGiftFeed);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(WebGiftFeed other)
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
						if (Time != other.Time)
						{
							return false;
						}
						if (GiftId != other.GiftId)
						{
							return false;
						}
						if (SortRank != other.SortRank)
						{
							return false;
						}
						if (!(MergeKey != other.MergeKey))
						{
							if (BatchSize != other.BatchSize)
							{
								return false;
							}
							if (ComboCount != other.ComboCount)
							{
								return false;
							}
							if (Rank != other.Rank)
							{
								return false;
							}
							if (ExpireDuration != other.ExpireDuration)
							{
								return false;
							}
							if (ClientTimestamp != other.ClientTimestamp)
							{
								return false;
							}
							if (SlotDisplayDuration != other.SlotDisplayDuration)
							{
								return false;
							}
							if (StarLevel != other.StarLevel)
							{
								return false;
							}
							if (StyleType != other.StyleType)
							{
								return false;
							}
							if (LiveAssistantType != other.LiveAssistantType)
							{
								return false;
							}
							if (!(DeviceHash != other.DeviceHash))
							{
								if (DanmakuDisplay != other.DanmakuDisplay)
								{
									return false;
								}
								return object.Equals(qAt, other.qAt);
							}
							return false;
						}
						return false;
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
			if (WAi != null)
			{
				num ^= User.GetHashCode();
			}
			if (HasTime)
			{
				num ^= Time.GetHashCode();
			}
			if (HasGiftId)
			{
				num ^= GiftId.GetHashCode();
			}
			if (HasSortRank)
			{
				num ^= SortRank.GetHashCode();
			}
			if (HasMergeKey)
			{
				num ^= MergeKey.GetHashCode();
			}
			if (HasBatchSize)
			{
				num ^= BatchSize.GetHashCode();
			}
			if (HasComboCount)
			{
				num ^= ComboCount.GetHashCode();
			}
			if (HasRank)
			{
				num ^= Rank.GetHashCode();
			}
			if (HasExpireDuration)
			{
				num ^= ExpireDuration.GetHashCode();
			}
			if (HasClientTimestamp)
			{
				num ^= ClientTimestamp.GetHashCode();
			}
			if (HasSlotDisplayDuration)
			{
				num ^= SlotDisplayDuration.GetHashCode();
			}
			if (HasStarLevel)
			{
				num ^= StarLevel.GetHashCode();
			}
			if (HasStyleType)
			{
				num ^= StyleType.GetHashCode();
			}
			if (HasLiveAssistantType)
			{
				num ^= LiveAssistantType.GetHashCode();
			}
			if (HasDeviceHash)
			{
				num ^= DeviceHash.GetHashCode();
			}
			if (HasDanmakuDisplay)
			{
				num ^= DanmakuDisplay.GetHashCode();
			}
			if (qAt != null)
			{
				num ^= qAt.GetHashCode();
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
			if (WAi != null)
			{
				output.WriteRawTag(18);
				output.WriteMessage(User);
			}
			if (HasTime)
			{
				output.WriteRawTag(24);
				output.WriteUInt64(Time);
			}
			if (HasGiftId)
			{
				output.WriteRawTag(32);
				output.WriteUInt32(GiftId);
			}
			if (HasSortRank)
			{
				output.WriteRawTag(40);
				output.WriteUInt64(SortRank);
			}
			if (HasMergeKey)
			{
				output.WriteRawTag(50);
				output.WriteString(MergeKey);
			}
			if (HasBatchSize)
			{
				output.WriteRawTag(56);
				output.WriteUInt32(BatchSize);
			}
			if (HasComboCount)
			{
				output.WriteRawTag(64);
				output.WriteUInt32(ComboCount);
			}
			if (HasRank)
			{
				output.WriteRawTag(72);
				output.WriteUInt32(Rank);
			}
			if (HasExpireDuration)
			{
				output.WriteRawTag(80);
				output.WriteUInt64(ExpireDuration);
			}
			if (HasClientTimestamp)
			{
				output.WriteRawTag(88);
				output.WriteUInt64(ClientTimestamp);
			}
			if (HasSlotDisplayDuration)
			{
				output.WriteRawTag(96);
				output.WriteUInt64(SlotDisplayDuration);
			}
			if (HasStarLevel)
			{
				output.WriteRawTag(104);
				output.WriteUInt32(StarLevel);
			}
			if (HasStyleType)
			{
				output.WriteRawTag(112);
				output.WriteEnum((int)StyleType);
			}
			if (HasLiveAssistantType)
			{
				output.WriteRawTag(120);
				output.WriteEnum((int)LiveAssistantType);
			}
			if (HasDeviceHash)
			{
				output.WriteRawTag(130, 1);
				output.WriteString(DeviceHash);
			}
			if (HasDanmakuDisplay)
			{
				output.WriteRawTag(136, 1);
				output.WriteBool(DanmakuDisplay);
			}
			if (qAt != null)
			{
				qAt.WriteTo(ref output);
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
			if (WAi != null)
			{
				num += 1 + CodedOutputStream.ComputeMessageSize(User);
			}
			if (HasTime)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(Time);
			}
			if (HasGiftId)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(GiftId);
			}
			if (HasSortRank)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(SortRank);
			}
			if (HasMergeKey)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(MergeKey);
			}
			if (HasBatchSize)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(BatchSize);
			}
			if (HasComboCount)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(ComboCount);
			}
			if (HasRank)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(Rank);
			}
			if (HasExpireDuration)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(ExpireDuration);
			}
			if (HasClientTimestamp)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(ClientTimestamp);
			}
			if (HasSlotDisplayDuration)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(SlotDisplayDuration);
			}
			if (HasStarLevel)
			{
				num += 1 + CodedOutputStream.ComputeUInt32Size(StarLevel);
			}
			if (HasStyleType)
			{
				num += 1 + CodedOutputStream.ComputeEnumSize((int)StyleType);
			}
			if (HasLiveAssistantType)
			{
				num += 1 + CodedOutputStream.ComputeEnumSize((int)LiveAssistantType);
			}
			if (HasDeviceHash)
			{
				num += 2 + CodedOutputStream.ComputeStringSize(DeviceHash);
			}
			if (HasDanmakuDisplay)
			{
				num += 3;
			}
			if (qAt != null)
			{
				num += qAt.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(WebGiftFeed other)
		{
			if (other == null)
			{
				return;
			}
			if (other.HasId)
			{
				Id = other.Id;
			}
			if (other.WAi != null)
			{
				if (WAi == null)
				{
					User = new SimpleUserInfo();
				}
				User.MergeFrom(other.User);
			}
			if (other.HasTime)
			{
				Time = other.Time;
			}
			if (other.HasGiftId)
			{
				GiftId = other.GiftId;
			}
			if (other.HasSortRank)
			{
				SortRank = other.SortRank;
			}
			if (other.HasMergeKey)
			{
				MergeKey = other.MergeKey;
			}
			if (other.HasBatchSize)
			{
				BatchSize = other.BatchSize;
			}
			if (other.HasComboCount)
			{
				ComboCount = other.ComboCount;
			}
			if (other.HasRank)
			{
				Rank = other.Rank;
			}
			if (other.HasExpireDuration)
			{
				ExpireDuration = other.ExpireDuration;
			}
			if (other.HasClientTimestamp)
			{
				ClientTimestamp = other.ClientTimestamp;
			}
			if (other.HasSlotDisplayDuration)
			{
				SlotDisplayDuration = other.SlotDisplayDuration;
			}
			if (other.HasStarLevel)
			{
				StarLevel = other.StarLevel;
			}
			if (other.HasStyleType)
			{
				StyleType = other.StyleType;
			}
			if (other.HasLiveAssistantType)
			{
				LiveAssistantType = other.LiveAssistantType;
			}
			if (other.HasDeviceHash)
			{
				DeviceHash = other.DeviceHash;
			}
			if (other.HasDanmakuDisplay)
			{
				DanmakuDisplay = other.DanmakuDisplay;
			}
			qAt = UnknownFieldSet.MergeFrom(qAt, other.qAt);
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
					if (WAi == null)
					{
						User = new SimpleUserInfo();
					}
					input.ReadMessage(User);
					break;
				case 10u:
					Id = input.ReadString();
					break;
				case 32u:
					GiftId = input.ReadUInt32();
					break;
				case 24u:
					Time = input.ReadUInt64();
					break;
				case 64u:
					ComboCount = input.ReadUInt32();
					break;
				case 56u:
					BatchSize = input.ReadUInt32();
					break;
				case 50u:
					MergeKey = input.ReadString();
					break;
				case 40u:
					SortRank = input.ReadUInt64();
					break;
				case 96u:
					SlotDisplayDuration = input.ReadUInt64();
					break;
				case 88u:
					ClientTimestamp = input.ReadUInt64();
					break;
				case 80u:
					ExpireDuration = input.ReadUInt64();
					break;
				case 72u:
					Rank = input.ReadUInt32();
					break;
				case 112u:
					StyleType = (Types.StyleType)input.ReadEnum();
					break;
				case 104u:
					StarLevel = input.ReadUInt32();
					break;
				default:
					qAt = UnknownFieldSet.MergeFieldFrom(qAt, ref input);
					break;
				case 136u:
					DanmakuDisplay = input.ReadBool();
					break;
				case 130u:
					DeviceHash = input.ReadString();
					break;
				case 120u:
					LiveAssistantType = (WebLiveAssistantType)input.ReadEnum();
					break;
				}
			}
		}

		static WebGiftFeed()
		{
			yA7 = new MessageParser<WebGiftFeed>(() => new WebGiftFeed());
			TAU = "";
			lAn = 0uL;
			JAy = 0u;
			tAv = 0uL;
			HAs = "";
			qAm = 0u;
			XAT = 0u;
			nAd = 0u;
			uAx = 0uL;
			aAR = 0uL;
			QAl = 0uL;
			KA0 = 0u;
			oA5 = Types.StyleType.UnknownStyle;
			tAQ = WebLiveAssistantType.UnknownAssistantType;
			KAw = "";
			IAu = false;
		}
	}
}
