#pragma once

#include "../../../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Response recieved from retrieving a social leaderboard.
	/// </summary>
	struct RuyiNetGetSocialLeaderboardResponse 
	{
		/// <summary>
		/// The data class.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// Represents a single leaderboard entry.
			/// </summary>
			struct LeaderboardEntry
			{
				/// <summary>
				/// The ID of the player this entry represents.
				/// </summary>
				std::string playerId;

				/// <summary>
				/// The latest score for the player.
				/// </summary>
				int score;

				/// <summary>
				/// Extra data provided by the developer, if any.
				/// </summary>
				std::string otherData;

				/// <summary>
				/// When this entry was created (UNIX timestamp).
				/// </summary>
				long createdAt;

				/// <summary>
				/// When this entry was last updated (UNIX timestamp).
				/// </summary>
				long updatedAt;

				/// <summary>
				/// The display name of the player.
				/// </summary>
				std::string name;

				/// <summary>
				/// The URL of the player's profile picture.
				/// </summary>
				std::string pictureUrl;

				void parseJson(nlohmann::json& j)
				{
					if (!j["playerId"].is_null()) playerId = j["playerId"];
					if (!j["score"].is_null()) score = j["score"];
					if (!j["otherData"].is_null()) otherData = j["otherData"];
					if (!j["createdAt"].is_null()) createdAt = j["createdAt"];
					if (!j["updatedAt"].is_null()) updatedAt = j["updatedAt"];
					if (!j["name"].is_null()) name = j["name"];
					if (!j["pictureUrl"].is_null()) pictureUrl = j["pictureUrl"];
				}
			};

			/// <summary>
			/// The list of entries for this leaderboard page.
			/// </summary>
			std::vector<LeaderboardEntry> social_leaderboard;

			/// <summary>
			/// How long before the next time this leaderboard is reset.
			/// </summary>
			int timeBeforeReset;

			/// <summary>
			/// The server time when this leaderboard was retrieved (UNIX timestamp).
			/// </summary>
			long server_time;

			void parseJson(nlohmann::json& j)
			{
				if (!j["timeBeforeReset"].is_null()) timeBeforeReset = j["timeBeforeReset"];
				if (!j["server_time"].is_null()) server_time = j["server_time"];
				if (!j["social_leaderboard"].is_null()) 
				{ 
					nlohmann::json social_leaderboardJson = j["social_leaderboard"];

					if (social_leaderboardJson.is_array()) 
					{
						for (auto LeaderboardEntryJson : social_leaderboardJson)
						{
							LeaderboardEntry _leaderboardEntry;

							_leaderboardEntry.parseJson(LeaderboardEntryJson);

							social_leaderboard.push_back(_leaderboardEntry);
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