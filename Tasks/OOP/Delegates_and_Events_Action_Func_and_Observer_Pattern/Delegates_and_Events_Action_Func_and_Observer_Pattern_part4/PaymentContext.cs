namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part4
{
    public class PaymentContext
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        
        public PaymentContext(decimal amount, string description)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount, nameof(amount));
            ArgumentException.ThrowIfNullOrWhiteSpace(description, nameof(description));

            Amount = amount;
            Description = description;
        }
    }
}
