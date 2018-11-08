#pragma once

#include "../../../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Response recieved from an achievemet request (gamification service).
	/// </summary>
	struct RuyiNetListAllLeaderboardsResponse 
	{
		/// <summary>
		/// The data class.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// Represents a single leaderboard config.
			/// </summary>
			struct LeaderboardInfo
			{
				/// <summary>
				/// The ID of the leaderboard.
				/// </summary>
				std::string leaderboardId;

				/// <summary>
				/// The type of leaderboard.
				/// </summary>
				std::string leaderboardType;

				/// <summary>
				/// When the leaderboard will next be reset.
				/// </summary>
				long resetAt;

				/// <summary>
				/// The type of rotation this leaderboard uses.
				/// </summary>
				std::string rotationType;

				/// <summary>
				/// The current version of the leaderboard.
				/// </summary>
				int currentVersionId;

				/// <summary>
				/// The maximum number of leaderboards retained.
				/// </summary>
				int maxRetainedCount;

				/// <summary>
				/// The actual number of versions currrent retained.
				/// </summary>
				int retainedVersionsCount;

				/// <summary>
				/// Custom data specified by the developer.
				/// </summary>
				std::string data;

				void parseJson(nlohmann::json& j)
				{
					if (!j["leaderboardId"].is_null()) leaderboardId = j["leaderboardId"];
					if (!j["leaderboardType"].is_null()) leaderboardType = j["leaderboardType"];
					if (!j["resetAt"].is_null()) resetAt = j["resetAt"];
					if (!j["rotationType"].is_null()) rotationType = j["rotationType"];
					if (!j["currentVersionId"].is_null()) currentVersionId = j["currentVersionId"];
					if (!j["maxRetainedCount"].is_null()) maxRetainedCount = j["maxRetainedCount"];
					if (!j["retainedVersionsCount"].is_null()) retainedVersionsCount = j["retainedVersionsCount"];
					if (!j["data"].is_null()) data = j["data"];

				}
			};

			/// <summary>
			/// The list of leaderboards.
			/// </summary>
			std::vector<LeaderboardInfo> leaderboardList;

			void parseJson(nlohmann::json& j)
			{
				if (!j["leaderboardList"].is_null())
				{
					nlohmann::json leaderboardListJson = j["leaderboardList"];

					if (leaderboardListJson.is_array())
					{
						for (auto leaderboardInfoJson : leaderboardListJson)
						{
							LeaderboardInfo _leaderboardInfo;

							_leaderboardInfo.parseJson(leaderboardInfoJson);

							leaderboardList.push_back(_leaderboardInfo);
						}
					}
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