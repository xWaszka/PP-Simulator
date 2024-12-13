namespace Simulator;

public abstract class Creature
{
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

    public virtual void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name}, level {Level}.");
    }

    public void Go(Direction direction)
    {
        string directionText = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionText}.");
    }
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public abstract int Power { get; }
}
