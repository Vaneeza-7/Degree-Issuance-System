using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class Director
{

    public DBHandler dbHandler = new DBHandler();
    public int UserID { get; set; } //auto generated
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }

    public DateTime DateOfJoining { get; set; }
    public DateTime DateOfRetirement { get; set; }

    public Director(int UserID, string Email, string Password, string Address, string Name, DateTime DateOfJoining, DateTime DateOfRetirement)
    {
        this.UserID = UserID;
        this.Email = Email;
        this.Password = Password;
        this.Address = Address;
        this.Name = Name;
        this.DateOfJoining = DateOfJoining;
        this.DateOfRetirement = DateOfRetirement;
    }

    public Director(string Email, string Password)
    {
        this.Email = Email;
        this.Password = Password;
    }

    public bool signIn()
    {
        return dbHandler.SignInDirector(Email, Password);
    }

    public string[] GetDirectorInformation(string email)
    {
        return dbHandler.GetDirectorInformation(email);
    }

    public void MonitorRequests() { }
}