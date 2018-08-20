using System;
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

        [Fact]
        public void An_empty_column_should_not_have_a_move()
        {
            var grid = new Grid(4);

            grid.CanColumnMove(1, Direction.North).Should().BeFalse();
        }

        [Fact]
        public void A_column_cannot_move_east_or_west()
        {
            var grid = new Grid(4);

            grid.Invoking(a => a.CanColumnMove(1, Direction.East))
                .Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void A_column_with_a_single_tile_at_row_0_should_not_move_north()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(0, 1), Value = 2 });

            grid.CanColumnMove(1, Direction.North).Should().BeFalse();
        }

        [Fact]
        public void A_column_with_a_single_numberTile_at_row_above_0_should_move_north()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(1, 1), Value = 2 });

            grid.CanColumnMove(1, Direction.North).Should().BeTrue();
        }

        [Fact]
        public void A_column_with_a_numberTile_at_row_0_and_another_after_an_emprtyTile_can_move_north()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(1, 1), Value = 2 });
            grid.SetTile(new NumberTile { Location = new Location(3, 1), Value = 4 });

            grid.CanColumnMove(1, Direction.North).Should().BeTrue();
        }

        [Fact]
        public void A_column_full_of_different_values_cannot_move_north()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(0, 1), Value = 2 });
            grid.SetTile(new NumberTile { Location = new Location(1, 1), Value = 4 });
            grid.SetTile(new NumberTile { Location = new Location(2, 1), Value = 8 });
            grid.SetTile(new NumberTile { Location = new Location(3, 1), Value = 16 });

            grid.CanColumnMove(1, Direction.North).Should().BeFalse();
        }

        [Fact]
        public void A_column_with_adjacent_same_value_tiles_can_move_north()
        {
            var grid = new Grid(4);
            grid.SetTile(new NumberTile { Location = new Location(0, 1), Value = 2 });
            grid.SetTile(new NumberTile { Location = new Location(1, 1), Value = 4 });
            grid.SetTile(new NumberTile { Location = new Location(2, 1), Value = 4 });
            grid.SetTile(new NumberTile { Location = new Location(3, 1), Value = 16 });

            grid.CanColumnMove(1, Direction.North).Should().BeTrue();
        }
    }
}
