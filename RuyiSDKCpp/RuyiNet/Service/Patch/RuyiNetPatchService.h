#pragma once

#include "../RuyiNetService.h"
#include "../../Response/RuyiNetGetGameManifestResponse.h"
#include "RuyiNetGameManifest.h"

namespace Ruyi { namespace SDK { namespace Online {

	class RuyiNetPatchService : public RuyiNetService
	{
	public:
		RuyiNetPatchService(RuyiNetClient* client);

		/// <summary>
		/// Returns a manifest for the specified game.
		/// </summary>
		/// <param name="clientIndex">The index of the client making the call.</param>
		/// <param name="gameId">The index of the client making the call.</param>
		/// <param name="gameManifest">manifest for the specified game.</param>
		void GetGameManifest(int clientIndex, std::string gameId, RuyiNetGameManifest& gameManifest);
	};

}}} //namespace