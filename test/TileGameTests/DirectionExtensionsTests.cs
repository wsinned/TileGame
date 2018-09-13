using System;
using System.Collections.Generic;
using FluentAssertions;
using TileGame;
using Xunit;

namespace TileGameTests
{
    public class DirectionExtensionsTests
    {
        [Fact]
        public void GetAxis_East_is_a_Horizontal_direction()
        {
            var east = Direction.East;
            east.GetAxisFromDirection().Should().Be(Axis.Horizontal);
        }

        [Fact]
        public void GetAxis_West_is_a_Horizontal_direction()
        {
            var west = Direction.West;
            west.GetAxisFromDirection().Should().Be(Axis.Horizontal);
        }

        [Fact]
        public void GetAxis_North_is_a_Vertical_direction()
        {
            var north = Direction.North;
            north.GetAxisFromDirection().Should().Be(Axis.Vertical);
        }

        [Fact]
        public void GetAxis_South_is_a_Vertical_direction()
        {
            var south = Direction.South;
            south.GetAxisFromDirection().Should().Be(Axis.Vertical);
        }
    }
}
