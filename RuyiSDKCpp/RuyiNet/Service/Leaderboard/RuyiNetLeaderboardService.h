#pragma once

#include "Response/RuyiNetLeaderboardResponse.h"
#include "Response/RuyiNetSocialLeaderboardResponse.h"
#include "Response/RuyiNetGetGlobalLeaderboardEntryCountResponse.h"
#include "../../Response/RuyiNetResponse.h"
#include "RuyiNetLeaderboardType.h"
#include "RuyiNetRotationType.h"
#include "RuyiNetLeaderboardPage.h"
#include "RuyiNetLeaderboardInfo.h"
#include "RuyiNetPlayerScore.h"
#include "RuyiNetLeaderboardConfig.h"

#include "../RuyiNetService.h"

namespace Ruyi { namespace SDK { namespace Online {

	class RuyiNetLeaderboardPage;
	class RuyiNetLeaderboardInfo;
	class RuyiNetPlayerScore;
	class RuyiNetLeaderboardConfig;

	using namespace Ruyi::SDK::BrainCloudApi;

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
		__declspec(deprecated("Use Portal to create leaderboards. Use Cloud Code to dynamically create leaderboards."))
		void CreateLeaderboard(int index, const std::string& id, RuyiNetLeaderboardType type,
			RuyiNetRotationType rotationType, RuyiNetResponse& response);
		
		/// <summary>
		/// Returns the number of entries in a global leaderboard.
		/// </summary>
		/// <param name="index">The index of the client calling the operation.</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve data for.</param>
		/// <param name="response">returned response of json data</param>
		void GetGlobalLeaderboardEntryCount(int index, std::string leaderboardId, RuyiNetGetGlobalLeaderboardEntryCountResponse& response);

		/// <summary>
		/// Returns the number of entries in a global leaderboard.
		/// </summary>
		/// <param name="index">The index of the client calling the operation.</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve data for.</param>
		/// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
		/// <param name="response">returned response of json data</param>
		void GetGlobalLeaderboardEntryCount(int index, std::string leaderboardId, int versionId, RuyiNetGetGlobalLeaderboardEntryCountResponse& response);

		/// <summary>
		/// Retrieves paginated data from a leaderboard.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="sort">How to sort the data.</param>
		/// <param name="startIndex">The first entry to retrieve.</param>
		/// <param name="endIndex">The last entry to retrieve.</param>
		/// <param name="page">data of a leaderboard page</param>
		void GetGlobalLeaderboardPage(int index, std::string leaderboardId, SortOrder::type sort, int startIndex, int endIndex, RuyiNetLeaderboardPage& page);

		/// <summary>
		/// Retrieves paginated data from a leaderboard.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="sort">How to sort the data.</param>
		/// <param name="startIndex">The first entry to retrieve.</param>
		/// <param name="endIndex">The last entry to retrieve.</param>
		/// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
		/// <param name="page">returned data</param>
		void GetGlobalLeaderboardPage(int index, std::string leaderboardId, SortOrder::type sort, int startIndex, int endIndex, int versionId, RuyiNetLeaderboardPage& page);

		/// <summary>
		/// Retrieves a list of versions available for a leaderboard.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="info">return info data</param>
		void GetGlobalLeaderVersions(int index, std::string leaderboardId, RuyiNetLeaderboardInfo& info);

		/// <summary>
		/// Retrieves data from a leaderboard centered around the current player.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="sort">How to sort the data.</param>
		/// <param name="beforeCount">How many entries before the current player to retrieve.</param>
		/// <param name="afterCount">How many entries after the current player to retrieve.</param>
		/// <param name="page">returned data</param>
		void GetGlobalLeaderboardView(int index, std::string leaderboardId, SortOrder::type sort, int beforeCount, int afterCount, RuyiNetLeaderboardPage& page);

		/// <summary>
		/// Retrieves data from a leaderboard centered around the current player.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="sort">How to sort the data.</param>
		/// <param name="beforeCount">How many entries before the current player to retrieve.</param>
		/// <param name="afterCount">How many entries after the current player to retrieve.</param>
		/// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
		/// <param name="page">returned data</param>
		void GetGlobalLeaderboardView(int index, std::string leaderboardId, SortOrder::type sort, int beforeCount, int afterCount, int versionId, RuyiNetLeaderboardPage& page);

		/// <summary>
		/// Retrieves a leaderboard with all the user's friends.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="groupId">The ID of the group to retrieve data for.</param>
		/// <param name="callback">The function to call when the data is retrieved.</param>
		void GetGroupSocialLeaderboard(int index, std::string leaderboardId, std::string groupId, RuyiNetLeaderboardPage& page);

