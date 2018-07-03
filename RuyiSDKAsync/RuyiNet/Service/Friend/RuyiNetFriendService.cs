using Newtonsoft.Json;
using System.Threading.Tasks;

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

        /// <summary>
        /// Adds a user to the player's friend list.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="profileId">The profile ID of the user to add.</param>
        public async Task<RuyiNetResponse> AddFriend(int index, string profileId)
        {
            var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
            var resp = await mClient.BCService.Script_RunParentScriptAsync("AddFriend", JsonConvert.SerializeObject(payload), "RUYI", index, token);
            return mClient.Process<RuyiNetResponse>(resp);
        }

        /// <summary>
        /// Removes a user from the player's friend list.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="profileId">The profile ID of the user to remove.</param>
        public async Task<RuyiNetResponse> RemoveFriend(int index, string profileId)
        {
            var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
            var resp = await mClient.BCService.Script_RunParentScriptAsync("RemoveFriend", JsonConvert.SerializeObject(payload), "RUYI", index, token);
            return mClient.Process<RuyiNetResponse>(resp);
        }

        /// <summary>
        /// Returns a list of the user's friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        public async Task<RuyiNetListFriendsResponse> ListFriends(int index)
        {
            var resp = await mClient.BCService.Script_RunParentScriptAsync("ListFriends", "{}", "RUYI", index, token);
            return mClient.Process<RuyiNetListFriendsResponse>(resp);
        }

        /// <summary>
        /// Get the profile of the specified user.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="profileId">The profile ID of the user to get the profile for.</param>
        public async Task<RuyiNetGetProfileResponse> GetProfile(int index, string profileId)
        {
            var payload = new RuyiNetProfileIdRequest() { profileId = profileId };
            var resp = await mClient.BCService.Script_RunParentScriptAsync("GetProfile", JsonConvert.SerializeObject(payload), "RUYI", index, token);
            return mClient.Process<RuyiNetGetProfileResponse>(resp);
        }

        /// <summary>
        /// Get the profile of the specified users.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="profileIds">A list of profile IDs of the users to get the profiles for.</param>
        public async Task<RuyiNetGetProfilesResponse> GetProfiles(int index, string[] profileIds)
        {
            var payload = new RuyiNetProfileIdsRequest() { profileIds = profileIds };
            var resp = await mClient.BCService.Script_RunParentScriptAsync("GetProfiles", JsonConvert.SerializeObject(payload), "RUYI", index, token);
            return mClient.Process<RuyiNetGetProfilesResponse>(resp);
        }
    }
}
