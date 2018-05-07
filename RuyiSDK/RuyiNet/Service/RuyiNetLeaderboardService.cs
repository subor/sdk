using Newtonsoft.Json;
using Ruyi.SDK.BrainCloudApi;
using System;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// Provides operations to retrieve leaderboard data and submit scores.
    /// </summary>
    public class RuyiNetLeaderboardService : RuyiNetService
    {
        /// <summary>
        /// Create a leaderboard service.
        /// </summary>
        /// <param name="client"></param>
        internal RuyiNetLeaderboardService(RuyiNetClient client)
        : base(client)
        {
        }

        /// <summary>
        /// Create a leaderboard. This will be deprecated when the developer portal is available.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="id">The ID of the new leaderboard.</param>
        /// <param name="type">The type of leaderboard to create.</param>
        /// <param name="rotationType">How often the leaderboard will rotate scores.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void CreateLeaderboard(int index, string id, RuyiNetLeaderboardType type,
            RuyiNetRotationType rotationType, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var data = new RuyiNetCreateLeaderboardRequest()
                {
                    leaderboardId = mClient.AppId + "_" + id,
                    type = type.ToString(),
                    rotationType = rotationType.ToString(),
                    versionsToRetain = 1
                };

                return mClient.BCService.Script_RunParentScript("CreateLeaderboard", JsonConvert.SerializeObject(data), "RUYI", index);
            }, callback);
        }

        /// <summary>
        /// Retrieves paginated data from a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="id">The ID of the leaderboard to retrieve.</param>
        /// <param name="sort">How to sort the data.</param>
        /// <param name="startIndex">The first entry to retrieve.</param>
        /// <param name="endIndex">The last entry to retrieve.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGLobalLeaderboardPage(int index, string id, SortOrder sort,
            int startIndex, int endIndex, RuyiNetTask<RuyiNetLeaderboardResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var data = new RuyiNetGetGlobalLeaderboardPageRequest()
                {
                    leaderboardId = mClient.AppId + "_" + id,
                    sort = sort.ToString(),
                    startIndex = startIndex,
                    endIndex = endIndex
                };

                return mClient.BCService.Script_RunParentScript("GetGlobalLeaderboardPage", JsonConvert.SerializeObject(data), "RUYI", index);
            }, callback);
        }

        /// <summary>
        /// Retrieves data from a leaderboard centered around the current player.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="id">The ID of the leaderboard to retrieve.</param>
        /// <param name="sort">How to sort the data.</param>
        /// <param name="beforeCount">How many entries before the current player to retrieve.</param>
        /// <param name="afterCount">How many entries after the current player to retrieve.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGlobalLeaderboardView(int index, string id, SortOrder sort,
            int beforeCount, int afterCount, RuyiNetTask<RuyiNetLeaderboardResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var data = new RuyiNetGetGlobalLeaderboardViewRequest()
                {
                    leaderboardId = mClient.AppId + "_" + id,
                    sort = sort.ToString(),
                    beforeCount = beforeCount,
                    afterCount = afterCount
                };

                return mClient.BCService.Script_RunParentScript("GetGlobalLeaderboardView", JsonConvert.SerializeObject(data), "RUYI", index);
            }, callback);
        }

        /// <summary>
        /// Retrieves a leaderboard with all the user's friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="id">The ID of the leaderboard to retrieve.</param>
        /// <param name="replaceName">If true, the player's name is replaced by the string "You".</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetSocialLeaderboard(int index, string id, bool replaceName,
            RuyiNetTask<RuyiNetSocialLeaderboardResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var data = new RuyiNetGetSocialLeaderboardRequest()
                {
                    leaderboardId = mClient.AppId + "_" + id,
                    replaceName = replaceName
                };

                return mClient.BCService.Script_RunParentScript("GetSocialLeaderboard", JsonConvert.SerializeObject(data), "RUYI", index);
            }, callback);
        }

        /// <summary>
        /// Posts a score to the leaderboard for the player.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="id">The ID of the leaderboard to post to.</param>
        /// <param name="score">The score to post.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void PostScoreToLeaderboard(int index, string id, int score,
            RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            EnqueueTask(() =>
            {
                var data = new RuyiNetPostScoreToLeaderboardRequest()
                {
                    leaderboardId = mClient.AppId + "_" + id,
                    score = score
                };

                return mClient.BCService.Script_RunParentScript("PostScoreToLeaderboard", JsonConvert.SerializeObject(data), "RUYI", index);
            }, callback);
        }

        private class RuyiNetCreateLeaderboardRequest
        {
            public string leaderboardId;
            public string type;
            public string rotationType;
            public int versionsToRetain;
        }

        private class RuyiNetGetGlobalLeaderboardPageRequest
        {
            public string leaderboardId;
            public string sort;
            public int startIndex;
            public int endIndex;
        }

        private class RuyiNetGetGlobalLeaderboardViewRequest
        {
            public string leaderboardId;
            public string sort;
            public int beforeCount;
            public int afterCount;
        }

        private class RuyiNetGetSocialLeaderboardRequest
        {
            public string leaderboardId;
            public bool replaceName;
        }

        private class RuyiNetPostScoreToLeaderboardRequest
        {
            public string leaderboardId;
            public int score;
        }
    }
    
    /// <summary>
    /// Contains the leaderboard returned from a leaderboard request.
    /// </summary>
    [Serializable]
    public class RuyiNetLeaderboardResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The response.
            /// </summary>
            [Serializable]
            public class Response
            {
                /// <summary>
                /// Timestamp of when the leaderboard data was retrieved.
                /// </summary>
                public long server_time;

                /// <summary>
                /// A single leaderboard entry.
                /// </summary>
                [Serializable]
                public class LeaderboardData
                {
                    /// <summary>
                    /// The ID of the player this entry relates to.
                    /// </summary>
                    public string playerId;

                    /// <summary>
                    /// The score.
                    /// </summary>
                    public int score;

                    /// <summary>
                    /// When this entry was created.
                    /// </summary>
                    public long createdAt;

                    /// <summary>
                    /// When this entry was last updated.
                    /// </summary>
                    public long updatedAt;

                    /// <summary>
                    /// The index of this entry in the returned data.
                    /// </summary>
                    public int index;

                    /// <summary>
                    /// The rank of the player in the leaderboard.
                    /// </summary>
                    public int rank;

                    /// <summary>
                    /// The user name of the player.
                    /// </summary>
                    public string name;

                    /// <summary>
                    /// The URL of the users profile image.
                    /// </summary>
                    public string pictureUrl;

                    /// <summary>
                    /// Whether or not this player is friends with the current user.
                    /// </summary>
                    public bool friend;
                }

                /// <summary>
                /// The leaderboard.
                /// </summary>
                public LeaderboardData[] leaderboard;

                /// <summary>
                /// The version of the leaderboard.
                /// </summary>
                public int versionId;

                /// <summary>
                /// The ID the of the leaderboard the data was retrieved from.
                /// </summary>
                public string leaderboardId;

                /// <summary>
                /// How long before the leaderboard will be reset, in milliseconds.
                /// </summary>
                public int timeBeforeReset;

                /// <summary>
                /// Are there more entries after these?
                /// </summary>
                public bool moreAfter;

                /// <summary>
                /// Are there more entries before these?
                /// </summary>
                public bool moreBefore;
            }

            /// <summary>
            /// The response.
            /// </summary>
            public Response response;

            /// <summary>
            /// Whether or not the server-side script succeeded.
            /// </summary>
            public bool success;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status code of this response.
        /// </summary>
        public int status;
    }

    /// <summary>
    /// A response from retrieving social leaderboard data.
    /// </summary>
    [Serializable]
    public class RuyiNetSocialLeaderboardResponse
    {
        /// <summary>
        /// The response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// THe response.
            /// </summary>
            [Serializable]
            public class Response
            {
                /// <summary>
                /// Timestamp of when the leaderboard data was retrieved.
                /// </summary>
                public long server_time;

                /// <summary>
                /// A single leaderboard entry.
                /// </summary>
                [Serializable]
                public class LeaderboardData
                {
                    /// <summary>
                    /// The score.
                    /// </summary>
                    public int score;

                    /// <summary>
                    /// When this entry was created.
                    /// </summary>
                    public long createdAt;

                    /// <summary>
                    /// The user name of the player.
                    /// </summary>
                    public string playerName;

                    /// <summary>
                    /// The URL of the users profile image.
                    /// </summary>
                    public string pictureUrl;

                    /// <summary>
                    /// The ID of the player this entry relates to.
                    /// </summary>
                    public string playerId;

                    /// <summary>
                    /// When this entry was updated.
                    /// </summary>
                    public long updatedAt;
                }

                /// <summary>
                /// The leaderboard.
                /// </summary>
                public LeaderboardData[] social_leaderboard;

                /// <summary>
                /// The ID the of the leaderboard the data was retrieved from.
                /// </summary>
                public string leaderboardId;

                /// <summary>
                /// How long before the leaderboard will be reset, in milliseconds.
                /// </summary>
                public int timeBeforeReset;
            }

            /// <summary>
            /// THe response.
            /// </summary>
            public Response response;

            /// <summary>
            /// Whether or not the server-side script succeeded.
            /// </summary>
            public bool success;
        }

        /// <summary>
        /// The response data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status code of this response.
        /// </summary>
        public int status;
    }
}
