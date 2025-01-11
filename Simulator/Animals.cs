using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    public Map? Maps { get; set; }
    public Point Position { get; set; }
    public virtual char Symbol => 'A';
    public string Name { get; init; } = "Unknown";
    private string description = "Unknown";
    public string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; init; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        Maps = map;
        Position = position;
        map.Add(this, position);
    }

    public virtual void Go(Direction direction)
    {
        if (Maps == null)
        {
            throw new InvalidOperationException("Animal is not assigned to a map.");
        }
        Point newPosition = Maps.Next(Position, direction);
        Maps.Move(this, newPosition);
        Position = newPosition;
    }
}
