﻿using System;
using Microsoft.Xna.Framework;
using RogueSharpSample1.Behaviors;
using RogueSharpSample1.Monsters;
using RogueSharpSample1.Systems;
using SadConsole;
using Console = SadConsole.Consoles.Console;

namespace RogueSharpSample1.Core
{
    public class Monster : Actor
    {
        public int? TurnsAlerted { get; set; }

        public void DrawStats(Console statConsole, int position)
        {
            var yPosition = 13 + position * 2;
            statConsole.CellData.Print(1, yPosition, Symbol.ToString(), Color);
            var width = Convert.ToInt32(Health / (double) MaxHealth * 16.0);
            var remainingWidth = 16 - width;
            statConsole.CellData.SetBackground(3, yPosition, width, Swatch.Primary);
            statConsole.CellData.SetBackground(3 + width, yPosition, remainingWidth, Swatch.PrimaryDarkest);
            statConsole.CellData.Print(2, yPosition, $": {Name}", Color.White);
        }

        public static Monster Clone(Monster anotherMonster)
        {
            return new Ooze
            {
                Attack = anotherMonster.Attack,
                AttackChance = anotherMonster.AttackChance,
                Awareness = anotherMonster.Awareness,
                Color = anotherMonster.Color,
                Defense = anotherMonster.Defense,
                DefenseChance = anotherMonster.DefenseChance,
                Gold = anotherMonster.Gold,
                Health = anotherMonster.Health,
                MaxHealth = anotherMonster.MaxHealth,
                Name = anotherMonster.Name,
                Speed = anotherMonster.Speed,
                Symbol = anotherMonster.Symbol
            };
        }

        public virtual void PerformAction(CommandSystem commandSystem)
        {
            var behavior = new StandardMoveAndAttack();
            behavior.Act(this, commandSystem);
        }
    }

    public static class CellSurfaceExtensions
    {
        public static void SetBackground(this CellSurface cellSurface, int x, int y, int width, Color color)
        {
            for (var i = x; i < x + width; i++)
            {
                cellSurface.SetBackground(i, y, color);
            }
        }
    }
}
