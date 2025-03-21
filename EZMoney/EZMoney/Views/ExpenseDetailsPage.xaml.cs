using EZMoney.Models;
using EZMoney.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZMoney.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailsPage : ContentPage
    {
        public ExpenseModel Expense { get; set; }

        public Command EditCommand { get; }
        public Command DeleteCommand { get; }

        public ExpenseDetailsPage(ExpenseModel expense)
        {
            InitializeComponent();
            Expense = expense;
            BindingContext = this;

            EditCommand = new Command(async () =>
            {
                await Navigation.PushAsync(new EditExpensePage(Expense));
            });

            DeleteCommand = new Command(() =>
            {
                ExpenseService.Instance.DeleteExpense(Expense);
                Navigation.PopAsync();
            });
        }
    }
}