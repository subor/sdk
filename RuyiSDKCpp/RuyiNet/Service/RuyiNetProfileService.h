#pragma once

#include "../../RuyiString.h"
#include "../Response/RuyiNetGetCDNResponse.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetProfileService : public RuyiNetService
	{
	public:
		RuyiNetProfileService(RuyiNetClient * client);

		void UpdateUserPicture(int index, RuyiString filename, const RuyiNetTask<RuyiNetGetCDNResponse>::CallbackType & callback);

	private:
		const RuyiString PROFILE_LOCATION = RUYI_STR("profile");
		const RuyiString PROFILE_IMAGE_FILENAME = RUYI_STR("image.jpg");
	};
}