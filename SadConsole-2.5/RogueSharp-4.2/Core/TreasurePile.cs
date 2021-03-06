﻿using RogueSharpSample1.Interfaces;

namespace RogueSharpSample1.Core
{
    public class TreasurePile
    {
        public TreasurePile(int x, int y, ITreasure treasure)
        {
            X = x;
            Y = y;
            Treasure = treasure;

            var drawableTreasure = treasure as IDrawable;
            if (drawableTreasure != null)
            {
                drawableTreasure.X = x;
                drawableTreasure.Y = y;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public ITreasure Treasure { get; set; }
    }
}
