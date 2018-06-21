#pragma once

#include "RuyiNetSummaryFriendData.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	/// <summary>
	/// A profile that can be returned from Ruyi Net operations.
	/// </summary>
	struct RuyiNetProfile
	{
		/// <summary>
		/// The summary data of the player.
		/// </summary>
		RuyiNetSummaryFriendData summaryFriendData;

		/// <summary>
		/// A profile that can be returned from Ruyi Net operations.
		/// </summary>
		std::string profileName;

		/// <summary>
		/// The ID of the player.
		/// </summary>
		std::string profileId;

		/// <summary>
		/// The URL of the player's profile picture.
		/// </summary>
		std::string pictureUrl;
		
		/// <summary>
		/// The email of the player.
		/// </summary>
		std::string email;
		//bool isFriend; //no return json of this param
		
		void parseJson(nlohmann::json& j)
		{
			if (!j["profileId"].is_null()) 
			{
				profileId = j["profileId"];
			}
			if (!j["profileName"].is_null()) 
			{
				profileName = j["profileName"];
			}
			if (!j["pictureUrl"].is_null())
			{
				pictureUrl = j["pictureUrl"];
			}
			if (!j["email"].is_null()) 
			{
				email = j["email"];
			}
			if (!j["summaryFriendData"].is_null())
			{
				nlohmann::json summaryFriendDataJson = j["summaryFriendData"];
				
				if (!summaryFriendDataJson.is_object()) return;

				summaryFriendData.parseJson(summaryFriendDataJson);
			}
		}
	};
//}
}}} //namespace