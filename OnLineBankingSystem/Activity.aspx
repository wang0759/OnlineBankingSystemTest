<%@ Page Title="Activity" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="test1.Activity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1>
    Account Activities
</h1>
    <div class="row">
        <div class="col-xs-6">
            Customer Name: 
        </div>
        <div class="col-xs-6">
            <asp:DropDownList CssClass="form-control" ID="drpCustomers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCustomers_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <br /> <br />
        <div class="row">
            <div class="col-lg-12">
                Checking Account Activities:
            </div>
            <asp:Table ID="tblCheckingActivity" CssClass="table" runat="server"></asp:Table>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-12">
                Saving Account Activities:
            </div>
            <asp:Table ID="tblSavingActivity" CssClass="table" runat="server"></asp:Table>
        </div>
    </div>





</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
