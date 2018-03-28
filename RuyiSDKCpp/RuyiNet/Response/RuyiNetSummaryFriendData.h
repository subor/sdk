#pragma once

#include "../../RuyiString.h"
#include "boost/container/detail/json.hpp"

using nlohmann::json;

namespace Ruyi
{
	struct RuyiNetSummaryFriendData
	{
		std::string gender;
		std::string dob;
		std::string location;
	};

	void to_json(json & j, const RuyiNetSummaryFriendData & data);
	void from_json(const json & j, RuyiNetSummaryFriendData & data);
}