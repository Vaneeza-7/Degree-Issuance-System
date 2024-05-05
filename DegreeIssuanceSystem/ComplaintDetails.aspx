<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComplaintDetails.aspx.cs" MasterPageFile="~/Site.master" Inherits="ComplaintDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" >
         <div style="margin-left: 4px; background-color: black; height:60px;">

        </div>
       <div style="margin-left: 4px;margin-top: 25px; height: 42px;">

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Complaint Details"></asp:Label>
        </div>

<div class="container mt-3">
      <div style="padding-bottom: 10px;">
        <div class="row mb-2">
        <div class="col-md-3 font-weight-bold">Complaint ID:</div>
        <div class="col-md-9"><asp:Label ID="lblComplaintID" runat="server" /></div>
    </div>
    <div class="row mb-2">
        <div class="col-md-3 font-weight-bold">Student ID:</div>
        <div class="col-md-9"><asp:Label ID="lblStudentID" runat="server" /></div>
    </div>
    <div class="row mb-2">
        <div class="col-md-3 font-weight-bold">Status:</div>
        <div class="col-md-9"><asp:Label ID="lblStatus" runat="server" /></div>
    </div>
    <div class="row mb-2">
        <div class="col-md-3 font-weight-bold">Type:</div>
        <div class="col-md-9"><asp:Label ID="lblType" runat="server" /></div>
    </div>
    <div class="row mb-2">
    <div class="col-md-3 font-weight-bold">Date:</div>
    <div class="col-md-9"><asp:Label ID="lblDate" runat="server" /></div>
    </div>
</div>
          </div>
        <div class="form-group">
                <label>Complaint Text:</label>
                <asp:TextBox ID="txtComplaint" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="None" ReadOnly="true"></asp:TextBox>
                <br />
            <label>Give Comments:</label>
            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" CssClass="form-control" Placeholder="Enter comments (optional)"></asp:TextBox> 
        </div>
        <h4>Select Status</h4>
        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Resolved" Value="Resolved"  style="margin-right:15px"></asp:ListItem>
                <asp:ListItem Text="Unresolved" Value="Unresolved" style="margin-right:15px"></asp:ListItem>
               <asp:ListItem Text="Closed" Value="Closed" style="margin-right:15px"></asp:ListItem>
               <asp:ListItem Text="Open" Value="Open" style="margin-right:15px"></asp:ListItem>
            <asp:ListItem Text="Pending" Value="Pending" style="margin-right:15px"></asp:ListItem>
            </asp:RadioButtonList>
         <br />
        <div class="text-center mb-3">
            <asp:Button ID="btnUpdate" runat="server" Width="100px" Text="Update" CssClass="btn btn-primary mr-2" OnClick="btnUpdate_Click" />
        </div>
        <br />
        <p style="margin-left: 4px; background-color: #343A40; height: 20px">
            </p>
    </form>
</asp:Content>
