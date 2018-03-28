#pragma once

#include <string>

#include "boost/container/detail/json.hpp"

using nlohmann::json;

namespace Ruyi
{
	struct RuyiNetGetCDNResponse
	{
		struct Data
		{
			std::string appServerUrl;
			std::string cdnUrl;
		};

		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetGetCDNResponse::Data & data);
	void from_json(const json & j, RuyiNetGetCDNResponse::Data & data);
	void to_json(json & j, const RuyiNetGetCDNResponse & data);
	void from_json(const json & j, RuyiNetGetCDNResponse & data);
}