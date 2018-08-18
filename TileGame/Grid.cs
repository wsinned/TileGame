using System;
using System.Collections.Generic;

namespace TileGame
{
    public class Grid
    {
        private int _size;

        public Grid(int size)
        {
            _size = size;
        }

        public int NumberOfRows => _size;
        public int NumberOfColumns => _size;

    }
}
