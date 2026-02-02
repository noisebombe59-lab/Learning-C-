namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part1
{
    public class Program
    {
        static void Main()
        {
            Engine truckEngine = new Engine(500);
            Engine carEngine = new Engine(232);

            List<Vehicle> garage = new List<Vehicle>();

            garage.Add(new Truck("Scania", truckEngine));
            garage.Add(new Car("Tesla Model S", carEngine));

            foreach (var v in garage)
            {
                v.Drive();
            }
            Console.ReadKey();
        }
    }
}
