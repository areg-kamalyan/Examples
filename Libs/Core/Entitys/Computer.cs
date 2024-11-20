namespace Core.Entitys
{
    public class Computer
    {
        public string? CPU { get; set; }
        public string? RAM { get; set; }
        public string? Storage { get; set; }
        public string? GraphicsCard { get; set; }
        public string? ScreenSize { get; set; }

        public override string ToString()
        {
            return $"Computer Specifications: \n" +
                   $"CPU: {CPU}\n" +
                   $"RAM: {RAM}\n" +
                   $"Storage: {Storage}\n" +
                   $"Graphics Card: {GraphicsCard}\n" +
                   $"Screen Size: {ScreenSize}";
        }
    }
}
