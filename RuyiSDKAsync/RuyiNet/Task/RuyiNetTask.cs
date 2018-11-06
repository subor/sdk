using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

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
    /// A task that is used to make a request to RuyiNet.
    /// </summary>
    /// <typeparam name="Response"></typeparam>
    public sealed class RuyiNetTask<Response>
    {
        /// <summary>
        /// Prototype for a method to be called that makes a request to RuyiNet.
        /// </summary>
        /// <returns>The response as a JSON string.</returns>
        public delegate Task<string> ExecuteType();

        /// <summary>
        /// Prototype of a callback for the task.
        /// </summary>
        /// <param name="response">The response serialised into a class.</param>
        public delegate Task CallbackType(Response response);
    }
}
