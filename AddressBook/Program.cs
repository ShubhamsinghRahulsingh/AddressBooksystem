using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBookMain create = new AddressBookMain();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Select 1.To Create Contact 2.To Edit Contact 3.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        create.CreateContact();
                        create.Display();
                        break;
                    case 2:
                        create.EditContact("Shubham");
                        create.Display();
                        break;
                    case 3:
                        flag = false;
                        break;
                }
            }
        }      
    }
}
