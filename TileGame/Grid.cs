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
            var numberTiles = column.Where(t => t is NumberTile).OrderBy(t => t.Row);

            switch (direction)
            {
                case Direction.North:
                    return CanColumnMoveNorth(column, numberTiles);

                case Direction.South:
                    break;

                default:
                    throw new InvalidOperationException("A column cannot move in on the East/West axis.");
            }
  
            return true;
        }

        public bool CanColumnMoveNorth(List<Tile> column, IEnumerable<Tile> numberTiles)
        {
            if (numberTiles.Count() == 0) return false;
            if (numberTiles.Count() == 1)
            {
                if (column[0] is NumberTile) return false;

                foreach (var tile in numberTiles)
                {
                    if (column[tile.Row - 1] is EmptyTile) return true;
                }

            }

            return false;
        }
    }
}
