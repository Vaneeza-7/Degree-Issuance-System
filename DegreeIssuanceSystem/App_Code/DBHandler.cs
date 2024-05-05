using System;
using System.Data;
using System.Data.SqlClient;

public class DBHandler
{
    string connectionString = "Data Source=DESKTOP-D3DRLR7\\SQLEXPRESS;Initial Catalog=onestop;Integrated Security=True;TrustServerCertificate=True;";

    public DBHandler() { }

    public bool signInAdmin(string email, string password)
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

    //admin functions added by Vaneeza
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

    //admin approve request function
    public void ApproveRequest(string token, string comments)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DegreeRequests SET AdminApproved = 1, AdminComments = @comments WHERE Token = @token", con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt update request. An error occurred: " + ex.Message);
        }
    }

    //admin reject request function
    public void RejectRequest(string token, string comments)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DegreeRequests SET AdminApproved = 0, AdminComments = @comments WHERE Token = @token", con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt update request. An error occurred: " + ex.Message);
        }
    }

    //fyp department approve request function
    public void ApproveRequestFYP(string token, string comments)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DegreeRequests SET FYPApproved = 1, FYPComments = @comments WHERE Token = @token", con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt update request. An error occurred: " + ex.Message);
        }
    }

    //fyp department reject request function
    public void RejectRequestFYP(string token, string comments)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DegreeRequests SET FYPApproved = 0, FYPComments = @comments WHERE Token = @token", con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt update request. An error occurred: " + ex.Message);
        }
    }

    //finance department approve request function
    public void ApproveRequestFinance(string token, string comments)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DegreeRequests SET FinanceApproved = 1, FinanceComments = @comments WHERE Token = @token", con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt update request. An error occurred: " + ex.Message);
        }
    }

    //finance department reject request function
    public void RejectRequestFinance(string token, string comments)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DegreeRequests SET FinanceApproved = 0, FinanceComments = @comments WHERE Token = @token", con))
                {
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Parameters.AddWithValue("@comments", comments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt update request. An error occurred: " + ex.Message);
        }
    }

    public bool UpdateComplaintStatus(int complaintID, string status, string AdminComments)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE StudentComplaints SET Status = @status, AdminComments = @AdminComments WHERE ComplaintID = @complaintID", con))
                {
                    cmd.Parameters.AddWithValue("@complaintID", complaintID);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@AdminComments", AdminComments);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt update complaint status. An error occurred: " + ex.Message);
            return false;
        }
    }

    public StudentComplaint GetComplaintDetails(int complaintID)
    {
        StudentComplaint complaint = new StudentComplaint(complaintID);
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM StudentComplaints WHERE ComplaintID = @complaintID", con))
                {
                    cmd.Parameters.AddWithValue("@complaintID", complaintID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            complaint.ComplaintID = Convert.ToInt32(reader["ComplaintID"]);
                            complaint.StudentID = Convert.ToInt32(reader["StudentID"]);
                            complaint.Status = reader["Status"].ToString();
                            complaint.Type = reader["Type"].ToString();
                            complaint.Date = Convert.ToDateTime(reader["Date"]);
                            complaint.ComplaintText = reader["ComplaintText"].ToString();
                            complaint.AdminComments = reader["AdminComments"].ToString();
                        }
                    }
                    con.Close();
                    return complaint;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldnt get complaint details. An error occurred: " + ex.Message);
            return null;
        }
    }
}
