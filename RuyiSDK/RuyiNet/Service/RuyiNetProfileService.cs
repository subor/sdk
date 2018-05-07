using Newtonsoft.Json;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// Methods to help a player manage their profile.
    /// </summary>
    public class RuyiNetProfileService : RuyiNetService
    {
        const string PROFILE_LOCATION = "profile";
        const string PROFILE_IMAGE_FILENAME = "image.jpg";

        /// <summary>
        /// Create the Profile Service.
        /// </summary>
        /// <param name="client">The Ruyi Net client.</param>
        internal RuyiNetProfileService(RuyiNetClient client)
        : base(client)
        {
        }

        /// <summary>
        /// Updates the profile picture of the user.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="filename">The image file to use as a profile picture.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void UpdateUserPicture(int index, string filename, RuyiNetTask<RuyiNetGetCDNResponse>.CallbackType callback)
        {
            EnqueuePlatformTask(index, () =>
            {
                var response = mClient.BCService.File_UploadFile(PROFILE_LOCATION, PROFILE_IMAGE_FILENAME, true, true, filename, index);
                var uploadedFile = JsonConvert.DeserializeObject<RuyiNetUploadFileResponse>(response);

                if (uploadedFile.status == 200)
                {
                    response = mClient.BCService.File_GetCDNUrl(PROFILE_LOCATION, PROFILE_IMAGE_FILENAME, index);
                    var cdnUrl = JsonConvert.DeserializeObject<RuyiNetGetCDNResponse>(response);
                    if (cdnUrl.status == 200)
                    {
                        mClient.BCService.PlayerState_UpdateUserPictureUrl(cdnUrl.data.appServerUrl, index);
                    }
                }                

                return response;
            }, callback);
        }
    }
}
