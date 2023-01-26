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
        private List<ContactModel> contacts;

        public FileService()
        {
            ReadFromFile();
        }

        // Tries to find file on desktop and deserializes it and updates contacts list with the data
        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<List<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = new List<ContactModel>(); }
        }

        // Saves JSON file on desktop
        private void SaveToFile()
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
