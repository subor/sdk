#include "..\Response\RuyiNetUploadFileResponse.h"

#include "RuyiNetProfileService.h"

namespace Ruyi
{
	RuyiNetProfileService::RuyiNetProfileService(RuyiNetClient * client)
		: RuyiNetService(client)
	{
	}

	void RuyiNetProfileService::UpdateUserPicture(int index, RuyiString filename,
		const RuyiNetTask<RuyiNetGetCDNResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		auto profileLocation = ToString(PROFILE_LOCATION);
		auto profileImageFilename = ToString(PROFILE_IMAGE_FILENAME);
		EnqueueTask<RuyiNetGetCDNResponse>([&BCService, &index, &filename, &profileLocation, &profileImageFilename]() -> std::string
		{
			std::string response;
			BCService->File_UploadFile(response, profileLocation, profileImageFilename, true, true, ToString(filename), index);
			RuyiNetUploadFileResponse fileInfo = json::parse(response);

			if (fileInfo.status == 200)
			{
				BCService->File_GetCDNUrl(response, profileLocation, profileImageFilename, index);
				RuyiNetGetCDNResponse cdnUrl = json::parse(response);
				if (cdnUrl.status == 200)
				{
					BCService->PlayerState_UpdateUserPictureUrl(response, cdnUrl.data.appServerUrl, index);
				}
			}

			return response;
		}, callback);
	}
}