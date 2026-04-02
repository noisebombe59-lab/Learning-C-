namespace LINQ_part3
{
    public class Program
    {
        static void Main()
        {
            var saturday = new DateTime(2026, 01, 03, 0, 0, 0);
            var sunday = new DateTime(2026, 01, 04, 0, 0, 0);

            var bankManager = new BankManager();

            var operation1 = new Operations("Цирк", 500);
            var operation2 = new Operations("парк", 700);
            var operation3 = new Operations("Театр", 900);
            var operation4 = new Operations("Дельфинарий", 1500);
            var operation5 = new Operations("Катамаран", 500);
            var operation6 = new Operations("Компьютерный клуб", 500);

            var transactions = new List<Transactions>
            {
               new Transactions(saturday, 1, 1, 1, 23900, operation1, "Развлечения"),
               new Transactions(sunday, 2, 2, 2, 10000, operation2, "Еда"),
               new Transactions(saturday, 3, 3, 3, 22500, operation3, "Транспорт"),
               new Transactions(sunday, 3, 3, 3, 33232, operation4, "Красота"),
               new Transactions(sunday, 3, 3, 3, 52500, operation5, "Фильмы"),
               new Transactions(saturday, 4, 4, 4, 222354222, operation6, "Здоровье"),
            };

            var customers = new List<Customer>
            {
              new Customer("Андреев Андрей Андреевич", 21, 1, 10000 ),
              new Customer("Антонов Антон Антонович", 22, 2, 20000 ),
              new Customer("Олегов Олег Олегович", 23, 3, 30000 ),
              new Customer("Александров Александр Александрович", 24, 4, 40000 ),
            };

            bankManager.AddTransactions(transactions);
            bankManager.AddCustomers(customers);

            bankManager.GoldenClientReport();
            bankManager.FindSuspiciosOperations(customers, transactions);
            bankManager.GetReportBySpendingCategory();
            bankManager.GetTotalTransactionForWeekend();
            bankManager.ReportByAccountType();
        }
    }
}