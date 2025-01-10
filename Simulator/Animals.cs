using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
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
}
