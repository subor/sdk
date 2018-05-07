using System;
using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    /// <summary>
    /// The base class for all skill calculators.
    /// </summary>
    public abstract class SkillCalculator
    {
        /// <summary>
        /// The options that can be supported by the skill calculator.
        /// </summary>
        [Flags]
        public enum SupportedOptions
        {
            /// <summary>
            /// No options supported.
            /// </summary>
            None = 0x00,

            /// <summary>
            /// Partial play of match supported.
            /// </summary>
            PartialPlay = 0x01,

            /// <summary>
            /// Partial update of rating supported.
            /// </summary>
            PartialUpdate = 0x02
        }

        /// <summary>
        /// Calculates the new  ratings for players based on the results of a match.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to identify the player.</typeparam>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="teams">A list of teams and their players.</param>
        /// <param name="teamRanks">The ranks of the teams.</param>
        /// <returns>A list of players and their new rating</returns>
        public abstract IDictionary<TPlayer, Rating> CalculateNewRatings<TPlayer>(GameInfo gameInfo, 
            IEnumerable<IDictionary<TPlayer, Rating>> teams, params int[] teamRanks);

        /// <summary>
        /// Calculate the quality of the match.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to identify the player.</typeparam>
        /// <param name="gameInfo">Information on how the game calculates win probabilities.</param>
        /// <param name="teams">A list of teams and their players.</param>
        /// <returns>The quality of the match specified.</returns>
        public abstract double CalculateMatchQuality<TPlayer>(GameInfo gameInfo, IEnumerable<IDictionary<TPlayer, Rating>> teams);

        /// <summary>
        /// Check whether or not an option is supported.
        /// </summary>
        /// <param name="option">The flag we want to check.</param>
        /// <returns>True if the option is supported, false if not.</returns>
        public bool IsSupported(SupportedOptions option)
        {
            return (mSupportedOptions & option) == option;
        }

        /// <summary>
        /// Construct a skill calculator.
        /// </summary>
        /// <param name="supportedOptions">The options that are supported.</param>
        /// <param name="totalTeamsAllowed">The range of teams that are allowed.</param>
        /// <param name="playersPerTeamAllowed">The range of players per team that are allowed.</param>
        protected SkillCalculator(SupportedOptions supportedOptions, TeamsRange totalTeamsAllowed, PlayersRange playersPerTeamAllowed)
        {
            mSupportedOptions = supportedOptions;
            mTotalTeamsAllowed = totalTeamsAllowed;
            mPlayersPerTeamAllowed = playersPerTeamAllowed;
        }

        /// <summary>
        /// Validate that the team and player counts are in range.
        /// </summary>
        /// <typeparam name="TPlayer">The type used to represent a player.</typeparam>
        /// <param name="teams">The list of teams to validate.</param>
        protected void ValidateTeamCountAndPlayersCountPerTeam<TPlayer>(IEnumerable<IDictionary<TPlayer, Rating>> teams)
        {
            ValidateTeamCountAndPlayersCountPerTeam(teams, mTotalTeamsAllowed, mPlayersPerTeamAllowed);
        }

        private static void ValidateTeamCountAndPlayersCountPerTeam<TPlayer>(IEnumerable<IDictionary<TPlayer, Rating>> teams,
            TeamsRange totalTeams, PlayersRange playersPerTeam)
        {
            Guard.ArgumentNotNull(teams, "teams");
            var countOfTeams = 0;
            foreach (var currentTeam in teams)
            {
                if (!playersPerTeam.IsInRange(currentTeam.Count))
                {
                    throw new ArgumentException();
                }

                countOfTeams++;
            }

            if (!totalTeams.IsInRange(countOfTeams))
            {
                throw new ArgumentException();
            }
        }

        private readonly SupportedOptions mSupportedOptions;
        private readonly PlayersRange mPlayersPerTeamAllowed;
        private readonly TeamsRange mTotalTeamsAllowed;
    }
}