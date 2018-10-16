#include "RuyiNetLeaderboardVersionInfo.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetLeaderboardVersionInfo::RuyiNetLeaderboardVersionInfo() {}
	RuyiNetLeaderboardVersionInfo::RuyiNetLeaderboardVersionInfo(RuyiNetGetGlobalLeaderboardVersionsResponse::Data::VersionInfo& data)
	{
		VersionId = data.versionId;
		StartingAt = data.startingAt;
		EndingAt = data.endingAt;
	}

	int RuyiNetLeaderboardVersionInfo::GetVersionId() { return VersionId; }
	long RuyiNetLeaderboardVersionInfo::GetStartingAt() { return StartingAt; }
	long RuyiNetLeaderboardVersionInfo::GetEndingAt() { return EndingAt; }
}}}