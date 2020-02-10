using PhoneBookTestApp.DL;
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
        const String FNAME = "Cynthia";
        const String LNAME = "Smith";
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
                string choice = "";
                do
                {

                    Console.WriteLine("1. DisplayPhoneBook");

                    Console.WriteLine("2. Insert Person Details in PhoneBook");

                    Console.WriteLine("3.Find Person By Name");

                    Console.WriteLine("4.Exit");

                    choice = Console.ReadLine();

                    switch (choice)

                    {

                        case "1":
                            #region DisplayPhoneBook
                            Console.WriteLine("------------------PhoneBook----------------");
                            phonebook.PrintPhoneBook(Display.Print);
                            #endregion
                            break;

                        case "2": //Do that
                            #region AddNewPerson
                            Console.WriteLine("-----------------Enter New Person ----------------");

                            Console.WriteLine("Enter First Name:");
                            string firstName = Console.ReadLine();

                            Console.WriteLine("Enter Last Name:");
                            string lastName = Console.ReadLine();
                            Person personObj = new Person();
                            if (Validation.ValidateName(firstName + " " + lastName))
                            {
                                personObj.Name = firstName + " " + lastName;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Name ,\n should contain only Letters\n Firstname lastname should not be blank\n");
                                break;
                            }
                            Console.WriteLine("Enter PhoneNumber Name:");
                            personObj.PhoneNumber = Console.ReadLine();

                            Console.WriteLine("Enter Address Name:");
                            personObj.Address = Console.ReadLine();

                            PhoneDL phoneDL = new PhoneDL();
                            phoneDL.InsertPerson(personObj);
                            #endregion
                            break;
                        case "3":
                            #region FindPerson
                            Console.WriteLine("------------------Searched Record----------------");

                            Console.WriteLine("Enter First Name:");
                            firstName = Console.ReadLine();

                            Console.WriteLine("Enter Last Name:");
                            lastName = Console.ReadLine();
                           
                            if (!Validation.ValidateName(firstName + " " + lastName))
                            {
                                Console.WriteLine("Invalid Name ,\n should contain only Letters\n Firstname lastname should not be blank\n");
                                break;
                            }
                            Person person = new Person();
                            person = phonebook.findPerson(firstName, lastName);
                            if (person != null)
                            {
                                Display.Print(person);
                            }
                            else
                            {
                                Console.WriteLine("Person " + firstName + " " + lastName + "Not found");
                                break;
                            }
                            #endregion
                            break;
                    }

                } while (choice != "4");

               

               
                

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

    }
}
