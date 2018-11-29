using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Allows players to gather together in a party.
    /// </summary>
    public class RuyiNetPartyService : RuyiNetService
    {
        /// <summary>
        /// Create the Party Service.
        /// </summary>
        /// <param name="client">The Ruyi Net client.</param>
        internal RuyiNetPartyService(RuyiNetClient client)
        : base(client)
        {
        }

        /// <summary>
        /// Get the current party information for the player.
        /// </summary>
        /// <param name="index">The index of user.</param>
        /// <param name="partyId">The ID of the party.</param>
        public async Task<RuyiNetPartyResponse> GetPartyInfo(int index, string partyId)
        {
            var resp = await mClient.BCService.Party_GetPartyInfoAsync(partyId, index, token);
            return mClient.Process<RuyiNetPartyResponse>(resp);
        }

        /// <summary>
        /// Invite someone to join a party.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerId">The ID of the player to invite.</param>
        public async Task<RuyiNetPartyResponse> SendPartyInvitation(int index, string playerId)
        {
            var resp = await mClient.BCService.Party_SendPartyInvitationAsync(playerId, index, token);
            return mClient.Process<RuyiNetPartyResponse>(resp);
        }

        /// <summary>
        /// Accept a party invitation.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to join.</param>
        public async Task<RuyiNetPartyResponse> AcceptPartyInvitation(int index, string partyId)
        {
            var resp = await mClient.BCService.Party_AcceptPartyInvitationAsync(partyId, index, token);
            return mClient.Process<RuyiNetPartyResponse>(resp);
        }

        /// <summary>
        /// Reject a party invitation.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to reject.</param>
        public async Task<RuyiNetPartyResponse> RejectPartyInvitation(int index, string partyId)
        {
            var resp = await mClient.BCService.Party_RejectPartyInvitationAsync(partyId, index, token);
            return mClient.Process<RuyiNetPartyResponse>(resp);
        }

        /// <summary>
        /// Join a friend's party.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to join.</param>
        public async Task<RuyiNetPartyResponse> JoinParty(int index, string partyId)
        {
            var resp = await mClient.BCService.Party_JoinPartyAsync(partyId, index, token);
            return mClient.Process<RuyiNetPartyResponse>(resp);
        }

        /// <summary>
        /// Leave a party.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to leave.</param>
        public async Task<RuyiNetPartyResponse> LeaveParty(int index, string partyId)
        {
            var resp = await mClient.BCService.Party_LeavePartyAsync(partyId, index, token);
            return mClient.Process<RuyiNetPartyResponse>(resp);
        }

        /// <summary>
        /// Get friends' parties.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="maxResults">The maximum, number of results to return .</param>
        public async Task<RuyiNetPartyListResponse> GetFriendsParties(int index, int maxResults)
        {
            var resp = await mClient.BCService.Party_GetFriendsPartiesAsync(maxResults, index, token);
            return mClient.Process<RuyiNetPartyListResponse>(resp);
        }

        /// <summary>
        /// List Party Invitations
        /// </summary>
        /// <param name="index">The index of user</param>
        public async Task<RuyiNetPartyInvitationResponse> ListPartyInvitations(int index)
        {
            var resp = await mClient.BCService.Party_ListPartyInvitationsAsync(index, token);
            return mClient.Process<RuyiNetPartyInvitationResponse>(resp);
        }

        /// <summary>
        /// Returns the party the current player is a member of, if any.
        /// </summary>
        /// <param name="index">The index of user</param>
        public async Task<RuyiNetPartyResponse> GetMyParty(int index)
        {
            var resp = await mClient.BCService.Party_GetMyPartyAsync(index, token);
            return mClient.Process<RuyiNetPartyResponse>(resp);
        }
    }
}