
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EZMoney.Models;
using SQLite;

namespace EZMoney.Service
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "expenses.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ExpenseModel>().Wait();
        }

        public Task<int> AddExpenseAsync(ExpenseModel expense) => _database.InsertAsync(expense);

        public Task<List<ExpenseModel>> GetExpensesAsync() => _database.Table<ExpenseModel>().ToListAsync();

        public Task<int> UpdateExpenseAsync(ExpenseModel expense) => _database.UpdateAsync(expense);

        public Task<int> DeleteExpenseAsync(ExpenseModel expense) => _database.DeleteAsync(expense);
    }
}
