#pragma once

#include "../Response/RuyiNetGetCDNResponse.h"
#include "../Response/RuyiNetGetFriendsVideosResponse.h"
#include "../Response/RuyiNetListUserFilesResponse.h"
#include "../Response/RuyiNetUploadFileResponse.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetVideoService : public RuyiNetService
	{
	public:
		RuyiNetVideoService(RuyiNetClient * const client);
		void UploadVideo(int index, const RuyiString & cloudFilename, const RuyiString & localPath,
			const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback);
		void DownloadVideo(int index, const RuyiString & cloudFilename);
		void ListVideos(int index, const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback);
		void DeleteVideo(int index, const RuyiString & cloudFilename,
			const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback);
		void GetVideoUrL(int index, const RuyiString & cloudFilename,
			const RuyiNetTask<RuyiNetGetCDNResponse>::CallbackType & callback);
		void GetFriendsVideos(int index, const RuyiString & profileId,
			const RuyiNetTask<RuyiNetGetFriendsVideosResponse>::CallbackType callback);

	private:
		const RuyiString VIDEO_LOCATION = RUYI_STR("video");
	};
}