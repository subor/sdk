#pragma once

#include "../RuyiNetService.h"
#include "../../Response/RuyiNetAchievementResponse.h"
#include "RuyiNetAchievement.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// Provides gamification services to a game.
	/// </summary>
	class RuyiNetGamificationService : public RuyiNetService 
	{
	public:
		RuyiNetGamificationService(RuyiNetClient* client);

		/// <summary>
		/// Award a single achievement to the player.
		/// </summary>
		/// <param name="index">The index of the user.</param>
		/// <param name="achievementId">The ID of the achievement to unlock.</param>
		/// <param name="achievement">achievement to the player.</param>
		void AwardAchievement(int index, std::string achievementId, RuyiNetAchievement& achievement);

		/// <summary>
		/// Award multiple achievements to the player.
		/// </summary>
		/// <param name="index">The index of the user.</param>
		/// <param name="achievementIds">The ID of the achievement to unlock.</param>
		/// <param name="achievements">achievements to the player..</param>
		void AwardAchievements(int index, std::vector<std::string>& achievementIds, std::vector<RuyiNetAchievement*>& achievements);

		/// <summary>
		/// Read all the achievements the current player has earned.
		/// </summary>
		/// <param name="index">The index of the user.</param>
		/// <param name="includeMetaData">Whether or not to include metadata (otherwise just returns achievement IDs).</param>
		/// <param name="achievements">achievements the current player earned.</param>
		void ReadAchievedAchievements(int index, bool includeMetaData, std::vector<RuyiNetAchievement*>& achievements);

		/// <summary>
		/// Read the achievement data for the current game.
		/// </summary>
		/// <param name="index">The index of the user.</param>
		/// <param name="includeMetaData">Whether or not to include metadata (otherwise just returns achievement IDs).</param>
		/// <param name="achievements">achievement data for the current game.</param>
		void ReadAchievements(int index, bool includeMetaData, std::vector<RuyiNetAchievement*>& achievements);
	};
}}}