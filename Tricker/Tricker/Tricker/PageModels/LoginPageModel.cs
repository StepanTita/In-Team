using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Tricker.Pages;

namespace Tricker.PageModels
{
    public class LoginPageModel : ContentPage, INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChangedNew = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChangedNew(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChangedNew(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand SubmitRegisterCommand { protected set; get; }
        public LoginPageModel() {}






    }
}
