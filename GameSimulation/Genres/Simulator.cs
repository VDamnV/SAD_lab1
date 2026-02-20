using GameSimulation.Abstractions;
using GameSimulation.Models;

namespace GameSimulation.Genres
{
    // Клас для симуляторів
    public class Simulator : PCGame
    {
        public Simulator(string title, HardwareSpecs requirements)
        {
            Title = title;
            MinReq = requirements;
        }

        // Специфічна функція симулятора — використання керма
        public void UseWheel()
        {
            if (State == GameState.Running)
            {
                Notify("Steering wheel active! Handling is now more realistic.");
            }
            else
            {
                // Попередження, якщо гра не запущена
                Notify("Error: You must start the simulation before connecting the wheel.");
            }
        }
    }
}