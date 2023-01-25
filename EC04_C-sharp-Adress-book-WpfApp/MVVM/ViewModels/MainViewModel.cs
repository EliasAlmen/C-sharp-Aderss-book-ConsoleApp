using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC04_C_sharp_Adress_book_WpfApp.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel = new ContactsListViewModel();

        [RelayCommand]
        private void GoToAddContact()
        {
            CurrentViewModel = new AddContactViewModel();
        }

        [RelayCommand]
        private void GoToContactList()
        {
            CurrentViewModel = new ContactsListViewModel();
        }
    }
}
