using Newtonsoft.Json;
using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Get Game Manifest information for patches.
    /// </summary>
    public class RuyiNetPatchService : RuyiNetService
    {

        internal RuyiNetPatchService(RuyiNetClient client)
            : base(client)
        { }

        /// <summary>
        /// Returns a manifest for the specified game.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="gameId">The index of the client making the call.</param>
        /// <param name="callback">Callback to call when the operation is complete.</param>
        public void GetGameManifest(int clientIndex, string gameId, Action<RuyiNetGameManifest> callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    var data = mClient.BCService.Patch_GetGameManifestAsync(gameId, clientIndex, token).Result;
                    return data;
                }
                catch (Exception e)
                {
                    // just log it for now, otherwise layer0 will crash, it happens when no response while switching high-low power mode
                    // throw;
                    Logging.Logger.Log(e.Message, Logging.LogLevel.Error);
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
                }
            }, (RuyiNetGetGameManifestResponse response) =>
            {
                callback(response);
            });
        }

        static System.Threading.CancellationToken token = System.Threading.CancellationToken.None;
    }
}
