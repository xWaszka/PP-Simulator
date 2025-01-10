
namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    private List<IMappable>?[,] _field;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX));
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY));
        }

        _field = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(IMappable mappable, Point point)
    {
        if (!Exist(point)) throw new ArgumentOutOfRangeException("Point is outside the map.");

        if (_field[point.X, point.Y] == null)
        {
            _field[point.X, point.Y] = new List<IMappable>();
        }

        _field[point.X, point.Y].Add(mappable);
    }

    public override List<IMappable> At(Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Point is out of bounds.");
        }

        return _field[point.X, point.Y] ?? new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public override void Remove(IMappable mappable, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Point is out of bounds.");
        }

        var mappablesAtPoint = _field[point.X, point.Y];
        if (mappablesAtPoint != null && mappablesAtPoint.Contains(mappable))
        {
            mappablesAtPoint.Remove(mappable);
        }
    }

    public override void Move(IMappable mappable, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Point is out of bounds.");
        }

        Remove(mappable, mappable.Position);
        Add(mappable, point);
        mappable.Position = point;
    }
}
