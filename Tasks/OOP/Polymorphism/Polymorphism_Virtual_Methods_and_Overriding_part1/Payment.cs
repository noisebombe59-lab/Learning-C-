namespace Polymorphism_Virtual_Methods_and_Overriding_part1
{
    public class Payment
    {
        private readonly int _amount;

        public int Amount { get => _amount; }

        protected Payment(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма не может быть отрицательной или равна 0", nameof(amount));

            _amount = amount;
        }

        public virtual void ProcessPayment()
        {
            Console.WriteLine($"Подготовка к оплате на сумму: {Amount}");
        }
    }
}
