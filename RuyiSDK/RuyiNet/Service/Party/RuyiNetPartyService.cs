using Newtonsoft.Json;
using System;
using System.Linq;

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
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetPartyInfo(int index, string partyId, Action<RuyiNetParty> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_GetPartyInfo(partyId, index);
            }, (RuyiNetPartyResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.party);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Invite someone to join a party.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerId">The ID of the player to invite.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void SendPartyInvitation(int index, string playerId, Action<RuyiNetParty> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_SendPartyInvitation(playerId, index);
            }, (RuyiNetPartyResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.party);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Accept a party invitation.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to join.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void AcceptPartyInvitation(int index, string partyId, Action<RuyiNetParty> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_AcceptPartyInvitation(partyId, index);
            }, (RuyiNetPartyResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.party);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Reject a party invitation.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to reject.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void RejectPartyInvitation(int index, string partyId, Action<RuyiNetParty> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_RejectPartyInvitation(partyId, index);
            }, (RuyiNetPartyResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.party);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Join a friend's party.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to join.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void JoinParty(int index, string partyId, Action<RuyiNetParty> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_JoinParty(partyId, index);
            }, (RuyiNetPartyResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.party);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Leave a party.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="partyId">The ID of the party to leave.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void LeaveParty(int index, string partyId, Action<RuyiNetParty> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_LeaveParty(partyId, index);
            }, (RuyiNetPartyResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.party);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Get friends' parties.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="maxResults">The maximum, number of results to return .</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetFriendsParties(int index, int maxResults, Action<RuyiNetParty[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_GetFriendsParties(maxResults, index);
            }, (RuyiNetPartyListResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.parties.Cast<RuyiNetParty>().ToArray();
                        callback(results);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// List Party Invitations
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ListPartyInvitations(int index, Action<RuyiNetPartyInvitation[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_ListPartyInvitations(index);
            }, (RuyiNetPartyInvitationResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.invites.Cast<RuyiNetPartyInvitation>().ToArray();
                        callback(results);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Returns the party the current player is a member of, if any.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetMyParty(int index, Action<RuyiNetParty> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Party_GetMyParty(index);
            }, (RuyiNetPartyResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.party);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }
    }
}