using Simulator.Maps;
using Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<IMappable> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;
    private int _currentTurnIndex = 0;

    public IMappable CurrentCreature => Creatures[_currentTurnIndex % Creatures.Count];
    public string CurrentMoveName => Moves[_currentTurnIndex % Moves.Length].ToString().ToLower();

    public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("The list of creatures cannot be empty.");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("The number of creatures must match the number of starting positions.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = new string(moves.Where(c => "URDL".Contains(char.ToUpper(c))).ToArray());

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation is already finished.");
        }

        var directions = DirectionParser.Parse(Moves);
        if (_currentTurnIndex >= directions.Count)
        {
            Finished = true;
            return;
        }

        var direction = directions[_currentTurnIndex % directions.Count];
        CurrentCreature.Go(direction);
        _currentTurnIndex++;
    }
}
