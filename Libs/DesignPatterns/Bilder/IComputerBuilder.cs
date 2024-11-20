using Core.Entitys;

namespace DesignPatterns.Bilder
{
    public interface IComputerBuilder
    {
        void BuildCPU();
        void BuildRAM();
        void BuildStorage();
        void BuildGraphicsCard();
        void BuildScreenSize();
        Computer GetResult();
    }
}
