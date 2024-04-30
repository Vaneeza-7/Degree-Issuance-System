using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBHandler
/// </summary>
public class DBHandler
{
    string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";
    public DBHandler()
    {
    }

    public bool signInAdmin(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admins WHERE Email = @email AND Password = @password", con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        // Logic for successful authentication
                        return true;
                    }
                    else
                    {
                        // Logic for failed authentication
                        return false;
                    }
                }
                con.Close();
            }

        }
        catch (SqlException ex)
        {
            // Handle SQL-specific errors
            Console.WriteLine("A SQL error occurred: " + ex.Message);
            return false;

        }
        catch (Exception ex)
        {
            // Handle general errors
            Console.WriteLine("An error occurred: " + ex.Message);
            return false;
        }
        

    }

}
