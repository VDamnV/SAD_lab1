using GameSimulation.Abstractions;
using GameSimulation.Models;

namespace GameSimulation.Genres
{
    // Клас для онлайн-казино (браузерна гра)
    public class OnlineCasino : BaseGame
    {
        public OnlineCasino(string title)
        {
            Title = title;
        }

        // Казино не потребує інсталяції
        public override void Install(HardwareSpecs hardware)
        {
            Notify("Notice: This is a browser game and does not require installation.");
        }

        // Запуск вимагає лише підключення до мережі
        public override void Launch(HardwareSpecs hardware, bool isOnline)
        {
            if (!isOnline)
            {
                Notify("Connection Error: Internet access is required to play Trash Slots.");
                return;
            }

            State = GameState.Running;
            Notify("Game opened successfully in your web browser.");
        }
    }
}