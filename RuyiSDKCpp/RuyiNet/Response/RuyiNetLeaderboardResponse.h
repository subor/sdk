#pragma once

#include <list>
#include <string>

#include "boost/container/detail/json.hpp"

using json = nlohmann::json;

namespace Ruyi
{
	struct RuyiNetLeaderboardResponse
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
					int index;
					int rank;
					std::string name;
					std::string pictureUrl;
					bool isFriend;
				};

				std::list<LeaderboardData> leaderboard;
				int versionId;
				std::string leaderboardId;
				int timeBeforeReset;
				bool moreAfter;
				bool moreBefore;
			};

			Response response;
			bool success;
		};
		
		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetLeaderboardResponse::Data::Response::LeaderboardData & data);
	void from_json(const json & j, RuyiNetLeaderboardResponse::Data::Response::LeaderboardData & data);
	void to_json(json & j, const RuyiNetLeaderboardResponse::Data::Response & data);
	void from_json(const json & j, RuyiNetLeaderboardResponse::Data::Response & data);
	void to_json(json & j, const RuyiNetLeaderboardResponse::Data & data);
	void from_json(const json & j, RuyiNetLeaderboardResponse::Data & data);
	void to_json(json & j, const RuyiNetLeaderboardResponse& data);
	void from_json(const json & j, RuyiNetLeaderboardResponse& data);
}