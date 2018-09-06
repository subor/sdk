#pragma once

#include "Response/RuyiNetGetGlobalLeaderboardVersionsResponse.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Represents a leaderboard version.
	/// </summary>
	class RuyiNetLeaderboardVersionInfo 
	{
	public:
		RuyiNetLeaderboardVersionInfo() {}
		RuyiNetLeaderboardVersionInfo(RuyiNetGetGlobalLeaderboardVersionsResponse::Data::VersionInfo& data) 
		{
			VersionId = data.versionId;
			StartingAt = data.startingAt;
			EndingAt = data.endingAt;
		}
		
		int GetVersionId() { return VersionId; }
		long GetStartingAt() { return StartingAt; }
		long GetEndingAt() { return EndingAt; }

	private:
		/// <summary>
        /// The ID of this version.
        /// </summary>
		int VersionId;

        /// <summary>
        /// The time this version starts.
        /// </summary>
		long StartingAt;

        /// <summary>
        /// The time this version ends.
        /// </summary>
		long EndingAt;
	};

}}}