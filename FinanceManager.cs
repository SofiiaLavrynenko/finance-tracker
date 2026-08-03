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

    public void PrintStatistics()
    {
        DateTime month = DateTime.Now;

        List<Transaction> lastMonthTransactions = _transactions
                                                .Where(t => t.Date.Month == month.Month 
                                                && t.Date.Year == month.Year)
                                                .ToList();

        decimal totalIncome = 0;
        int totalIncomeNumber = 0;
        decimal totalExpense = 0;
        int totalExpenseNumber = 0;
        
        foreach (var transaction in lastMonthTransactions)
        {
            if (transaction.Type == TransactionType.Income)
            {
                totalIncome += transaction.Amount;
                totalIncomeNumber += 1;
            }
            else
            {
                totalExpense += transaction.Amount;
                totalExpenseNumber += 1;
            }
        }

        System.Console.WriteLine("\nTRANSACTION STATS");
        System.Console.WriteLine($"Month: {month.ToString("MMMM")}\n");
        System.Console.WriteLine($"Income transactions number: {totalIncomeNumber}");
        System.Console.WriteLine($"Total income amount: {totalIncome}\n");
        System.Console.WriteLine($"Expense transactions number: {totalExpenseNumber}");
        System.Console.WriteLine($"Total expense number: {totalExpense}");
    }
}