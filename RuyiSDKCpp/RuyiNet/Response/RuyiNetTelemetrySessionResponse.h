#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi
{
	/// <summary>
	/// Response recieved after making a telemetry session request.
	/// </summary>
	struct RuyiNetTelemetrySessionResponse
	{
		/// <summary>
		/// The data class.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The ID of the game this telemetry session belongs to.
			/// </summary>
			std::string gameId;

			/// <summary>
			/// The ID of the telemetry session.
			/// </summary>
			std::string telemetrySessionId;

			/// <summary>
			/// The timestamp when the telemetry session was started/finished.
			/// </summary>
			int timestamp;

			/// <summary>
			/// Either STARTED or FINISHED.
			/// </summary>
			std::string sessionTiming;

			void parseJson(nlohmann::json& j)
			{
				if (!j["gameId"].is_null())
				{
					gameId = j["gameId"];
				}
				if (!j["telemetrySessionId"].is_null())
				{
					telemetrySessionId = j["telemetrySessionId"];
				}
				if (!j["timestamp"].is_null())
				{
					timestamp = j["timestamp"];
				}
				if (!j["sessionTiming"].is_null())
				{
					sessionTiming = j["sessionTiming"];
				}
			}
		};

		/// <summary>
		/// The data.
		/// </summary>
		Data data;

		/// <summary>
		/// The response status.
		/// </summary>
		int status;

		void parseJson(nlohmann::json& j)
		{
			if (!j["data"].is_null())
			{
				nlohmann::json dataJson = j["data"];

				data.parseJson(dataJson);
			}
			if (!j["status"].is_null())
			{
				status = j["status"];
			}
		}
	};
}