#include "RuyiNetGamificationService.h"

namespace Ruyi { namespace SDK { namespace Online {
	
RuyiNetGamificationService::RuyiNetGamificationService(RuyiNetClient* client) : RuyiNetService(client)
{}

void RuyiNetGamificationService::AwardAchievement(int index, std::string achievementId, RuyiNetAchievement& achievement) 
{
	std::string responseStr;
	std::vector<std::string> achievementIds{ achievementId };
	mClient->GetBCService()->Gamification_AwardAchievements(responseStr, achievementIds, index);
	nlohmann::json retJson = nlohmann::json::parse(responseStr);
	RuyiNetAchievementResponse response;
	response.parseJson(retJson);

	if (RuyiNetHttpStatus::OK == response.status) 
	{
		if ( response.data.achievements.size() >= 1) 
		{
			achievement.GetDataFromAchievement(response.data.achievements[0]);
		}
	}
}

void RuyiNetGamificationService::AwardAchievements(int index, std::vector<std::string>& achievementIds, std::vector<RuyiNetAchievement*>& achievements)
{
	std::string responseStr;
	mClient->GetBCService()->Gamification_AwardAchievements(responseStr, achievementIds, index);
	nlohmann::json retJson = nlohmann::json::parse(responseStr);
	RuyiNetAchievementResponse response;
	response.parseJson(retJson);

	if (RuyiNetHttpStatus::OK == response.status) 
	{
		std::for_each(response.data.achievements.begin(), response.data.achievements.end(), [&](RuyiNetAchievementResponse::Data::Achievement& _achievement)
		{
			RuyiNetAchievement* pRuyiNetAchievement = new RuyiNetAchievement(_achievement);
			achievements.push_back(pRuyiNetAchievement);
		});
	}
}

void RuyiNetGamificationService::ReadAchievedAchievements(int index, bool includeMetaData, std::vector<RuyiNetAchievement*>& achievements)
{
	std::string responseStr;
	mClient->GetBCService()->Gamification_ReadAchievedAchievements(responseStr, includeMetaData, index);
	nlohmann::json retJson = nlohmann::json::parse(responseStr);
	RuyiNetAchievementResponse response;
	response.parseJson(retJson);

	if (RuyiNetHttpStatus::OK == response.status)
	{
		std::for_each(response.data.achievements.begin(), response.data.achievements.end(), [&](RuyiNetAchievementResponse::Data::Achievement& _achievement)
		{
			RuyiNetAchievement* pRuyiNetAchievement = new RuyiNetAchievement(_achievement);
			achievements.push_back(pRuyiNetAchievement);
		});
	}
}

void RuyiNetGamificationService::ReadAchievements(int index, bool includeMetaData, std::vector<RuyiNetAchievement*>& achievements)
{
	std::string responseStr;
	mClient->GetBCService()->Gamification_ReadAchievements(responseStr, includeMetaData, index);
	nlohmann::json retJson = nlohmann::json::parse(responseStr);
	RuyiNetAchievementResponse response;
	response.parseJson(retJson);

	if (RuyiNetHttpStatus::OK == response.status)
	{
		std::for_each(response.data.achievements.begin(), response.data.achievements.end(), [&](RuyiNetAchievementResponse::Data::Achievement& _achievement)
		{
			RuyiNetAchievement* pRuyiNetAchievement = new RuyiNetAchievement(_achievement);
			achievements.push_back(pRuyiNetAchievement);
		});
	}
}
}}}