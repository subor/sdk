#include "RuyiNetFriendService.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetFriendService::RuyiNetFriendService(RuyiNetClient * client)
		: RuyiNetService(client)
	{}

	void RuyiNetFriendService::AddFriend(int index, const std::string& profileId, RuyiNetAddRemoveFriendResponse& response)
	{
		nlohmann::json payloadJson;

		payloadJson["profileId"] = profileId;

		std::string responseStr = RunParentScript(index, "AddFriend", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetFriendService::RemoveFriend(int index, const std::string& profileId, RuyiNetAddRemoveFriendResponse& response)
	{
		nlohmann::json payloadJson;
		payloadJson["profileId"] = profileId;
		std::string responseStr = RunParentScript(index, "RemoveFriend", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetFriendService::ListFriends(int index, RuyiNetFriendListResponse& response)
	{
		nlohmann::json payloadJson;
		std::string strResponse = RunParentScript(index, "ListFriends", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(strResponse);
		response.parseJson(retJson);
	}

	void RuyiNetFriendService::GetProfile(int index, const std::string & profileId, RuyiNetGetProfileResponse& response)
	{
		nlohmann::json payloadJson;
		payloadJson["profileId"] = profileId;
		std::string strResponse = RunParentScript(index, "GetProfile", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(strResponse);
		response.parseJson(retJson);
	}
	
	void RuyiNetFriendService::GetProfiles(int index, const std::list<std::string>& profileIds, RuyiNetGetProfilesResponse& response)
	{
		nlohmann::json payloadJson;

		payloadJson["profileId"] = profileIds;
		std::string strResponse = RunParentScript(index, "GetProfiles", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(strResponse);
		response.parseJson(retJson);
	}
}}} 