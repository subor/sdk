#include "RuyiNetFindPlayersResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetFindPlayersResponse::Data::MatchesFound & data)
	{
		j = json
		{
			{ "playerName", data.playerName },
			{ "pictureUrl", data.pictureUrl },
			{ "playerRating", data.playerRating },
			{ "summaryFriendData", data.summaryFriendData },
			{ "playerId", data.playerId }
		};
	}
	
	void from_json(const json & j, RuyiNetFindPlayersResponse::Data::MatchesFound & data)
	{
		data.playerName = j.at("playerName").get<std::string>();
		data.pictureUrl = j.at("pictureUrl").get<std::string>();
		data.playerRating = j.at("playerRating").get<int>();
		data.summaryFriendData = j.at("summaryFriendData").get<RuyiNetSummaryFriendData>();
		data.playerId = j.at("playerId").get<std::string>();
	}

	void to_json(json & j, const RuyiNetFindPlayersResponse::Data & data)
	{
		j = json
		{
			{ "matchesFound", data.matchesFound },
			{ "rejectCount", data.rejectCount }
		};
	}

	void from_json(const json & j, RuyiNetFindPlayersResponse::Data & data)
	{
		data.matchesFound = j.at("matchesFound").get<std::list<RuyiNetFindPlayersResponse::Data::MatchesFound>>();
		data.rejectCount = j.at("rejectCount").get<int>();
	}

	void to_json(json & j, const RuyiNetFindPlayersResponse & data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetFindPlayersResponse & data)
	{
		data.data = j.at("data").get<RuyiNetFindPlayersResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}