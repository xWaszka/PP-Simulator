namespace Simulator.Maps;
using Simulator;

public interface IMappable
{
    Map? Maps { get; set; }
    Point Position { get; set; }
    string Name { get; }
    char Symbol { get; }
    void InitMapAndPosition(Map map, Point position);
    void Go(Direction direction);
}
