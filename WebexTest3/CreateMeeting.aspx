<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMeeting.aspx.cs" Inherits="WebexTest3.CreateMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create WebEx Meeting</title>
</head>
<body >
    <h2 style="text-align:center;"> Create WebEx Meeting</h2>
    
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
                    <td>  <label>Meeting Name:</label></td>
                    <td>     <asp:TextBox ID="txtMeetingName" runat="server" Text="" /></td>
                </tr>
                <tr>
                    <td>  <label>Start Date:</label></td>
                    <td>  <asp:TextBox ID="txtStartDate" runat="server" Text="" /></td>
                </tr>
                <tr>
                    <td>   <label>Duration:</label></td>
                    <td> <asp:TextBox ID="txtDuration" runat="server" Text="20" /></td>
                </tr>
                
                <tr>
                    <td></td>
                    <td style="text-align:right;">  <asp:Button ID="btnCreateMeeting" runat="server" Text="Create Meeting" OnClick="btnCreateMeeting_Click" /></td>
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
