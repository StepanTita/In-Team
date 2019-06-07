using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Tricker.Views;

namespace Tricker.ViewModels
{
    public class LoginViewModel : ContentPage, INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand SubmitRegisterCommand { protected set; get; }
        public LoginViewModel() {}






    }
}
