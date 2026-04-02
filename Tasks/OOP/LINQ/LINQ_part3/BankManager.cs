namespace LINQ_part3
{
    public class BankManager
    {
        private readonly List<Transactions> _transactions = new();
        private readonly List<Customer> _customers = new();

        public IReadOnlyList<Transactions> Transactions => _transactions.AsReadOnly();
        public IReadOnlyList<Customer> Customers => _customers.AsReadOnly();

        public void AddCustomers(IEnumerable<Customer> customers)
        {
            _customers.AddRange(customers);
        }

        public void AddTransactions(IEnumerable<Transactions> transactions)
        {
            _transactions.AddRange(transactions);
        }

        public string SetCustomerStatus(decimal amount)
        {
            if (amount > 50000) return "Платиновый";
            if (amount >= 20000 && amount <= 50000) return "Золотой";
            return "Обычный";
        }

        public void ReportByAccountType()
        {
            var reportByAccountType = _transactions
                .GroupBy(g => g.CustomerId)
                .Select(group => new
                {
                    CusId = group.Key,
                    CustomerStatus = SetCustomerStatus(group.Sum(s => s.TransactionTotalAmount)),
                    TotalAmount = group.Sum(s => s.TransactionTotalAmount),
                });

            var finalStats = reportByAccountType
                .GroupBy(g => g.CustomerStatus)
                .Select(group => new
                {
                    AccountType = group.Key,
                    Count = group.Count(),
                    TransactionsAmount = group.Sum(s => s.TotalAmount)
                });

            Console.WriteLine("Статистика по типам счетов:");
            foreach (var item in finalStats)
            {
                Console.WriteLine($"Тип счета: {item.AccountType}");
                Console.WriteLine($"Количество клиентов в категории {item.AccountType} - {item.Count}");
                Console.WriteLine($"Общая сумма трать в категории {item.AccountType} - {item.TransactionsAmount}");
                Console.WriteLine(new string('-', 50));
            }
        }

        public void GetTotalTransactionForWeekend()
        {
            var getTotalTransactionForWeekend = _transactions
                .Where(w => w.TransactionTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday);

            Console.WriteLine("Список всех транзакций, которые были в субботу/воскресенье:\n");
            GetReportBySpendingCategory(getTotalTransactionForWeekend);
        }

        public void GetReportBySpendingCategory(IEnumerable<Transactions>? dataSourse = null)
        {
            var currentData = dataSourse ?? (_transactions as IEnumerable<Transactions>);

            if (!currentData.Any())
            {
                Console.WriteLine("Нет данных для формирования отчета");
                return;
            }

            var spendingCategoryList = currentData
                .Join(
                _customers,
                transactionId => transactionId.CustomerId,
                customerId => customerId.CustomerId,
                (transactionId, customerId) => new
                {
                    transactionId = transactionId.CustomerId,
                    transactionCount = transactionId.TransactionCount,
                    customerId = customerId.CustomerId,
                    customerName = customerId.CustomerFullName,
                    spendingCategory = transactionId.SpendingCategory,
                    spendingAmount = transactionId.TransactionTotalAmount
                })
                .GroupBy(g => g.customerId)
                .Select(group => new
                {
                    CustomerId = group.Key,
                    CustomerName = group.First().customerName ?? "Неизвестный клиент",
                    MoneySpended = group.Sum(s => s.spendingAmount),
                    SpendingCategory = group.OrderByDescending(o => o.spendingCategory).ThenByDescending(t => t.spendingAmount)
                });

            Console.WriteLine("Отчет по тратам в каждой категории:\n");
            foreach (var item in spendingCategoryList)
            {
                Console.WriteLine($"ID клиента: {item.CustomerId}");
                Console.WriteLine($"Имя клиента: {item.CustomerName}");
                Console.WriteLine("Детализация трат:");

                foreach (var cat in item.SpendingCategory)
                {
                    Console.WriteLine($"    * {cat.spendingCategory}: {cat.spendingAmount}");
                }

                Console.WriteLine($"ИТОГО ПОТРАЧЕНО: {item.MoneySpended}");
                Console.WriteLine(new string('-', 50));
            }
        }

        public void GoldenClientReport()
        {
            var start = new DateTime(2026, 01, 01, 0, 0, 0);
            var end = new DateTime(2026, 05, 01, 0, 0, 0).AddDays(1).AddSeconds(-1);

            var goldenClientReport = _transactions
                .Where(w => w.TransactionTime >= start && w.TransactionTime <= end)
                .Join(
                _customers,
                    transId => transId.CustomerId,
                    cusId => cusId.CustomerId,
                    (transId, cusId) => new
                    {
                        customerId = cusId.CustomerId,
                        customerName = cusId.CustomerFullName,
                        transactionTotalAmount = transId.TransactionTotalAmount,
                    })
                .GroupBy(g => g.customerId)
                .Select(group => new
                {
                    Id = group.Key,
                    FullName = group.First().customerName ?? "Неизвестный клиент",
                    TotalSpent = group.Sum(s => s.transactionTotalAmount),
                })
                .OrderByDescending(o => o.TotalSpent)
                .Take(3);

            Console.WriteLine("Топ - 3 'Золотых клиента':\n");

            foreach (var element in goldenClientReport)
            {
                Console.WriteLine($"ID: {element.Id}, Клиент: {element.FullName}, Общая сумма трат: {element.TotalSpent}");
            }
            Console.WriteLine();
        }

        public void FindSuspiciosOperations(IEnumerable<Customer> customers, IEnumerable<Transactions> transactions)
        {
            var averageForAllTransactions = transactions
                .Average(s => s.TransactionTotalAmount);

            var findSuspiciosOperations = transactions
                .Where(w => w.TransactionTotalAmount > averageForAllTransactions * 5)
                .Join(
                    customers,
                    suspectTransId => suspectTransId.CustomerId,
                    suspectCusId => suspectCusId.CustomerId,
                    (suspectTransId, suspectCusId) => new
                    {
                        suspectTransactionId = suspectTransId.TransactionId,
                        suspectOpetationName = suspectTransId.OperationType,
                        suspectTransactionTime = suspectTransId.TransactionTime,
                        suspectTransactionAmount = suspectTransId.TransactionTotalAmount,

                        suspectCustomerId = suspectCusId.CustomerId,
                        suspectCustomerName = suspectCusId.CustomerFullName,
                        suspectCustomerAge = suspectCusId.CustomerAge,
                        suspectCustomerStatus = suspectCusId.CustomerStatus,
                    })
                .GroupBy(g => g.suspectCustomerId)
                .Select(group => new
                {
                    SuspectCustomerId = group.Key,
                    SuspectCustomerName = group.First().suspectCustomerName ?? "Неизвестный клиент",
                    SuspectCustomerAge = group.First().suspectCustomerAge,
                    SuspectCustomerStatus = SetCustomerStatus(group.Sum(s => s.suspectTransactionAmount)),

                    AllSuspectTransactions = group.OrderByDescending(t => t.suspectTransactionAmount)
                });

            Console.WriteLine("Список подозрительных операций:\n");
            foreach (var susp in findSuspiciosOperations)
            {
                Console.WriteLine($"Детали о клиенте:");
                Console.WriteLine($"ID клиента: {susp.SuspectCustomerId}");
                Console.WriteLine($"Имя клиента: {susp.SuspectCustomerName}");
                Console.WriteLine($"Возраст клиента: {susp.SuspectCustomerAge}");
                Console.WriteLine($"Статус клиента: {susp.SuspectCustomerStatus}");

                foreach (var customer in susp.AllSuspectTransactions)
                {
                    Console.WriteLine($"   > ID: {customer.suspectTransactionId} | {customer.suspectOpetationName.OperationType} | Сумма: {customer.suspectTransactionAmount} | Дата: {customer.suspectTransactionTime:d}");
                }
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}
