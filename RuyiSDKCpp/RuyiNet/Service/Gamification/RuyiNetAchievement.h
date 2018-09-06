#pragma once

#include "../../Response/RuyiNetAchievementResponse.h"

namespace Ruyi { namespace SDK { namespace Online {
	
	/// <summary>
	/// Status of an achievement for the player
	/// </summary>
	enum RuyiNetAchievementStatus
	{
		/// <summary>
		/// The achievement has been awarded.
		/// </summary>
		AWARDED,

		/// <summary>
		/// The achievement has not yet been awarded.
		/// </summary>
		NOT_AWARDED,

		/// <summary>
		/// Unknown achievement status.
		/// </summary>
		UNKNOWN
	};

	/// <summary>
	/// Represents an achievement in RuyiNet
	/// </summary>
	class RuyiNetAchievement 
	{
	public:
		
		RuyiNetAchievement() 
		{
			id = "";
			Status = RuyiNetAchievementStatus::UNKNOWN;
		}
		
		/// <summary>
		/// Construct from an achievement response.
		/// </summary>
		/// <param name="achievement">An achievement returned from a response.</param>
		RuyiNetAchievement(RuyiNetAchievementResponse::Data::Achievement& achievement) : id(achievement.id)
		{
			if (0 == achievement.status.compare("NOT_AWARDED"))
			{
				Status = RuyiNetAchievementStatus::NOT_AWARDED;
			} else if (0 == achievement.status.compare("AWARDED"))
			{
				Status = RuyiNetAchievementStatus::AWARDED;
			} else
			{
				Status = RuyiNetAchievementStatus::UNKNOWN;
			}
		}

		/// <summary>
		/// get data from an achievement response.
		/// </summary>
		/// <param name="achievement">An achievement returned from a response.</param>
		void GetDataFromAchievement(RuyiNetAchievementResponse::Data::Achievement& achievement)
		{
			id = achievement.id;		

			if (0 == achievement.status.compare("NOT_AWARDED"))
			{
				Status = RuyiNetAchievementStatus::NOT_AWARDED;
			} else if (0 == achievement.status.compare("AWARDED"))
			{
				Status = RuyiNetAchievementStatus::AWARDED;
			} else
			{
				Status = RuyiNetAchievementStatus::UNKNOWN;
			}
		}

		/// <summary>
		/// The ID of the achievement.
		/// </summary>
		std::string id;

		/// <summary>
		/// Whether or not the current player has earned this achievement.
		/// </summary>
		RuyiNetAchievementStatus Status;
	};
}}} //namespace