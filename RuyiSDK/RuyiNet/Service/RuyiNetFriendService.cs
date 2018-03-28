using Newtonsoft.Json;

namespace Ruyi
{
    /// <summary>
    /// A service for handling players' friend lists.
    /// </summary>
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
        /// Adds a user to the player's friend list.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="profileId">The profile ID of the user to add.</param>
        /// <param name="callback">The function to call when the task completes.</param>
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
        /// <param name="profileId">The profile ID of the user to remove.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void RemoveFriend(int index, string profileId, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
                return mClient.BCService.Script_RunParentScript("RemoveFriend", JsonConvert.SerializeObject(payload), "RUYI", index);
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
                return mClient.BCService.Script_RunParentScript("ListFriends", "{}", "RUYI", index);
            }, callback);
        }

        /// <summary>
        /// Get the profile of the specified user.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="profileId">The profile ID of the user to get the profile for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
        public void GetProfile(int index, string profileId, RuyiNetTask<RuyiNetGetProfileResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
                return mClient.BCService.Script_RunParentScript("GetProfile", JsonConvert.SerializeObject(payload), "RUYI", index);
            }, callback);
        }

        /// <summary>
        /// Get the profile of the specified users.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="profileIds">A list of profile IDs of the users to get the profiles for.</param>
        /// <param name="callback">The function to call when the task completes.</param>
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
