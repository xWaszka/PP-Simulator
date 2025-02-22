﻿namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int huntCount = 0;
    public override char Symbol => 'O';

    public Orc() : base() { }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    }

    public void Hunt()
    {
        huntCount++;
        if (huntCount % 2 == 0 && rage < 10)
        {
            rage++;
        }
    }
    public override string Info => $"{Name} [{Level}][{Rage}]";
    public override int Power => 7 * Level + 3 * Rage;
}
