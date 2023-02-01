using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EC04_C_sharp_Adress_book_WpfApp.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // Set the starting view
        [ObservableProperty]
        private ObservableObject currentViewModel = new ContactsListViewModel();


        // Add contact view
        [RelayCommand]
        private void GoToAddContact()
        {
            CurrentViewModel = new AddContactViewModel();
        }

        // Contact list view
        [RelayCommand]
        private void GoToContactList()
        {
            CurrentViewModel = new ContactsListViewModel();
        }

        // Exit app
        [RelayCommand]
        private void Exit()
            => Application.Current.Shutdown();
    }
}
