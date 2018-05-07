namespace Ruyi.SDK.Cloud
{
    internal static class PartialPlay
    {
        public static double GetPartialPlayPercentage(object player)
        {
            var partialPlay = player as ISupportPartialPlay;
            if (partialPlay == null)
            {
                return 1.0;
            }

            var partialPlayPercentage = partialPlay.PartialPlayPercentage;

            const double smallestPercentage = 0.0001;
            if (partialPlayPercentage < smallestPercentage)
            {
                partialPlayPercentage = smallestPercentage;
            }

            return partialPlayPercentage;
        }
    }
}
