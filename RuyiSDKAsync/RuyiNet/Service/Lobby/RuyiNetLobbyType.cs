namespace Ruyi.SDK.Online
{
    /// <summary>
    /// The type of the lobby: Ranked or Player match.
    /// </summary>
    public enum RuyiNetLobbyType
    {
        /// <summary>
        /// Ranked match - uses player ratings
        /// </summary>
        RANKED,

        /// <summary>
        /// Player match - play with anyone without affecting player ratings
        /// </summary>
        PLAYER
    }
}
