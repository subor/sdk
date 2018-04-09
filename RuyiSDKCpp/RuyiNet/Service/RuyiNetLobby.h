#pragma once

#include "../RuyiNetClient.h"
#include "../Response/RuyiNetLobbyResponse.h"

namespace Ruyi
{
	class RuyiNetLobby 
	{
		/// <summary>
		/// Represents a single lobby member.
		/// </summary>
		struct RuyiNetLobbyMember
		{
		public:
			/// <summary>
			/// Create the lobby member.
			/// </summary>
			/// <param name="profileId">The profile ID of the player.</param>
			/// <param name="role">The role of the player.</param>
			RuyiNetLobbyMember(const std::string& profileId, const std::string& role) : ProfileId(profileId), Role(role) {}
			const std::string& GetProfileId() { return ProfileId; }
			const std::string& GetRole() { return Role; }
		private:
			/// <summary>
			/// The profile ID of the player.
			/// </summary>
			std::string ProfileId;
			/// <summary>
			/// The role of the player.
			/// </summary>
			std::string Role;
		};

	public:
		RuyiNetLobby();
		RuyiNetLobby(RuyiNetResponseGroup& group);
		
		const std::list<RuyiNetLobbyMember>& GetPendingMembers() { return PendingMembers; }
		const std::list<RuyiNetLobbyMember>& GetMembers() { return Members; }
		const std::list<const std::string*>& GetMemberProfileIds() { return MemberProfileIds; }
		const std::string& GetLobbyId() { return LobbyId; }
		const std::string& GetOwnerProfileId() { return OwnerProfileId; }
		const std::string& GetState() { return State; }
		const std::string& GetConnectionString() { return ConnectionString; }
		const RuyiNetLobbyType& GetLobbyType() { return LobbyType; }
		const long& GetCreatedAt() { return CreatedAt; }
		const long& GetUpdatedAt() { return UpdatedAt; }
		const int& GetMemberCount() { return MemberCount; }
		const int& GetMaxSlots() { return MaxSlots; }
		const int& GetFreeSlots() { return FreeSlots; }
		const int& GetRequestingPendingMemberCount() { return RequestingPendingMemberCount; }
		const int& GetInvitedPendingMemberCount() { return InvitedPendingMemberCount; }

	private:
		/// <summary>
		/// A list of players that have either been invited or requested to join
		/// the lobby.
		/// </summary>
		std::list<RuyiNetLobbyMember> PendingMembers;

		/// <summary>
		/// The players who are in this lobby.
		/// </summary>
		std::list<RuyiNetLobbyMember> Members;

		/// <summary>
		/// A list of ids - useful for quickly retrieving profile data.
		/// </summary>
		std::list<const std::string*> MemberProfileIds;

		/// <summary>
		/// The unique ID of the lobby.
		/// </summary>
		std::string LobbyId;

		/// <summary>
		/// The profile ID of the player who owns this lobby.
		/// </summary>
		std::string OwnerProfileId;

		/// <summary>
		/// The current state of the lobby.
		/// </summary>
		std::string State;

		/// <summary>
		/// A connection string used to connect to the host.
		/// </summary>
		std::string ConnectionString;

		/// <summary>
		/// The type of lobby - Ranked or Player match
		/// </summary>
		RuyiNetLobbyType LobbyType;

		/// <summary>
		/// When the lobby was created.
		/// </summary>
		long CreatedAt;

		/// <summary>
		/// When the lobby was last updated.
		/// </summary>
		long UpdatedAt;

		/// <summary>
		/// The number of players in the lobby.
		/// </summary>
		int MemberCount;

		/// <summary>
		/// The maximum number of players that can be in this lobby.
		/// </summary>
		int MaxSlots;

		/// <summary>
		/// The number of free slots available in this lobby.
		/// </summary>
		int FreeSlots;

		/// <summary>
		/// The number of players that have requested to join the lobby.
		/// </summary>
		int RequestingPendingMemberCount;

		/// <summary>
		/// The number of players that have been invited to join the lobby.
		/// </summary>
		int InvitedPendingMemberCount;

		void ParseMembers(std::map<std::string, RuyiNetResponseGroup::Member>& members, std::list<RuyiNetLobbyMember>& pendingMembers);
	};
}