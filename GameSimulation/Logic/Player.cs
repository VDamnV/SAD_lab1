using System.Collections.Generic;
using GameSimulation.Abstractions;
using GameSimulation.Models;

namespace GameSimulation.Logic
{
    public class Player
    {
        public HardwareSpecs MyPC { get; set; } = new HardwareSpecs();
        public bool IsOnline { get; set; } = true;
        public List<IGame> Library { get; } = new List<IGame>();
        private IGame _active = null;

        public void Play(IGame g)
        {
            if (_active != null) { System.Console.WriteLine("Close current game first!"); return; }
            g.Launch(MyPC, IsOnline);
            if (g.State == GameState.Running) _active = g;
        }

        public void Stop() { if (_active != null) { _active.Stop(); _active = null; } }
    }
}