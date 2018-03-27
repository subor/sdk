#pragma once

#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetFriendService : public RuyiNetService
	{
	public:
		RuyiNetFriendService(RuyiNetClient * client);

		void AddFriend(int index, const RuyiString & profileId, const RuyiNetTask<json>::CallbackType & callback);
		void RemoveFriend(int index, const RuyiString & profileId, const RuyiNetTask<json>::CallbackType & callback);
		void ListFriends(int index, const RuyiNetTask<json>::CallbackType & callback);
		void GetProfile(int index, const RuyiString & profileId, const RuyiNetTask<json>::CallbackType & callback);
		void GetProfiles(int index, const std::list<RuyiString> & profileId, const RuyiNetTask<json>::CallbackType & callback);
	};
}