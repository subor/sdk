#pragma once

#include "RuyiNetService.h"
#include "RuyiNetLobby.h"
#include "../Response/RuyiNetLobbyResponse.h"

namespace Ruyi
{
	class RuyiNetLobbyService : public RuyiNetService
	{
	public:

		/// <summary>
		/// Creates a lobby that other players can find and join.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
		/// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
		void CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType);

		/// <summary>
		/// Creates a lobby that other players can find and join.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="maxSlots">The maximum number of players that can join this lobby.</param>
		/// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
		/// <param name="customAttributes">JSON string of custom attributes to attach to this lobby.</param>
		void CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType, std::string customAttributes);

		/// <summary>
		/// Closes a lobby and kicks all players.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="lobbyId">The ID of the lobby to close.</param>
		/// <param name="response">The parsed data struct of return json</param>
		void CloseLobby(int index, std::string lobbyId, RuyiNetResponse& response);

		/// <summary>
		/// Searches for lobbies created by other players.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="numResults">The maximum number of lobbies to return.</param>
		/// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
		/// <param name="lobbyList">The Found lobbies list</param>
		void FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, std::list<RuyiNetLobby*>& lobbyList);

		/// <summary>
		/// Searches for lobbies created by other players.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="numResults">The maximum number of lobbies to return.</param>
		/// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
		/// <param name="freeSlots">The number of free slots needed.</param>
		/// <param name="lobbyList">The Found lobbies list</param>
		void FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, std::list<RuyiNetLobby*>& lobbyList);

		/// <summary>
		/// Searches for lobbies created by other players.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="numResults">The maximum number of lobbies to return.</param>
		/// <param name="lobbyType">Whether or not this lobby is for a RANKED MATCH or a PLAYER MATCH.</param>
		/// <param name="freeSlots">The number of free slots needed.</param>
		/// <param name="searchCriteria">JSON string representing parameters to search for.</param>
		/// <param name="lobbyList">The Found lobbies list</param>
		void FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, std::string searchCriteria, std::list<RuyiNetLobby*>& lobbyList);

		const RuyiNetLobby* CurrentLobby() const { return mCurrentLobby; }

	private:
		RuyiNetLobby* mCurrentLobby;
		void InitLobby(RuyiNetResponseGroup& response);
		void DeleteLobby();
	};
}