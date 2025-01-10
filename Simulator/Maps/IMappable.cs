namespace Simulator.Maps;

public interface IMappable
{
    Map? Maps { get; set; }
    Point Position { get; set; }
    string Name { get; }
    void InitMapAndPosition(Map map, Point position);
    void Go(Direction direction);
}
