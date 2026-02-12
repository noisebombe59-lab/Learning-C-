namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part1
{
    public class Logger
    {
        public void PrintBalanceStatus(decimal balanceAfterOperetation)
        {
            Console.WriteLine($"[LOG]: Баланс изменился: {balanceAfterOperetation}");
        }
    }
}
