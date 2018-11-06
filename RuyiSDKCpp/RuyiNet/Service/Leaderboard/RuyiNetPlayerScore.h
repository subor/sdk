#pragma once

#include "Response/RuyiNetGetPlayerScoreResponse.h"
#include "Response/RuyiNetGetPlayerScoresFromLeaderboardsResponse.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Represents a player's score on a leaderboard.
	/// </summary>
	class RuyiNetPlayerScore 
	{
	public:
		RuyiNetPlayerScore();
		RuyiNetPlayerScore(RuyiNetGetPlayerScoreResponse::Data::Score& data);
		RuyiNetPlayerScore(RuyiNetGetPlayerScoresFromLeaderboardsResponse::Data::Score& data);

		void GetData(RuyiNetGetPlayerScoreResponse::Data::Score& data);
		void GetData(RuyiNetGetPlayerScoresFromLeaderboardsResponse::Data::Score& data);

		int GetScore();
		std::string GetData();
		long GetCreatedAt();
		long GetUpdatedAt();
		std::string GetLeaderboardId();
		int GetVersionId();

		///<summary>
		/// Rescord status of response
		///</summary>
		int Status;

	private:
		/// <summary>
        /// The player's score.
        /// </summary>
		int Score;

        /// <summary>
        /// Data specified by the game developer.
        /// </summary>
		std::string Data;

        /// <summary>
        /// When this score entry was created.
        /// </summary>
		long CreatedAt;

        /// <summary>
        /// When this score entry was last updated.
        /// </summary>
		long UpdatedAt;

        /// <summary>
        /// The ID of the leaderboard this score is an entry for.
        /// </summary>
		std::string LeaderboardId;

        /// <summary>
        /// The version of the leaderboard this score is an entry for.
        /// </summary>
		int VersionId;
	};
}}}