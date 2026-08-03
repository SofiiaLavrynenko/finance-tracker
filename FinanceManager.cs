namespace FinanceTracker;

public class FinanceManager
{
    private List<Transaction> _transactions;

    public FinanceManager()
    {
        _transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public List<Transaction> GetAllTransactions()
    {
        return _transactions;
    }

    public decimal GetBalance()
    {
        decimal balance = 0;

        foreach (var transaction in _transactions)
        {
            if (transaction.Type == TransactionType.Income)
            {
                balance += transaction.Amount;
            }
            else
            {
                balance -= transaction.Amount;
            }
        }
        return balance;
    }
}