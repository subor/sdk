#pragma once

#include "../../RuyiString.h"

#include "RuyiNetSummaryFriendData.h"

namespace Ruyi
{
	struct RuyiNetProfile
	{
		std::string profileName;
		std::string profileId;
		std::string pictureUrl;
		std::string email;
		bool isFriend;
		RuyiNetSummaryFriendData summaryFriendData;
	};
	
	void to_json(json & j, const RuyiNetProfile & data);
	void from_json(const json & j, RuyiNetProfile & data);
}