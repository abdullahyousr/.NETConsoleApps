using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class AppStart
    {
        internal static string userName { get; set; }

        internal void SavingUserName(string name)
        {
            userName = name;
        }
        
        internal void AppWelcome()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Hello {userName}! It's {DateTime.Now}");
            Console.WriteLine($"Welcome to the Math Game Application");
            Console.ReadLine();
        }
    }
}
