public abstract class Character
{
    public string Type { get; protected set; } = string.Empty;
    public abstract void DisplayType();
}

public class Warrior : Character
{
    public Warrior() { Type = "Warrior"; }
    public override void DisplayType() => Console.WriteLine("You are a mighty Warrior!");
}

public class Mage : Character
{
    public Mage() { Type = "Mage"; }
    public override void DisplayType() => Console.WriteLine("You are an intelligent Mage!");
}