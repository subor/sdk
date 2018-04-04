#include "RuyiNetTest.h"

#include "RuyiNet/Response/RuyiNetProfile.h"
#include "RuyiNet/Service/RuyiNetFriendService.h"

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
}
