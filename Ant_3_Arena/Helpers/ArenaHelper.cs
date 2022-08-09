using Ant_3_Arena.Contracts;
using Ant_3_Arena.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Ant_3_Arena.Helpers
{
    internal class ArenaHelper
    {
        private static readonly Random random = new Random();

        internal static void AddRandomAnt(ref List<IEntity> entities, Size clientSize)
        {
            const int MaxHexValue = 256;

            var randomColor = Color.FromArgb(random.Next(MaxHexValue), random.Next(MaxHexValue), random.Next(MaxHexValue));
            var position = new Vector2(random.Next(clientSize.Width), random.Next(clientSize.Height));
            var direction = new Direction(random.Next(360));
            var speed = random.NextDouble() * 10 + 2;

            entities.Add(new Ant(randomColor, position, direction, speed));
        }

        internal static void AddUniqueWhiteAnt(ref List<IEntity> entities, Size clientSize)
        {
            var position = new Vector2(random.Next(clientSize.Width - 25) + 25, random.Next(clientSize.Height - 25) + 25);
            var direction = new Direction(random.Next(360));
            var speed = random.NextDouble() * 10 + 1;

            entities.Add(new Ant(Color.White, position, direction, speed));
        }
    }
}
