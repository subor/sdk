using Newtonsoft.Json;
using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Simple class for receiving status responses from API calls.
    /// </summary>
    [Serializable]
    public class RuyiNetResponse
    {
        /// <summary>
        /// Resultant status code from an API call.
        /// </summary>
        public int status;

        /// <summary>
        /// Message accompanying the result - can be used to determine errors.
        /// </summary>
        public string message;
    }

    /// <summary>
    /// Base class for tasks.
    /// </summary>
    public abstract class RuyiNetTaskBase
    {
        /// <summary>
        /// This is called when the task needs to run.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// This is called when the task completes.
        /// </summary>
        public abstract void OnResponse();

        /// <summary>
        /// A flag to indicate whether or not the task is completed.
        /// </summary>
        public bool Completed { get; protected set; }

        /// <summary>
        /// Stores the response that is passed to the callbacks.
        /// </summary>
        protected string Response { get; set; }
    }

    /// <summary>
    /// A task that is used to make a request to RuyiNet.
    /// </summary>
    /// <typeparam name="Response"></typeparam>
    public class RuyiNetTask<Response> : RuyiNetTaskBase
    {
        /// <summary>
        /// Prototype for a method to be called that makes a request to RuyiNet.
        /// </summary>
        /// <returns>The response as a JSON string.</returns>
        public delegate string ExecuteType();

        /// <summary>
        /// Prototype of a callback for the task.
        /// </summary>
        /// <param name="response">The response serialised into a class.</param>
        public delegate void CallbackType(Response response);

        /// <summary>
        /// Creates a Task.
        /// </summary>
        /// <param name="onExecute">The method to call when the task executes.</param>
        /// <param name="callback">The callback to call when the task completes.</param>
        public RuyiNetTask(ExecuteType onExecute, CallbackType callback)
        {
            OnExecute = onExecute;
            Callback = callback;
        }

        /// <summary>
        /// Runs the task.
        /// </summary>
        public override void Execute()
        {
            Completed = false;
            base.Response = OnExecute();
            Completed = true;
        }

        /// <summary>
        /// Parses the response and calls the callback.
        /// </summary>
        public override void OnResponse()
        {
            if (Callback != null)
            {
                System.Console.Write(base.Response);
                var data = JsonConvert.DeserializeObject<Response>(base.Response, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                Callback(data);
            }
        }

        /// <summary>
        /// The callback that will be called when the task completes.
        /// </summary>
        public CallbackType Callback { get; protected set; }

        /// <summary>
        /// The method to call when the task executes.
        /// </summary>
        protected ExecuteType OnExecute { get; set; }
    }

    /// <summary>
    /// A task that is called on the platform (RUYI) API rather than the game's API.
    /// </summary>
    /// <typeparam name="Response">A class that will contain the response data.</typeparam>
    public class RuyiNetPlatformTask<Response> : RuyiNetTask<Response>
    {
        /// <summary>
        /// Creates a platform task.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="client">The RUYI Net client</param>
        /// <param name="onExecute">The method to call when the task executes.</param>
        /// <param name="callback">The callback to call when the task completes.</param>
        public RuyiNetPlatformTask(int index, RuyiNetClient client,
            ExecuteType onExecute, CallbackType callback)
            : base(onExecute, callback)
        {
            mClient = client;
            mIndex = index;
        }

        /// <summary>
        /// Switch to the RUYI platform and run the task.
        /// </summary>
        public override void Execute()
        {
            Completed = false;
            mClient.BCService.Identity_SwitchToParentProfile("RUYI", mIndex);
            base.Response = OnExecute();
            mClient.BCService.Identity_SwitchToSingletonChildProfile(mClient.AppId, false, mIndex);
            Completed = true;
        }

        private RuyiNetClient mClient;
        private int mIndex;
    }
}
