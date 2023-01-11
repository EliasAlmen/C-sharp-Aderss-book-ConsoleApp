using EC04_C_sharp_Adress_book_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC04_C_sharp_Adress_book_ConsoleApp.Services
{
    internal class MenuService
    {
        
        private List<IContact> contacts = new List<IContact>();
        
        private void MenuHeadings()
        {
            Console.Clear();
            Console.WriteLine("THE ADRESS BOOK");
            Console.WriteLine("_____________________________________________________________________________\n");
        }
        private void MenuFooter()
        {
            Console.WriteLine("_____________________________________________________________________________\n\n");
        }
        private void MainMenuInputValidation(string userInput) 
        {
            while (userInput == "1" && userInput == "2" && userInput == "3" && userInput == "4")
            {
                Console.WriteLine("\nPlease input a valid number\n");
                Console.Write("Input: ");
                userInput = Console.ReadLine();
            }
        }

        public void MainMenu() 
        {
            MenuHeadings();

            Console.WriteLine("Choose an option by pressing a number on your keyboard and then hitting Enter.\n");
            Console.WriteLine("1. Create a contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Show a specific contact");
            Console.WriteLine("4. Remove a contact");

            MenuFooter();

            Console.Write("Your input: ");
            var userInput = Console.ReadLine();

            MainMenuInputValidation(userInput);

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    MenuHeadings();
                    SubMenuOne();
                    break;

                case "2":
                    Console.Clear();
                    MenuHeadings();
                    SubMenuTwo();
                    break;

                case "3":
                    Console.Clear();
                    MenuHeadings();
                    SubMenuThree();
                    MenuFooter();
                    break;

                case "4":
                    Console.Clear();
                    MenuHeadings();
                    SubMenuFour();
                    MenuFooter();
                    break;

                default:
                    break;
            }
        }

        private void SubMenuOne()
        {
            IContact contact = new Contact();
            Console.WriteLine("Please enter the following information about your new contact.\nConfirm by pressing Enter.");
            MenuFooter();
            
            Console.Write("First name: ");
            var firstName = Console.ReadLine();
            firstName = contact.FirstName;
            
            Console.Write("Last name: ");
            var LastName = Console.ReadLine();
            LastName = contact.LastName;

            Console.Write("Email: ");
            var email = Console.ReadLine();
            email = contact.Email;

            Console.Write("Phone number: ");
            var phoneNumber = Console.ReadLine();
            phoneNumber = contact.PhoneNumber;

            Console.Write("Adress: ");
            var adress = Console.ReadLine();
            adress = contact.Address;

            contacts.Add(contact);

        }
        private void SubMenuTwo()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Sorry! your adress book is empty...\n");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Your adress book contains the following contacts: test ");
                foreach (IContact contact in contacts)
                {
                    Console.WriteLine($"{contact.FirstName} \t {contact.LastName} \t {contact.Email}");
                }

            }
            Console.ReadKey();
        }
        private void SubMenuThree()
        {

        }
        private void SubMenuFour()
        {

        }
    }
}
