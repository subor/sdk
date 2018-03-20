#include "RuyiNetFriendService.h"

namespace Ruyi
{
	RuyiNetFriendService::RuyiNetFriendService(RuyiNetClient * client)
			: RuyiNetService(client)
	{}

	void RuyiNetFriendService::AddFriend(int index, const RuyiString & profileId,
		const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([&index, &profileId, this]() -> std::string
		{
			json payload = { "profileId", ToString(profileId) };
			return RunParentScript(index, "AddFriend", payload);
		}, callback);
	}

	void RuyiNetFriendService::RemoveFriend(int index, const RuyiString & profileId,
		const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([&index, &profileId, this]() -> std::string
		{
			json payload = { "profileId", ToString(profileId) };
			return RunParentScript(index, "RemoveFriend", payload);
		}, callback);
	}

	void RuyiNetFriendService::ListFriends(int index, const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([&index, this]() -> std::string
		{
			json payload = {};
			return RunParentScript(index, "ListFriends", payload);
		}, callback);
	}

	void RuyiNetFriendService::GetProfile(int index, const RuyiString & profileId,
		const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([&index, &profileId, this]() -> std::string
		{
			json payload = { "profileId", ToString(profileId) };
			return RunParentScript(index, "GetProfile", payload);
		}, callback);
	}

	void RuyiNetFriendService::GetProfiles(int index, const std::list<RuyiString> & profileIds,
		const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([&index, &profileIds, this]() -> std::string
		{
			std::list<std::string> mbsProfileIds;
			for (auto i : profileIds)
			{
				mbsProfileIds.push_back(ToString(i));
			}

			json payload = { "profileIds", mbsProfileIds };
			return RunParentScript(index, "GetProfiles", payload);
		}, callback);
	}
}