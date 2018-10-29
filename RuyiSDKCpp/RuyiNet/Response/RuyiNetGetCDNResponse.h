#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// The response from getting a CDN
	/// </summary>
	struct RuyiNetGetCDNResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// A permanent link to the file.
			/// </summary>
			std::string appServerUrl;

			/// <summary>
			/// A temporary link to the file served via a CDN.
			/// </summary>
			std::string cdnUrl;
		};

		/// <summary>
		/// The response data.
		/// </summary>
		Data data;
		/// <summary>
		/// The status of the response.
		/// </summary>
		int status;

		void parseJson(nlohmann::json& j)
		{
			if (!j["status"].is_null())
			{
				status = j["status"];
			}

			if (!j["data"].is_null())
			{
				nlohmann::json dataJson = j["data"];

				if (!dataJson.is_object()) return;

				if (!dataJson["appServerUrl"].is_null())
				{
					data.appServerUrl = dataJson["appServerUrl"];
				}

				if (!dataJson["cdnUrl"].is_null())
				{
					data.cdnUrl = dataJson["cdnUrl"];
				}
			}
		}
	};
}}}