using GameSimulation.Abstractions;
using GameSimulation.Models;

namespace GameSimulation.Genres
{
    public abstract class PCGame : BaseGame
    {
        public HardwareSpecs MinReq { get; set; } // Вимоги до заліза

        public override void Install(HardwareSpecs hardware)
        {
            if (State != GameState.Idle) { Notify("Already installed."); return; }
            if (hardware.HDD < MinReq.HDD) { Notify("Installation failed: Not enough HDD."); return; }
            hardware.HDD -= MinReq.HDD;
            State = GameState.Installed;
            Notify("Installation complete.");
        }

        public override void Launch(HardwareSpecs h, bool isOnline)
        {
            if (State == GameState.Idle) { Notify("Error: Install the game first."); return; }
            if (h.CPU < MinReq.CPU || h.RamGb < MinReq.RamGb || h.GpuPower < MinReq.GpuPower) 
            { 
                Notify("Error: PC performance is too low."); 
                return; 
            }
            State = GameState.Running;
            Notify("Launched on Windows PC.");
        }
    }
}