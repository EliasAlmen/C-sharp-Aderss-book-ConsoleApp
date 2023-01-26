using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC04_C_sharp_Adress_book_WpfApp.MVVM.Models;
using EC04_C_sharp_Adress_book_WpfApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EC04_C_sharp_Adress_book_WpfApp.MVVM.ViewModels
{
    public partial class ContactsListViewModel : ObservableObject
    {
        private readonly FileService fileService;

        

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        public ContactsListViewModel()
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
        }

        [ObservableProperty]
        private ContactModel selectedContact = null!;

        [RelayCommand]
        public void DeleteSelected()
        {
            if (SelectedContact != null)
            {
                fileService.Delete(SelectedContact);
            }
            else
            {
                MessageBox.Show("No contact was selected.");
            }
        }
    }  
}
