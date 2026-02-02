namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part4
{
    public class Computer
    {
        public string Brand { get; init; }
        public Processor Cpu { get; init; }

        public Computer(string brand, Processor cpu)
        {
            if (cpu == null)
                throw new ArgumentNullException("Ошибка, передан пустой объект", nameof(cpu));

            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentNullException("Название бренда обязательно", nameof(brand));

            Brand = brand;
            Cpu = cpu;
        }
    }
}
