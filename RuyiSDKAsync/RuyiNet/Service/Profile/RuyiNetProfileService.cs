using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Ruyi.SDK.Online
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
        public async Task UpdateUserPicture(int index, string filename, RuyiNetTask<RuyiNetGetCDNResponse>.CallbackType callback)
        {
            var resp = await EnqueuePlatformTask<RuyiNetGetCDNResponse>(index, async () =>
            {
                var response = await mClient.BCService.File_UploadFileAsync(PROFILE_LOCATION, PROFILE_IMAGE_FILENAME, true, true, filename, index, token);
                var uploadedFile = JsonConvert.DeserializeObject<RuyiNetUploadFileResponse>(response);

                if (uploadedFile.status == RuyiNetHttpStatus.OK)
                {
                    response = mClient.BCService.File_GetCDNUrlAsync(PROFILE_LOCATION, PROFILE_IMAGE_FILENAME, index, token).Result;
                    var cdnUrl = JsonConvert.DeserializeObject<RuyiNetGetCDNResponse>(response);
                    if (cdnUrl.status == RuyiNetHttpStatus.OK)
                    {
                        mClient.BCService.PlayerState_UpdateUserPictureUrlAsync(cdnUrl.data.appServerUrl, index, token).Wait();
                    }
                }                
                return response;
            });
            await callback(resp);
        }

        static System.Threading.CancellationToken token = System.Threading.CancellationToken.None;
    }
}
