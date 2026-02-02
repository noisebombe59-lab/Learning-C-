namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part1
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        private readonly string _cardNumber;

        public string? CardNumber { get => _cardNumber; }

        public CreditCardProcessor(string? cardNumber)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);

            _cardNumber = cardNumber;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата: {amount} через Credit Card: [{CardNumber}] прошла успешно");
        }
    }
}
