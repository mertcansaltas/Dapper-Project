using System;
using System.Data.SqlClient;
using Dapper;
namespace Ornek1
{
    public class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=DESKTOP-6B51G3S;Database=RehberDosyasi;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veritabanından veri sorgulama
                var query = "SELECT * FROM Users";
                var users = connection.Query<Users>(query);
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.ID}, Name: {user.FirstName}");
                }

                // Veritabanına veri ekleme
                var insertQuery = "INSERT INTO Users (ID,FirstName) VALUES (@ID, @FirstName)";
                var result = connection.Execute(insertQuery, new { ID = 7, FirstName = "Selman" });

                Console.WriteLine($"Eklendi: {result}");

                //Veritabanında veri sorgulama
                var query1 = "SELECT * FROM Users WHERE Age>26";
                var users1 = connection.Query<Users>(query1);
                foreach (var user1 in users1)
                {
                    Console.WriteLine($" dsfdsfID: {user1.ID}, Name: {user1.FirstName}");
                }

                //Güncelleme
                var updateQuery = "UPDATE Users SET FirstName = @NewName WHERE ID = @UserId";
                var parameters = new { NewName = "Şeref", UserId = 2 };

                int rowsAffected = connection.Execute(updateQuery, parameters);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Update successful!");
                }
                else
                {
                    Console.WriteLine("User with ID 2 not found or no changes made.");
                }
                var query3 = "SELECT * FROM Users";
                var users3 = connection.Query<Users>(query3);
                foreach (var user in users3)
                {
                    Console.WriteLine($"ID: {user.ID}, Name: {user.FirstName}");
                }
                //Silme
                var deleteQuery = "DELETE FROM Users WHERE ID = @UserId";
                var parameters2 = new { UserId = 3 };

                int rowsAffected2 = connection.Execute(deleteQuery, parameters);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Deletion successful!");
                }
                else
                {
                    Console.WriteLine("User with ID 3 not found or no changes made.");
                }
            }
        }
       
    }
}