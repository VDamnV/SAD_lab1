using GameSimulation.Abstractions;
using GameSimulation.Models;

namespace GameSimulation.Genres
{
    // Клас для стратегічних ігор
    public class Strategy : PCGame
    {
        // Конструктор ініціалізує назву та мінімальні вимоги
        public Strategy(string title, HardwareSpecs requirements)
        {
            Title = title;
            MinReq = requirements;
        }
    }
}