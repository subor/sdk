namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a telemetry session.
    /// </summary>
    public class RuyiNetTelemetrySession
    {
        /// <summary>
        /// The ID of the telemetry session.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The time when the telemetry session started.
        /// </summary>
        public int Timestamp { get; private set; }

        internal RuyiNetTelemetrySession(string id, int timestamp)
        {
            Id = id;
            Timestamp = timestamp;
        }
    }
}
