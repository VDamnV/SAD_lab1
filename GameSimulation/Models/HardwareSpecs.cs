namespace GameSimulation.Models
{
    public class HardwareSpecs
    {
        public int CPU { get; set; } // Потужність процесора
        public int RamGb { get; set; } // Об'єм ОЗП
        public int GpuPower { get; set; } // Потужність відеокарти
        public double HDD { get; set; } // Вільне місце на диску
    }
}