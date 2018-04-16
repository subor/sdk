#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi
{
	struct RuyiNetResponse
	{
		/// <summary>
		/// Resultant status code from an API call.
		/// </summary>
		int status;

		/// <summary>
		/// Message accompanying the result - can be used to determine errors.
		/// </summary>
		std::string message;

		void parseJson(nlohmann::json& j)
		{
			if (!j["status"].is_null())
			{
				status = j["status"];
			}
			if (!j["message"].is_null())
			{
				message = j["message"];
			}
		}
	};
}