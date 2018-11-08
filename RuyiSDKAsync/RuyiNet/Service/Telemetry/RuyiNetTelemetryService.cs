using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Handles pushing telemetry data to the cloud.
    /// </summary>
    public class RuyiNetTelemetryService : RuyiNetService
    {

        internal RuyiNetTelemetryService(RuyiNetClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Starts a telemetry session on the online service using the current timestamp.
        /// </summary>
        /// <param name="clientIndex">Index of the client making the call.</param>
        public Task<RuyiNetTelemetrySession> StartTelemetrySession(int clientIndex)
        {
            return StartTelemetrySession(clientIndex, CurrentTimestamp);
        }

        /// <summary>
        /// Starts a telemetry session on the online service
        /// </summary>
        /// <param name="clientIndex">Index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the session started.</param>
        public async Task<RuyiNetTelemetrySession> StartTelemetrySession(int clientIndex, int timestamp)
        {
            string resp = null;
            try
            {
                resp = await mClient.BCService.Telemetry_StartTelemetrySessionAsync(timestamp, clientIndex, token);
            }
            catch (Exception e)
            {
#if DEBUG
                var error = new RuyiNetResponse()
                {
                    status = 999,
                    message = e.ToString()
                };
                resp = JsonConvert.SerializeObject(error);
#else
                        throw;
#endif
            }
            var response = mClient.Process<RuyiNetTelemetrySessionResponse>(resp);
            return new RuyiNetTelemetrySession(response.data.telemetrySessionId, response.data.timestamp);
        }

        /// <summary>
        /// Ends a telemetry session at the current timestamp.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to close.</param>
        public Task<RuyiNetResponse> EndTelemetrySession(int clientIndex, string sessionId)
        {
            return EndTelemetrySession(clientIndex, CurrentTimestamp, sessionId);
        }

        /// <summary>
        /// Ends a telemetry session.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the session ended.</param>
        /// <param name="sessionId">The ID of the session to close.</param>
        public async Task<RuyiNetResponse> EndTelemetrySession(int clientIndex, int timestamp, string sessionId)
        {
            try
            {
                var resp = await mClient.BCService.Telemetry_EndTelemetrySessionAsync(sessionId, timestamp, clientIndex, token);
                return mClient.Process<RuyiNetResponse>(resp);
            }
            catch (Exception e)
            {
#if DEBUG
                return new RuyiNetResponse()
                {
                    status = 999,
                    message = e.ToString()
                };
#else
                        throw;
#endif
            }
            
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        public Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, string sessionId, string eventType)
        {
            return LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, string.Empty, null);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        public Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType)
        {
            return LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", null);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        public Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId)
        {
            return LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, null);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            Dictionary<string, string> customData)
        {
            return LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        public Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId)
        {
            return LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, null);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            Dictionary<string, string> customData)
        {
            return LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, customData);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, string sessionId, string eventType, Dictionary<string, string> customData)
        {
            return LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", customData);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public async Task<RuyiNetResponse> LogTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            Dictionary<string, string> customData)
        {
            try
            {
                var resp = await mClient.BCService.Telemetry_LogTelemetryEventAsync(
                    sessionId, timestamp, eventType, participantId,
                    customData, clientIndex, token);
                return mClient.Process<RuyiNetResponse>(resp);
            }
            catch (Exception e)
            {
#if DEBUG
                return new RuyiNetResponse()
                {
                    status = 999,
                    message = e.ToString()
                };
#else
                        throw;
#endif
            }
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        public Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, string sessionId, string eventType)
        {
            return StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", null);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        public Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType)
        {
            return StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", null);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        public Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId)
        {
            return StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, null);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            Dictionary<string, string> customData)
        {
            return StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        public Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId)
        {
            return StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, null);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            Dictionary<string, string> customData)
        {
            return StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, customData);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, string sessionId, string eventType, Dictionary<string, string> customData)
        {
            return StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", customData);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public async Task<RuyiNetResponse> StartTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            Dictionary<string, string> customData)
        {
            try
            {
                var resp = await mClient.BCService.Telemetry_StartTelemetryEventAsync(
                    sessionId, timestamp, eventType, participantId,
                    customData, clientIndex, token);
                return mClient.Process<RuyiNetResponse>(resp);
            }
            catch (Exception e)
            {
#if DEBUG
                return new RuyiNetResponse()
                {
                    status = 999,
                    message = e.ToString()
                };
#else
                        throw;
#endif
            }
            
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        public Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, string sessionId, string eventType)
        {
            return EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", null);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        public Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType)
        {
            return EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", null);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        public Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId)
        {
            return EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, null);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            Dictionary<string, string> customData)
        {
            return EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        public Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId)
        {
            return EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, null);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            Dictionary<string, string> customData)
        {
            return EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, customData);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, string sessionId, string eventType, Dictionary<string, string> customData)
        {
            return EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", customData);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        public async Task<RuyiNetResponse> EndTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            Dictionary<string, string> customData)
        {
            try
            {
                var resp = await mClient.BCService.Telemetry_EndTelemetryEventAsync(
                    sessionId, timestamp, eventType, participantId,
                    customData, clientIndex, token);
                return mClient.Process<RuyiNetResponse>(resp);
            }
            catch (Exception e)
            {
#if DEBUG
                return new RuyiNetResponse()
                {
                    status = 999,
                    message = e.ToString()
                };
#else
                        throw;
#endif
            }
        }

        private int CurrentTimestamp
        {
            get
            {
                return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }
        }
    }
}
