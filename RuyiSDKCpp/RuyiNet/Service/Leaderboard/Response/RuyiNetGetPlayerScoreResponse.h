#pragma once

#include "../../../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Response recieved from retrieving a player's score.
	/// </summary>
	struct RuyiNetGetPlayerScoreResponse
	{
		/// <summary>
		/// The data class.
		/// </summary>
		struct Data 
		{
			/// <summary>
			/// Represents a player score.
			/// </summary>
			struct Score 
			{
				/// <summary>
				/// The player's score.
				/// </summary>
				int score;

				/// <summary>
				/// Data specified by the game developer.
				/// </summary>
				std::string data;

				/// <summary>
				/// When this score entry was created.
				/// </summary>
				long createdAt;

				/// <summary>
				/// When this score entry was last updated.
				/// </summary>
				long updatedAt;

				/// <summary>
				/// The ID of the leaderboard this score is an entry for.
				/// </summary>
				std::string leaderboardId;

				/// <summary>
				/// The version of the leaderboard this score is an entry for.
				/// </summary>
				int versionId;

				void parseJson(nlohmann::json& j)
				{
					if (!j["score"].is_null()) 
					{
						score = j["score"];
					}
					if (!j["data"].is_null())
					{
						data = j["data"];
					}
					if (!j["createdAt"].is_null())
					{
						createdAt = j["createdAt"];
					}
					if (!j["updatedAt"].is_null())
					{
						updatedAt = j["updatedAt"];
					}
					if (!j["leaderboardId"].is_null())
					{
						leaderboardId = j["leaderboardId"];
					}
					if (!j["versionId"].is_null())
					{
						versionId = j["versionId"];
					}
				}
			};

			/// <summary>
			/// The player's score entry.
			/// </summary>
			Score score;

			void parseJson(nlohmann::json& j)
			{
				if (!j["score"].is_null())
				{
					nlohmann::json scoreJson = j["score"];

					score.parseJson(scoreJson);
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