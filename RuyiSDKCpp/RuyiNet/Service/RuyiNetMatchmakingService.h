#pragma once

#include "../Response/RuyiNetFindPlayersResponse.h"
#include "../Response/RuyiNetResponse.h"
#include "../Response/RuyiNetProfile.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetMatchmakingService : public RuyiNetService
	{
	public:
		RuyiNetMatchmakingService(RuyiNetClient * client);

		void EnableMatchmaking(int index, RuyiNetResponse& response);
		void DisableMatchmaking(int index, RuyiNetResponse& response);
		void SetPlayerRating(int index, long playerRating, RuyiNetResponse& response);
		void IncrementPlayerRating(int index, long increment, RuyiNetResponse& response);
		void DecrementPlayerRating(int index, long decrement, RuyiNetResponse& response);
		void ResetPlayerRating(int index, RuyiNetResponse& response);
		void FindPlayers(int index, long rangeDelta, long numMatches, RuyiNetFindPlayersResponse& response);
	};
}