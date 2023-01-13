using EC04_C_sharp_Adress_book_ConsoleApp.Models;
using Newtonsoft.Json;
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
        private DatabaseService db = new DatabaseService();

        public string FilePath { get; set; } = null!;
        
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

        private void SubMenuOne()
        {
            IContact contact = new Contact();
            Console.WriteLine("Please enter the following information about your new contact.\nConfirm by pressing Enter.");
            MenuFooter();
            
            Console.Write("First name: ");
            var firstName = Console.ReadLine();
            contact.FirstName = firstName ?? null!;

            Console.Write("Last name: ");
            var lastName = Console.ReadLine();
            contact.LastName = lastName ?? null!;

            Console.Write("Email: ");
            var email = Console.ReadLine();
            contact.Email = email ?? null!;

            Console.Write("Phone number: ");
            var phoneNumber = Console.ReadLine();
            contact.PhoneNumber = phoneNumber ?? null!;

            Console.Write("Adress: ");
            var adress = Console.ReadLine();
            contact.Address = adress ?? null!;

            contacts.Add(contact);

            db.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
        }
        private void SubMenuTwo()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Sorry! your adress book is empty...\n");
                MenuFooter();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
                return;

            }
            else
            {
                //string fname = "First name";
                //string lname = "Last name";
                //string email = "Email";
                Console.WriteLine("Your adress book contains the following contacts: \n");
                //Console.ForegroundColor = ConsoleColor.Black;
                //Console.BackgroundColor = ConsoleColor.DarkGray;
                //Console.WriteLine($"{fname, -20}" + $"{lname,-20}" + $"{email,-20}");
                //Console.ResetColor();
                foreach (IContact contact in contacts)
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
            Console.WriteLine("\n\nPress any key to contiune.");
            Console.ReadKey(true);
        }
        private void SubMenuThree()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Sorry! your adress book is empty...\n");
                MenuFooter();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;

            }
            else
            {
                Console.WriteLine("Your adress book contains the following contacts: \n");
                int i = 1;
                foreach (IContact contact in contacts)
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
            Console.WriteLine("\n\nPress any key to contiune.");
            Console.ReadKey(true);
        }
        private void SubMenuFour()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Sorry! your adress book is empty...\n");
                MenuFooter();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
                return;

            }
            else
            {
                Console.WriteLine("Your adress book contains the following contacts: \n");
                int i = 1;
                foreach (IContact contact in contacts)
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
                var awnser = Console.ReadLine();
                Console.Clear();
                if (awnser.ToLower() == "y")
                {
                    contacts.RemoveAt(contactNumber);
                    MenuHeadings();
                    Console.WriteLine("Contact was removed.");
                    MenuFooter();
                    Console.WriteLine("\n\nPress any key to contiune.");
                    Console.ReadKey(true);
                    return;
                }
                else
                {
                    MenuHeadings();
                    Console.WriteLine("No contact was deleted.");
                    MenuFooter();
                    Console.WriteLine("\n\nPress any key to contiune.");
                    Console.ReadKey(true);
                    return;
                }
            }
            Console.WriteLine("\n\nPress any key to contiune.");
            Console.ReadKey(true);
        }
    }
}
