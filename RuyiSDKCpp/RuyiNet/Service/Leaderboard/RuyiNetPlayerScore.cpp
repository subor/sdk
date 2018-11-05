#include "RuyiNetPlayerScore.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetPlayerScore::RuyiNetPlayerScore() {}
	RuyiNetPlayerScore::RuyiNetPlayerScore(RuyiNetGetPlayerScoreResponse::Data::Score& data)
	{
		GetData(data);
	}
	RuyiNetPlayerScore::RuyiNetPlayerScore(RuyiNetGetPlayerScoresFromLeaderboardsResponse::Data::Score& data)
	{
		GetData(data);
	}

	void RuyiNetPlayerScore::GetData(RuyiNetGetPlayerScoreResponse::Data::Score& data)
	{
		Score = data.score;
		Data = data.data;
		CreatedAt = data.createdAt;
		UpdatedAt = data.updatedAt;
		LeaderboardId = data.leaderboardId;
		VersionId = data.versionId;
	}
	void RuyiNetPlayerScore::GetData(RuyiNetGetPlayerScoresFromLeaderboardsResponse::Data::Score& data)
	{
		Score = data.score;
		Data = data.data;
		CreatedAt = data.createdAt;
		UpdatedAt = data.updatedAt;
		LeaderboardId = data.leaderboardId;
		VersionId = data.versionId;
	}

	int RuyiNetPlayerScore::GetScore() { return Score; }
	std::string RuyiNetPlayerScore::GetData() { return Data; }
	long RuyiNetPlayerScore::GetCreatedAt() { return CreatedAt; }
	long RuyiNetPlayerScore::GetUpdatedAt() { return UpdatedAt; }
	std::string RuyiNetPlayerScore::GetLeaderboardId() { return LeaderboardId; }
	int RuyiNetPlayerScore::GetVersionId() { return VersionId; }

}}}