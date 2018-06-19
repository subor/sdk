#pragma once

#include "../../RuyiNetClient.h"
#include "../../Response/RuyiNetLobbyResponse.h"

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
			const std::string& GetProfileId() const { return ProfileId; }
			const std::string& GetRole() const { return Role; }
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
		RuyiNetLobby(RuyiNetResponseGroup& response);
		void InitWithResponse(RuyiNetResponseGroup& response);
		~RuyiNetLobby();

		const std::list<RuyiNetLobbyMember>& GetPendingMembers() const { return PendingMembers; }
		const std::list<RuyiNetLobbyMember>& GetMembers() const { return Members; }
		const std::list<const std::string*>& GetMemberProfileIds() const { return MemberProfileIds; }
		const std::string& GetLobbyId() const { return LobbyId; }
		const std::string& GetOwnerProfileId() const { return OwnerProfileId; }
		const std::string& GetState() const { return State; }
		const std::string& GetConnectionString() const { return ConnectionString; }
		const RuyiNetLobbyType& GetLobbyType() const { return LobbyType; }
		const long& GetCreatedAt() const { return CreatedAt; }
		const long& GetUpdatedAt() const { return UpdatedAt; }
		const int& GetMemberCount() const { return MemberCount; }
		const int& GetMaxSlots() const { return MaxSlots; }
		const int& GetFreeSlots() const { return FreeSlots; }
		const int& GetRequestingPendingMemberCount() const { return RequestingPendingMemberCount; }
		const int& GetInvitedPendingMemberCount() const { return InvitedPendingMemberCount; }

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