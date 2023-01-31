using EC04_C_sharp_Adress_book_WpfApp.MVVM.Models;
using EC04_C_sharp_Adress_book_WpfApp.Services;
using FluentAssertions;

namespace EC04_C_sharp_Adres_book_WpfApp_Tests
{
    public class ContactModel_Tests
    {
        private ContactModel _contactModel;
        private FileService _fileService;

        public ContactModel_Tests()
        {
            //Arrange
            _contactModel = new ContactModel();
            _fileService = new FileService();
        }

        [Fact]
        public void 
            Contact_Model_Types_Check()
        {
            //Act & Assert
            _contactModel.FirstName.Should().BeOfType<string>();
            _contactModel.LastName.Should().BeOfType<string>();
            _contactModel.Email.Should().BeOfType<string>();
            _contactModel.PhoneNumber.Should().BeOfType<string>();
            _contactModel.Address.Should().BeOfType<string>();
        }

        [Fact]
        public void Contact_list_is_initially_empty()
        {
            //Act & Assert
            _fileService.Contacts().Should().HaveCount(0);
        }
    }
}