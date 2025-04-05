public abstract class Character
{
    public string Type { get; protected set; } = string.Empty;
    public int Health { get; set; }
    public abstract void DisplayType();
}

public class Warrior : Character
{
    public Warrior() 
    {
        Type = "Warrior";
        Health = 200;
    }

    public override void DisplayType() => Console.WriteLine("You are a mighty Warrior!");
}

public class Mage : Character
{
    public Mage() 
    {
        Type = "Mage";
        Health = 100;
    }

    public override void DisplayType() => Console.WriteLine("You are an intelligent Mage!");
}