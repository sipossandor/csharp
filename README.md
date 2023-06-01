# csharp
WPF (Windows Presentation Foundation)
using MySql.Data.MySqlClient;
using System;
class Program {
  static void Main(string[] args) {
    // Connection String to connect with MySQL database.
    string connString = "server=localhost;userid=root;password=root";
    MySqlConnection conn = new MySqlConnection(connString);
    conn.Open();
    MySqlCommand cmd = new MySqlCommand("create database Sample_DB", conn);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Database Sample_DB created successfully");
    conn.Close();
  }
}
