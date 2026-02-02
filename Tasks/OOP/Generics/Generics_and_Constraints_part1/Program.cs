namespace Generics_and_Constraints_part1
{
    public class Program
    {
        static void Main()
        {
            const string separator = "-----------------------------------------------";

            var dataCellString = new DataCell<string>("[Строка] Тестируем вывод Generic");  
            var dataCellInt = new DataCell<int>(10);

            var refValidator1 = new RefValidator<string>("Текст на проверку ссылочного типа");
            bool checkResult = refValidator1.IsNull();
            
            var entityFactory = new EntityFactory<User>();
            User newUser = entityFactory.CreateNew();

            var resetter = new Resetter<int>(500);
            var newUserForReset = new Resetter<User>(new User());

            Console.WriteLine($"{dataCellInt.GetValue()}");
            Console.WriteLine(separator);

            Console.WriteLine($"{dataCellString.GetValue()}");
            Console.WriteLine(separator);

            Console.WriteLine(checkResult);
            Console.WriteLine(separator);

            Console.WriteLine(newUser.Name);
            Console.WriteLine(separator);

            Console.WriteLine(resetter.GetCurrentValue());
            Console.WriteLine(separator);

            resetter.Reset();

            Console.WriteLine(resetter.GetCurrentValue());
            Console.WriteLine(separator);

            newUserForReset.Reset();
            Console.WriteLine(newUserForReset.GetCurrentValue() == null);
            Console.ReadKey();
        }
    }
}