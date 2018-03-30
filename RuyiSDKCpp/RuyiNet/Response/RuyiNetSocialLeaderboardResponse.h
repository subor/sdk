#pragma once

#include <list>
#include <string>

#include "boost/container/detail/json.hpp"

using json = nlohmann::json;

namespace Ruyi
{
	struct RuyiNetSocialLeaderboardResponse
	{
		struct Data
		{
			struct Response
			{
				long server_time;

				struct LeaderboardData
				{
					std::string playerId;
					int score;
					long createdAt;
					long updatedAt;
					std::string playerName;
					std::string pictureUrl;
				};

				std::list<LeaderboardData> leaderboard;
				std::string leaderboardId;
				int timeBeforeReset;
			};

			Response response;
			bool success;
		};

		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetSocialLeaderboardResponse::Data::Response::LeaderboardData & data);
	void from_json(const json & j, RuyiNetSocialLeaderboardResponse::Data::Response::LeaderboardData & data);
	void to_json(json & j, const RuyiNetSocialLeaderboardResponse::Data::Response & data);
	void from_json(const json & j, RuyiNetSocialLeaderboardResponse::Data::Response & data);
	void to_json(json & j, const RuyiNetSocialLeaderboardResponse::Data & data);
	void from_json(const json & j, RuyiNetSocialLeaderboardResponse::Data & data);
	void to_json(json & j, const RuyiNetSocialLeaderboardResponse& data);
	void from_json(const json & j, RuyiNetSocialLeaderboardResponse& data);
}