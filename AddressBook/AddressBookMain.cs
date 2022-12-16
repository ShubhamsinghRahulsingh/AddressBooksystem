using CsvHelper;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace AddressBook
{
    public class AddressBookMain
    {
        List<Contact> address = new List<Contact>();
        Dictionary<string, List<Contact>> addressBook = new Dictionary<string, List<Contact>>();
        List<Contact> cityList = new List<Contact>();
        List<Contact> stateList = new List<Contact>();
        Dictionary<string, List<Contact>> cities = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> states = new Dictionary<string, List<Contact>>();
        public void CreateContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter the firstName");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the lastName");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter the City");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter the State");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter the Zip");
            contact.Zip = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the PhoneNumber");
            contact.PhoneNUmber = Console.ReadLine();
            Console.WriteLine("Enter the Email ID");
            contact.Email = Console.ReadLine();
            CheckForDuplicacy(address, contact);
        }
        public void EditContact()
        {
            Console.WriteLine("Enter the name whose details you want to edit");
            string editcontact = Console.ReadLine();
            foreach (var contact in address)
                if (contact.FirstName.Equals(editcontact) || contact.LastName.Equals(editcontact))
                {
                    Console.WriteLine("What you want to Edit" + "\n" + "Select 1.Address 2.City 3.State 4.Zip 5.PhoneNumber 6.Email ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter the new address");
                            contact.Address = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter the new city");
                            contact.City = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter the new state");
                            contact.State = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter the new zip");
                            contact.Zip = Convert.ToInt64(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Enter the new phone number");
                            contact.PhoneNUmber = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter the new email id");
                            contact.Email = Console.ReadLine();
                            break;

                    }
                }
        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter the name whose contact you want to delete");
            string delcontact = Console.ReadLine();
            Contact deletecontact = new Contact();
            foreach (var contact in address.ToList())
                if (contact.FirstName.Equals(delcontact) || contact.LastName.Equals(delcontact))
                {
                    deletecontact = contact;
                }
            address.Remove(deletecontact);
            Console.WriteLine("contact has been deleted successfully");
        }
        public void Display()
        {
            foreach (var contact in address)
            {
                Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + contact.FirstName + "\n" + "LastName: " + contact.LastName + "\n" + "Address: " + contact.Address + "\n" + "City: " + contact.City + "\n" + "State: " + contact.State + "\n" + "Zip: " + contact.Zip + "\n" + "PhoneNumber: " + contact.PhoneNUmber + "\n" + "Email: " + contact.Email);
            }

        }
        //UC7
        public void CheckForDuplicacy(List<Contact> address, Contact contact)
        {
            if (address.Any())
            {
                if (address.Any(e => e.FirstName == contact.FirstName && e.LastName==contact.LastName))//Lambda expression
                {
                    Console.WriteLine("A person with name {0} {1} is already existed", contact.FirstName,contact.LastName);
                    return;
                }
            }
            address.Add(contact);
        }
        //UC8
        public void SearchPersonInCityOrState(string searchName)
        {
            Console.WriteLine("1.Search Person In City\n2.Search Person In State");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter the City Name : ");
                    string cityName = Console.ReadLine();
                    foreach (var dictKey in addressBook)
                    {
                        foreach (var dictData in dictKey.Value.FindAll(x => x.City == cityName))
                        {
                            cityList.Add(dictData);
                            if (cityList.Any(x => x.FirstName == searchName))
                            {
                                Console.WriteLine("Person With Name {0} is found in the AddressBook in City {1}", searchName, cityName);
                                return;
                            }
                        }
                    }
                    Console.WriteLine("Person With Name {0} is not found in the AddressBook in City {1}", searchName, cityName);
                    break;

                case 2:
                    Console.Write("Enter the State Name : ");
                    string stateName = Console.ReadLine();
                    foreach (var dictKey in addressBook)
                    {
                        foreach (var dictData in dictKey.Value.FindAll(x => x.State == stateName))
                        {
                            stateList.Add(dictData);
                            if (stateList.Any(x => x.FirstName == searchName))
                            {
                                Console.WriteLine("Person With Name {0} is found in the AddressBook in State {1}", searchName, stateName);
                                return;
                            }
                        }
                    }
                    Console.WriteLine("Person With Name {0} is not found in the AddressBook in State {1}", searchName, stateName);
                    break;
            }
        }
        //UC9
        public void ViewPersonInCityOrState()
        {
            cityList = new List<Contact>();
            stateList = new List<Contact>();
            Console.WriteLine("1.Select Whether to view Persons by\n1.City\n2.State");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter the City Name : ");
                    string cityName = Console.ReadLine();
                    foreach (var dictKey in addressBook)
                    {
                        foreach (var dictData in dictKey.Value.FindAll(x => x.City == cityName))
                        {
                            cityList.Add(dictData);
                        }
                    }
                    cities.Add(cityName, cityList);
                    Console.WriteLine("Persons in City {0} are:", cityName);
                    foreach (var data in cities)
                    {
                        foreach (var contact in data.Value)// checking values inside keys
                        {
                            Console.WriteLine(contact.FirstName + " " + contact.LastName);
                        }

                    }
                    cities=new Dictionary<string, List<Contact>>();
                    break;
                case 2:
                    Console.Write("Enter the State Name : ");
                    string stateName = Console.ReadLine();
                    foreach (var dictKey in addressBook)
                    {
                        foreach (var dictData in dictKey.Value.FindAll(x => x.State == stateName))
                        {
                            stateList.Add(dictData);
                        }
                    }
                    states.Add(stateName, stateList);
                    Console.WriteLine("Persons in State {0} are:", stateName);
                    foreach (var data in states)
                    {
                        foreach (var contact in data.Value)// checking values inside keys
                        {
                            Console.WriteLine(contact.FirstName + " " + contact.LastName);
                        }

                    }
                    states = new Dictionary<string, List<Contact>>();
                    break;
            }
        }
        //UC10
        public void CountContactsByCityOrState()
        {
            cityList = new List<Contact>();
            stateList = new List<Contact>();
            Console.WriteLine("1.Select Whether to Count Contacts by\n1.City\n2.State");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter the City Name : ");
                    string cityName = Console.ReadLine();
                    foreach (var dictKey in addressBook)
                    {
                        foreach (var dictData in dictKey.Value.FindAll(x => x.City == cityName))
                        {
                            cityList.Add(dictData);
                        }
                    }
                    int countCity = cityList.Count();
                    Console.WriteLine("Total Contacts Persons With CityName {0} are: {1}", cityName, countCity);
                    break;
                case 2:
                    Console.Write("Enter the State Name : ");
                    string stateName = Console.ReadLine();
                    foreach (var dictKey in addressBook)
                    {
                        foreach (var dictData in dictKey.Value.FindAll(x => x.State == stateName))
                        {
                            stateList.Add(dictData);
                        }
                    }
                    int countState = stateList.Count();
                    Console.WriteLine("Total Contacts Persons With StateName {0} are: {1}", stateName, countState);
                    break;
            }
        }
        //UC11
        public void SortContactsByPersonsName()
        {
            foreach (var contact in addressBook)
            {
                Console.WriteLine("AddressBook Name is: "+contact.Key);
                foreach (var data in contact.Value.OrderBy(x => (x.FirstName + x.LastName)))
                {
                    Console.WriteLine("FirstName: " + data.FirstName + " LastName: " + data.LastName + " Address: " + data.Address + " City: " + data.City + " State: " + data.State + " Zip: " + data.Zip + " PhoneNumber: " + data.PhoneNUmber + " Email: " + data.Email);
                }
                Console.WriteLine();
            }
        }
        //UC12
        public void SortContactsByCityOrStateOrZIP()
        {
            
            Console.WriteLine("Select on which basis you want to Sort contacts\n1.City\n2.State\n3.ZIP");
            int select=Convert.ToInt32(Console.ReadLine());
            switch(select)
            {
                case 1:
                    foreach (var contact in addressBook)
                    {
                        Console.WriteLine("AddressBook Name is: " + contact.Key);
                        foreach (var data in contact.Value.OrderBy(x =>x.City))
                        {
                            Console.WriteLine("FirstName: " + data.FirstName + " LastName: " + data.LastName + " Address: " + data.Address + " City: " + data.City + " State: " + data.State + " Zip: " + data.Zip + " PhoneNumber: " + data.PhoneNUmber + " Email: " + data.Email);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    foreach (var contact in addressBook)
                    {
                        Console.WriteLine("AddressBook Name is: " + contact.Key);
                        foreach (var data in contact.Value.OrderBy(x =>x.State))
                        {
                            Console.WriteLine("FirstName: " + data.FirstName + " LastName: " + data.LastName + " Address: " + data.Address + " City: " + data.City + " State: " + data.State + " Zip: " + data.Zip + " PhoneNumber: " + data.PhoneNUmber + " Email: " + data.Email);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    foreach (var contact in addressBook)
                    {
                        Console.WriteLine("AddressBook Name is: " + contact.Key);
                        foreach (var data in contact.Value.OrderBy(x => x.Zip))
                        {
                            Console.WriteLine("FirstName: " + data.FirstName + " LastName: " + data.LastName + " Address: " + data.Address + " City: " + data.City + " State: " + data.State + " Zip: " + data.Zip + " PhoneNumber: " + data.PhoneNUmber + " Email: " + data.Email);
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }
        //UC13
        public void ReadAndWriteAddressBookToFile()
        {
            //Writing in  file
            string filePath = @"D:\GitRepository\AddressBooksystem\AddressBook\Files\AddressBook.txt";
            StreamWriter writer = new StreamWriter(filePath);
            foreach(var contact in addressBook)
            {
                Console.WriteLine("AddressBook Key Name is: ",contact.Key);
                foreach(var data in contact.Value)
                {
                    writer.WriteLine("FirstName: " + data.FirstName + " LastName: " + data.LastName + " Address: " + data.Address + " City: " + data.City + " State: " + data.State + " Zip: " + data.Zip + " PhoneNumber: " + data.PhoneNUmber + " Email: " + data.Email);
                }
            }
            writer.Close();

            //Reading from file
            StreamReader reader=new StreamReader(filePath);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
        }
        //UC14
        public void ReadOrWriteAddressBookFromAndToCsvFile()
        {
            //Writing in  CSV File
            string csvFilePath = @"D:\GitRepository\AddressBooksystem\AddressBook\Files\AddressBook.csv";
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
               foreach(var data in addressBook)
               {
                    List<Contact> csvlist = new List<Contact>();
                    foreach (var contact in data.Value)
                    {
                        csvlist.Add(contact);
                        csvWriter.WriteRecords(csvlist);
                    }
               }
            }
            //Reading from CSV File
            using (StreamReader reader = new StreamReader(csvFilePath))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<Contact>().ToList();
                foreach(var data in records)
                {
                    Console.WriteLine("FirstName: " + data.FirstName + " LastName: " + data.LastName + " Address: " + data.Address + " City: " + data.City + " State: " + data.State + " Zip: " + data.Zip + " PhoneNumber: " + data.PhoneNUmber + " Email: " + data.Email);
                }
            }
        }
        public void CreateDictionary()
        {
            Console.WriteLine("Enter with what name you want to add in dictionary");
            string name=Console.ReadLine();
            addressBook.Add(name, address);
            address = new List<Contact>();
        }
        public void DisplayDictionary()
        {
            foreach(var data in addressBook)
            {
                Console.WriteLine(data.Key);//printing dictionary keys
                foreach(var contact in data.Value)// checking values inside keys
                {
                    Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + contact.FirstName + "\n" + "LastName: " + contact.LastName + "\n" + "Address: " + contact.Address + "\n" + "City: " + contact.City + "\n" + "State: " + contact.State + "\n" + "Zip: " + contact.Zip + "\n" + "PhoneNumber: " + contact.PhoneNUmber + "\n" + "Email: " + contact.Email);
                }

            }
        }
    }
}
