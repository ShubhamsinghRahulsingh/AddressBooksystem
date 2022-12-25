using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBookADO_DOT_NET
    {
        //Specifying the connection string from the sql server connection.
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=true;";
        // Establishing the connection using the Sqlconnection.  
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        public void RetrieveEntriesFromAddressBookDB()
        {
            try
            {
                List<ContactADO> contactAdo = new List<ContactADO>();
                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    string query = @"select * from AddressBookADO";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = CommandType.Text;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ContactADO service = new ContactADO();
                            service.FirstName = dr.GetString(0);
                            service.LastName = dr.GetString(1);
                            service.Address = dr.GetString(2);
                            service.City = dr.GetString(3);
                            service.State = dr.GetString(4);
                            service.Zip = dr.GetInt32(5);
                            service.PhoneNUmber = dr.GetInt64(6);
                            service.Email = dr.GetString(7);
                            contactAdo.Add(service);
                        }
                        foreach (var data in contactAdo)
                        {
                            Console.WriteLine("Firstame:"+data.FirstName + "  "+"LastName:" + data.LastName + "  "+"Address:" + data.Address + "  "+"City:" + data.City + "  "+"State:" + data.State + "  "+"ZIP:" + data.Zip + "  "+"PhoneNo:" + data.PhoneNUmber+"  "+"Email:"+data.Email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateContactDetailsInDatabase()
        {
            try
            {
                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    string query = @"UPDATE AddressBookADO SET LastName='Saini',Address='Patel Nagar' WHERE FirstName='Dheeraj'";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = CommandType.Text;
                    int result = command.ExecuteNonQuery();
                    this.sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Details Updated Successfully");
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void RetrieveEntriesForParticularPeriodFromDB()
        {
            try
            {
                List<ContactADO> contactAdo = new List<ContactADO>();
                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    string query = @"select * from AddressBookADO where DOB BETWEEN '1992-04-16' AND '1999-02-03' ";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = CommandType.Text;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ContactADO service = new ContactADO();
                            service.FirstName = dr.GetString(0);
                            service.LastName = dr.GetString(1);
                            service.Address = dr.GetString(2);
                            service.City = dr.GetString(3);
                            service.State = dr.GetString(4);
                            service.Zip = dr.GetInt32(5);
                            service.PhoneNUmber = dr.GetInt64(6);
                            service.Email = dr.GetString(7);
                            contactAdo.Add(service);
                        }
                        foreach (var data in contactAdo)
                        {
                            Console.WriteLine("Firstame:" + data.FirstName + "  " + "LastName:" + data.LastName + "  " + "Address:" + data.Address + "  " + "City:" + data.City + "  " + "State:" + data.State + "  " + "ZIP:" + data.Zip + "  " + "PhoneNo:" + data.PhoneNUmber + "  " + "Email:" + data.Email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void CountNoOfContactsByCityOrState()
        {
            try
            {
                using (this.sqlconnection)
                {
                    Console.WriteLine("Select Whether to count By\n1.City\n2.State");
                    int sel = Convert.ToInt32(Console.ReadLine());
                    this.sqlconnection.Open();
                    switch (sel)
                    {
                        case 1:
                            string query = @"SELECT COUNT(*) From AddressBookADO WHERE CITY='Saharanpur'";
                            SqlCommand command = new SqlCommand(query, this.sqlconnection);
                            command.CommandType = CommandType.Text;
                            int result = command.ExecuteNonQuery();
                            SqlDataReader dr = command.ExecuteReader();
                            dr.Read();
                            Console.WriteLine("No Of Contacts in Particular City:" + dr.GetInt32(0));
                            this.sqlconnection.Close();
                            break;
                        case 2:
                            string queryy = @"SELECT COUNT(*) From AddressBookADO WHERE State='UP'";
                            SqlCommand commandd = new SqlCommand(queryy, this.sqlconnection);
                            commandd.CommandType = CommandType.Text;
                            int resultt = commandd.ExecuteNonQuery();
                            SqlDataReader dataReader = commandd.ExecuteReader();
                            dataReader.Read();
                            Console.WriteLine("No Of Contacts in Particular State:" + dataReader.GetInt32(0));
                            this.sqlconnection.Close();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void AddNewContactInDatabase()
        {
            try
            {
                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    string query = @"INSERT INTO AddressBookADO VALUES('Manish','Reddy','Prince Valley','Bangalore','KT',646463,8774743344,'manish@gmail.com','1994-09-02') ";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = CommandType.Text;
                    int result = command.ExecuteNonQuery();
                    this.sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("New Contact Added Successfully");
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
    }
}
