#include "RuyiNetVideoService.h"

namespace Ruyi
{
	RuyiNetVideoService::RuyiNetVideoService(RuyiNetClient * const client)
		: RuyiNetService(client)
	{
	}
	
	void RuyiNetVideoService::UploadVideo(int index, const std::string& cloudFilename, const std::string& localPath, RuyiNetUploadFileResponse& response)
	{
		std::string videoLocation = ToString(VIDEO_LOCATION);
		std::string responseStr;
		mClient->GetBCService()->File_UploadFile(responseStr, videoLocation, cloudFilename, true, false, localPath, index);
		nlohmann::json responseJson1 = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson1);
		if (STATUS_OK == response.status)
		{
			mClient->GetBCService()->File_GetCDNUrl(responseStr, videoLocation, cloudFilename, index);
			nlohmann::json responseJson2 = nlohmann::json::parse(responseStr);
			RuyiNetGetCDNResponse cdnResponse;
			cdnResponse.parseJson(responseJson2);
			if (STATUS_OK == cdnResponse.status)
			{
				nlohmann::json videoEntityJson;
				videoEntityJson["appServerUrl"] = cdnResponse.data.appServerUrl;
				videoEntityJson["cloudFilename"] = cloudFilename;

				nlohmann::json aclJson;
				aclJson["other"] = 1;

				std::string videoEntityStr = videoEntityJson.dump();
				std::string aclStr = aclJson.dump();

				mClient->GetBCService()->Entity_CreateEntity(responseStr, videoLocation, videoEntityStr, aclStr, index);
				nlohmann::json responseJson3 = nlohmann::json::parse(responseStr);
				response.parseJson(responseJson3);
			}
		}
	}
	
	void RuyiNetVideoService::DownloadVideo(int index, const std::string& cloudFilename, RuyiNetResponse& response)
	{
		std::string videoLocation = ToString(VIDEO_LOCATION);
		std::string responseStr;
		mClient->GetBCService()->File_DownloadFile(responseStr, videoLocation, cloudFilename, true, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
	
	void RuyiNetVideoService::ListVideos(int index, RuyiNetListUserFilesResponse& response)
	{
		std::string videoLocation = ToString(VIDEO_LOCATION);
		std::string responseStr;
		mClient->GetBCService()->File_ListUserFiles_SNSFO(responseStr, videoLocation, false, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
	
	void RuyiNetVideoService::DeleteVideo(int index, const std::string& cloudFilename, RuyiNetUploadFileResponse& response)
	{
		std::string videoLocation = ToString(VIDEO_LOCATION);
		std::string responseStr;
		mClient->GetBCService()->File_DeleteUserFile(responseStr, videoLocation, cloudFilename, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
	
	void RuyiNetVideoService::GetVideoUrL(int index, const std::string& cloudFilename, RuyiNetGetCDNResponse& response)
	{
		std::string videoLocation = ToString(VIDEO_LOCATION);
		std::string responseStr;
		mClient->GetBCService()->File_GetCDNUrl(responseStr, videoLocation, cloudFilename, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
	
	void RuyiNetVideoService::GetFriendsVideos(int index, const std::string& profileId, RuyiNetGetFriendsVideosResponse& response)
	{
		std::string videoLocation = ToString(VIDEO_LOCATION);
		std::string responseStr;

		nlohmann::json payloadJson;

		payloadJson["entityType"] = videoLocation;

		std::string payloadStr = payloadJson.dump();

		mClient->GetBCService()->Entity_GetSharedEntitiesListForProfileId(responseStr, profileId, payloadStr, "{}", 100, index);

		nlohmann::json responseJson = nlohmann::json::parse(responseStr);

		response.parseJson(responseJson);
	}
}