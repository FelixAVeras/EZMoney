using EZMoney.Models;
using EZMoney.Service;
using EZMoney.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZMoney.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<ExpenseModel> Expenses { get; set; }
        public ExpenseModel SelectedExpense { get; set; }

        public ICommand AddExpenseCommand { get; }
        public ICommand ShowExpenseCommand { get; }
        //public ICommand EditExpenseCommand { get; }
        //public ICommand DeleteExpenseCommand { get; }


        public DashboardViewModel()
        {
            Expenses = ExpenseService.Instance.GetExpenses();

            ShowExpenseCommand = new Command<ExpenseModel>(async (expense) =>
            {
                if (expense != null)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(expense));
                }
            });

            //AddExpenseCommand = new Command(() =>
            //{
            //    var newExpense = new ExpenseModel
            //    {
            //        Name = "Supermercado",
            //        Amount = 50.00m,
            //        Date = DateTime.Now
            //    };

            //    ExpenseService.Instance.AddExpense(newExpense);
            //    Expenses.Add(newExpense);
            //});

            //EditExpenseCommand = new Command<ExpenseModel>(async (expense) =>
            //{
            //    if (expense != null)
            //    {
            //        await Application.Current.MainPage.Navigation.PushAsync(new EditExpensePage(expense));
            //    }
            //});

            //DeleteExpenseCommand = new Command<ExpenseModel>((expense) =>
            //{
            //    if (expense != null)
            //    {
            //        ExpenseService.Instance.DeleteExpense(expense);
            //        Expenses.Remove(expense);
            //    }
            //});
        }

        //private void AddExpense()
        //{
        //    var newExpense = new ExpenseModel
        //    {
        //        Name = "Supermercado",
        //        Amount = 50.00m,
        //        Date = System.DateTime.Now
        //    };

        //    ExpenseService.Instance.AddExpense(newExpense);
        //    Expenses.Add(newExpense);
        //}

        //private void DeleteExpense(ExpenseModel expense)
        //{
        //    ExpenseService.Instance.DeleteExpense(expense);
        //    Expenses.Remove(expense);
        //}
    }
}
