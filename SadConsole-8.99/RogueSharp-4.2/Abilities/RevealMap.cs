﻿using RogueSharpSample2.Core;

namespace RogueSharpSample2.Abilities
{
    public class RevealMap : Ability
    {
        private readonly int _revealDistance;

        public RevealMap(int revealDistance)
        {
            Name = "Reveal Map";
            TurnsToRefresh = 100;
            TurnsUntilRefreshed = 0;
            _revealDistance = revealDistance;
        }

        protected override bool PerformAbility()
        {
            var map = RogueGame.DungeonMap;
            var player = RogueGame.Player;

            foreach (var cell in map.GetCellsInCircle(player.X, player.Y, _revealDistance))
            {
                if (cell.IsWalkable)
                {
                    map.SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }

            return true;
        }
    }
}
