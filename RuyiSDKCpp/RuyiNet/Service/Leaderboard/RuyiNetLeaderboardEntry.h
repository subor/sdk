#pragma once

#include "RuyiNetLeaderboardService.h"

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
		RuyiNetLeaderboardEntry() {}
		
		RuyiNetLeaderboardEntry(RuyiNetGetGlobalLeaderboardPageResponse::Data::LeaderboardEntry& entry)
		{
			PlayerId = entry.playerId;
			Score = entry.score;
			Data = entry.data;
			CreatedAt = entry.createdAt;
			UpdatedAt = entry.updatedAt;
			Index = entry.index;
			Rank = entry.rank;
			Name = entry.name;
			PictureUrl = entry.pictureUrl;
		}

		RuyiNetLeaderboardEntry(RuyiNetGetGroupSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
		{
			PlayerId = entry.playerId;
			Score = entry.score;
			Data = entry.data;
			CreatedAt = entry.createdAt;
			UpdatedAt = entry.updatedAt;
			Index = entry.index;
			Rank = entry.rank;
			Name = entry.playerName;
			PictureUrl = entry.pictureUrl;
		}

		RuyiNetLeaderboardEntry(RuyiNetGetSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
		{
			PlayerId = entry.playerId;
			Score = entry.score;
			Data = entry.otherData;
			CreatedAt = entry.createdAt;
			UpdatedAt = entry.updatedAt;
			Name = entry.name;
			PictureUrl = entry.pictureUrl;
		}

		std::string GetPlayerId() { return PlayerId; }
		int GetScore() { return Score; }
		std::string GetData() { return Data; }
		long GetCreatedAt() { return CreatedAt; }
		long GetUpdatedAt() { return UpdatedAt; }
		int GetIndex() { return Index; }
		int GetRank() { return Rank; }
		std::string GetName() { return Name; }
		std::string GetPictureUrl() { return PictureUrl; }

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