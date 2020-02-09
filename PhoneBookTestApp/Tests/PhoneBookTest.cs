using NUnit.Framework;
using PhoneBookTestApp;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {

        [Test]
        public void addPerson()
        {
            int expected = 1;
            Person person = new Person("Varsha Modake", "2334", "dffg");
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.addPerson(person);
            int count =PhoneBook.phoneBookList.Count;
            Assert.AreEqual(expected, count);
            
        }

        [Test]
        public void findPerson()
        {
            string firstName = "Varsha";
            string LastName = "Modake";
            string ExpectedName = "VARSHA MODAKE";
            PhoneBook phoneBook = new PhoneBook();
            Person person= phoneBook.findPerson(firstName,LastName);
            Assert.AreEqual(ExpectedName, person.Name.ToUpper());
        }
    }

    // ReSharper restore InconsistentNaming 
}