#pragma once

#include <list>
#include <string>

#include "RuyiNetSummaryFriendData.h"

namespace Ruyi
{
	struct RuyiNetFindPlayersResponse
	{
		struct Data
		{
			struct MatchesFound
			{
				std::string playerName;
				std::string pictureUrl;
				int playerRating;
				RuyiNetSummaryFriendData summaryFriendData;
				std::string playerId;
			};

			std::list<MatchesFound> matchesFound;
			int rejectCount;
		};

		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetFindPlayersResponse::Data::MatchesFound & data);
	void from_json(const json & j, RuyiNetFindPlayersResponse::Data::MatchesFound & data);
	void to_json(json & j, const RuyiNetFindPlayersResponse::Data & data);
	void from_json(const json & j, RuyiNetFindPlayersResponse::Data & data);
	void to_json(json & j, const RuyiNetFindPlayersResponse & data);
	void from_json(const json & j, RuyiNetFindPlayersResponse & data);
}