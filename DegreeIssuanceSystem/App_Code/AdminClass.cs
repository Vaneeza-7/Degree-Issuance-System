using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminClass
/// </summary>
public class AdminClass
{
    public DBHandler dbHandler = new DBHandler();
    public int UserID { get; set; } //auto generated
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }

    public AdminClass(int UserID, string Email, string Password, string Address, string Name, string Designation)
    {
        this.UserID = UserID;
        this.Email = Email;
        this.Password = Password;
        this.Address = Address;
        this.Name = Name;
        this.Designation = Designation;
    }

    public AdminClass(string Email, string Password)
    {
        this.Email = Email;
        this.Password = Password;
    }

    public bool signIn() { 
        return dbHandler.signInAdmin(Email, Password);

    }
}