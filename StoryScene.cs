using System;
using System.Collections.Generic;

public class StoryScene
{
    public string Description { get; set; } = string.Empty;
    public Dictionary<string, int> Choices { get; set; } = new Dictionary<string, int>();
    public void DisplayScene()
    {
        Console.WriteLine(Description);
        Console.WriteLine("1. Enter the forest (-10 health)");
        Console.WriteLine("2. Climb the mountain (-20 health)");
    }
}
