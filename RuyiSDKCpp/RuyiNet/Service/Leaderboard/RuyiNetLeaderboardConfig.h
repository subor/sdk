#pragma once

#include "Response/RuyiNetListAllLeaderboardsResponse.h"
#include "RuyiNetLeaderboardType.h"
#include "RuyiNetRotationType.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Represents a leaderboard configuration.
	/// </summary>
	class RuyiNetLeaderboardConfig
	{
	public:
		RuyiNetLeaderboardConfig() {}

		RuyiNetLeaderboardConfig(RuyiNetListAllLeaderboardsResponse::Data::LeaderboardInfo& data)
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

		std::string GetLeaderboardId() { return LeaderboardId; }
		RuyiNetLeaderboardType GetLeaderboardType() { return LeaderboardType; }
		long GetResetAt() { return ResetAt; }
		RuyiNetRotationType GetRotationType() { return RotationType; }
		int GetCurrentVersionId() { return CurrentVersionId; }
		int GetMaxRetainedCount() { return MaxRetainedCount; }
		int GetRetainedVersionsCount() { return RetainedVersionsCount; }
		std::string GetData() { return Data; }

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
		/// When the leaderboard will next be reset.
		/// </summary>
		long ResetAt;

		/// <summary>
		/// The type of rotation this leaderboard uses.
		/// </summary>
		RuyiNetRotationType RotationType;

		/// <summary>
		/// The current version of the leaderboard.
		/// </summary>
		int CurrentVersionId;

		/// <summary>
		/// The maximum number of leaderboards retained.
		/// </summary>
		int MaxRetainedCount;

		/// <summary>
		/// The actual number of versions currrent retained.
		/// </summary>
		int RetainedVersionsCount;

		/// <summary>
		/// Custom data specified by the developer.
		/// </summary>
		std::string Data;
	};
}}}