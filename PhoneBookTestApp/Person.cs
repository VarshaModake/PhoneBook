using System;

namespace PhoneBookTestApp
{
    public delegate void PhoneBookDel(Person person);
    public class Person:Display, IEquatable<Person>
    {
        private string name;
        private string phoneNumber;
        private string address;
      
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
     
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public Person()
        {

        }
        public Person(string Name,string PhoneNumber,string address)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Address = address;
        }

        public bool Equals(Person other)
        {
            if (other == null) return false;
            else return check(other);

            
        }
        public bool check(Person other)
        {
            if (other == null)
            { return false; }
            else
            return (this.Name.Equals(other.Name));
        }
        public void PrintPerson(PhoneBookDel del)
        {
            del(this);
        }
    }
}