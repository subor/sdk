#include "RuyiNetTest.h"

#include "RuyiNet/Response/RuyiNetResponse.h"
#include "RuyiNet/Response/RuyiNetProfile.h"

#include "RuyiNet/Service/Friend/RuyiNetFriendService.h"
#include "RuyiNet/Service/Leaderboard/RuyiNetLeaderboardService.h"
#include "RuyiNet/Service/Cloud/RuyiNetCloudService.h"
#include "RuyiNet/Service/Lobby/RuyiNetLobbyService.h"
#include "RuyiNet/Service/Party/RuyiNetPartyService.h"
#include "RuyiNet/Service/Telemetry/RuyiNetTelemetryService.h"
#include "RuyiNet/Service/UserFile/RuyiNetUserFileService.h"
#include "RuyiNet/Service/Gamification/RuyiNetGamificationService.h"
#include "RuyiNet/Service/Patch/RuyiNetPatchService.h"

#include "boost/container/detail/json.hpp"

#define TEST_APP_ID "11499"
#define TEST_APP_SECRET "Shooter"
#define STATUS_OK 200

RuyiNetTest::RuyiNetTest(RuyiSDKContext::Endpoint endpoint, std::string remoteAddress) :BaseUnitTest(endpoint, remoteAddress)
{

	Logger::WriteMessage("RuyiNetClient Init !!!\n");
}

void RuyiNetTest::RuyiNet_Initialize() 
{
	ruyiSDK->RuyiNet->Initialise(TEST_APP_ID, TEST_APP_SECRET);

	const RuyiNetProfile* profile = ruyiSDK->RuyiNet->GetPlayer(0);

	if (nullptr != profile) 
	{
		Logger::WriteMessage(("profileID:" + profile->profileId + "\n").c_str());
		Logger::WriteMessage(("profileName:" + profile->profileName + "\n").c_str());
		Logger::WriteMessage(("email:" + profile->email + "\n").c_str());
		Logger::WriteMessage(("pictureUrl:" + profile->pictureUrl + "\n").c_str());
	} else 
	{
		Logger::WriteMessage("Null Profile\n");
	}

	Assert::IsTrue(profile != nullptr, L"No player Profile");
}

void RuyiNetTest::Login() 
{
	//ruyiSDK->RuyiNet->Login();
	std::string ret;
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
	ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "godenzzm", "111", true, 0);

	Logger::WriteMessage(("RuyiNetTest::Login() ret:" + ret + "\n").c_str());

	nlohmann::json retJson = nlohmann::json::parse(ret);	

	Assert::IsTrue(!retJson["status"].is_null(), L"Json Format Error"  );
	Assert::IsTrue(STATUS_OK == retJson["status"], L"Login Failure");
}

void RuyiNetTest::FriendServiceTest()
{
	//test: get friends list
	RuyiNetFriendListResponse response;
	ruyiSDK->RuyiNet->GetFriendService()->ListFriends(0, response);

	Logger::WriteMessage(("FriendServiceTest friendsList status:" + to_string(response.status) + "\n").c_str());
	Logger::WriteMessage(("FriendServiceTest friendsList friends num:" + to_string(response.data.response.friends.size()) + "\n").c_str());

	std::vector<RuyiNetFriendListResponse::Data::Response::Friend>::iterator it;
	for (it = response.data.response.friends.begin(); it != response.data.response.friends.end(); ++it)
	{
		Logger::WriteMessage(("FriendServiceTest friendsList profileId:" + it->playerId + "\n").c_str());
		Logger::WriteMessage(("FriendServiceTest friendsList name:" + it->name + "\n").c_str());
	}

	Assert::IsTrue(STATUS_OK == response.status);
}

