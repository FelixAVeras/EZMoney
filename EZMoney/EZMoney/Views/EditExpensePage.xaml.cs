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
    public partial class EditExpensePage : ContentPage
    {
        public ExpenseModel Expense { get; set; }
        public Command SaveCommand { get; }

        public EditExpensePage(ExpenseModel expense)
        {
            InitializeComponent();
            Expense = expense;
            BindingContext = this;

            SaveCommand = new Command(() =>
            {
                ExpenseService.Instance.UpdateExpense(Expense);
                Navigation.PopAsync();
            });
        }
    }
}