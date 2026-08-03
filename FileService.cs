using System.Text.Json;

namespace FinanceTracker;

public static class FileService
{
    public static void SaveTransactions(List<Transaction> transactions, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(transactions, options);

        File.WriteAllText(filePath, jsonString);
    }

    public static List<Transaction> LoadTransactions(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Transaction>();
        }

        string jsonString = File.ReadAllText(filePath);

        if (string.IsNullOrWhiteSpace(jsonString))
        {
            return new List<Transaction>();
        }

        return JsonSerializer.Deserialize<List<Transaction>>(jsonString) ?? new List<Transaction>();
    }
}