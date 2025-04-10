using EZMoney.Pages;
using EZMoney.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZMoney.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ApiService apiService;

        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        public string Email
        {
            get => email;
            set => SetValue(ref this.email, value);
        }

        public string Password
        {
            get => password;
            set => SetValue(ref this.password, value);
        }

        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref this.isRunning, value);
        }

        public bool IsRemembered
        {
            get => isRemember;
            set => SetValue(ref isRemember, value);
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref this.isEnabled, value);
        }

        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "fcarvajal44@gmail.com";
            this.Password = "123456";
        }

        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El correo electronico ingresado no es correcto. Intente de nuevo",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "La contraseña ingresada no es valida. Intente de nuevo",
                    "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            //var token = await this.apiService.GetToken(
            //    "http://landsapi1.azurewebsites.net",
            //    this.Email,
            //    this.Password);

            //if (token == null)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        Languages.SomethingWrong,
            //        Languages.Accept);
            //    return;
            //}

            //if (string.IsNullOrEmpty(token.AccessToken))
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        token.ErrorDescription,
            //        Languages.Accept);
            //    this.Password = string.Empty;
            //    return;
            //}

            MainViewModel.GetInstance().Dashboard = new DashboardViewModel();
            //mainViewModel.Token = token;
            //mainViewModel.Lands = new LandsViewModel();
            Application.Current.MainPage = new MasterPage();

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }
    }
}
