#pragma once

#include <string>

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// How often a leaderboard will reset.
	/// </summary>
	enum RuyiNetRotationType
	{
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

	RuyiNetRotationType ConvertStringToRuyiNetRotationType(std::string str);

}}} 