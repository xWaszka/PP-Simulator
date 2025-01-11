namespace Simulator;


public class Birds : Animals
{
    public bool CanFly { get; set; } = true;
    public Birds() : base() { }
    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";

    public override void Go(Direction direction)
    {
        if (Maps == null)
        {
            throw new InvalidOperationException("Bird is not assigned to a map.");
        }
        Point newPosition;
        if (CanFly)
        {
            newPosition = Maps.Next(Position, direction);
            newPosition = Maps.Next(newPosition, direction);
        }
        else
        {
            newPosition = Maps.NextDiagonal(Position, direction);
        }
        Maps.Move(this, newPosition);
        Position = newPosition;
    }

}
