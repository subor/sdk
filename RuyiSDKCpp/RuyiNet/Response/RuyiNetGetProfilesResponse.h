#pragma once

#include <list>
#include "RuyiNetProfile.h"

namespace Ruyi
{
	struct RuyiNetGetProfilesResponse
	{
		struct Data
		{
			std::list<RuyiNetProfile> response;
			bool success;
		};

		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetGetProfilesResponse & data);
	void to_json(json & j, const RuyiNetGetProfilesResponse::Data & data);
	void from_json(const json & j, RuyiNetGetProfilesResponse::Data & data);
	void from_json(const json & j, RuyiNetGetProfilesResponse & data);
}