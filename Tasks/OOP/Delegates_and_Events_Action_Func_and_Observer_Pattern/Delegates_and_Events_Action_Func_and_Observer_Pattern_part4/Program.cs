namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part4
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var paymentTerminal = new PaymentTerminal();
                var banksecurity = new BankSecurity();

                paymentTerminal.ValidationRequested += banksecurity.ValidateTransaction;

                paymentTerminal.ProcessPayment(200, "Депозит");
                paymentTerminal.ProcessPayment(6000, "Депозит");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}