using System;
using System.Collections.Generic;
using System.Linq;

namespace TileGame
{
    public class Grid
    {
        private readonly int _size;
        private readonly Dictionary<Location, Tile> _tiles = new Dictionary<Location, Tile>();

        public int NumberOfRows => _size;
        public int NumberOfColumns => _size;
        public List<Tile> EmptyTiles => _tiles.Values.Where(t => t is EmptyTile).ToList();

        public Grid(int size)
        {
            _size = size;
            GenerateTiles(_size);
        }

        private void GenerateTiles(int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    var location = new Location(row, column);
                    _tiles[location] = new EmptyTile { Location = location };
                }
            }
        }

        public void SetTile(NumberTile numberTile)
        {
            _tiles[numberTile.Location] = numberTile;
        }

        public List<Tile> GetColumn(int column)
        {
            return _tiles.Values.Where(t => t.Column == column).OrderBy(t => t.Row).ToList();
        }

        public List<Tile> GetRow(int row)
        {
            return _tiles.Values.Where(t => t.Row == row).OrderBy(t => t.Column).ToList();
        }

        public bool CanColumnMove(int columnId, Direction direction)
        {
            var column = GetColumn(columnId);
            if (column.Count(t => t is NumberTile) == 0) return false;
            if (column.Count(t => t is NumberTile) == 1)
            {
                if (column[0] is NumberTile) return false;
            }
            return true;
        }
    }
}
