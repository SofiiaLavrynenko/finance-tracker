namespace FinanceTracker;

public class Transaction
{
    public int Id { get; init; }
    public decimal Amount { get; init; }
    public string Category { get; init; } = "not stated";
    public TransactionType Type { get; init; }
    public DateTime Date { get; init; }

    public Transaction(int id, decimal amount, string category, TransactionType type)
    {
        Id = id;
        Amount = amount;
        Category = category;
        Type = type;
        Date = DateTime.Now;
    }
}