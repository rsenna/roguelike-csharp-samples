﻿using RogueSharp.SadConsole.Playground.Main.Core;
using RogueSharp.SadConsole.Playground.Main.Interfaces;
using RogueSharp.SadConsole.Playground.Main.Monsters;
using RogueSharp.SadConsole.Playground.Main.Systems;

namespace RogueSharp.SadConsole.Playground.Main.Behaviors
{
    public class SplitOoze : IBehavior
    {
        public bool Act(Monster monster, CommandSystem commandSystem)
        {
            var map = RogueGame.DungeonMap;

            // Ooze only splits when wounded
            if (monster.Health >= monster.MaxHealth)
            {
                return false;
            }

            var halfHealth = monster.MaxHealth / 2;
            if (halfHealth <= 0)
                // Health would be too low so bail out
            {
                return false;
            }

            var cell = FindClosestUnoccupiedCell(map, monster.X, monster.Y);

            if (cell == null)
                // No empty cells so bail out
            {
                return false;
            }

            // Make a new ooze with half the health of the old one
            var newOoze = Monster.Clone(monster) as Ooze;
            if (newOoze != null)
            {
                newOoze.TurnsAlerted = 1;
                newOoze.X = cell.X;
                newOoze.Y = cell.Y;
                newOoze.MaxHealth = halfHealth;
                newOoze.Health = halfHealth;
                map.AddMonster(newOoze);
                RogueGame.MessageLog.Add($"{monster.Name} splits itself in two");
            }
            else
            {
                // Not an ooze so bail out
                return false;
            }

            // Halve the original ooze's health too
            monster.MaxHealth = halfHealth;
            monster.Health = halfHealth;

            return true;
        }

        private Cell FindClosestUnoccupiedCell(DungeonMap dungeonMap, int x, int y)
        {
            for (var i = 1; i < 5; i++)
            {
                foreach (var cell in dungeonMap.GetBorderCellsInArea(x, y, i))
                {
                    if (cell.IsWalkable)
                    {
                        return cell;
                    }
                }
            }

            return null;
        }
    }
}
