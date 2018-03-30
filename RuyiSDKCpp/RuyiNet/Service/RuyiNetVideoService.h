#pragma once

#include "../RuyiNetClient.h"
#include "../Response/RuyiNetGetCDNResponse.h"
#include "../Response/RuyiNetGetFriendsVideosResponse.h"
#include "../Response/RuyiNetListUserFilesResponse.h"
#include "../Response/RuyiNetUploadFileResponse.h"
#include "../Response/RuyiNetResponse.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetVideoService : public RuyiNetService
	{
	public:
		RuyiNetVideoService(RuyiNetClient * const client);
		
		/// <summary>
		/// Prepares a video upload.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>
		/// <param name="localPath">The path and fileName of the local file.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void UploadVideo(int index, const std::string& cloudFilename, const std::string& localPath, RuyiNetUploadFileResponse& response);

		/// <summary>
		/// Prepares a video download.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void DownloadVideo(int index, const std::string& cloudFilename, RuyiNetResponse& response);
		
		/// <summary>
		/// List all the current user's videos.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void ListVideos(int index, RuyiNetListUserFilesResponse& response);
		
		/// <summary>
		/// Deletes a video.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void DeleteVideo(int index, const std::string& cloudFilename, RuyiNetUploadFileResponse& response);

		/// <summary>
		/// Returns the CDN url for a video.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>	
		/// <param name="response">The parsed data struct of return json.</param>
		void GetVideoUrL(int index, const std::string& cloudFilename, RuyiNetGetCDNResponse& response);
		
		/// <summary>
		/// Returns a list of friends videos.
		/// </summary>
		/// <param name="index">The index of the user</param>
		/// <param name="profileId">The profile of the ID to fetch the videos for.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void GetFriendsVideos(int index, const std::string& profileId, RuyiNetGetFriendsVideosResponse& response);
			
	private:
		const RuyiString VIDEO_LOCATION = RUYI_STR("video");
	};
}