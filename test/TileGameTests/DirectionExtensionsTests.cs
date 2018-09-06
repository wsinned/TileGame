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
        public void GetAxisFromDirection_East_is_a_Horizontal_direction()
        {
            var d = Direction.East;
            d.GetAxisFromDirection().Should().Be(Axis.Horizontal);
        }

        [Fact]
        public void GetAxisFromDirection_West_is_a_Horizontal_direction()
        {
            var d = Direction.West;
            d.GetAxisFromDirection().Should().Be(Axis.Horizontal);
        }

        [Fact]
        public void GetAxisFromDirection_North_is_a_Vertical_direction()
        {
            var d = Direction.North;
            d.GetAxisFromDirection().Should().Be(Axis.Vertical);
        }

        [Fact]
        public void GetAxisFromDirection_South_is_a_Vertical_direction()
        {
            var d = Direction.South;
            d.GetAxisFromDirection().Should().Be(Axis.Vertical);
        }
    }
}
