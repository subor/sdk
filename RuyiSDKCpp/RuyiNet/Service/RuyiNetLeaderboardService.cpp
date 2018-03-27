#include "RuyiNetLeaderboardService.h"

namespace Ruyi
{
	RuyiNetLeaderboardService::RuyiNetLeaderboardService(RuyiNetClient * client)
		: RuyiNetService(client)
	{}

	void RuyiNetLeaderboardService::CreateLeaderboard(int index, const RuyiString & id, RuyiNetLeaderboardType type,
		RuyiNetRotationType rotationType, const RuyiNetTask<json>::CallbackType & callback)
	{
		auto leaderboardId = GetLeaderboardId(id);
		EnqueueTask<json>([this, &index, &leaderboardId, &type, &rotationType]()->std::string
		{
			json payload = 
			{
				{ "leaderboardId", leaderboardId },
				{ "type", type._to_string() },
				{ "rotationType", rotationType._to_string() },
				{ "versionsToRetain", 1 }
			};

			return RunParentScript(index, "CreateLeaderboard", payload);
		}, callback);
	}

	void RuyiNetLeaderboardService::GetGlobalLeaderboardPage(int index, const RuyiString & id, SDK::BrainCloudApi::SortOrder::type sort,
		int startIndex, int endIndex, const RuyiNetTask<RuyiNetLeaderboardResponse>::CallbackType & callback)
	{
		auto leaderboardId = GetLeaderboardId(id);
		auto sortString = (sort == SDK::BrainCloudApi::SortOrder::HIGH_TO_LOW) ? "HIGH_TO_LOW" : "LOW_TO_HIGH";
		EnqueueTask<json>([this, &index, &leaderboardId, &sortString, &startIndex, &endIndex]()->std::string
		{
			json payload =
			{
				{ "leaderboardId", leaderboardId },
				{ "sort", sortString },
				{ "startIndex", startIndex },
				{ "endIndex", endIndex }
			};

			return RunParentScript(index, "GetGlobalLeaderboardPage", payload);
		}, callback);
	}

	void RuyiNetLeaderboardService::GetGlobalLeaderboardView(int index, const RuyiString & id, SDK::BrainCloudApi::SortOrder::type sort,
		int beforeCount, int afterCount, const RuyiNetTask<RuyiNetLeaderboardResponse>::CallbackType & callback)
	{
		auto leaderboardId = GetLeaderboardId(id);
		auto sortString = (sort == SDK::BrainCloudApi::SortOrder::HIGH_TO_LOW) ? "HIGH_TO_LOW" : "LOW_TO_HIGH";
		EnqueueTask<json>([this, &index, &leaderboardId, &sortString, &beforeCount, &afterCount]()->std::string
		{
			json payload =
			{
				{ "leaderboardId", leaderboardId },
				{ "sort", sortString },
				{ "beforeCount", beforeCount },
				{ "afterCount", afterCount }
			};

			return RunParentScript(index, "GetGlobalLeaderboardView", payload);
		}, callback);
	}

	void RuyiNetLeaderboardService::GetSocialLeaderboard(int index, const RuyiString & id, bool replaceName,
		const RuyiNetTask<RuyiNetSocialLeaderboardResponse>::CallbackType & callback)
	{
		auto leaderboardId = GetLeaderboardId(id);
		EnqueueTask<json>([this, &index, &leaderboardId, &replaceName]()->std::string
		{
			json payload =
			{
				{ "leaderboardId", leaderboardId },
				{ "replaceName", replaceName }
			};

			return RunParentScript(index, "GetSocialLeaderboard", payload);
		}, callback);
	}

	void RuyiNetLeaderboardService::PostScoreToLeaderboard(int index, const RuyiString & id, int score,
		const RuyiNetTask<json>::CallbackType & callback)
	{
		auto leaderboardId = GetLeaderboardId(id);
		EnqueueTask<json>([this, &index, &leaderboardId, &score]()->std::string
		{
			json payload =
			{
				{ "leaderboardId", leaderboardId },
				{ "score", score }
			};

			return RunParentScript(index, "PostScoreToLeaderboard", payload);
		}, callback);
	}

	std::string RuyiNetLeaderboardService::GetLeaderboardId(const RuyiString & id)
	{
		RuyiString result = mClient->GetAppId() + RUYI_STR("_") + id;
		return ToString(result);
	}
}