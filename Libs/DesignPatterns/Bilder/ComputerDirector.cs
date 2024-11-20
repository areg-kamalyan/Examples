using Core.Entitys;

namespace DesignPatterns.Bilder
{
    // Директор — управляет процессом построения
    public class ComputerDirector
    {
        private IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildCPU();
            _builder.BuildRAM();
            _builder.BuildStorage();
            _builder.BuildGraphicsCard();
            _builder.BuildScreenSize();
        }

        public Computer GetComputer()
        {
            return _builder.GetResult();
        }
    }
}
