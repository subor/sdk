#pragma once

#include "../../Response/RuyiNetGetPartyInfoResponse.h"
#include "../../Response/RuyiNetGetProfilesResponse.h"
#include "../../Response/RuyiNetResponse.h"
#include "../RuyiNetService.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	class RuyiNetPartyService : public RuyiNetService
	{
	public:
		RuyiNetPartyService(RuyiNetClient * client);

		/// <summary>
		/// Get the current party information for the player.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="response">The parse data structure of response json</param>
		void GetPartyInfo(int index, RuyiNetGetPartyInfoResponse& response);

		/// <summary>
		/// Get information on the party members in the current party.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="response">The parse data structure of response json</param>
		void GetPartyMembersInfo(int index, RuyiNetGetProfilesResponse& response);
		
		/// <summary>
		/// Invite someone to join a party.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="profileId">The profile ID of the player to invite.</param>
		/// <param name="response">The parse data structure of response json</param>
		void SendPartyInvitation(int index, const std::string& profileId, RuyiNetResponse& response);		
		
		/// <summary>
		/// Accept a party invitation.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="groupId">The group ID of the party to join.</param>
		/// <param name="response">The parse data structure of response json</param>
		void AcceptPartyInvitation(int index, const std::string& groupId, RuyiNetResponse& response);
		
		/// <summary>
		/// Reject a party invitation.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="groupId">The group ID of the party to reject.</param>
		/// <param name="response">The parse data structure of response json</param>
		void RejectPartyInvitation(int index, const std::string& groupId, RuyiNetResponse& response);
		
		/// <summary>
		/// Join a friend's party.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="groupId">The group ID of the party to join.</param>
		/// <param name="response">The parse data structure of response json</param>
		void JoinParty(int index, const std::string& groupId, RuyiNetResponse& response);
		
		/// <summary>
		/// Leave a party.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="groupId">The group ID of the party to leave.</param>
		/// <param name="response">The parse data structure of response json</param>
		void LeaveParty(int index, const std::string& groupId, RuyiNetResponse& response);	
	};
//}
	}}} //namespace