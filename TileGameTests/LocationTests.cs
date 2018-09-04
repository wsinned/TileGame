using FluentAssertions;
using TileGame;
using Xunit;

namespace TileGameTests
{
    public class LocationTests
    {
        [Fact]
        public void ToString_should_return_empty_tile_message()
        {
            var location = new Location(0, 0);
            location.ToString().Should().Be("[0, 0]");
        }

        [Fact]
        public void Equals_should_not_equal_null()
        {
            var location = new Location(0, 0);
            location.Equals(null).Should().BeFalse();
        }

        [Fact]
        public void Equals_should_not_equal_an_object()
        {
            var location = new Location(0, 0);
            var obj = new object();
            location.Equals(obj).Should().BeFalse();
        }

        [Fact]
        public void Equals_should_not_equal_an_different_location()
        {
            var location1 = new Location(0, 0);
            var location2 = new Location(1, 0);
            location1.Equals(location2).Should().BeFalse();
        }

        [Fact]
        public void Equals_should_equal_an_equivalent_location()
        {
            var location1 = new Location(0, 0);
            var location2 = new Location(0, 0);
            location1.Equals(location2).Should().BeTrue();
        }
    }
}

