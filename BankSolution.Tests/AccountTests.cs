namespace BankSolution.Tests
{
    internal class AccountTests
    {
        [Test]
        public void WithNegativeStartingBalanceShouldThrowException()
        {
            Assert.That(() =>
            {
                // Arrange & Act
                var account = new Account(-100);
            }, 
            // Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "You cannot have a negative balance.");
        }

        [Test]
        public void DepositWithPositiveAmountShouldAddToBalance()
        {
            // Arrange
            var account = new Account(100);

            // Act
            account.Deposit(200, "Deposit");

            // Assert
            Assert.That(account.Balance, Is.EqualTo(300));
        }

        [Test]
        public void WithdrawWithValidAmountShouldSubtractFromBalance()
        {
            // Arrange
            var account = new Account(100);

            // Act
            account.Withdraw(40);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(59.5m));
        }

        [Test]
        public void WithdrawWithInvalidAmountShouldThrowException()
        {
            Assert.That(() =>
            {
                // Arrange
                var account = new Account(500);

                // Act
                account.Withdraw(1000);
            },
            // Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "You do not have enough money for this operation.");
        }

        [Test]
        public void TransactionHistoryShouldReturnCorrectValues()
        {
            // Arrange
            var account = new Account(100);

            account.Deposit(500, "From Parents");
            account.Deposit(1500, "Salary");
            account.Withdraw(300);
            account.Withdraw(800);
            account.Deposit(2000, "Car Trade");
            account.Withdraw(450);

            // Act
            var transactionHistory = account.TransactionHistory();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(transactionHistory[0], Contains.Substring("Deposit: 100.00 - Initial Balance"));
                Assert.That(transactionHistory[1], Contains.Substring("Deposit: 500.00 - From Parents"));
                Assert.That(transactionHistory[2], Contains.Substring("Deposit: 1500.00 - Salary"));
                Assert.That(transactionHistory[3], Contains.Substring("Withdrawal: -300.00 - ATM Withdrawal"));
                Assert.That(transactionHistory[4], Contains.Substring("Withdrawal: -0.50 - Withdrawal Bank Tax"));
                Assert.That(transactionHistory[5], Contains.Substring("Withdrawal: -800.00 - ATM Withdrawal"));
                Assert.That(transactionHistory[6], Contains.Substring("Withdrawal: -0.50 - Withdrawal Bank Tax"));
                Assert.That(transactionHistory[7], Contains.Substring("Deposit: 2000.00 - Car Trade"));
                Assert.That(transactionHistory[8], Contains.Substring("Withdrawal: -450.00 - ATM Withdrawal"));
                Assert.That(transactionHistory[9], Contains.Substring("Withdrawal: -0.50 - Withdrawal Bank Tax"));
            });
        }
    }
}
