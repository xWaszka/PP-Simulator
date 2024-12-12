﻿namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    private int level = 1;
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature()
    {
    }
    public string Name
    {
        get => name;
        init
        {
            string trimmed = value.Trim();
            if (trimmed.Length < 3)
                trimmed = trimmed.PadRight(3, '#');

            if (trimmed.Length > 25)
            {
                trimmed = trimmed.Substring(0, 25).TrimEnd();
                if (trimmed.Length < 3)
                    trimmed = trimmed.PadRight(3, '#');
            }

            if (char.IsLower(trimmed[0]))
                trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1);

            name = trimmed;
        }
    }
    public int Level
    {
        get => level;
        init
        {
            if (value < 1) level = 1;
            else if (value > 10) level = 10;
            else level = value;
        }
    }
    public void Upgrade()
    {
        if (level < 10)
            level++;
    }
    public string Info => $"Name: {Name}, Level: {Level}";
    public void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name}, level {Level}.");
    }
}
