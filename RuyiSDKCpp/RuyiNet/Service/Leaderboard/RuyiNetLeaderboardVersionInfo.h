#pragma once

#include "Response/RuyiNetGetGlobalLeaderboardVersionsResponse.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Represents a leaderboard version.
	/// </summary>
	class RuyiNetLeaderboardVersionInfo 
	{
	public:
		RuyiNetLeaderboardVersionInfo();
		RuyiNetLeaderboardVersionInfo(RuyiNetGetGlobalLeaderboardVersionsResponse::Data::VersionInfo& data);
		
		int GetVersionId();
		long GetStartingAt();
		long GetEndingAt();

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