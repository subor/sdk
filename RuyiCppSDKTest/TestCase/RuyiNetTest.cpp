#include "RuyiNetTest.h"

#include "RuyiNet/Response/RuyiNetResponse.h"
#include "RuyiNet/Response/RuyiNetProfile.h"

#include "RuyiNet/Service/RuyiNetFriendService.h"
#include "RuyiNet/Service/RuyiNetLeaderboardService.h"
#include "RuyiNet/Service/RuyiNetCloudService.h"
#include "RuyiNet/Service/RuyiNetLobbyService.h"
#include "RuyiNet/Service/RuyiNetPartyService.h"
#include "RuyiNet/Service/RuyiNetTelemetryService.h"

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
	ruyiSDK->Storage->GetLocalPath(result, "/<HDD0>/n.txt");
	
	RuyiNetResponse response1;
	const RuyiString persistentDataPath = ToRuyiString(result.path);
	ruyiSDK->RuyiNet->GetCloudService()->BackupData(0, persistentDataPath, response1);

	Assert::IsTrue(STATUS_OK == response1.status);
}

void RuyiNetTest::LobbyServiceTest()
{
	//test: create lobby
	RuyiNetLobbyResponse response1;
	ruyiSDK->RuyiNet->GetLobbyService()->CreateLobby(0, 4, Ruyi::RuyiNetLobbyType::PLAYER, response1);
	
	Assert::IsTrue(STATUS_OK == response1.status);

	//test: find lobby
	RuyiNetLobbyFindResponse response2;
	std::list<RuyiNetLobby*> lobbies;
	ruyiSDK->RuyiNet->GetLobbyService()->FindLobbies(0, 10, Ruyi::RuyiNetLobbyType::PLAYER, lobbies, response2);

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