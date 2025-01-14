using Simulator;
public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
    }

    public void LogTurn()
    {
        var symbols = new Dictionary<Point, char>();
        foreach (var creature in _simulation.Creatures)
        {
            symbols[creature.Position] = creature.Symbol;
        }

        var log = new SimulationTurnLog
        {
            Mappable = _simulation.CurrentCreature.ToString(),
            Move = _simulation.CurrentMoveName,
            Symbols = symbols
        };

        TurnLogs.Add(log);
    }
}

/// <summary>
/// State of map after single simulation turn.
/// </summary>
public class SimulationTurnLog
    {
        /// <summary>
        /// Text representation of moving object in this turn.
        /// CurrentMappable.ToString()
        /// </summary>
        public required string Mappable { get; init; }

        /// <summary>
        /// Text representation of the move in this turn.
        /// </summary>
        public required string Move { get; init; }

        /// <summary>
        /// Dictionary of IMappable.Symbols on the map in this turn.
        /// </summary>
        public required Dictionary<Point, char> Symbols { get; init; }
    }

