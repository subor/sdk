#pragma once

#include "Response/RuyiNetGetGlobalLeaderboardVersionsResponse.h"
#include "RuyiNetLeaderboardType.h"
#include "RuyiNetRotationType.h"
#include "RuyiNetLeaderboardVersionInfo.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Represents a leaderboard on RuyiNet.
	/// </summary>
	class RuyiNetLeaderboardInfo
	{
	public:
		
		RuyiNetLeaderboardInfo();
		RuyiNetLeaderboardInfo(RuyiNetGetGlobalLeaderboardVersionsResponse::Data& data);

		void GetData(RuyiNetGetGlobalLeaderboardVersionsResponse::Data& data);

		std::string GetLeaderboardId();
		RuyiNetLeaderboardType GetLeaderboardType();
		RuyiNetRotationType GetRotationType();
		int GetRetainedCount();
		std::vector<RuyiNetLeaderboardVersionInfo*>& GetVersions();

		///<summary>
		/// Rescord status of response
		///</summary>
		int Status;

	private:
		/// <summary>
        /// The ID of the leaderboard.
        /// </summary>
		std::string LeaderboardId;

        /// <summary>
        /// The type of leaderboard.
        /// </summary>
		RuyiNetLeaderboardType LeaderboardType;

        /// <summary>
        /// The type of leaderboard rotation.
        /// </summary>
		RuyiNetRotationType RotationType;

        /// <summary>
        /// The number of versions retained.
        /// </summary>
		int RetainedCount;

        /// <summary>
        /// A list of versions currently retained.
        /// </summary>
		std::vector<RuyiNetLeaderboardVersionInfo*> Versions;
	};
}}}