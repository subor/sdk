
#include "RuyiNetGetProfilesResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetGetProfilesResponse & data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void to_json(json & j, const RuyiNetGetProfilesResponse::Data & data)
	{
		j = json
		{
			{ "response", data.response },
			{ "success", data.success }
		};
	}

	void from_json(const json & j, RuyiNetGetProfilesResponse::Data & data)
	{
		data.response = j.at("response").get<std::list<RuyiNetProfile>>();
		data.success = j.at("success").get<bool>();
	}

	void from_json(const json & j, RuyiNetGetProfilesResponse & data)
	{
		data.data = j.at("data").get<RuyiNetGetProfilesResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}