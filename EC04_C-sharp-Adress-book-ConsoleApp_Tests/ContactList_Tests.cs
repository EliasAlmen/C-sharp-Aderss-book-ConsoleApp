using EC04_C_sharp_Adress_book_ConsoleApp.Models;
using EC04_C_sharp_Adress_book_ConsoleApp.Services;

namespace EC04_C_sharp_Adress_book_ConsoleApp_Tests
{
    public class ContactList_Tests
    {
        private MenuService _menuService;
        Contact contact;

        public ContactList_Tests()
        {
            //Arrange
            _menuService = new MenuService();
            contact = new Contact();
        }

        [Fact]
        public void Expected_to_add_contact_to_list()
        {
            //Act
            _menuService.contacts.Add(contact);

            //Assert
            Assert.Single(_menuService.contacts);
        }

        [Fact]
        public void Expected_to_remove_contact_from_list()
        {
            //Act
            _menuService.contacts.Add(contact);
            _menuService.contacts.Remove(contact);

            //Assert
            Assert.Empty(_menuService.contacts);
        }
    }
}