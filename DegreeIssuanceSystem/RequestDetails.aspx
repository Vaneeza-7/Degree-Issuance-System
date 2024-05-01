<%@ Page Language="C#" AutoEventWireup="true" masterPageFile ="~/Site.master" CodeFile="RequestDetails.aspx.cs" Inherits="RequestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" >
         <div style="margin-left: 4px; background-color: black; height:60px;">

        </div>
       <div style="margin-left: 4px;margin-top: 25px; height: 42px;">

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Request Details"></asp:Label>
        </div>

<div class="container mt-3">
      <div style="padding-bottom: 10px;">
        <div class="row mb-2">
        <div class="col-md-3 font-weight-bold">Request Token:</div>
        <div class="col-md-9"><asp:Label ID="lblToken" runat="server" /></div>
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
        <div class="col-md-3 font-weight-bold">Date Received:</div>
        <div class="col-md-9"><asp:Label ID="lblDateReceived" runat="server" /></div>
    </div>
    <div class="row mb-2">
    <div class="col-md-3 font-weight-bold">Admin Approval:</div>
    <div class="col-md-9"><asp:Label ID="lblAdminApproved" runat="server" /></div>
    </div>
    <div class="row mb-2">
        <div class="col-md-3 font-weight-bold">FYP Approval:</div>
        <div class="col-md-9"><asp:Label ID="lblFYPApproved" runat="server" /></div>
    </div>
    <div class="row mb-2">
        <div class="col-md-3 font-weight-bold">Finance Approval:</div>
        <div class="col-md-9"><asp:Label ID="lblFinanceApproved" runat="server" /></div>
    </div>
     <div class="row mb-2">
    <div class="col-md-3 font-weight-bold">Student Academic Record:</div>
    <div class="col-md-9">
        <asp:HyperLink ID="academicLink" runat="server" Text="View Academic Record" NavigateUrl="~/AcademicRecordPage.aspx" />
    </div>
</div>
          </div>
        <div class="form-group">
                <label>FYP Department Comments:</label>
                <asp:TextBox ID="txtFYPComments" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="None" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Finance Department Comments:</label>
                <asp:TextBox ID="txtFinanceComments" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="None" ReadOnly="true"></asp:TextBox>
            </div>

        <h3>Approve or Reject Request</h3>
            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" CssClass="form-control" Placeholder="Enter comments (optional)"></asp:TextBox>
            <br />

        <div class="text-center mb-3">
            <asp:Button ID="btnApprove" runat="server" Width="100px" Text="Approve" CssClass="btn btn-success mr-2" OnClick="btnApprove_Click" />

            <asp:Button ID="btnReject" runat="server" Width="100px" Text="Reject" CssClass="btn btn-danger" OnClick="btnReject_Click" />
        </div>
        </div>
        <br />
        <p style="margin-left: 4px; background-color: #343A40; height: 20px">

            </p>
    </form>
</asp:Content>
