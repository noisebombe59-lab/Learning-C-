namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part1
{
    public class Program
    {
        static void Main()
        {
            var account = new Account();
            var logger = new Logger();

            account.BalanceChanged += logger.PrintBalanceStatus;
            account.Deposit(500);
        }
    }
}