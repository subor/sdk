#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	/// <summary>
	/// The summary data of the player.
	/// </summary>
	struct RuyiNetSummaryFriendData
	{
		/// <summary>
		/// The player's gender.
		/// </summary>
		std::string gender;

		/// <summary>
		/// The player's date of birth.
		/// </summary>
		std::string dob;

		/// <summary>
		/// The location of the player.
		/// </summary>
		std::string location;
		
		void parseJson(nlohmann::json& j)
		{
			if (!j["gender"].is_null()) 
			{
				gender = j["gender"];
			}
			if (!j["dob"].is_null())
			{
				dob = j["dob"];
			}
			if (!j["location"].is_null())
			{
				location = j["location"];
			}
		}
	};

//}
}}} //namespace