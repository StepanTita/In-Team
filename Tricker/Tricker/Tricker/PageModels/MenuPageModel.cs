using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FormsToolkit;
using FreshMvvm;
using Tricker.Helpers;
using Xamarin.Forms;

namespace Tricker.PageModels
{
    public class MenuPageModel : FreshBasePageModel
    {
        public ICommand NavigateCommand { get; set; }

        public List<MenuItem> MenuItems { get; set; }
        public MenuItem SelectedItem { get; set; }

        public MenuPageModel()
        {
            NavigateCommand = new Command(NavigateToPageModel);

            MenuItems = new List<MenuItem>();

            MenuItems.Add(new MenuItem() { Value = "Map", Label = "Map", Image = "start.png" });
            MenuItems.Add(new MenuItem() { Value = "Account", Label = "Account", Image = "me.png" });
        }

        void NavigateToPageModel()
        {
            MessagingService.Current.SendMessage<string>(Helpers.Constants.NavigationTriggered, SelectedItem.Value);
        }
    }

    public class MenuItem
    {
        public string Label { get; set; }
        public string Image { get; set; }
        public string Value { get; set; }
    }
}