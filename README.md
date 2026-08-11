# Finance Tracker

**Finance Tracker** is a console application built with C# (.NET 10.0) designed for simple and effective personal finance management. The application allows users to log new transactions (income / expenses), monitor their overall balance, review transaction history, and generate monthly financial statistics. All data is automatically persisted in a local JSON file.

---

## Key Features

- **Transaction Management**: add income and expense records specifying the ID, amount, and category
- **Transaction History**: view the complete list of logged transactions
- **Balance Calculation**: automatically compute the current balance based on income and expense totals
- **Monthly Statistics**: view total counts and sums for both income and expense transactions for the current month
- **Data Persistence**: automatically serialize and deserialize transaction data using a local JSON file

---

## Tech Stack & Requirements

- **Language**: C#
- **Target Framework**: .NET 10.0 
- **Data Format**: JSON

---

## Project Structure

```text
FinanceTracker/
├── Program.cs             # application entry point and interactive CLI menu
├── FinanceManager.cs      # core business logic for managing transactions and statistics
├── FileService.cs         # file I/O service handling JSON serialization/deserialization
├── Transaction.cs         # data model representing a single financial transaction
├── TransactionType.cs     # enum defining transaction types (Income / Expense)
├── transactions.json      # local JSON storage file for transactions
└── finance-tracker.csproj # .NET project configuration file
```

---

## Getting Started 

1. clone the repository
``` bash
git clone https://github.com/SofiiaLavrynenko/finance-tracker
cd finance-tracker
```
2. build the project 
``` bash
dotnet build
```
3. run the application
``` bash
dotnet run
```

---

## Usage Guide

Upon launching the program, the main console menu will appear:

``` text
FINANCE TRACKER
1 - add new transaction
2 - see all transactions
3 - see current balance
4 - see monthly stats
0 - exit
```

1. **add new transaction**: enter transaction details includinng ID, amount, category, and select the type (1 for income, 2 for expense)
2. **see all transactions**: display all stored transactions with timestamps
3. **see current balance**: display the calculated balance
4. **see monthly stats**: generate a summary report for the current calendar month
5. **exit**: terminate the application

---

## Data Storage Format

Transactions are saved locally in JSON format with the following structure:
``` json
[
  {
    "Id": 1,
    "Amount": 100,
    "Category": "food",
    "Type": 1,
    "Date": "2026-08-03T21:33:43.101399+03:00"
  }
]
```

`Type` field values:
* `0` - income
* `1` - expense