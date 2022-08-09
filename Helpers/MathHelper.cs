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
    }
}
