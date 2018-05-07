namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// Information on the current game.
    /// </summary>
    public class GameInfo
    {
        /// <summary>
        /// Construct a game info.
        /// </summary>
        /// <param name="initialMean">The initial mean of players' ratings.</param>
        /// <param name="initialStandardDeviation">The initial standard deviation of players' ratings.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="dynamicFactor">The dynamic factor.</param>
        /// <param name="drawProbability">The probability the game ends in a draw.</param>
        public GameInfo(double initialMean, double initialStandardDeviation,
            double beta, double dynamicFactor, double drawProbability)
        {
            InitialMean = initialMean;
            InitialStandardDeviation = initialStandardDeviation;
            Beta = beta;
            DynamicsFactor = dynamicFactor;
            DrawProbability = drawProbability;
        }

        /// <summary>
        /// Returns a default rating.
        /// </summary>
        public Rating DefaultRating
        {
            get { return new Rating(InitialMean, InitialStandardDeviation); }
        }

        /// <summary>
        /// Returns a default game info.
        /// </summary>
        public static GameInfo DefaultGameInfo
        {
            get
            {
                return new GameInfo(DefaultInitialMean, DefaultInitialStandardDeviation,
                    DefaultBeta, DefaultDynamicsFactor, DefaultDrawProbability);
            }
        }

        /// <summary>
        /// The inital mean of players' ratings.
        /// </summary>
        public double InitialMean { get; set; }

        /// <summary>
        /// The initial standard deviation of players' ratings.
        /// </summary>
        public double InitialStandardDeviation { get; set; }

        /// <summary>
        /// The beta.
        /// </summary>
        public double Beta { get; set; }

        /// <summary>
        /// The dynamics factor.
        /// </summary>
        public double DynamicsFactor { get; set; }

        /// <summary>
        /// The chance the match is a draw.
        /// </summary>
        public double DrawProbability { get; set; }

        private const double DefaultBeta = DefaultInitialMean / 6.0;
        private const double DefaultDrawProbability = 0.10;
        private const double DefaultDynamicsFactor = DefaultInitialMean / 300.0;
        private const double DefaultInitialMean = 25.0;
        private const double DefaultInitialStandardDeviation = DefaultInitialMean / 3.0;
    }
}
