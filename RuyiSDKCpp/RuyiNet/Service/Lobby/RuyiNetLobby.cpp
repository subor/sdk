#include "RuyiNetLobby.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi {
	RuyiNetLobby::RuyiNetLobby() 
	{
		PendingMembers.clear();
		Members.clear();
		MemberProfileIds.clear();

		LobbyId = "";
		OwnerProfileId = "";
		State = "";
		CreatedAt = 0;
		UpdatedAt = 0;
		RequestingPendingMemberCount = 0;
		InvitedPendingMemberCount = 0;
		MemberCount = 0;

		MaxSlots = 0;
		FreeSlots = 0;
		ConnectionString = "";
		LobbyType = RuyiNetLobbyType::PLAYER;
	}

	RuyiNetLobby::RuyiNetLobby(RuyiNetResponseGroup& response)
	{
		InitWithResponse(response);
	}

	RuyiNetLobby::~RuyiNetLobby()
	{
		PendingMembers.clear();
		Members.clear();
		MemberProfileIds.clear();
	}

	void RuyiNetLobby::InitWithResponse(RuyiNetResponseGroup& response)
	{
		ParseMembers(response.pendingMembers, PendingMembers);
		ParseMembers(response.members, Members);

		MemberProfileIds.clear();
		std::for_each(Members.begin(), Members.end(), [&](RuyiNetLobbyMember& member)
		{
			MemberProfileIds.push_back(&(member.GetProfileId()));
		});

		LobbyId = response.groupId;
		OwnerProfileId = response.ownerId;
		State = response.name;
		CreatedAt = response.createdAt;
		UpdatedAt = response.updatedAt;
		RequestingPendingMemberCount = response.requestingPendingMemberCount;
		InvitedPendingMemberCount = response.invitedPendingMemberCount;
		MemberCount = response.memberCount;

		MaxSlots = response.data.maxSlots;
		FreeSlots = response.data.freeSlots;
		ConnectionString = response.data.connectionString;
		LobbyType = response.data.ranked ? RuyiNetLobbyType::RANKED : RuyiNetLobbyType::PLAYER;
	}

	void RuyiNetLobby::ParseMembers(std::map<std::string, RuyiNetResponseGroup::Member>& members, std::list<RuyiNetLobbyMember>& pendingMembers)
	{
		pendingMembers.clear();
		std::for_each(members.begin(), members.end(), [&](const std::pair<std::string, RuyiNetResponseGroup::Member>& member) 
		{
			RuyiNetLobbyMember lobbyMember(member.first, member.second.role);
			pendingMembers.push_back(lobbyMember);
		});
	}

//}
	}}} //namespace