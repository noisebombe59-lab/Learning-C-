namespace access_modifiers_static_records
{
    public class BankAccount
    {
        private decimal _balance;
        private int _accountNumber;

        public decimal Balance { get => _balance; }
        public int AccountNumber { get => _accountNumber; }

        public BankAccount(int accountNumber, decimal balance = 0)
        {

            if (balance < 0)
                throw new ArgumentException(null, nameof(balance));

            if (accountNumber <= 0)
                throw new ArgumentException(null, nameof(accountNumber));

            _balance = balance;
            _accountNumber = accountNumber;
        }
        public void Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit > 0)
                _balance += amountToDeposit;

            else
                throw new ArgumentException(null, nameof(amountToDeposit));
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= 0)
                throw new ArgumentException(null, "amountNegativeOrZero");

            if (Balance - amountToWithdraw < BankSettings.MinBalance)
                throw new ArgumentException(null, "insufficientFunds");

            _balance -= amountToWithdraw;
        }

        protected void ApplyInterest()
        {

        }
    }
}
