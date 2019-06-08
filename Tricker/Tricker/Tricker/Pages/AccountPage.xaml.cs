using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tricker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        private User CurrentUser;
        public AccountPage()
        {
            InitializeComponent();
            CurrentUser = new User();
            //ActivateElements();

        }
        public AccountPage(User currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            ActivateElements();
            
        }

        private void ActivateElements()
        {
            Avatar.Source = CurrentUser.Avatar.URL;
            UserName.Text = CurrentUser.Name;
            if (Avatar.Source.Equals(null))
            {
                Avatar.Source = "resource://Tricker.Android.Resources.drawable.profile.jpg";
            }
            if (UserName.Text.Equals(null))
            {
                UserName.Text = "Stepan Tytarenko";
            }
        }
    }
}