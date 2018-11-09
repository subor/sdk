#include "RuyiNetLeaderboardConfig.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetLeaderboardConfig::RuyiNetLeaderboardConfig() {}

	RuyiNetLeaderboardConfig::RuyiNetLeaderboardConfig(RuyiNetListAllLeaderboardsResponse::Data::LeaderboardInfo& data)
	{
		GetData(data);
	}

	void RuyiNetLeaderboardConfig::GetData(RuyiNetListAllLeaderboardsResponse::Data::LeaderboardInfo& data)
	{
		LeaderboardId = data.leaderboardId;
		LeaderboardType = ConvertStringToRuyiNetLeaderboardType(data.leaderboardType);
		RotationType = ConvertStringToRuyiNetRotationType(data.rotationType);
		ResetAt = data.resetAt;
		CurrentVersionId = data.currentVersionId;
		MaxRetainedCount = data.maxRetainedCount;
		RetainedVersionsCount = data.retainedVersionsCount;
		Data = data.data;
	}

	std::string RuyiNetLeaderboardConfig::GetLeaderboardId() { return LeaderboardId; }
	RuyiNetLeaderboardType RuyiNetLeaderboardConfig::GetLeaderboardType() { return LeaderboardType; }
	long RuyiNetLeaderboardConfig::GetResetAt() { return ResetAt; }
	RuyiNetRotationType RuyiNetLeaderboardConfig::GetRotationType() { return RotationType; }
	int RuyiNetLeaderboardConfig::GetCurrentVersionId() { return CurrentVersionId; }
	int RuyiNetLeaderboardConfig::GetMaxRetainedCount() { return MaxRetainedCount; }
	int RuyiNetLeaderboardConfig::GetRetainedVersionsCount() { return RetainedVersionsCount; }
	std::string RuyiNetLeaderboardConfig::GetData() { return Data; }

}}}