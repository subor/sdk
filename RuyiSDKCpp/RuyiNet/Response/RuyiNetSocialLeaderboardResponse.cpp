#pragma once

#include "RuyiNetSocialLeaderboardResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetSocialLeaderboardResponse::Data::Response::LeaderboardData & data)
	{
		j = json
		{
			{ "playerId", data.playerId },
			{ "score", data.score },
			{ "createdAt", data.createdAt },
			{ "updatedAt", data.updatedAt },
			{ "playerName", data.playerName },
			{ "pictureUrl", data.pictureUrl }
		};
	}

	void from_json(const json & j, RuyiNetSocialLeaderboardResponse::Data::Response::LeaderboardData & data)
	{
		data.playerId = j.at("playerId").get<std::string>();
		data.score = j.at("score").get<int>();
		data.createdAt = j.at("createdAt").get<long>();
		data.updatedAt = j.at("updatedAt").get<long>();
		data.playerName = j.at("playerName").get<std::string>();
		data.pictureUrl = j.at("pictureUrl").get<std::string>();
	}

	void to_json(json & j, const RuyiNetSocialLeaderboardResponse::Data::Response & data)
	{
		j = json
		{
			{ "server_time", data.server_time },
			{ "leaderboard", data.leaderboard },
			{ "leaderboardId", data.leaderboardId },
			{ "timeBeforeReset", data.timeBeforeReset },
		};
	}

	void from_json(const json & j, RuyiNetSocialLeaderboardResponse::Data::Response & data)
	{
		data.server_time = j.at("server_time").get<long>();
		data.leaderboard = j.at("leaderboard").get<std::list<RuyiNetSocialLeaderboardResponse::Data::Response::LeaderboardData>>();
		data.leaderboardId = j.at("leaderboardId").get<std::string>();
		data.timeBeforeReset = j.at("timeBeforeReset").get<int>();
	}

	void to_json(json & j, const RuyiNetSocialLeaderboardResponse::Data & data)
	{
		j = json
		{
			{ "response", data.response },
			{ "success", data.success }
		};
	}

	void from_json(const json & j, RuyiNetSocialLeaderboardResponse::Data & data)
	{
		data.response = j.at("response").get<RuyiNetSocialLeaderboardResponse::Data::Response>();
		data.success = j.at("success").get<bool>();
	}

	void to_json(json & j, const RuyiNetSocialLeaderboardResponse& data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetSocialLeaderboardResponse& data)
	{
		data.data = j.at("data").get<RuyiNetSocialLeaderboardResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}