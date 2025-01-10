
namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    private List<Creature>?[,] _field;

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

        _field = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point point)
    {
        if (!Exist(point)) throw new ArgumentOutOfRangeException("Point is outside the map.");

        if (_field[point.X, point.Y] == null)
        {
            _field[point.X, point.Y] = new List<Creature>();
        }

        _field[point.X, point.Y].Add(creature);
    }

    public override List<Creature> At(Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Point is out of bounds.");
        }

        return _field[point.X, point.Y] ?? new List<Creature>();
    }

    public override List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }
    public override void Remove(Creature creature, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Point is out of bounds.");
        }

        var creaturesAtPoint = _field[point.X, point.Y];
        if (creaturesAtPoint != null && creaturesAtPoint.Contains(creature))
        {
            creaturesAtPoint.Remove(creature);
        }
    }
    public override void Move(Creature creature, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Point is out of bounds.");
        }

        Remove(creature, creature.Position);
        Add(creature, point);
        creature.Position = point;
    }
}
