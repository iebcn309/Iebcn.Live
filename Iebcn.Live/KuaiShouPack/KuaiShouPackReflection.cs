using System;
using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public static class KuaiShouPackReflection
	{
		private static FileDescriptor k9R;

		public static FileDescriptor Descriptor => k9R;

		static KuaiShouPackReflection()
		{
			k9R = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChJLdWFpU2hvdVBhY2sucHJvdG8SDEt1YWlTaG91UGFjayIjCg5DU1dlYkhl" + "YXJ0YmVhdBIRCgl0aW1lc3RhbXAYASABKAQi0wEKDVNvY2tldE1lc3NhZ2US" + "LgoLcGF5bG9hZFR5cGUYASABKA4yGS5LdWFpU2hvdVBhY2suUGF5bG9hZFR5" + "cGUSRAoPY29tcHJlc3Npb25UeXBlGAIgASgOMisuS3VhaVNob3VQYWNrLlNv" + "Y2tldE1lc3NhZ2UuQ29tcHJlc3Npb25UeXBlEg8KB3BheWxvYWQYAyABKAwi" + "OwoPQ29tcHJlc3Npb25UeXBlEgsKB1VOS05PV04QABIICgROT05FEAESCAoE" + "R1pJUBACEgcKA0FFUxADIpQBCg5DU1dlYkVudGVyUm9vbRINCgV0b2tlbhgB" + "IAEoCRIUCgxsaXZlU3RyZWFtSWQYAiABKAkSFgoOcmVjb25uZWN0Q291bnQY" + "AyABKA0SFQoNbGFzdEVycm9yQ29kZRgEIAEoDRIOCgZleHBUYWcYBSABKAkS" + "DgoGYXR0YWNoGAYgASgJEg4KBnBhZ2VJZBgHIAEoCSLdAwoNU0NXZWJGZWVk" + "UHVzaBIcChRkaXNwbGF5V2F0Y2hpbmdDb3VudBgBIAEoCRIYChBkaXNwbGF5" + "TGlrZUNvdW50GAIgASgJEhgKEHBlbmRpbmdMaWtlQ291bnQYAyABKAQSFAoM" + "cHVzaEludGVydmFsGAQgASgEEjIKDGNvbW1lbnRGZWVkcxgFIAMoCzIcLkt1" + "YWlTaG91UGFjay5XZWJDb21tZW50RmVlZBIVCg1jb21tZW50Q3Vyc29yGAYg" + "ASgJEjsKEGNvbWJvQ29tbWVudEZlZWQYByADKAsyIS5LdWFpU2hvdVBhY2su" + "V2ViQ29tYm9Db21tZW50RmVlZBIsCglsaWtlRmVlZHMYCCADKAsyGS5LdWFp" + "U2hvdVBhY2suV2ViTGlrZUZlZWQSLAoJZ2lmdEZlZWRzGAkgAygLMhkuS3Vh" + "aVNob3VQYWNrLldlYkdpZnRGZWVkEhIKCmdpZnRDdXJzb3IYCiABKAkSPAoR" + "c3lzdGVtTm90aWNlRmVlZHMYCyADKAsyIS5LdWFpU2hvdVBhY2suV2ViU3lz" + "dGVtTm90aWNlRmVlZBIuCgpzaGFyZUZlZWRzGAwgAygLMhouS3VhaVNob3VQ" + "YWNrLldlYlNoYXJlRmVlZCLGAQoOV2ViQ29tbWVudEZlZWQSCgoCaWQYASAB" + "KAkSKgoEdXNlchgCIAEoCzIcLkt1YWlTaG91UGFjay5TaW1wbGVVc2VySW5m" + "bxIPCgdjb250ZW50GAMgASgJEhIKCmRldmljZUhhc2gYBCABKAkSEAoIc29y" + "dFJhbmsYBSABKAQSDQoFY29sb3IYBiABKAkSNgoIc2hvd1R5cGUYByABKA4y" + "JC5LdWFpU2hvdVBhY2suV2ViQ29tbWVudEZlZWRTaG93VHlwZSJICg5TaW1w" + "bGVVc2VySW5mbxITCgtwcmluY2lwYWxJZBgBIAEoCRIQCgh1c2VyTmFtZRgC" + "IAEoCRIPCgdoZWFkVXJsGAMgASgJIkYKE1dlYkNvbWJvQ29tbWVudEZlZWQS" + "CgoCaWQYASABKAkSDwoHY29udGVudBgCIAEoCRISCgpjb21ib0NvdW50GAMg" + "ASgNImsKC1dlYkxpa2VGZWVkEgoKAmlkGAEgASgJEioKBHVzZXIYAiABKAsy" + "HC5LdWFpU2hvdVBhY2suU2ltcGxlVXNlckluZm8SEAoIc29ydFJhbmsYAyAB" + "KAQSEgoKZGV2aWNlSGFzaBgEIAEoCSLfBAoLV2ViR2lmdEZlZWQSCgoCaWQY" + "ASABKAkSKgoEdXNlchgCIAEoCzIcLkt1YWlTaG91UGFjay5TaW1wbGVVc2Vy" + "SW5mbxIMCgR0aW1lGAMgASgEEg4KBmdpZnRJZBgEIAEoDRIQCghzb3J0UmFu" + "axgFIAEoBBIQCghtZXJnZUtleRgGIAEoCRIRCgliYXRjaFNpemUYByABKA0S" + "EgoKY29tYm9Db3VudBgIIAEoDRIMCgRyYW5rGAkgASgNEhYKDmV4cGlyZUR1" + "cmF0aW9uGAogASgEEhcKD2NsaWVudFRpbWVzdGFtcBgLIAEoBBIbChNzbG90" + "RGlzcGxheUR1cmF0aW9uGAwgASgEEhEKCXN0YXJMZXZlbBgNIAEoDRI2Cglz" + "dHlsZVR5cGUYDiABKA4yIy5LdWFpU2hvdVBhY2suV2ViR2lmdEZlZWQuU3R5" + "bGVUeXBlEj0KEWxpdmVBc3Npc3RhbnRUeXBlGA8gASgOMiIuS3VhaVNob3VQ" + "YWNrLldlYkxpdmVBc3Npc3RhbnRUeXBlEhIKCmRldmljZUhhc2gYECABKAkS" + "FgoOZGFubWFrdURpc3BsYXkYESABKAginAEKCVN0eWxlVHlwZRIRCg1VTktO" + "T1dOX1NUWUxFEAASEAoMQkFUQ0hfU1RBUl8wEAESEAoMQkFUQ0hfU1RBUl8x" + "EAISEAoMQkFUQ0hfU1RBUl8yEAMSEAoMQkFUQ0hfU1RBUl8zEAQSEAoMQkFU" + "Q0hfU1RBUl80EAUSEAoMQkFUQ0hfU1RBUl81EAYSEAoMQkFUQ0hfU1RBUl82" + "EAcipwIKE1dlYlN5c3RlbU5vdGljZUZlZWQSCgoCaWQYASABKAkSKgoEdXNl" + "chgCIAEoCzIcLkt1YWlTaG91UGFjay5TaW1wbGVVc2VySW5mbxIMCgR0aW1l" + "GAMgASgEEg8KB2NvbnRlbnQYBCABKAkSFwoPZGlzcGxheUR1cmF0aW9uGAUg" + "ASgEEhAKCHNvcnRSYW5rGAYgASgEEkIKC2Rpc3BsYXlUeXBlGAcgASgOMi0u" + "S3VhaVNob3VQYWNrLldlYlN5c3RlbU5vdGljZUZlZWQuRGlzcGxheVR5cGUi" + "SgoLRGlzcGxheVR5cGUSGAoUVU5LTk9XTl9ESVNQTEFZX1RZUEUQABILCgdD" + "T01NRU5UEAESCQoFQUxFUlQQAhIJCgVUT0FTVBADItUBCgxXZWJTaGFyZUZl" + "ZWQSCgoCaWQYASABKAkSKgoEdXNlchgCIAEoCzIcLkt1YWlTaG91UGFjay5T" + "aW1wbGVVc2VySW5mbxIMCgR0aW1lGAMgASgEEhoKEnRoaXJkUGFydHlQbGF0" + "Zm9ybRgEIAEoDRIQCghzb3J0UmFuaxgFIAEoBBI9ChFsaXZlQXNzaXN0YW50" + "VHlwZRgGIAEoDjIiLkt1YWlTaG91UGFjay5XZWJMaXZlQXNzaXN0YW50VHlw" + "ZRISCgpkZXZpY2VIYXNoGAcgASgJKtgKCgtQYXlsb2FkVHlwZRILCgdVTktO" + "T1dOEAASEAoMQ1NfSEVBUlRCRUFUEAESDAoIQ1NfRVJST1IQAxILCgdDU19Q" + "SU5HEAQSEAoMUFNfSE9TVF9JTkZPEDMSFAoQU0NfSEVBUlRCRUFUX0FDSxBl" + "EgsKB1NDX0VDSE8QZhIMCghTQ19FUlJPUhBnEg8KC1NDX1BJTkdfQUNLEGgS" + "CwoHU0NfSU5GTxBpEhIKDUNTX0VOVEVSX1JPT00QyAESEgoNQ1NfVVNFUl9Q" + "QVVTRRDJARIRCgxDU19VU0VSX0VYSVQQygESIAobQ1NfQVVUSE9SX1BVU0hf" + "VFJBRkZJQ19aRVJPEMsBEhQKD0NTX0hPUlNFX1JBQ0lORxDMARIRCgxDU19S" + "QUNFX0xPU0UQzQESEwoOQ1NfVk9JUF9TSUdOQUwQzgESFgoRU0NfRU5URVJf" + "Uk9PTV9BQ0sQrAISFAoPU0NfQVVUSE9SX1BBVVNFEK0CEhUKEFNDX0FVVEhP" + "Ul9SRVNVTUUQrgISIAobU0NfQVVUSE9SX1BVU0hfVFJBRkZJQ19aRVJPEK8C" + "Eh0KGFNDX0FVVEhPUl9IRUFSVEJFQVRfTUlTUxCwAhITCg5TQ19QSVBfU1RB" + "UlRFRBCxAhIRCgxTQ19QSVBfRU5ERUQQsgISGAoTU0NfSE9SU0VfUkFDSU5H" + "X0FDSxCzAhITCg5TQ19WT0lQX1NJR05BTBC0AhIRCgxTQ19GRUVEX1BVU0gQ" + "tgISGAoTU0NfQVNTSVNUQU5UX1NUQVRVUxC3AhIWChFTQ19SRUZSRVNIX1dB" + "TExFVBC4AhIWChFTQ19MSVZFX0NIQVRfQ0FMTBDAAhIfChpTQ19MSVZFX0NI" + "QVRfQ0FMTF9BQ0NFUFRFRBDBAhIfChpTQ19MSVZFX0NIQVRfQ0FMTF9SRUpF" + "Q1RFRBDCAhIXChJTQ19MSVZFX0NIQVRfUkVBRFkQwwISGwoWU0NfTElWRV9D" + "SEFUX0dVRVNUX0VORBDEAhIXChJTQ19MSVZFX0NIQVRfRU5ERUQQxQISJAof" + "U0NfUkVOREVSSU5HX01BR0lDX0ZBQ0VfRElTQUJMRRDGAhIjCh5TQ19SRU5E" + "RVJJTkdfTUFHSUNfRkFDRV9FTkFCTEUQxwISFQoQU0NfUkVEX1BBQ0tfRkVF" + "RBDKAhIaChVTQ19MSVZFX1dBVENISU5HX0xJU1QQ1AISIAobU0NfTElWRV9R" + "VUlaX1FVRVNUSU9OX0FTS0VEEN4CEiMKHlNDX0xJVkVfUVVJWl9RVUVTVElP" + "Tl9SRVZJRVdFRBDfAhIWChFTQ19MSVZFX1FVSVpfU1lOQxDgAhIXChJTQ19M" + "SVZFX1FVSVpfRU5ERUQQ4QISGQoUU0NfTElWRV9RVUlaX1dJTk5FUlMQ4gIS" + "GwoWU0NfU1VTUEVDVEVEX1ZJT0xBVElPThDjAhITCg5TQ19TSE9QX09QRU5F" + "RBDoAhITCg5TQ19TSE9QX0NMT1NFRBDpAhIUCg9TQ19HVUVTU19PUEVORUQQ" + "8gISFAoPU0NfR1VFU1NfQ0xPU0VEEPMCEhUKEFNDX1BLX0lOVklUQVRJT04Q" + "/AISFAoPU0NfUEtfU1RBVElTVElDEP0CEhUKEFNDX1JJRERMRV9PUEVORUQQ" + "hgMSFgoRU0NfUklERExFX0NMT0VTRUQQhwMSFAoPU0NfUklERV9DSEFOR0VE" + "EJwDEhMKDlNDX0JFVF9DSEFOR0VEELkDEhIKDVNDX0JFVF9DTE9TRUQQugMS" + "KQokU0NfTElWRV9TUEVDSUFMX0FDQ09VTlRfQ09ORklHX1NUQVRFEIUFKlYK" + "FldlYkNvbW1lbnRGZWVkU2hvd1R5cGUSFQoRRkVFRF9TSE9XX1VOS05PV04Q" + "ABIUChBGRUVEX1NIT1dfTk9STUFMEAESDwoLRkVFRF9ISURERU4QAipJChRX" + "ZWJMaXZlQXNzaXN0YW50VHlwZRIaChZVTktOT1dOX0FTU0lTVEFOVF9UWVBF" + "EAASCQoFU1VQRVIQARIKCgZKVU5JT1IQAg=="), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[3]
			{
				typeof(PayloadType),
				typeof(WebCommentFeedShowType),
				typeof(WebLiveAssistantType)
			}, null, new GeneratedClrTypeInfo[11]
			{
				new GeneratedClrTypeInfo(typeof(CSWebHeartbeat), CSWebHeartbeat.Parser, new string[1] { "Timestamp" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(SocketMessage), SocketMessage.Parser, new string[3] { "PayloadType", "CompressionType", "Payload" }, null, new Type[1] { typeof(SocketMessage.Types.CompressionType) }, null, null),
				new GeneratedClrTypeInfo(typeof(CSWebEnterRoom), CSWebEnterRoom.Parser, new string[7] { "Token", "LiveStreamId", "ReconnectCount", "LastErrorCode", "ExpTag", "Attach", "PageId" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(SCWebFeedPush), SCWebFeedPush.Parser, new string[12]
				{
					"DisplayWatchingCount", "DisplayLikeCount", "PendingLikeCount", "PushInterval", "CommentFeeds", "CommentCursor", "ComboCommentFeed", "LikeFeeds", "GiftFeeds", "GiftCursor",
					"SystemNoticeFeeds", "ShareFeeds"
				}, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(WebCommentFeed), WebCommentFeed.Parser, new string[7] { "Id", "User", "Content", "DeviceHash", "SortRank", "Color", "ShowType" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(SimpleUserInfo), SimpleUserInfo.Parser, new string[3] { "PrincipalId", "UserName", "HeadUrl" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(WebComboCommentFeed), WebComboCommentFeed.Parser, new string[3] { "Id", "Content", "ComboCount" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(WebLikeFeed), WebLikeFeed.Parser, new string[4] { "Id", "User", "SortRank", "DeviceHash" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(WebGiftFeed), WebGiftFeed.Parser, new string[17]
				{
					"Id", "User", "Time", "GiftId", "SortRank", "MergeKey", "BatchSize", "ComboCount", "Rank", "ExpireDuration",
					"ClientTimestamp", "SlotDisplayDuration", "StarLevel", "StyleType", "LiveAssistantType", "DeviceHash", "DanmakuDisplay"
				}, null, new Type[1] { typeof(WebGiftFeed.Types.StyleType) }, null, null),
				new GeneratedClrTypeInfo(typeof(WebSystemNoticeFeed), WebSystemNoticeFeed.Parser, new string[7] { "Id", "User", "Time", "Content", "DisplayDuration", "SortRank", "DisplayType" }, null, new Type[1] { typeof(WebSystemNoticeFeed.Types.DisplayType) }, null, null),
				new GeneratedClrTypeInfo(typeof(WebShareFeed), WebShareFeed.Parser, new string[7] { "Id", "User", "Time", "ThirdPartyPlatform", "SortRank", "LiveAssistantType", "DeviceHash" }, null, null, null, null)
			}));
		}
	}
}