﻿using Microsoft.Xna.Framework;

namespace GoRogueSample3.Tiles
{
    public class TileDoor : TileBase
    {
        public bool IsOpen { get; set; } // Open door = 1, closed = 0

        public bool Locked { get; set; } // Locked door = 1, Unlocked = 0

        //Default constructor
        //A TileDoor can be set locked/unlocked/open/closed using the constructor.
        public TileDoor(bool locked, bool open)
            : base(Color.Gray, Color.Transparent, '+')
        {
            //+ is the closed glyph
            //closed by default
            Glyph = '+';

            //Update door fields
            Locked = locked;
            IsOpen = open;

            //change the symbol to open if the door is open
            if (!Locked && IsOpen)
            {
                Open();
            }
            else if (Locked || !IsOpen)
            {
                Close();
            }
        }

        //closes a door
        public void Close()
        {
            IsOpen = false;
            Glyph = '+';
            IsBlockingLOS = true;
            IsBlockingMove = true;
        }

        //opens a door
        public void Open()
        {
            IsOpen = true;
            IsBlockingLOS = false;
            IsBlockingMove = false;
            Glyph = '-';
        }
    }
}
