﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidateAPICreds.aspx.cs" Inherits="WebexTest3.ValidateAPICreds" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
        <div style="text-align:right;">            
            <table align="center">

                <tr>
                    <td>  <label>SiteName:</label></td>
                    <td> <asp:TextBox ID="txtSiteName" runat="server" Text="apidemoeu" /></td>
                </tr>
                <tr>
                    <td>  <label>WebexID:</label></td>
                    <td>  <asp:TextBox ID="txtWebexID" runat="server" Text="test_user" /></td>
                </tr>
                <tr>
                    <td>   <label>Password:</label></td>
                    <td>   <asp:TextBox ID="txtPassword" runat="server" Text="cisco!123" /></td>
                </tr>
             
               
                
                <tr>
                    <td></td>
                    <td style="text-align:right;">  <asp:Button ID="btnValidate" runat="server" Text="Validate" OnClick="btnValidate_Click" /></td>
                </tr>
               




            </table>

          &nbsp;&nbsp;
            <div style="clear:left;text-align:center;" />
                <asp:Label runat="server" ID="ltrlMessage"></asp:Label>

        </div>
        <div>
          
          

        </div>
        <div>
         
         

        </div>
         <div>
          
       

        </div>
         <div>
          
          

        </div>
         <div>
         
           

        </div>
        <div>
          
        </div>
    </form>
</body>
</html>