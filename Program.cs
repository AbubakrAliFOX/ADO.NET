using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;

namespace ADO.NET
{
    internal class Program
    {
        static string connetionStr = "server=.;Database=ContactsDB;Integrated Security=True;";

        public struct stContact
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; } 

            public void printInfo ()
            {

                Console.WriteLine($"Contact ID: {ID}");
                Console.WriteLine($"Name: {FirstName} {LastName}");
                Console.WriteLine($"Email: {Email}");
                Console.WriteLine($"Phone: {Phone}");
                Console.WriteLine($"Address: {Address}");
                Console.WriteLine($"Country ID: {CountryID}");
                Console.WriteLine();
            }
        }
        static bool findContactById(int ID, ref stContact contact)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connetionStr);
            string query = "select * from Contacts where ContactID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    contact.ID = (int)reader["ContactID"];
                    contact.FirstName = (string)reader["FirstName"];
                    contact.LastName = (string)reader["LastName"];
                    contact.Email = (string)reader["Email"];
                    contact.Phone = (string)reader["Phone"];
                    contact.Address = (string)reader["Address"];
                    contact.CountryID = (int)reader["CountryID"];

                } else
                {
                    isFound = false;
                }

                reader.Close();
                connection.Close();

            }


            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return isFound;

        }
        static void searchContactsStartsWithLetter (string Letter)
        {
            SqlConnection connection = new SqlConnection(connetionStr);
            string query = "select * from Contacts where FirstName LIKE '' + @Letter + '%'";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Letter", Letter);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();

            }


            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        static void printAllContactsWithFirstName(string FirstName, int CountryID)
        {
            SqlConnection connection = new SqlConnection(connetionStr);
            string query = "select * from Contacts where FirstName = @FirstName and CountryID = @CountryID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();

            }


            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        static void printAllContacts ()
        {
            SqlConnection connection = new SqlConnection(connetionStr);

            string query = "select * from Contacts";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();

            }


            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        static void Main(string[] args)
        {
            //printAllContacts();
            //printAllContactsWithFirstName("Jane",2);
            //searchContactsStartsWithLetter("m");
            stContact contact = new stContact();
            if (findContactById(1, ref contact)) {
                contact.printInfo();
            } else
            {
                Console.WriteLine("Not Found!!");
            }

        }
    }
}
