namespace LINQ_part2
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "---------------------------------------------------------------------";

                var logisticsOperator = new LogisticsOperator();

                var deliveryOrder1 = new DeliveryOrder("Refrejerator", 10000m, 1, "Ожидает", 2, 180, 1, "Портофино");
                var deliveryOrder2 = new DeliveryOrder("Microwave", 1000m, 2, "Ожидает", 3, 55, 2, "Мюнхен");
                var deliveryOrder3 = new DeliveryOrder("Couch", 15000m, 3, "Ожидает", 1, 90, 3, "Стокгольм");

                var vehicle1 = new Vehicle("КАМАЗ", 20000, true, 1, 1);
                var vehicle2 = new Vehicle("VOLVO", 15000, true, 2, 2);
                var vehicle3 = new Vehicle("MERCEDES", 10000, true, 3, 3);

                var driver1 = new Drivers("Иванов Иван Иванович", "C1", true, 1);
                var driver2 = new Drivers("Антонов Антон Антонович", "B", true, 2);
                var driver3 = new Drivers("Сереев Сергей Сергеевич", "C", true, 3);

                var forbiddenCity1 = "Киев";
                var forbiddenCity2 = "Краков";
                var forbiddenCity3 = "Мадрид";
                var forbiddenCity4 = "Штуттгард";
                var forbiddenCity5 = "Стокгольм";

                logisticsOperator.AddToBlackList(forbiddenCity1);
                logisticsOperator.AddToBlackList(forbiddenCity2);
                logisticsOperator.AddToBlackList(forbiddenCity3);
                logisticsOperator.AddToBlackList(forbiddenCity4);
                logisticsOperator.AddToBlackList(forbiddenCity5);

                logisticsOperator.AddDriver(driver1);
                logisticsOperator.AddDriver(driver2);
                logisticsOperator.AddDriver(driver3);

                logisticsOperator.AddVehicle(vehicle1);
                logisticsOperator.AddVehicle(vehicle2);
                logisticsOperator.AddVehicle(vehicle3);

                logisticsOperator.AddOrder(deliveryOrder1);
                logisticsOperator.AddOrder(deliveryOrder2);
                logisticsOperator.AddOrder(deliveryOrder3);

                logisticsOperator.GetAvailableCitiesReport();

                Console.WriteLine(separator);
                logisticsOperator.GroupByDeliveryStatus();
                logisticsOperator.GetRideReport();
            }
            catch (ArgumentOutOfRangeException ex)
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