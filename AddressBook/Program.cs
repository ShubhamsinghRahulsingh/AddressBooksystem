using System;
namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBookMain create = new AddressBookMain();
            create.CreateContact();
            create.Display();
        }      
    }
}
