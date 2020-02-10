using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    public class Validation
    {
        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name, "^[A-Za-zÀ-ú]+ [A-Za-zÀ-ú]+$");
            
        }
    }
}
