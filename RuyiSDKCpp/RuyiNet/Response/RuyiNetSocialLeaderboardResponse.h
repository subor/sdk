#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi
{
	/// <summary>
	/// A response from retrieving social leaderboard data.
	/// </summary>
	struct RuyiNetSocialLeaderboardResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// THe response.
			/// </summary>
			struct Response
			{
				/// <summary>
				/// Timestamp of when the leaderboard data was retrieved.
				/// </summary>
				long server_time;

				/// <summary>
				/// A single leaderboard entry.
				/// </summary>
				struct LeaderboardData
				{
					/// <summary>
					/// The ID of the player this entry relates to.
					/// </summary>
					std::string playerId;
					/// <summary>
					/// The score.
					/// </summary>
					int score;
					/// <summary>
					/// When this entry was created.
					/// </summary>
					long createdAt;
					/// <summary>
					/// When this entry was updated.
					/// </summary>
					long updatedAt;
					/// <summary>
					/// The user name of the player.
					/// </summary>
					std::string playerName;
					/// <summary>
					/// The URL of the users profile image.
					/// </summary>
					std::string pictureUrl;
				};

				/// <summary>
				/// The leaderboard.
				/// </summary>
				//std::list<LeaderboardData> leaderboard;
				std::list<LeaderboardData> social_leaderboard;

				/// <summary>
				/// The ID the of the leaderboard the data was retrieved from.
				/// </summary>
				std::string leaderboardId;
				/// <summary>
				/// How long before the leaderboard will be reset, in milliseconds.
				/// </summary>
				int timeBeforeReset;
			};

			/// <summary>
			/// THe response.
			/// </summary>
			Response response;
			/// <summary>
			/// Whether or not the server-side script succeeded.
			/// </summary>
			bool success;
		};

		/// <summary>
		/// The response data.
		/// </summary>
		Data data;
		/// <summary>
		/// The status code of this response.
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
					nlohmann::json responseJson = dataJson["response"];

					if (!responseJson["server_time"].is_null())
					{
						data.response.server_time = responseJson["server_time"];
					}
					if (!responseJson["leaderboardId"].is_null())
					{
						data.response.leaderboardId = responseJson["leaderboardId"];
					}
					if (!responseJson["timeBeforeReset"].is_null())
					{
						data.response.timeBeforeReset = responseJson["timeBeforeReset"];
					}
					if (!responseJson["leaderboard"].is_null())
					{
						nlohmann::json leaderboardJson = responseJson["social_leaderboard"];

						if (leaderboardJson.is_array())
						{
							for(auto leaderboardDataJson : leaderboardJson)
							{
								Data::Response::LeaderboardData leaderboardData;
								
								if (!leaderboardDataJson["playerId"].is_null())
								{
									leaderboardData.playerId = leaderboardDataJson["playerId"];
								}
								if (!leaderboardDataJson["score"].is_null())
								{
									leaderboardData.score = leaderboardDataJson["score"];
								}
								if (!leaderboardDataJson["createdAt"].is_null())
								{
									leaderboardData.createdAt = leaderboardDataJson["createdAt"];
								}
								if (!leaderboardDataJson["updatedAt"].is_null())
								{
									leaderboardData.updatedAt = leaderboardDataJson["updatedAt"];
								}
								if (!leaderboardDataJson["playerName"].is_null())
								{
									leaderboardData.playerName = leaderboardDataJson["playerName"];
								}
								if (!leaderboardDataJson["pictureUrl"].is_null())
								{
									leaderboardData.pictureUrl = leaderboardDataJson["pictureUrl"];
								}

								data.response.social_leaderboard.push_back(leaderboardData);
							}
						}
					}
				}
			}
		}
	};
}