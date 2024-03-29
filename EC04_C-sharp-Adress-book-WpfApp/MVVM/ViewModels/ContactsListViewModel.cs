﻿using CommunityToolkit.Mvvm.ComponentModel;
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


        // Delete selected contact, with MessageBox YesNo
        [RelayCommand]
        public void DeleteSelected()
        {
            //Simple check if anything is selected in ViewList
            if (SelectedContact != null)
            {
                var contactBackend = SelectedContact;
                MessageBoxResult result = MessageBox.Show($"Remove {contactBackend.FirstName} {contactBackend.LastName} \n\nAre you sure?", "Remove contact", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                
                
                switch (result)
                {
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.Yes:
                        //for the backend
                        //for the GUI
                        Contacts.Remove(SelectedContact);
                        //for the backend
                        fileService.Delete(contactBackend);
                        MessageBox.Show($"{contactBackend.FirstName}\n{contactBackend.LastName}\n\nDeleted.");
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show($"{contactBackend.FirstName}\n{contactBackend.LastName}\n\nWas not deleted.");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("No contact was selected.");
            }
        }

        // Updates contact compares to list and saves file
        [RelayCommand]
        public void UpdateSelected()
        {
            if (SelectedContact != null)
            {
                var x = Contacts.FirstOrDefault(i => i.FirstName== SelectedContact.FirstName);
                if (x != null)
                {
                    x.FirstName = SelectedContact.FirstName;
                    x.LastName= SelectedContact.LastName;
                    x.Email= SelectedContact.Email;
                    x.PhoneNumber = SelectedContact.PhoneNumber;
                    x.Address= SelectedContact.Address;
                    fileService.SaveToFile();
                    MessageBox.Show("Contact was updated!");
                }
                else MessageBox.Show("Error.");


            }
            else
            {
                MessageBox.Show("No contact was selected.");
            }
        }
    }  
}
