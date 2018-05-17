#pragma once

#include "../Response/RuyiNetLeaderboardResponse.h"
#include "../Response/RuyiNetSocialLeaderboardResponse.h"
#include "../Response/RuyiNetResponse.h"
#include "RuyiNetLeaderboardType.h"
#include "RuyiNetRotationType.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetLeaderboardService : public RuyiNetService
	{
	public:
		RuyiNetLeaderboardService(RuyiNetClient * client);

		/// <summary>
		/// Create a leaderboard. This will be deprecated when the developer portal is available.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="id">The ID of the new leaderboard.</param>
		/// <param name="type">The type of leaderboard to create.</param>
		/// <param name="rotationType">How often the leaderboard will rotate scores.</param>
		/// <param name="response">The parsed data struct of return json</param>
		void CreateLeaderboard(int index, const std::string& id, RuyiNetLeaderboardType type,
			RuyiNetRotationType rotationType, RuyiNetResponse& response);
		
		/// <summary>
		/// Retrieves paginated data from a leaderboard.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="id">The ID of the leaderboard to retrieve.</param>
		/// <param name="sort">How to sort the data.</param>
		/// <param name="startIndex">The first entry to retrieve.</param>
		/// <param name="endIndex">The last entry to retrieve.</param>
		/// <param name="response">The parsed data struct of return json</param>
		void GetGlobalLeaderboardPage(int index, const std::string& id, SDK::BrainCloudApi::SortOrder::type sort,
			int startIndex, int endIndex, RuyiNetLeaderboardResponse& response);
		
		/// <summary>
		/// Retrieves data from a leaderboard centered around the current player.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="id">The ID of the leaderboard to retrieve.</param>
		/// <param name="sort">How to sort the data.</param>
		/// <param name="beforeCount">How many entries before the current player to retrieve.</param>
		/// <param name="afterCount">How many entries after the current player to retrieve.</param>
		/// <param name="response">The parsed data struct of return json</param>
		void GetGlobalLeaderboardView(int index, const std::string& id, SDK::BrainCloudApi::SortOrder::type sort,
			int beforeCount, int afterCount, RuyiNetLeaderboardResponse& response);
		
		/// <summary>
		/// Retrieves a leaderboard with all the user's friends.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="id">The ID of the leaderboard to retrieve.</param>
		/// <param name="replaceName">If true, the player's name is replaced by the string "You".</param>
		/// <param name="response">The parsed data struct of return json</param>
		void GetSocialLeaderboard(int index, const std::string& id, bool replaceName, 
			RuyiNetSocialLeaderboardResponse& response);
			
		/// <summary>
		/// Posts a score to the leaderboard for the player.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="id">The ID of the leaderboard to post to.</param>
		/// <param name="score">The score to post.</param>
		/// <param name="response">The parsed data struct of return json</param>
		void PostScoreToLeaderboard(int index, const std::string& id, int score, RuyiNetResponse& response);

	private:
		std::string GetLeaderboardId(const std::string& id);
	};
}