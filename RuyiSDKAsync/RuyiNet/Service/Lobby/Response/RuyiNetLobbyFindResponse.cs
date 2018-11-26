using System;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// The response recieved on finding a lobby.
    /// </summary>
    [Serializable]
    public class RuyiNetLobbyFindResponse
    {
        /// <summary>
        /// The data
        /// </summary>
        [Serializable]
        public class Data
        {
            /// <summary>
            /// The list of returned lobbies.
            /// </summary>
            public RuyiNetLobbyResponseData[] lobbies;
            
        }

        /// <summary>
        /// The data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The response status.
        /// </summary>
        public int status;

        /// <summary>
        /// Creates array of <see cref="RuyiNetLobby"/> from response <see cref="data"/>
        /// </summary>
        public RuyiNetLobby[] GetLobbies()
        {
            if (data == null || data.lobbies == null)
                return null;
            var results = data.lobbies;
            var lobbies = new RuyiNetLobby[results.Length];
            for (int i = 0; i < results.Length; ++i)
            {
                lobbies[i] = new RuyiNetLobby(results[i]);
            }
            return lobbies;
        }
    }
}
