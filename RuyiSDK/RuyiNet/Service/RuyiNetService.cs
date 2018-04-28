namespace Ruyi
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
        /// Queue up a request to the online service.
        /// </summary>
        /// <typeparam name="Response">A serialisiable class we can receive the data in.</typeparam>
        /// <param name="onExecute">The method to call when we execute the task.</param>
        /// <param name="callback">The callback to call when the task completes</param>
        protected void EnqueueTask<Response>(RuyiNetTask<Response>.ExecuteType onExecute, RuyiNetTask<Response>.CallbackType callback)
        {
            mClient.EnqueueTask(onExecute, callback);
        }

        /// <summary>
        /// Queue up a request to the online service that needs to be called on the RUYI platform level.
        /// </summary>
        /// <typeparam name="Response">A serialisiable class we can receive the data in.</typeparam>
        /// <param name="index">The index of user</param>
        /// <param name="onExecute">The method to call when we execute the task.</param>
        /// <param name="callback">The callback to call when the task completes</param>
        protected void EnqueuePlatformTask<Response>(int index, RuyiNetTask<Response>.ExecuteType onExecute, RuyiNetTask<Response>.CallbackType callback)
        {
            mClient.EnqueuePlatformTask(index, onExecute, callback);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Response">A serialisiable class we can receive the data in.</typeparam>
        /// <param name="index">The index of user</param>
        /// <param name="script">The name of the script to run.</param>
        /// <param name="payload">The JSON payload to send with the request</param>
        /// <param name="callback">The callback to call when the task completes</param>
        protected void RunPlatformScript<Response>(int index, string script, string payload, 
            RuyiNetTask<Response>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Script_RunParentScript(script, payload, "RUYI", index);
            }, callback);
        }

        /// <summary>
        /// The Ruyi Net Client.
        /// </summary>
        protected RuyiNetClient mClient;
    }
}