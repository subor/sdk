#pragma once

//#include "../../RuyiString.h"
#include "../../RuyiNetClient.h"
#include "../../Response/RuyiNetGetCDNResponse.h"
#include "../RuyiNetService.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	class RuyiNetProfileService : public RuyiNetService
	{
	public:
		RuyiNetProfileService(RuyiNetClient * client);

		/// <summary>
		/// Updates the profile picture of the user.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="filename">The image file to use as a profile picture.</param>
		/// <param name="response">The pased data sturcture of return json</param>
		void UpdateUserPicture(int index, const std::string& filename, RuyiNetGetCDNResponse& response);

	private:
		const RuyiString PROFILE_LOCATION = RUYI_STR("profile");
		const RuyiString PROFILE_IMAGE_FILENAME = RUYI_STR("image.jpg");
	};
//}
}}} //namespace