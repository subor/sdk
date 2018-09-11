#include "RuyiNetLeaderboardService.h"

namespace Ruyi { namespace SDK { namespace Online {


	
	RuyiNetLeaderboardService::RuyiNetLeaderboardService(RuyiNetClient * client)
		: RuyiNetService(client)
	{}

	void RuyiNetLeaderboardService::CreateLeaderboard(int index, const std::string& id, RuyiNetLeaderboardType type, RuyiNetRotationType rotationType, RuyiNetResponse& response)
	{		
		auto leaderboardId = GetLeaderboardId(id);

		nlohmann::json payloadJson;

		payloadJson["leaderboardId"] = leaderboardId;
		payloadJson["type"] = (int)type;
		payloadJson["rotationType"] = (int)rotationType;
		payloadJson["versionsToRetain"] = 1;

		std::string responseStr = RunParentScript(index, "CreateLeaderboard", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}
	
	void RuyiNetLeaderboardService::GetGlobalLeaderboardEntryCount(int index, std::string leaderboardId, RuyiNetGetGlobalLeaderboardEntryCountResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->SocialLeaderboard_GetGlobalLeaderboardEntryCount(responseStr, leaderboardId, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		if (STATUS_OK != response.status) 
		{
			response.data.entryCount = 0;
		}
	}

	void RuyiNetLeaderboardService::GetGlobalLeaderboardEntryCount(int index, std::string leaderboardId, int versionId, RuyiNetGetGlobalLeaderboardEntryCountResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->SocialLeaderboard_GetGlobalLeaderboardEntryCountByVersion(responseStr, leaderboardId, versionId, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		if (STATUS_OK != response.status)
		{
			response.data.entryCount = 0;
		}
	}
	
	void RuyiNetLeaderboardService::GetGlobalLeaderboardPage(int index, std::string leaderboardId, SortOrder::type sort, int startIndex, int endIndex, RuyiNetLeaderboardPage& page)
	{
		std::string responseStr;
		RuyiNetGetGlobalLeaderboardPageResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetGlobalLeaderboardPage(responseStr, leaderboardId, sort, startIndex, endIndex, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		page.Status = response.status;
		if (STATUS_OK == response.status)
		{
			page.GetData(response.data);
		} 
	}

	void RuyiNetLeaderboardService::GetGlobalLeaderboardPage(int index, std::string leaderboardId, SortOrder::type sort, int startIndex, int endIndex, int versionId, RuyiNetLeaderboardPage& page)
	{
		std::string responseStr;
		RuyiNetGetGlobalLeaderboardPageResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetGlobalLeaderboardPageByVersion(responseStr, leaderboardId, sort, startIndex, endIndex, versionId, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		page.Status = response.status;
		if (STATUS_OK == response.status)
		{
			page.GetData(response.data);
		}
	}

	void RuyiNetLeaderboardService::GetGlobalLeaderVersions(int index, std::string leaderboardId, RuyiNetLeaderboardInfo& info) 
	{
		std::string responseStr;
		RuyiNetGetGlobalLeaderboardVersionsResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetGlobalLeaderboardVersions(responseStr, leaderboardId, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		info.Status = response.status;
		if (STATUS_OK == response.status)
		{
			info.GetData(response.data);
		}
	}

	void RuyiNetLeaderboardService::GetGlobalLeaderboardView(int index, std::string leaderboardId, SortOrder::type sort, int beforeCount, int afterCount, RuyiNetLeaderboardPage& page)
	{
		std::string responseStr;
		RuyiNetGetGlobalLeaderboardPageResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetGlobalLeaderboardView(responseStr, leaderboardId, sort, beforeCount, afterCount, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		page.Status = response.status;
		if (STATUS_OK == response.status)
		{
			page.GetData(response.data);
		}
	}

	void RuyiNetLeaderboardService::GetGlobalLeaderboardView(int index, std::string leaderboardId, SortOrder::type sort, int beforeCount, int afterCount, int versionId, RuyiNetLeaderboardPage& page)
	{
		std::string responseStr;
		RuyiNetGetGlobalLeaderboardPageResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetGlobalLeaderboardViewByVersion(responseStr, leaderboardId, sort, beforeCount, afterCount, versionId, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		page.Status = response.status;
		if (STATUS_OK == response.status)
		{
			page.GetData(response.data);
		}
	}

	void RuyiNetLeaderboardService::GetGroupSocialLeaderboard(int index, std::string leaderboardId, std::string groupId, RuyiNetLeaderboardPage& page)
	{
		std::string responseStr;
		RuyiNetGetGroupSocialLeaderboardResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetGroupSocialLeaderboard(responseStr, leaderboardId, groupId, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		page.Status = response.status;
		if (STATUS_OK == response.status)
		{
			page.GetData(response.data);
		}
	}

	void RuyiNetLeaderboardService::GetPlayerScore(int index, std::string leaderboardId, RuyiNetPlayerScore& score) 
	{
		GetPlayerScore(index, leaderboardId, -1, score);
	}

	void RuyiNetLeaderboardService::GetPlayerScore(int index, std::string leaderboardId, int versionId, RuyiNetPlayerScore& score)
	{
		std::string responseStr;
		RuyiNetGetPlayerScoreResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetPlayerScore(responseStr, leaderboardId, versionId, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		score.Status = response.status;
		if (STATUS_OK == response.status)
		{
			score.GetData(response.data.score);
		}
	}

	void RuyiNetLeaderboardService::GetPlayerScoresFromLeaderboards(int index, std::vector<std::string> leaderboardIds, std::vector<RuyiNetPlayerScore*> scores)
	{
		std::string responseStr;
		RuyiNetGetPlayerScoresFromLeaderboardsResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetPlayerScoresFromLeaderboards(responseStr, leaderboardIds, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);

		if (STATUS_OK == response.status)
		{
			std::for_each(response.data.scores.begin(), response.data.scores.end(), [&](RuyiNetGetPlayerScoresFromLeaderboardsResponse::Data::Score& _score)
			{
				RuyiNetPlayerScore* playerSocre = new RuyiNetPlayerScore(_score);
				scores.push_back(playerSocre);
			});
		}
	}

	void RuyiNetLeaderboardService::GetPlayersSocialLeaderboard(int index, std::string leaderboardId, std::vector<std::string> playerIds, RuyiNetLeaderboardPage& page)
	{
		std::string responseStr;
		RuyiNetGetGroupSocialLeaderboardResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetPlayersSocialLeaderboard(responseStr, leaderboardId, playerIds, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		page.Status = response.status;
		if (STATUS_OK == response.status)
		{
			page.GetData(response.data);
		}
	}

	void RuyiNetLeaderboardService::GetSocialLeaderboard(int index, std::string leaderboardId, bool replaceName, RuyiNetLeaderboardPage& page)
	{
		std::string responseStr;
		RuyiNetGetSocialLeaderboardResponse response;
		mClient->GetBCService()->SocialLeaderboard_GetSocialLeaderboard(responseStr, leaderboardId, replaceName, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		page.Status = response.status;
		if (STATUS_OK == response.status)
		{
			page.GetData(response.data);
		}
	}

	void RuyiNetLeaderboardService::ListAllLeaderboards(int index, std::vector<RuyiNetLeaderboardConfig*> configs)
	{
		std::string responseStr;
		RuyiNetListAllLeaderboardsResponse response;
		mClient->GetBCService()->SocialLeaderboard_ListLeaderboards(responseStr, index);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		if (STATUS_OK == response.status)
		{
			std::for_each(response.data.leaderboardList.begin(), response.data.leaderboardList.end(), [&](RuyiNetListAllLeaderboardsResponse::Data::LeaderboardInfo& _info)
			{
				configs.push_back(new RuyiNetLeaderboardConfig(_info));
			});
		}
	}

	void RuyiNetLeaderboardService::PostScoreToDynamicLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount)
	{
		PostScoreToDynamicLeaderboard(isSuccess, index, score, leaderboardId, leaderboardType, rotationType, rotationReset, retainedCount, "");
	}

	void RuyiNetLeaderboardService::PostScoreToDynamicLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount, std::string data)
	{
		std::string responseStr;
		RuyiNetResponse response;
		SocialLeaderboardType::type socialLeaderboardType = (SocialLeaderboardType::type)leaderboardType;
		RotationType::type _rotationType = (RotationType::type)rotationType;
		mClient->GetBCService()->SocialLeaderboard_PostScoreToDynamicLeaderboard(responseStr, leaderboardId, score, data, socialLeaderboardType, _rotationType, rotationReset, retainedCount, index);
		/*
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		if (STATUS_OK == response.status)
		{
			isSuccess = true;
		} else 
		{
			isSuccess = false;
		}*/
	}

	void RuyiNetLeaderboardService::PostScoreToLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId)
	{
		PostScoreToLeaderboard(isSuccess, index, score, leaderboardId, "");
	}

	void RuyiNetLeaderboardService::PostScoreToLeaderboard(bool& isSuccess, int index, int score, std::string leaderboardId, std::string data)
	{
		std::string responseStr;
		RuyiNetResponse response;
		mClient->GetBCService()->SocialLeaderboard_PostScoreToLeaderboard(responseStr, leaderboardId, score, data, index);
		//currently no data return
		/*
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		if (STATUS_OK == response.status)
		{
			isSuccess = true;
		} else
		{
			isSuccess = false;
		}*/
	}

	void RuyiNetLeaderboardService::RemoveScore(bool& isSuccess, int index, std::string leaderboardId)
	{
		RemoveScore(isSuccess, index, leaderboardId, -1);
	}

	void RuyiNetLeaderboardService::RemoveScore(bool& isSuccess, int index, std::string leaderboardId, int versionId)
	{
		std::string responseStr;
		RuyiNetResponse response;
		mClient->GetBCService()->SocialLeaderboard_RemovePlayerScore(responseStr, leaderboardId, versionId, index);
		/*
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		if (STATUS_OK == response.status)
		{
			isSuccess = true;
		} else
		{
			isSuccess = false;
		}*/
	}

	/*
	void RuyiNetLeaderboardService::GetGlobalLeaderboardPage(int index, const std::string& id, SDK::BrainCloudApi::SortOrder::type sort,
		int startIndex, int endIndex, RuyiNetLeaderboardResponse& response);
	
	void RuyiNetLeaderboardService::GetGlobalLeaderboardView(int index, const std::string& id, SDK::BrainCloudApi::SortOrder::type sort,
		int beforeCount, int afterCount, RuyiNetLeaderboardResponse& response);
	
	void RuyiNetLeaderboardService::GetSocialLeaderboard(int index, const std::string& id, bool replaceName,
		RuyiNetSocialLeaderboardResponse& response);
	
	void RuyiNetLeaderboardService::PostScoreToLeaderboard(int index, const std::string& id, int score, RuyiNetResponse& response);
	*/

	std::string RuyiNetLeaderboardService::GetLeaderboardId(const std::string& id)
	{
		//RuyiString result = mClient->GetAppId() + RUYI_STR("_") + id;
		//return ToString(result);
		std::string result = mClient->GetAppId() + "_" + id;

		return result;
	}

}}} 