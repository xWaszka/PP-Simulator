namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public Birds() : base() { }

    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";
}
