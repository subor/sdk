#pragma once

#include "../../../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// Contains the leaderboard returned from a leaderboard request.
	/// </summary>
	struct RuyiNetGetGlobalLeaderboardEntryCountResponse
	{
		/// <summary>
		/// The data class.
		/// </summary>
		struct Data 
		{
			/// <summary>
			/// The number of entries in the specified leaderboard.
			/// </summary>
			int entryCount = 0;

			void parseJson(nlohmann::json& j)
			{
				if (!j["entryCount"].is_null()) 
				{
					entryCount = j["entryCount"];
				}
			}
		};

		/// <summary>
		/// The data returned with the response.
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

				data.parseJson(dataJson);
			}
		}
	};
}}}