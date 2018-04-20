#pragma once

#include "RuyiNetService.h"

#include "../Response/RuyiNetTelemetrySessionResponse.h"
#include "../Response/RuyiNetResponse.h"

namespace Ruyi
{
	/// <summary>
	/// Represents a telemetry session.
	/// </summary>
	class RuyiNetTelemetrySession
	{
	public:
		RuyiNetTelemetrySession(std::string& id, int timestamp) : Id(id), Timestamp(timestamp) {}
		/// <summary>
		/// The ID of the telemetry session.
		/// </summary>
		const std::string& GetId() { return Id; }
		void SetId(std::string& id) { Id = id; }

		/// <summary>
		/// The time when the telemetry session started.
		/// </summary>
		int GetTimestamp() { return Timestamp; }
		void SetTimestamp(int timestamp) { Timestamp = timestamp; }
	private:
		std::string Id;
		int Timestamp;
	};

	/// <summary>
	/// Handles pushing telemetry data to the cloud.
	/// </summary>
	class RuyiNetTelemetryService : public RuyiNetService
	{
	public:
		RuyiNetTelemetryService(RuyiNetClient * client) : RuyiNetService(client) {}

		/// <summary>
		/// Starts a telemetry session on the online service using the current timestamp.
		/// </summary>
		/// <param name="clientIndex">Index of the client making the call.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		/// <param name="session>the telemetry session</param>
		void StartTelemetrySession(int clientIndex, RuyiNetTelemetrySessionResponse& response, RuyiNetTelemetrySession& session);

		/// <summary>
		/// Starts a telemetry session on the online service
		/// </summary>
		/// <param name="clientIndex">Index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the session started.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		/// <param name="session>the telemetry session</param>
		void StartTelemetrySession(int clientIndex, int timestamp, RuyiNetTelemetrySessionResponse& response, RuyiNetTelemetrySession& session);

		/// <summary>
		/// Ends a telemetry session at the current timestamp.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to close.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetrySession(int clientIndex, std::string sessionId, RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry session.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the session ended.</param>
		/// <param name="sessionId">The ID of the session to close.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetrySession(int clientIndex, int timestamp, std::string sessionId, RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
			RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
			std::map<std::string, std::string> customData, RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
			RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
			std::map<std::string, std::string> customData, RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::map<std::string, std::string> customData,
			RuyiNetResponse& response);

		/// <summary>
		/// Logs a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to log the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId, 
			const std::map<std::string, std::string>& customData, RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType,
			RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
			RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
			RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
			std::map<std::string, std::string> customData, RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
			RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
			std::map<std::string, std::string> customData, RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::map<std::string, std::string> customData,
			RuyiNetResponse& response);

		/// <summary>
		/// Starts a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to Start the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
			std::map<std::string, std::string>& customData, RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType,
			RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
			RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
			RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
			std::map<std::string, std::string> customData, RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
			RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
			std::map<std::string, std::string> customData, RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType,
			std::map<std::string, std::string> customData, RuyiNetResponse& response);

		/// <summary>
		/// Ends a telemetry event.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="timestamp">The timestamp when the event occurred.</param>
		/// <param name="sessionId">The ID of the session to End the event with.</param>
		/// <param name="eventType">The type of event.</param>
		/// <param name="participantId">The ID or the participant in the event.</param>
		/// <param name="customData">The custom data to attach to the event.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
			std::map<std::string, std::string>& customData, RuyiNetResponse& response);

	private:
		//seconds
		int GetCurrentTimestamp();
	};
}