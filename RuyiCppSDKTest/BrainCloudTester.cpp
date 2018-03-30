#include "CppUnitTest.h"

#include "TestCase\BCServiceTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace RuyiCppSDKTest
{
	TEST_CLASS(BrainCloudTester)
	{
	public:
		static BCServiceTest* pBCServiceTest;

		TEST_CLASS_INITIALIZE(ClassInitialize)
		{
			pBCServiceTest = new BCServiceTest();

			pBCServiceTest->BCS_Authentication_AuthenticateAnonymous(); //order(0)
		}

		TEST_CLASS_CLEANUP(ClassCleanup)
		{
			delete pBCServiceTest;
			pBCServiceTest = NULL;
		}

		TEST_METHOD(BCS_GLOBALSTATISTICS)
		{
			pBCServiceTest->BCS_GlobalStatistics_IncrementGlobalStats(); //order(860)
			pBCServiceTest->BCS_GlobalStatistics_ProcessStatistics(); //order(870)
			pBCServiceTest->BCS_GlobalStatistics_ReadAllGlobalStats(); //order(880)
			pBCServiceTest->BCS_GlobalStatistics_ReadGlobalStatsForCategory(); //order(890)
			pBCServiceTest->BCS_GlobalStatistics_ReadGlobalStatsSubset(); //order(900)
		}

		TEST_METHOD(BCS_Authentications)
		{
			pBCServiceTest->BCS_Authentication_AuthenticateAnonymous(); //order(0)
			pBCServiceTest->BCS_Authentication_ClearSavedProfiedId(); //order(10)
			pBCServiceTest->BCS_Authentication_AuthenticateEmail(); //order(20)
			pBCServiceTest->BCS_Authentication_ResetEmailPassword(); //order(22)
			pBCServiceTest->BCS_Authentication_AuthenticateUniversal(); //order(30)
		}

		TEST_METHOD(BCS_AsyncMath)
		{
			pBCServiceTest->BCS_AsyncMatch_CreateMatch(); //order(50)
			pBCServiceTest->BCS_AsyncMatch_FindMatchs(); //order(52)
			pBCServiceTest->BCS_AsyncMatch_UpdateMatchSummaryData(); //order(55)
			pBCServiceTest->BCS_AsyncMatch_ReadMatch(); //order(60)
			pBCServiceTest->BCS_AsyncMatch_SubmitTurn(); //order(70)
			pBCServiceTest->BCS_AsyncMatch_ReadMatchHistory(); //order(80)
			pBCServiceTest->BCS_AsyncMatch_CompleteMatch(); //order(90)
			pBCServiceTest->BCS_AsyncMatch_FindCompleteMatches(); //order(100)
			pBCServiceTest->BCS_AsyncMatch_CreateMatchWithInitialTurn(); //order(110)
			pBCServiceTest->BCS_AsyncMatch_AbandonMatch(); //order(120)
			pBCServiceTest->BCS_AsyncMatch_DeleteMatch(); //order(130)
		}

		TEST_METHOD(BCS_DATASTREAM)
		{
			pBCServiceTest->BCS_DataStream_CustomPageEvent(); //order(140)
			pBCServiceTest->BCS_DataStream_CustomScreenEvent(); //order(150)
			pBCServiceTest->BCS_DataStream_CustomTrackEvent(); //order(160)
		}

		TEST_METHOD(BCS_ENTITY)
		{
			pBCServiceTest->BCS_Entity_CreateEntity(); //order(170)
			pBCServiceTest->BCS_Entity_GetList(); //order(190)
			pBCServiceTest->BCS_Entity_GetListCount(); //order(200)
			pBCServiceTest->BCS_Entity_GetEntity(); //order(210)
			pBCServiceTest->BCS_Entity_GetEntitiesByType(); //order(220)
			pBCServiceTest->BCS_Entity_GetPage(); //order(230)
			pBCServiceTest->BCS_Entity_GetPageOffset(); //order(240)
			pBCServiceTest->BCS_Entity_GetSharedEntityForProfileId(); //order(250)
			pBCServiceTest->BCS_Entity_GetSharedEntitiesForProfileId(); //order(260)
			pBCServiceTest->BCS_Entity_GetSharedEntitiesListForProfileId(); //order(270)
			pBCServiceTest->BCS_Entity_IncrementUserEntityData(); //order(280)
			pBCServiceTest->BCS_Entity_IncrementSharedUserEntityData(); //order(290)
			pBCServiceTest->BCS_Entity_UpdateEntity(); //order(300)
			pBCServiceTest->BCS_Entity_UpdateSharedEntity(); //order(320)
			pBCServiceTest->BCS_Entity_DeleteEntity(); //order(330)
			pBCServiceTest->BCS_Entity_UpdateSingleton(); //order(340)
			pBCServiceTest->BCS_Entity_GetSingleton(); //order(350)
			pBCServiceTest->BCS_Entity_DeleteSingleton(); //order(360)
		}

		TEST_METHOD(BCS_EVENT)
		{
			pBCServiceTest->BCS_Event_SendEvent(); //order(400)
			pBCServiceTest->BCS_Event_GetEvents(); //order(410)
			pBCServiceTest->BCS_Event_UpdateIncomingEventData(); //order(420)
			pBCServiceTest->BCS_Event_DeleteIncomingEvent(); //order(430)
		}

		TEST_METHOD(BCS_FILES)
		{
			pBCServiceTest->BCS_File_UploadFile(); //order(440)
			pBCServiceTest->BCS_File_GetCDNUrl(); //order(445)

			// FIXME:
			// bcs is actually a blocking call, so you can't upload and keeps getting the update
			// of the progress, unless we do something on the layer0 side.
			// we should create an ID for each upload and just return the id for upload call,
			// user could use that ID to get the progress.
//			pBCServiceTest->BCS_File_GetUploadProgressAndBytes(); //order(450) not finish
//			pBCServiceTest->BCS_File_CancelUpload(); //order(470)
			
			
			pBCServiceTest->BCS_File_ListUserFiles(); //order(480)
			pBCServiceTest->BCS_File_DeleteFiles(); //order(490)
		}

		TEST_METHOD(BCS_FRIENDS)
		{
			pBCServiceTest->BCS_Friend_AddFriends(); //order(500)
			pBCServiceTest->BCS_Friend_ListFirends(); //order(510)
			pBCServiceTest->BCS_Friend_ReadFriendEntity(); //order(520)
			pBCServiceTest->BCS_Friend_ReadFriendsEntities(); //order(530)
			pBCServiceTest->BCS_Friend_ReadFriendUserState(); //order(540)
			pBCServiceTest->BCS_Friend_FindUserByUniversalId(); //order(550)
			pBCServiceTest->BCS_Friend_FindUserByExactName(); //order(560)
			pBCServiceTest->BCS_Friend_FindUsersBySubstrName(); //order(570)
			pBCServiceTest->BCS_Friend_GetExternalIdForProfileId(); //order(580)
			pBCServiceTest->BCS_Friend_GetProfileInfoForCredential(); //order(590)
			pBCServiceTest->BCS_Friend_GetSummaryDataForProfileId(); //order(600)
			pBCServiceTest->BCS_Friend_GetUsersOnlineStatus(); //order(610)
		}

		TEST_METHOD(BCS_GAMIFICATION)
		{
			pBCServiceTest->BCS_Gamification_ReadAllGamification(); //order(620)
			pBCServiceTest->BCS_Gamification_ReadXpLevelsMetaData(); //order(630)
			pBCServiceTest->BCS_Gamification_AwardAchievements(); //order(640)
			pBCServiceTest->BCS_Gamification_ReadAchievements(); //order(650)
			pBCServiceTest->BCS_Gamification_ReadAchievedAchievements(); //order(660)
			pBCServiceTest->BCS_Gamification_ReadMilestones(); //order(670)
			pBCServiceTest->BCS_Gamification_ReadMilestonesByCategory(); //order(680)
			pBCServiceTest->BCS_Gamification_ReadInProgressMilestones(); //order(690)
			pBCServiceTest->BCS_Gamification_ReadCompletedMilestones(); //order(700)
			pBCServiceTest->BCS_Gamification_ResetMilestones(); //order(710)
			pBCServiceTest->BCS_Gamification_ReadQuests(); //order(720)
			pBCServiceTest->BCS_Gamification_ReadQuestsByCategory(); //order(730)
			pBCServiceTest->BCS_Gamification_ReadQuestsWithStatus(); //order(740)
			pBCServiceTest->BCS_Gamification_ReadQuestsWithBasicPercentage(); //order(750)
			pBCServiceTest->BCS_Gamification_ReadQuestsWithComplexPercentage(); //order(760)
			pBCServiceTest->BCS_Gamification_ReadNotStartedQuests(); //order(770)
			pBCServiceTest->BCS_Gamification_ReadInProgressQuests(); //order(780)
			pBCServiceTest->BCS_Gamification_ReadCompletedQuests(); //order(790)
		}

		TEST_METHOD(BCS_GLOABLAPP)
		{
			pBCServiceTest->BCS_GlobalApp_ReadProperties(); //order(800)
		}

		TEST_METHOD(BCS_GLOBALENTITY)
		{
			pBCServiceTest->BCS_GlobalEntity_CreateEntity(); //order(810)
			pBCServiceTest->BCS_GlobalEntity_CreateEntityWithIndexedId(); //order(820)
			pBCServiceTest->BCS_GlobalEntity_DoEntityUpdates(); //order(830)
			pBCServiceTest->BCS_GlobalEntity_Retrieval(); //order(835)
			pBCServiceTest->BCS_GlobalEntity_SystemEntities(); //order(840)
			pBCServiceTest->BCS_GlobalEntity_DeleteEntities(); //order(850)
		}
		
		//test for single api of some function
		TEST_METHOD(BCS_EXAMPLE)
		{
			pBCServiceTest->BCS_GetLoginedUserProfile();
			//pBCServiceTest->BCS_PostScoreToLeaderboard();
			pBCServiceTest->BCS_GetLeadboardPage();
			//pBCServiceTest->BCS_FriendRelatedScript();

			//pBCServiceTest->BCS_JsonTest();
		}
	};

	BCServiceTest* BrainCloudTester::pBCServiceTest;
}