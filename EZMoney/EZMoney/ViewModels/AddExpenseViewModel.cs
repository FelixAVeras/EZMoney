using EZMoney.Models;
using EZMoney.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZMoney.ViewModels
{
    public class AddExpenseViewModel : BaseViewModel
    {
        private string _category;
        private string _description;
        private decimal _amount;
        private DateTime _date;

        public string Category
        {
            get => _category;
            set => SetValue(ref _category, value);
        }

        public string Description
        {
            get => _description;
            set => SetValue(ref _description, value);
        }

        public decimal Amount
        {
            get => _amount;
            set => SetValue(ref _amount, value);
        }

        public DateTime Date
        {
            get => _date;
            set => SetValue(ref _date, value);
        }

        public ICommand SaveCommand { get; }

        public AddExpenseViewModel()
        {
            Date = DateTime.Now;
            SaveCommand = new Command(SaveExpense);
        }

        private void SaveExpense()
        {
            if (string.IsNullOrWhiteSpace(Category) || Amount <= 0)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Ingrese una categoría y un monto válido.", "OK");
                return;
            }

            ExpenseModel newExpense = new ExpenseModel
            {
                Category = Category,
                Description = Description,
                Amount = Amount,
                Date = Date
            };

            ExpenseService.Instance.AddExpense(newExpense);

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
