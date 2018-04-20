#include "..\Response\RuyiNetUploadFileResponse.h"

#include "RuyiNetProfileService.h"

namespace Ruyi
{
	RuyiNetProfileService::RuyiNetProfileService(RuyiNetClient * client)
		: RuyiNetService(client)
	{
	}
	
	void RuyiNetProfileService::UpdateUserPicture(int index, const std::string& filename, RuyiNetGetCDNResponse& response)
	{
		auto BCService = mClient->GetBCService();
		auto profileLocation = ToString(PROFILE_LOCATION);
		auto profileImageFilename = ToString(PROFILE_IMAGE_FILENAME);

		try
		{
			std::string responseStr;
			BCService->File_UploadFile(responseStr, profileLocation, profileImageFilename, true, true, filename, index);
			nlohmann::json responseJson1 = nlohmann::json::parse(responseStr);
			RuyiNetUploadFileResponse responseFileInfo;
			responseFileInfo.parseJson(responseJson1);

			if (STATUS_OK == responseFileInfo.status)
			{
				BCService->File_GetCDNUrl(responseStr, profileLocation, profileImageFilename, index);
				nlohmann::json responseJson2 = nlohmann::json::parse(responseStr);
				RuyiNetGetCDNResponse responseCDNUrl;
				responseCDNUrl.parseJson(responseJson2);

				if (STATUS_OK == responseCDNUrl.status)
				{
					BCService->PlayerState_UpdateUserPictureUrl(responseStr, responseCDNUrl.data.appServerUrl, index);
					nlohmann::json responseJson3 = nlohmann::json::parse(responseStr);
					response.parseJson(responseJson3);
				}
			}
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
}