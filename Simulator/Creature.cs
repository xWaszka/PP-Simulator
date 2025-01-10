using Simulator.Maps;
namespace Simulator;


public abstract class Creature
{
    public Map? Maps { get; set; }
    public Point Position { get; set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        //Map.Add()
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
        // użyc
        //Map.Next()
        //Map.Move()
    }
    public string[] Go(Direction[] directions)
    {
        string[] result = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }
    public string[] Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);
        return Go(parsedDirections);
    }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public abstract int Power { get; }
}
