using Simulator.Maps;

namespace Simulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Lab5b();
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

            var pointf = new Point(9, 9);
            Console.WriteLine($"Czy prostokąt 1 zawiera punkt {pointf}? {rect1.Contains(pointf)}");

            var rect3 = new Rectangle(1, 1, 1, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }
    public static void Lab5b()
    {
        try
        {
            var map = new SmallSquareMap(10);
            Console.WriteLine($"Mapa o rozmiarze: {map.Size}");

            // testy punktów
            var pointOutside = new Point(11, 12);
            Console.WriteLine($"Punkt: {pointOutside}");
            Console.WriteLine($"Czy punkt należy do mapy? {map.Exist(pointOutside)}");

            var pointInside = new Point(5, 5);
            Console.WriteLine($"Punkt: {pointInside}");
            Console.WriteLine($"Czy punkt należy do mapy? {map.Exist(pointInside)}");

            // test metod next/nextDiagonal
            var nextPoint = map.Next(pointInside, Direction.Up);
            Console.WriteLine($"Następny punkt (Up): {nextPoint}");

            nextPoint = map.Next(pointInside, Direction.Right);
            Console.WriteLine($"Następny punkt (Right): {nextPoint}");

            nextPoint = map.NextDiagonal(pointInside, Direction.Up);
            Console.WriteLine($"Następny punkt (Diagonal Up): {nextPoint}");

            nextPoint = map.NextDiagonal(pointInside, Direction.Down);
            Console.WriteLine($"Następny punkt (Diagonal Down): {nextPoint}");


            // test wyjścia poza mapę
            var badPoint = new Point(9, 9);
            nextPoint = map.Next(badPoint, Direction.Right);
            Console.WriteLine($"Punkt po próbie wyjścia poza mapę (Next): {nextPoint}");

            nextPoint = map.NextDiagonal(badPoint, Direction.Right);
            Console.WriteLine($"Punkt po próbie wyjścia poza mapę (Diagonal): {nextPoint}");

            // test zbyt dużej mapy
            try
            {
                var invalidMap = new SmallSquareMap(25);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            // test zbyt małej mapy
            try
            {
                var invalidMap = new SmallSquareMap(4);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            // test punktów ujemnych
            var negativePoint = new Point(-1, -1);
            Console.WriteLine($"Punkt: {negativePoint}");
            Console.WriteLine($"Czy punkt należy do mapy? {map.Exist(negativePoint)}");

        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }



}