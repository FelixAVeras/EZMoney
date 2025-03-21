using System;
using System.Collections.Generic;
using System.Text;

namespace EZMoney.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;

        public LoginViewModel Login { get; set; }

        public MainViewModel()
        {
            instance = this;

            this.Login = LoginViewModel();
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
