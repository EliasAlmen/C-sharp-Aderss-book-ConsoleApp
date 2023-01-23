using EC04_C_sharp_Adress_book_ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EC04_C_sharp_Adress_book_ConsoleApp.Services
{


    internal class MenuService
    {
        
        private List<Contact> contacts = new List<Contact>();
        private readonly DatabaseService datab = new();

        public string FilePath { get; set; } = null!;
        

        public void MainMenu()
        {
            PopulateContacts();
            MenuHeadings();
            MenuOptions();
            MenuFooter();
            UserInput();
        }

        private void UserInput()
        {
            Console.Write("Your input: ");
            string userInput = Console.ReadLine() ?? "";

            var result = MainMenuInputValidation(userInput);

            switch (result)
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

        private void PopulateContacts()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<List<Contact>>(datab.Read(FilePath));
                if (items != null)
                {
                    contacts = items;
                }
            }
            catch { }
        }
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
        public string MainMenuInputValidation(string userInput)
        {
            bool validation = true;
            while (validation)
            {
                if (userInput == "1")
                {
                    validation = false;
                }
                else if (userInput == "2")
                {
                    validation = false;
                }
                else if (userInput == "3")
                {
                    validation = false;
                }
                else if (userInput == "4")
                {
                    validation = false;
                }
                else
                {
                    Console.WriteLine("\nPlease input a valid number\n");
                    Console.Write("Your input: ");
                    userInput = Console.ReadLine() ?? "";
                }
            }
            return userInput;
        }

        private void MenuOptions()
        {
            Console.WriteLine("Choose an option by pressing a number on your keyboard and then hitting Enter.\n");
            Console.WriteLine("1. Create a contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Show a specific contact");
            Console.WriteLine("4. Remove a contact");
        }
        private void SubMenuOne()
        {
            var contact = new Contact();
            Console.WriteLine("Please enter the following information about your new contact.\nConfirm by pressing Enter.");
            MenuFooter();

            AddContactInfo("First name");
            var firstName = UserInputContact("firstName");
            contact.FirstName = firstName ?? null!;

            AddContactInfo("Last name");
            var lastName = UserInputContact("lastName");
            contact.LastName = lastName ?? null!;

            AddContactInfo("Email");
            var email = UserInputContact("email");
            contact.Email = email ?? null!;

            AddContactInfo("Phone number");
            var phoneNumber = UserInputContact("phoneNumber");
            contact.PhoneNumber = phoneNumber ?? null!;

            AddContactInfo("Adress");
            var adress = UserInputContact("adress");
            contact.Address = adress ?? null!;

            contacts.Add(contact);

            datab.Save(FilePath, JsonConvert.SerializeObject(contacts));
        }

        private static string? UserInputContact(string? contactClassProperty)
        {
            contactClassProperty = Console.ReadLine();
            return contactClassProperty;
        }

        private static void AddContactInfo(string contactInfo)
        {
            Console.Write($"{contactInfo}: ");
        }

        private void SubMenuTwo()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Sorry! your adress book is empty...\n");
                MenuFooter();
                AnyKey();
                return;

            }
            else
            {
                Console.WriteLine("Your adress book contains the following contacts: \n");
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"{contact.FirstName, -20}" + $"{contact.LastName, -20}" + $"{contact.Email, -20}");
                    System.Threading.Thread.Sleep(200);
                    /*
                     So funny.. I spent alot of time building the if-statements below. But only to find out later that i can reserve space like above ', -20'
                     */

                    //if (contact.FirstName.Length <= 6 && contact.LastName.Length <= 5)
                    //{
                    //    Console.WriteLine($"{contact.FirstName}" + "\t" + "\t" + $"{contact.LastName}" + "\t" + "\t" + "\t" + "\t" + $"{contact.Email}");
                    //}
                    //else if (contact.FirstName.Length <= 7 && contact.LastName.Length <= 5)
                    //{
                    //    Console.WriteLine($"{contact.FirstName}" + "\t" + "\t" + $"{contact.LastName}" + "\t" + "\t" + "\t" + "\t" + $"{contact.Email}");
                    //}
                    //else if (contact.FirstName.Length <= 7 && contact.LastName.Length <= 7)
                    //{
                    //    Console.WriteLine($"{contact.FirstName}" + "\t" + "\t" + $"{contact.LastName}" + "\t" + "\t" + "\t" + "\t" + $"{contact.Email}");
                    //}
                    //else if (contact.FirstName.Length <= 7 && contact.LastName.Length <= 10)
                    //{
                    //    Console.WriteLine($"{contact.FirstName}" + "\t" + "\t" + $"{contact.LastName}" + "\t" + "\t" + "\t" + $"{contact.Email}");
                    //}
                    //else if (contact.FirstName.Length <= 7 && contact.LastName.Length >= 11)
                    //{
                    //    Console.WriteLine($"{contact.FirstName}" + "\t" + "\t" + $"{contact.LastName}" + "\t" + "\t" + "\t" + $"{contact.Email}");
                    //}
                    //else if (contact.FirstName.Length >= 8 && contact.LastName.Length <= 10)
                    //{
                    //    Console.WriteLine($"{contact.FirstName}" + "\t" + $"{contact.LastName}" + "\t" + "\t" + "\t" + $"{contact.Email}");
                    //}

                }
                MenuFooter();


            }
            AnyKey();
        }
        private void SubMenuThree()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Sorry! your adress book is empty...\n");
                MenuFooter();
                AnyKey();
                return;

            }
            else
            {
                Console.WriteLine("Your adress book contains the following contacts: \n");
                int i = 1;
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"#{i++, -5}" + $"{contact.FirstName, -20}" + $"{contact.LastName, -20}");
                    System.Threading.Thread.Sleep(200);

                }
                MenuFooter();
                string fname = "First name:";
                string lname = "Last name:";
                string email = "Email:";
                string phone = "Phone number:";
                string adress = "Adress:";
                Console.WriteLine("\nEnter contact position and press 'Enter' to see details.\n");
                Console.Write("Your input: ");
                var contactNumber = Convert.ToInt32(Console.ReadLine());
                contactNumber -= 1;
                Console.Clear();
                MenuHeadings(); 
                Console.WriteLine($"{fname, -20} {contacts[contactNumber].FirstName, -20}");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine($"{lname,-20} {contacts[contactNumber].LastName, -20}");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine($"{email,-20} {contacts[contactNumber].Email, -20}");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine($"{phone,-20} {contacts[contactNumber].PhoneNumber, -20}");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine($"{adress,-20} {contacts[contactNumber].Address, -20}");
                MenuFooter();
            }
            AnyKey();
        }
        private void SubMenuFour()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Sorry! your adress book is empty...\n");
                MenuFooter();
                AnyKey();
                return;

            }
            else
            {
                Console.WriteLine("Your adress book contains the following contacts: \n");
                int i = 1;
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"#{i++,-5}" + $"{contact.FirstName,-20}" + $"{contact.LastName,-20}");
                    System.Threading.Thread.Sleep(200);

                }
                MenuFooter();
                Console.WriteLine("\nEnter contact position and press 'Enter' to DELETE.\n");
                Console.Write("Your input: ");
                var contactNumber = Convert.ToInt32(Console.ReadLine());
                contactNumber -= 1;
                Console.Clear();
                MenuHeadings(); 
                Console.WriteLine($"Are you sure you want to delete contact: {contacts[contactNumber].FirstName} {contacts[contactNumber].LastName} ? y/n");
                MenuFooter();   
                Console.Write("Your input: ");
                var awnser = Console.ReadLine() ?? null!;
                Console.Clear();
                if (awnser.ToLower() == "y")
                {
                    contacts.RemoveAt(contactNumber);
                    datab.Save(FilePath, JsonConvert.SerializeObject(contacts));
                    MenuHeadings();
                    Console.WriteLine("Contact was removed.");
                    MenuFooter();
                    AnyKey();
                    return;
                }
                else if (awnser.ToLower() == "n")
                {
                    MenuHeadings();
                    Console.WriteLine("No contact was deleted.");
                    MenuFooter();
                    AnyKey();
                    return;
                }
                else 
                {
                    MenuHeadings();
                    Console.WriteLine("Input not recognized");
                    MenuFooter();
                    AnyKey();
                    return;
                }
            }
        }

        private static void AnyKey()
        {
            Console.WriteLine("\n\nPress any key to contiune.");
            Console.ReadKey(true);
        }
    }
}
