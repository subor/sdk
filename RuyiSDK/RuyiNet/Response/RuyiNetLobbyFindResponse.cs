using System;

namespace Ruyi.SDK.Cloud
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
            /// The response
            /// </summary>
            public class Response
            {

                /// <summary>
                /// 
                /// </summary>
                public string context;

                /// <summary>
                /// The results from the response.
                /// </summary>
                public class Results
                {
                    /// <summary>
                    /// The number of groups found.
                    /// </summary>
                    public int count;

                    /// <summary>
                    /// The page this list represents.
                    /// </summary>
                    public int page;
                    
                    /// <summary>
                    /// The array of groups found.
                    /// </summary>
                    public RuyiNetResponseGroup[] items;

                    /// <summary>
                    /// Whether or not there are more groups in later pages.
                    /// </summary>
                    public bool moreAfter;

                    /// <summary>
                    /// Whether or not there are more groups in earlier pages.
                    /// </summary>
                    public bool moreBefore;
                }
                
                /// <summary>
                /// The results.
                /// </summary>
                public Results results;
            }

            /// <summary>
            /// The response.
            /// </summary>
            public Response response;

            /// <summary>
            /// Whether or not the server-side script was successful.
            /// </summary>
            public bool success;
        }

        /// <summary>
        /// The data.
        /// </summary>
        public Data data;

        /// <summary>
        /// The response status.
        /// </summary>
        public int status;
    }
}
