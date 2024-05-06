<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentAcademicRecord.aspx.cs" MasterPageFile="~/Site.master" Inherits="StudentAcademicRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div style="margin-left: 4px; background-color: black; height: 60px;">
            <!-- Header -->
        </div>
        <div style="margin-left: 4px; margin-top: 25px; height: 42px;">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Student Academic Records"></asp:Label>
        </div>
        <div class="container mt-5">
                    <div class="row">
                        <div class="col-md-8">
                            <asp:Label ID="lblSearch" runat="server" Text="Search by Student ID:" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="txtSearchUserID" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-2 d-flex align-items-end">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-dark btn-sm" OnClick="btnSearch_Click" Font-Size="Large" />
                        </div>
                    </div>
                </div>
        <div class="container mt-5">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
                <HeaderStyle BackColor="#343a40" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" />
                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                    <asp:BoundField DataField="RecordID" HeaderText="Record ID" />
                    <asp:BoundField DataField="UserID" HeaderText="Student ID" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                    <asp:BoundField DataField="CGPA" HeaderText="CGPA" />
                    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblSearchResult" runat="server" Font-Bold="True" CssClass="mt-3" />
        </div>
    </form>
</asp:Content>
