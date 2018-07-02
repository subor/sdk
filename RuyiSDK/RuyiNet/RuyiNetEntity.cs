using System.Collections.Generic;

namespace Ruyi.SDK.RuyiNet
{
    /// <summary>
    /// Represents an entity
    /// </summary>
    public class RuyiNetEntity
    {
        /// <summary>
        /// The ID of the entity.
        /// </summary>
        public string EntityId { get; private set; }

        /// <summary>
        /// The type of the entity.
        /// </summary>
        public string EntityType { get; private set; }

        /// <summary>
        /// The version of the entity.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// When this entity was created.
        /// </summary>
        public long CreatedAt { get; private set; }

        /// <summary>
        /// When this entity was last updated.
        /// </summary>
        public long UpdatedAt { get; private set; }

        /// <summary>
        /// The custom data attached to this entity.
        /// </summary>
        public Dictionary<string, object> Data { get; private set; }
    }
}
