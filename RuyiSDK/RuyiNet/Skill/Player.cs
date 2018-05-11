namespace Ruyi.SDK.Online
{
    /// <summary>
    /// Represents a single player.
    /// </summary>
    /// <typeparam name="T">The type to use as a player ID.</typeparam>
    public class Player<T> : ISupportPartialPlay, ISupportPartialUpdate
    {
        /// <summary>
        /// Construct a player.
        /// </summary>
        /// <param name="id">The ID of the player.</param>
        public Player(T id)
            : this(id, DefaultPartialPlayPercentage, DefaultPartialUpdatePercentage)
        {
        }

        /// <summary>
        /// Construct a player with a partial play.
        /// </summary>
        /// <param name="id">The ID of the player.</param>
        /// <param name="partialPlayPercentage">The player's partial play percentage.</param>
        public Player(T id, double partialPlayPercentage)
            : this(id, partialPlayPercentage, DefaultPartialUpdatePercentage)
        {
        }

        /// <summary>
        /// Construct a player with a partial play and partial update.
        /// </summary>
        /// <param name="id">The ID of the player.</param>
        /// <param name="partialPlayPercentage">The player's partial play percentage.</param>
        /// <param name="partialUpdatePercentage">The player's partial update percentage.</param>
        public Player(T id, double partialPlayPercentage, double partialUpdatePercentage)
        {
            Guard.ArgumentInRangeInclusive(partialPlayPercentage, 0, 1.0, "partialPlayPercentage");
            Guard.ArgumentInRangeInclusive(partialUpdatePercentage, 0, 1.0, "partialUpdatePercentage");

            mId = id;
            mPartialPlayPercentage = partialPlayPercentage;
            mPartialUpdatePercentage = partialUpdatePercentage;
        }

        /// <summary>
        /// The ID of the player.
        /// </summary>
        public T Id { get { return mId; } }

        /// <summary>
        /// The player's partial play percentage.
        /// </summary>
        public double PartialPlayPercentage { get { return mPartialPlayPercentage; } }

        /// <summary>
        /// The player's partial update percentage.
        /// </summary>
        public double PartialUpdatePercentage { get { return mPartialUpdatePercentage; } }

        /// <summary>
        /// Convert the player to a string.
        /// </summary>
        /// <returns>A string representation of the player.</returns>
        public override string ToString()
        {
            if (Id != null)
            {
                return Id.ToString();
            }

            return base.ToString();
        }

        private const double DefaultPartialPlayPercentage = 1.0;
        private const double DefaultPartialUpdatePercentage = 1.0;
        private readonly T mId;
        private readonly double mPartialPlayPercentage;
        private readonly double mPartialUpdatePercentage;
    }

    /// <summary>
    /// A generic player class.
    /// </summary>
    public class Player : Player<object>
    {
        /// <summary>
        /// Construct a player.
        /// </summary>
        /// <param name="id">The ID of the player.</param>
        public Player(object id)
            : base(id)
        {
        }
        /// <summary>
        /// Construct a player with a partial play.
        /// </summary>
        /// <param name="id">The ID of the player.</param>
        /// <param name="partialPlayPercentage">The player's partial play percentage.</param>
        public Player(object id, double partialPlayPercentage)
            : base(id, partialPlayPercentage)
        {
        }
        /// <summary>
        /// Construct a player with a partial play and partial update.
        /// </summary>
        /// <param name="id">The ID of the player.</param>
        /// <param name="partialPlayPercentage">The player's partial play percentage.</param>
        /// <param name="partialUpdatePercentage">The player's partial update percentage.</param>
        public Player(object id, double partialPlayPercentage, double partialUpdatePercentage)
            : base(id, partialPlayPercentage, partialUpdatePercentage)
        {
        }
    }
}
