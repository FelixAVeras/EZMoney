using EZMoney.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace EZMoney.Service
{
    public class ExpenseService
    {
        private static ExpenseService _instance;
        private readonly SQLiteConnection _database;

        // Uncomment this in the update
        //public static ExpenseService Instance => _instance ??= new ExpenseService();

        public static ExpenseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpenseService();
                }

                return _instance;
            }
        }

        public ObservableCollection<ExpenseModel> Expenses { get; private set; }

        private ExpenseService()
        {
            string dbPath = Path.Combine(Environment
                .GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "expenses.db3");
            
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<ExpenseModel>();

            LoadExpenses();
        }

        private void LoadExpenses()
        {
            var expensesList = _database.Table<ExpenseModel>().ToList();
            Expenses = new ObservableCollection<ExpenseModel>(expensesList);
        }

        public ObservableCollection<ExpenseModel> GetExpenses()
        {
            var expensesList = _database.Table<ExpenseModel>().ToList();
            return new ObservableCollection<ExpenseModel>(expensesList);
        }

        public void AddExpense(ExpenseModel expense)
        {
            _database.Insert(expense);
            Expenses.Add(expense);
        }

        public void UpdateExpense(ExpenseModel expense)
        {
            _database.Update(expense);

            var existingExpense = Expenses.FirstOrDefault(e => e.Id == expense.Id);
            
            if (existingExpense != null)
            {
                existingExpense.Name = expense.Name;
                existingExpense.Amount = expense.Amount;
                existingExpense.Date = expense.Date;
            }
        }

        public void DeleteExpense(ExpenseModel expense)
        {
            _database.Delete(expense);
            Expenses.Remove(expense);
        }
    }
}
