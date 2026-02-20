using System;
using GameSimulation.Logic;
using GameSimulation.Models;
using GameSimulation.Genres;
using GameSimulation.Abstractions;
using System.Collections.Generic;

namespace GameSimulation
{
    class Program
    {
        private const string ChoicePrompt = "Enter choice: ";

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Player user = new Player();
            // ... (тут залишається логіка циклу while з викликами SetupPC, AddGame, OpenLibrary)
        }
        
        // Методи SetupPC, AddGame, OpenLibrary, ManageGame та ReadInt 
        // копіюються сюди з попередньої версії коду.
    }
}