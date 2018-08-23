using System;
using FluentAssertions;
using TileGame;
using Xunit;

namespace TileGameTests
{
    public class NumberTileTests
    {
        [Fact]
        public void ToString_should_return_Value_message()
        {
            var tile = new NumberTile { Location = new Location(0,0), Value =2 };
            tile.ToString().Should().Be("Tile [0, 0]: Value 2");
        }
    }
}
