#pragma once

#include <list>
#include <string>

#include "RuyiNetSummaryFriendData.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// The response after a matching-making is requested.
	/// </summary> 
	struct RuyiNetFindPlayersResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The data struct of match player
			/// </summary>
			struct MatchesFound
			{
				/// <summary>
				/// The ID of the player.
				/// </summary>
				std::string playerId;
				/// <summary>
				/// A name that can be returned from Ruyi Net operations.
				/// </summary>
				std::string playerName;
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
			/// The matches player data list
			/// </summary>
			std::list<MatchesFound> matchesFound;

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

				if (!dataJson["matchesFound"].is_null())
				{
					nlohmann::json matchesFoundJson = dataJson["matchesFound"];
										
					if (matchesFoundJson.is_array()) 
					{
						for (auto matches : matchesFoundJson) 
						{
							Data::MatchesFound match;

							if (!matches["playerId"].is_null())
							{
								match.playerId = matches["playerId"];
							}
							if (!matches["playerName"].is_null())
							{
								match.playerName = matches["playerName"];
							}
							if (!matches["pictureUrl"].is_null())
							{
								match.pictureUrl = matches["pictureUrl"];
							}
							if (!matches["summaryFriendData"].is_null())
							{
								nlohmann::json summaryFriendJson = matches["summaryFriendData"];

								match.summaryFriendData.parseJson(summaryFriendJson);
							}
							data.matchesFound.push_back(match);
						}
					}
				}
			}
		}
	};
}}} 

	
