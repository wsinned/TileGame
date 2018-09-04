using System;
using System.Collections.Generic;
using FluentAssertions;
using TileGame;
using Xunit;

namespace TileGameTests
{
    public class TileListTests
    {
        [Fact]
        public void TileList_should_throw_on_invalid_move_on_horizontal_axis()
        {
            var tiles = new List<Tile> 
            { 
                new EmptyTile { Location = new Location(0, 0) }, 
                new NumberTile { Location = new Location(0, 1), Value = 2 } 
            };
            var sut = new TileList(Axis.Horizontal, tiles);

            sut.Invoking(a => a.CanMoveTowardsZero(Direction.North))
                .Should().Throw<ArgumentException>();
            sut.Invoking(a => a.CanMoveTowardsZero(Direction.South))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TileList_should_throw_on_invalid_move_on_vertical_axis()
        {
            var tiles = new List<Tile> 
            { 
                new EmptyTile { Location = new Location(0, 0) }, 
                new NumberTile { Location = new Location(1, 0), Value = 2 } 
            };
            var sut = new TileList(Axis.Vertical, tiles);

            sut.Invoking(a => a.CanMoveTowardsZero(Direction.East))
                .Should().Throw<ArgumentException>();
            sut.Invoking(a => a.CanMoveTowardsZero(Direction.West))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TileList_should_move_west_and_not_move_east()
        {
            var tiles = new List<Tile> 
            { 
                new EmptyTile { Location = new Location(0, 0) }, 
                new NumberTile { Location = new Location(0, 1), Value = 2 } 
            };
            var sut = new TileList(Axis.Horizontal, tiles);

            sut.CanMoveTowardsZero(Direction.East).Should().BeFalse();
            sut.CanMoveTowardsZero(Direction.West).Should().BeTrue();
        }

        [Fact]
        public void TileList_should_move_east_and_not_move_west()
        {
            var tiles = new List<Tile>
            {
                new NumberTile { Location = new Location(0, 0), Value = 2 },
                new EmptyTile { Location = new Location(0, 1) }
            };
            var sut = new TileList(Axis.Horizontal, tiles);

            sut.CanMoveTowardsZero(Direction.East).Should().BeTrue();
            sut.CanMoveTowardsZero(Direction.West).Should().BeFalse();
        }

        [Fact]
        public void TileList_should_be_ordered_independent_of_initial_order()
        {
            var tiles = new List<Tile> 
            {
                new EmptyTile { Location = new Location(0, 1) },
                new NumberTile { Location = new Location(0, 0), Value = 2 }
            };
            var sut = new TileList(Axis.Horizontal, tiles);

            sut.CanMoveTowardsZero(Direction.East).Should().BeTrue();
            sut.CanMoveTowardsZero(Direction.West).Should().BeFalse();
        }

        [Fact]
        public void TileList_should_move_west_with_empty_tile_before_numberTile()
        {
            var tiles = new List<Tile> 
            { 
                new NumberTile { Location = new Location(0, 0), Value = 2 },
                new EmptyTile { Location = new Location(0, 1) }, 
                new NumberTile { Location = new Location(0, 2), Value = 4 } 
            };
            var sut = new TileList(Axis.Horizontal, tiles);

            sut.CanMoveTowardsZero(Direction.West).Should().BeTrue();
        }
    }
}

