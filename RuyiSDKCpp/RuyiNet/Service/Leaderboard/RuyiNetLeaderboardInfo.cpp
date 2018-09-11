#include "RuyiNetLeaderboardInfo.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetLeaderboardInfo::RuyiNetLeaderboardInfo() {}
	RuyiNetLeaderboardInfo::RuyiNetLeaderboardInfo(RuyiNetGetGlobalLeaderboardVersionsResponse::Data& data)
	{
		LeaderboardId = data.leaderboardId;
		LeaderboardType = ConvertStringToRuyiNetLeaderboardType(data.leaderboardType);
		RotationType = ConvertStringToRuyiNetRotationType(data.rotationType);
		RetainedCount = data.retainedCount;

		std::for_each(data.versions.begin(), data.versions.end(), [&](RuyiNetGetGlobalLeaderboardVersionsResponse::Data::VersionInfo& info)
		{
			Versions.push_back(new RuyiNetLeaderboardVersionInfo(info));
		});
	}

	void RuyiNetLeaderboardInfo::GetData(RuyiNetGetGlobalLeaderboardVersionsResponse::Data& data)
	{
		LeaderboardId = data.leaderboardId;
		LeaderboardType = ConvertStringToRuyiNetLeaderboardType(data.leaderboardType);
		RotationType = ConvertStringToRuyiNetRotationType(data.rotationType);
		RetainedCount = data.retainedCount;

		std::for_each(data.versions.begin(), data.versions.end(), [&](RuyiNetGetGlobalLeaderboardVersionsResponse::Data::VersionInfo& info)
		{
			Versions.push_back(new RuyiNetLeaderboardVersionInfo(info));
		});
	}

	std::string RuyiNetLeaderboardInfo::GetLeaderboardId() { return LeaderboardId; }
	RuyiNetLeaderboardType RuyiNetLeaderboardInfo::GetLeaderboardType() { return LeaderboardType; }
	RuyiNetRotationType RuyiNetLeaderboardInfo::GetRotationType() { return RotationType; }
	int RuyiNetLeaderboardInfo::GetRetainedCount() { return RetainedCount; }
	std::vector<RuyiNetLeaderboardVersionInfo*>& RuyiNetLeaderboardInfo::GetVersions() { return Versions; }


}}}