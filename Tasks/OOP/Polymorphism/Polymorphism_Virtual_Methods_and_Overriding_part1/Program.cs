namespace Polymorphism_Virtual_Methods_and_Overriding_part1
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "****************************************************";

                List<Payment> payments = new List<Payment>();
                CreditCardPayment creditCardPayment = new CreditCardPayment("5455666604041544", 500);
                PayPalPayment payPalPayment = new PayPalPayment("anisimovilya@gmail.com", 400);

                payments.Add(payPalPayment);
                payments.Add(creditCardPayment);

                foreach (var payment in payments)
                {
                    if (payment is PayPalPayment payPal)
                    {
                        payPal.SendReceipt();
                        Console.WriteLine(separator);
                    }
                    else
                    {
                        Console.WriteLine($"{payment} не является объектом [PayPalPayment]");
                        Console.WriteLine(separator);
                    }

                    payment.ProcessPayment();
                    Console.WriteLine(separator);
                }
            }
            catch (ArgumentNullException ex)
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