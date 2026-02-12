namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part4
{
    public class BankSecurity
    {
        public bool ValidateTransaction(PaymentContext paymentContext)
        {
            if (paymentContext.Amount > 5000)
            {
                Console.WriteLine($"[БАНК]: Сумма {paymentContext.Amount} слишком велика");
                return false;
            }

            return true;
        }
    }
}
