using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC04_C_sharp_Adress_book_ConsoleApp.Models
{
    internal interface IContact
    {
        string Address { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        Guid Id { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }

    internal class Contact : IContact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
