#pragma once

#include "RuyiNetProfile.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// The response after a single profile is requested.
	/// </summary>
	struct RuyiNetGetProfileResponse
	{
		/// <summary>
		/// The data contained in the response.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The profile returned in the response.
			/// </summary>
			RuyiNetProfile response;

			/// <summary>
			/// Whether or not the server-side script ran successfully.
			/// </summary>
			bool success;
		};

		/// <summary>
		/// The response data.
		/// </summary>
		Data data;

		/// <summary>
		/// The status code of the returned data.
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

				if (!dataJson["success"].is_null()) 
				{
					data.success = dataJson["success"];
				}
				if (!dataJson["response"].is_null())
				{
					nlohmann::json responseJson = dataJson["response"];

					data.response.parseJson(responseJson);
				}
			}
		}
	};
}}}