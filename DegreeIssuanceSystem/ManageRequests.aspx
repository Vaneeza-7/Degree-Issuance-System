﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ManageRequests.aspx.cs" Inherits="ManageRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" >
         <div style="margin-left: 4px; background-color: black; height:60px;">

        </div>
       <div style="margin-left: 4px;margin-top: 25px; height: 42px;">

            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Text="Manage Requests"></asp:Label>
        </div>

        <div class="container mt-5">
            <asp:GridView ID="GridView1" border-color=black runat="server" CssClass="table table-hover" AutoGenerateColumns="False">
            <HeaderStyle BackColor="#343a40" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Token" HeaderText="Token" SortExpression="Token" />
                <asp:BoundField DataField="DateReceived" HeaderText="Date Received" SortExpression="DateReceived" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:TemplateField HeaderText="Admin Approved">
            <ItemTemplate>
                <%# Convert.ToBoolean(Eval("AdminApproved")) ? "✔️" : "Awaiting" %>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FYP Approved">
    <ItemTemplate>
        <%# Convert.ToBoolean(Eval("FYPApproved")) ? "✔️" : "Awaiting" %>
    </ItemTemplate>
</asp:TemplateField>
                        <asp:TemplateField HeaderText="Finance Approved">
    <ItemTemplate>
        <%# Convert.ToBoolean(Eval("FinanceApproved")) ? "✔️" : "Awaiting" %>
    </ItemTemplate>
</asp:TemplateField>
                 <asp:BoundField DataField="UserID" HeaderText="Student ID" SortExpression="UserID" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnViewDetails" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("UserID") %>' CssClass="btn btn-dark btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
             
            </asp:GridView>
        </div>

        <p style="margin-left: 4px; background-color: #343A40; height: 20px">

            </p>
    </form>
</asp:Content>
