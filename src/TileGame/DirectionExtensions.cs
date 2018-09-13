using System.ComponentModel;
namespace TileGame
{
    public static class DirectionExtensions
    {
        public static Axis GetAxisFromDirection(this Direction direction)
        {
            if (direction == Direction.East || direction == Direction.West)
            {
                return Axis.Horizontal;
            }
            else
            {
                return Axis.Vertical;
            }
        }
    }
}
