#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi
{
	class RuyiNetService
	{
	protected:
		RuyiNetService(RuyiNetClient * client);

		std::string RunParentScript(int index, const std::string& scriptName, nlohmann::json payload);

		RuyiNetClient * mClient;
	};
}