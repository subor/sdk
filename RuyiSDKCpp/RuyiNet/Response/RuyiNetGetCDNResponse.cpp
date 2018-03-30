#include "RuyiNetGetCDNResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetGetCDNResponse::Data & data)
	{
		j = json
		{
			{ "appServerUrl", data.appServerUrl },
			{ "cdnUrl", data.cdnUrl }
		};
	}

	void from_json(const json & j, RuyiNetGetCDNResponse::Data & data)
	{
		data.appServerUrl = j.at("appServerUrl").get<std::string>();
		data.cdnUrl = j.at("cdnUrl").get<std::string>();
	}

	void to_json(json & j, const RuyiNetGetCDNResponse & data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetGetCDNResponse & data)
	{
		data.data = j.at("data").get<RuyiNetGetCDNResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}