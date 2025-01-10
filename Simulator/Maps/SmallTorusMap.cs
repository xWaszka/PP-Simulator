namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public int Size { get; }
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
        }
        public override Point Next(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point(p.X, (p.Y + 1) % Size),
                Direction.Down => new Point(p.X, (p.Y - 1 + Size) % Size),
                Direction.Left => new Point((p.X - 1 + Size) % Size, p.Y),
                Direction.Right => new Point((p.X + 1) % Size, p.Y)
            };
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point((p.X + 1) % Size, (p.Y + 1) % Size),
                Direction.Down => new Point((p.X - 1 + Size) % Size, (p.Y - 1 + Size) % Size),
                Direction.Left => new Point((p.X - 1 + Size) % Size, (p.Y + 1) % Size),
                Direction.Right => new Point((p.X + 1) % Size, (p.Y - 1 + Size) % Size)
            };
        }
    }
}
