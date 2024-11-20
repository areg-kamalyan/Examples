using Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bilder
{
    // Конкретный строитель для офисного компьютера
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void BuildCPU()
        {
            _computer.CPU = "Intel Core i5 11600";
        }

        public void BuildRAM()
        {
            _computer.RAM = "16 GB DDR4";
        }

        public void BuildStorage()
        {
            _computer.Storage = "500 GB SSD";
        }

        public void BuildGraphicsCard()
        {
            _computer.GraphicsCard = "Integrated Intel UHD";
        }

        public void BuildScreenSize()
        {
            _computer.ScreenSize = "24 inch Full HD";
        }

        public Computer GetResult()
        {
            return _computer;
        }
    }
}
