
#include "RuyiNetGetProfileResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetGetProfileResponse & data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void to_json(json & j, const RuyiNetGetProfileResponse::Data & data)
	{
		j = json
		{
			{ "response", data.response },
			{ "success", data.success }
		};
	}

	void from_json(const json & j, RuyiNetGetProfileResponse::Data & data)
	{
		data.response = j.at("response").get<RuyiNetProfile>();
		data.success = j.at("success").get<bool>();
	}

	void from_json(const json & j, RuyiNetGetProfileResponse & data)
	{
		data.data = j.at("data").get<RuyiNetGetProfileResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}