using System;
using TileGame;
using Xunit;

namespace TileGameTests
{
    public class GridTests
    {
        [Fact]
        public void Create_grid_returns_grid_with_correct_dimensions()
        {
            int size = 2;
            Grid grid = new Grid(size);

            Assert.Equal(size, grid.NumberOfRows);
            Assert.Equal(size, grid.NumberOfColumns);
        }
    }
}
