using CommunityToolkit.Mvvm.ComponentModel;
using EC04_C_sharp_Adress_book_WpfApp.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC04_C_sharp_Adress_book_WpfApp.Services
{
    public class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contactswpf.json";
        

        private ObservableCollection<ContactModel> contacts;

        public FileService()
        {
            try
            {
                ReadFromFile();
            }
            catch 
            {
                contacts = new ObservableCollection<ContactModel>();
            }
        }

        // Tries to find file on desktop and deserializes it and updates contacts list with the data
        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = new ObservableCollection<ContactModel>(); }
        }

        // Saves JSON file on desktop
        public void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        // Add contact to contacts list
        public void AddToList(ContactModel contact)
        {
            contacts.Add(contact);
            SaveToFile();
        }

        // Remove contact from contacts list
        public void Delete(ContactModel contact)
        {
            contacts.Remove(contact);
            SaveToFile();
        }

        public static string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }


        // Populate listview with contacts
        public ObservableCollection<ContactModel> Contacts()
        {
            var items = new ObservableCollection<ContactModel>();
            foreach (var contact in contacts)
            {
                items.Add(contact);
            }
            return items;
        }
    }
}
