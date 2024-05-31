using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class WebCommentFeed : IMessage<WebCommentFeed>, IMessage, IEquatable<WebCommentFeed>, IDeepCloneable<WebCommentFeed>, IBufferMessage
	{
		private static readonly MessageParser<WebCommentFeed> V2S;

		private UnknownFieldSet O2x;

		private int p2p;

		public const int IdFieldNumber = 1;

		private static readonly string I2R;

		private string q2O;

		public const int UserFieldNumber = 2;

		private SimpleUserInfo T2l;

		public const int ContentFieldNumber = 3;

		private static readonly string C2k;

		private string L20;

		public const int DeviceHashFieldNumber = 4;

		private static readonly string x2Y;

		private string F25;

		public const int SortRankFieldNumber = 5;

		private static readonly ulong E24;

		private ulong y2Q;

		public const int ColorFieldNumber = 6;

		private static readonly string Q2X;

		private string L2w;

		public const int ShowTypeFieldNumber = 7;

		private static readonly WebCommentFeedShowType I2g;

		private WebCommentFeedShowType P2u;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public static MessageParser<WebCommentFeed> Parser => V2S;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[4];

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Id
		{
			get
			{
				return q2O ?? I2R;
			}
			set
			{
				q2O = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasId => q2O != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public SimpleUserInfo User
		{
			get
			{
				return T2l;
			}
			set
			{
				T2l = value;
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string Content
		{
			get
			{
				return L20 ?? C2k;
			}
			set
			{
				L20 = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasContent => L20 != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string DeviceHash
		{
			get
			{
				return F25 ?? x2Y;
			}
			set
			{
				F25 = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDeviceHash => F25 != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong SortRank
		{
			get
			{
				if (((uint)p2p & (true ? 1u : 0u)) != 0)
				{
					return y2Q;
				}
				return E24;
			}
			set
			{
				p2p |= 1;
				y2Q = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasSortRank => (p2p & 1) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string Color
		{
			get
			{
				return L2w ?? Q2X;
			}
			set
			{
				L2w = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasColor => L2w != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public WebCommentFeedShowType ShowType
		{
			get
			{
				if ((p2p & 2) == 0)
				{
					return I2g;
				}
				return P2u;
			}
			set
			{
				p2p |= 2;
				P2u = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasShowType => (p2p & 2) != 0;

		[GeneratedCode("protoc", null)]
		public WebCommentFeed()
		{
		}

		[GeneratedCode("protoc", null)]
		public WebCommentFeed(WebCommentFeed other)
			: this()
		{
			p2p = other.p2p;
			q2O = other.q2O;
			T2l = ((other.T2l == null) ? null : other.T2l.Clone());
			L20 = other.L20;
			F25 = other.F25;
			y2Q = other.y2Q;
			L2w = other.L2w;
			P2u = other.P2u;
			O2x = UnknownFieldSet.Clone(other.O2x);
		}

		[GeneratedCode("protoc", null)]
		public WebCommentFeed Clone()
		{
			return new WebCommentFeed(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearId()
		{
			q2O = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearContent()
		{
			L20 = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDeviceHash()
		{
			F25 = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearSortRank()
		{
			p2p &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearColor()
		{
			L2w = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearShowType()
		{
			p2p &= -3;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as WebCommentFeed);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(WebCommentFeed other)
		{
			if (other != null)
			{
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
					if (!(Content != other.Content))
					{
						if (!(DeviceHash != other.DeviceHash))
						{
							if (SortRank != other.SortRank)
							{
								return false;
							}
							if (Color != other.Color)
							{
								return false;
							}
							if (ShowType != other.ShowType)
							{
								return false;
							}
							return object.Equals(O2x, other.O2x);
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
			if (T2l != null)
			{
				num ^= User.GetHashCode();
			}
			if (HasContent)
			{
				num ^= Content.GetHashCode();
			}
			if (HasDeviceHash)
			{
				num ^= DeviceHash.GetHashCode();
			}
			if (HasSortRank)
			{
				num ^= SortRank.GetHashCode();
			}
			if (HasColor)
			{
				num ^= Color.GetHashCode();
			}
			if (HasShowType)
			{
				num ^= ShowType.GetHashCode();
			}
			if (O2x != null)
			{
				num ^= O2x.GetHashCode();
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
			if (T2l != null)
			{
				output.WriteRawTag(18);
				output.WriteMessage(User);
			}
			if (HasContent)
			{
				output.WriteRawTag(26);
				output.WriteString(Content);
			}
			if (HasDeviceHash)
			{
				output.WriteRawTag(34);
				output.WriteString(DeviceHash);
			}
			if (HasSortRank)
			{
				output.WriteRawTag(40);
				output.WriteUInt64(SortRank);
			}
			if (HasColor)
			{
				output.WriteRawTag(50);
				output.WriteString(Color);
			}
			if (HasShowType)
			{
				output.WriteRawTag(56);
				output.WriteEnum((int)ShowType);
			}
			if (O2x != null)
			{
				O2x.WriteTo(ref output);
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
			if (T2l != null)
			{
				num += 1 + CodedOutputStream.ComputeMessageSize(User);
			}
			if (HasContent)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(Content);
			}
			if (HasDeviceHash)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(DeviceHash);
			}
			if (HasSortRank)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(SortRank);
			}
			if (HasColor)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(Color);
			}
			if (HasShowType)
			{
				num += 1 + CodedOutputStream.ComputeEnumSize((int)ShowType);
			}
			if (O2x != null)
			{
				num += O2x.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(WebCommentFeed other)
		{
			if (other == null)
			{
				return;
			}
			if (other.HasId)
			{
				Id = other.Id;
			}
			if (other.T2l != null)
			{
				if (T2l == null)
				{
					User = new SimpleUserInfo();
				}
				User.MergeFrom(other.User);
			}
			if (other.HasContent)
			{
				Content = other.Content;
			}
			if (other.HasDeviceHash)
			{
				DeviceHash = other.DeviceHash;
			}
			if (other.HasSortRank)
			{
				SortRank = other.SortRank;
			}
			if (other.HasColor)
			{
				Color = other.Color;
			}
			if (other.HasShowType)
			{
				ShowType = other.ShowType;
			}
			O2x = UnknownFieldSet.MergeFrom(O2x, other.O2x);
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
				case 26u:
					Content = input.ReadString();
					break;
				case 18u:
					if (T2l == null)
					{
						User = new SimpleUserInfo();
					}
					input.ReadMessage(User);
					break;
				case 10u:
					Id = input.ReadString();
					break;
				case 56u:
					ShowType = (WebCommentFeedShowType)input.ReadEnum();
					break;
				case 50u:
					Color = input.ReadString();
					break;
				default:
					O2x = UnknownFieldSet.MergeFieldFrom(O2x, ref input);
					break;
				case 40u:
					SortRank = input.ReadUInt64();
					break;
				case 34u:
					DeviceHash = input.ReadString();
					break;
				}
			}
		}

		static WebCommentFeed()
		{
			V2S = new MessageParser<WebCommentFeed>(() => new WebCommentFeed());
			I2R = "";
			C2k = "";
			x2Y = "";
			E24 = 0uL;
			Q2X = "";
			I2g = WebCommentFeedShowType.FeedShowUnknown;
		}
	}
}
