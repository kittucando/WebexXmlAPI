<%@ Page Title="" Language="C#" MasterPageFile="~/Mster.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WebexTest3.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ol>
        <li><a href="APIValidationTest.aspx" target="_blank">Validation with GetUser</a>         </li>
        <li><a href="ApiAuthentication.aspx" target="_blank">Validate with authenticateuser </a></li>
          <li><a href="ValidateAPICreds.aspx" target="_blank">Validate with input fields</a></li>
        <li><a href="CreateMeeting.aspx" target="_blank">Create Meeting</a>         </li>
        <li><a href="DeleteMeeting.aspx" target="_blank">Delete Meeting</a></li>
       
       
        <li><a href="#">Get Meeting</a></li>

    </ol>

</asp:Content>
