using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    
   public class Display
    {
        public static void Print(Person person)
        {
            string message = "First Name: {0}\nPhone Number: {1}\nAddress: {2}\n";
            Console.WriteLine(string.Format(message, person.Name, person.PhoneNumber, person.Address));
        }
    }
}
