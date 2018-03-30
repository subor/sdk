using NUnit.Framework;
using Ruyi;
using Ruyi.SDK.BrainCloudApi;
using System;
using System.Collections.Generic;

namespace UnitTests.RuyiNet
{
    [TestFixture]
    class RuyiNetTest
    {
        const string TEST_APP_ID = "30005";
        const string TEST_APP_SECRET = "9918d6c0-88e0-449c-bf27-b5dfbc6a59cd";
        const string TEST_LEADERBOARD_ID = "testCreate";

        public static string[] PLAYER_IDS =
        {
            "1faacff3-5284-4511-9779-461becbaf957",
            "afebe314-ebfd-419c-b182-7a7ad55aa03d",
            "94d2a811-5c4d-452f-8c87-25d9cb283bf5",
        };

        [Test]
        public void RuyiNetTest_Initialise()
        {
            CreateRuyiSDK();

            //  Check RuyiNet is available.
            Assert.IsTrue(IsRuyiNetAvailable);

            //  Check services initialised okay.
            Assert.NotNull(mSDK.RuyiNetService.CloudService);
            Assert.NotNull(mSDK.RuyiNetService.FriendService);
            Assert.NotNull(mSDK.RuyiNetService.LeaderboardService);
            Assert.NotNull(mSDK.RuyiNetService.LobbyService);
            Assert.NotNull(mSDK.RuyiNetService.PartyService);
            Assert.NotNull(mSDK.RuyiNetService.ProfileService);
            Assert.NotNull(mSDK.RuyiNetService.TelemetryService);

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, DisposeRuyiSDK);
        }

