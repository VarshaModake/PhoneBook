﻿using PhoneBookTestApp.DL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private static PhoneBook phonebook = new PhoneBook();

        //temporary constants 
        const String FNAME = "Dave";
        const String LNAME = "Williams";
        //Dave Williams
        static void Main(string[] args)
        {
            try
            {
                /* TODO: create person objects and put them in the PhoneBook and database
               * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
               * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
               */
                // TODO: print the phone book out to System.out
                // TODO: find Cynthia Smith and print out just her entry
                // TODO: insert the new person objects into the database
                #region InitializeDataBase 
                DatabaseUtil.CleanUp();
                DatabaseUtil.initializeDatabase();
                #endregion
                
                #region LoadData
                List<Person> personList = LoadJson.LoadData();
                #endregion

                #region AddDataToPhoneBook
                foreach (Person personItem in personList)
                {
                    phonebook.addPerson(personItem); //add data into phoneBook
                }
                #endregion

                #region AddDataToDataBase
                PhoneBookDL phoneBookOperations = new PhoneBookDL();
                phoneBookOperations.InsertPhoneBookToDataBase(); //Add data into DataBase
                #endregion

                #region DisplayPhoneBook
                Console.WriteLine("------------------PhoneBook----------------");
                phonebook.PrintPhoneBook(Display.Print);
                #endregion

                #region FindPerson
                Console.WriteLine("------------------Searched Record----------------");

                Person person = new Person();
                person = phonebook.findPerson(FNAME, LNAME);
                if (person != null)
                {
                    Display.Print(person);
                }
                else
                {
                    Console.WriteLine("Person " +FNAME+" "+LNAME +"Not found");
                    throw new System.ArgumentException("Person Not Present In PhoneBook", FNAME+" " +LNAME);
                }
                #endregion

                #region AddNewPerson
                Console.WriteLine("-----------------Enter New Person ----------------");

                Console.WriteLine("Enter First Name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine();

                person.Name = firstName + " " + lastName;

                Console.WriteLine("Enter PhoneNumber Name:");
                person.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Enter Address Name:");
                person.Address = Console.ReadLine();

                PhoneDL phoneDL = new PhoneDL();
                phoneDL.InsertPerson(person);
                #endregion

                Console.WriteLine("------------------PhoneBook----------------");
                phonebook.PrintPhoneBook(Display.Print);


                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

    }
}
