# csharp
WPF (Windows Presentation Foundation)
using MySql.Data.MySqlClient;  
using System;  
class Program {  
  static void Main(string[] args) {  
    //Connection String to connect with MySQL database.  
    string connString = "server=localhost;userid=root;password=root;database=Sample_DB";  
    MySqlConnection conn = new MySqlConnection(connString);  
    conn.Open();  
    MySqlCommand cmd = new MySqlCommand("INSERT INTO employee(eid,ename, salary) VALUES(@eid,@ename,@salary)", conn);  
    cmd.Parameters.AddWithValue("@eid", 101);  
    cmd.Parameters.AddWithValue("@ename", "Amit Kumar");  
    cmd.Parameters.AddWithValue("@salary", 43200);  
    cmd.Prepare();  
    cmd.ExecuteNonQuery();  
    Console.WriteLine("Record inserted successfully");  
    conn.Close();  
  }  
}  
// C# program to print the column values of a   
// specified MySql database table.  
using MySql.Data.MySqlClient;  
using System;  
class Program {  
  static void Main(string[] args) {  
    // Connection String to connect with MySQL database.  
    string connString = "server=localhost;userid=root;password=root;database=Sample_DB";  
    MySqlConnection conn = new MySqlConnection(connString);  
    conn.Open();  
    MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee", conn);  
    MySqlDataReader reader;  
    reader = cmd.ExecuteReader();  
    while (reader.Read()) {  
      Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetUInt32(2));  
    }  
    conn.Close();  
  }  
}  


