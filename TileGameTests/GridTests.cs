using FluentAssertions;
using System.Linq;
using TileGame;
using Xunit;

namespace TileGameTests
{
    public class GridTests
    {
        [Fact]
        public void Create_grid_returns_grid_with_correct_number_of_rows()
        {
            var grid = new Grid(3);

            grid.NumberOfRows.Should().Be(3);
        }

        [Fact]
        public void Create_grid_returns_grid_with_correct_number_of_columns()
        {
            var grid = new Grid(4);

            grid.NumberOfColumns.Should().Be(4);
        }

        [Fact]
        public void New_Grid_should_have_all_empty_tiles()
        {
            var grid = new Grid(4);

            grid.EmptyTiles.Count.Should().Be(16);
        }

        [Fact]
        public void Setting_a_number_tile_should_reduce_empty_tiles()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(1, 1)});

            grid.EmptyTiles.Count.Should().Be(15);
        }

        [Fact]
        public void Getting_a_column_returns_correct_number_of_tiles()
        {
            var grid = new Grid(4);

            grid.GetColumn(0).Count.Should().Be(4);
        }

        [Fact]
        public void Getting_a_row_returns_correct_number_of_tiles()
        {
            var grid = new Grid(4);

            grid.GetRow(0).Count.Should().Be(4);
        }

        [Fact]
        public void Setting_a_number_tile_should_be_in_correct_column()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(1, 2)});

            grid.GetColumn(2).Count(t => t is NumberTile).Should().Be(1);
        }

        [Fact]
        public void Setting_a_number_tile_should_be_in_correct_row()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(1, 2)});

            grid.GetRow(1).Count(t => t is NumberTile).Should().Be(1);
        }
    }
}
