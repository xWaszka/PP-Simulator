using System.Text;
using Simulator;
using Simulator.Maps;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new SmallTorusMap(8, 6);

        List<IMappable> creatures = new List<IMappable>
        {
            new Elf("Legolas", 5, 8),
            new Orc("Gorbag", 3, 7),
            new Animals { Name = "Rabbits" },
            new Birds { Name = "Eagles", CanFly = true },
            new Birds { Name = "Ostriches", CanFly = false },
        };

        string moves = "rdurlddurldruul";
        if (string.IsNullOrWhiteSpace(moves))
        {
            throw new InvalidOperationException("Ciąg ruchów jest pusty lub nieprawidłowy.");
        }

        Console.WriteLine($"Ciąg ruchów: {moves}");

        List<Point> points = new List<Point>
        {
            new Point(1, 1),
            new Point(2, 1),
            new Point(3, 4),
            new Point(6, 1),
            new Point(1, 4),
        };

        Simulation simulation = new(map, creatures, points, moves);
        SimulationHistory history = new(simulation);
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("Początkowy stan mapy:");
        mapVisualizer.Draw();
        Console.WriteLine("\nInformacje o stworzeniach:");
        foreach (var creature in creatures)
        {
            Console.WriteLine($"{creature.Name} na pozycji {creature.Position}");
        }

        Console.WriteLine("\nNaciśnij Enter, aby rozpocząć symulację...");
        Console.ReadKey(true);

        int turnCount = 1;
        history.LogTurn();

        while (!simulation.Finished && turnCount <= 15)
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"Tura {turnCount}");
                mapVisualizer.Draw();
                Console.WriteLine($"Ruch: {simulation.CurrentCreature.Name} idzie w kierunku {simulation.CurrentMoveName}");
                Console.WriteLine($"Pozycja przed ruchem: {simulation.CurrentCreature.Position}");

                simulation.Turn();
                history.LogTurn();
                Console.WriteLine($"Pozycja po ruchu: {simulation.CurrentCreature.Position}");

                Console.WriteLine("\nStworzenia na mapie:");
                foreach (var creature in creatures)
                {
                    Console.WriteLine($"{creature.Name} na pozycji {creature.Position}");
                }

                turnCount++;

                if (!simulation.Finished && turnCount <= 15)
                {
                    Console.WriteLine("\nNaciśnij Enter, aby przejść do następnej tury...");
                    Console.ReadKey(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nWystąpił błąd: {ex.Message}");
                Console.WriteLine("Symulacja zostaje zatrzymana.");
                break;
            }
        }

        Console.WriteLine("\nSymulacja zakończona!\n");

        foreach (var turnNumber in new[] { 5, 10, 15 })
        {
            if (turnNumber <= history.TurnLogs.Count)
            {
                var log = history.TurnLogs[turnNumber - 1];
                Console.WriteLine($"\nStan mapy po {turnNumber} turze:");
                foreach (var symbol in log.Symbols)
                {
                    Console.WriteLine($"Pozycja: {symbol.Key}, Symbol: {symbol.Value}");
                }
            }
            else
            {
                Console.WriteLine($"\nNie osiągnięto {turnNumber} tury w symulacji.");
            }
        }

        Console.ReadKey(true);
    }
}
