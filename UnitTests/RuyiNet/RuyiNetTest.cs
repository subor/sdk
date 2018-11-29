using NUnit.Framework;
using Ruyi.SDK.BrainCloudApi;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ruyi.SDK.Online.Tests
{
    [TestFixture, Timeout(120000)]
    class RuyiNetTest
    {
        const string TEST_APP_ID = "30005";
        const string TEST_APP_SECRET = "9918d6c0-88e0-449c-bf27-b5dfbc6a59cd";
        const string TEST_LEADERBOARD_ID = "testCreate";

        static string[] PLAYER_IDS =
        {
            "bfdcafbf-b15d-4c01-93b0-b363b310ef80"
        };

        [SetUp]
        public void CreateRuyiSDK()
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

        [TearDown]
        public void DisposeRuyiSDK()
        {
            mSDK.Dispose();
        }

        [Test]
        public async Task RuyiNetTest_Initialise()
        {
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

            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);
        }

        [Test]
        public async Task RuyiNetTest_CloudBackupData()
        {
            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);
            var response = await mSDK.RuyiNetService.CloudService.BackupData(0);
            CheckResponseStatus(response.status);
        }

        [Test]
        public async Task RuyiNetTest_CloudRestoreData()
        {
            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);
            await mSDK.RuyiNetService.CloudService.RestoreData(0, async (RuyiNetResponse response) => { CheckResponseStatus(response.status); });
        }

        [Test]
        public async Task RuyiNetTest_Friend()
        {
            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);
            var response = await mSDK.RuyiNetService.FriendService.AddFriend(0, PLAYER_IDS[0]);
            CheckResponseStatus(response.status);

            var friendsResponse = await mSDK.RuyiNetService.FriendService.ListFriends(0);
            var friends = friendsResponse.GetFriendSummaryData();
            Assert.GreaterOrEqual(friends.Length, 1);

            var i = Array.FindIndex(friends, (x) => (x.PlayerId == PLAYER_IDS[0]));

            Assert.GreaterOrEqual(i, 0);

            var removeFriendResponse = await mSDK.RuyiNetService.FriendService.RemoveFriend(0, PLAYER_IDS[0]);
            CheckResponseStatus(removeFriendResponse.status);

            friendsResponse = await mSDK.RuyiNetService.FriendService.ListFriends(0);
            var friends2 = friendsResponse.GetFriendSummaryData();
            i = Array.FindIndex(friends2, (x) => (x.PlayerId == PLAYER_IDS[0]));
            Assert.IsTrue(i < 0);
        }

        [Test]
        public async Task RuyiNetTest_GetProfile()
        {
            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);

            var getProfileResponse = await mSDK.RuyiNetService.FriendService.GetProfile(0, PLAYER_IDS[0]);
            CheckResponseStatus(getProfileResponse.status);
            Assert.IsTrue(getProfileResponse.data.success);
            Assert.IsTrue(getProfileResponse.data.response.profileId == PLAYER_IDS[0]);

            var getProfilesResponse = await mSDK.RuyiNetService.FriendService.GetProfiles(0, PLAYER_IDS);
            CheckResponseStatus(getProfileResponse.status);
            Assert.IsTrue(getProfileResponse.data.success);

            var profileList = getProfilesResponse.data.response;

            foreach (var playerId in PLAYER_IDS)
            {
                var i = Array.FindIndex(profileList, (x) => (x.profileId == playerId));
                Assert.GreaterOrEqual(i, 0);
            }
        }

        [Test]
        public async Task RuyiNetTest_Leaderboard()
        {
            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);
            var leaderboardService = mSDK.RuyiNetService.LeaderboardService;
            var result = await leaderboardService.PostScoreToLeaderboard(0, TEST_LEADERBOARD_ID, 100);
            Assert.IsTrue(result.status == 200);

            var response = await leaderboardService.GetGLobalLeaderboardPage(0, TEST_LEADERBOARD_ID, SortOrder.HIGH_TO_LOW, 0, 10);
            var page = response.data.response.leaderboard;
            Assert.IsNotNull(page);

            Assert.Greater(page.Length, 0);
            Assert.LessOrEqual(page.Length, 10);

            var globalResponse = await leaderboardService.GetGlobalLeaderboardView(0, TEST_LEADERBOARD_ID, SortOrder.HIGH_TO_LOW, 5, 5);
            var view = globalResponse.data.response.leaderboard;
            Assert.IsNotNull(view);

            Assert.Greater(view.Length, 0);
            Assert.LessOrEqual(view.Length, 10);

            var socialResponse = await leaderboardService.GetSocialLeaderboard(0, TEST_LEADERBOARD_ID, true);
            var socialLeaderboard = socialResponse.data.response.social_leaderboard;
            Assert.IsNotNull(socialLeaderboard);

            Assert.Greater(socialLeaderboard.Length, 0);
            Assert.LessOrEqual(socialLeaderboard.Length, 10);
        }

        [Test]
        public void RuyiNetTest_Lobby()
        {
            /*mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET, () =>
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
                        CheckResponseStatus(startGameResponse.status);

                        lobbyService.LeaveLobby(0, createLobbyResponse.LobbyId,
                        (RuyiNetResponse leaveLobbyResponse) =>
                        {
                            CheckResponseStatus(leaveLobbyResponse.status);
                        });
                    });
                });
            });

            while (mSDK.RuyiNetService.IsWorking) { mSDK.Update(); }*/
        }

        [Test]
        public async Task RuyiNetTest_Party()
        {
            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);
            var partyService = mSDK.RuyiNetService.PartyService;
            var response = await partyService.SendPartyInvitation(0, PLAYER_IDS[0]);
            var party = response.data.party;
            var info = await partyService.GetPartyInfo(0, party.partyId);
            await partyService.LeaveParty(0, info.data.party.partyId);
        }

        [Test]
        public async Task RuyNetTest_Telemetry()
        {
            await mSDK.RuyiNetService.Initialise(TEST_APP_ID, TEST_APP_SECRET);
            var telemetryService = mSDK.RuyiNetService.TelemetryService;
            var session = await telemetryService.StartTelemetrySession(0);
            Assert.IsNotNull(session);

            var customData = new Dictionary<string, string>
            {
                ["position"] = "[10, 10]"
            };

            var logEventResponse = await telemetryService.LogTelemetryEvent(0, session.Id, "ATTACK", customData);
            CheckResponseStatus(logEventResponse.status);

            var endSessionResponse = await telemetryService.EndTelemetrySession(0, session.Id);
            CheckResponseStatus(endSessionResponse.status);
        }

        private bool IsRuyiNetAvailable
        {
            get
            {
                return mSDK != null && mSDK.RuyiNetService != null;
            }
        }

        private void CheckResponseStatus(int responseStatus, int expected = 200)
        {
            Assert.AreEqual(expected, responseStatus);
        }

        private RuyiSDK mSDK;
        private RuyiSDKContext mSDKContext;
    }
}
