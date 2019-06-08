using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tricker.PageModels
{
    class AuthorizationPageModel : ContentPage, INotifyPropertyChanged
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

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                PropertyChangedNew(this, new PropertyChangedEventArgs("Login"));
            }
        }

        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set
            {
                fullname = value;
                PropertyChangedNew(this, new PropertyChangedEventArgs("FullName"));
            }
        }

    }
}
