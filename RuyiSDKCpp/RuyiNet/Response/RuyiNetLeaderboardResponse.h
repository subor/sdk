#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// Contains the leaderboard returned from a leaderboard request.
	/// </summary>
	struct RuyiNetLeaderboardResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The response.
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
					/// When this entry was last updated.
					/// </summary>
					long updatedAt;
					/// <summary>
					/// The index of this entry in the returned data.
					/// </summary>
					int index;
					/// <summary>
					/// The rank of the player in the leaderboard.
					/// </summary>
					int rank;
					/// <summary>
					/// The user name of the player.
					/// </summary>
					std::string name;
					/// <summary>
					/// The URL of the users profile image.
					/// </summary>
					std::string pictureUrl;
					/// <summary>
					/// Whether or not this player is friends with the current user.
					/// </summary>
					bool isFriend;
				};

				/// <summary>
				/// The leaderboard.
				/// </summary>
				std::list<LeaderboardData> leaderboard;
				/// <summary>
				/// The version of the leaderboard.
				/// </summary>
				int versionId;
				/// <summary>
				/// The ID the of the leaderboard the data was retrieved from.
				/// </summary>
				std::string leaderboardId;
				/// <summary>
				/// How long before the leaderboard will be reset, in milliseconds.
				/// </summary>
				int timeBeforeReset;
				/// <summary>
				/// Are there more entries after these?
				/// </summary>
				bool moreAfter;
				/// <summary>
				/// Are there more entries before these?
				/// </summary>
				bool moreBefore;
			};

			/// <summary>
			/// The response.
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

					if (responseJson.is_object()) 
					{
						if (!responseJson["server_time"].is_null())
						{
							data.response.server_time = responseJson["server_time"];
						}
						if (!responseJson["versionId"].is_null())
						{
							data.response.versionId = responseJson["versionId"];
						}
						if (!responseJson["leaderboardId"].is_null())
						{
							data.response.leaderboardId = responseJson["leaderboardId"];
						}
						if (!responseJson["timeBeforeReset"].is_null())
						{
							data.response.timeBeforeReset = responseJson["timeBeforeReset"];
						}
						if (!responseJson["moreAfter"].is_null())
						{
							data.response.moreAfter = responseJson["moreAfter"];
						}
						if (!responseJson["moreBefore"].is_null())
						{
							data.response.moreBefore = responseJson["moreBefore"];
						}
						if (!responseJson["leaderboard"].is_null())
						{
							nlohmann::json leaderboardJson = responseJson["leaderboard"];
							if (leaderboardJson.is_array())
							{
								for (auto leaderboardDataJson : leaderboardJson)
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
									if (!leaderboardDataJson["index"].is_null())
									{
										leaderboardData.index = leaderboardDataJson["index"];
									}
									if (!leaderboardDataJson["rank"].is_null())
									{
										leaderboardData.index = leaderboardDataJson["rank"];
									}
									if (!leaderboardDataJson["name"].is_null())
									{
										leaderboardData.index = leaderboardDataJson["name"];
									}
									if (!leaderboardDataJson["pictureUrl"].is_null())
									{
										leaderboardData.index = leaderboardDataJson["pictureUrl"];
									}
									if (!leaderboardDataJson["isFriend"].is_null())
									{
										leaderboardData.index = leaderboardDataJson["isFriend"];
									}

									data.response.leaderboard.push_back(leaderboardData);
								}
							}
						}
					}
				}
			}
		}
	};
}}}