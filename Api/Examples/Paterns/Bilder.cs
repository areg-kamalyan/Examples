using Core.Entitys;
using DesignPatterns.Bilder;

namespace Examples.Paterns
{
    internal class Bilder
    {
        public static void Use()
        {
            // Строим игровой компьютер
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            ComputerDirector director = new ComputerDirector(gamingBuilder);
            director.Construct();
            Computer gamingComputer = director.GetComputer();

            Console.WriteLine("Gaming Computer: \n" + gamingComputer);

            // Строим офисный компьютер
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            director = new ComputerDirector(officeBuilder);
            director.Construct();
            Computer officeComputer = director.GetComputer();

            Console.WriteLine("\nOffice Computer: \n" + officeComputer);
        }
    }
}
