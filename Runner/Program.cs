namespace Runner;

using global::Simulator.Maps;
using global::Simulator;


internal class Program
{
    private static void Main(string[] args)
    {
        Lab6a();
    }
    public static void Lab6a()
    {
        Console.WriteLine("HUNT TEST\n");
        var orc = new Orc("Gorbag", rage: 7);
        Console.WriteLine(orc.Greeting());
        for (int i = 0; i < 10; i++)
        {
            orc.Hunt();
            Console.WriteLine(orc.Greeting());
        }

        Console.WriteLine("\nSING TEST\n");
        var elf = new Elf("Legolas", agility: 2);
        Console.WriteLine(elf.Greeting());
        for (int i = 0; i < 10; i++)
        {
            elf.Sing();
            Console.WriteLine(elf.Greeting());
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
                orc,
                elf,
                new Orc("Morgash", 3, 8),
                new Elf("Elandor", 5, 3)
            };

        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }

        Console.WriteLine("\nDIRECTIONS TEST\n");

        Direction[] directionsOrc = new Direction[] { Direction.Up, Direction.Down, Direction.Left };
        string[] resultOrc = orc.Go(directionsOrc);
        Console.WriteLine("Directions Orc:");
        foreach (var direction in resultOrc)
        {
            Console.WriteLine(direction);
        }

        string directionStringElf = "Up, Down, Left";
        string[] directionsFromStringElf = elf.Go(directionStringElf);
        Console.WriteLine("Directions Elf:");
        foreach (var direction in directionsFromStringElf)
        {
            Console.WriteLine(direction);
        }
    }


}