void RuyiNetTest::LeaderboardServiceTest()
{
	//test: create leaderboard
	RuyiNetResponse response1;
	ruyiSDK->RuyiNet->GetLeaderboardService()->CreateLeaderboard(0, TEST_APP_ID, RuyiNetLeaderboardType::LOW_VALUE, RuyiNetRotationType::DAILY, response1);

	Assert::IsTrue(STATUS_OK == response1.status);

	//test: get global leaderboard page
	RuyiNetLeaderboardResponse response2;
	ruyiSDK->RuyiNet->GetLeaderboardService()->GetGlobalLeaderboardPage(0, TEST_APP_ID, SDK::BrainCloudApi::SortOrder::type::HIGH_TO_LOW, 0, 10, response2);

	std::for_each(response2.data.response.leaderboard.begin(), response2.data.response.leaderboard.end(), [&](RuyiNetLeaderboardResponse::Data::Response::LeaderboardData& data)
	{
		Logger::WriteMessage(("LeaderboardServiceTest GetGlobalLeaderboardPage rank:" + to_string(data.rank) + " playerId:" + data.playerId + " score:" + to_string(data.score)).c_str());
	});

	Assert::IsTrue(STATUS_OK == response2.status);

	//test: get global leaderboard view
	RuyiNetLeaderboardResponse response3;
	ruyiSDK->RuyiNet->GetLeaderboardService()->GetGlobalLeaderboardView(0, TEST_APP_ID, SDK::BrainCloudApi::SortOrder::type::HIGH_TO_LOW, 0, 10, response3);

	std::for_each(response3.data.response.leaderboard.begin(), response3.data.response.leaderboard.end(), [&](RuyiNetLeaderboardResponse::Data::Response::LeaderboardData& data)
	{
		Logger::WriteMessage(("LeaderboardServiceTest GetLeaderboardService rank:" + to_string(data.rank) + " playerId:" + data.playerId + " score:" + to_string(data.score)).c_str());
	});

	Assert::IsTrue(STATUS_OK == response3.status);

	//test: get social leaderboard 
	RuyiNetSocialLeaderboardResponse response4;
	ruyiSDK->RuyiNet->GetLeaderboardService()->GetSocialLeaderboard(0, TEST_APP_ID, "", response4);

	std::for_each(response4.data.response.social_leaderboard.begin(), response4.data.response.social_leaderboard.end(), [&](RuyiNetSocialLeaderboardResponse::Data::Response::LeaderboardData& data)
	{
		Logger::WriteMessage(("LeaderboardServiceTest GetLeaderboardService playerId:" + data.playerId + " score:" + to_string(data.score)).c_str());
	});

	Assert::IsTrue(STATUS_OK == response4.status);

	//test: post score to leaderboard
	RuyiNetResponse response5;
	ruyiSDK->RuyiNet->GetLeaderboardService()->PostScoreToLeaderboard(0, TEST_APP_ID, 100, response5);

	Assert::IsTrue(STATUS_OK == response5.status);
}

void RuyiNetTest::CloudServiceTest()
{
	//test: backup data
	StorageLayer::GetLocalPathResult result;
	ruyiSDK->Storage->GetLocalPath(result, "/");
	std::string localPath = result.path + "Resources/Configs/SystemSetting/SystemSetting.cfg";
	
	Logger::WriteMessage(("CloudServiceTest localPath:" + localPath).c_str());

	RuyiNetResponse response1;
	const RuyiString persistentDataPath = ToRuyiString(localPath);
	ruyiSDK->RuyiNet->GetCloudService()->BackupData(0, persistentDataPath, response1);

	Assert::IsTrue(STATUS_OK == response1.status);
}

void RuyiNetTest::LobbyServiceTest()
{
	//test: create lobby
	RuyiNetLobbyResponse response1;
	ruyiSDK->RuyiNet->GetLobbyService()->CreateLobby(0, 4, RuyiNetLobbyType::PLAYER, response1);
	
	Assert::IsTrue(STATUS_OK == response1.status);

	//test: find lobby
	RuyiNetLobbyFindResponse response2;
	std::list<RuyiNetLobby*> lobbies;
	ruyiSDK->RuyiNet->GetLobbyService()->FindLobbies(0, 10, RuyiNetLobbyType::PLAYER, lobbies, response2);

	Assert::IsTrue(STATUS_OK == response2.status);

	//test: join found lobby, start game, and leave joined lobby
	std::for_each(lobbies.begin(), lobbies.end(), [&](RuyiNetLobby* lobby) 
	{
		Logger::WriteMessage(("LobbyServiceTest FindLobbies lobby Id:" + lobby->GetLobbyId()).c_str());

		//test: join looby
		RuyiNetLobbyResponse response3;
		ruyiSDK->RuyiNet->GetLobbyService()->JoinLobby(0, lobby->GetLobbyId(), response3);

		Assert::IsTrue(STATUS_OK == response3.status);

		//test: start game
		RuyiNetResponse response4;
		ruyiSDK->RuyiNet->GetLobbyService()->StartGame(0, lobby->GetLobbyId(), "Ruyi", response4);
		
		Assert::IsTrue(STATUS_OK == response4.status);

		//test: leave lobby
		RuyiNetResponse response5;
		ruyiSDK->RuyiNet->GetLobbyService()->LeaveLobby(0, lobby->GetLobbyId(), response4);

		Assert::IsTrue(STATUS_OK == response5.status);
	});

	
}

void RuyiNetTest::PartyServiceTest()
{
	//test: get player party info
	RuyiNetGetPartyInfoResponse response1;
	ruyiSDK->RuyiNet->GetPartyService()->GetPartyInfo(0, response1);

	Assert::IsTrue(STATUS_OK == response1.status);

	//test: get player members of party info
	RuyiNetGetProfilesResponse response2;
	ruyiSDK->RuyiNet->GetPartyService()->GetPartyMembersInfo(0, response2);

	Assert::IsTrue(STATUS_OK == response2.status);

	//test: invite someone join party
	RuyiNetFriendListResponse response3;
	ruyiSDK->RuyiNet->GetFriendService()->ListFriends(0, response3);
	if (response3.data.response.friends.size() > 0)
	{
		RuyiNetFriendListResponse::Data::Response::Friend& f = response3.data.response.friends[0];

		RuyiNetResponse response4;
		ruyiSDK->RuyiNet->GetPartyService()->SendPartyInvitation(0, f.playerId, response4);

		Assert::IsTrue(STATUS_OK == response4.status);
	}
}

