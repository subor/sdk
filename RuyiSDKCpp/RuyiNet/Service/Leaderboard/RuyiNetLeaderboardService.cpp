#include "RuyiNetLeaderboardService.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetLeaderboardService::RuyiNetLeaderboardService(RuyiNetClient * client)
		: RuyiNetService(client)
	{}

	void RuyiNetLeaderboardService::CreateLeaderboard(int index, const std::string& id, RuyiNetLeaderboardType type, RuyiNetRotationType rotationType, RuyiNetResponse& response)
	{		
		auto leaderboardId = GetLeaderboardId(id);

		nlohmann::json payloadJson;

		payloadJson["leaderboardId"] = leaderboardId;
		payloadJson["type"] = (int)type;
		payloadJson["rotationType"] = (int)rotationType;
		payloadJson["versionsToRetain"] = 1;

		std::string responseStr = RunParentScript(index, "CreateLeaderboard", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}
	
	void RuyiNetLeaderboardService::GetGlobalLeaderboardPage(int index, const std::string& id, SDK::BrainCloudApi::SortOrder::type sort,
		int startIndex, int endIndex, RuyiNetLeaderboardResponse& response)
	{
		auto leaderboardId = GetLeaderboardId(id);
		auto sortString = (sort == SDK::BrainCloudApi::SortOrder::HIGH_TO_LOW) ? "HIGH_TO_LOW" : "LOW_TO_HIGH";

		nlohmann::json payloadJson;

		payloadJson["leaderboardId"] = leaderboardId;
		payloadJson["sort"] = sortString;
		payloadJson["startIndex"] = startIndex;
		payloadJson["endIndex"] = endIndex;

		std::string responseStr = RunParentScript(index, "GetGlobalLeaderboardPage", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}
	
	void RuyiNetLeaderboardService::GetGlobalLeaderboardView(int index, const std::string& id, SDK::BrainCloudApi::SortOrder::type sort,
		int beforeCount, int afterCount, RuyiNetLeaderboardResponse& response)
	{
		auto leaderboardId = GetLeaderboardId(id);
		auto sortString = (sort == SDK::BrainCloudApi::SortOrder::HIGH_TO_LOW) ? "HIGH_TO_LOW" : "LOW_TO_HIGH";

		nlohmann::json payloadJson;

		payloadJson["leaderboardId"] = leaderboardId;
		payloadJson["sort"] = sortString;
		payloadJson["beforeCount"] = beforeCount;
		payloadJson["afterCount"] = afterCount;

		std::string responseStr = RunParentScript(index, "GetGlobalLeaderboardView", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}
	
	void RuyiNetLeaderboardService::GetSocialLeaderboard(int index, const std::string& id, bool replaceName,
		RuyiNetSocialLeaderboardResponse& response)
	{
		auto leaderboardId = GetLeaderboardId(id);

		nlohmann::json payloadJson;

		payloadJson["leaderboardId"] = leaderboardId;
		payloadJson["replaceName"] = replaceName;

		std::string responseStr = RunParentScript(index, "GetSocialLeaderboard", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}
	
	void RuyiNetLeaderboardService::PostScoreToLeaderboard(int index, const std::string& id, int score, RuyiNetResponse& response)
	{
		auto leaderboardId = GetLeaderboardId(id);

		nlohmann::json payloadJson;

		payloadJson["leaderboardId"] = leaderboardId;
		payloadJson["score"] = score;

		std::string responseStr = RunParentScript(index, "PostScoreToLeaderboard", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	std::string RuyiNetLeaderboardService::GetLeaderboardId(const std::string& id)
	{
		//RuyiString result = mClient->GetAppId() + RUYI_STR("_") + id;
		//return ToString(result);
		std::string result = mClient->GetAppId() + "_" + id;

		return result;
	}
}}} 