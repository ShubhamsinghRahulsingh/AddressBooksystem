using System;
namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            Contact contact = new Contact() //object creation
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Convert.ToInt64(Console.ReadLine()),
                PhoneNUmber = Console.ReadLine(),
                Email = Console.ReadLine()

            };
            Console.WriteLine("Contact Details:"+"\n"+"FirstName: "+contact.FirstName+"\n"+"LastName: "+contact.LastName+"\n"+"Address: "+contact.Address+"\n"+"City: "+contact.City+"\n"+"State: "+contact.State+"\n"+"Zip: "+contact.Zip+"\n"+"PhoneNumber: "+contact.PhoneNUmber+"\n"+"Email: "+contact.Email);

        }
    }
}
