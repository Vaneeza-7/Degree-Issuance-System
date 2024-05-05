using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default :  System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void studentbtn_Click(object sender, EventArgs e)
    {

        Response.Redirect("studentlogin.aspx");
    }
    protected void adminbtn_Click(object sender, EventArgs e)
    {

        Response.Redirect("AdminLogin.aspx");
    }
    protected void directorbtn_Click(object sender, EventArgs e)
    {

        Response.Redirect("Login.aspx");
    }
    protected void fypbtn_Click(object sender, EventArgs e)
    {

        Response.Redirect("Login.aspx");
    }
    protected void accountantbtn_Click(object sender, EventArgs e)
    {

        Response.Redirect("Login.aspx");
    }
}