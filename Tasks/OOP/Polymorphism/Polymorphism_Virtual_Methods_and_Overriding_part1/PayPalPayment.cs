namespace Polymorphism_Virtual_Methods_and_Overriding_part1
{
    public class PayPalPayment : Payment
    {
        private readonly string? _email;

        public string? Email { get => _email; }

        public PayPalPayment(string? email, int amount) : base(amount)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("Email не может быть пустым", nameof(email));

            if (!email.Contains("@gmail.com"))
                throw new ArgumentException("Email должен содержать @gmail.com", nameof(email));

            _email = email;
        }

        public void SendReceipt()
        {
            Console.WriteLine($"Чек отправлен на почту: {Email}");
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Оплата через PayPal: ({Email}) на сумму: ({Amount}) прошла успешно.");
        }
    }
}
