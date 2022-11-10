﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AddressBook
{
    public class AddressBookMain
    {
        List<Contact> address = new List<Contact>();
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
            address.Add(contact);
        }
        public void EditContact()
        {
            Console.WriteLine("Enter the name whose details you want to edit");
            string editcontact= Console.ReadLine();
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
            string delcontact=Console.ReadLine();
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
    }
}
