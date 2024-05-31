using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public sealed class SCWebFeedPush : IMessage<SCWebFeedPush>, IMessage, IEquatable<SCWebFeedPush>, IDeepCloneable<SCWebFeedPush>, IBufferMessage
	{
		private static readonly MessageParser<SCWebFeedPush> x28;

		private UnknownFieldSet y2J;

		private int v2D;

		public const int DisplayWatchingCountFieldNumber = 1;

		private static readonly string o2E;

		private string O2I;

		public const int DisplayLikeCountFieldNumber = 2;

		private static readonly string X2f;

		private string T2H;

		public const int PendingLikeCountFieldNumber = 3;

		private static readonly ulong j2N;

		private ulong T27;

		public const int PushIntervalFieldNumber = 4;

		private static readonly ulong R2t;

		private ulong A2r;

		public const int CommentFeedsFieldNumber = 5;

		private static readonly FieldCodec<WebCommentFeed> K2U;

		private readonly RepeatedField<WebCommentFeed> H21 = new RepeatedField<WebCommentFeed>();

		public const int CommentCursorFieldNumber = 6;

		private static readonly string F2i;

		private string U2n;

		public const int ComboCommentFeedFieldNumber = 7;

		private static readonly FieldCodec<WebComboCommentFeed> S2M;

		private readonly RepeatedField<WebComboCommentFeed> u2y = new RepeatedField<WebComboCommentFeed>();

		public const int LikeFeedsFieldNumber = 8;

		private static readonly FieldCodec<WebLikeFeed> l2G;

		private readonly RepeatedField<WebLikeFeed> Y2v = new RepeatedField<WebLikeFeed>();

		public const int GiftFeedsFieldNumber = 9;

		private static readonly FieldCodec<WebGiftFeed> j2e;

		private readonly RepeatedField<WebGiftFeed> q2s = new RepeatedField<WebGiftFeed>();

		public const int GiftCursorFieldNumber = 10;

		private static readonly string z2C;

		private string l2m;

		public const int SystemNoticeFeedsFieldNumber = 11;

		private static readonly FieldCodec<WebSystemNoticeFeed> o2B;

		private readonly RepeatedField<WebSystemNoticeFeed> x2T = new RepeatedField<WebSystemNoticeFeed>();

		public const int ShareFeedsFieldNumber = 12;

		private static readonly FieldCodec<WebShareFeed> i2K;

		private readonly RepeatedField<WebShareFeed> L2d = new RepeatedField<WebShareFeed>();

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageParser<SCWebFeedPush> Parser => x28;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public static MessageDescriptor Descriptor => KuaiShouPackReflection.Descriptor.MessageTypes[3];

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		MessageDescriptor IMessage.Descriptor => Descriptor;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string DisplayWatchingCount
		{
			get
			{
				return O2I ?? o2E;
			}
			set
			{
				O2I = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDisplayWatchingCount => O2I != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string DisplayLikeCount
		{
			get
			{
				return T2H ?? X2f;
			}
			set
			{
				T2H = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasDisplayLikeCount => T2H != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public ulong PendingLikeCount
		{
			get
			{
				if ((v2D & 1) == 0)
				{
					return j2N;
				}
				return T27;
			}
			set
			{
				v2D |= 1;
				T27 = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPendingLikeCount => (v2D & 1) != 0;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public ulong PushInterval
		{
			get
			{
				if ((v2D & 2) == 0)
				{
					return R2t;
				}
				return A2r;
			}
			set
			{
				v2D |= 2;
				A2r = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasPushInterval => (v2D & 2) != 0;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public RepeatedField<WebCommentFeed> CommentFeeds => H21;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public string CommentCursor
		{
			get
			{
				return U2n ?? F2i;
			}
			set
			{
				U2n = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public bool HasCommentCursor => U2n != null;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public RepeatedField<WebComboCommentFeed> ComboCommentFeed => u2y;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public RepeatedField<WebLikeFeed> LikeFeeds => Y2v;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public RepeatedField<WebGiftFeed> GiftFeeds => q2s;

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public string GiftCursor
		{
			get
			{
				return l2m ?? z2C;
			}
			set
			{
				l2m = ProtoPreconditions.CheckNotNull(value, "value");
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("protoc", null)]
		public bool HasGiftCursor => l2m != null;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public RepeatedField<WebSystemNoticeFeed> SystemNoticeFeeds => x2T;

		[GeneratedCode("protoc", null)]
		[DebuggerNonUserCode]
		public RepeatedField<WebShareFeed> ShareFeeds => L2d;

		[GeneratedCode("protoc", null)]
		public SCWebFeedPush()
		{
		}

		[GeneratedCode("protoc", null)]
		public SCWebFeedPush(SCWebFeedPush other)
			: this()
		{
			v2D = other.v2D;
			O2I = other.O2I;
			T2H = other.T2H;
			T27 = other.T27;
			A2r = other.A2r;
			H21 = other.H21.Clone();
			U2n = other.U2n;
			u2y = other.u2y.Clone();
			Y2v = other.Y2v.Clone();
			q2s = other.q2s.Clone();
			l2m = other.l2m;
			x2T = other.x2T.Clone();
			L2d = other.L2d.Clone();
			y2J = UnknownFieldSet.Clone(other.y2J);
		}

		[GeneratedCode("protoc", null)]
		public SCWebFeedPush Clone()
		{
			return new SCWebFeedPush(this);
		}

		[GeneratedCode("protoc", null)]
		public void ClearDisplayWatchingCount()
		{
			O2I = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearDisplayLikeCount()
		{
			T2H = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearPendingLikeCount()
		{
			v2D &= -2;
		}

		[GeneratedCode("protoc", null)]
		public void ClearPushInterval()
		{
			v2D &= -3;
		}

		[GeneratedCode("protoc", null)]
		public void ClearCommentCursor()
		{
			U2n = null;
		}

		[GeneratedCode("protoc", null)]
		public void ClearGiftCursor()
		{
			l2m = null;
		}

		[GeneratedCode("protoc", null)]
		public override bool Equals(object other)
		{
			return Equals(other as SCWebFeedPush);
		}

		[GeneratedCode("protoc", null)]
		public bool Equals(SCWebFeedPush other)
		{
			if (other != null)
			{
				if (other == this)
				{
					return true;
				}
				if (!(DisplayWatchingCount != other.DisplayWatchingCount))
				{
					if (!(DisplayLikeCount != other.DisplayLikeCount))
					{
						if (PendingLikeCount != other.PendingLikeCount)
						{
							return false;
						}
						if (PushInterval != other.PushInterval)
						{
							return false;
						}
						if (H21.Equals(other.H21))
						{
							if (CommentCursor != other.CommentCursor)
							{
								return false;
							}
							if (u2y.Equals(other.u2y))
							{
								if (Y2v.Equals(other.Y2v))
								{
									if (q2s.Equals(other.q2s))
									{
										if (!(GiftCursor != other.GiftCursor))
										{
											if (x2T.Equals(other.x2T))
											{
												if (L2d.Equals(other.L2d))
												{
													return object.Equals(y2J, other.y2J);
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
			if (HasDisplayWatchingCount)
			{
				num ^= DisplayWatchingCount.GetHashCode();
			}
			if (HasDisplayLikeCount)
			{
				num ^= DisplayLikeCount.GetHashCode();
			}
			if (HasPendingLikeCount)
			{
				num ^= PendingLikeCount.GetHashCode();
			}
			if (HasPushInterval)
			{
				num ^= PushInterval.GetHashCode();
			}
			num ^= H21.GetHashCode();
			if (HasCommentCursor)
			{
				num ^= CommentCursor.GetHashCode();
			}
			num ^= u2y.GetHashCode();
			num ^= Y2v.GetHashCode();
			num ^= q2s.GetHashCode();
			if (HasGiftCursor)
			{
				num ^= GiftCursor.GetHashCode();
			}
			num ^= x2T.GetHashCode();
			num ^= L2d.GetHashCode();
			if (y2J != null)
			{
				num ^= y2J.GetHashCode();
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
			if (HasDisplayWatchingCount)
			{
				output.WriteRawTag(10);
				output.WriteString(DisplayWatchingCount);
			}
			if (HasDisplayLikeCount)
			{
				output.WriteRawTag(18);
				output.WriteString(DisplayLikeCount);
			}
			if (HasPendingLikeCount)
			{
				output.WriteRawTag(24);
				output.WriteUInt64(PendingLikeCount);
			}
			if (HasPushInterval)
			{
				output.WriteRawTag(32);
				output.WriteUInt64(PushInterval);
			}
			H21.WriteTo(ref output, K2U);
			if (HasCommentCursor)
			{
				output.WriteRawTag(50);
				output.WriteString(CommentCursor);
			}
			u2y.WriteTo(ref output, S2M);
			Y2v.WriteTo(ref output, l2G);
			q2s.WriteTo(ref output, j2e);
			if (HasGiftCursor)
			{
				output.WriteRawTag(82);
				output.WriteString(GiftCursor);
			}
			x2T.WriteTo(ref output, o2B);
			L2d.WriteTo(ref output, i2K);
			if (y2J != null)
			{
				y2J.WriteTo(ref output);
			}
		}

		[GeneratedCode("protoc", null)]
		public int CalculateSize()
		{
			int num = 0;
			if (HasDisplayWatchingCount)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(DisplayWatchingCount);
			}
			if (HasDisplayLikeCount)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(DisplayLikeCount);
			}
			if (HasPendingLikeCount)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(PendingLikeCount);
			}
			if (HasPushInterval)
			{
				num += 1 + CodedOutputStream.ComputeUInt64Size(PushInterval);
			}
			num += H21.CalculateSize(K2U);
			if (HasCommentCursor)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(CommentCursor);
			}
			num += u2y.CalculateSize(S2M);
			num += Y2v.CalculateSize(l2G);
			num += q2s.CalculateSize(j2e);
			if (HasGiftCursor)
			{
				num += 1 + CodedOutputStream.ComputeStringSize(GiftCursor);
			}
			num += x2T.CalculateSize(o2B);
			num += L2d.CalculateSize(i2K);
			if (y2J != null)
			{
				num += y2J.CalculateSize();
			}
			return num;
		}

		[GeneratedCode("protoc", null)]
		public void MergeFrom(SCWebFeedPush other)
		{
			if (other != null)
			{
				if (other.HasDisplayWatchingCount)
				{
					DisplayWatchingCount = other.DisplayWatchingCount;
				}
				if (other.HasDisplayLikeCount)
				{
					DisplayLikeCount = other.DisplayLikeCount;
				}
				if (other.HasPendingLikeCount)
				{
					PendingLikeCount = other.PendingLikeCount;
				}
				if (other.HasPushInterval)
				{
					PushInterval = other.PushInterval;
				}
				H21.Add(other.H21);
				if (other.HasCommentCursor)
				{
					CommentCursor = other.CommentCursor;
				}
				u2y.Add(other.u2y);
				Y2v.Add(other.Y2v);
				q2s.Add(other.q2s);
				if (other.HasGiftCursor)
				{
					GiftCursor = other.GiftCursor;
				}
				x2T.Add(other.x2T);
				L2d.Add(other.L2d);
				y2J = UnknownFieldSet.MergeFrom(y2J, other.y2J);
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
				case 50u:
					CommentCursor = input.ReadString();
					break;
				case 42u:
					H21.AddEntriesFrom(ref input, K2U);
					break;
				case 32u:
					PushInterval = input.ReadUInt64();
					break;
				case 24u:
					PendingLikeCount = input.ReadUInt64();
					break;
				case 18u:
					DisplayLikeCount = input.ReadString();
					break;
				case 10u:
					DisplayWatchingCount = input.ReadString();
					break;
				case 74u:
					q2s.AddEntriesFrom(ref input, j2e);
					break;
				case 66u:
					Y2v.AddEntriesFrom(ref input, l2G);
					break;
				case 58u:
					u2y.AddEntriesFrom(ref input, S2M);
					break;
				default:
					y2J = UnknownFieldSet.MergeFieldFrom(y2J, ref input);
					break;
				case 98u:
					L2d.AddEntriesFrom(ref input, i2K);
					break;
				case 90u:
					x2T.AddEntriesFrom(ref input, o2B);
					break;
				case 82u:
					GiftCursor = input.ReadString();
					break;
				}
			}
		}

		static SCWebFeedPush()
		{
			x28 = new MessageParser<SCWebFeedPush>(() => new SCWebFeedPush());
			o2E = "";
			X2f = "";
			j2N = 0uL;
			R2t = 0uL;
			K2U = FieldCodec.ForMessage(42u, WebCommentFeed.Parser);
			F2i = "";
			S2M = FieldCodec.ForMessage(58u, WebComboCommentFeed.Parser);
			l2G = FieldCodec.ForMessage(66u, WebLikeFeed.Parser);
			j2e = FieldCodec.ForMessage(74u, WebGiftFeed.Parser);
			z2C = "";
			o2B = FieldCodec.ForMessage(90u, WebSystemNoticeFeed.Parser);
			i2K = FieldCodec.ForMessage(98u, WebShareFeed.Parser);
		}
	}
}
