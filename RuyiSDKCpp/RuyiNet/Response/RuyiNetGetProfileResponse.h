#pragma once

#include "RuyiNetProfile.h"

namespace Ruyi
{
	struct RuyiNetGetProfileResponse
	{
		struct Data
		{
			RuyiNetProfile response;
			bool success;
		};

		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetGetProfileResponse & data);
	void to_json(json & j, const RuyiNetGetProfileResponse::Data & data);
	void from_json(const json & j, RuyiNetGetProfileResponse::Data & data);
	void from_json(const json & j, RuyiNetGetProfileResponse & data);
}