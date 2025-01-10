using System.Text;
using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

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

        while (!simulation.Finished)
        {
            Console.Clear();


            Console.WriteLine($"Ruch: {simulation.CurrentCreature.Name} idzie w kierunku {simulation.CurrentMoveName}");
            simulation.Turn();
            mapVisualizer.Draw();

            Console.WriteLine("\nStworzenia na mapie:");
            foreach (var creature in creatures)
            {
                Console.WriteLine($"{creature.Name} na pozycji {creature.Position}");
            }
            Console.WriteLine("\nNaciśnij Enter, aby przejść do następnego ruchu...");
            Console.ReadKey(true);
        }

        Console.WriteLine("\nSymulacja zakończona!");
        Console.ReadKey(true);
    }
}
