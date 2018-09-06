namespace TileGame
{
    public class Tile
    {
        public Location Location {get; set;}

        public int Row => Location.Row;
        public int Column => Location.Column;

        public override string ToString()
        {
            return $"Tile {Location.ToString()}:";
        }
    }
}