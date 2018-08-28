using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents entity data that comes from a response.
    /// </summary>
    [Serializable]
    public class RuyiNetEntityData
    {
        /// <summary>
        /// ID of the entity.
        /// </summary>
        public string entityId;

        /// <summary>
        /// The type of the entity.
        /// </summary>
        public string entityType;

        /// <summary>
        /// What version of the entity this is.
        /// </summary>
        public int version;

        /// <summary>
        /// The custom data attached to this entity.
        /// </summary>
        public Dictionary<string, object> data;

        /// <summary>
        /// When this entity was created.
        /// </summary>
        public long createdAt;

        /// <summary>
        /// When this entity was last updated.
        /// </summary>
        public long updatedAt;
    }
}
