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
			InvisibleUntilEarned = false;
			XpAwarded = 0;
			CoinAwarded = 0;
			GameId = "";
			AchievementId = "";
			Title = "";
			Description = "";
			ImageUrl = "";
			ExtraData = "";
		}
		
		/// <summary>
		/// Construct from an achievement response.
		/// </summary>
		/// <param name="achievement">An achievement returned from a response.</param>
		RuyiNetAchievement(RuyiNetAchievementResponse::Data::Achievement& achievement) : GameId(achievement.gameId), AchievementId(achievement.achievementId), Title(achievement.title),
			Description(achievement.description), ImageUrl(achievement.imageUrl), ExtraData(achievement.extraData)
		{
			InvisibleUntilEarned = achievement.invisibleUntilEarned;
			XpAwarded = achievement.xpAwarded;
			CoinAwarded = achievement.coinAwarded;
			
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
			InvisibleUntilEarned = achievement.invisibleUntilEarned;
			XpAwarded = achievement.xpAwarded;
			CoinAwarded = achievement.coinAwarded;
			GameId = achievement.gameId; 
			AchievementId = achievement.achievementId;
			Title = achievement.title;
			Description = achievement.description;
			ImageUrl = achievement.imageUrl;
			ExtraData = achievement.extraData;

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
		/// The ID of the game this achievement belongs to.
		/// </summary>
		std::string GameId;

		/// <summary>
		/// The ID of the achievement.
		/// </summary>
		std::string AchievementId;

		/// <summary>
		/// The achievement's title.
		/// </summary>
		std::string Title;

		/// <summary>
		/// A description of the achievement.
		/// </summary>
		std::string Description;

		/// <summary>
		/// Whether or not the achievement is invisible until it's earned.
		/// </summary>
		bool InvisibleUntilEarned;

		/// <summary>
		/// The URL of the image related to this achievement.
		/// </summary>
		std::string ImageUrl;

		/// <summary>
		/// Any extra data attached by the developer.
		/// </summary>
		std::string ExtraData;

		/// <summary>
		/// The XP awarded when this achievement is gained.
		/// </summary>
		int XpAwarded;

		/// <summary>
		/// The amount of coin awarded when this achievement is gained.
		/// </summary>
		int CoinAwarded;

		/// <summary>
		/// Whether or not the current player has earned this achievement.
		/// </summary>
		RuyiNetAchievementStatus Status;
	};
}}} //namespace