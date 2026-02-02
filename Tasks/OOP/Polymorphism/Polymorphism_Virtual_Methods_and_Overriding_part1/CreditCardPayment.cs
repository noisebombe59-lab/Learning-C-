namespace Polymorphism_Virtual_Methods_and_Overriding_part1
{
    public class CreditCardPayment : Payment
    {
        private readonly string? _cardNumber;

        public string? CardNumber { get => _cardNumber; }

        public CreditCardPayment(string? cardNumber, int amount) : base(amount)
        {
            if (cardNumber is null || cardNumber is "")
                throw new ArgumentNullException("Номер карты не может быть пустым", nameof(cardNumber));

            if (cardNumber.Length != 16)
                throw new ArgumentException("Номер карты должен содержать 16 цифр", nameof(cardNumber));

            _cardNumber = cardNumber;
        }

        public override void ProcessPayment()
        {
            base.ProcessPayment();
            Console.WriteLine($"Оплата картой: {CardNumber}");
        }
    }
}