        [Test]
        public void RuyiNetTest_CloudBackupData()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                mSDK.RuyiNetService.CloudService.BackupData(0, CheckResponseStatus);
            });
        }

        [Test]
        public void RuyiNetTest_CloudRestoreData()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                mSDK.RuyiNetService.CloudService.RestoreData(0, CheckResponseStatus);
            });
        }

        [Test]
        public void RuyiNetTest_Friend()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                mSDK.RuyiNetService.FriendService.AddFriend(0, PLAYER_IDS[0],
                    (RuyiNetResponse response) =>
                {
                    Assert.IsTrue(response.status == 200);

                    mSDK.RuyiNetService.FriendService.ListFriends(0,
                        (RuyiNetListFriendsResponse listFriendsResponse) =>
                    {
                        Assert.IsTrue(listFriendsResponse.status == 200);
                        Assert.IsTrue(listFriendsResponse.data.success);

                        var friendList = listFriendsResponse.data.response.friends;

                        Assert.IsTrue(friendList.Length >= 1);

                        var i = Array.FindIndex(friendList, (x) => (x.playerId == PLAYER_IDS[0]));

                        Assert.IsTrue(i >= 0);

                        mSDK.RuyiNetService.FriendService.RemoveFriend(0, PLAYER_IDS[0],
                            (RuyiNetResponse removeFriendResponse) =>
                        {

                            Assert.IsTrue(removeFriendResponse.status == 200);

                            mSDK.RuyiNetService.FriendService.ListFriends(0,
                                (RuyiNetListFriendsResponse listRemovedFriendsResponse) =>
                            {
                                Assert.IsTrue(listRemovedFriendsResponse.status == 200);
                                Assert.IsTrue(listRemovedFriendsResponse.data.success);

                                friendList = listRemovedFriendsResponse.data.response.friends;

                                i = Array.FindIndex(friendList, (x) => (x.playerId == PLAYER_IDS[0]));

                                Assert.IsTrue(i < 0);

                                DisposeRuyiSDK();
                            });
                        });
                    });
                });
            });
        }

        [Test]
        public void RuyiNetTest_GetProfile()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                mSDK.RuyiNetService.FriendService.GetProfile(0, PLAYER_IDS[0],
                    (RuyiNetGetProfileResponse getProfileResponse) =>
                {
                    Assert.IsTrue(getProfileResponse.status == 200);
                    Assert.IsTrue(getProfileResponse.data.success);
                    Assert.IsTrue(getProfileResponse.data.response.profileId == PLAYER_IDS[0]);

                    mSDK.RuyiNetService.FriendService.GetProfiles(0, PLAYER_IDS,
                        (RuyiNetGetProfilesResponse getProfilesResponse) =>
                    {
                        Assert.IsTrue(getProfileResponse.status == 200);
                        Assert.IsTrue(getProfileResponse.data.success);

                        var profileList = getProfilesResponse.data.response;

                        var i = Array.FindIndex(profileList, (x) => (x.profileId == PLAYER_IDS[0]));
                        Assert.IsTrue(i >= 0);

                        i = Array.FindIndex(profileList, (x) => (x.profileId == PLAYER_IDS[1]));
                        Assert.IsTrue(i >= 0);

                        i = Array.FindIndex(profileList, (x) => (x.profileId == PLAYER_IDS[2]));
                        Assert.IsTrue(i >= 0);
                    });
                });
            });
        }

        [Test]
        public void RuyiNetTest_Leaderboard()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                var leaderboardService = mSDK.RuyiNetService.LeaderboardService;
                leaderboardService.PostScoreToLeaderboard(0, TEST_LEADERBOARD_ID, 100,
                    (RuyiNetResponse postScoreResponse) =>
                {
                    Assert.IsTrue(postScoreResponse.status == 200);

                    leaderboardService.GetGLobalLeaderboardPage(0, TEST_LEADERBOARD_ID, SortOrder.HIGH_TO_LOW, 0, 10,
                        (RuyiNetLeaderboardResponse getPageResponse) =>
                    {
                        Assert.IsTrue(getPageResponse.status == 200);
                        Assert.IsTrue(getPageResponse.data.success);

                        var leaderboard = getPageResponse.data.response;

                        Assert.IsTrue(leaderboard.leaderboard.Length > 0);
                        Assert.IsTrue(leaderboard.leaderboard.Length <= 10);

                        leaderboardService.GetGlobalLeaderboardView(0, TEST_LEADERBOARD_ID, SortOrder.HIGH_TO_LOW, 5, 5,
                            (RuyiNetLeaderboardResponse getViewResponse) =>
                        {
                            Assert.IsTrue(getViewResponse.status == 200);
                            Assert.IsTrue(getViewResponse.data.success);

                            leaderboard = getViewResponse.data.response;

                            Assert.IsTrue(leaderboard.leaderboard.Length > 0);
                            Assert.IsTrue(leaderboard.leaderboard.Length <= 10);

                            leaderboardService.GetSocialLeaderboard(0, TEST_LEADERBOARD_ID, true,
                                (RuyiNetSocialLeaderboardResponse getSocialResponse) =>
                            {
                                Assert.IsTrue(getSocialResponse.status == 200);
                                Assert.IsTrue(getSocialResponse.data.success);

                                var socialLeaderboard = getSocialResponse.data.response.social_leaderboard;

                                Assert.IsTrue(socialLeaderboard.Length > 0);
                                Assert.IsTrue(socialLeaderboard.Length <= 10);
                            });
                        });
                    });
                });
            });
        }

        [Test]
        public void RuyiNetTest_Lobby()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                var lobbyService = mSDK.RuyiNetService.LobbyService;
                lobbyService.CreateLobby(0, 4, RuyiNetLobbyType.PLAYER,
                    (RuyiNetLobby createLobbyResponse) =>
                {
                    Assert.IsTrue(createLobbyResponse.FreeSlots == 3);
                    Assert.IsTrue(createLobbyResponse.LobbyType == RuyiNetLobbyType.PLAYER);
                    Assert.IsTrue(createLobbyResponse.MaxSlots == 4);
                    Assert.IsTrue(createLobbyResponse.MemberCount == 1);
                    Assert.IsTrue(createLobbyResponse.Members.Length == 1);

                    lobbyService.StartGame(0, createLobbyResponse.LobbyId, createLobbyResponse.ConnectionString,
                        (RuyiNetResponse startGameResponse) =>
                    {
                        Assert.IsTrue(startGameResponse.status == 200);

                        lobbyService.LeaveLobby(0, createLobbyResponse.LobbyId,
                        (RuyiNetResponse leaveLobbyResponse) =>
                        {
                            Assert.IsTrue(leaveLobbyResponse.status == 200);
                        });
                    });
                });
            });
        }

        [Test]
        public void RuyiNetTest_Party()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                var partyService = mSDK.RuyiNetService.PartyService;
                partyService.SendPartyInvitation(0, PLAYER_IDS[0],
                    (RuyiNetResponse sendResponse) =>
                {
                    Assert.IsTrue(sendResponse.status == 200);
                    partyService.GetPartyInfo(0, (RuyiNetGetPartyInfoResponse getPartyResponse) =>
                    {
                        Assert.IsTrue(getPartyResponse.status == 200);
                        Assert.IsTrue(getPartyResponse.data.success);

                        var groups = getPartyResponse.data.response.groups;

                        Assert.IsTrue(groups.Length >= 1);
                        partyService.GetPartyMembersInfo(0, (RuyiNetGetProfilesResponse getMembersResponse) =>
                        {
                            Assert.IsTrue(getMembersResponse.status == 200);
                            Assert.IsTrue(getMembersResponse.data.success);

                            var members = getMembersResponse.data.response;

                            Assert.IsTrue(members.Length >= 0);

                            var playerId = mSDK.RuyiNetService.ActivePlayer.profileId;

                            var i = Array.FindIndex(members, (x) => (x.profileId == playerId));
                            Assert.IsTrue(i >= 0);

                            partyService.LeaveParty(0, groups[0].groupId, (RuyiNetResponse leaveResponse) =>
                            {
                                Assert.IsTrue(leaveResponse.status == 200);
                            });
                        });
                    });
                });
            });
        }

        public void RuyNetTest_Telemetry()
        {
            CreateRuyiSDK();

            mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
            {
                var telemetryService = mSDK.RuyiNetService.TelemetryService;
                telemetryService.StartTelemetrySession(0, (RuyiNetTelemetrySession session) =>
                {
                    Assert.IsNotNull(session);

                    var customData = new Dictionary<string, string>();
                    customData["position"] = "[10, 10]";
                    telemetryService.LogTelemetryEvent(0, session.Id, "ATTACK", customData, (RuyiNetResponse logEventResponse) =>
                    {
                        Assert.IsTrue(logEventResponse.status == 200);

                        telemetryService.EndTelemetrySession(0, session.Id, (RuyiNetResponse endSessionResponse) =>
                        {
                            Assert.IsTrue(endSessionResponse.status == 200);
                        });
                    });
                });
            });
        }

        private bool IsRuyiNetAvailable
        {
            get
            {
                return mSDK != null && mSDK.RuyiNetService != null;
            }
        }

        private void CreateRuyiSDK()
        {
            if (mSDK == null)
            {
                mSDKContext = new RuyiSDKContext()
                {
                    endpoint = RuyiSDKContext.Endpoint.Console
                };

                mSDK = RuyiSDK.CreateInstance(mSDKContext);
            }
        }

        private void DisposeRuyiSDK()
        {
            mSDK.Dispose();
        }

        private void CheckResponseStatus(RuyiNetResponse response)
        {
            Assert.IsTrue(response.status == 200);

            DisposeRuyiSDK();
        }

        private RuyiSDK mSDK;
        private RuyiSDKContext mSDKContext;
    }
}
