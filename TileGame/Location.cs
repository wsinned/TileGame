namespace TileGame
{
    public class Location
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Location (int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"[{Row}, {Column}]";
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var location = obj as Location;
            return (Row == location.Row && Column == location.Column);
        }

        public override int GetHashCode()
        {
            return Row.GetHashCode() * 17 + Column.GetHashCode();
        }
    }
}
