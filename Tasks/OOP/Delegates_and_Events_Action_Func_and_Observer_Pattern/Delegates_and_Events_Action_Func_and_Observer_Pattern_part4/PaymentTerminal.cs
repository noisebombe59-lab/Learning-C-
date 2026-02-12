namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part4
{
    public class PaymentTerminal
    {
        public event Func<PaymentContext, bool>? ValidationRequested;

        public void ProcessPayment(decimal amount, string description)
        {
            if (ValidationRequested == null)
            {
                Console.WriteLine("Ошибка: Система валидации не подключена!");
                return;
            }

            var paymentContext = new PaymentContext(amount, description);
            bool isApproved = ValidationRequested.Invoke(paymentContext);

            if (isApproved)
            {
                Console.WriteLine($"Платеж на сумму: {amount} проведен");
            }
            else
            {
                Console.WriteLine("Отказ: Лимит привышен или подозрительная операция");
            }
        }
    }
}
