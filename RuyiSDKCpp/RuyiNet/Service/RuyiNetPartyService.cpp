#include "RuyiNetPartyService.h"

namespace Ruyi
{
	RuyiNetPartyService::RuyiNetPartyService(RuyiNetClient * client)
		:RuyiNetService(client)
	{
	}

	void RuyiNetPartyService::GetPartyInfo(int index, const RuyiNetTask<RuyiNetGetPartyInfoResponse>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index]() -> std::string
		{
			return RunParentScript(index, "GetPartyInfo", {});
		}, callback);
	}

	void RuyiNetPartyService::GetPartyMembersInfo(int index, const RuyiNetTask<RuyiNetGetProfilesResponse>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index]() -> std::string
		{
			return RunParentScript(index, "GetPartyMembers", {});
		}, callback);
	}

	void RuyiNetPartyService::SendPartyInvitation(int index, const RuyiString & profileId, const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index, &profileId]() -> std::string
		{
			return RunParentScript(index, "SendPartyInvitation", { {"profileId", profileId} });
		}, callback);
	}

	void RuyiNetPartyService::AcceptPartyInvitation(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index, &groupId]() -> std::string
		{
			return RunParentScript(index, "AcceptPartyInvitation", { { "groupId", groupId } });
		}, callback);
	}

	void RuyiNetPartyService::RejectPartyInvitation(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index, &groupId]() -> std::string
		{
			return RunParentScript(index, "RejectPartyInvitation", { { "groupId", groupId } });
		}, callback);
	}

	void RuyiNetPartyService::JoinParty(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index, &groupId]() -> std::string
		{
			return RunParentScript(index, "JoinParty", { { "groupId", groupId } });
		}, callback);
	}

	void RuyiNetPartyService::LeaveParty(int index, const RuyiString & groupId, const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index, &groupId]() -> std::string
		{
			return RunParentScript(index, "LeaveParty", { { "groupId", groupId } });
		}, callback);
	}
}