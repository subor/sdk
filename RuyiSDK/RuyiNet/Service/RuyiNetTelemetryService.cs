using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Cloud
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
        /// <param name="callback">The callback that will receive the session ID.</param>
        public void StartTelemetrySession(int clientIndex, Action<RuyiNetTelemetrySession> callback)
        {
            StartTelemetrySession(clientIndex, CurrentTimestamp, callback);
        }

        /// <summary>
        /// Starts a telemetry session on the online service
        /// </summary>
        /// <param name="clientIndex">Index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the session started.</param>
        /// <param name="callback">The callback that will receive the session ID.</param>
        public void StartTelemetrySession(int clientIndex, int timestamp, Action<RuyiNetTelemetrySession> callback)
        {

            EnqueueTask(() =>
            {
                try
                {
                    var data = mClient.BCService.Telemetry_StartTelemetrySession(timestamp, clientIndex);
                    return data;
                }
                catch (Exception e)
                {
#if DEBUG
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
#else
                        throw;
#endif
                }
            }, (RuyiNetTelemetrySessionResponse response) =>
            {
                if (callback != null)
                {
                    callback(new RuyiNetTelemetrySession(response.data.telemetrySessionId, response.data.timestamp));
                }
            });
        }

        /// <summary>
        /// Ends a telemetry session at the current timestamp.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to close.</param>
        /// <param name="callback">Callback to call when the operation is complete.</param>
        public void EndTelemetrySession(int clientIndex, string sessionId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetrySession(clientIndex, CurrentTimestamp, sessionId, callback);
        }

        /// <summary>
        /// Ends a telemetry session.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the session ended.</param>
        /// <param name="sessionId">The ID of the session to close.</param>
        /// <param name="callback">Callback to call when the operation is complete.</param>
        public void EndTelemetrySession(int clientIndex, int timestamp, string sessionId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    var data = mClient.BCService.Telemetry_EndTelemetrySession(sessionId, timestamp, clientIndex);
                    return data;
                }
                catch (Exception e)
                {
#if DEBUG
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
#else
                        throw;
#endif
                }
            }, callback);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, string sessionId, string eventType,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", null, callback);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", null, callback);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, null, callback);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, callback);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, null, callback);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, customData, callback);
        }

        /// <summary>
        /// Logs a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to log the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, string sessionId, string eventType,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            LogTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", customData, callback);
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
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void LogTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    var data = mClient.BCService.Telemetry_LogTelemetryEvent(
                        sessionId, timestamp, eventType, participantId,
                        customData, clientIndex);
                    return data;
                }
                catch (Exception e)
                {
#if DEBUG
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
#else
                        throw;
#endif
                }
            }, callback);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, string sessionId, string eventType,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", null, callback);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", null, callback);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, null, callback);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, callback);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, null, callback);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, customData, callback);
        }

        /// <summary>
        /// Starts a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to Start the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, string sessionId, string eventType,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            StartTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", customData, callback);
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
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void StartTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    var data = mClient.BCService.Telemetry_StartTelemetryEvent(
                        sessionId, timestamp, eventType, participantId,
                        customData, clientIndex);
                    return data;
                }
                catch (Exception e)
                {
#if DEBUG
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
#else
                        throw;
#endif
                }
            }, callback);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, string sessionId, string eventType,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", null, callback);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", null, callback);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, null, callback);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="timestamp">The timestamp when the event occurred.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, callback);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, null, callback);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="participantId">The ID or the participant in the event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, string sessionId,
            string eventType, string participantId,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, participantId, customData, callback);
        }

        /// <summary>
        /// Ends a telemetry event.
        /// </summary>
        /// <param name="clientIndex">The index of the client making the call.</param>
        /// <param name="sessionId">The ID of the session to End the event with.</param>
        /// <param name="eventType">The type of event.</param>
        /// <param name="customData">The custom data to attach to the event.</param>
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, string sessionId, string eventType,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EndTelemetryEvent(clientIndex, CurrentTimestamp, sessionId, eventType, "", customData, callback);
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
        /// <param name="callback">The callback to call when the operation is complete.</param>
        public void EndTelemetryEvent(int clientIndex, int timestamp,
            string sessionId, string eventType, string participantId,
            Dictionary<string, string> customData,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                try
                {
                    var data = mClient.BCService.Telemetry_EndTelemetryEvent(
                        sessionId, timestamp, eventType, participantId,
                        customData, clientIndex);
                    return data;
                }
                catch (Exception e)
                {
#if DEBUG
                    var response = new RuyiNetResponse()
                    {
                        status = 999,
                        message = e.ToString()
                    };

                    return JsonConvert.SerializeObject(response);
#else
                        throw;
#endif
                }
            }, callback);
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
