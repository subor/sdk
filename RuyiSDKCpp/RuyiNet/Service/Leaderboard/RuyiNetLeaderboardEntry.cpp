#include "RuyiNetLeaderboardEntry.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetLeaderboardEntry::RuyiNetLeaderboardEntry() {}

	RuyiNetLeaderboardEntry::RuyiNetLeaderboardEntry(RuyiNetGetGlobalLeaderboardPageResponse::Data::LeaderboardEntry& entry)
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

	RuyiNetLeaderboardEntry::RuyiNetLeaderboardEntry(RuyiNetGetGroupSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
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

	RuyiNetLeaderboardEntry::RuyiNetLeaderboardEntry(RuyiNetGetSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
	{
		PlayerId = entry.playerId;
		Score = entry.score;
		Data = entry.otherData;
		CreatedAt = entry.createdAt;
		UpdatedAt = entry.updatedAt;
		Name = entry.name;
		PictureUrl = entry.pictureUrl;
	}

	std::string RuyiNetLeaderboardEntry::GetPlayerId() { return PlayerId; }
	int RuyiNetLeaderboardEntry::GetScore() { return Score; }
	std::string RuyiNetLeaderboardEntry::GetData() { return Data; }
	long RuyiNetLeaderboardEntry::GetCreatedAt() { return CreatedAt; }
	long RuyiNetLeaderboardEntry::GetUpdatedAt() { return UpdatedAt; }
	int RuyiNetLeaderboardEntry::GetIndex() { return Index; }
	int RuyiNetLeaderboardEntry::GetRank() { return Rank; }
	std::string RuyiNetLeaderboardEntry::GetName() { return Name; }
	std::string RuyiNetLeaderboardEntry::GetPictureUrl() { return PictureUrl; }

}}}