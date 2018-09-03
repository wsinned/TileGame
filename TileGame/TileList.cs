﻿using System.Collections.Generic;
using System.Linq;
using System;

namespace TileGame
{
    public class TileList
    {
        private IEnumerable<Tile> _tiles;

        public Axis Axis { get; private set; }

        public int Count => _tiles.Count();

        public bool IsEmpty => !_tiles.Any(t => t is NumberTile);

        public bool HasNumberTiles => _tiles.Any(t => t is NumberTile);

        public TileList(Axis axis, IEnumerable<Tile> tiles)
        {
            Axis = axis;
            _tiles = tiles;
        }

        public bool IsFirstTileEmpty(IEnumerable<Tile> tiles)
        {
                return tiles.First() is EmptyTile;
        }

        public bool CanMoveTowardsZero(Direction direction)
        {
            CheckForInvalidMovement(direction);

            var tiles = ReverseIfRequired(direction).ToList();

            if (IsEmpty) return false;
            if (IsFirstTileEmpty(tiles)) return true;

            for (int i = 1; i < tiles.Count(); i++)
            {
                var tile = tiles[i];
                var prevTile = tiles[i - 1];

                if (tile is NumberTile && prevTile is EmptyTile)
                {
                    return true;
                }

                if (tile is NumberTile && prevTile is NumberTile)
                {
                    if (AreTilesSameValue(prevTile, tile))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool AreTilesSameValue(Tile a, Tile b)
        {
            var aTile = a as NumberTile;
            var bTile = b as NumberTile;

            return aTile.Value == bTile.Value;
        }

        private void CheckForInvalidMovement(Direction direction)
        {
            var fail = false;

            switch (Axis)
            {
                case Axis.Horizontal:
                    fail |= (direction == Direction.North || direction == Direction.South);
                    break;
                case Axis.Vertical:
                    fail |= (direction == Direction.East || direction == Direction.West);

                    break;
            }

            if (fail)
            {
                throw new ArgumentException($"Cannot move {direction} on {Axis} axis.");
            }
        }

        private IEnumerable<Tile> ReverseIfRequired(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return _tiles.Reverse();

                case Direction.South:
                    return _tiles.Reverse();

                default:
                    return _tiles;
            }
        }
    }
}
