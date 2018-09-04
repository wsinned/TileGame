using System.ComponentModel;
namespace TileGame
{
    public static class DirectionExtensions
    {
        public static Axis GetAxisFromDirection(this Direction d)
        {
            switch (d)
            {
                case Direction.East:
                case Direction.West:
                    return Axis.Horizontal;

                case Direction.North:
                case Direction.South:
                    return Axis.Vertical;

                default:
                    throw new InvalidEnumArgumentException($"Not a direction: {d}");
            }
        }
    }
}
