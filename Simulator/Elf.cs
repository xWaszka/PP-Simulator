﻿namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int singCount = 0;

    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public int Agility
    {
        get => agility;
        init
        {
            if (value < 0) agility = 0;
            else if (value > 10) agility = 10;
            else agility = value;
        }
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public void Sing()
    {
        singCount++;
        Console.WriteLine($"{Name} is singing.");
        if (singCount % 3 == 0 && agility < 10)
        {
            agility++;
        }
    }
    public override int Power => 8 * Level + 2 * Agility;
}