		/// <summary>
		/// Retrieves the player's score for a leaderboard.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="score">returned data</param>
		void GetPlayerScore(int index, std::string leaderboardId, RuyiNetPlayerScore& score);

		/// <summary>
		/// Retrieves the player's score for a leaderboard.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
		/// <param name="score">returned data.</param>
		void GetPlayerScore(int index, std::string leaderboardId, int versionId, RuyiNetPlayerScore& score);

		/// <summary>
		/// Retrieves the current player's scores from multiple leaderboards.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardIds">A list of leaderboard's IDs to retrieve data from.</param>
		/// <param name="scores">returned data</param>
		void GetPlayerScoresFromLeaderboards(int index, std::vector<std::string> leaderboardIds, std::vector<RuyiNetPlayerScore*> scores);

		/// <summary>
		/// Retrieves a leaderboard for all the specified users.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="playerIds">The IDs of the players to retrieve data for.</param>
		/// <param name="page">returned data</param>
		void GetPlayersSocialLeaderboard(int index, std::string leaderboardId, std::vector<std::string> playerIds, RuyiNetLeaderboardPage& page);

		/// <summary>
		/// Retrieves a leaderboard for all the users friends.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
		/// <param name="replaceName">If this is true the current player¡¯s name will be replaced with ¡°You¡±.</param>
		/// <param name="page">returned data</param>
		void GetSocialLeaderboard(int index, std::string leaderboardId, bool replaceName, RuyiNetLeaderboardPage& page);

		/// <summary>
		/// Returns a list of all leaderboard configurations for a game.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="config">returned data</param>
		void ListAllLeaderboards(int index, std::vector<RuyiNetLeaderboardConfig*> configs);

		/// <summary>
		/// Adds a score to a leaderboard that will be dynamically created if it doesn't exist.
		/// </summary>
		/// <param name="bool">returned result</param>
		/// <param name="index">The index of user</param>
		/// <param name="score">The score to post</param>
		/// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
		/// <param name="leaderboardType">The type of leaderboard to create.</param>
		/// <param name="rotationType">The rotation type of the leaderboard to create.</param>
		/// <param name="rotationReset">The time the leaderboard will reset.</param>
		/// <param name="retainedCount">How many versions of the leaderboard to retain.</param>
		void PostScoreToDynamicLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount);

		/// <summary>
		/// Adds a score to a leaderboard that will be dynamically created if it doesn't exist.
		/// </summary>
		/// <param name="isSuccess">returned result</param>
		/// <param name="index">The index of user</param>
		/// <param name="score">The score to post</param>
		/// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
		/// <param name="leaderboardType">The type of leaderboard to create.</param>
		/// <param name="rotationType">The rotation type of the leaderboard to create.</param>
		/// <param name="rotationReset">The time the leaderboard will reset.</param>
		/// <param name="retainedCount">How many versions of the leaderboard to retain.</param>
		/// <param name="data">Custom data for the developer to use.</param>
		void PostScoreToDynamicLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount, std::string data);

		/// <summary>
		/// Adds a score to a leaderboard.
		/// </summary>
		/// <param name="isSuccess">returned result</param>
		/// <param name="index">The index of user</param>
		/// <param name="score">The score to post</param>
		/// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
		void PostScoreToLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId);

		/// <summary>
		/// Adds a score to a leaderboard.
		/// </summary>
		/// <param name="isSuccess">returned result</param>
		/// <param name="index">The index of user</param>
		/// <param name="score">The score to post</param>
		/// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
		/// <param name="data">Custom data for the developer to use.</param>
		void PostScoreToLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId, std::string data);

		/// <summary>
		/// Removes a score from a leaderboard.
		/// </summary>
		/// <param name="isSuccess">returned result</param>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to remove the score from.</param>
		void RemoveScore(bool& isSuccess, int index, std::string leaderboardId);

		/// <summary>
		/// Removes a score from a leaderboard.
		/// </summary>
		/// <param name="isSuccess">returned result</param>
		/// <param name="index">The index of user</param>
		/// <param name="leaderboardId">The ID of the leaderboard to remove the score from.</param>
		/// <param name="versionId">The version of the leaderboard to remove the score from.</param>
		void RemoveScore(bool& isSuccess, int index, std::string leaderboardId, int versionId);

	private:
		std::string GetLeaderboardId(const std::string& id);
	};
}}} 