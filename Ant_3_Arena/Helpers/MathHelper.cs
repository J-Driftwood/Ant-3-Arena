using Ant_3_Arena.Models;
using System;
using System.Numerics;

namespace Ant_3_Arena.Helpers
{
    internal class MathHelper
    {
        internal static Vector2 FromDegreesToPosition(double degrees)
        {
            return new Vector2((float)Math.Cos(degrees * Math.PI / 180), (float)Math.Sin(degrees * Math.PI / 180));
        }

        internal static Direction GetAngle(Vector2 a, Vector2 b)
        {
            float xDiff = b.X - a.X;
            float yDiff = b.Y - a.Y;

            return new Direction(Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI);
        }
    }
}
