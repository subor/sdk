#include "RuyiNetPatchService.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetPatchService::RuyiNetPatchService(RuyiNetClient* client) : RuyiNetService(client)
	{}
	
	void RuyiNetPatchService::GetGameManifest(int clientIndex, std::string gameId, RuyiNetGameManifest& gameManifest) 
	{
		std::string responseStr;
		mClient->GetBCService()->Patch_GetGameManifest(responseStr, gameId, clientIndex);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		RuyiNetGetGameManifestResponse response;
		response.parseJson(retJson);
		gameManifest.GetDataFromGameManifestResponse(response);
	}

}}} //namespace