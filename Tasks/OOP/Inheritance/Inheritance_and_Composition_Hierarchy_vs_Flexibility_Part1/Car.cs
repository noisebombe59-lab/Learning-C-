namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part1
{
    public class Car : Vehicle
    {
        public Car(string? model, Engine engine) : base(model, engine) { }

        public override void Drive()
        {
            Console.WriteLine($"Машина {Model} поехал. Мощность: {WorkEngine?.Power} л.с.");
        }
    }
}