void RuyiNetTest::TelemetryServiceTest()
{
	//test: statr session
	RuyiNetTelemetrySessionResponse response1;
	RuyiNetTelemetrySession session1;
	ruyiSDK->RuyiNet->GetTelemetryService()->StartTelemetrySession(0, response1, session1);

	Logger::WriteMessage(("TelemetryServiceTest StartTelemetrySession id:" + session1.GetId()).c_str());

	Assert::IsTrue(STATUS_OK == response1.status);

	//test: log session
	std::string eventType = "";

	RuyiNetResponse response2;
	ruyiSDK->RuyiNet->GetTelemetryService()->LogTelemetryEvent(0, session1.GetId(), eventType, response2);

	Assert::IsTrue(STATUS_OK == response2.status);

	//test: start event
	RuyiNetResponse response3;
	ruyiSDK->RuyiNet->GetTelemetryService()->StartTelemetryEvent(0, session1.GetId(), eventType, response3);

	Assert::IsTrue(STATUS_OK == response3.status);

	//test: end event
	RuyiNetResponse response4;
	ruyiSDK->RuyiNet->GetTelemetryService()->EndTelemetryEvent(0, session1.GetId(), eventType, response4);

	Assert::IsTrue(STATUS_OK == response4.status);

	//test:: end session
	RuyiNetResponse response5;
	ruyiSDK->RuyiNet->GetTelemetryService()->EndTelemetrySession(0, session1.GetId(), response5);

	Assert::IsTrue(STATUS_OK == response5.status);
}

void RuyiNetTest::UserFileServiceTest() 
{
	StorageLayer::GetLocalPathResult result;
	ruyiSDK->Storage->GetLocalPath(result, "/");
	std::string localPath = result.path + "Resources/Configs/SystemSetting/SystemSetting.cfg";
	std::string cloudPath = "test/files";
	std::string cloudFile = "testCloudFile_shared.cfg";

	RuyiNetUploadFileResponse response1;
	ruyiSDK->RuyiNet->GetUserFileService()->UploadFile(0, cloudPath, cloudFile, true, true, localPath, response1);

	Assert::IsTrue(STATUS_OK == response1.status);

	std::string uploadId = response1.data.fileDetails.uploadId;
	ruyiSDK->RuyiNet->GetUserFileService()->CancelUpload(0, uploadId);
	
	double progress = ruyiSDK->RuyiNet->GetUserFileService()->GetUploadProgress(0, uploadId);

	Assert::IsTrue(progress <= 0);

	RuyiNetListUserFilesResponse response2;
	ruyiSDK->RuyiNet->GetUserFileService()->ListUserFiles(0, response2);

	Assert::IsTrue(STATUS_OK == response2.status);

	RuyiNetUploadFileResponse response3;
	ruyiSDK->RuyiNet->GetUserFileService()->DeleteUserFile(0, cloudPath, cloudFile, response3);

	Assert::IsTrue(STATUS_OK == response3.status || (400 == response3.status));

	RuyiNetGetCDNResponse response4;
	ruyiSDK->RuyiNet->GetUserFileService()->GetCDNUrl(0, cloudPath, cloudFile, response4);

	Logger::WriteMessage(("GetCDNUrl cdn url:" + response4.data.cdnUrl).c_str());

	Assert::IsTrue(STATUS_OK == response4.status);
}

void RuyiNetTest::GamificationServiceTest() 
{
	RuyiNetAchievement achievement;
	std::string achievementId = ""; //not a clue about id value, update later
	ruyiSDK->RuyiNet->GetGamificationService()->AwardAchievement(0, achievementId, achievement);

	Assert::IsTrue(0 == achievement.GameId.compare(""));

	std::vector<std::string> achievementIds;
	std::vector<RuyiNetAchievement*> achievements;
	ruyiSDK->RuyiNet->GetGamificationService()->AwardAchievements(0, achievementIds, achievements);

	Assert::IsTrue(achievements.size() > 0);

	int includeMetaData = 0; //not a clue about this value;
	achievements.clear();
	ruyiSDK->RuyiNet->GetGamificationService()->ReadAchievedAchievements(0, includeMetaData, achievements);

	Assert::IsTrue(achievements.size() > 0);

	achievements.clear();
	ruyiSDK->RuyiNet->GetGamificationService()->ReadAchievements(0, includeMetaData, achievements);
	
	Assert::IsTrue(achievements.size() > 0);
}

void RuyiNetTest::PatchServiceTest() 
{
	RuyiNetGameManifest gameManifest;
	std::string gameId = "Shooter";
	ruyiSDK->RuyiNet->GetPatchService()->GetGameManifest(0, gameId, gameManifest);

	Assert::IsTrue(STATUS_OK == gameManifest.Status);
}