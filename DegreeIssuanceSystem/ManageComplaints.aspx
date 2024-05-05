<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ManageComplaints.aspx.cs" Inherits="ManageComplaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" >
         <div style="margin-left: 4px; background-color: black; height:60px;">

        </div>
       <div style="margin-left: 4px;margin-top: 25px; height: 42px;">

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Manage Complaints"></asp:Label>
        </div>

        <div class="container mt-5">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" DataKeyNames="ComplaintID">
    <Columns>
        <asp:BoundField DataField="ComplaintID" HeaderText="ComplaintID" SortExpression="ComplaintID" />
        <asp:BoundField DataField="StudentID" HeaderText="StudentID" SortExpression="StudentID" />
        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="ComplaintText" HeaderText="ComplaintText" SortExpression="ComplaintText" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("ComplaintID") + "," + Eval("StudentID") %>' CssClass="btn btn-dark btn-sm" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle BackColor="#343a40" ForeColor="White" />
</asp:GridView>

        </div>

        <p style="margin-left: 4px; background-color: #343A40; height: 20px">

            </p>
    </form>
</asp:Content>
