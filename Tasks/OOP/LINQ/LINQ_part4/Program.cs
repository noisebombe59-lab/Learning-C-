namespace LINQ_part4
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var sortingCentre = new SortingСenter();

                var cargos = new List<Cargo>
            {
                new Cargo(1, 500, 1000, 1, 1.5, "Food", "Critical", "Рим"),
                new Cargo(2, 508, 2000, 2, 2.5, "Medecine", "Critical", "Милан"),
                new Cargo(3, 788, 3000, 3, 3.5, "Tools", "Critical", "Денвер"),
                new Cargo(4, 355, 4000, 4, 4.5, "Furniture", "Critical", "Вашингтон"),
                new Cargo(5, 550, 5000, 5, 5.5, "Post", "Critical", "Краков"),
                new Cargo(6, 720, 6000, 6, 6.5, "Post", "Critical", "Киев"),
                new Cargo(7, 820, 7000, 7, 7.5, "Post", "Critical", "Донецк")
            };

                var vehicles = new List<Vehicle>
            {
                new Vehicle(1, 500, 1, "Ready", "Volvo"),
                new Vehicle(2, 410, 2, "Not ready", "Reno"),
                new Vehicle(3, 520, 3, "Ready", "KAMAZ"),
                new Vehicle(4, 330, 4, "IsAvailable", "Mercedes"),
                new Vehicle(5, 540, 5, "Ready", "Bilaz"),
                new Vehicle(6, 350, 6, "IsAvailable", "Scania"),
                new Vehicle(7, 660, 7, "Ready", "Audi")
            };

                var cities = new List<Cities>
                {
                    new Cities(1, "Милан", "Италия"),
                    new Cities(2, "Берлин", "Германия"),
                    new Cities(3, "Бали", "Индонезия"),
                    new Cities(4, "Иерусалим", "Израиль"),
                    new Cities(5, "Каир", "Египет")
                };

                var deliveries = new List<Delivery>
                {
                    new Delivery(new DateTime(2026,03,22), 1, cargos),
                    new Delivery(new DateTime(2026,03,22), 2, cargos),
                    new Delivery(new DateTime(2026,04,10), 3, cargos),
                    new Delivery(new DateTime(2026,04,11), 4, cargos),
                    new Delivery(new DateTime(2026,04,12), 5, cargos),
                };

                sortingCentre.AddVehicle(vehicles);
                sortingCentre.AddCargo(cargos);
                sortingCentre.AddCity(cities);
                sortingCentre.AddDeliveries(deliveries);

                sortingCentre.GetRouteSheetReport();
                sortingCentre.GetTopFiveReport();
                sortingCentre.GetVehicleForCargoReport();
                sortingCentre.GetPolicyLimitsReport();
                sortingCentre.GetUniqueCitiesReport();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}