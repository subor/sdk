#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// Response recieved from an achievemet request (gamification service).
	/// </summary>
	struct RuyiNetAchievementResponse 
	{
		
		/// <summary>
		/// The data class.
		/// </summary>
		struct Data 
		{ 
			
			/// <summary>
			/// Represents an achievement
			/// </summary>
			struct Achievement
			{		
				
				/// <summary>
				/// The ID of the achievement.
				/// </summary>
				std::string achievementId;

				/// <summary>
				/// Whether or not the current player has earned this achievement.
				/// </summary>
				std::string status;

				/// <summary>
				/// The ID of the game this achievement belongs to.
				/// </summary>
				std::string gameId;

				/// <summary>
				/// The achievement's title.
				/// </summary>
				std::string title;

				/// <summary>
				/// A description of the achievement.
				/// </summary>
				std::string description;

				/// <summary>
				/// Whether or not the achievement is invisible until it's earned.
				/// </summary>
				bool invisibleUntilEarned;

				/// <summary>
				/// The URL of the image related to this achievement.
				/// </summary>
				std::string imageUrl;

				/// <summary>
				/// Any extra data attached by the developer.
				/// </summary>
				std::string extraData;

				/// <summary>
				/// The XP awarded when this achievement is gained.
				/// </summary>
				int xpAwarded;

				/// <summary>
				/// The amount of coin awarded when this achievement is gained.
				/// </summary>
				int coinAwarded;
				
				void parseJson(nlohmann::json& j) 
				{					
					if (!j["achievementId"].is_null()) achievementId = j["achievementId"]; 					
					if (!j["status"].is_null()) status = j["status"];
					if (!j["gameId"].is_null()) gameId = j["gameId"];
					if (!j["title"].is_null()) title = j["title"];
					if (!j["description"].is_null()) description = j["description"];
					if (!j["invisibleUntilEarned"].is_null()) invisibleUntilEarned = j["invisibleUntilEarned"];
					if (!j["imageUrl"].is_null()) imageUrl = j["imageUrl"];
					if (!j["extraData"].is_null()) extraData = j["extraData"];
					if (!j["xpAwarded"].is_null()) xpAwarded = j["xpAwarded"];
					if (!j["coinAwarded"].is_null()) coinAwarded = j["coinAwarded"];
					
				}	
				
			};
			
			std::vector<Achievement> achievements;

			void parseJson(nlohmann::json& j) 
			{				
				if (!j["achievements"].is_null()) 
				{
					nlohmann::json _achievements = j["achievements"];

					if (!_achievements.is_object()) return;

					if (_achievements.is_array()) 
					{
						for (auto achievementJson : _achievements) 
						{
							Achievement _achievement;

							_achievement.parseJson(achievementJson);

							achievements.push_back(_achievement);
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
			if (!j["status"].is_null()) status = j["status"];

			if (!j["data"].is_null()) 
			{
				nlohmann::json dataJson = j["data"];

				data.parseJson(dataJson);
			}
		}
	};

}}}