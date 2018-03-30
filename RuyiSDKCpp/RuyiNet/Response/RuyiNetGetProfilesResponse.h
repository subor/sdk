#pragma once

#include "../RuyiNetClient.h"
#include "RuyiNetProfile.h"

namespace Ruyi
{
	/// <summary>
	/// The response after a list of profiles are requested.
	/// </summary>
	struct RuyiNetGetProfilesResponse
	{
		/// <summary>
		/// The data contained in the response.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The profiles returned in the response.
			/// </summary>
			std::list<RuyiNetProfile> response;

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

				if (!dataJson["success"].is_null())
				{
					data.success = dataJson["success"];
				}

				if (!dataJson["response"].is_null())
				{
					nlohmann::json responseJsons = dataJson["response"];
					if (responseJsons.is_array())
					{
						for(auto responseJson : responseJsons)
						{
							RuyiNetProfile profile;

							profile.parseJson(responseJson);

							data.response.push_back(profile);
						}
					}
				}
			}
		}
	};
}