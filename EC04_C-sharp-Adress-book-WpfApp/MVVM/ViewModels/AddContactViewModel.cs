using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC04_C_sharp_Adress_book_WpfApp.MVVM.Models;
using EC04_C_sharp_Adress_book_WpfApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string tb_firstName = "First name:";

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string tb_lastName = "Last name:";

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string tb_email = "Email:";

        [ObservableProperty]
        private string phoneNumber = string.Empty;

        [ObservableProperty]
        private string tb_phoneNumber = "Phone number:";

        [ObservableProperty]
        private string address = string.Empty;

        [ObservableProperty]
        private string tb_address = "Adress:";

        [RelayCommand]
        private void Add()
        {
            fileService.AddToList(new ContactModel { FirstName = FirstName, LastName = LastName, Email = Email, PhoneNumber = PhoneNumber, Address = Address });
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
        }
    }
}
