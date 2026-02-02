namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility
{
    public class BankOperation
    {
        private readonly BankLogger _logger;

        public BankOperation(BankLogger logger)
        {
            _logger = logger;
        }

        public void Execute(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Значение транзакции не может быть отрицательным или равно 0");

            _logger.Log($"Зачисление: {amount}");
        }
    }
}
