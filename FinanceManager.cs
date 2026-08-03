namespace FinanceTracker;

public class FinanceManager
{
    private List<Transaction> _transactions;
    private readonly string _filePath = "transactions.json";

    public FinanceManager()
    {
        _transactions = FileService.LoadTransactions(_filePath);
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        FileService.SaveTransactions(_transactions, _filePath);
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