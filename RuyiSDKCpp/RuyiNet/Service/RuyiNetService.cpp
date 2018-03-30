#include "RuyiNetService.h"

namespace Ruyi
{
	RuyiNetService::RuyiNetService(RuyiNetClient * client)
		: mClient(client)
	{
	}

	std::string RuyiNetService::RunParentScript(int index, const std::string & scriptName, json payload)
	{
		std::string response;
		mClient->GetBCService()->Script_RunParentScript(response, scriptName, payload, "RUYI", index);
		return response;
	}
}