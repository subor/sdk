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
		RuyiNetPlayerScore() {}
		RuyiNetPlayerScore(RuyiNetGetPlayerScoreResponse::Data::Score& data)
		{
			Score = data.score;
			Data = data.data;
			CreatedAt = data.createdAt;
			UpdatedAt = data.updatedAt;
			LeaderboardId = data.leaderboardId;
			VersionId = data.versionId;
		}
		RuyiNetPlayerScore(RuyiNetGetPlayerScoresFromLeaderboardsResponse::Data::Score& data)
		{
			Score = data.score;
			Data = data.data;
			CreatedAt = data.createdAt;
			UpdatedAt = data.updatedAt;
			LeaderboardId = data.leaderboardId;
			VersionId = data.versionId;
		}

		int GetScore() { return Score; }
		std::string GetData() { return Data; }
		long GetCreatedAt() { return CreatedAt; }
		long GetUpdatedAt() { return UpdatedAt; }
		std::string GetLeaderboardId() { return LeaderboardId; }
		int GetVersionId() { return VersionId; }

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