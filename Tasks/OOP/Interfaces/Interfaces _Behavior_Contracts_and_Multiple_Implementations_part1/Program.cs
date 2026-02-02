namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part1
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "--------------------------------------------------------------";

                List<IPaymentProcessor> paymentProcessors = new List<IPaymentProcessor>();
                CreditCardProcessor creditCardProcessor = new CreditCardProcessor("5544101147874466");
                PayPalProcessor payPalProcessor = new PayPalProcessor("ilya_anisimov_78@gmail.com");

                paymentProcessors.Add(creditCardProcessor);
                paymentProcessors.Add(payPalProcessor);

                foreach (var processor in paymentProcessors)
                {
                    processor.ProcessPayment(100.0);
                    Console.WriteLine(separator);
                }
            }
            catch (FormatException ex)
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