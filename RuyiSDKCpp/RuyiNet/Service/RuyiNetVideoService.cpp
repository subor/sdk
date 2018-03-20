#include "RuyiNetVideoService.h"

namespace Ruyi
{
	RuyiNetVideoService::RuyiNetVideoService(RuyiNetClient * const client)
		: RuyiNetService(client)
	{
	}

	void RuyiNetVideoService::UploadVideo(int index, const RuyiString & cloudFilename, const RuyiString & localPath,
		const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		auto videoLocation = ToString(VIDEO_LOCATION);
		auto filename = ToString(cloudFilename);
		EnqueuePlatformTask<RuyiNetUploadFileResponse>(index,
			[&BCService, &videoLocation, &index, &filename, &localPath]() -> std::string
		{
			std::string response;
			BCService->File_UploadFile(response, videoLocation, filename, true, false, ToString(localPath), index);
			RuyiNetUploadFileResponse uploadFileResponse = json::parse(response);
			if (uploadFileResponse.status == 200)
			{
				std::string cdnResponse;
				BCService->File_GetCDNUrl(cdnResponse, videoLocation, filename, index);
				RuyiNetGetCDNResponse cdnUrl = json::parse(cdnResponse);
				if (cdnUrl.status == 200)
				{
					json videoEntity =
					{
						{ "appServerUrl", cdnUrl.data.appServerUrl },
						{ "cloudFilename", filename }
					};

					json acl =
					{
						{"other", 1 }
					};

					std::string entityResponse;
					BCService->Entity_CreateEntity(entityResponse, videoLocation, videoEntity, acl, index);
				}
			}

			return response;
		}, callback);
	}

	void RuyiNetVideoService::DownloadVideo(int index, const RuyiString & cloudFilename)
	{

	}

	void RuyiNetVideoService::ListVideos(int index, const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		auto videoLocation = ToString(VIDEO_LOCATION);
		EnqueuePlatformTask<RuyiNetListUserFilesResponse>(index, [&BCService, &videoLocation, &index]() -> std::string
		{
			std::string response;
			BCService->File_ListUserFiles_SNSFO(response, videoLocation, false, index);
			return response;
		}, callback);
	}

	void RuyiNetVideoService::DeleteVideo(int index, const RuyiString & cloudFilename,
		const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		auto videoLocation = ToString(VIDEO_LOCATION);
		auto filename = ToString(cloudFilename);
		EnqueuePlatformTask<RuyiNetUploadFileResponse>(index, 
			[&BCService, &videoLocation, &filename, &index]() -> std::string
		{
			std::string response;
			BCService->File_DeleteUserFile(response, videoLocation, filename, index);
			return response;
		}, callback);
	}

	void RuyiNetVideoService::GetVideoUrL(int index, const RuyiString & cloudFilename,
		const RuyiNetTask<RuyiNetGetCDNResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		auto videoLocation = ToString(VIDEO_LOCATION);
		auto filename = ToString(cloudFilename);
		EnqueuePlatformTask<RuyiNetGetCDNResponse>(index,
			[&BCService, &videoLocation, &filename, &index]() -> std::string
		{
			std::string response;
			BCService->File_GetCDNUrl(response, videoLocation, filename, index);
			return response;
		}, callback);
	}

	void RuyiNetVideoService::GetFriendsVideos(int index, const RuyiString & profileId,
		const RuyiNetTask<RuyiNetGetFriendsVideosResponse>::CallbackType callback)
	{
		auto BCService = mClient->GetBCService();
		auto videoLocation = ToString(VIDEO_LOCATION);
		EnqueuePlatformTask<RuyiNetGetFriendsVideosResponse>(index,
			[&BCService, &videoLocation, &profileId, &index]() -> std::string
		{
			json payload = 
			{
				{ "entityType", videoLocation }
			};

			std::string response;
			BCService->Entity_GetSharedEntitiesListForProfileId(response, ToString(profileId), payload, {}, 100, index);
			return response;
		}, callback);
	}
}