using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

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
        public async Task<RuyiNetGameManifest> GetGameManifest(int clientIndex, string gameId)
        {
            string resp = null;
            try
            {
                resp = await mClient.BCService.Patch_GetGameManifestAsync(gameId, clientIndex, token);
            }
            catch (Exception e)
            {
                // just log it for now, otherwise layer0 will crash, it happens when no response while switching high-low power mode
                // throw;
                Logging.Logger.Log(e.Message, Logging.LogLevel.Error);
                var error = new RuyiNetResponse()
                {
                    status = 999,
                    message = e.ToString()
                };

                resp = JsonConvert.SerializeObject(error);
            }
            var response = mClient.Process<RuyiNetGetGameManifestResponse>(resp);
            return response;
        }
    }
}
