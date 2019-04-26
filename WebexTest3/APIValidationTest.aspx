<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APIValidationTest.aspx.cs" Inherits="WebexTest3.APIValidationTest" %>

<!DOCTYPE html>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!-- saved from url=(0101)file://C:\Documents and Settings\Ellen\Local Settings\Temporary Internet Files\OLKE43\Generic-XML.htm -->
<html>
<head>
    <title>Test XML API</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
    <script language="javascript">
        function submitForm() {
            if (document.form.sitename.value != null) {
                var sitename = document.form.sitename.value;

                //if(document.form.preview.checked){
                //	var preview = "preview/";
                //}
                //else{
                //	var preview = "";
                //}

                var url = "https://" + sitename + ".webex.com/WBXService/XMLService";


                document.form.action = url;
                document.form.submit();
            }
            else {
                alert("You must supply a sitename");
                return false;
            }
        }
</script>

    <meta content="MSHTML 6.00.2900.2523" name="GENERATOR">
</head>
<body>
    <center>

       


<form name=form action="" method=post>

    <table>
    <tr>
        <td colspan="2" style="text-align:center;"><H3>Test XML API</H3> </td>
       
    </tr>
           <tr>
        <td> <B> Sitename: </B></td>
        <td><INPUT name=sitename> </td>
    </tr>
         <tr>
        <td><B>XML Text:</B> </td>
             <td><textarea name=XML rows=25 cols=90>&lt;?xml version="1.0" encoding="UTF-8"?&gt;
&lt;serv:message xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	 xmlns:serv="http://www.webex.com/schemas/2002/06/service"
	 xsi:schemaLocation="http://www.webex.com/schemas/2002/06/service
	 http://www.webex.com/schemas/2002/06/service/service.xsd"&gt;

	&lt;header&gt;
	   &lt;securityContext&gt;
	   &lt;webExID&gt;test_user&lt;/webExID&gt;
	   &lt;password&gt;cisco!123&lt;/password&gt;
	   &lt;siteName&gt;apidemoeu&lt;/siteName&gt;	 
	   &lt;returnAdditionalInfo&gt;TRUE&lt;/returnAdditionalInfo&gt;	
	   &lt;/securityContext&gt;
	&lt;/header&gt;

	&lt;body&gt;
		&lt;bodyContent xsi:type="java:com.webex.service.binding.site.GetSite"&gt;
	
		&lt;/bodyContent&gt;
	&lt;/body&gt;
&lt;/serv:message&gt;
</textarea> </td>
    </tr>
            <tr >
        <td colspan="2" style="text-align:center;">
    <INPUT onclick=submitForm() type="button" value="Test API">  </td>
       
    </tr>



</table>




    
   
    
  <%--  <input type=checkbox value=Yes name=preview>Use Preview<BR>--%>
    
    
    
</form></center>
</body>
</html>


