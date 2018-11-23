using Newtonsoft.Json;
using Ruyi.SDK.BrainCloudApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// A service for handling players' friend lists.
    /// </summary>
    /// <example>
    /// <code source="sdk/unittests/doctests.cs" region="RuyiNet_Friends"></code>
    /// </example>
    public class RuyiNetFriendService : RuyiNetService
    {
        /// <summary>
        /// Create a Friend Service.
        /// </summary>
        /// <param name="client">The Ruyi Net Client.</param>
        internal RuyiNetFriendService(RuyiNetClient client)
        : base(client)
        {
        }

        /// <summary>
        /// Accepts a friend invitation and adds the player to the friend list.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerId">The  ID of the player to remove.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void AcceptFriendInvitation(int index, string playerId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_AcceptFriendInvitation(playerId, index);
            }, callback);
        }

        /// <summary>
        /// Attempts to find a user by exact name.
        /// </summary>
        /// <param name="index">The index of user.</param>
        /// <param name="name">The name of the user to search for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindUserByExactName(int index, string name, Action<RuyiNetFriendSummaryData[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_FindUsersByExactName(name, 1, index);
            }, (RuyiNetFriendFindUsersResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.matches.Cast<RuyiNetFriendSummaryData>().ToArray();
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
        /// Attempts to find users with names containing the substring.
        /// </summary>
        /// <param name="index">The index of user.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="maxResults">The maximum number of results to return.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void FindUsersBySubstrName(int index, string substring, int maxResults, Action<RuyiNetFriendSummaryData[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_FindUsersBySubstrName(substring, maxResults, index);
            }, (RuyiNetFriendFindUsersResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.matches.Cast<RuyiNetFriendSummaryData>().ToArray();
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
        /// Retrieve the online status of a list of users.
        /// </summary>
        /// <param name="index">The index of user.</param>
        /// <param name="playerIds">The IDs of the players to get the online status for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetUsersOnlineStatus(int index, List<string> playerIds, Action<RuyiNetFriendOnlineStatus[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_GetUsersOnlineStatus(playerIds, index);
            }, (RuyiNetFriendGetUsersOnlineStatusResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.onlineStatus.Cast<RuyiNetFriendOnlineStatus>().ToArray();
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
        /// Returns the summary data for players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerId">The ID of the player to get the summary data for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetSummaryDataForPlayerId(int index, string playerId, Action<RuyiNetFriendSummaryData> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_GetSummaryDataForProfileId(playerId, index);
            }, (RuyiNetGetSummaryDataForProfileIdResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Returns the summary data for players.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerIds">The ID of the players to get the summary data for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetSummaryDataForPlayerIds(int index, List<string> playerIds, Action<RuyiNetFriendSummaryData[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_GetSummaryDataForProfileIds(playerIds, index);
            }, (RuyiNetGetSummaryDataMultipleResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.profiles.Cast<RuyiNetFriendSummaryData>().ToArray();
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
        /// Returns the summary data for a player's friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetSummaryDataForFriends(int index, Action<RuyiNetFriendSummaryData[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_GetSummaryDataForFriends(index);
            }, (RuyiNetGetSummaryDataMultipleResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.profiles.Cast<RuyiNetFriendSummaryData>().ToArray();
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
        /// Returns the summary data for a player's friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetSummaryDataForRecentlyMetPlayers(int index, Action<RuyiNetFriendSummaryData[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_GetSummaryDataForRecentlyMetPlayers(index);
            }, (RuyiNetGetSummaryDataMultipleResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.profiles.Cast<RuyiNetFriendSummaryData>().ToArray();
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
        /// Returns a list of invitations sent to this player.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ListFriendInvitationsRecieved(int index, Action<RuyiNetFriendInvite[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_ListFriendInvitationsReceived(index);
            }, (RuyiNetFriendListInvitationsResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.friendInvitations.Cast<RuyiNetFriendInvite>().ToArray();
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
        /// Returns a list of invitations the player has sent.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ListFriendInvitationsSent(int index, Action<RuyiNetFriendInvite[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_ListFriendInvitationsSent(index);
            }, (RuyiNetFriendListInvitationsResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        var results = response.data.friendInvitations.Cast<RuyiNetFriendInvite>().ToArray();
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
        /// Returns a list of the user's friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ListFriends(int index, Action<RuyiNetFriendSummaryData[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_ListFriends(FriendPlatform.brainCloud, true, index);
            }, (RuyiNetListFriendsResponse response) =>
            {
                if (callback != null)
                {
                    callback(response.GetFriendSummaryData());
                }
            });
        }

        /// <summary>
        /// Read an entity attached to a friend.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="entityId">The ID of the entity to retrieve.</param>
        /// <param name="friendPlayerId">The player ID of the friend.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ReadFriendEntity(int index, string entityId, string friendPlayerId, Action<RuyiNetEntity> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_ReadFriendEntity(entityId, friendPlayerId, index);
            }, (RuyiNetReadFriendEntityResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data);
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Read an entity attached to a friend.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="entityType">The type of entities to retrieve.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ReadFriendsEntities(int index, string entityType, Action<RuyiNetEntity[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_ReadFriendsEntities(entityType, index);
            }, (RuyiNetReadFriendsEntitiesResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == 200)
                    {
                        var results = response.data.results.Cast<RuyiNetEntity>().ToArray();
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
        /// Reject and delete a friend invitation.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerId">The  ID of the player to remove.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void RejectFriendInvitation(int index, string playerId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_RejectFriendInvitation(playerId, index);
            }, callback);
        }

        /// <summary>
        /// Removes a user from the player's friend list.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerId">The  ID of the player to remove.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void RemoveFriend(int index, string playerId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_RemoveFriend(playerId, index);
            }, callback);
        }

        /// <summary>
        /// Send an invitation to be friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="playerId">The  ID of the player to send the invitation to.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void SendFriendInvitation(int index, string playerId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_SendFriendInvitation(playerId, index);
            }, callback);
        }

        [Obsolete("Use SendFriendInvitation instead")]
        public void AddFriend(int index, string profileId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
                return mClient.BCService.Script_RunParentScript("AddFriend", JsonConvert.SerializeObject(payload), "RUYI", index);
            }, callback);
        }

        [Obsolete("Use GetSummaryDataForProfileId instead")]
        public void GetProfile(int index, string profileId, RuyiNetTask<RuyiNetGetProfileResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
                return mClient.BCService.Script_RunParentScript("GetProfile", JsonConvert.SerializeObject(payload), "RUYI", index);
            }, callback);
        }

        [Obsolete("Use ListFriends instead")]
        public void GetProfiles(int index, string[] profileIds, RuyiNetTask<RuyiNetGetProfilesResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var payload = new RuyiNetProfileIdsRequest() { profileIds = profileIds };
                return mClient.BCService.Script_RunParentScript("GetProfiles", JsonConvert.SerializeObject(payload), "RUYI", index);
            }, callback);
        }
    }
}
