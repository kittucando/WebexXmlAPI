using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class CreateMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrlMessage.Text = string.Empty;
        }

        protected void btnCreateMeeting_Click(object sender, EventArgs e)
        {
            WebexModel webex = new WebexModel
            {
                webExID = txtWebexID.Text,
                password = txtPassword.Text,
                siteName = txtSiteName.Text,
                requestUrl = "https://" + txtSiteName.Text + ".Webex.com/WBXService/XMLService",
                meetingName = txtMeetingName.Text,
                startDate = txtStartDate.Text,// "01/04/2019 19:30:00";
                duration = Convert.ToInt32(txtDuration.Text)
            };
            ltrlMessage.Text = WebexHelper.CreateWebexMeeting(webex);

            #region MyRegion
            //JObject data2 = JObject.Parse(jsonText);

            //if (data.Children().Contains("meet:meetingkey"))
            //{
            //    ltrlMessage.Text = (data.Children().Contains("meet:meetingkey").ToString());
            //}


            //string totalvalues = string.Empty;
            //foreach (var body in data)
            //{

            //    // totalvalues += item.Key.ToString() + ":" + item.Value.ToString();

            //    if (body.Value.Count() > 1)
            //    {
            //        foreach (var Content in body.Value)
            //        {
            //            if (Content.Contains("meet:iCalendarURL"))
            //            {
            //                totalvalues += Content.Single().ToString() + "\n";
            //            }


            //        }
            //    }


            //}
            //ltrlMessage.Text = totalvalues;


            //var nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            //nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            //nsmgr.AddNamespace("serv", "http://www.w3.org/1999/XSL/Transform");
            //var nl = xmlDoc.SelectNodes("//serv:message", nsmgr);
            ////XmlElement root = xmlDoc.DocumentElement;
            ////XmlNodeList nodes = root.SelectNodes("//serv:message/serv:body/serv:bodyContent");
            //foreach (XmlNode node in nl)
            //{
            //    Meetingkey = node["meet:meetingkey"].InnerText;
            //    guestToken = node["meet:guestToken"].InnerText;
            //    hostUrl = node["meet:iCalendarURL/serv:host"].InnerText;
            //    attendeeUrl = node["meet:iCalendarURL/serv:attendee"].InnerText;
            //}



            ////string status = xmlDoc.SelectSingleNode("//serv:message/serv:header/serv:response/serv:result").ToString();
            ////if (status.ToUpper() == "SUCCESS")
            ////{
            ////    XmlNodeList xnList = xmlDoc.SelectNodes("serv:message/serv:body");
            ////    Meetingkey = xmlDoc.SelectSingleNode("serv:message/serv:body/serv:bodyContent/meet:meetingkey").ToString();
            ////    guestToken = xmlDoc.SelectSingleNode("/serv:message/serv:body/serv:bodyContent/meet:guestToken").ToString();
            ////    hostUrl = xmlDoc.SelectSingleNode("/serv:message/serv:body/serv:bodyContent/meet:iCalendarURL/serv:host").ToString();
            ////    attendeeUrl = xmlDoc.SelectSingleNode("/serv:message/serv:body/serv:bodyContent/meet:iCalendarURL/serv:attendee").ToString();

            ////}
            ////else if (status.ToUpper() == "FAILURE")
            ////{
            ////    ltrlMessage.Text = "Error Occured:";
            ////}
            ////else
            ////{
            ////    ltrlMessage.Text = "Something went wrong";
            ////}


            //// string timeZone = data["Atlantic/Canary"].Value<string>();


            ////foreach (XmlNode xn in xnList)
            ////{
            ////    string firstName = xn["Meetingkey"].InnerText;
            ////    string lastName = xn["guestToken"].InnerText;
            ////    Console.WriteLine("Name: {0} {1}", firstName, lastName);
            ////}




            #endregion
        }


    }
}