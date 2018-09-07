#pragma once

#include "../RuyiNetService.h"
#include "../../Response/RuyiNetGetProfileResponse.h"
#include "../../Response/RuyiNetGetProfilesResponse.h"
#include "../../Response/RuyiNetFriendResponse.h"

namespace Ruyi { namespace SDK { namespace Online {

	class RuyiNetFriendService : public RuyiNetService
	{
	public:
		RuyiNetFriendService(RuyiNetClient* client);

		/// <summary>
		/// Adds a user to the player's friend list.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="profileId">The profile ID of the user to add.</param>
		/// <param name="response">The parsed data struct of return json </param>
		void AddFriend(int index, const std::string& profileId, RuyiNetAddRemoveFriendResponse& response);

		/// <summary>
		/// Removes a user from the player's friend list.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="profileId">The profile ID of the user to remove.</param>
		/// <param name="response">The parsed data struct of return json </param>
		void RemoveFriend(int index, const std::string& profileId, RuyiNetAddRemoveFriendResponse& response);

		/// <summary>
		/// Returns a list of the user's friends.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="response">The parsed data struct of return json </param>
		void ListFriends(int index, RuyiNetFriendListResponse& response);

		/// <summary>
		/// Get the profile of the specified user.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="profileId">The profile ID of the user to get the profile for.</param>
		/// <param name="response">The parsed data struct of return json </param>
		void GetProfile(int index, const std::string& profileId, RuyiNetGetProfileResponse& response);

		/// <summary>
		/// Get the profile of the specified users.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="profileIds">A list of profile IDs of the users to get the profiles for.</param>
		void GetProfiles(int index, const std::list<std::string>& profileId, RuyiNetGetProfilesResponse& response);
	};
}}} 