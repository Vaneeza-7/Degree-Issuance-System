<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" >
        <div style="margin-left: 4px; background-color: black; height:60px; width: 1177px">

        </div>
        <div style="margin-left: 4px;margin-top: 25px; height: 42px;">

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Admin Profile"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="         |       "></asp:Label>
            <asp:Label ID="Label2" runat="server" Font-Names="Times New Roman" Font-Size="Small" Text="HOME"></asp:Label>
        
        </div>

        <div style="border: thin solid #000000; margin-left: 4px; width: 1177px; margin-top: 10px; height: 135px;">
        
            <p style="margin-left: 0px; background-color:#343A40; width: 1178px; margin-top: 0px;">
                <asp:Image ID="Image1" runat="server" Width="33px" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfBLhnA-5RgTFwYxyGrQkUhKMjJY7nBwIHtA&amp;usqp=CAU" Height="30px" />
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large" Text="University Information" ForeColor="White"></asp:Label>
&nbsp;&nbsp;</p>
            <p style="margin-left: 80px">
         &nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="User ID :"></asp:Label>
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label18" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="Designation: "></asp:Label>
                <asp:Label ID="Label20" runat="server" style="margin-left: 18px" ForeColor="Black"></asp:Label>
            </p>
        </div>
        <div style="border: thin solid #000000; margin-left:4px; margin-top: 10px; height: 262px; width: 1177px;">
            <p style="margin-left: 0px; background-color:#343A40; width: 1178px; margin-top: 0px;">

                <asp:Image ID="Image2" runat="server" Height="32px" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSxwBSld3XNShoHRPdqsl9tYETtMwnQr9DhBw&amp;usqp=CAU" Width="32px" />
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large" Text="Personal Information" ForeColor="White"></asp:Label>

            </p>

            <p style="margin-left: 80px">

                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="Name: "></asp:Label>
                <asp:Label ID="Label21" runat="server" style="margin-left: 12px" ForeColor="Black"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="DOB: "></asp:Label>
                <asp:Label ID="Label22" runat="server" style="margin-left: 22px" ForeColor="Black">04-09-2002</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="Gender: "></asp:Label>
                <asp:Label ID="Label23" runat="server" style="margin-left: 18px" ForeColor="Black">Male</asp:Label>

            </p>

            <p style="margin-left: 80px; width: 1092px;">

                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="CNIC: "></asp:Label>
                <asp:Label ID="Label24" runat="server" style="margin-left: 11px">61101-56409828</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="Nationality: "></asp:Label>
                <asp:Label ID="Label25" runat="server" style="margin-left: 15px" ForeColor="Black">Pakistani</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="Email: "></asp:Label>
                <asp:Label ID="Label26" runat="server" style="margin-left: 7px"></asp:Label>

            </p>

            <p style="margin-left: 80px; width: 1091px;">

                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="Mobile No.: "></asp:Label>
                <asp:Label ID="Label27" runat="server" style="margin-left: 16px" ForeColor="Black">+92 3135364365</asp:Label>

            </p>

        </div>

        <div style="border: thin solid #000000; margin-left:4px; margin-top: 10px; height: 159px; outline-width: 10px; outline-color:dodgerblue; width: 1177px;">
           
            <p style="margin-left: 0px; background-color:#343A40; width: 1180px; margin-top: 0px;">

                <asp:Image ID="Image3" runat="server" Height="40px" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQwl19B2TzhQTLW0ogadwsmdLC98xs7PtaJQ&amp;usqp=CAU" Width="49px" />
                <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large" Text="Contact Information" ForeColor="White"></asp:Label>
            
            </p>
           
            <p style="margin-left: 80px; width: 1096px;">

                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Text="Address: "></asp:Label>
                <asp:Label ID="Label28" runat="server" style="margin-left: 16px">House 67 AK Brohi Road Islamabad</asp:Label>
            
            </p>

        </div>
        
        <div style="border: thin solid #000000; margin-left:4px; margin-top: 10px; height: 45px; outline-width: 10px; outline-color:dodgerblue; width: 1177px;">
        
            <p style="margin-left: 0px; background-color:#343A40; width: 1180px; margin-top: 0px; height: 47px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           

           </p>
            
        </div>

    </form>
</asp:Content>
