#pragma once

#include "../Response/RuyiNetFindPlayersResponse.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetMatchmakingService : public RuyiNetService
	{
	public:
		RuyiNetMatchmakingService(RuyiNetClient * client);

		void EnableMatchmaking(int index, const RuyiNetTask<json>::CallbackType & callback);
		void DisableMatchmaking(int index, const RuyiNetTask<json>::CallbackType & callback);
		void SetPlayerRating(int index, long playerRating, const RuyiNetTask<json>::CallbackType & callback);
		void IncrementPlayerRating(int index, long increment, const RuyiNetTask<json>::CallbackType & callback);
		void DecrementPlayerRating(int index, long decrement, const RuyiNetTask<json>::CallbackType & callback);
		void ResetPlayerRating(int index, const RuyiNetTask<json>::CallbackType & callback);
		void FindPlayers(int index, long rangeDelta, long numMatches,
			const RuyiNetTask<RuyiNetFindPlayersResponse>::CallbackType & callback);
	};
}