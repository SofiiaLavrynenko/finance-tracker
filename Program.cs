using System.Linq.Expressions;

using FinanceTracker;

class Program
{
    static void Main(string[] args)
    {
        var manager = new FinanceManager();

        while (true)
        {
            System.Console.WriteLine("\nFINANCE TRACKER");
            System.Console.WriteLine("1 - add new transaction");
            System.Console.WriteLine("2 - see all transactions");
            System.Console.WriteLine("3 - see current balance");
            System.Console.WriteLine("0 - exit");

            System.Console.Write("Choose your option: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    {
                        int id;
                        decimal amount;
                        string category;
                        TransactionType type;
                        DateTime date = DateTime.Now;

                        System.Console.Write("\nEnter transaction id: ");
                        id = int.Parse(Console.ReadLine()!);

                        System.Console.Write("Enter transaction amount: ");
                        amount = decimal.Parse(Console.ReadLine()!);

                        System.Console.Write("Enter transaction category: ");
                        category = Console.ReadLine()!;

                        System.Console.WriteLine("Transaction types:");
                        System.Console.WriteLine("1 - income");
                        System.Console.WriteLine("2 - expense");

                        System.Console.Write("Enter transaction type: ");
                        string typeNumber = Console.ReadLine()!;

                        type = typeNumber == "1" ? TransactionType.Income : TransactionType.Expense;

                        manager.AddTransaction(new Transaction(id, amount, category, type));

                        break;
                    }
                
                case "2":
                    {
                        List<Transaction> transactions = manager.GetAllTransactions();

                        if (transactions.Count == 0)
                        {
                            System.Console.WriteLine("\nTransactions list is empty.");
                        }
                        else
                        {
                            System.Console.WriteLine("\nTransactions:");
                            foreach (var transaction in transactions)
                            {
                                System.Console.WriteLine(transaction.ToString());
                            }
                        }

                        break;
                    }
                
                case "3":
                    {
                        System.Console.WriteLine($"\nCurrent balance is {manager.GetBalance()}.");

                        break;
                    }

                case "0":
                    {
                        System.Console.WriteLine("\nExiting...");

                        return;
                    }
                
                default:
                    {
                        System.Console.WriteLine("\nInvalid input. Please, try again.");

                        break;
                    }

            }
        }
    }
}