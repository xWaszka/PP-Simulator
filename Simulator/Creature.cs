using Simulator.Maps;
namespace Simulator;


public abstract class Creature : IMappable
{
    public Map? Maps { get; set; }
    public Point Position { get; set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        Maps = map;
        Position = position;
        map.Add(this, position);
    }


    private string name = "Unknown";
    private int level = 1;
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature()
    {
    }
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }
    public void Upgrade()
    {
        if (level < 10)
            level++;
    }
    public abstract string Info { get; }


    public virtual string Greeting()
    {
        return ($"Hi! I'm {Name}, level {Level}.");
    }

    public void Go(Direction direction)
    {
        if (Maps == null)
        {
            throw new InvalidOperationException("Stwór nie jest przypisany do mapy.");
        }
        Point newPosition = Maps.Next(Position, direction);
        Maps.Move(this, newPosition);
        Position = newPosition;
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public abstract int Power { get; }
    public abstract char Symbol { get; }
}
