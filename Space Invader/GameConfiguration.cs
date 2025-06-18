using Newtonsoft.Json;

namespace Space_Invaders;

public class GameConfiguration
{
    public int Height { get; init; }
    public int Width { get; init; }
    public string Title { get; init; }

    public GameConfiguration(string jsonPath)
    {
        string jsonString = File.ReadAllText(jsonPath);
        JsonConvert.PopulateObject(jsonString, this);
    }
}