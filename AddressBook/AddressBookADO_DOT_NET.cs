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
    }
}
