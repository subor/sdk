#pragma once

#include <string.h>

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// The type of a leaderboard.
	/// </summary>
	enum RuyiNetLeaderboardType
	{
		NONE,

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

	RuyiNetLeaderboardType ConvertStringToRuyiNetLeaderboardType(std::string str)
	{
		RuyiNetLeaderboardType ret = RuyiNetLeaderboardType::NONE;

		if (0 == str.compare("HIGH_VALUE"))
		{
			ret = RuyiNetLeaderboardType::HIGH_VALUE;
		}else if (0 == str.compare("CUMULATIVE"))
		{
			ret = RuyiNetLeaderboardType::CUMULATIVE;
		}else if (0 == str.compare("LAST_VALUE"))
		{
			ret = RuyiNetLeaderboardType::LAST_VALUE;
		}else if (0 == str.compare("LOW_VALUE"))
		{
			ret = RuyiNetLeaderboardType::LOW_VALUE;
		}else
		{
			ret = RuyiNetLeaderboardType::NONE;
		}

		return ret;
	}
}}} 