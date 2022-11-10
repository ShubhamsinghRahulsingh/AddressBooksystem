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
                Console.WriteLine("Select 1.Create Contact 2.Edit Contact 3.Delete contact 4.Display contacts 5.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        create.CreateContact();
                        break;
                    case 2:
                        create.EditContact();
                        break;
                    case 3:
                        create.DeleteContact();
                        break;
                    case 4:
                        create.Display();
                        break;
                    case 5:
                        flag = false;
                        break;
                }
            }
        }      
    }
}
