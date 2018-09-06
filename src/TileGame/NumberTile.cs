namespace TileGame
{
    public class NumberTile: Tile
    {
        public int Value { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Value {Value}";
        }
    }
}
