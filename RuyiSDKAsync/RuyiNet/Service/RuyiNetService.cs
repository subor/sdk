using System.Threading.Tasks;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Base class for all Net Services.
    /// </summary>
    public class RuyiNetService
    {
        /// <summary>
        /// Creates a Ruyi Net Service
        /// </summary>
        /// <param name="client">The Ruyi Net Client.</param>
        protected RuyiNetService(RuyiNetClient client)
        {
            mClient = client;
        }

        /// <summary>
        /// Queue up a request to the online service that needs to be called on the RUYI platform level.
        /// </summary>
        /// <typeparam name="Response">A serialisiable class we can receive the data in.</typeparam>
        /// <param name="index">The index of user</param>
        /// <param name="onExecute">The method to call when we execute the task.</param>
        protected Task<Response> EnqueuePlatformTask<Response>(int index, RuyiNetTask<Response>.ExecuteType onExecute)
        {
            return mClient.EnqueuePlatformTask(index, onExecute);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Response">A serialisiable class we can receive the data in.</typeparam>
        /// <param name="index">The index of user</param>
        /// <param name="script">The name of the script to run.</param>
        /// <param name="payload">The JSON payload to send with the request</param>
        protected async Task<Response> RunPlatformScript<Response>(int index, string script, string payload)
        {
            var resp = await mClient.BCService.Script_RunParentScriptAsync(script, payload, "RUYI", index, token);
            return mClient.Process<Response>(resp);
        }

        /// <summary>
        /// The Ruyi Net Client.
        /// </summary>
        protected RuyiNetClient mClient;

        protected static System.Threading.CancellationToken token = System.Threading.CancellationToken.None;
    }
}