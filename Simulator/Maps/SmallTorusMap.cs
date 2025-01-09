﻿namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }
        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Wielkość mapy musi być miedzy 5 a 20");
            }
            Size = size;
        }
        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
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
