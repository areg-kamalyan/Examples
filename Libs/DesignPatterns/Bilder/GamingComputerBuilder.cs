using Core.Entitys;

namespace DesignPatterns.Bilder
{
    // Конкретный строитель для игрового компьютера
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void BuildCPU()
        {
            _computer.CPU = "Intel Core i9 12900K";
        }

        public void BuildRAM()
        {
            _computer.RAM = "32 GB DDR5";
        }

        public void BuildStorage()
        {
            _computer.Storage = "1 TB SSD";
        }

        public void BuildGraphicsCard()
        {
            _computer.GraphicsCard = "NVIDIA GeForce RTX 4090";
        }

        public void BuildScreenSize()
        {
            _computer.ScreenSize = "27 inch 4K";
        }

        public Computer GetResult()
        {
            return _computer;
        }
    }
}
