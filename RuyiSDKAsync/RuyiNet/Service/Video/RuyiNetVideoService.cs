using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Allows users to upload videos to their individual accounts.
    /// TODO: about the file upload/download, we need a second solution like still
    /// transfer the whole file from SDK to Layer0, because we need to use the SDK on mobile,
    /// we can identify this kind of situation from the SDKContext.
    /// </summary>
    public class RuyiNetVideoService : RuyiNetService
    {
        const string VIDEO_LOCATION = "video";

        /// <summary>
        /// Create the video service.
        /// </summary>
        /// <param name="client">The Ruyi Net client.</param>
        internal RuyiNetVideoService(RuyiNetClient client)
        : base(client)
        {
        }

        /// <summary>
        /// Prepares a video upload.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        /// <param name="localPath">The path and fileName of the local file.</param>
        public Task<RuyiNetUploadFileResponse> UploadVideo(int index, string cloudFilename, string localPath)
        {
            return EnqueuePlatformTask<RuyiNetUploadFileResponse>(index, async () =>
            {
                var response = await mClient.BCService.File_UploadFileAsync(VIDEO_LOCATION, cloudFilename, true, false, localPath, index, token);
                var uploadedFile = JsonConvert.DeserializeObject<RuyiNetUploadFileResponse>(response);

                if (uploadedFile.status == RuyiNetHttpStatus.OK)
                {
                    var cdnResponse = await mClient.BCService.File_GetCDNUrlAsync(VIDEO_LOCATION, cloudFilename, index, token);
                    var cdnUrl = JsonConvert.DeserializeObject<RuyiNetGetCDNResponse>(cdnResponse);
                    if (cdnUrl.status == RuyiNetHttpStatus.OK)
                    {
                        var videoEntity = JsonConvert.SerializeObject(new RuyiNetVideo()
                        {
                            appServerUrl = cdnUrl.data.appServerUrl,
                            cloudFilename = cloudFilename
                        });

                        var acl = JsonConvert.SerializeObject(new RuyiNetAcl()
                        {
                            other = 1
                        });

                        await mClient.BCService.Entity_CreateEntityAsync(VIDEO_LOCATION, videoEntity, acl, index, token);
                    }
                }

                return response;
            });
        }

        /// <summary>
        /// Prepares a video download.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        public Task<RuyiNetResponse> DownloadVideo(int index, string cloudFilename)
        {
            return EnqueuePlatformTask<RuyiNetResponse>(index, async () =>
            {
                return await mClient.BCService.File_DownloadFileAsync(VIDEO_LOCATION, cloudFilename, true, index, token);
            });
        }

        /// <summary>
        /// List all the current user's videos.
        /// </summary>
        /// <param name="index">The index of user</param>
        public async Task<RuyiNetListUserFilesResponse> ListVideos(int index)
        {
            var resp = await mClient.BCService.File_ListUserFiles_SNSFOAsync(VIDEO_LOCATION, false, index, token);
            return mClient.Process<RuyiNetListUserFilesResponse>(resp);
        }

        /// <summary>
        /// Deletes a video.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        public async Task<RuyiNetUploadFileResponse> DeleteVideo(int index, string cloudFilename)
        {
            var resp = await mClient.BCService.File_DeleteUserFileAsync(VIDEO_LOCATION, cloudFilename, index, token);
            return mClient.Process<RuyiNetUploadFileResponse>(resp);
        }

        /// <summary>
        /// Returns the CDN url for a video.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        public async Task<RuyiNetGetCDNResponse> GetVideoUrl(int index, string cloudFilename)
        {
            var resp = await mClient.BCService.File_GetCDNUrlAsync(VIDEO_LOCATION, cloudFilename, index, token);
            return mClient.Process<RuyiNetGetCDNResponse>(resp);
        }
        /// <summary>
        /// Returns a list of friends videos.
        /// </summary>
        /// <param name="index">The index of the user</param>
        /// <param name="profileId">The profile of the ID to fetch the videos for.</param>
        public async Task<RuyiNetGetFriendsVideosResponse> GetFriendsVideos(int index, string profileId)
        {
            var query = JsonConvert.SerializeObject(new VideoQuery()
            {
                entityType = VIDEO_LOCATION
            });

            var resp = await mClient.BCService.Entity_GetSharedEntitiesListForProfileIdAsync(profileId, query, "{}", 100, index, token);
            return mClient.Process<RuyiNetGetFriendsVideosResponse>(resp);
        }

        [Serializable]
        private class VideoQuery
        {
            public string entityType;
        }
    }

    /// <summary>
    /// Determines the permissions others have to access a players entities 
    /// (0 = no access, 1 = read-only, 2 = read/write).
    /// </summary>
    [Serializable]
    public class RuyiNetAcl
    {
        /// <summary>
        /// Permissions for other users.
        /// </summary>
        public int other;
    }

    /// <summary>
    /// Represents a video entity.
    /// </summary>
    [Serializable]
    public class RuyiNetVideo
    {
        /// <summary>
        /// The cloud filename of the video.
        /// </summary>
        public string cloudFilename;

        /// <summary>
        /// The URL of the video.
        /// </summary>
        public string appServerUrl;
    }

    /// <summary>
    /// The response from GetFriendsVideos
    /// </summary>
    [Serializable]
    public class RuyiNetGetFriendsVideosResponse
    {
        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;

        /// <summary>
        /// The response data.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// A single returned entity.
            /// </summary>
            public class Entity
            {
                /// <summary>
                /// The ID of the entity.
                /// </summary>
                public string entityId;

                /// <summary>
                /// The type of entity.
                /// </summary>
                public string entityType;

                /// <summary>
                /// The current version of the entity.
                /// </summary>
                public int version;

                /// <summary>
                /// The actual net video data.
                /// </summary>
                public RuyiNetVideo data;

                /// <summary>
                /// The access control list of the video.
                /// </summary>
                public RuyiNetAcl acl;

                /// <summary>
                /// When the video was created.
                /// </summary>
                public int createdAt;

                /// <summary>
                /// When the video was last updated.
                /// </summary>
                public int updatedAt;
            }

            /// <summary>
            /// The list of video entities.
            /// </summary>
            public Entity[] entities;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;
    }
}
