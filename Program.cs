using Azure;
using Microsoft.Data.SqlClient;

namespace TaskSqlBitis
{
    internal class Program
    {
        const string CONNECTION_STRING = "Server=B3-2\\SQLEXPRESS;Database=APPTASK;Trusted_Connection=True;TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            CreateTable();
            Insert("Salam", DateTime.Today);
            Insert("Sagol", DateTime.Today);
        }

        public static void CreateTable()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = "CREATE TABLE Post(Id int primary key identity(1,1),Title nvarchar(50),CreatedDate date)";
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    int result = sqlCommand.ExecuteNonQuery();
                }
            }
        }

            public static void Insert( string title, DateTime createdDate)
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();


                    string query = "INSERT into Post (title,createdDate) VALUES (@Title,@CreatedDate)";
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        
                        sqlCommand.Parameters.AddWithValue("@Title", title);
                        sqlCommand.Parameters.AddWithValue("@CreatedDate", createdDate);


                        int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Console.WriteLine(result+"row affected");
                        
                    }
                    else
                    {
                        Console.WriteLine("Xeta");
                    }
                }
                };

            }

         public static void DeleteById(int id)
        {

        }




        }
    }
