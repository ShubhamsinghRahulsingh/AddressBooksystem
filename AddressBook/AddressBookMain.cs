using System;
namespace AddressBook
{
    public class AddressBookMain
    {
        Contact contact = new Contact();
        public void CreateContact()
        {
            contact.FirstName = Console.ReadLine();
            contact.LastName = Console.ReadLine();
            contact.Address = Console.ReadLine();
            contact.City = Console.ReadLine();
            contact.State = Console.ReadLine();
            contact.Zip = Convert.ToInt64(Console.ReadLine());
            contact.PhoneNUmber = Console.ReadLine();
            contact.Email = Console.ReadLine();
        }
        public void Display()
        {
            Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + contact.FirstName + "\n" + "LastName: " + contact.LastName + "\n" + "Address: " + contact.Address + "\n" + "City: " + contact.City + "\n" + "State: " + contact.State + "\n" + "Zip: " + contact.Zip + "\n" + "PhoneNumber: " + contact.PhoneNUmber + "\n" + "Email: " + contact.Email);

        }
    }
}
