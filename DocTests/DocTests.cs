using NUnit.Framework;
using System;
using System.Threading;

using Ruyi.SDK.Online;

namespace Ruyi.SDK.Tests
{
    /// <summary>
    /// These are examples used in the SDK documentation.  See devtools/SDKDocsBuilder/.
    /// </summary>
    [TestFixture, Timeout(10000)]
    [Parallelizable]
    public class DocTests
    {
        [Test]
        public void CreateRuyiSDK()
        {
            // Call update once
            bool isGameRunning = true;
            bool IsGameRunning()
            {
                var retval = isGameRunning;
                isGameRunning = false;
                return retval;
            }
            #region RuyiSDK
            var sdkCtx = new RuyiSDKContext { endpoint = RuyiSDKContext.Endpoint.Console, EnabledFeatures = RuyiSDK.SDKFeatures.All };
            using (var sdk = RuyiSDK.CreateInstance(sdkCtx))
            {
                while (IsGameRunning()) { sdk.Update(); }
            }
            #endregion
        }

        [Test]
        public void Storage()
        {
            #region Storage
            var sdkCtx = new RuyiSDKContext {
                endpoint = RuyiSDKContext.Endpoint.Console,
                EnabledFeatures = RuyiSDK.SDKFeatures.Basic | RuyiSDK.SDKFeatures.Storage // or `All`
            };
            using (var sdk = RuyiSDK.CreateInstance(sdkCtx))
            {
                // `AppId` in your RuyiManifest.json- same as app id you received from Subor Team or on the dev portal
                var appid = "18258";
                var writablePath = sdk.Storage.GetLocalPath(Ruyi.SDK.Constants.ConstantsSDKDataTypesConstants.DATA_DRIVER_TAG + appid);
                // Write files to writable path

                var readonlyPath = sdk.Storage.GetLocalPath(Ruyi.SDK.Constants.ConstantsSDKDataTypesConstants.HDD0_DRIVER_TAG + appid);
                // Read files from read-only path
            }
            #endregion
        }

        [Test]
        public void RuyiNetClient()
        {
            #region RuyiNetClient
            using (var ruyi = RuyiSDK.CreateInstance(new RuyiSDKContext { endpoint = RuyiSDKContext.Endpoint.Console }))
            {
                ruyi.RuyiNetService.Initialise(APP_ID, APP_SECRET, () =>
                {
                    foreach (var player in ruyi.RuyiNetService.CurrentPlayers)
                    {
                        if (player == null)
                            continue;
                        Console.WriteLine(player.profileName);
                    }
                });
                while (ruyi.RuyiNetService.IsWorking) { ruyi.Update(); }
            }
            #endregion
        }

        [Test]
        public void RuyiNet_Friends()
        {
            var FRIEND_PROFILE_ID = "";
            #region RuyiNet_Friends
            using (var ruyi = RuyiSDK.CreateInstance(new RuyiSDKContext { endpoint = RuyiSDKContext.Endpoint.Console }))
            {
                void printFriends(RuyiNetFriendSummaryData[] friends)
                {
                    if (friends == null)
                    {
                        Console.WriteLine("ListFriends() failed");
                        return;
                    }
                    foreach (var friend in friends)
                    {
                        Console.WriteLine(friend.Name);
                    }
                }

                ruyi.RuyiNetService.Initialise(APP_ID, APP_SECRET, () =>
                {
                    // Get friends BEFORE adding a friend
                    ruyi.RuyiNetService.FriendService.ListFriends(0,
                        (RuyiNetFriendSummaryData[] friendsBefore) =>
                        {
                            Console.WriteLine("Friends BEFORE:");
                            printFriends(friendsBefore);

                            // Add a friend
                            ruyi.RuyiNetService.FriendService.AddFriend(0, FRIEND_PROFILE_ID,
                                (RuyiNetResponse response) =>
                                {
                                    // Get friends AFTER adding a friend
                                    ruyi.RuyiNetService.FriendService.ListFriends(0,
                                        (RuyiNetFriendSummaryData[] friendsAfter) =>
                                        {
                                            Console.WriteLine("Friends After:");
                                            printFriends(friendsAfter);
                                        }
                                        );
                                });
                        });
                });

                while (ruyi.RuyiNetService.IsWorking) { ruyi.Update(); }
            }
            #endregion
        }

        [Test]
        public void Subscribe_Input()
        {
            #region Subscribe_Input
            var sdk = RuyiSDK.CreateInstance(new RuyiSDKContext { endpoint = RuyiSDKContext.Endpoint.Console, EnabledFeatures = RuyiSDK.SDKFeatures.Basic });
            sdk.Subscriber.Subscribe(Ruyi.Layer0.ServiceHelper.PubChannelID(Ruyi.Layer0.ServiceIDs.INPUTMANAGER_INTERNAL));
            sdk.Subscriber.AddMessageHandler<Ruyi.SDK.InputManager.RuyiGamePadInput>((topic, message) => {
                if ((message.ButtonFlags & (int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_A) != 0)
                {
                    // "A" pressed!
                }
            });
            #endregion
        }

        const string APP_ID = "12345";
        const string APP_SECRET = "1234abcd-cdef-cdef-0123-0123456789ab";
    }
}