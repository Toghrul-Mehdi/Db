using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=Departmentss;Trusted_Connection=True;";

        string[] Name = { "Name1", "Name2", "Name3" };
        string[] Surname = { "SurName1", "SurName2", "SurName3" };
        double[] Salary = { 100.00, 200.00, 300.00 }; 
        string[] Email = { "togrul@gmail.com", "turan@gmail.com", "kenan@gmail.com" };
        string[] DepartmentName = { "Oba", "Araz", "Bravo" };

        string query = "INSERT INTO Employees (Name, Surname, Salary, Email, DepartmentName) VALUES (@Name, @Surname, @Salary, @Email, @DepartmentName)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    for (int i = 0; i < Name.Length; i++)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Name", Name[i]);
                        command.Parameters.AddWithValue("@Surname", Surname[i]);
                        command.Parameters.AddWithValue("@Salary", Salary[i]);
                        command.Parameters.AddWithValue("@Email", Email[i]);
                        command.Parameters.AddWithValue("@DepartmentName", DepartmentName[i]);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) added: {Name[i]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
