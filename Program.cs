using System;
using System.Data.SqlClient;
/*
	dotnet new console -o DotNetConsoleApp
    cd DotNetConsoleApp
    DotNetConsoleApp>dotnet add package System.Data.SqlClient 
    --------
    Create "Shopping" Sql Server Database 
    Create Products Table:
    CREATE TABLE Products(id int primary key Identity, name varchar(50));
*/
namespace DotNetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cnnString = "Database=shopping; Integrated Security=true"; 
            SqlConnection conn = new SqlConnection(cnnString);
            conn.Open();

            SqlCommand cmd;

            cmd = new SqlCommand("INSERT INTO Products(name) VALUES ('car')", conn);
            cmd = new SqlCommand("INSERT INTO Products(Name) VALUES ('pen')", conn);
            cmd.ExecuteNonQuery();      
                
            cmd = new SqlCommand("SELECT * FROM Products;", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}",
                reader[0], reader[1]));
            }
            reader.Close();
            conn.Close();
        }
    }
}
