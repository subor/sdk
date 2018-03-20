#pragma once

#include "../Response/RuyiNetLeaderboardResponse.h"
#include "../Response/RuyiNetSocialLeaderboardResponse.h"
#include "RuyiNetLeaderboardType.h"
#include "RuyiNetRotationType.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetLeaderboardService : public RuyiNetService
	{
	public:
		RuyiNetLeaderboardService(RuyiNetClient * client);

		void CreateLeaderboard(int index, const RuyiString & id, RuyiNetLeaderboardType type,
			RuyiNetRotationType rotationType, const RuyiNetTask<json>::CallbackType & callback);
		void GetGlobalLeaderboardPage(int index, const RuyiString & id, SDK::BrainCloudApi::SortOrder::type sort,
			int startIndex, int endIndex, const RuyiNetTask<RuyiNetLeaderboardResponse>::CallbackType & callback);
		void GetGlobalLeaderboardView(int index, const RuyiString & id, SDK::BrainCloudApi::SortOrder::type sort,
			int beforeCount, int afterCount, const RuyiNetTask<RuyiNetLeaderboardResponse>::CallbackType & callback);
		void GetSocialLeaderboard(int index, const RuyiString & id, bool replaceName, 
			const RuyiNetTask<RuyiNetSocialLeaderboardResponse>::CallbackType & callback);
		void PostScoreToLeaderboard(int index, const RuyiString & id, int score, const RuyiNetTask<json>::CallbackType & callback);

	private:
		std::string GetLeaderboardId(const RuyiString & id);
	};
}