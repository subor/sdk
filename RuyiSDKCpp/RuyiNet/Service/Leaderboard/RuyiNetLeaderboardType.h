#pragma once

#include <string>

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// The type of a leaderboard.
	/// </summary>
	enum RuyiNetLeaderboardType
	{
		/// <summary>
		/// The leaderboard will keep track of the highest value.
		/// </summary>
		HIGH_VALUE,

		/// <summary>
		/// The leaderboard will total up all values posted.
		/// </summary>
		CUMULATIVE,

		/// <summary>
		/// The leaderboard will only keep the last value posted.
		/// </summary>
		LAST_VALUE,

		/// <summary>
		/// The leaderboard will keep the lowest value.
		/// </summary>
		LOW_VALUE,
	};
	
	RuyiNetLeaderboardType ConvertStringToRuyiNetLeaderboardType(std::string str);
}}} 