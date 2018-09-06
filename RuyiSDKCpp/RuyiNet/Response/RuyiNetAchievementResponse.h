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
				std::string id;

				/// <summary>
				/// Whether or not the current player has earned this achievement.
				/// </summary>
				std::string status;
				
				void parseJson(nlohmann::json& j) 
				{					
					if (!j["id"].is_null()) id = j["id"]; 					
					if (!j["status"].is_null()) status = j["status"];			
				}	
				
			};
			
			std::vector<Achievement> achievements;

			void parseJson(nlohmann::json& j) 
			{				
				if (!j["achievements"].is_null()) 
				{
					nlohmann::json _achievements = j["achievements"];

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