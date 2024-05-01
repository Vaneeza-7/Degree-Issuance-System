using System;
using System.Data;
using System.Data.SqlClient;

public class DBHandler
{
    string connectionString = "Data Source=DESKTOP-PAN5U9D\\SQLEXPRESS01;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";

    public DBHandler() { }

    public bool SignInAdmin(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admins WHERE Email = @Email AND Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return false;
        }
    }

    public bool SignInStudent(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Students WHERE Email = @Email AND Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return false;
        }
    }

    public bool SignInDirector(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Directors WHERE Email = @Email AND Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return false;
        }
    }

    public bool SignInFinanceAccountant(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM FinanceAccountants WHERE Email = @Email AND Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return false;
        }
    }

    public bool SignInFYPDeptMembers(string email, string password)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM FYPDeptMembers WHERE Email = @Email AND Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    return result > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return false;
        }
    }

    public string[] GetStudentInformation(string email)
    {
        string[] studentInfo = new string[3]; // Adjust the array size based on the number of fields to retrieve

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Name, RollNumber, Degree FROM Students WHERE Email = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        studentInfo[0] = reader["Name"].ToString();
                        studentInfo[1] = reader["RollNumber"].ToString();
                        studentInfo[2] = reader["Degree"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
        }

        return studentInfo;
    }

    public bool SubmitComplaintForm(string complaint)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ComplaintForm (Date, Status, Complaint) VALUES (GETDATE(), 'Open', @Complaint)", con))
                {
                    cmd.Parameters.AddWithValue("@Complaint", complaint);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return false;
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

    public DegreeRequest GetRequestDetails(string token)
    {
        DegreeRequest degreeRequest = new DegreeRequest(token);
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DegreeRequests WHERE Token = @token", con))
                {
                    cmd.Parameters.AddWithValue("@token", token);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            degreeRequest.Token = reader["Token"].ToString();
                            degreeRequest.DateReceived = Convert.ToDateTime(reader["DateReceived"]);
                            degreeRequest.Status = reader["Status"].ToString();
                            degreeRequest.AdminApproved = Convert.ToBoolean(reader["AdminApproved"]);
                            degreeRequest.FYPApproved = Convert.ToBoolean(reader["FYPApproved"]);
                            degreeRequest.FinanceApproved = Convert.ToBoolean(reader["FinanceApproved"]);
                            degreeRequest.StudentID = Convert.ToInt32(reader["UserID"]);
                            degreeRequest.AdminComments = reader["AdminComments"].ToString();
                            degreeRequest.FYPComments = reader["FYPComments"].ToString();
                            degreeRequest.FinanceComments = reader["FinanceComments"].ToString();
                        }
                    }
                    con.Close();
                    return degreeRequest;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return null;
        }
    }

    public DataTable GetComplaints()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM StudentComplaints";
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
