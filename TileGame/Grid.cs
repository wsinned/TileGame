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

        public TileList GetAxisTiles(Axis axis, int axisId)
        {
            IEnumerable<Tile> tiles;
            switch (axis)
            {
                case Axis.Horizontal:
                    tiles = _tiles.Values.Where(t => t.Row == axisId).OrderBy(t => t.Column);
                    break;

                case Axis.Vertical:
                    tiles = _tiles.Values.Where(t => t.Column == axisId).OrderBy(t => t.Row);
                    break;

                default:
                    tiles = null;
                    break;
            }
            return new TileList(axis, tiles);
        }

        public bool CanAxisMove(Axis axis, int columnId, Direction direction)
        {
            var column = GetAxisTiles(axis, columnId);
            return column.CanMoveTowardsZero(direction);
        }

    }
}
