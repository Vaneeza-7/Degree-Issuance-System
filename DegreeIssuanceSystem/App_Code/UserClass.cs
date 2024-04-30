using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserClass
/// </summary>
public class UserClass
{
    public int UserID { get; set; } //auto generated
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }

    public void login() { }
    public void logout() { }
    public void updateProfile() { }
    public void resetPassword() { }

    public UserClass(int UserID, string Email, string Password)
    {
        this.UserID = UserID;
        this.Email = Email;
        this.Password = Password;
    }
}