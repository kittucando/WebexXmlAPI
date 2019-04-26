using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebexTest3
{
    public partial class ValidateAPICreds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            WebexModel webex = new WebexModel
            {
                webExID = txtWebexID.Text,
                password = txtPassword.Text,
                siteName = txtSiteName.Text,
                requestUrl = "https://" + txtSiteName.Text + ".Webex.com/WBXService/XMLService",                
            };
            string Meetingkey = string.Empty, guestToken = string.Empty, hostUrl = string.Empty, attendeeUrl = string.Empty;
            string strXML = WebexHelper.RequestXMLString(webex, "VALIDATE");
            string jsonText = WebexHelper.XMLResponseToString(webex.siteName, strXML);         
            ltrlMessage.Text = jsonText;
        }
    }
}