using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Response from making a call to brainCloud.
    /// </summary>
    public class RuyiNetGetGameManifestResponse
    {
        /// <summary>
        /// Response data.
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The Game ID this manifest represents.
            /// </summary>
            public string gameId;

            /// <summary>
            /// The latest version of the game.
            /// </summary>
            public string latestVersion;

            /// <summary>
            /// Represents a game patch.
            /// </summary>
            [Serializable]
            public class Patch
            {
                /// <summary>
                /// Which version this patch can be applied to.
                /// </summary>
                public string fromVersion;

                /// <summary>
                /// The version of the game after the patch is applied.
                /// </summary>
                public string toVersion;

                /// <summary>
                /// Location of the release notes for this patch.
                /// </summary>
                public string releaseNotesLocation;

                /// <summary>
                /// Location of the patch file.
                /// </summary>
                public string patchLocation;

                /// <summary>
                /// MD5 hash of the patch file.
                /// </summary>
                public string patchMd5;
            }

            /// <summary>
            /// A list of patches for this game.
            /// </summary>
            public Patch[] patchInfo;
        }

        /// <summary>
        /// The patch data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The status of the response.
        /// </summary>
        public int status;
    }
}
