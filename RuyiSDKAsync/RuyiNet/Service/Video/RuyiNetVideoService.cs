using Newtonsoft.Json;
using System;

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
        /// <param name="callback">The function to call when the task completes.</param>
        public void UploadVideo(int index, string cloudFilename, string localPath,
            RuyiNetTask<RuyiNetUploadFileResponse>.CallbackType callback)
        {
            EnqueuePlatformTask(index, () =>
            {
                var response = mClient.BCService.File_UploadFileAsync(VIDEO_LOCATION, cloudFilename, true, false, localPath, index, token).Result;
                var uploadedFile = JsonConvert.DeserializeObject<RuyiNetUploadFileResponse>(response);

                if (uploadedFile.status == RuyiNetHttpStatus.OK)
                {
                    var cdnResponse = mClient.BCService.File_GetCDNUrlAsync(VIDEO_LOCATION, cloudFilename, index, token).Result;
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

                        mClient.BCService.Entity_CreateEntityAsync(VIDEO_LOCATION, videoEntity, acl, index, token).Wait();
                    }
                }

                return response;
            }, callback);
        }

        /// <summary>
        /// Prepares a video download.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void DownloadVideo(int index, string cloudFilename, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueuePlatformTask(index, () =>
            {
                return mClient.BCService.File_DownloadFileAsync(VIDEO_LOCATION, cloudFilename, true, index, token).Result;
            }, callback);
        }

        /// <summary>
        /// List all the current user's videos.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ListVideos(int index, RuyiNetTask<RuyiNetListUserFilesResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.File_ListUserFiles_SNSFOAsync(VIDEO_LOCATION, false, index, token).Result;
            }, callback);
        }

        /// <summary>
        /// Deletes a video.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void DeleteVideo(int index, string cloudFilename,
            RuyiNetTask<RuyiNetUploadFileResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.File_DeleteUserFileAsync(VIDEO_LOCATION, cloudFilename, index, token).Result;
            }, callback);
        }

        /// <summary>
        /// Returns the CDN url for a video.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetVideoUrl(int index, string cloudFilename,
            RuyiNetTask<RuyiNetGetCDNResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.File_GetCDNUrlAsync(VIDEO_LOCATION, cloudFilename, index, token).Result;
            }, callback);
        }
        /// <summary>
        /// Returns a list of friends videos.
        /// </summary>
        /// <param name="index">The index of the user</param>
        /// <param name="profileId">The profile of the ID to fetch the videos for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetFriendsVideos(int index, string profileId,
            RuyiNetTask<RuyiNetGetFriendsVideosResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var query = JsonConvert.SerializeObject(new VideoQuery()
                {
                    entityType = VIDEO_LOCATION
                });
                
                return mClient.BCService.Entity_GetSharedEntitiesListForProfileIdAsync(profileId, query, "{}", 100, index, token).Result;
            }, callback);
        }

        [Serializable]
        private class VideoQuery
        {
            public string entityType;
        }

        static System.Threading.CancellationToken token = System.Threading.CancellationToken.None;
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
