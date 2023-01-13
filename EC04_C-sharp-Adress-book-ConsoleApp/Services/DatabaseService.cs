using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC04_C_sharp_Adress_book_ConsoleApp.Services
{
    internal class DatabaseService
    {
        public void Save(string filePath, string content)
        {
           using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
        }

        public string Read(string filePath) 
        {
            try
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
            catch { return null!; }
        }
    }
}
