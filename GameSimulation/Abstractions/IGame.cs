using GameSimulation.Models;

namespace GameSimulation.Abstractions
{
    public delegate void GameNotification(string message);

    public interface IGame
    {
        string Title { get; }
        GameState State { get; }
        void Install(HardwareSpecs hardware);
        void Launch(HardwareSpecs hardware, bool isOnline);
        void Save();
        void Load();
        void Stop();
        event GameNotification OnMessage;
    }
}