#pragma once

#include <string.h>

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// How often a leaderboard will reset.
	/// </summary>
	enum RuyiNetRotationType
	{
		NONE = 0,

		/// <summary>
		/// The leaderboard never resets.
		/// </summary>
		NEVER,

		/// <summary>
		/// The leaderboard resets daily.
		/// </summary>
		DAILY,

		/// <summary>
		/// The leaderboard resets every week.
		/// </summary>
		WEEKLY,

		/// <summary>
		/// The leaderboard resets every month.
		/// </summary>
		MONTHLY,

		/// <summary>
		/// The leaderboard resets every year.
		/// </summary>
		YEARLY,

		/// <summary>
		/// The leaderboard resets every X days.
		/// </summary>
		DAYS
	};

	RuyiNetRotationType ConvertStringToRuyiNetRotationType(std::string str)
	{
		RuyiNetRotationType ret = RuyiNetRotationType::NONE;

		if (0 == str.compare("NEVER"))
		{
			ret = RuyiNetRotationType::NEVER;
		}else if (0 == str.compare("DAILY"))
		{
			ret = RuyiNetRotationType::DAILY;
		}else if (0 == str.compare("WEEKLY"))
		{
			ret = RuyiNetRotationType::WEEKLY;
		}else if (0 == str.compare("MONTHLY"))
		{
			ret = RuyiNetRotationType::MONTHLY;
		}
		else if (0 == str.compare("YEARLY"))
		{
			ret = RuyiNetRotationType::YEARLY;
		}else if (0 == str.compare("DAYS"))
		{
			ret = RuyiNetRotationType::DAYS;
		}else
		{
			ret = RuyiNetRotationType::NONE;
		}

		return ret;
	}
}}} 