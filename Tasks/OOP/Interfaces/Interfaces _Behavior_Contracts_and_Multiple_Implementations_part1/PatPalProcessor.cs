namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part1
{
    public class PayPalProcessor : IPaymentProcessor
    {
        private readonly string _email;

        public string Email { get => _email; }

        public PayPalProcessor(string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nameof(email));

            if (!email.Contains("@"))
                throw new FormatException("Email должен содержать @");

            _email = email;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата: {amount} через PayPal [{Email}] прошла успешно");
        }
    }
}
