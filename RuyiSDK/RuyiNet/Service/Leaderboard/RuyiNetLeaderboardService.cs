using Ruyi.Logging;
using Ruyi.SDK.BrainCloudApi;
using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
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
        /// Deprecated. Use Portal to create leaderboards. Use Cloud Code to dynamically create leaderboards.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="id">The ID of the new leaderboard.</param>
        /// <param name="type">The type of leaderboard to create.</param>
        /// <param name="rotationType">How often the leaderboard will rotate scores.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        [Obsolete("Use Portal to create leaderboards. Use Cloud Code to dynamically create leaderboards.")]
        public void CreateLeaderboard(int index, string id, RuyiNetLeaderboardType type,
            RuyiNetRotationType rotationType, RuyiNetTask<RuyiNetResponse>.CallbackType callback)
        {
            if (callback != null)
            {
                callback(null);
            }
        }

        /// <summary>
        /// Returns the number of entries in a global leaderboard.
        /// </summary>
        /// <param name="index">The index of the client calling the operation.</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve data for.</param>
        /// <param name="callback">Callback to call when the data is returned.</param>
        public void GetGlobalLeaderboardEntryCount(int index, string leaderboardId, Action<int> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGlobalLeaderboardEntryCount(leaderboardId, index);
            }, (RuyiNetGetGlobalLeaderboardEntryCountResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.entryCount);
                    }
                    else
                    {
                        Logger.Log("GetGlobalLeaderboardEntryCount failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(0);
                    }
                }
            });
        }

        /// <summary>
        /// Returns the number of entries in a global leaderboard.
        /// </summary>
        /// <param name="index">The index of the client calling the operation.</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve data for.</param>
        /// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
        /// <param name="callback">Callback to call when the data is returned.</param>
        public void GetGlobalLeaderboardEntryCount(int index, string leaderboardId, int versionId, Action<int> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGlobalLeaderboardEntryCountByVersion(leaderboardId, versionId, index);
            }, (RuyiNetGetGlobalLeaderboardEntryCountResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(response.data.entryCount);
                    }
                    else
                    {
                        Logger.Log("GetGlobalLeaderboardEntryCount failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(0);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves paginated data from a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="sort">How to sort the data.</param>
        /// <param name="startIndex">The first entry to retrieve.</param>
        /// <param name="endIndex">The last entry to retrieve.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGlobalLeaderboardPage(int index, string leaderboardId, SortOrder sort, int startIndex, int endIndex, Action<RuyiNetLeaderboardPage> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGlobalLeaderboardPage(leaderboardId, sort, startIndex, endIndex, index);
            }, (RuyiNetGetGlobalLeaderboardPageResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardPage(response.data));
                    }
                    else
                    {
                        Logger.Log("GetGLobalLeaderboardPage failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves paginated data from a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="sort">How to sort the data.</param>
        /// <param name="startIndex">The first entry to retrieve.</param>
        /// <param name="endIndex">The last entry to retrieve.</param>
        /// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGlobalLeaderboardPage(int index, string leaderboardId, SortOrder sort, int startIndex, int endIndex, int versionId, Action<RuyiNetLeaderboardPage> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGlobalLeaderboardPageByVersion(leaderboardId, sort, startIndex, endIndex, versionId, index);
            }, (RuyiNetGetGlobalLeaderboardPageResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardPage(response.data));
                    }
                    else
                    {
                        Logger.Log("GetGLobalLeaderboardPage failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves a list of versions available for a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGlobalLeaderVersions(int index, string leaderboardId, Action<RuyiNetLeaderboardInfo> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGlobalLeaderboardVersions(leaderboardId, index);
            }, (RuyiNetGetGlobalLeaderboardVersionsResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardInfo(response.data));
                    }
                    else
                    {
                        Logger.Log("GetGLobalLeaderboardVersions failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves data from a leaderboard centered around the current player.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="sort">How to sort the data.</param>
        /// <param name="beforeCount">How many entries before the current player to retrieve.</param>
        /// <param name="afterCount">How many entries after the current player to retrieve.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGlobalLeaderboardView(int index, string leaderboardId, SortOrder sort, int beforeCount, int afterCount, Action<RuyiNetLeaderboardPage> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGlobalLeaderboardView(leaderboardId, sort, beforeCount, afterCount, index);
            }, (RuyiNetGetGlobalLeaderboardPageResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardPage(response.data));
                    }
                    else
                    {
                        Logger.Log("GetGLobalLeaderboardView failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves data from a leaderboard centered around the current player.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="sort">How to sort the data.</param>
        /// <param name="beforeCount">How many entries before the current player to retrieve.</param>
        /// <param name="afterCount">How many entries after the current player to retrieve.</param>
        /// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGlobalLeaderboardView(int index, string leaderboardId, SortOrder sort, int beforeCount, int afterCount, int versionId, Action<RuyiNetLeaderboardPage> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGlobalLeaderboardViewByVersion(leaderboardId, sort, beforeCount, afterCount, versionId, index);
            }, (RuyiNetGetGlobalLeaderboardPageResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardPage(response.data));
                    }
                    else
                    {
                        Logger.Log("GetGLobalLeaderboardView failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves a leaderboard with all the user's friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="groupId">The ID of the group to retrieve data for.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetGroupSocialLeaderboard(int index, string leaderboardId, string groupId, Action<RuyiNetLeaderboardPage> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetGroupSocialLeaderboard(leaderboardId, groupId, index);
            }, (RuyiNetGetGroupSocialLeaderboardResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardPage(response.data));
                    }
                    else
                    {
                        Logger.Log("GetGroupSocialLeaderboard failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves the player's score for a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetPlayerScore(int index, string leaderboardId, Action<RuyiNetPlayerScore> callback)
        {
            GetPlayerScore(index, leaderboardId, -1, callback);
        }

        /// <summary>
        /// Retrieves the player's score for a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="versionId">The version of the leaderboard to retrieve data for.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetPlayerScore(int index, string leaderboardId, int versionId, Action<RuyiNetPlayerScore> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetPlayerScore(leaderboardId, versionId, index);
            }, (RuyiNetGetPlayerScoreResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetPlayerScore(response.data.score));
                    }
                    else
                    {
                        Logger.Log("GetPlayerScore failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves the current player's scores from multiple leaderboards.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardIds">A list of leaderboard's IDs to retrieve data from.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetPlayerScoresFromLeaderboards(int index, List<string> leaderboardIds, Action<RuyiNetPlayerScore[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetPlayerScoresFromLeaderboards(leaderboardIds, index);
            }, (RuyiNetGetPlayerScoresFromLeaderboardsResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        List<RuyiNetPlayerScore> results = new List<RuyiNetPlayerScore>();
                        foreach (var i in response.data.scores)
                        {
                            results.Add(new RuyiNetPlayerScore(i));
                        }

                        callback(results.ToArray());
                    }
                    else
                    {
                        Logger.Log("GetPlayerScoresFromLeaderboards failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves a leaderboard for all the specified users.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="playerIds">The IDs of the players to retrieve data for.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetPlayersSocialLeaderboard(int index, string leaderboardId, List<string> playerIds, Action<RuyiNetLeaderboardPage> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetPlayersSocialLeaderboard(leaderboardId, playerIds, index);
            }, (RuyiNetGetGroupSocialLeaderboardResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardPage(response.data));
                    }
                    else
                    {
                        Logger.Log("GetPlayersSocialLeaderboard failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Retrieves a leaderboard for all the users friends.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to retrieve.</param>
        /// <param name="replaceName">If this is true the current player’s name will be replaced with “You”.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void GetSocialLeaderboard(int index, string leaderboardId, bool replaceName, Action<RuyiNetLeaderboardPage> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_GetSocialLeaderboard(leaderboardId, replaceName, index);
            }, (RuyiNetGetSocialLeaderboardResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(new RuyiNetLeaderboardPage(response.data));
                    }
                    else
                    {
                        Logger.Log("GetPlayersSocialLeaderboard failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Returns a list of all leaderboard configurations for a game.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void ListAllLeaderboards(int index, Action<RuyiNetLeaderboardConfig[]> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_ListLeaderboards(index);
            }, (RuyiNetListAllLeaderboardsResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        List<RuyiNetLeaderboardConfig> results = new List<RuyiNetLeaderboardConfig>();
                        foreach (var i in response.data.leaderboardList)
                        {
                            results.Add(new RuyiNetLeaderboardConfig(i));
                        }

                        callback(results.ToArray());
                    }
                    else
                    {
                        Logger.Log("ListAllLeaderboards failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(null);
                    }
                }
            });
        }

        /// <summary>
        /// Adds a score to a leaderboard that will be dynamically created if it doesn't exist.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="score">The score to post</param>
        /// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
        /// <param name="leaderboardType">The type of leaderboard to create.</param>
        /// <param name="rotationType">The rotation type of the leaderboard to create.</param>
        /// <param name="rotationReset">The time the leaderboard will reset.</param>
        /// <param name="retainedCount">How many versions of the leaderboard to retain.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void PostScoreToDynamicLeaderboard(int index, int score, string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount, Action<bool> callback)
        {
            PostScoreToDynamicLeaderboard(index, score, leaderboardId, leaderboardType, rotationType, rotationReset, retainedCount, "", callback);
        }

        /// <summary>
        /// Adds a score to a leaderboard that will be dynamically created if it doesn't exist.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="score">The score to post</param>
        /// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
        /// <param name="leaderboardType">The type of leaderboard to create.</param>
        /// <param name="rotationType">The rotation type of the leaderboard to create.</param>
        /// <param name="rotationReset">The time the leaderboard will reset.</param>
        /// <param name="retainedCount">How many versions of the leaderboard to retain.</param>
        /// <param name="data">Custom data for the developer to use.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void PostScoreToDynamicLeaderboard(int index, int score, string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount, string data, Action<bool> callback)
        {
            EnqueueTask(() =>
            {
                var bcLeaderboardType = (SocialLeaderboardType)leaderboardType;
                var bcRotationType = (RotationType)rotationType;
                return mClient.BCService.SocialLeaderboard_PostScoreToDynamicLeaderboard(leaderboardId, score, data, bcLeaderboardType, bcRotationType, rotationReset, retainedCount, index);
            }, (RuyiNetResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(true);
                    }
                    else
                    {
                        Logger.Log("PostScoreToDynamicLeaderboard failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(false);
                    }
                }
            });
        }

        /// <summary>
        /// Adds a score to a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="score">The score to post</param>
        /// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void PostScoreToLeaderboard(int index, int score, string leaderboardId, Action<bool> callback)
        {
            PostScoreToLeaderboard(index, score, leaderboardId, "", callback);
        }

        /// <summary>
        /// Adds a score to a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="score">The score to post</param>
        /// <param name="leaderboardId">The ID of the leaderboard to post to.</param>
        /// <param name="data">Custom data for the developer to use.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void PostScoreToLeaderboard(int index, int score, string leaderboardId, string data, Action<bool> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_PostScoreToLeaderboard(leaderboardId, score, data, index);
            }, (RuyiNetResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(true);
                    }
                    else
                    {
                        Logger.Log("PostScoreToLeaderboard failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(false);
                    }
                }
            });
        }

        /// <summary>
        /// Removes a score from a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to remove the score from.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void RemoveScore(int index, string leaderboardId, Action<bool> callback)
        {
            RemoveScore(index, leaderboardId, -1, callback);
        }

        /// <summary>
        /// Removes a score from a leaderboard.
        /// </summary>
        /// <param name="index">The index of user</param>
        /// <param name="leaderboardId">The ID of the leaderboard to remove the score from.</param>
        /// <param name="versionId">The version of the leaderboard to remove the score from.</param>
        /// <param name="callback">The function to call when the data is retrieved.</param>
        public void RemoveScore(int index, string leaderboardId, int versionId, Action<bool> callback)
        {
            EnqueueTask(() =>
            {
                return mClient.BCService.SocialLeaderboard_RemovePlayerScore(leaderboardId, versionId, index);
            }, (RuyiNetResponse response) =>
            {
                if (callback != null)
                {
                    if (response.status == RuyiNetHttpStatus.OK)
                    {
                        callback(true);
                    }
                    else
                    {
                        Logger.Log("RemoveScore failed with error code " + response.status, LogLevel.Error, MessageCategory.RuyiNet);
                        callback(false);
                    }
                }
            });
        }
    }
}
