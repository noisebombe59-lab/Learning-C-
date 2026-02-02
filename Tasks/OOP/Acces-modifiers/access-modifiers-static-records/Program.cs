namespace access_modifiers_static_records
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var accountNumber = 1;
                var account1 = new BankAccount(accountNumber);

                Console.Write("Введите сумму, которую хотите положить на счет: ");

                var deposit = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(deposit))
                {
                    Console.WriteLine("Значение для депозита не может быть пустым или состоять из пробелов");
                    return;
                }
                if (decimal.TryParse(deposit, out decimal amountToDeposit1))
                {
                    account1.Deposit(amountToDeposit1);
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    Console.WriteLine($"Аккаунт: ({accountNumber})\nДенег на балансе: ({account1.Balance})\nВнесенная сумма: ({amountToDeposit1})");
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                }

                Console.Write("Введите сумму, которую хотите снять: ");

                var withdraw = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(withdraw))
                {
                    Console.WriteLine("Значение для снятия средств не может быть пустым или состоять из пробелов");
                    return;
                }
                if (decimal.TryParse(withdraw, out decimal amountToWithdraw1))
                {
                    account1.Withdraw(amountToWithdraw1);
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    Console.WriteLine($"Аккаунт: ({accountNumber})\nДенег на балансе: ({account1.Balance})\nВыведенная сумма: ({amountToWithdraw1})");
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                }

                accountNumber++;
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "balance")
                {
                    Console.WriteLine("Ошибка: Баланс не может быть отрицательным\n");
                }
                else if (ex.ParamName == "accountNumber")
                {
                    Console.WriteLine("Ошибка: Номер аккаунта не может быть отрицательным или равен 0\n");
                }
                else if (ex.ParamName == "insufficientFunds")
                {
                    Console.WriteLine($"Ошибка: Недостаточно средств на счету. Минимальный баланс на счету должен остаться 100\n");
                }
                else if (ex.ParamName == "amountNegativeOrZero")
                {
                    Console.WriteLine($"Ошибка: Сумма снятия средств не может быть отрицательной или равно 0\n");
                }
                else if (ex.ParamName == "amountToDeposit")
                {
                    Console.WriteLine("Ошибка: Сумма депозита не может быть отрицательной или равна 0\n");
                }
                else
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.ParamName}\n");
                    Console.ReadKey();
                }
            }

            try
            {
                var person1 = new Person();
                var person2 = person1 with { FirstName = "Антон", Age = 44 };

                Console.WriteLine($"Данные аккаунта person1: {person1}");
                Console.WriteLine($"Данные аккаунта person2: {person2}\n");

                var transaction1 = new Transaction { Amount = 1000, Description = "Молоко 1л.", Date = DateTime.Today };
                var transaction2 = transaction1 with { Amount = 200, Description = "Хлеб (белый) 2шт", Date = DateTime.Now };

                Console.WriteLine($"[Данные о транзакции 1]: {transaction1}");
                Console.WriteLine($"[Данные о транзакции 2]: {transaction2}");
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "FirstName")
                {
                    Console.WriteLine($"Ошибка: Имя не может быть пустым");
                }
                else if (ex.ParamName == "LastName")
                {
                    Console.WriteLine($"Ошибка: фамилия не может быть пустой");
                }
                else
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.ParamName}");
                    Console.ReadKey();
                }
            }
        }
    }
}