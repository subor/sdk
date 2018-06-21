#include "RuyiNetTelemetryService.h"

#include <sys/utime.h>

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	void RuyiNetTelemetryService::StartTelemetrySession(int clientIndex, RuyiNetTelemetrySessionResponse& response, RuyiNetTelemetrySession& session)
	{
		StartTelemetrySession(clientIndex, GetCurrentTimestamp(), response, session);
	}

	void RuyiNetTelemetryService::StartTelemetrySession(int clientIndex, int timestamp, RuyiNetTelemetrySessionResponse& response, RuyiNetTelemetrySession& session)
	{
		std::string responseStr;
		mClient->GetBCService()->Telemetry_StartTelemetrySession(responseStr, timestamp, clientIndex);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
		session.SetId(response.data.telemetrySessionId);
		session.SetTimestamp(response.data.timestamp);
	}

	void RuyiNetTelemetryService::EndTelemetrySession(int clientIndex, std::string sessionId, RuyiNetResponse& response)
	{
		EndTelemetrySession(clientIndex, GetCurrentTimestamp(), sessionId, response);
	}

	void RuyiNetTelemetryService::EndTelemetrySession(int clientIndex, int timestamp, std::string sessionId, RuyiNetResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->Telemetry_EndTelemetrySession(responseStr, sessionId, timestamp, clientIndex);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		LogTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
		std::map<std::string, std::string> customData, RuyiNetResponse& response)
	{
		LogTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
		RuyiNetResponse& response) 
	{
		std::map<std::string, std::string> customData;
		LogTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
		std::map<std::string, std::string> customData, RuyiNetResponse& response)
	{
		LogTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::map<std::string, std::string> customData,
		RuyiNetResponse& response) 
	{
		LogTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::LogTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
		const std::map<std::string, std::string>& customData, RuyiNetResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->Telemetry_LogTelemetryEvent(responseStr, sessionId, timestamp, eventType, participantId, customData, clientIndex);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType,
		RuyiNetResponse& response) 
	{
		std::map<std::string, std::string> customData;
		StartTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
		std::map<std::string, std::string> customData, RuyiNetResponse& response)
	{
		StartTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		StartTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
		std::map<std::string, std::string> customData, RuyiNetResponse& response)
	{
		StartTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::map<std::string, std::string> customData,
		RuyiNetResponse& response)
	{
		StartTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::StartTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
		std::map<std::string, std::string>& customData, RuyiNetResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->Telemetry_StartTelemetryEvent(responseStr, sessionId, timestamp, eventType, participantId, customData, clientIndex);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		EndTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType,
		std::map<std::string, std::string> customData, RuyiNetResponse& response)
	{
		EndTelemetryEvent(clientIndex, timestamp, sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
		RuyiNetResponse& response)
	{
		std::map<std::string, std::string> customData;
		EndTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType, std::string participantId,
		std::map<std::string, std::string> customData, RuyiNetResponse& response)
	{
		EndTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, participantId, customData, response);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, std::string sessionId, std::string eventType,
		std::map<std::string, std::string> customData, RuyiNetResponse& response)
	{
		EndTelemetryEvent(clientIndex, GetCurrentTimestamp(), sessionId, eventType, "", customData, response);
	}

	void RuyiNetTelemetryService::EndTelemetryEvent(int clientIndex, int timestamp, std::string sessionId, std::string eventType, std::string participantId,
		std::map<std::string, std::string>& customData, RuyiNetResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->Telemetry_EndTelemetryEvent(responseStr, sessionId, timestamp, eventType, participantId, customData, clientIndex);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	int RuyiNetTelemetryService::GetCurrentTimestamp()
	{
		int ret = 0;

		time_t now;
		ret = (int)time(&now);

		return ret;
	}
//}
	}}} //namespace