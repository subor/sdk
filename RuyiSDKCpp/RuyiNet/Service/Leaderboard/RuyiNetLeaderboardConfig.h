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
		RuyiNetLeaderboardConfig();

		RuyiNetLeaderboardConfig(RuyiNetListAllLeaderboardsResponse::Data::LeaderboardInfo& data);

		void GetData(RuyiNetListAllLeaderboardsResponse::Data::LeaderboardInfo& data);

		std::string GetLeaderboardId();
		RuyiNetLeaderboardType GetLeaderboardType();
		long GetResetAt();
		RuyiNetRotationType GetRotationType();
		int GetCurrentVersionId();
		int GetMaxRetainedCount();
		int GetRetainedVersionsCount();
		std::string GetData();

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