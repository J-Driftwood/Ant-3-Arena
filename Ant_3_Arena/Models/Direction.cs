namespace Ant_3_Arena.Models
{
    internal class Direction
    {
        internal enum CardinalDirection
        {
            East = 0,
            South = 1,
            West = 2,
            North = 3,
        }

        /// <param name="degrees">value should be between 0 and 360. Value 0 equals direction east.</param>
        internal Direction(double degrees)
        {
            Degrees = degrees;
        }

        internal Direction(CardinalDirection cardinalDirection)
        {
            Degrees = (int)cardinalDirection * 90;
        }

        public static Direction operator +(Direction a, float b)
        {
            return new Direction(a.Degrees + b);
        }

        public double Degrees { get; }
    }
}
