using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Cloud
{
    internal static class RankSorter
    {
        public static void Sort<T>(ref IEnumerable<T> teams, ref int[] teamRanks)
        {
            Guard.ArgumentNotNull(teams, "teams");
            Guard.ArgumentNotNull(teamRanks, "teamRanks");

            var lastObservedRank = 0;
            var needToSort = false;

            foreach (var currentRank in teamRanks)
            {
                if (currentRank < lastObservedRank)
                {
                    needToSort = true;
                    break;
                }

                lastObservedRank = currentRank;
            }

            if (!needToSort)
            {
                return;
            }

            List<T> itemsInList = teams.ToList();
            var itemToRank = new Dictionary<T, int>();

            for (var i = 0; i < itemsInList.Count; ++i)
            {
                var currentItem = itemsInList[i];
                var currentItemRank = teamRanks[i];
                itemToRank[currentItem] = currentItemRank;
            }

            var sortedItems = new T[teamRanks.Length];
            var sortedRanks = new int[teamRanks.Length];

            var currentIndex = 0;

            foreach (var sortedKeyValuePair in itemToRank.OrderBy(pair => pair.Value))
            {
                sortedItems[currentIndex] = sortedKeyValuePair.Key;
                sortedRanks[currentIndex++] = sortedKeyValuePair.Value;
            }

            teams = sortedItems;
            teamRanks = sortedRanks;
        }
    }
}
