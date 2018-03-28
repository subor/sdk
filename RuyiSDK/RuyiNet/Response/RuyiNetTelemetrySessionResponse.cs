using System;

namespace Ruyi
{
    /// <summary>
    /// Response recieved after making a telemetry session request.
    /// </summary>
    [Serializable]
    public class RuyiNetTelemetrySessionResponse
    {
        /// <summary>
        /// The data class.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The ID of the game this telemetry session belongs to.
            /// </summary>
            public string gameId;

            /// <summary>
            /// The ID of the telemetry session.
            /// </summary>
            public string telemetrySessionId;

            /// <summary>
            /// The timestamp when the telemetry session was started/finished.
            /// </summary>
            public int timestamp;

            /// <summary>
            /// Either STARTED or FINISHED.
            /// </summary>
            public string sessionTiming;
        }

        /// <summary>
        /// The data.
        /// </summary>
        public Data data;
        
        /// <summary>
        /// The response status.
        /// </summary>
        public int status;
    }
}
