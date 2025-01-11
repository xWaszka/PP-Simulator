namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int singCount = 0;
    public override char Symbol => 'E';

    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    }

    public void Sing()
    {
        singCount++;
        if (singCount % 3 == 0 && agility < 10)
        {
            agility++;
        }
    }
    public override string Info => $"{Name} [{Level}][{Agility}]";
    public override int Power => 8 * Level + 2 * Agility;
}
