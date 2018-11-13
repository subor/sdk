#pragma once

#include "Response/RuyiNetGetGlobalLeaderboardPageResponse.h"
#include "Response/RuyiNetGetGroupSocialLeaderboardResponse.h"
#include "Response/RuyiNetGetSocialLeaderboardResponse.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// Represents a single leaderboard entry.
	/// </summary>
	class RuyiNetLeaderboardEntry 
	{
	public:
		RuyiNetLeaderboardEntry();
		
		RuyiNetLeaderboardEntry(RuyiNetGetGlobalLeaderboardPageResponse::Data::LeaderboardEntry& entry);

		RuyiNetLeaderboardEntry(RuyiNetGetGroupSocialLeaderboardResponse::Data::LeaderboardEntry& entry);

		RuyiNetLeaderboardEntry(RuyiNetGetSocialLeaderboardResponse::Data::LeaderboardEntry& entry);

		std::string GetPlayerId();
		int GetScore();
		std::string GetData();
		long GetCreatedAt();
		long GetUpdatedAt();
		int GetIndex();
		int GetRank();
		std::string GetName();
		std::string GetPictureUrl();

	private:
		/// <summary>
		/// The ID of the player this entry represents.
		/// </summary>
		std::string PlayerId;

		/// <summary>
		/// The latest score for the player.
		/// </summary>
		int Score;

		/// <summary>
		/// Extra data provided by the developer, if any.
		/// </summary>
		std::string Data;

		/// <summary>
		/// When this entry was created (UNIX timestamp).
		/// </summary>
		long CreatedAt;

		/// <summary>
		/// When this entry was last updated (UNIX timestamp).
		/// </summary>
		long UpdatedAt;

		/// <summary>
		/// The index of this entry.
		/// </summary>
		int Index;

		/// <summary>
		/// The overall rank of the player on this leaderboard.
		/// </summary>
		int Rank;

		/// <summary>
		/// The display name of the player.
		/// </summary>
		std::string Name;

		/// <summary>
		/// The URL of the player's profile picture.
		/// </summary>
		std::string PictureUrl;
	};
}}}