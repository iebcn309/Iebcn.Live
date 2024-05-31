using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public enum WebCommentFeedShowType
	{
		[OriginalName("FEED_SHOW_UNKNOWN")]
		FeedShowUnknown,
		[OriginalName("FEED_SHOW_NORMAL")]
		FeedShowNormal,
		[OriginalName("FEED_HIDDEN")]
		FeedHidden
	}
}
