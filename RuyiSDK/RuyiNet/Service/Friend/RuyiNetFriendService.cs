using Newtonsoft.Json;
using Ruyi.SDK.BrainCloudApi;
using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// A service for handling players' friend lists.
    /// </summary>
    /// <example>
    /// <code source="layer0/sdktest/doctests.cs" region="RuyiNet_Friends"></code>
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

        [Obsolete("Use SendFriendInvitation instead")]
        public void AddFriend(int index, string profileId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
                return mClient.BCService.Script_RunParentScript("AddFriend", JsonConvert.SerializeObject(payload), "RUYI", index);
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
        /// Returns a list of the user's friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void ListFriends(int index, RuyiNetTask<RuyiNetListFriendsResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.Friend_ListFriends(FriendPlatform.brainCloud, true, index);
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
