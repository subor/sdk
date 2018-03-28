#pragma once

#include "Layer0Test.h"
#include <windows.h>
#include <process.h>

#include "json.h"
#include "BaseUnitTest.h"

using namespace Ruyi;
using namespace Ruyi::SDK;
using namespace boost::property_tree;
using namespace std;
using namespace Ruyi::SDK::BrainCloudApi;

class BCServiceTest : public BaseUnitTest
{
public:
	BCServiceTest(RuyiSDKContext::Endpoint endpoint = RuyiSDKContext::Endpoint::Console, string remoteAddress = "localhost");

	void BCS_Authentication_AuthenticateAnonymous(); //order(0)
	void BCS_Authentication_ClearSavedProfiedId(); //order(10)
	void BCS_Authentication_AuthenticateEmail(); //order(20)
	void BCS_Authentication_ResetEmailPassword(); //order(22)
	void BCS_Authentication_AuthenticateUniversal(); //order(30)
	void BCS_AsyncMatch_CreateMatch(); //order(50)
	void BCS_AsyncMatch_FindMatchs(); //order(52)
	void BCS_AsyncMatch_UpdateMatchSummaryData(); //order(55)
	void BCS_AsyncMatch_ReadMatch(); //order(60)
	void BCS_AsyncMatch_SubmitTurn(); //order(70)
	void BCS_AsyncMatch_ReadMatchHistory(); //order(80)
	void BCS_AsyncMatch_CompleteMatch(); //order(90)
	void BCS_AsyncMatch_FindCompleteMatches(); //order(100)
	void BCS_AsyncMatch_CreateMatchWithInitialTurn(); //order(110)
	void BCS_AsyncMatch_AbandonMatch(); //order(120)
	void BCS_AsyncMatch_DeleteMatch(); //order(130)
	void BCS_DataStream_CustomPageEvent(); //order(140)
	void BCS_DataStream_CustomScreenEvent(); //order(150)
	void BCS_DataStream_CustomTrackEvent(); //order(160)
	void BCS_Entity_CreateEntity(); //order(170)
	void BCS_Entity_GetList(); //order(190)
	void BCS_Entity_GetListCount(); //order(200)
	void BCS_Entity_GetEntity(); //order(210)
	void BCS_Entity_GetEntitiesByType(); //order(220)
	void BCS_Entity_GetPage(); //order(230)
	void BCS_Entity_GetPageOffset(); //order(240)
	void BCS_Entity_GetSharedEntityForProfileId(); //order(250)
	void BCS_Entity_GetSharedEntitiesForProfileId(); //order(260)
	void BCS_Entity_GetSharedEntitiesListForProfileId(); //order(270)
	void BCS_Entity_IncrementUserEntityData(); //order(280)
	void BCS_Entity_IncrementSharedUserEntityData(); //order(290)
	void BCS_Entity_UpdateEntity(); //order(300)
	void BCS_Entity_UpdateSharedEntity(); //order(320)
	void BCS_Entity_DeleteEntity(); //order(330)
	void BCS_Entity_UpdateSingleton(); //order(340)
	void BCS_Entity_GetSingleton(); //order(350)
	void BCS_Entity_DeleteSingleton(); //order(360)

	void BCS_Event_SendEvent(); //order(400)
	void BCS_Event_GetEvents(); //order(410)
	void BCS_Event_UpdateIncomingEventData(); //order(420)
	void BCS_Event_DeleteIncomingEvent(); //order(430)

	void BCS_File_UploadFile(); //order(440)
	void BCS_File_GetCDNUrl(); //order(445)
	void BCS_File_GetUploadProgressAndBytes(); //order(450) not finish
	void BCS_File_CancelUpload(); //order(470)
	void BCS_File_ListUserFiles(); //order(480)
	void BCS_File_DeleteFiles(); //order(490)

	void BCS_Friend_AddFriends(); //order(500)
	void BCS_Friend_ListFirends(); //order(510)
	void BCS_Friend_ReadFriendEntity(); //order(520)
	void BCS_Friend_ReadFriendsEntities(); //order(530)
	void BCS_Friend_ReadFriendUserState(); //order(540)
	void BCS_Friend_FindUserByUniversalId(); //order(550)
	void BCS_Friend_FindUserByExactName(); //order(560)
	void BCS_Friend_FindUsersBySubstrName(); //order(570)
	void BCS_Friend_GetExternalIdForProfileId(); //order(580)
	void BCS_Friend_GetProfileInfoForCredential(); //order(590)
	void BCS_Friend_GetSummaryDataForProfileId(); //order(600)
	void BCS_Friend_GetUsersOnlineStatus(); //order(610)

	void BCS_Gamification_ReadAllGamification(); //order(620)
	void BCS_Gamification_ReadXpLevelsMetaData(); //order(630)
	void BCS_Gamification_AwardAchievements(); //order(640)
	void BCS_Gamification_ReadAchievements(); //order(650)
	void BCS_Gamification_ReadAchievedAchievements(); //order(660)
	void BCS_Gamification_ReadMilestones(); //order(670)
	void BCS_Gamification_ReadMilestonesByCategory(); //order(680)
	void BCS_Gamification_ReadInProgressMilestones(); //order(690)
	void BCS_Gamification_ReadCompletedMilestones(); //order(700)
	void BCS_Gamification_ResetMilestones(); //order(710)
	void BCS_Gamification_ReadQuests(); //order(720)
	void BCS_Gamification_ReadQuestsByCategory(); //order(730)
	void BCS_Gamification_ReadQuestsWithStatus(); //order(740)
	void BCS_Gamification_ReadQuestsWithBasicPercentage(); //order(750)
	void BCS_Gamification_ReadQuestsWithComplexPercentage(); //order(760)
	void BCS_Gamification_ReadNotStartedQuests(); //order(770)
	void BCS_Gamification_ReadInProgressQuests(); //order(780)
	void BCS_Gamification_ReadCompletedQuests(); //order(790)

	void BCS_GlobalApp_ReadProperties(); //order(800)

	void BCS_GlobalEntity_CreateEntity(); //order(810)
	void BCS_GlobalEntity_CreateEntityWithIndexedId(); //order(820)
	void BCS_GlobalEntity_DoEntityUpdates(); //order(830)
	void BCS_GlobalEntity_Retrieval(); //order(835)
	void BCS_GlobalEntity_SystemEntities(); //order(840)
	void BCS_GlobalEntity_DeleteEntities(); //order(850)

	void BCS_GlobalStatistics_IncrementGlobalStats(); //order(860)
	void BCS_GlobalStatistics_ProcessStatistics(); //order(870)
	void BCS_GlobalStatistics_ReadAllGlobalStats(); //order(880)
	void BCS_GlobalStatistics_ReadGlobalStatsForCategory(); //order(890)
	void BCS_GlobalStatistics_ReadGlobalStatsSubset(); //order(900)

private:
	SubscribeClient* sdkSubscriber;

	string LoginTestUser(string user = "", string pass = "", bool bRelogin = false);

	Json::Reader JsonReader;
	Json::Value _TestUserInfoRoot;

	Json::Value _tkMatchInfo;
	string _playerId1;
	string _playerId2;

	string _entityPageContext;

	string _TestEventId;
};