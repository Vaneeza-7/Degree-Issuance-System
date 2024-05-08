using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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

    public string[] GetDirectorInformation(string email)
    {
        string[] directorInfo = new string[4]; // Adjust the array size based on the number of fields to retrieve

        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Name, Address, DateOfJoining, DateOfRetirement FROM Directors WHERE Email = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        directorInfo[0] = reader["Name"].ToString();
                        directorInfo[1] = reader["Address"].ToString();
                        directorInfo[2] = reader["DateOfJoining"].ToString();
                        directorInfo[3] = reader["DateOfRetirement"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
        }

        return directorInfo;
    }

    public bool SubmitComplaintForm(string email, DateTime date, string type, string complaint)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // First, retrieve the StudentID based on the email
                int studentId;
                using (SqlCommand cmdGetStudentId = new SqlCommand("SELECT UserID AS StudentID FROM Students WHERE email = @Email", con))
                {
                    cmdGetStudentId.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    object result = cmdGetStudentId.ExecuteScalar();
                    con.Close();

                    if (result == null)
                    {
                        return false;
                    }

                    studentId = Convert.ToInt32(result);
                }
                sendNotification(studentId, "Your complaint has been submitted.");

                using (SqlCommand cmd = new SqlCommand("INSERT INTO studentcomplaints (StudentID, Status, Type, Date, ComplaintText, AdminComments) VALUES (@StudentID, 'Open', @Type, @Date, @Complaint, NULL)", con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Complaint", complaint);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
             Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool SubmitDegreeRequest(string email, DateTime date)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // First, retrieve the StudentID based on the email
                int studentId;
                using (SqlCommand cmdGetStudentId = new SqlCommand("SELECT UserID AS StudentID FROM Students WHERE email = @Email", con))
                {
                    cmdGetStudentId.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    object result = cmdGetStudentId.ExecuteScalar();
                    con.Close();

                    if (result == null)
                    {
                        return false;
                    }

                    studentId = Convert.ToInt32(result);
                }

                sendNotification(studentId, "Your degree request has been submitted.");

                using (SqlCommand cmd = new SqlCommand("INSERT INTO DegreeRequests (DateReceived, Status, AdminApproved, FYPApproved, FinanceApproved, UserID, AdminComments, FYPComments, FinanceComments) VALUES (@DateReceived, 'Pending', 0, 0, 0, @StudentID, NULL, NULL, NULL)", con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@DateReceived", date);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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

    public DataTable GetApprovedRequests()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM DegreeRequests WHERE AdminApproved = 1 AND FYPApproved = 1 AND FinanceApproved = 1";
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

    public bool sendNotification(int receiverID, string text)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Notifications (ReceiverID, Text, Date) VALUES (@ReceiverID, @Text, @Date)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ReceiverID", receiverID);
                    cmd.Parameters.AddWithValue("@Text", text);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (log them, etc.)
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public DataTable GetDegreeReport(int studentID)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = @"
                SELECT 
                    s.Name AS 'StudentName',
                    s.RollNumber AS 'RollNumber',
                    s.Degree AS 'DegreeName',
                    d.DateOfIssuance AS 'DateOfIssuance',
                    d.GraduatingCGPA AS 'CGPA',
                    d.Signature
                FROM 
                    Students s
                INNER JOIN 
                    Degree d ON s.UserID = d.UserID
                WHERE 
                    s.UserID = @studentID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@studentID", studentID);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        catch (Exception ex)
        {
            // Handle exception
            Console.WriteLine(ex.Message);
            return null;
        }

    }

    public DataTable GetTranscriptData(int studentID)
    {
        DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                string query = @"
            SELECT 
                s.Name AS 'StudentName',
                s.RollNumber AS 'RollNumber',
                c.CourseID,
                c.CourseName,
                c.Grade,
                sar.CGPA,
                sar.CreditHours,
                SUM(sar.CreditHours) OVER() AS 'TotalCreditHours',
                d.Signature
            FROM 
                Students s
            INNER JOIN 
                StudentAcademicRecords sar ON s.UserID = sar.UserID
            INNER JOIN 
                Courses c ON sar.RecordID = c.RecordID
            LEFT JOIN 
                Degree d ON s.UserID = d.UserID
            WHERE 
                s.UserID = @studentID
            ORDER BY 
                c.CourseID;";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return null;
            }
    }

    public DataTable GetStudentAcademicRecords(int userId)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                c.CourseID,
                c.CourseName,
                sar.RecordID,
                sar.UserID,
                c.Grade,
                sar.CGPA,
                sar.CreditHours
            FROM 
                Courses c
            INNER JOIN 
                StudentAcademicRecords sar ON c.RecordID = sar.RecordID
            WHERE
                sar.UserID = @userId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                con.Close();
                return dt;
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
