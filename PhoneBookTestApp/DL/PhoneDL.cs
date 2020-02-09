using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp.DL
{
    public class PhoneDL
    {
        public void InsertPerson(Person personObj)
        {
            try
            {
                
                    using (var sQLiteConnection = DatabaseUtil.GetConnection())
                    {
                        var sqlString = "insert into PHONEBOOK(Name,PhoneNumber,Address)values('" + personObj.Name + "','" + personObj.PhoneNumber + "','" + personObj.Address + "')";
                        DatabaseUtil.InsertPhoneBook(sqlString, sQLiteConnection);
                    }
                
            }
            catch
            {
                throw;
            }

        }
    }
}
