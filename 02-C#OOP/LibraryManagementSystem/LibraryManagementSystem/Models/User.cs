using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public abstract class User
    {
        public string Name { get; set; } = string.Empty;
        public void DisplayBooks(Library library)
        {
            library.Display();
        }
    }
}
