#pragma once

#include "../Response/RuyiNetGetPartyInfoResponse.h"
#include "../Response/RuyiNetGetProfilesResponse.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetPartyService : public RuyiNetService
	{
	public:
		RuyiNetPartyService(RuyiNetClient * client);

		void GetPartyInfo(int index, const RuyiNetTask<RuyiNetGetPartyInfoResponse>::CallbackType & callback);
		void GetPartyMembersInfo(int index, const RuyiNetTask<RuyiNetGetProfilesResponse>::CallbackType & callback);
		void SendPartyInvitation(int index, const RuyiString & profileId, const RuyiNetTask<json>::CallbackType & callback);
		void AcceptPartyInvitation(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback);
		void RejectPartyInvitation(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback);
		void JoinParty(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback);
		void LeaveParty(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback);
	};
}