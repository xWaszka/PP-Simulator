namespace Simulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }

    public static void Lab5a()
    {
        try
        {
            var rect1 = new Rectangle(1, 1, 5, 5);
            Console.WriteLine($"Prostokąt 1: {rect1.ToString()}");

            var p1 = new Point(3, 3);
            var p2 = new Point(7, 7);
            var rect2 = new Rectangle(p1, p2);
            Console.WriteLine($"Prostokąt 2: {rect2.ToString()}");

            var point = new Point(4, 4);
            Console.WriteLine($"Czy prostokąt 1 zawiera punkt {point}? {rect1.Contains(point)}");

            var rect3 = new Rectangle(1, 1, 1, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }


}