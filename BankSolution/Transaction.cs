namespace BankSolution
{
    internal class Transaction
    {
        public Transaction(DateTime transactionDate, decimal amount, string reference)
        {
            this.TransactionDate = transactionDate;
            this.Amount = amount;
            this.Reference = reference;
        }

        public DateTime TransactionDate { get; private set; }

        public decimal Amount { get; private set; }

        public string Reference { get; private set; }

        public override string ToString()
        {
            var typeOfTransaction = this.Amount > 0 ? "Deposit" : "Withdrawal";

            return $"{this.TransactionDate.ToShortDateString()} {this.TransactionDate.ToShortTimeString()} UTC - {typeOfTransaction}: {this.Amount:F2} - {this.Reference}";
        }
    }
}
