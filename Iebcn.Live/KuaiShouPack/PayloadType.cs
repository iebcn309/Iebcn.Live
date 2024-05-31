using Google.Protobuf.Reflection;

namespace KuaiShouPack
{
	public enum PayloadType
	{
		[OriginalName("UNKNOWN")]
		Unknown = 0,
		[OriginalName("CS_HEARTBEAT")]
		CsHeartbeat = 1,
		[OriginalName("CS_ERROR")]
		CsError = 3,
		[OriginalName("CS_PING")]
		CsPing = 4,
		[OriginalName("PS_HOST_INFO")]
		PsHostInfo = 51,
		[OriginalName("SC_HEARTBEAT_ACK")]
		ScHeartbeatAck = 101,
		[OriginalName("SC_ECHO")]
		ScEcho = 102,
		[OriginalName("SC_ERROR")]
		ScError = 103,
		[OriginalName("SC_PING_ACK")]
		ScPingAck = 104,
		[OriginalName("SC_INFO")]
		ScInfo = 105,
		[OriginalName("CS_ENTER_ROOM")]
		CsEnterRoom = 200,
		[OriginalName("CS_USER_PAUSE")]
		CsUserPause = 201,
		[OriginalName("CS_USER_EXIT")]
		CsUserExit = 202,
		[OriginalName("CS_AUTHOR_PUSH_TRAFFIC_ZERO")]
		CsAuthorPushTrafficZero = 203,
		[OriginalName("CS_HORSE_RACING")]
		CsHorseRacing = 204,
		[OriginalName("CS_RACE_LOSE")]
		CsRaceLose = 205,
		[OriginalName("CS_VOIP_SIGNAL")]
		CsVoipSignal = 206,
		[OriginalName("SC_ENTER_ROOM_ACK")]
		ScEnterRoomAck = 300,
		[OriginalName("SC_AUTHOR_PAUSE")]
		ScAuthorPause = 301,
		[OriginalName("SC_AUTHOR_RESUME")]
		ScAuthorResume = 302,
		[OriginalName("SC_AUTHOR_PUSH_TRAFFIC_ZERO")]
		ScAuthorPushTrafficZero = 303,
		[OriginalName("SC_AUTHOR_HEARTBEAT_MISS")]
		ScAuthorHeartbeatMiss = 304,
		[OriginalName("SC_PIP_STARTED")]
		ScPipStarted = 305,
		[OriginalName("SC_PIP_ENDED")]
		ScPipEnded = 306,
		[OriginalName("SC_HORSE_RACING_ACK")]
		ScHorseRacingAck = 307,
		[OriginalName("SC_VOIP_SIGNAL")]
		ScVoipSignal = 308,
		[OriginalName("SC_FEED_PUSH")]
		ScFeedPush = 310,
		[OriginalName("SC_ASSISTANT_STATUS")]
		ScAssistantStatus = 311,
		[OriginalName("SC_REFRESH_WALLET")]
		ScRefreshWallet = 312,
		[OriginalName("SC_LIVE_CHAT_CALL")]
		ScLiveChatCall = 320,
		[OriginalName("SC_LIVE_CHAT_CALL_ACCEPTED")]
		ScLiveChatCallAccepted = 321,
		[OriginalName("SC_LIVE_CHAT_CALL_REJECTED")]
		ScLiveChatCallRejected = 322,
		[OriginalName("SC_LIVE_CHAT_READY")]
		ScLiveChatReady = 323,
		[OriginalName("SC_LIVE_CHAT_GUEST_END")]
		ScLiveChatGuestEnd = 324,
		[OriginalName("SC_LIVE_CHAT_ENDED")]
		ScLiveChatEnded = 325,
		[OriginalName("SC_RENDERING_MAGIC_FACE_DISABLE")]
		ScRenderingMagicFaceDisable = 326,
		[OriginalName("SC_RENDERING_MAGIC_FACE_ENABLE")]
		ScRenderingMagicFaceEnable = 327,
		[OriginalName("SC_RED_PACK_FEED")]
		ScRedPackFeed = 330,
		[OriginalName("SC_LIVE_WATCHING_LIST")]
		ScLiveWatchingList = 340,
		[OriginalName("SC_LIVE_QUIZ_QUESTION_ASKED")]
		ScLiveQuizQuestionAsked = 350,
		[OriginalName("SC_LIVE_QUIZ_QUESTION_REVIEWED")]
		ScLiveQuizQuestionReviewed = 351,
		[OriginalName("SC_LIVE_QUIZ_SYNC")]
		ScLiveQuizSync = 352,
		[OriginalName("SC_LIVE_QUIZ_ENDED")]
		ScLiveQuizEnded = 353,
		[OriginalName("SC_LIVE_QUIZ_WINNERS")]
		ScLiveQuizWinners = 354,
		[OriginalName("SC_SUSPECTED_VIOLATION")]
		ScSuspectedViolation = 355,
		[OriginalName("SC_SHOP_OPENED")]
		ScShopOpened = 360,
		[OriginalName("SC_SHOP_CLOSED")]
		ScShopClosed = 361,
		[OriginalName("SC_GUESS_OPENED")]
		ScGuessOpened = 370,
		[OriginalName("SC_GUESS_CLOSED")]
		ScGuessClosed = 371,
		[OriginalName("SC_PK_INVITATION")]
		ScPkInvitation = 380,
		[OriginalName("SC_PK_STATISTIC")]
		ScPkStatistic = 381,
		[OriginalName("SC_RIDDLE_OPENED")]
		ScRiddleOpened = 390,
		[OriginalName("SC_RIDDLE_CLOESED")]
		ScRiddleCloesed = 391,
		[OriginalName("SC_RIDE_CHANGED")]
		ScRideChanged = 412,
		[OriginalName("SC_BET_CHANGED")]
		ScBetChanged = 441,
		[OriginalName("SC_BET_CLOSED")]
		ScBetClosed = 442,
		[OriginalName("SC_LIVE_SPECIAL_ACCOUNT_CONFIG_STATE")]
		ScLiveSpecialAccountConfigState = 645
	}
}
