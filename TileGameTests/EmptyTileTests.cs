using System;
using FluentAssertions;
using TileGame;
using Xunit;

namespace TileGameTests
{
    public class EmptyTileTests
    {
        [Fact]
        public void ToString_should_return_empty_tile_message()
        {
            var tile = new EmptyTile { Location = new Location(0,0) };
            tile.ToString().Should().Be("Tile [0, 0]: Empty");
        }
    }
}
