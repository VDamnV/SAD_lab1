namespace GameSimulator.Models;

public class PC
{
    public bool IsConnectedToInternet { get; set; }
    public SystemRequirements Specs { get; set; }

    public PC(SystemRequirements specs, bool hasInternet)
    {
        Specs = specs;
        IsConnectedToInternet = hasInternet;
    }
}