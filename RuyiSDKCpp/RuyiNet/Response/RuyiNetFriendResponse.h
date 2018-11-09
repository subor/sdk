#pragma once

#include <list>
#include <string>

#include "RuyiNetSummaryFriendData.h"
#include "../RuyiNetClient.h"

/// <summary>
/// BrainCloud Friend related data structure
/// <summary>
namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// The response after a add/remove friend is requested.
	/// </summary>
	struct RuyiNetAddRemoveFriendResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The response from the server-side script.
			/// </summary>
			struct Response
			{

				/// <summary>
				/// The reason code of request failure.
				/// </summary>
				int reason_code;
				/// <summary>
				/// The message of request failure
				/// </summary>
				std::string status_message;
				/// <summary>
				/// The status code of the returned data.
				/// by now we only know 200 means add/remove friends successfully
				/// </summary>
				int status;
			};

			/// <summary>
			/// The actual response.
			/// </summary>
			Response response;
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
					nlohmann::json responseJson = dataJson["response"];

					if (!responseJson["status"].is_null())
					{
						data.response.status = responseJson["status"];
					}
					if (!responseJson["reason_code"].is_null())
					{
						data.response.reason_code = responseJson["reason_code"];
					}
					if (!responseJson["status_message"].is_null())
					{
						data.response.status_message = responseJson["status_message"];
					}
				}
			}
		}
	};

	/// <summary>
	/// The response after a friend list is requested.
	/// </summary> 
	struct RuyiNetFriendListResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The response from the server-side script.
			/// </summary>
			struct Response
			{
				/// <summary>
				/// The details of a specific friend.
				/// </summary>
				struct Friend
				{
					/// <summary>
					/// The ID of the player.
					/// </summary>
					std::string playerId;

					/// <summary>
					/// The username of the player.
					/// </summary>
					std::string name;

					/// <summary>
					/// The URL of the player's profile picture.
					/// </summary>
					std::string pictureUrl;

					/// <summary>
					/// The summary data of the player.
					/// </summary>
					RuyiNetSummaryFriendData summaryFriendData;
				};

				/// <summary>
				/// The list of friends.
				/// </summary>
				std::vector<Friend> friends;

				/// <summary>
				/// Timestamp of when the list was retrieved.
				/// </summary>
				long server_time;
			};

			/// <summary>
			/// The actual response.
			/// </summary>
			Response response;

			/// <summary>
			/// Whether or not the server-side script ran successfully.
			/// </summary>
			bool success;
		};
		
		typedef std::vector < Data::Response::Friend > ::iterator _iterator;

		/// <summary>
		/// The response data.
		/// </summary>
		Data data;

		/// <summary>
		/// The status code of the returned data.
		/// </summary>
		int status;

		///the parse method from nlohmann::json to struct data
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

					if (!responseJson.is_object()) return;

					if (!responseJson["server_time"].is_null())
					{
						data.response.server_time = responseJson["server_time"];
					}

					if (!responseJson["friends"].is_null())
					{
						nlohmann::json friendsJson = responseJson["friends"];
						if (friendsJson.is_array())
						{
							for (auto friendJson : friendsJson)
							{
								Data::Response::Friend f;

								if (!friendJson["playerId"].is_null())
								{
									f.playerId = friendJson["playerId"];
								}
								if (!friendJson["name"].is_null())
								{
									f.name = friendJson["name"];
								}
								if (!friendJson["pictureUrl"].is_null())
								{
									f.pictureUrl = friendJson["pictureUrl"];
								}
								if (!friendJson["summaryFriendData"].is_null())
								{
									f.summaryFriendData.parseJson(friendJson["summaryFriendData"]);
								}

								data.response.friends.push_back(f);
							}
						}
					}
				}
			}
		}
	};
}}}