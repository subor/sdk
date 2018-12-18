using Newtonsoft.Json;
using Ruyi.SDK.Constants;
using Ruyi.SDK.StorageLayer;
using System;
using System.IO;
using System.Security;
using System.Threading.Tasks;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Handles backing up data to the cloud.
    /// </summary>
    public class RuyiNetCloudService : RuyiNetService
    {
        const string BACKUP_LOCATION = "ruyiBackup";
        readonly string[] IGNORE =
        {
            "Crashes",
            "Unity",
            "output_log.txt"
        };

        /// <summary>
        /// Create the Cloud Service.
        /// </summary>
        /// <param name="client">The Ruyi Net client.</param>
        /// <param name="storageLayerService">The storage layer service, needed to read/write files from disk</param>
        internal RuyiNetCloudService(RuyiNetClient client, StorageLayerService.Client storageLayerService)
        : base(client)
        {
            mStorageLayerService = storageLayerService;
        }

        /// <summary>
        /// Manually backup the save data up to this point.
        /// </summary>
        /// <param name="index">The index of user</param>
        public Task<RuyiNetResponse> BackupData(int index)
        {
            return BackupData(index, false);
        }

        /// <summary>
        /// Manually restore the save data up to this point.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public async Task<RuyiNetResponse> RestoreData(int index, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            try
            {
                var path = GetPersistentDataPath(index);
                path = Path.GetFullPath(path);

                //  List files
                var data = await mClient.BCService.File_ListUserFiles_SNSFOAsync(GetCloudLocation(index), true, index, token);
                var response = JsonConvert.DeserializeObject<RuyiNetListUserFilesResponse>(data, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                if (response.status != RuyiNetHttpStatus.OK)
                {
                    return mClient.Process<RuyiNetResponse>(data);
                }

                //  Download one by one to correct path
                //  TODO: Need to get the session ID and pass it in as a URL parameter.
                foreach (var i in response.data.fileList)
                {
                    var resp = await mClient.BCService.File_DownloadFileAsync(i.cloudPath, i.cloudFilename, true, index, token);
                    var response2 = mClient.Process<RuyiNetResponse>(resp);
                    await callback(response2);
                }

                //  Delete backup
                //var backupInfo = new DirectoryInfo(backupPath);
                //backupInfo.Delete(true);

                return new RuyiNetResponse() { status = RuyiNetHttpStatus.OK, message = "Restore Data Successful" };
            }
            catch (Exception e)
            {
                if (e is ArgumentException ||
                    e is NotSupportedException ||
                    e is PathTooLongException ||
                    e is DirectoryNotFoundException)
                {
                    return new RuyiNetResponse()
                    {
                        status = 400,
                        message = e.ToString()
                    };
                }
                else if (e is SecurityException ||
                         e is IOException ||
                         e is UnauthorizedAccessException ||
                         e is RuyiNetException)
                {
                    return new RuyiNetResponse()
                    {
                        status = 500,
                        message = e.ToString()
                    };
                }
                else
                {
#if DEBUG
                    return new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };
#else
                    throw;
#endif
                }
            }
        }

        internal Task<RuyiNetResponse> BackupData(int index, bool cleanMode)
        {
            return Task.Run(() =>
            {
                try
                {
                    var path = GetPersistentDataPath(index);
                    path = Path.GetFullPath(path);
                    BackupPath(index, GetCloudLocation(index), path);
                    if (cleanMode)
                    {
                        var di = new DirectoryInfo(path);
                        foreach (var i in di.GetFiles())
                        {
                            if (Array.IndexOf(IGNORE, i.Name) >= 0)
                            {
                                continue;
                            }

                            i.Delete();
                        }

                        foreach (var i in di.GetDirectories())
                        {
                            if (Array.IndexOf(IGNORE, i.Name) >= 0)
                            {
                                continue;
                            }

                            i.Delete(true);
                        }
                    }

                    return new RuyiNetResponse() { status = RuyiNetHttpStatus.OK };
                }
                catch (Exception e)
                {
                    if (e is ArgumentException ||
                        e is NotSupportedException ||
                        e is PathTooLongException ||
                        e is DirectoryNotFoundException)
                    {
                        var response = new RuyiNetResponse()
                        {
                            status = 400,
                            message = e.ToString()
                        };

                        return response;
                    }
                    else if (e is SecurityException ||
                             e is IOException ||
                             e is UnauthorizedAccessException ||
                             e is RuyiNetException)
                    {
                        var response = new RuyiNetResponse()
                        {
                            status = 500,
                            message = e.ToString()
                        };

                        return response;
                    }
                    else
                    {
                        var response = new RuyiNetResponse()
                        {
                            status = 501,
                            message = e.ToString()
                        };

                        return response;

                        //throw;
                    }
                }
            });
        }

        private void BackupPath(int index, string cloudPath, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var subdirectories = Directory.GetDirectories(path);
            foreach (var i in subdirectories)
            {
                var directoryName = Path.GetFileName(i);
                if (Array.IndexOf(IGNORE, directoryName) >= 0)
                {
                    continue;
                }

                var newPath = Path.Combine(cloudPath, directoryName);
                BackupPath(index, newPath, i);
            }

            var files = Directory.GetFiles(path);
            foreach (var i in files)
            {
                var fileName = Path.GetFileName(i);
                if (Array.IndexOf(IGNORE, fileName) >= 0)
                {
                    continue;
                }

                //  TODO: Set 'shareable' to false and get the session ID to use
                //  as a parameter when downloading the data.
                var data = mClient.BCService.File_UploadFileAsync(cloudPath, fileName, true/*false*/, true, i, index, token).Result;
                var response = JsonConvert.DeserializeObject<RuyiNetUploadFileResponse>(data);
                if (response.status != RuyiNetHttpStatus.OK)
                {
                    throw new RuyiNetException("Failed to upload file: " + i);
                }
            }
        }

        private string GetPersistentDataPath(int index)
        {
            var path = mStorageLayerService.GetLocalPathAsync(ConstantsSDKDataTypesConstants.HTTP_HDD_CACHE_DRIVER_TAG + GetCloudLocation(index), token).Result;
            if (path.Result)
            {
                return path.Path;
            }

            return null;
        }

        private string GetCloudLocation(int index)
        {
            return mClient.CurrentPlayers[index].profileId + "/" + mClient.AppId;
        }

        private StorageLayerService.Client mStorageLayerService;
    }
}
