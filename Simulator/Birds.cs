namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public Birds() : base() { }

    public Birds(string description, uint size, bool canFly = true) : base()
    {
        Description = description;
        Size = size;
        CanFly = canFly;
    }
    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";
}
