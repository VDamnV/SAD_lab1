using GameSimulation.Abstractions;
using GameSimulation.Models;
using GameSimulation.Genres;

namespace GameSimulation.Abstractions
{
    public abstract class BaseGame : IGame
    {
        public string Title { get; protected set; }
        public GameState State { get; protected set; } = GameState.Idle;
        protected bool HasSaveData = false;

        public event GameNotification OnMessage;
        protected void Notify(string msg) => OnMessage?.Invoke($"[{Title}]: {msg}");

        public abstract void Install(HardwareSpecs hardware);
        public abstract void Launch(HardwareSpecs hardware, bool isOnline);
        
        public void Save() // Спільна логіка збереження
        {
            if (State != GameState.Running) { Notify("Error: Game is not running."); return; }
            HasSaveData = true; 
            Notify("Progress saved successfully.");
        }

        public void Load() // Спільна логіка завантаження
        {
            if (State != GameState.Running) { Notify("Error: Game is not running."); return; }
            if (!HasSaveData) { Notify("Error: No save data found."); return; }
            Notify("Progress loaded.");
        }

        public virtual void Stop()
        {
            if (State == GameState.Running)
            {
                State = (this is OnlineCasino) ? GameState.Idle : GameState.Installed;
                Notify("Game stopped.");
            }
        }
    }
}