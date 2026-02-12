namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part1
{
    public class Account
    {
        public event Action<decimal>? BalanceChanged;
        private decimal _balance;

        public void Deposit(decimal amount)
        {
            _balance += amount;
            BalanceChanged?.Invoke(_balance);
        }
    }
}
