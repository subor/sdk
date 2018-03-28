#include "RuyiNetSummaryFriendData.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetSummaryFriendData & data)
	{
		j = json
		{
			{ "gender", data.gender },
			{ "dob", data.dob },
			{ "location", data.location }
		};
	}

	void from_json(const json & j, RuyiNetSummaryFriendData & data)
	{
		data.gender = j.at("gender").get<std::string>();
		data.dob = j.at("dob").get<std::string>();
		data.location = j.at("location").get<std::string>();
	}
}