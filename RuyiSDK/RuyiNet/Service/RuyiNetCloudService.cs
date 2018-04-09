using Newtonsoft.Json;
using Ruyi.SDK.StorageLayer;
using System;
using System.IO;
using System.Security;

namespace Ruyi
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
        /// <param name="callback">The function to call when the task completes.</param>
        public void BackupData(int index, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            BackupData(index, false, callback);
        }

        /// <summary>
        /// Manually restore the save data up to this point.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void RestoreData(int index, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    var path = GetPersistentDataPath(index);
                    path = Path.GetFullPath(path);

                    //  Backup persistent data path
                    /*var backupPath = Path.Combine(path, BACKUP_LOCATION);
                    if (Directory.Exists(backupPath))
                    {
                        var x = new DirectoryInfo(backupPath);
                        x.Delete(true);
                    }

                    foreach (var i in Directory.GetDirectories(path, "*", SearchOption.AllDirectories))
                    {
                        var directoryName = Path.GetFileName(i);
                        if (Array.IndexOf(IGNORE, directoryName) >= 0)
                        {
                            continue;
                        }

                        Directory.CreateDirectory(i.Replace(path, backupPath));
                    }

                    //Copy all the files & Replaces any files with the same name
                    foreach (var i in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
                    {
                        var fileName = Path.GetFileName(i);
                        if (Array.IndexOf(IGNORE, fileName) >= 0)
                        {
                            continue;
                        }

                        File.Copy(i, i.Replace(path, backupPath), true);
                        File.Delete(i);
                    }*/

                    //  List files
                    var data = mClient.BCService.File_ListUserFiles_SNSFO(GetCloudLocation(index), true, index);
                    var response = JsonConvert.DeserializeObject<RuyiNetListUserFilesResponse>(data, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    if (response.status != 200)
                    {
                        return data;
                    }

                    //  Download one by one to correct path
                    //  TODO: Need to get the session ID and pass it in as a URL parameter.
                    foreach (var i in response.data.fileList)
                    {
                        EnqueueTask(() =>
                        {
                            return mClient.BCService.File_DownloadFile(i.cloudPath, i.cloudFilename, true, index);
                        }, callback);
                    }

                    //  Delete backup
                    //var backupInfo = new DirectoryInfo(backupPath);
                    //backupInfo.Delete(true);

                    return JsonConvert.SerializeObject(new RuyiNetResponse() { status = 200, message = "Restore Data Successful" });
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

                        return JsonConvert.SerializeObject(response);
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

                        return JsonConvert.SerializeObject(response);
                    }
                    else
                    {
#if DEBUG
                        var response = new RuyiNetResponse()
                        {
                            status = 999,
                            message = e.ToString()
                        };

                        return JsonConvert.SerializeObject(response);
#else
                        throw;
#endif
                    }
                }

            }, callback);

        }

        internal void BackupData(int index, bool cleanMode, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
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

                    return JsonConvert.SerializeObject(new RuyiNetResponse() { status = 200 });
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

                        return JsonConvert.SerializeObject(response);
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

                        return JsonConvert.SerializeObject(response);
                    }
                    else
                    {
                        var response = new RuyiNetResponse()
                        {
                            status = 501,
                            message = e.ToString()
                        };

                        return JsonConvert.SerializeObject(response);

                        //throw;
                    }
                }

            }, callback);
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
                var data = mClient.BCService.File_UploadFile(cloudPath, fileName, true/*false*/, true, i, index);
                var response = JsonConvert.DeserializeObject<RuyiNetUploadFileResponse>(data);
                if (response.status != 200)
                {
                    throw new RuyiNetException("Failed to upload file: " + i);
                }
            }
        }

        private string GetPersistentDataPath(int index)
        {
            var path = mStorageLayerService.GetLocalPath("/<HTTPHDDCACHE>/" + GetCloudLocation(index));
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
