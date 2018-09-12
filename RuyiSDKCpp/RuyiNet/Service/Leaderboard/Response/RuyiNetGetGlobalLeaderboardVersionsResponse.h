#pragma once

#include "../../../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {
			
	/// <summary>
	/// Represents a response from a GetLeaderboardVersions request.
	/// </summary>
	struct RuyiNetGetGlobalLeaderboardVersionsResponse 
	{
		/// <summary>
		/// The data class.
		/// </summary>
		struct Data 
		{
			/// <summary>
			/// Represents a leaderboard version.
			/// </summary>
			struct VersionInfo 
			{
				/// <summary>
				/// The ID of this version.
				/// </summary>
				int versionId;

				/// <summary>
				/// The time this version starts.
				/// </summary>
				long startingAt;

				/// <summary>
				/// The time this version ends.
				/// </summary>
				long endingAt;

				void parseJson(nlohmann::json& j)
				{
					if (!j["versionId"].is_null()) 
					{
						versionId = j["versionId"];
					}
					if (!j["startingAt"].is_null())
					{
						startingAt = j["startingAt"];
					}
					if (!j["endingAt"].is_null())
					{
						endingAt = j["endingAt"];
					}
				}
			};

			/// <summary>
			/// The ID of the leaderboard.
			/// </summary>
			std::string leaderboardId;

			/// <summary>
			/// The type of leaderboard.
			/// </summary>
			std::string leaderboardType;

			/// <summary>
			/// The type of leaderboard rotation.
			/// </summary>
			std::string rotationType;

			/// <summary>
			/// The number of versions retained.
			/// </summary>
			int retainedCount;

			/// <summary>
			/// A vector of versions currently retained.
			/// </summary>
			std::vector<VersionInfo> versions;

			void parseJson(nlohmann::json& j)
			{
				if (!j["leaderboardId"].is_null())
				{
					leaderboardId = j["leaderboardId"];
				}
				if (!j["leaderboardType"].is_null())
				{
					leaderboardType = j["leaderboardType"];
				}
				if (!j["rotationType"].is_null())
				{
					rotationType = j["rotationType"];
				}
				if (!j["retainedCount"].is_null())
				{
					retainedCount = j["retainedCount"];
				}
				if (!j["versions"].is_null()) 
				{
					nlohmann::json versionsJson = j["versions"];

					if (versionsJson.is_array()) 
					{
						for (auto versionInfoJson : versionsJson) 
						{
							VersionInfo versionInfo;

							versionInfo.parseJson(versionInfoJson);

							versions.push_back(versionInfo);
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