namespace BankSolution
{
    public class Account
    {
        private readonly List<Transaction> transactions;

        private decimal balance;

        public Account(int amount)
        {
            this.Balance = amount;
            this.transactions = new List<Transaction>
            {
                new Transaction(DateTime.UtcNow, amount, "Initial Balance")
            };
        }

        public decimal Balance
        {
            get => this.balance;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("You cannot have a negative balance.");
                }

                this.balance = value;
            }
        }

        public void Deposit(decimal amount, string reference)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("You need to deposit a positive amount of money.");
            }

            this.balance += amount;

            this.transactions.Add(new Transaction(DateTime.UtcNow, amount, reference));
        }

        public void Withdraw(decimal amount)
        {
            const decimal withdrawalTax = 0.5m;

            amount += withdrawalTax;

            if (this.Balance < amount)
            {
                throw new InvalidOperationException("You do not have enough money for this operation.");
            }

            this.balance -= amount;

            this.transactions.Add(new Transaction(DateTime.UtcNow, -amount + withdrawalTax, "ATM Withdrawal"));
            this.transactions.Add(new Transaction(DateTime.UtcNow, -withdrawalTax, "Withdrawal Bank Tax"));
        }

        public List<string> TransactionHistory()
        {
            return this.transactions
                .Select(t => t.ToString())
                .ToList();
        }
    }
}
