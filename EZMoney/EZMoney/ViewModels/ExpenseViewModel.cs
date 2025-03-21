using EZMoney.Models;
using EZMoney.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZMoney.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        public ObservableCollection<ExpenseModel> Expenses { get; set; }

        public ICommand AddExpenseCommand { get; }
        public ICommand LoadExpensesCommand { get; }

        public ExpenseViewModel()
        {
            _databaseService = new DatabaseService();
            Expenses = new ObservableCollection<ExpenseModel>();

            AddExpenseCommand = new Command(async () => await AddExpense());
            LoadExpensesCommand = new Command(async () => await LoadExpenses());

            LoadExpensesCommand.Execute(null);
        }

        private async Task AddExpense()
        {
            var newExpense = new ExpenseModel { Name = "Example", Amount = 50, Category = "Food", Date = System.DateTime.Now };
            await _databaseService.AddExpenseAsync(newExpense);
            await LoadExpenses();
        }

        private async Task LoadExpenses()
        {
            Expenses.Clear();
            var expenses = await _databaseService.GetExpensesAsync();
            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }
    }
}
