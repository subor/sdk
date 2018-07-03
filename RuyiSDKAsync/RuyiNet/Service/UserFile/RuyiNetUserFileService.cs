using System;
using System.Threading.Tasks;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Allows users to upload files to their individual accounts
    /// </summary>
    public class RuyiNetUserFileService : RuyiNetService
    {
        /// <summary>
        /// Create the user file service.
        /// </summary>
        /// <param name="client">The Ruyi Net client.</param>
        internal RuyiNetUserFileService(RuyiNetClient client)
        : base(client)
        {
        }

        /// <summary>
        /// Prepares a user file upload.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudPath">The desired cloud path of the file.</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        /// <param name="shareable">True if the file is shareable.</param>
        /// <param name="replaceIfExists">Whether to replace file if it exists.</param>
        /// <param name="localPath">The path and fileName of the local file.</param>
        public async Task<RuyiNetUploadFileResponse> UploadFile(int index, string cloudPath, string cloudFilename,
            bool shareable, bool replaceIfExists, string localPath)
        {
            var resp = await mClient.BCService.File_UploadFileAsync(cloudPath, cloudFilename, shareable, replaceIfExists, localPath, index, token);
            return mClient.Process<RuyiNetUploadFileResponse>(resp);
        }

        /// <summary>
        /// Cancels an upload.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="uploadId">The ID of the upload.</param>
        public Task CancelUpload(int index, string uploadId)
        {
            return mClient.BCService.File_CancelUploadAsync(uploadId, index, token);
        }

        /// <summary>
        /// Returns the number of bytes uploaded or -1 if upload not found.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="uploadId">The ID of the upload.</param>
        /// <returns></returns>
        public Task<long> GetUploadBytesTransferred(int index, string uploadId)
        {
            return mClient.BCService.File_GetUploadBytesTransferredAsync(uploadId, index, token);
        }

        /// <summary>
        /// Returns the progress of the given upload from 0.0 to 1.0 or -1 if upload not found.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="uploadId">The ID of the upload.</param>
        public Task<double> GetUploadProgress(int index, string uploadId)
        {
            return mClient.BCService.File_GetUploadProgressAsync(uploadId, index, token);
        }

        /// <summary>
        /// Returns the total number of bytes that will be uploaded or -1 if upload not found.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="uploadId">The ID of the upload.</param>
        /// <returns></returns>
        public Task<long> GetUploadTotalBytesToTransfer(int index, string uploadId)
        {
            return mClient.BCService.File_GetUploadTotalBytesToTransferAsync(uploadId, index, token);
        }

        /// <summary>
        /// List all user files.
        /// </summary>
        /// <param name="index">The index of user</param>
        public async Task<RuyiNetListUserFilesResponse> ListUserFiles(int index)
        {
            var resp = await mClient.BCService.File_ListUserFiles_SFOAsync(index, token);
            return mClient.Process<RuyiNetListUserFilesResponse>(resp);
        }

        /// <summary>
        /// List all user files.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudPath">File path.</param>
        /// <param name="recursive">Whether to recurse into sub-directories</param>
        public async Task<RuyiNetListUserFilesResponse> ListUserFiles(int index, string cloudPath, bool recursive)
        {
            var resp = await mClient.BCService.File_ListUserFiles_SNSFOAsync(cloudPath, recursive, index, token);
            return mClient.Process<RuyiNetListUserFilesResponse>(resp);
        }

        /// <summary>
        /// Deletes a single user file.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudPath">The desired cloud path of the file.</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        public async Task<RuyiNetUploadFileResponse> DeleteUserFile(int index, string cloudPath, string cloudFilename)
        {
            var resp = await mClient.BCService.File_DeleteUserFileAsync(cloudPath, cloudFilename, index, token);
            return mClient.Process<RuyiNetUploadFileResponse>(resp);
        }

        /// <summary>
        /// Deletes multiple user files.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudPath">The desired cloud path of the file.</param>
        /// <param name="recursive">Whether to recurse into sub-directories</param>
        public async Task<RuyiNetListUserFilesResponse> DeleteUserFiles(int index, string cloudPath, bool recursive)
        {
            var resp = await mClient.BCService.File_DeleteUserFilesAsync(cloudPath, recursive, index, token);
            return mClient.Process<RuyiNetListUserFilesResponse>(resp);
        }

        /// <summary>
        /// Returns the CDN url for a file object.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="cloudPath">The desired cloud path of the file.</param>
        /// <param name="cloudFilename">The desired cloud fileName of the file.</param>
        public async Task<RuyiNetGetCDNResponse> GetCDNUrl(int index, string cloudPath, string cloudFilename)
        {
            var resp = await mClient.BCService.File_GetCDNUrlAsync(cloudPath, cloudFilename, index, token);
            return mClient.Process<RuyiNetGetCDNResponse>(resp);
        }
    }

    /// <summary>
    /// The response after uploading a file.
    /// </summary>
    [Serializable]
    public class RuyiNetUploadFileResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The details of the file to upload.
            /// </summary>
            [Serializable]
            public class FileDetails
            {
                /// <summary>
                /// When the file was last updated.
                /// </summary>
                public long updatedAt;

                /// <summary>
                /// The size of the file.
                /// </summary>
                public int fileSize;

                /// <summary>
                /// The file type.
                /// </summary>
                public string fileType;

                /// <summary>
                /// When the file expires.
                /// </summary>
                public long expiresAt;

                /// <summary>
                /// Whether or not the file is shareable.
                /// </summary>
                public bool shareable;

                /// <summary>
                /// The ID of this upload.
                /// </summary>
                public string uploadId;

                /// <summary>
                /// When the file was created.
                /// </summary>
                public long createdAt;

                /// <summary>
                /// The profile ID of the owning player.
                /// </summary>
                public string profileId;

                /// <summary>
                /// The ID of the game the file relates to.
                /// </summary>
                public string gameId;

                /// <summary>
                /// The path to the file.
                /// </summary>
                public string path;

                /// <summary>
                /// The filename.
                /// </summary>
                public string filename;

                /// <summary>
                /// Whether the file will replace a file if it already exists.
                /// </summary>
                public bool replaceIfExists;

                /// <summary>
                /// The location of the file on the cloud.
                /// </summary>
                public string cloudPath;
            }

            /// <summary>
            /// The details of the file to upload.
            /// </summary>
            public FileDetails fileDetails;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;
    }

    /// <summary>
    /// The response from a List User Files request.
    /// </summary>
    [Serializable]
    public class RuyiNetListUserFilesResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The details of the file to upload.
            /// </summary>
            [Serializable]
            public class FileDetails
            {
                /// <summary>
                /// When the file was last updated.
                /// </summary>
                public long updatedAt;

                /// <summary>
                /// When the file was uploaded.
                /// </summary>
                public long uploadedAt;

                /// <summary>
                /// The size of the file.
                /// </summary>
                public int fileSize;

                /// <summary>
                /// Whether or not the file is shareable.
                /// </summary>
                public bool shareable;

                /// <summary>
                /// When the file was created.
                /// </summary>
                public long createdAt;

                /// <summary>
                /// The profile ID of the owning player.
                /// </summary>
                public string profileId;
                
                /// <summary>
                /// The ID of the game the file relates to.
                /// </summary>
                public string gameId;

                /// <summary>
                /// The path to the file.
                /// </summary>
                public string cloudPath;

                /// <summary>
                /// The filename.
                /// </summary>
                public string cloudFilename;

                /// <summary>
                /// The URL to download the file.
                /// </summary>
                public string downloadUrl;

                /// <summary>
                /// The location of the file on the cloud.
                /// </summary>
                public string cloudLocation;
            }

            /// <summary>
            /// The list of files.
            /// </summary>
            public FileDetails[] fileList;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;
    }

    /// <summary>
    /// The response from getting a CDN
    /// </summary>
    [Serializable]
    public class RuyiNetGetCDNResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// A permanent link to the file.
            /// </summary>
            public string appServerUrl;

            /// <summary>
            /// A temporary link to the file served via a CDN.
            /// </summary>
            public string cdnUrl;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;
    }
}
