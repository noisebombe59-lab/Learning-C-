namespace Polymorphism_Virtual_Methods_and_Overriding_part3
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string? separator = "-------------------------------------------------------";
                List<Vehicle> vehicles = new List<Vehicle>();
                Car car = new Car("Opel Astra", 140);
                Truck truck = new Truck("Volvo Atlant", 600, 15, 166);

                vehicles.Add(car);
                vehicles.Add(truck);

                foreach (var vehicle in vehicles)
                {
                    var isTruck = vehicle as Truck;

                    if (isTruck != null)
                    {
                        Console.WriteLine($"{isTruck.Model} Грузоподъемность: {isTruck.MaxCargoWeight} тонн");
                        Console.WriteLine(separator);
                    }
                    else
                    {
                        Console.WriteLine($"{vehicle.Model} не является объектом [Truck]");
                        Console.WriteLine(separator);
                    }
                    Console.WriteLine($"Модель: {vehicle.Model}, Налог: {vehicle.CalculateTax()}");
                    Console.WriteLine(separator);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}