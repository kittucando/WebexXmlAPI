using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebexTest3
{
    public partial class DeleteMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
            WebexModel webex = new WebexModel
            {
                webExID = txtWebexID.Text,
                password = txtPassword.Text,
                siteName = txtSiteName.Text,
                requestUrl = "https://" + txtSiteName.Text + ".Webex.com/WBXService/XMLService",
                meetingkey = txtMeetingId.Text
            };
            string Meetingkey = string.Empty, guestToken = string.Empty, hostUrl = string.Empty, attendeeUrl = string.Empty;
            string strXML = WebexHelper.RequestXMLString(webex, "DELETE");
            string jsonText = WebexHelper.XMLResponseToString(webex.siteName, strXML);
            // To convert JSON text contained in string json into an XML node
            // XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonText);
            //  ltrlMessage.Text = jsonText;
            ltrlMessage.Text = jsonText;

        }

    }
}