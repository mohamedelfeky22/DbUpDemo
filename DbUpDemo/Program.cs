using DbUp;
using System;

namespace DbUpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the connection string to your SQL Server database
            var connectionString = "Server=DESKTOP-UJ65KS0\\SQLEXPRESS;Database=DbUpDemo;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=True";

            // Create the upgrader object to manage database migrations
            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem("Scripts")  // Point to the folder with migration scripts
                .LogToConsole()  // Log output to the console
                .Build();

            // Perform the migration
            var result = upgrader.PerformUpgrade();

            // Check the result of the migration
            if (result.Successful)
            {
                Console.WriteLine("Database upgrade successful!");
            }
            else
            {
                Console.WriteLine("Database upgrade failed: " + result.Error);
            }
        }
    }
}
