﻿using SimConsole;
using Simulator.Maps;

public class MapVisualizer
{
    private readonly Map _map;
    private const int CellWidth = 3;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();
        DrawTopBorder();
        DrawRows();
        DrawBottomBorder();
    }

    private void DrawTopBorder()
    {
        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            DrawHorizontalLine();
            Console.Write(Box.TopMid);
        }
        DrawHorizontalLine();
        Console.WriteLine(Box.TopRight);
    }

    private void DrawBottomBorder()
    {
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            DrawHorizontalLine();
            Console.Write(Box.BottomMid);
        }
        DrawHorizontalLine();
        Console.WriteLine(Box.BottomRight);
    }

    private void DrawRows()
    {
        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            DrawRow(y);
            if (y > 0)
            {
                DrawRowSeparator();
            }
        }
    }

    private void DrawRow(int y)
    {
        Console.Write(Box.Vertical);
        for (int x = 0; x < _map.SizeX; x++)
        {
            DrawCell(x, y);
            if (x < _map.SizeX - 1)
            {
                Console.Write(Box.Vertical);
            }
        }
        Console.WriteLine(Box.Vertical);
    }

    private void DrawRowSeparator()
    {
        Console.Write(Box.MidLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            DrawHorizontalLine();
            Console.Write(Box.Cross);
        }
        DrawHorizontalLine();
        Console.WriteLine(Box.MidRight);
    }

    private void DrawCell(int x, int y)
    {
        var creatures = _map.At(new Point(x, y));
        string symbol = GetCellSymbol(creatures);
        Console.Write($" {symbol} ");
    }

    public static string GetCellSymbol(List<IMappable> mappables)
    {
        if (mappables.Count > 1)
        {
            return "X";
        }
        return mappables.Count == 1 ? mappables[0].Symbol.ToString() : " ";
    }

    private static void DrawHorizontalLine()
    {
        for (int i = 0; i < CellWidth; i++)
        {
            Console.Write(Box.Horizontal);
        }
    }
}
