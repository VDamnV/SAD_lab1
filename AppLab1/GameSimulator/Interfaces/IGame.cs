namespace GameSimulator.Interfaces;

public interface IGame
{
    string Title { get; }
    string Genre { get; }
    bool IsRunning { get; }
    
    // Подія для сповіщення UI про зміну стану (вимога лабораторної)
    event Action<string> OnGameStateChanged;

    void Start(Models.PC computer);
    void Stop();
}