using System.Text;
using SimConsole;
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

        string moves = "rdullddulllrurl";
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
        while (!simulation.Finished)
        {
            try
            {
                mapVisualizer.Draw();
                Console.WriteLine($"Tura {turnCount} - Ruch: {simulation.CurrentCreature.Name} idzie w kierunku {simulation.CurrentMoveName}");
                Console.WriteLine($"Pozycja przed ruchem: {simulation.CurrentCreature.Position}");
                simulation.Turn();
                Console.WriteLine($"Pozycja po ruchu: {simulation.CurrentCreature.Position}");
                turnCount++;
                

                Console.WriteLine("\nStworzenia na mapie:");
                foreach (var creature in creatures)
                {
                    Console.WriteLine($"{creature.Name} na pozycji {creature.Position}");
                }

                Console.WriteLine("\nNaciśnij Enter, aby przejść do następnej tury...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nWystąpił błąd: {ex.Message}");
                Console.WriteLine("Symulacja zostaje zatrzymana.");
                break;
            }
        }

        Console.WriteLine("\nSymulacja zakończona!");
        Console.ReadKey(true);
    }
}
