using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class PhoneBookDL
    {
        public void InsertPhoneBookToDataBase()
        {
            try
            {
                foreach (Person person in PhoneBook.phoneBookList)
                {
                    using (var sQLiteConnection = DatabaseUtil.GetConnection())
                    {
                        var sqlString = "insert into PHONEBOOK(Name,PhoneNumber,Address)values('" + person.Name + "','" + person.PhoneNumber + "','" + person.Address + "')";
                        DatabaseUtil.InsertPhoneBook(sqlString, sQLiteConnection);
                    }
                }
            }
            catch
            {
                throw;
            }
            
        }
        public  void RefereshPhoneBookWithDataBase(IList<Person> phoneBookList)
        {
            try
            {
                using (var sQLiteConnection = DatabaseUtil.GetConnection())
                {
                    var sqlString = "Select * from PHONEBOOK";
                    SQLiteDataReader sQLiteData = DatabaseUtil.GetPersonDetail(sqlString, sQLiteConnection);
                    if (sQLiteData.HasRows)
                    {
                        while (sQLiteData.Read())
                        {
                            Person personPhoneBook = new Person();
                            personPhoneBook.Name = sQLiteData[0].ToString();
                            personPhoneBook.PhoneNumber = sQLiteData[1].ToString();
                            personPhoneBook.Address = sQLiteData[2].ToString();
                            if (!phoneBookList.Contains(personPhoneBook))
                            {
                                phoneBookList.Add(personPhoneBook);

                            }
                        }
                    }
                    else
                    {
                        throw new System.Exception("Data is not available");
                    }
                }

            }
            catch
            {
                throw;
            }
        }
        }
    }
