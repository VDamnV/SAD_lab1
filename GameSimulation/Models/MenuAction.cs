using System;

namespace GameSimulation.Models
{
    // Допоміжний клас для динамічного формування меню в консолі
    public class MenuAction
    {
        public string Name { get; set; }
        public Action Act { get; set; }
        public MenuAction(string name, Action act) { Name = name; Act = act; }
    }
}