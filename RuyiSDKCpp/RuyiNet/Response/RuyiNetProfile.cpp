#include "RuyiNetProfile.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetProfile & data)
	{
		j = json
		{
			{ "profileName", data.profileName },
			{ "profileId", data.profileId },
			{ "pictureUrl", data.pictureUrl },
			{ "email", data.email },
			{ "friend", data.isFriend },
			{ "summaryFriendData", data.summaryFriendData }
		};
	}

	void from_json(const json & j, RuyiNetProfile & data)
	{
		data.profileName = j.at("profileName").get<std::string>();
		data.profileId = j.at("profileId").get<std::string>();
		data.pictureUrl = j.at("pictureUrl").get<std::string>();
		data.email = j.at("email").get<std::string>();
		data.isFriend = j.at("friend").get<bool>();
		data.summaryFriendData = j.at("summaryFriendData").get<RuyiNetSummaryFriendData>();
	}
}