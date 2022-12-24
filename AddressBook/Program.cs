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
            AddressBookADO_DOT_NET ado = new AddressBookADO_DOT_NET();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1.Create Contact\n2.Edit Contact\n3.Delete contact\n4.Display contacts\n5.Create Dictionary\n6.Display Dictionary\n7.SearchPersonInCityOrState\n8.ViewPersonInCityOrState\n9.CountContactsByCityOrState\n10.SortContactsByPersonsName\n11.SortContactsByCityOrStateOrZIP\n12.ReadAndWriteAddressBookToFile\n13.ReadOrWriteAddressBookFromAndToCsvFile\n14.ReadOrWriteAddressBookToJSONFile\n15.RetrieveEntriesFromAddressBookDB\n16.UpdateContactDetailsInDatabase\n17.Exit");
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
                        create.CreateDictionary();
                        break;
                    case 6:
                        create.DisplayDictionary();
                        break;
                    case 7:
                        Console.WriteLine("Enter the name to be searched");
                        string name=Console.ReadLine();
                        create.SearchPersonInCityOrState(name);
                        break;
                    case 8:
                        create.ViewPersonInCityOrState();
                        break;
                    case 9:
                        create.CountContactsByCityOrState();
                        break;
                    case 10:
                        create.SortContactsByPersonsName();
                        break;
                    case 11:
                        create.SortContactsByCityOrStateOrZIP();
                        break;
                    case 12:
                        create.ReadAndWriteAddressBookToFile();
                        break;
                    case 13:
                        create.ReadOrWriteAddressBookFromAndToCsvFile();
                        break;
                    case 14:
                        create.ReadOrWriteAddressBookToJSONFile();
                        break;
                    case 15:
                        ado.RetrieveEntriesFromAddressBookDB();
                        break;
                    case 16:
                        ado.UpdateContactDetailsInDatabase();
                        break;
                    case 17:
                        flag = false;
                        break;
                }
            }
        }      
    }
}
