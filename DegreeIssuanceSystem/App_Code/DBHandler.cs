using System;
using System.Activities;
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

    public bool signInStudent(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Students WHERE Email = @email AND Password = @password", con))
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

    public bool signInDirector(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Directors WHERE Email = @email AND Password = @password", con))
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

    public bool signInFinanceAccountant(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM FinanceAccountants WHERE Email = @email AND Password = @password", con))
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

    public bool signInFYPDeptMembers(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM FYPDeptMembers WHERE Email = @email AND Password = @password", con))
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

    public AdminClass GetAdmin(string email, string password)
    {
        AdminClass admin = new AdminClass(email, password);
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Admins WHERE Email = @email", con))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admin.UserID = Convert.ToInt32(reader["UserID"]);
                            admin.Email = reader["Email"].ToString();
                            admin.Password = reader["Password"].ToString();
                            admin.Name = reader["Name"].ToString();
                            admin.Address = reader["Address"].ToString();
                            admin.Designation = reader["Designation"].ToString();
                        }
                    }
                    con.Close();
                    return admin;
                }
            }
        }
        catch (SqlException ex)
        {
            // Handle SQL-specific errors
            Console.WriteLine("A SQL error occurred: " + ex.Message);
            return null;

        }
        catch (Exception ex)
        {
            // Handle general errors
            Console.WriteLine("An error occurred: " + ex.Message);
            return null;
        }
    }

    public DataTable GetRequests()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM DegreeRequests";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            con.Open();
            adapter.Fill(dt);
            con.Close();
        }
        catch (Exception ex)
        {
            // Handle exception
            Console.WriteLine(ex.Message);
        }
        return dt;
    }
}
