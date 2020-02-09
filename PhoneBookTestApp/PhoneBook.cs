using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;


namespace PhoneBookTestApp
{
    public class PhoneBook :IPhoneBook
    {
        public static IList<Person> phoneBookList = new List<Person>(); //For demo used List because we have only 5-6 records in real application can use Hash
       
        public void addPerson(Person person)
        {
            try
            {
                if (person != null)
                {
                    if (phoneBookList != null)
                    {
                        phoneBookList.Add(person);
                    }
                    else
                    {
                        phoneBookList = new List<Person>();
                        phoneBookList.Add(person);
                    }

                }
            }
            catch
            {
                throw;
            }
        }
        
       
        public void PrintPhoneBook(PhoneBookDel del)
        {
            PhoneBookDL bookDL = new PhoneBookDL();
            bookDL.RefereshPhoneBookWithDataBase(phoneBookList);
            foreach (Person person in phoneBookList)
            {
                del(person);
            }
        }
        
        public Person findPerson(string firstName, string lastName)
        {
            try {
                Person p1 = null;
                string Name = firstName + " " + lastName;
                foreach(Person person in phoneBookList)
                {
                    if(person.Name.ToLower().Equals(Name.ToLower()))
                    {
                        return person;
                    }
                }

                return p1;
                
            }
            catch
            {
                throw;
            }
           
        }
    }
}