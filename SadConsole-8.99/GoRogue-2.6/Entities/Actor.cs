﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GoRogueSample3.Entities
{
    public abstract class Actor : Entity
    {
        protected Actor(Color foreground, Color background, int glyph, int width = 1, int height = 1)
            : base(foreground, background, width, height, glyph)
        { }

        public List<Item> Inventory => new List<Item>(); // the player's collection of items

        public int Health { get; set; } // current health
        public int MaxHealth { get; set; } // maximum health
        public int Attack { get; set; } // attack strength
        public int AttackChance { get; set; } // percent chance of successful hit
        public int Defense { get; set; } // defensive strength
        public int DefenseChance { get; set; } // percent chance of successfully blocking a hit
        public int Gold { get; set; } // amount of gold carried

        // Moves the Actor BY positionChange tiles in any X/Y direction
        // returns true if actor was able to move, false if failed to move
        public bool MoveBy(Point positionChange)
        {
            // Check the current map if we can move to this new position
            if (Program.World.CurrentMap.IsTileWalkable(Position + positionChange))
            {
                // if there's a monster here,
                // do a bump attack
                var monster = Program.World.CurrentMap.GetEntityAt<Monster>(Position + positionChange);
                var item = Program.World.CurrentMap.GetEntityAt<Item>(Position + positionChange);
                if (monster != null)
                {
                    Program.CommandManager.Attack(this, monster);
                    return true;
                }
                // if there's an item here,
                // try to pick it up

                if (item != null)
                {
                    Program.CommandManager.Pickup(this, item);
                    return true;
                }

                Position += positionChange;
                return true;
            }

            return false;
        }

        // Moves the Actor TO newPosition location
        // returns true if actor was able to move, false if failed to move
        public bool MoveTo(Point newPosition)
        {
            Position = newPosition;
            return true;
        }
    }
}
