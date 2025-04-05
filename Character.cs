public abstract class Character
{
    public string Type { get; protected set; } = string.Empty;//Characters type
    public int Health { get; set; }//Characters health which is defined by its classes
    public abstract void DisplayType();//Abstract method to display the specific messege
}

public class Warrior : Character //Warrior class inherits from the character
{
    public Warrior() 
    {
        Type = "Warrior";
        Health = 200;
    }

    public override void DisplayType() => Console.WriteLine("You are a mighty Warrior!");
}

//Mage class inherits from the character
public class Mage : Character
{
    public Mage() 
    {
        Type = "Mage";
        Health = 100;
    }

    public override void DisplayType() => Console.WriteLine("You are an intelligent Mage!");
}