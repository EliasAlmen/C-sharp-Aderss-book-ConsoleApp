using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC04_C_sharp_Adress_book_WpfApp.MVVM.Models;
using EC04_C_sharp_Adress_book_WpfApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EC04_C_sharp_Adress_book_WpfApp.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public AddContactViewModel()
        {
            fileService = new FileService();
        }

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string tb_firstName = "First name";

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string tb_lastName = "Last name";

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string tb_email = "Email";

        [ObservableProperty]
        private string phoneNumber = string.Empty;

        [ObservableProperty]
        private string tb_phoneNumber = "Phone number";

        [ObservableProperty]
        private string address = string.Empty;

        [ObservableProperty]
        private string tb_address = "Address";

        // Add contact to list. If-statement to check that all fields are filled in.
        [RelayCommand]
        private void Add()
        {
            if (FirstName == string.Empty || LastName == string.Empty || Email == string.Empty || PhoneNumber == string.Empty || Address == string.Empty)
            {
                MessageBox.Show("Please fill in all text fields.");
            }
            else
            {
                // Takes input and returns Uppercase string. Nice to have.
                var FirstNameUpper = FileService.ToUpperFirstLetter(FirstName);
                var LastNameUpper = FileService.ToUpperFirstLetter(LastName);
                var EmailUpper = FileService.ToUpperFirstLetter(Email);
                var AddressUpper = FileService.ToUpperFirstLetter(Address);

                fileService.AddToList(new ContactModel { FirstName = FirstNameUpper, LastName = LastNameUpper, Email = EmailUpper, PhoneNumber = PhoneNumber, Address = AddressUpper });
                
                // Clear fields after contact was added.
                FirstName = string.Empty;
                LastName = string.Empty;
                Email = string.Empty;
                PhoneNumber = string.Empty;
                Address = string.Empty;

                // Confirmation MessageBox
                MessageBox.Show($"{FirstNameUpper}\n{LastNameUpper}\n\nAdded.");

            }
        }
    }
}
