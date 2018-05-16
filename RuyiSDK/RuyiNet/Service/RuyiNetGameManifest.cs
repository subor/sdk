namespace Ruyi.SDK.Online
{
    /// <summary>
    /// A Game Manifest that includes patch information.
    /// </summary>
    public class RuyiNetGameManifest
    {
        /// <summary>
        /// Implicit conversion from JSON response class.
        /// </summary>
        /// <param name="other"></param>
        public static implicit operator RuyiNetGameManifest(RuyiNetGetGameManifestResponse other)
        {
            return new RuyiNetGameManifest(other);
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="response">The response class to convert from.</param>
        public RuyiNetGameManifest(RuyiNetGetGameManifestResponse response)
        {
            Status = response.status;

            if (Status == RuyiNetHttpStatus.OK &&
                response.data != null)
            {
                GameId = response.data.gameId;
                LatestVersion = response.data.latestVersion;

                PatchInfo = new Patch[response.data.patchInfo.Length];
                for (int i = 0; i < PatchInfo.Length; ++i)
                {
					PatchInfo[i] = new Patch();
                    PatchInfo[i].FromVersion = response.data.patchInfo[i].fromVersion;
                    PatchInfo[i].ToVersion = response.data.patchInfo[i].toVersion;
                    PatchInfo[i].ReleaseNotesLocation = response.data.patchInfo[i].releaseNotesLocation;
                    PatchInfo[i].PatchLocation = response.data.patchInfo[i].patchLocation;
                    PatchInfo[i].PatchMd5 = response.data.patchInfo[i].patchMd5;
                }
            }
        }

        /// <summary>
        /// The Game ID this manifest represents.
        /// </summary>
        public string GameId { get; private set; }

        /// <summary>
        /// The latest version of the game.
        /// </summary>
        public string LatestVersion { get; private set; }

        /// <summary>
        /// Represents a game patch.
        /// </summary>
        public class Patch
        {
            /// <summary>
            /// Which version this patch can be applied to.
            /// </summary>
            public string FromVersion { get; set; }

            /// <summary>
            /// The version of the game after the patch is applied.
            /// </summary>
            public string ToVersion { get; set; }

            /// <summary>
            /// Location of the release notes for this patch.
            /// </summary>
            public string ReleaseNotesLocation { get; set; }

            /// <summary>
            /// Location of the patch file.
            /// </summary>
            public string PatchLocation { get; set; }

            /// <summary>
            /// MD5 hash of the patch file.
            /// </summary>
            public string PatchMd5 { get; set; }
        }

        /// <summary>
        /// A list of patches for this game.
        /// </summary>
        public Patch[] PatchInfo { get; private set; }

        /// <summary>
        /// The status of the response data (compare to RuyiNetHttpStatus.OK).
        /// </summary>
        public int Status { get; private set; }
    }
}
