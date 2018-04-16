#pragma once

#include "RuyiNetLeaderboardResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetLeaderboardResponse::Data::Response::LeaderboardData & data)
	{
		j = json
		{
			{ "playerId", data.playerId },
			{ "score", data.score },
			{ "createdAt", data.createdAt },
			{ "updatedAt", data.updatedAt },
			{ "index", data.index },
			{ "rank", data.rank },
			{ "name", data.name },
			{ "pictureUrl", data.pictureUrl },
			{ "friend", data.isFriend }
		};
	}

	void from_json(const json & j, RuyiNetLeaderboardResponse::Data::Response::LeaderboardData & data)
	{
		data.playerId = j.at("playerId").get<std::string>();
		data.score = j.at("score").get<int>();
		data.createdAt = j.at("createdAt").get<long>();
		data.updatedAt = j.at("updatedAt").get<long>();
		data.index = j.at("index").get<int>();
		data.rank = j.at("rank").get<int>();
		data.name = j.at("name").get<std::string>();
		data.pictureUrl = j.at("pictureUrl").get<std::string>();
		data.isFriend = j.at("friend").get<bool>();
	}

	void to_json(json & j, const RuyiNetLeaderboardResponse::Data::Response & data)
	{
		j = json
		{
			{ "server_time", data.server_time },
			{ "leaderboard", data.leaderboard },
			{ "versionId", data.versionId },
			{ "leaderboardId", data.leaderboardId },
			{ "timeBeforeReset", data.timeBeforeReset },
			{ "moreAfter", data.moreAfter },
			{ "moreBefore", data.moreBefore }
		};
	}

	void from_json(const json & j, RuyiNetLeaderboardResponse::Data::Response & data)
	{
		data.server_time = j.at("server_time").get<long>();
		data.leaderboard = j.at("leaderboard").get<std::list<RuyiNetLeaderboardResponse::Data::Response::LeaderboardData>>();
		data.versionId = j.at("versionId").get<int>();
		data.leaderboardId = j.at("leaderboardId").get<std::string>();
		data.timeBeforeReset = j.at("timeBeforeReset").get<int>();
		data.moreAfter = j.at("moreAfter").get<bool>();
		data.moreBefore = j.at("moreBefore").get<bool>();
	}

	void to_json(json & j, const RuyiNetLeaderboardResponse::Data & data)
	{
		j = json
		{
			{ "response", data.response },
			{ "success", data.success }
		};
	}

	void from_json(const json & j, RuyiNetLeaderboardResponse::Data & data)
	{
		data.response = j.at("response").get<RuyiNetLeaderboardResponse::Data::Response>();
		data.success = j.at("success").get<bool>();
	}

	void to_json(json & j, const RuyiNetLeaderboardResponse& data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetLeaderboardResponse& data)
	{
		data.data = j.at("data").get<RuyiNetLeaderboardResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}