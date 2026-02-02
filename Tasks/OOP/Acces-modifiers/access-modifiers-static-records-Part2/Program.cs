namespace access_modifiers_static_records_Part2
{
    public class Program
    {
        static void Main()
        {
            int doorLevel = 1;

            var director = new Pass(OwnerName: "Игорь", Level: 5, ExpiryDate: new DateTime(2027, 05, 11));
            var trainee = new Pass(OwnerName: "Андрей", Level: 1, ExpiryDate: new DateTime(2026, 01, 09));
            var firedEmployee = new Pass(OwnerName: "Сергей", Level: 5, ExpiryDate: new DateTime(2026, 01, 07));

            var test1 = SecuritySystem.CanAccess(director, doorLevel);
            var test2 = SecuritySystem.CanAccess(trainee, doorLevel);
            var test3 = SecuritySystem.CanAccess(firedEmployee, doorLevel);

            Console.WriteLine($"Тест1: {test1}");
            Console.WriteLine($"Тест2: {test2}");
            Console.WriteLine($"Тест3: {test3}");

            SecuritySystem.ShowStats();
        }
    }
}